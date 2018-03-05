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
    public partial class fContatosTrabalhadosDetalhado : Form
    {
        public fContatosTrabalhadosDetalhado()
        {
            InitializeComponent();
        }

        private void GerarRelatorio()
        {
            try
            {
                string sHoraInicial = "";
                string sHoraFinal = "23:59:59";

                if (comboHoraInicial.Text != "") sHoraInicial = comboHoraInicial.Text.ToString() + ":00";
                if (comboHoraFinal.Text != "") sHoraFinal = comboHoraFinal.Text.ToString() + ":00";

                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy")) + " " + sHoraInicial;
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " " + sHoraFinal;
                int iIDUsuario = Convert.ToInt32(comboOperador.SelectedValue);

                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                string sIDStatus = "";

                foreach (object itemChecked in chlStatus.CheckedItems)
                {
                    if (sIDStatus != "")
                        sIDStatus += ", ";

                    sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-", 1) - 1);
                }

                //Campanha
                string sCampanha = "";
                campanhaCTL CCampanha = new campanhaCTL();//r
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

                //Maling
                string sMailing = "";
                mailingCTL CMailing = new mailingCTL();
                string sIDMailing = "";
                foreach (object itemChecked in chkMailing.CheckedItems)
                {
                    if (sIDMailing != "")
                        sIDMailing = sIDMailing + ",";

                    sIDMailing = sIDMailing + CMailing.RetornarIDMailing(itemChecked.ToString()); 

                    if (sMailing != "")
                        sMailing = sMailing + "; ";

                    sMailing = sMailing + itemChecked.ToString();
                }

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarContatosTrabalhadosDetalhado(sDataInicial, sDataFinal, iIDUsuario, sIDCampanhas, sIDMailing, iIDTipoAtendimento, sIDStatus);
                dgDados.DataSource = dataTable;
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

            bool bMalingSelecionado = false;//r
            foreach (object itemChecked in chkMailing.CheckedItems)
            {
                bMalingSelecionado = true;
            }
            if (bMalingSelecionado == false)
            {
                MessageBox.Show("Selecione, pelo menos, uma Mailing.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void CarregarStatusRelatorio(int iIDCampanha)
        {
            statusCTL CStatus = new statusCTL();
            CStatus.PreencherCheckListBox_DescricaoStatus(chlStatus, iIDCampanha);
        }

        private void CarregarOperadores()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperador, true, false);
        }

        private void fContatosTrabalhados_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);

            CarregarOperadores();
            chlStatus.Items.Clear();
            comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            comboHoraInicial.DropDownStyle = ComboBoxStyle.DropDownList;
            comboHoraFinal.DropDownStyle = ComboBoxStyle.DropDownList;
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
                string sHoraInicial = "";
                string sHoraFinal = "23:59:59";

                if (comboHoraInicial.Text != "") sHoraInicial = comboHoraInicial.Text.ToString() + ":00";
                if (comboHoraFinal.Text != "") sHoraFinal = comboHoraFinal.Text.ToString() + ":00";

                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy")) + " " + sHoraInicial;
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " " + sHoraFinal;
                int iIDUsuario = Convert.ToInt32(comboOperador.SelectedValue);

                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                string sIDStatus = "";

                foreach (object itemChecked in chlStatus.CheckedItems)
                {
                    if (sIDStatus != "")
                        sIDStatus += ", ";

                    sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-", 1) - 1);
                }

                string sCampanha = "";
                campanhaCTL CCampanha = new campanhaCTL();//r
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

                string sMailing = "";
                mailingCTL CMailing = new mailingCTL();
                string sIDMailing = "";
                foreach (object itemChecked in chkMailing.CheckedItems)
                {
                    if (sIDMailing != "")
                        sIDMailing = sIDMailing + ",";

                    sIDMailing = sIDMailing + CMailing.RetornarIDMailing(itemChecked.ToString());

                    if (sMailing != "")
                        sMailing = sMailing + "; ";

                    sMailing = sMailing + itemChecked.ToString();
                }

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarContatosTrabalhadosDetalhado(sDataInicial, sDataFinal, iIDUsuario, sIDCampanhas, sIDMailing, iIDTipoAtendimento, sIDStatus);

                string sEnderecoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare - Contatos_Trabalhados_Detalhado.xls";
                dataTable.TableName = "Tabulare";
                dataTable.WriteXml(sEnderecoArquivo);

                MessageBox.Show("Dados exportados com sucesso!\n\nO arquivo encontra-se na Área de Trabalho.", "Tabulare");
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void cmdMarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chlStatus.Items.Count; ++i)
                this.chlStatus.SetItemChecked(i, true);
        }

        private void cmdDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chlStatus.Items.Count; ++i)
                this.chlStatus.SetItemChecked(i, false);
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fContatosTrabalhadosDetalhado_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }


        private void CarregarCampanhas(int iIDUsuario)//R
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherCheckListBox_CampanhasAtivas(chkCampanha, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void cmdTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
                this.chkCampanha.SetItemChecked(i, true);

            for (int i = 0; i < this.chlStatus.Items.Count; ++i)
                this.chlStatus.SetItemChecked(i, false);

            string sCampanha = "";
            campanhaCTL CCampanha = new campanhaCTL();//r
            string sIDCampanhas = "";
            chkMailing.Items.Clear();

            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                if (sIDCampanhas != "")
                    sIDCampanhas = sIDCampanhas + ",";

                sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                if (sCampanha != "")
                    sCampanha = sCampanha + "; ";

                sCampanha = sCampanha + itemChecked.ToString();
            }

            if (sIDCampanhas != "")
            {
                CarregarMailings(sIDCampanhas);
            }

            chlStatus.Items.Clear();
        }

        private void cmdNenhum_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
                this.chkCampanha.SetItemChecked(i, false);

            chkMailing.Items.Clear();
        }

        private void CarregarMailings(string sIDCampanhas)
        {
            try
            {
                //comboMailing.Items.Clear();
                mailingCTL CMailing = new mailingCTL();
                CMailing.PreencherCheckListBox_Mailing(chkMailing, sIDCampanhas);
            }
            catch { }

        }

        private void chkCampanha_MouseUp(object sender, MouseEventArgs e)
        {
            chlStatus.Items.Clear();
            chkMailing.Items.Clear();

            string sCampanha = "";
            string sIDCampanhas = "";
            int iQuantSelecionados = 0;

            campanhaCTL CCampanha = new campanhaCTL();//r

            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                iQuantSelecionados++;

                if (sIDCampanhas != "")
                    sIDCampanhas = sIDCampanhas + ",";

                sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());


                CarregarStatusRelatorio(sIDCampanhas);//

                if (sCampanha != "")
                    sCampanha = sCampanha + "; ";

                sCampanha = sCampanha + itemChecked.ToString();
            }

            //Só carrega os campos se selecionar apenas uma campanha
            if (iQuantSelecionados == 1)
            {
                statusCTL CStatus = new statusCTL();
                CStatus.PreencherCheckListBox_DescricaoStatus(chlStatus, -1);
            }
            else
            {
                chlStatus.Items.Clear();
            }


            if (sIDCampanhas != "")
            {
                CarregarMailings(sIDCampanhas);
            }
        }

        private void cmdTodosMailing_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkMailing.Items.Count; ++i)
                this.chkMailing.SetItemChecked(i, true);
        }

        private void cmdNenhumMailing_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkMailing.Items.Count; ++i)
                this.chkMailing.SetItemChecked(i, false);
        }

        private void CarregarStatusRelatorio(string sIDCampanha)//r
        {
            statusCTL CStatus = new statusCTL();
            CStatus.PreencherCheckListBox_DescricaoStatus(chlStatus, sIDCampanha);
        }

        private void chkListarAtivos_CheckedChanged(object sender, EventArgs e)
        {
            string sIDCampanhas = "";
            campanhaCTL CCampanha = new campanhaCTL();//r

            foreach (object itemChecked in chkCampanha.CheckedItems)
            {
                sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                if (chkListarAtivos.Checked == true)
                {
                    if (sIDCampanhas != "")
                        CarregarMailingInativos(sIDCampanhas);//  
                }
                else
                {
                    chkMailing.Items.Clear();
                    CarregarMailings(sIDCampanhas);
                }
            }
        }

        private void CarregarMailingInativos(string sIDCampanha)//r
        {
            try
            {
                mailingCTL CMailing = new mailingCTL();
                CMailing.PreencherCheckListBox_MailingsInativos(chkMailing, sIDCampanha, Convert.ToBoolean(chkListarAtivos.Checked));
            }
            catch { }
        }
    }
}
