using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using System.Text.RegularExpressions;

namespace tabulare.relatorio
{
    public partial class fQuantitativoDadosVenda : Form
    {
        public static bool bAtualizarRelatorio = false;

        public fQuantitativoDadosVenda()
        {
            InitializeComponent();


        }

        public DataTable GerarRelatorio()
        {
            DataTable dataTable = new DataTable();
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                int iIDOperador = Convert.ToInt32(comboOperador.SelectedValue);
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);

                if (usuarioCTL.bTestandoSistema)
                {
                    sDataInicial = "2000/01/01";
                    sDataFinal = "2033/01/01";
                }

                string sOpcao = "";
                foreach (object itemChecked in chkOpcao.CheckedItems)
                {
                    sOpcao += sOpcao != "" ? ";" + itemChecked.ToString() : itemChecked.ToString();
                }                
                string[] sColunas = sOpcao.Split(';');

                //Check Auditoria
                auditoriaCTL CAuditoria = new auditoriaCTL();
                string sIDAuditoria = "";
                foreach (object itemChecked in chkAuditoria.CheckedItems)
                {
                    if (sIDAuditoria != "")
                        sIDAuditoria = sIDAuditoria + ",";

                    sIDAuditoria = sIDAuditoria + CAuditoria.RetornarIDAuditoria(itemChecked.ToString());

                    if (sIDAuditoria != "")
                        sIDAuditoria = sIDAuditoria.ToString();

                    sIDAuditoria = sIDAuditoria.ToString();
                }

                relatorioCTL CRelatorio = new relatorioCTL();

                dataTable = CRelatorio.RetornarQuantitativoDadosVenda(iIDOperador, iIDCampanha, sIDAuditoria, sDataInicial, sDataFinal, sColunas);
                dataTable.Columns.Add("TOTAL");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int iTotal = 0;
                    for (int iColuna = 1; iColuna < dataTable.Columns.Count - 1; iColuna++)
                    {
                        iTotal += Convert.ToInt32(dataRow[iColuna].ToString());
                    }
                    dataRow[dataTable.Columns.Count - 1] = iTotal.ToString();
                }
                dgDados.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
            return dataTable;
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            int iCampanhaAtual = fLogin.Usuario.IDCampanha;

            if (PodeGerar())
            {
                try
                {
                    dgDados.DataSource = null;
                    GerarRelatorio();
                    lblQtdAuditoria.Text = dgDados.RowCount.ToString() + " registro(s)";
                }
                catch (Exception ex)
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("Erro na execução da tarefa. Favor informar a TI o erro abaixo.\n\n" + ex.Message, "Tabulare Software");
                }
            }
        }


        private void CarregarChkStatusAuditoria()
        {
            auditoriaCTL CAuditoria = new auditoriaCTL();
            CAuditoria.PreencherCheckListBox_Auditoria(chkAuditoria, true);

            for (int i = 0; i < this.chkAuditoria.Items.Count; ++i)
                this.chkAuditoria.SetItemChecked(i, true);

            string sAuditoria = "";
            int iQuantSelecionados = 0;
            foreach (object itemChecked in chkAuditoria.CheckedItems)
            {
                iQuantSelecionados++;
                sAuditoria = itemChecked.ToString();
            }
        }

        private bool PodeGerar()
        {
            string sMensagem;
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataInicial.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "Data Inicial incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataFinal.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "Data Final incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Selecione [Campanha].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (chkAuditoria.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecione alguma [Auditoria].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (chkCampos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecione algum [Campos (Dados da Venda)].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (chkOpcao.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecione alguma coluna a ser exibida no relatório.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //Verifica se tem coluna repetida. Não pode ter, senão dá erro na hora de criar colunas com o mesmo nome.
            string sOpcao = "";
            foreach (object itemChecked in chkOpcao.CheckedItems)
            {
                sOpcao += sOpcao != "" ? ";" + itemChecked.ToString().Substring(itemChecked.ToString().IndexOf("=>") + 2).Trim() : itemChecked.ToString().Substring(itemChecked.ToString().IndexOf("=>") + 2).Trim();
            }
            string[] sColunas = sOpcao.Split(';');

            foreach (string sColuna in sColunas)
            {
                int iNumeroRepeticoes = 0;
                foreach (object itemChecked in chkOpcao.CheckedItems)
                {
                    if (sColuna == itemChecked.ToString().Substring(itemChecked.ToString().IndexOf("=>") + 2).Trim())
                        iNumeroRepeticoes++;
                    
                    if (iNumeroRepeticoes > 1)
                    {
                        MessageBox.Show("A coluna [" + sColuna + "] está repetida. O relatório não pode ter colunas com o mesmo nome.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }

            return true;
        }

        private void ExibirForm(Form form)
        {
            form.WindowState = FormWindowState.Maximized;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void fDadosVenda_filtro_Load(object sender, EventArgs e)
        {
            try
            {
                this.ShowIcon = false;
                this.MaximizeBox = true;
                this.MinimizeBox = false;
                comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;
                CarregarChkStatusAuditoria();
                CarregarOperadoresAuditoria();
                CarregarCampanhasAtivas(fLogin.Usuario.IDUsuario);
            }
            catch { }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void cmdMarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkOpcao.Items.Count; ++i)
                this.chkOpcao.SetItemChecked(i, true);
        }

        private void cmdDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkOpcao.Items.Count; ++i)
                this.chkOpcao.SetItemChecked(i, false);
        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {
            if (PodeGerar())
                ExportarRelatorio();
        }

        private void ExportarRelatorio()
        {
            try
            {
                DataTable dataTable = GerarRelatorio();

                string sEnderecoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare - Quantitativo.xls";
                dataTable.TableName = "Tabulare";
                dataTable.WriteXml(sEnderecoArquivo, System.Data.XmlWriteMode.IgnoreSchema);

                MessageBox.Show("Dados exportados com sucesso!\n\nO arquivo encontra-se na Área de Trabalho.", "Tabulare");
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void cmdMarcarVendas_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampos.Items.Count; ++i)
                this.chkCampos.SetItemChecked(i, true);

            CarregarListaCamposVenda();
        }

        private void cmdDesmarcarVenda_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampos.Items.Count; ++i)
                this.chkCampos.SetItemChecked(i, false);

            CarregarListaCamposVenda();
        }

        private void cmdMarcarAuditoria_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkAuditoria.Items.Count; ++i)
                this.chkAuditoria.SetItemChecked(i, true);
        }

        private void CarregarOperadoresAuditoria()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperador, true, false);
            comboOperador.Text = fLogin.Usuario.Nome;
            comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmdDesmarcarAuditoria_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkAuditoria.Items.Count; ++i)
                this.chkAuditoria.SetItemChecked(i, false);
        }

        private void CarregarCampanhasAtivas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkCampos.Items.Clear();
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string sCampanha = comboCampanha.Text.ToString();

                campanhaCTL CCampanha = new campanhaCTL();
                CCampanha.PreencherCheckListBox_CamposListaVendaCampanhas(chkCampos, sCampanha);
            }
        }

        private void CarregarListaCamposVenda()
        {
            int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);

            chkOpcao.Items.Clear();
            string sCampo = "";
            foreach (object itemChecked in chkCampos.CheckedItems)
            {
                sCampo += sCampo != "" ? ",'" + itemChecked.ToString() + "'" : "'" + itemChecked.ToString() + "'";
            }

            if (!String.IsNullOrEmpty(sCampo))
            {
                campanhaCTL CCampanha = new campanhaCTL();
                CCampanha.PreencherCheckListBox_ListaCampoVenda(chkOpcao, iIDCampanha, sCampo);
            }
        }

        private void chkCampos_MouseUp(object sender, MouseEventArgs e)
        {
            CarregarListaCamposVenda();
        }
    }
}

