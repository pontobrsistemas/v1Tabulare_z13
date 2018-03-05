using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;

namespace tabulare.supervisor
{
    public partial class fBackofficeVenda_filtro : Form
    {
        public static bool bAtualizarRelatorio = false;
        public string chkCamposFixoProspect;

        public fBackofficeVenda_filtro()
        {
            InitializeComponent();
        }

        public void GerarRelatorio()
        {
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                int iIDOperadorAuditoria = Convert.ToInt32(comboOperador.SelectedValue);

                string sCampanha = "";
                campanhaCTL CCampanha = new campanhaCTL();
                string sIDCampanhas = "";
                foreach (object itemChecked in chkCampanha.CheckedItems)
                {
                    if (sIDCampanhas != "")
                        sIDCampanhas = sIDCampanhas + ",";

                    sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                    if (sCampanha != "")
                        sCampanha = sCampanha + "; ";

                    sCampanha = sCampanha + itemChecked.ToString();
                }

                string sCamposVenda = "";
                foreach (object itemChecked in chkCampos.CheckedItems)
                {
                    if (sCamposVenda != "")
                        sCamposVenda = sCamposVenda + ",";

                    sCamposVenda = sCamposVenda + "'" + itemChecked.ToString() + "'";
                }

                string sCamposProspectExtra = "";
                string sCamposProspectFixo = "";
                foreach (object itemChecked in chkCamposProspect.CheckedItems)
                {
                    if (itemChecked.ToString().IndexOf(" (campo fixo)") > -1)
                    {
                        if (sCamposProspectFixo != "")
                            sCamposProspectFixo = sCamposProspectFixo + ",";

                        sCamposProspectFixo = sCamposProspectFixo + "p.[" + itemChecked.ToString().Replace(" (campo fixo)", "") + "]";
                        sCamposProspectFixo = sCamposProspectFixo.Replace("p.[CPF/CNPJ]", "p.[CPF_CNPJ] [CPF / CNPJ]");
                    }
                    else
                    {
                        if (sCamposProspectExtra != "")
                            sCamposProspectExtra = sCamposProspectExtra + ",";

                        sCamposProspectExtra = sCamposProspectExtra + "'" + itemChecked.ToString() + "'";
                    }
                }

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

                //Se selecionou todos status de auditoria, busca todos (ativos e inativos)
                //DataTable dataTable = CAuditoria.RetornarStatusAuditoria(false);
                //foreach (DataRow dataRow in dataTable.Rows)
                //{
                //    sIDAuditoria += sIDAuditoria != "" ? ", " + dataRow["Cód."] : dataRow["Cód."];
                //}

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable;

                //Se o perfil for Supervisor, exibe todas as vendas.
                //Se for Operador, exibe só as vendas do usuário logado
                if (fLogin.Usuario.Perfil == "Supervisor" || fLogin.Usuario.Perfil == "BackOffice" || fLogin.Usuario.Perfil == "Administrador")
                {
                    dataTable = CRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, -1, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, txtTelefone1_filtro.Text, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome_filtro.Text), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPFCNPJ_filtro.Text), comboDadosVenda.SelectedValue == null ? "-1" : comboDadosVenda.SelectedValue.ToString(), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtTextoDadosVenda.Text), iIDOperadorAuditoria);
                    dgDados.DataSource = dataTable;

                    dgDados.Columns[0].Visible = false;
                    dgDados.Columns[1].Visible = false;
                }
                else
                {
                    dataTable = CRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, fLogin.Usuario.IDUsuario, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, txtTelefone1_filtro.Text, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome_filtro.Text), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPFCNPJ_filtro.Text), comboDadosVenda.SelectedValue == null ? "-1" : comboDadosVenda.SelectedValue.ToString(), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtTextoDadosVenda.Text), iIDOperadorAuditoria);
                    dgDados.DataSource = dataTable;

                    dgDados.Columns[0].Visible = false;
                    dgDados.Columns[1].Visible = false;
                }

                foreach (DataGridViewRow dataGridViewRow in dgDados.Rows)
                {
                    //Verifica as vendas que estão sendo auditadas no momento e coloca coluna em vermelho
                    if (dataGridViewRow.Cells["Backoffice"].Value.ToString().IndexOf("sendo auditada por") > -1)
                        dataGridViewRow.Cells["Backoffice"].Style.ForeColor = System.Drawing.Color.Red;

                    //if (Convert.ToInt32( dataGridViewRow.Cells["Mensagem"].Value) == 1)
                    //    dataGridViewRow.Cells["Observação"].Style.ForeColor = System.Drawing.Color.Red;


                    //Verifica o prazo de expiração dos status de auditoria
                    if (dataGridViewRow.Cells["Auditoria"].Value.ToString().IndexOf("(expirando)") > -1)
                        dataGridViewRow.Cells["Auditoria"].Style.ForeColor = System.Drawing.Color.Orange;
                    else if (dataGridViewRow.Cells["Auditoria"].Value.ToString().IndexOf("(expirado)") > -1)
                        dataGridViewRow.Cells["Auditoria"].Style.ForeColor = System.Drawing.Color.Red;
                }
                dgDados.ClearSelection();
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
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

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherCheckListBox_CampanhasAtivas(chkCampanha, iIDUsuario, fLogin.Usuario.Perfil);
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
            double dTelefone;
            if (Double.TryParse(txtTelefone1_filtro.Text, out dTelefone) == false && txtTelefone1_filtro.Text != "")
            {
                sMensagem = "O [Telefone] está incorreto.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            bool bSelecionado = false;
            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                bSelecionado = true;
            }
            if (bSelecionado == false)
            {
                MessageBox.Show("Selecione, pelo menos, uma Campanha.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void dgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    prospectCTL CProspect = new prospectCTL();
                    dgDados.Columns[0].Visible = true;
                    supervisor.fBackofficeVenda_detalhe.iIDHistorico = Convert.ToInt32(dgDados.Rows[e.RowIndex].Cells[2].Value.ToString());
                    supervisor.fBackofficeVenda_detalhe.iIDCampanha = Convert.ToInt32(dgDados.Rows[e.RowIndex].Cells[1].Value.ToString());
                    supervisor.fBackofficeVenda_detalhe.iIDVenda = Convert.ToInt32(dgDados.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dgDados.Columns[0].Visible = false;

                    if (fLogin.Usuario.Perfil == "Operador")
                    {
                        ExibirForm(new supervisor.fBackofficeVenda_detalhe());
                    }
                    else
                    {
                        //Verifica se não está sendo auditada por algum backoffice
                        string sBackoffice = CProspect.VerificarVendaSendoAuditadaBackoffice(Convert.ToInt32(dgDados.Rows[e.RowIndex].Cells[2].Value.ToString()), fLogin.Usuario.IDUsuario);
                        if (!String.IsNullOrEmpty(sBackoffice))
                            MessageBox.Show("Não é possível auditar essa venda\n\nEla está sendo auditada por " + sBackoffice + ".", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            fBackOffice.ExibirForm(new supervisor.fBackofficeVenda_detalhe());
                    }
                }
            }
            catch { }
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
                CarregarCampanhas(fLogin.Usuario.IDUsuario);
                CarregarChkStatusAuditoria();//r
                CarregarOperadoresAuditoria();
                DefinirAcessos();
            }
            catch { }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void DefinirAcessos()
        {
            if (fLogin.Usuario.Perfil == "Operador")
            {
                comboOperador.Text = fLogin.Usuario.Nome;
                cmdFechar.Enabled = true;
                comboOperador.Enabled = false;  //bloqueia o operador para visualizar vendas de outros operadores
                lblTituloFormulario.Text = "DADOS DA VENDA";
                this.Text = "DADOS DA VENDA";
                cmdExportar.Enabled = false;
            }
            else
            {
                //cmdFechar.Enabled = false;
                lblTituloFormulario.Text = "BACKOFFICE - AUDITORIA DADOS DA VENDA";
                this.Text = "BACKOFFICE - AUDITORIA DADOS DA VENDA";
                cmdExportar.Enabled = true;
            }
        }

        private void cmdMarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
                this.chkCampanha.SetItemChecked(i, true);

            string sCampanha = "";
            int iQuantSelecionados = 0;
            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                iQuantSelecionados++;
                sCampanha = itemChecked.ToString();
            }

            //Só carrega os campos se selecionar apenas uma campanha
            if (iQuantSelecionados == 1)
            {
                campanhaCTL CCampanha = new campanhaCTL();
                CCampanha.PreencherCheckListBox_CamposVendaCampanhas(chkCampos, sCampanha);
            }
            else
            {
                chkCampos.Items.Clear();
                chkCamposProspect.Items.Clear();
                comboDadosVenda.DataSource = null;
            }
            CarregarCamposProspectFixo();
        }

        private void CarregarCamposProspectFixo()
        {
            chkCamposProspect.Items.Add("CPF/CNPJ (campo fixo)");
            chkCamposProspect.Items.Add("Logradouro (campo fixo)");
            chkCamposProspect.Items.Add("Numero (campo fixo)");
            chkCamposProspect.Items.Add("Complemento (campo fixo)");
            chkCamposProspect.Items.Add("Bairro (campo fixo)");
            chkCamposProspect.Items.Add("Cidade (campo fixo)");
            chkCamposProspect.Items.Add("Estado (campo fixo)");
            chkCamposProspect.Items.Add("Email (campo fixo)");
            chkCamposProspect.Items.Add("Cep (campo fixo)");
        }

        private void cmdDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
                this.chkCampanha.SetItemChecked(i, false);

            for (int i = 0; i < this.chkCampos.Items.Count; ++i)
                this.chkCampos.SetItemChecked(i, false);

            for (int i = 0; i < this.chkCamposProspect.Items.Count; ++i)
                this.chkCamposProspect.SetItemChecked(i, false);
        }

        private void timerAtualizacao_Tick(object sender, EventArgs e)
        {
            if (bAtualizarRelatorio == true)
            {
                try
                {
                    int iLinha = dgDados.CurrentRow.Index;
                    GerarRelatorio();
                    bAtualizarRelatorio = false;
                    dgDados.Rows[iLinha].Selected = true;
                }
                catch { }
            }
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
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                int iIDOperadorAuditoria = Convert.ToInt32(comboOperador.SelectedValue);

                string sCampanha = "";
                campanhaCTL CCampanha = new campanhaCTL();
                string sIDCampanhas = "";
                foreach (object itemChecked in chkCampanha.CheckedItems)
                {
                    if (sIDCampanhas != "")
                        sIDCampanhas = sIDCampanhas + ",";

                    sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                    if (sCampanha != "")
                        sCampanha = sCampanha + "; ";

                    sCampanha = sCampanha + itemChecked.ToString();
                }

                string sCamposVenda = "";
                foreach (object itemChecked in chkCampos.CheckedItems)
                {
                    if (sCamposVenda != "")
                        sCamposVenda = sCamposVenda + ",";

                    sCamposVenda = sCamposVenda + "'" + itemChecked.ToString() + "'";
                }

                string sCamposProspectExtra = "";
                string sCamposProspectFixo = "";
                foreach (object itemChecked in chkCamposProspect.CheckedItems)
                {
                    if (itemChecked.ToString().IndexOf(" (campo fixo)") > -1)
                    {
                        if (sCamposProspectFixo != "")
                            sCamposProspectFixo = sCamposProspectFixo + ",";

                        sCamposProspectFixo = sCamposProspectFixo + "p.[" + itemChecked.ToString().Replace(" (campo fixo)", "") + "]";
                        sCamposProspectFixo = sCamposProspectFixo.Replace("p.[CPF/CNPJ]", "p.[CPF_CNPJ] [CPF / CNPJ]");
                    }
                    else
                    {
                        if (sCamposProspectExtra != "")
                            sCamposProspectExtra = sCamposProspectExtra + ",";

                        sCamposProspectExtra = sCamposProspectExtra + "'" + itemChecked.ToString() + "'";
                    }
                }

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

                //Se o perfil for Supervisor, exibe todas as vendas.
                //Se for Operador, exibe só as vendas do usuário logado
                DataTable dataTable;
                if (fLogin.Usuario.Perfil == "Supervisor" || fLogin.Usuario.Perfil == "BackOffice" || fLogin.Usuario.Perfil == "Administrador")
                {
                    dataTable = CRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, -1, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, txtTelefone1_filtro.Text, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome_filtro.Text), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPFCNPJ_filtro.Text), comboDadosVenda.SelectedValue == null ? "-1" : comboDadosVenda.SelectedValue.ToString(), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtTextoDadosVenda.Text), iIDOperadorAuditoria);
                    dgDados.DataSource = dataTable;

                    dgDados.Columns[0].Visible = false;
                    dgDados.Columns[1].Visible = false;
                }
                else
                {
                    dataTable = CRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, fLogin.Usuario.IDUsuario, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, txtTelefone1_filtro.Text, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome_filtro.Text), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPFCNPJ_filtro.Text), comboDadosVenda.SelectedValue == null ? "-1" : comboDadosVenda.SelectedValue.ToString(), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtTextoDadosVenda.Text), iIDOperadorAuditoria);
                    dgDados.DataSource = dataTable;

                    dgDados.Columns[0].Visible = false;
                    dgDados.Columns[1].Visible = false;
                }

                foreach (DataGridViewRow dataGridViewRow in dgDados.Rows)
                {
                    //Verifica as vendas que estão sendo auditadas no momento e coloca coluna em vermelho
                    if (dataGridViewRow.Cells["Backoffice"].Value.ToString().IndexOf("sendo auditada por") > -1)
                        dataGridViewRow.Cells["Backoffice"].Style.ForeColor = System.Drawing.Color.Red;

                    //Verifica o prazo de expiração dos status de auditoria
                    if (dataGridViewRow.Cells["Auditoria"].Value.ToString().IndexOf("(expirando)") > -1)
                        dataGridViewRow.Cells["Auditoria"].Style.ForeColor = System.Drawing.Color.Orange;
                    else if (dataGridViewRow.Cells["Auditoria"].Value.ToString().IndexOf("(expirado)") > -1)
                        dataGridViewRow.Cells["Auditoria"].Style.ForeColor = System.Drawing.Color.Red;
                }
                dgDados.ClearSelection();

                dataTable.Columns.Remove("IDVenda");
                dataTable.Columns.Remove("IDCampanha");
                string sEnderecoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare - Auditoria.xls";
                dataTable.TableName = "Tabulare";
                dataTable.WriteXml(sEnderecoArquivo, System.Data.XmlWriteMode.IgnoreSchema);

                MessageBox.Show("Dados exportados com sucesso!\n\nO arquivo encontra-se na Área de Trabalho.", "Tabulare");

            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void chkCampanha_MouseUp(object sender, MouseEventArgs e)
        {
            chkCampos.Items.Clear();
            chkCamposProspect.Items.Clear();
            comboDadosVenda.DataSource = null;

            chkCamposFixoProspect = "0";
            string sCampanha = "";
            int iQuantSelecionados = 0;
            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                iQuantSelecionados++;
                sCampanha = itemChecked.ToString();
            }

            //Só carrega os campos se selecionar apenas uma campanha
            if (iQuantSelecionados == 1)
            {
                campanhaCTL CCampanha = new campanhaCTL();
                CCampanha.PreencherCheckListBox_CamposVendaCampanhas(chkCampos, sCampanha);
                CCampanha.PreencherCheckListBox_CamposProspect(chkCamposProspect, sCampanha);
                CCampanha.PreencherComboBox_DadosVenda(comboDadosVenda, sCampanha, false, true);
                comboDadosVenda.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            CarregarCamposProspectFixo();
        }

        private void txtTelefone1_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }
        }

        private void cmdMarcarVendas_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampos.Items.Count; ++i)
                this.chkCampos.SetItemChecked(i, true);

            string sCampanha = "";
            int iQuantSelecionados = 0;
            foreach (object itemChecked in chkCampos.CheckedItems)
            {
                iQuantSelecionados++;
                sCampanha = itemChecked.ToString();
            }
        }

        private void cmdDesmarcarVenda_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampos.Items.Count; ++i)
                this.chkCampos.SetItemChecked(i, false);
        }

        private void cmdMarcarProspect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCamposProspect.Items.Count; ++i)
                this.chkCamposProspect.SetItemChecked(i, true);

            string sCampanha = "";
            int iQuantSelecionados = 0;
            foreach (object itemChecked in chkCamposProspect.CheckedItems)
            {
                iQuantSelecionados++;
                sCampanha = itemChecked.ToString();
            }
        }

        private void cmdDesmarcarProspect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCamposProspect.Items.Count; ++i)
                this.chkCamposProspect.SetItemChecked(i, false);
        }

        private void cmdMarcarAuditoria_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkAuditoria.Items.Count; ++i)
                this.chkAuditoria.SetItemChecked(i, false);
        }

        private void CarregarOperadoresAuditoria()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperador, true, false);
            comboOperador.Text = fLogin.Usuario.Nome;
            comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
