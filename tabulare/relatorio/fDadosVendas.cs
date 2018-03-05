using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;

namespace tabulare.relatorio
{
    public partial class fDadosVenda : Form
    {
        public fDadosVenda()
        {
            InitializeComponent();
        }

        private void GerarRelatorio()
        {
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                int iIDUsuario = Convert.ToInt32(comboOperador.SelectedValue);
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                int iIDStatusAuditoria = Convert.ToInt32(comboAuditoria.SelectedValue);

                string sCampanha = "";
                campanhaCTL CCampanha = new campanhaCTL();//r
                string sIDCampanhas = "";
                int iMailingInativos;

                foreach (object itemChecked in chkCampanha.CheckedItems)
                {
                    if (sIDCampanhas != "")
                        sIDCampanhas = sIDCampanhas + ",";

                    sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                    if (sCampanha != "")
                        sCampanha = sCampanha + "; ";

                    sCampanha = sCampanha + itemChecked.ToString();
                }

                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                if (chkListarInativos.Checked == true)
                    iMailingInativos = 0;
                else
                    iMailingInativos = 1;

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = null;

                dataTable = CRelatorio.RetornarDadosVenda(sDataInicial, sDataFinal, sIDCampanhas, iIDMailing, iIDUsuario, iIDTipoAtendimento, iIDStatusAuditoria, iMailingInativos);
                dgDados.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void CarregarStatusAuditoria()
        {
            auditoriaCTL CAuditoria = new auditoriaCTL();
            CAuditoria.PreencherComboBox_StatusAuditoria(comboAuditoria, true, true, false);
        }

        private void ExportarRelatorio()
        {
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                int iIDUsuario = Convert.ToInt32(comboOperador.SelectedValue);
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                int iIDStatusAuditoria = Convert.ToInt32(comboAuditoria.SelectedValue);

                string sCampanha = "";
                campanhaCTL CCampanha = new campanhaCTL();//r
                string sIDCampanhas = "";
                int iMailingInativos;

                foreach (object itemChecked in chkCampanha.CheckedItems)
                {
                    if (sIDCampanhas != "")
                        sIDCampanhas = sIDCampanhas + ",";

                    sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                    if (sCampanha != "")
                        sCampanha = sCampanha + "; ";

                    sCampanha = sCampanha + itemChecked.ToString();
                }

                if (chkListarInativos.Checked == true)
                    iMailingInativos = 0;
                else
                    iMailingInativos = 1;


                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = null;

                dataTable = CRelatorio.RetornarDadosVenda(sDataInicial, sDataFinal, sIDCampanhas, iIDMailing, iIDUsuario, iIDTipoAtendimento, iIDStatusAuditoria, iMailingInativos);

                string sEnderecoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare - Dados_da_Venda.xls";
                dataTable.TableName = "Tabulare";
                dataTable.WriteXml(sEnderecoArquivo, System.Data.XmlWriteMode.IgnoreSchema);

                MessageBox.Show("Dados exportados com sucesso!\n\nO arquivo encontra-se na Área de Trabalho.", "Tabulare");
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            if (PodeGerar())
                GerarRelatorio();

            lblRegistros.Text = dgDados.RowCount.ToString() + " registro(s)";
        }

        private bool PodeGerar()
        {
            string sMensagem;
            string sCampanha = "";
            campanhaCTL CCampanha = new campanhaCTL();//r
            string sIDCampanhas = "";


            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataInicial.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "[Data Inicial] incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataFinal.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "[Data Final] incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                if (sIDCampanhas != "")
                    sIDCampanhas = sIDCampanhas + ",";

                sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                if (sCampanha != "")
                    sCampanha = sCampanha + "; ";

                sCampanha = sCampanha + itemChecked.ToString();
            }

            if (sIDCampanhas == "")
            {
                sMensagem = "Selecione uma [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void fContatosTrabalhados_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            CarregarStatusAuditoria();
            CarregarOperadores();

            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            comboAuditoria.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CarregarCampanhas(int iIDUsuario)//R
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherCheckListBox_CampanhasAtivas(chkCampanha, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void CarregarOperadores()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperador);
        }

        private void CarregarMailing(int iIDCampanha, int iAtivo)
        {
            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_MailingsAtivos(comboMailing, iIDCampanha, iAtivo, true, false, false);
        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {
            if (PodeGerar())
                ExportarRelatorio();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fDadosVenda_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
                this.chkCampanha.SetItemChecked(i, true);

            string sCampanha = "";
            campanhaCTL CCampanha = new campanhaCTL();//r
            string sIDCampanhas = "";
            int iMailingInativos;

            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                if (sIDCampanhas != "")
                    sIDCampanhas = sIDCampanhas + ",";

                sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                if (sCampanha != "")
                    sCampanha = sCampanha + "; ";

                sCampanha = sCampanha + itemChecked.ToString();
            }

            if (chkListarInativos.Checked == true)
                iMailingInativos = 0;
            else
                iMailingInativos = 1;

            if (sIDCampanhas != "")
            {
                CarregarMailings2(sIDCampanhas, iMailingInativos);
                comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            lblQuantidade.Text = Convert.ToString(comboMailing.Items.Count) + " Mailing(s).";
        }

        private void chkCampanha_MouseUp(object sender, MouseEventArgs e)
        {
            string sCampanha = "";
            string sIDCampanhas = "";
            int iQuantSelecionados = 0;
            int iMailingInativos;

            if (chkListarInativos.Checked == true)
                iMailingInativos = 0;
            else
                iMailingInativos = 1;

            campanhaCTL CCampanha = new campanhaCTL();//r
            mailingCTL CMailing = new mailingCTL();

            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                iQuantSelecionados++;

                if (sIDCampanhas != "")
                    sIDCampanhas = sIDCampanhas + ",";

                sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                CarregarMailings2(sIDCampanhas, iMailingInativos);

                if (sCampanha != "")
                    sCampanha = sCampanha + "; ";

                sCampanha = sCampanha + itemChecked.ToString();
            }

            //Só carrega os campos se selecionar apenas uma campanha
            if (iQuantSelecionados == 0)
            {
                CMailing.PreencherComboBox_TodosMailingsAtivos(comboMailing, "0", 1, false, false, false);
                comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            lblQuantidade.Text = Convert.ToString(comboMailing.Items.Count) + " Mailing(s).";
        }

        private void CarregarMailings2(string sIDCampanhas, int iMailingInativos)
        {
            try
            {
                mailingCTL CMailing = new mailingCTL();
                CMailing.PreencherComboBox_TodosMailingsAtivos(comboMailing, sIDCampanhas, iMailingInativos, true, false, false);
                comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch { }
        }

        private void cmdNenhum_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
                this.chkCampanha.SetItemChecked(i, false);

            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_TodosMailingsAtivos(comboMailing, "0", 1, false, false, false);
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;

            lblQuantidade.Text = "";
        }

        private void chkListarInativos_CheckedChanged(object sender, EventArgs e)
        {
            string sCampanha = "";
            campanhaCTL CCampanha = new campanhaCTL();//r
            string sIDCampanhas = "";
            int iMailingInativos;

            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                if (sIDCampanhas != "")
                    sIDCampanhas = sIDCampanhas + ",";

                sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                if (sCampanha != "")
                    sCampanha = sCampanha + "; ";

                sCampanha = sCampanha + itemChecked.ToString();
            }

            if (chkListarInativos.Checked == true)
                iMailingInativos = 0;
            else
                iMailingInativos = 1;

            if (sIDCampanhas != "")
            {
                CarregarMailings2(sIDCampanhas, iMailingInativos);
                comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            lblQuantidade.Text = Convert.ToString(comboMailing.Items.Count) + " Mailing(s).";
        }
    }
}