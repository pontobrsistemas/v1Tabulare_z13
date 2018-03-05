using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System;
using System.Collections.Generic;
using controller;
using model.objetos;
using System.Threading;
using System.Data.OleDb;


namespace tabulare.supervisor
{
    public partial class fMailing : Form
    {
        private static int iQtdeImportado;
        private static int iLinha;
        private static double dPercentualImportado;
        private string sArquivo;
        private string sNomeMailing;
        private static string sMotivo;
        private static prospect[] Prospects;
        private static DataTable dataBlacklist;
        private static string sCaminho;
        private static DataSet dataSetMailing;

        public fMailing()
        {
            InitializeComponent();
        }

        private void ListarMailings(int iIDCampanha)
        {
            mailingCTL CMailing = new mailingCTL();
            dgMailing.DataSource = CMailing.RetornarMailings(Convert.ToBoolean(chkListarAtivos.Checked), iIDCampanha);
        }

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
            CCampanha.PreencherComboBox_Campanhas(comboCampanha_filtro, true, true, false, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void cmdNovo_Click(object sender, EventArgs e)
        {
            try
            {
                string sMensagem;
                iQtdeImportado = 0;
                txtIDMailing.Text = "";
                radSim.Checked = true;
                radNao.Checked = false;

                txtMailing.Text = "Mailing - " + DateTime.Now.ToString("ddMMyyyy HHmmss");

                OpenFileDialog FileDialog = new OpenFileDialog();
                DialogResult DialogResult;
            
                FileDialog.Title = "Abrir Como";
                FileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                DialogResult = FileDialog.ShowDialog();
                string sEnderecoCompletoArquivo = FileDialog.FileName;
                sArquivo = FileDialog.SafeFileName;
                txtArquivo.Text = sEnderecoCompletoArquivo;
                

                if (string.IsNullOrEmpty(sEnderecoCompletoArquivo))
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("[Arquivo] inválido.", "Tabulare");
                }
                else
                {
                    dataSetMailing = new DataSet();
                    dataSetMailing = PontoBr.Banco.Excel.RetornarRegistrosExcel(sEnderecoCompletoArquivo);

                    if (dataSetMailing.Tables.Count == 0)
                    {
                        PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("Nenhum registro encontrado no arquivo!", "Tabulare");
                        return;
                    }
                    if (dataSetMailing.Tables[0].Columns[0].ColumnName == "Erro")
                    {
                        PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(dataSetMailing.Tables[0].Rows[0]["Erro"].ToString(), "Tabulare");
                        return;
                    }
                    else
                    {
                        dgMailingPlanilha.DataSource = dataSetMailing.Tables[0];
                        grpMailing.Text = "Mailing - " + dataSetMailing.Tables[0].Rows.Count.ToString() + " registro(s)";
                        
                    }

                    sMensagem = "Resumo da leitura do arquivo: \n";
                    sMensagem += "================= \n";
                    sMensagem += "Quantidade de registros do arquivo: " + dataSetMailing.Tables[0].Rows.Count.ToString() + "\n";
                    sMensagem += "================= \n";
                    sMensagem += "Clique no botão Importar para salvar os registros.";
                    MessageBox.Show(sMensagem, "Tabulare");
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void AtualizarBarraStatus()
        {
            dPercentualImportado = Convert.ToDouble(iQtdeImportado / Convert.ToDouble(dataSetMailing.Tables[0].Rows.Count)) * Convert.ToDouble(100);
            prbProgresso.Value = Convert.ToInt32(dPercentualImportado);
            prbProgresso.Step = 1;
            prbProgresso.PerformStep();
        }

        private void linkArquivo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("importacao_mailing.xls");
        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            if (PodeImportar())
            {
                Cursor.Current = Cursors.WaitCursor;

                mailing Mailing = new mailing();
                Mailing.Mailing = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtMailing.Text);
                Mailing.IDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
                Mailing.Ativo = radSim.Checked == true ? 1 : 0;
                string sImportarDuplicado = chkDuplicado.Checked == true ? "Não" : "Sim";

                int iIDMailing = new mailingCTL().CadastrarMailing(Mailing, fLogin.Usuario.IDUsuario);

                prospect[] Prospects = new prospect[dataSetMailing.Tables[0].Rows.Count];
                int i = 0;
                ArrayList ProspectInvalidosLista = new ArrayList();

                foreach (DataRow dataRowProspect in dataSetMailing.Tables[0].Rows)
                {
                    try
                    {
                        if (RegistroValido(dataRowProspect))
                        {
                            AtualizarBarraStatus();

                            prospect Prospect = new prospect();
                            try
                            {
                                string sTelefone1 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[0].ToString().Trim());
                                string sTelefone2 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[1].ToString().Trim());
                                string sTelefone3 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[2].ToString().Trim());
                                string sNome = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[3].ToString().Trim());
                                string sCPF_CNPJ = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[4].ToString().Trim());
                                string sLogradouro = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[5].ToString().Trim());
                                string sNumero = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[6].ToString().Trim());
                                string sComplemento = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[7].ToString().Trim());
                                string sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[8].ToString().Trim());
                                string sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[9].ToString().Trim());
                                string sEstado = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[10].ToString().Trim());
                                string sEmail = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[11].ToString().Trim());
                                string sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[12].ToString().Trim());

                                string sCampo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[13].ToString().Trim());
                                string sCampo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[14].ToString().Trim());
                                string sCampo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[15].ToString().Trim());
                                string sCampo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[16].ToString().Trim());
                                string sCampo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[17].ToString().Trim());
                                string sCampo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[18].ToString().Trim());
                                string sCampo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[19].ToString().Trim());
                                string sCampo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[20].ToString().Trim());
                                string sCampo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[21].ToString().Trim());
                                string sCampo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRowProspect[22].ToString().Trim());

                                Prospect.Telefone1 = Convert.ToDouble(sTelefone1);
                                Prospect.Telefone2 = sTelefone2 == "" ? 0 : Convert.ToDouble(sTelefone2);
                                Prospect.Telefone3 = sTelefone3 == "" ? 0 : Convert.ToDouble(sTelefone3);
                                Prospect.Nome = sNome.Replace("'", "");
                                Prospect.CPF_CNPJ = sCPF_CNPJ.Replace("'", "");
                                Prospect.Logradouro = sLogradouro.Replace("'", "");
                                Prospect.Numero = sNumero.Replace("'", "");
                                Prospect.Complemento = sComplemento.Replace("'", "");
                                Prospect.Bairro = sBairro.Replace("'", "");
                                Prospect.Cidade = sCidade.Replace("'", "");
                                Prospect.Estado = sEstado.Replace("'", "");
                                Prospect.Email = sEmail.Replace("'", "");
                                Prospect.Cep = sCep.Replace("'", "");

                                Prospect.Campo01 = sCampo01.Replace("'", "");
                                Prospect.Campo02 = sCampo02.Replace("'", "");
                                Prospect.Campo03 = sCampo03.Replace("'", "");
                                Prospect.Campo04 = sCampo04.Replace("'", "");
                                Prospect.Campo05 = sCampo05.Replace("'", "");
                                Prospect.Campo06 = sCampo06.Replace("'", "");
                                Prospect.Campo07 = sCampo07.Replace("'", "");
                                Prospect.Campo08 = sCampo08.Replace("'", "");
                                Prospect.Campo09 = sCampo09.Replace("'", "");
                                Prospect.Campo10 = sCampo10.Replace("'", "");

                                Prospect.IDMailing = iIDMailing;
                                Prospect.ImportarDuplicado = sImportarDuplicado;

                                Prospects[i] = Prospect;
                                iQtdeImportado++;
                            }
                            catch { }
                        }
                        else
                        {
                            prospect ProspectInvalido = new prospect();

                            ProspectInvalido.sLinha = "";
                            for (int iColuna = 0; iColuna < dataRowProspect.ItemArray.Length; iColuna++)
                            {
                                if (ProspectInvalido.sLinha != "")
                                    ProspectInvalido.sLinha = ProspectInvalido.sLinha + ";";

                                ProspectInvalido.sLinha = ProspectInvalido.sLinha + dataRowProspect[iColuna].ToString();
                            }

                            ProspectInvalido.sMotivo = sMotivo;
                            ProspectInvalido.IDMailing = iIDMailing;
                            ProspectInvalidosLista.Add(ProspectInvalido);
                        }
                        i++;
                    }
                    catch { }
                }
                
                prospectCTL CProspect = new prospectCTL();
                CProspect.ImportarProspect(Prospects);
                CProspect.CadastrarProspectInvalidoLista(ProspectInvalidosLista);

                Cursor.Current = Cursors.Default;
                
                string sQtdeImportado = CProspect.RetornarQtdeProspectMailing(iIDMailing);

                string sMensagem;
                sMensagem = "Resumo da importação: \n";
                sMensagem += "================= \n";
                sMensagem += "Quantidade de registros do arquivo: " + dataSetMailing.Tables[0].Rows.Count.ToString() + "\n";
                sMensagem += "Quantidade de registros importados: " + sQtdeImportado;

                /*Verifica se há registro inválido.
                Se houver, salva relatório na área de trabalho e exibem mensagem*/
                if (dataSetMailing.Tables[0].Rows.Count != Convert.ToInt64(sQtdeImportado))
                {
                    DataTable dataTable = CProspect.RetornarProspectsInvalido(iIDMailing);

                    DataGrid dataGrid = new DataGrid();
                    dataGrid.DataSource = dataTable;

                    string sEnderecoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare-ProspectInvalido_" + txtMailing.Text + ".xls";
                    dataTable.TableName = "Tabulare";
                    dataTable.WriteXml(sEnderecoArquivo, System.Data.XmlWriteMode.IgnoreSchema);

                    sMensagem += "\n\nFoi salvo na Área de Trabalho arquivo com prospects\ninválidos (não importados).";
                }

                //Exclui mailing se não importou nenhum registro
                try
                {
                    if (sQtdeImportado == "0")
                        CProspect.ExcluirMailing(iIDMailing);
                }
                catch { }

                LimparFormulario();
                MessageBox.Show(sMensagem, "Tabulare");
            }            
        }

          private bool RegistroValido(DataRow dataRow)
        {
            sMotivo = "";

            if (dataRow.ItemArray.Length != 23)
            {
                sMotivo = "Registro não possui 23 colunas";
                return false;
            }
            string sTelefone1 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[0].ToString().Trim());
            string sTelefone2 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[1].ToString().Trim());
            string sTelefone3 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[2].ToString().Trim());
            string sNome = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[3].ToString().Trim());
            string sCPF_CNPJ = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[4].ToString().Trim());
            string sLogradouro = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[5].ToString().Trim());
            string sNumero = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[6].ToString().Trim());
            string sComplemento = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[7].ToString().Trim());
            string sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[8].ToString().Trim());
            string sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[9].ToString().Trim());
            string sEstado = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[10].ToString().Trim());
            string sEmail = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[11].ToString().Trim());
            string sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[12].ToString().Trim());

            string sCampo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[13].ToString().Trim());
            string sCampo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[14].ToString().Trim());
            string sCampo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[15].ToString().Trim());
            string sCampo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[16].ToString().Trim());
            string sCampo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[17].ToString().Trim());
            string sCampo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[18].ToString().Trim());
            string sCampo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[19].ToString().Trim());
            string sCampo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[20].ToString().Trim());
            string sCampo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[21].ToString().Trim());
            string sCampo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(dataRow[22].ToString().Trim());

            double dTelefone1, dTelefone2, dTelefone3;

            //Telefone1////////////////////////////////////////////////////////
            //Verifica se o Telefone1 é numérico
            try
            {
                dTelefone1 = Convert.ToDouble(sTelefone1);
                sTelefone1 = dTelefone1.ToString();
            }
            catch
            {
                sMotivo = "[Telefone 1] não é numérico";
                return false;
            }

            //Verifica se o Telefone1 tem 10 ou 11 dígitos
            if (sTelefone1.Length != 10 && sTelefone1.Length != 11)
            {
                sMotivo = "[Telefone 1] não possui 10 ou 11 caracteres";
                return false;
            }
            //////////////////////////////////////////////////////////

            //Telefone2////////////////////////////////////////////////////////
            //Verifica se o Telefone2 é numérico
            try
            {
                if (sTelefone2 != "")
                {
                    dTelefone2 = Convert.ToDouble(sTelefone2);
                    sTelefone2 = dTelefone2.ToString();

                    //Verifica se o Telefone2 tem 10 ou 11 dígitos
                    if (sTelefone2.Length != 10 && sTelefone2.Length != 11)
                    {
                        sMotivo = "[Telefone 2] não possui 10 ou 11 caracteres";
                        return false;
                    }
                }
            }
            catch
            {
                sMotivo = "[Telefone 2] não é numérico";
                return false;
            }

            //Verifica se o Telefone3 é numérico
            try
            {
                if (sTelefone3 != "")
                {
                    dTelefone3 = Convert.ToDouble(sTelefone3);
                    sTelefone3 = dTelefone3.ToString();

                    //Verifica se o Telefone3 tem 10 ou 11 dígitos
                    if (sTelefone3.Length != 10 && sTelefone3.Length != 11)
                    {
                        sMotivo = "[Telefone 3] não possui 10 ou 11 caracteres";
                        return false;
                    }
                }
            }
            catch
            {
                sMotivo = "[Telefone 3] não é numérico";
                return false;
            }

            /*Verifica se o telefone já existe no mesmo mailing*/
            if (Prospects != null)
                for (int i = 0; i < Prospects.Length; i++)
                {
                    if (Prospects[i] != null) /*Verifica se há prospect*/
                    {
                        if (Prospects[i].Telefone1 == dTelefone1)
                        {
                            sMotivo = "[Telefone 1] já existe no mesmo mailing";
                            return false;
                        }
                    }
                }

            //Verifica se o tamanho do Nome é maior que 200
            if (sNome.Length >= 200)
            {
                sMotivo = "[Nome] possui mais de 200 caracteres";
                return false;
            }
            if (sCPF_CNPJ.Length >= 50)
            {
                sMotivo = "[CPF / CNPJ] possui mais de 200 caracteres";
                return false;
            }
            if (sLogradouro.Length >= 200)
            {
                sMotivo = "[Logradouro] possui mais de 200 caracteres";
                return false;
            }
            if (sNumero.Length >= 50)
            {
                sMotivo = "[Número] possui mais de 200 caracteres";
                return false;
            }
            if (sComplemento.Length >= 50)
            {
                sMotivo = "[Complemento] possui mais de 200 caracteres";
                return false;
            }
            if (sBairro.Length >= 200)
            {
                sMotivo = "[Bairro] possui mais de 200 caracteres";
                return false;
            }
            if (sCidade.Length >= 200)
            {
                sMotivo = "[Cidade] possui mais de 200 caracteres";
                return false;
            }
            if (sEstado.Length >= 200)
            {
                sMotivo = "[Estado] possui mais de 200 caracteres";
                return false;
            }
            if (sEmail.Length >= 200)
            {
                sMotivo = "[E-mail] possui mais de 200 caracteres";
                return false;
            }

            if (sCep.Length > 10)
            {
                sMotivo = "[Cep] possui mais de 10 caracteres";//rr
                return false;
            }

            if (sCampo01.Length >= 200)
            {
                sMotivo = "[Campo 01] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo02.Length >= 200)
            {
                sMotivo = "[Campo 02] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo03.Length >= 200)
            {
                sMotivo = "[Campo 03] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo04.Length >= 200)
            {
                sMotivo = "[Campo 04] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo05.Length >= 200)
            {
                sMotivo = "[Campo 05] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo06.Length >= 200)
            {
                sMotivo = "[Campo 06] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo07.Length >= 200)
            {
                sMotivo = "[Campo 07] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo08.Length >= 200)
            {
                sMotivo = "[Campo 08] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo09.Length >= 200)
            {
                sMotivo = "[Campo 09] possui mais de 200 caracteres";
                return false;
            }
            if (sCampo10.Length >= 200)
            {
                sMotivo = "[Campo 10] possui mais de 200 caracteres";
                return false;
            }
            //foreach (DataRow dataRowBlacklist in dataBlacklist.Rows)
            //{
            //    if (dataRowBlacklist["Telefone"].ToString() == sTelefone1)
            //    {
            //        sMotivo = "[Telefone 1] está no Blacklist";
            //        return false;
            //    }
            //}
            return true;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void fMailing_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ListarMailings(-1);
            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            txtMailing.Focus();

            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCampanha_filtro.DropDownStyle = ComboBoxStyle.DropDownList;

            lblRegistros.Text = dgMailing.RowCount.ToString() + " registro(s)";

            dgMailing.Columns[0].Width = 100;
            dgMailing.Columns[1].Width = 300;
            dgMailing.Columns[2].Width = 200;
            dgMailing.Columns[3].Width = 150;
            dgMailing.Columns[4].Width = 50;
            dgMailing.Columns[5].Width = 300;
        }

        private bool PodeImportar()
        {

            if (txtMailing.Text == "")
            {
                MessageBox.Show("Nome do [Mailing] inválido.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtMailing.Text.IndexOf("'") > -1)
            {
                MessageBox.Show("Não utilize aspas simples (') no campo [Mailing].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            mailingCTL CMailing = new mailingCTL();
            if (CMailing.VerificarExistenciaMailing(txtMailing.Text) == true)
            {
                MessageBox.Show("[Mailing] já existente. Escolha outro nome para o Mailing.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Selecione [Campanha].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtIDMailing.Text != "")
            {
                MessageBox.Show("Clique em Novo para selecionar um arquivo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtArquivo.Text == "")
            {
                MessageBox.Show("Clique em Novo para selecionar um arquivo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (radSim.Checked == false && radNao.Checked == false)
            {
                MessageBox.Show("Selecione Sim ou Não para Ativo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dataSetMailing.Tables.Count == 0)
            {
                MessageBox.Show("Nenhum registro encontrado no arquivo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dataSetMailing.Tables[0].Columns.Count < 23)
            {
                MessageBox.Show("Registro deve possuir, no mínimo, 23 colunas.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dataSetMailing.Tables[0].Columns[0].ColumnName != "Telefone 1"
                || dataSetMailing.Tables[0].Columns[1].ColumnName != "Telefone 2"
                || dataSetMailing.Tables[0].Columns[2].ColumnName != "Telefone 3"
                || dataSetMailing.Tables[0].Columns[3].ColumnName != "Nome"
                || dataSetMailing.Tables[0].Columns[4].ColumnName != "CPF / CNPJ"
                || dataSetMailing.Tables[0].Columns[5].ColumnName != "Logradouro"
                || dataSetMailing.Tables[0].Columns[6].ColumnName != "Numero"
                || dataSetMailing.Tables[0].Columns[7].ColumnName != "Complemento"
                || dataSetMailing.Tables[0].Columns[8].ColumnName != "Bairro"
                || dataSetMailing.Tables[0].Columns[9].ColumnName != "Cidade"
                || dataSetMailing.Tables[0].Columns[10].ColumnName != "Estado"
                || dataSetMailing.Tables[0].Columns[11].ColumnName != "Email"
                || dataSetMailing.Tables[0].Columns[12].ColumnName != "CEP")
            {
                string sMensagem = "As colunas estão incorretas. Elas devem seguir a seguinte ordem:\n\n";
                sMensagem += "Telefone 1 | Telefone 2 | Telefone 3 | Nome | CPF / CNPJ | Logradouro | Numero | Complemento | Bairro | Cidade | Estado | Email | CEP | Campo01 ao Campo10 são livres";

                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void dgMailing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            campanhaCTL CCampanha = new campanhaCTL();

            if (e.RowIndex >= 0)
            {
                txtIDMailing.Text = dgMailing.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMailing.Text = dgMailing.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboCampanha.SelectedValue = CCampanha.RetornarIDCampanha(dgMailing.Rows[e.RowIndex].Cells[2].Value.ToString());
                radSim.Checked = dgMailing.Rows[e.RowIndex].Cells[4].Value.ToString() == "Sim" ? true : false;
                radNao.Checked = dgMailing.Rows[e.RowIndex].Cells[4].Value.ToString() == "Não" ? true : false;
            }
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeSalvar())
            {
                mailing Mailing = new mailing();
                Mailing.IDMailing = Convert.ToInt32(txtIDMailing.Text);
                Mailing.Ativo = radSim.Checked == true ? 1 : 0;

                mailingCTL CMailing = new mailingCTL();
                CMailing.EditarMailing(Mailing);

                LimparFormulario();

                MessageBox.Show("Alterações salvas com sucesso.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (txtIDMailing.Text == "")
            {
                sMensagem = "Selecione um [Mailing.]";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMailing.Text == "")
            {
                sMensagem = "Nome do [Mailing] inválido.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMailing.Text.IndexOf("'") > -1)
            {
                sMensagem = "Não utilize aspas simples (') no campo [Mailing].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void LimparFormulario()
        {
            txtIDMailing.Text = "";
            txtArquivo.Text = "";
            txtMailing.Text = "";
            radSim.Checked = false;
            radNao.Checked = false;
            prbProgresso.Value = 0;
            ListarMailings(Convert.ToInt32(comboCampanha_filtro.SelectedValue));
            comboCampanha.SelectedValue = -1;
            dgMailingPlanilha.DataSource = null;
            grpMailing.Text = "Mailing";
        }

        private void chkListarAtivos_CheckedChanged(object sender, EventArgs e)
        {
            ListarMailings(Convert.ToInt32(comboCampanha_filtro.SelectedValue));

            lblRegistros.Text = dgMailing.RowCount.ToString() + " registro(s)";
        }

        private void comboCampanha_filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ListarMailings(Convert.ToInt32(comboCampanha_filtro.SelectedValue));

            lblRegistros.Text = dgMailing.RowCount.ToString() + " registro(s)";
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fMailing_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdGerarMailingCallfex_Click(object sender, EventArgs e)
        {
            try
            {
                mailingCTL CMailing = new mailingCTL();
                if (comboCampanha.SelectedValue.ToString() != "-1" && txtMailing.Text.ToString() != "")
                    if (radSim.Checked == true)
                    {
                        CMailing.GerarMailingCallFlex(Convert.ToInt32(comboCampanha.SelectedValue.ToString()), Convert.ToInt32(txtIDMailing.Text.ToString()));
                        MessageBox.Show("Gerado arquivo CallFlex com sucesso. \nCampanha - " + comboCampanha.Text.ToString() + "\nMailing - " + txtMailing.Text.ToString() + ".");
                    }
                    else
                        MessageBox.Show("O Mailing deve estar ativo \n para gerar arquivo para o CallFlex");
                else
                    MessageBox.Show("Favor selecionar um mailing \n para gerar arquivo para o CallFlex");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro. Favor acionar a TI local.\n\n" + ex.Message);
            }
        }

        private void cmdPlanilhaExcel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("importacao_mailing.xlsx");
        }
    }
}
