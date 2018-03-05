using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using model.objetos;
using System.Collections.Specialized;
using System.Net;


namespace tabulare.supervisor
{
    public partial class fResubmitMailing : Form
    {
        public fResubmitMailing()
        {
            InitializeComponent();
        }

        private void Resubmit()
        {
            try
            {
                prospectCTL CProspect = new prospectCTL();
                string sMensagem;
                string sDataInicial = "";
                string sDataFinal = "";
                int iIDOperador = -1;
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                string sIDStatus = "";
                string sBairro = "";
                string sCidade = "";
                string sCep = "";

                //CProspect.LimparTabelaTemporariaResubmit();

                foreach (object itemChecked in chkLStatus.CheckedItems)
                {
                    if (chkFiltroAvancado.Checked)
                    {
                        sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                        sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                        iIDOperador = Convert.ToInt32(comboOperador.SelectedValue);
                        sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtBairro.Text);
                        sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCidade.Text);
                        sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCep.Text);
                    }

                    if (sIDStatus != "")
                        sIDStatus += ", ";

                    sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-", 1) - 1);
                }

                CProspect.InserirProspectTemporiamenteResubmit(sIDStatus.ToString(), iIDMailing, sDataInicial, sDataFinal, iIDOperador, sBairro, sCidade, sCep);

                int iNumeroProspectResubmit = CProspect.RetornarQuantidadeResubmit();
                string sMailing = comboMailing.Text;

                CProspect.ExecutarResubmit(fLogin.Usuario.IDUsuario);

                try
                {
                    if (ChkEnviarResubmitVonix.Checked == true)
                        Processar();
                }
                catch (Exception ex)
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
                }

                sMensagem = "Mailing selecionado: " + sMailing + "\n\n";
                sMensagem += "Resubmit executado com sucesso em " + iNumeroProspectResubmit.ToString() + " prospect(s).";

                LiberarFormulario();

                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software"); 
            }
        }

        private void LiberarFormulario()
        {
            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboMailing.DataSource = null;
            lblResubmit.Text = "-";
            ChkEnviarResubmitVonix.Checked = false;

            CarregarStatus(Convert.ToInt32(comboCampanha.SelectedValue));
        }

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void CarregarMailings(int iIDCampanha, int iAtivo)
        {
            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_MailingsAtivos(comboMailing, iIDCampanha, iAtivo, false, true, false);
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (fLogin.Configuracao.TipoPabx == "Callflex")
            {
                //Retorna status tanto da Callflex quanto outros clientes
                if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                    if (iIDCampanha != -1)
                    {
                        CarregarMailings(iIDCampanha, 0);
                        CarregarStatusCallflex(Convert.ToInt32(comboCampanha.SelectedValue));
                        comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;

                        cmdFechar.Location = new Point(1123, 33);
                        listBoxStatusCallflex.Visible = true;
                        lblTabulacaoCallflex.Visible = true;
                    }
                    else
                    {
                        chkLStatus.Items.Clear();
                        comboMailing.SelectedValue = -1;
                        lblResubmit.Text = "0";
                    }
                }
            }
            else
            {
                if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                    if (iIDCampanha != -1)
                    {
                        CarregarMailings(iIDCampanha, 0);
                        CarregarStatus(Convert.ToInt32(comboCampanha.SelectedValue));
                        comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    else
                    {
                        chkLStatus.Items.Clear();
                        comboMailing.SelectedValue = -1;
                        lblResubmit.Text = "0";
                    }
                }
            }
        }

        private bool PodeResubmit()
        {
            string sMensagem;
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (comboMailing.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione [Mailing].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            bool bAlgumSelecionado = false;
            foreach (object itemChecked in chkLStatus.CheckedItems)
            {
                bAlgumSelecionado = true;
            }
            if (bAlgumSelecionado == false)
            {
                sMensagem = "Selecione algum [Status].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void fResubmitMailing_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            CarregarOperadores();
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;

            if (fLogin.Configuracao.TipoPabx != "Vonix")
            {
                ChkEnviarResubmitVonix.Visible = false;
                lblResubmitVonix.Visible = false;
            }

            if (fLogin.Configuracao.Cliente == "Mundiale" || fLogin.Configuracao.Cliente == "Vgx")
            {
                if (fLogin.Usuario.TipoDiscador == "Preditivo")
                {
                    groupBox2.Visible = false;
                    //chkLStatus.Visible = false;
                    //label4.Visible = false;
                    //cmdMarcar.Visible = false;
                    //cmdDesmarcar.Visible = false;
                    cmdCalcular.Visible = false;
                    cmdEfetuarResubmit.Visible = false;
                    ChkEnviarResubmitVonix.Visible = false;
                    lblCcliente.Visible = false;
                    lblResubmitVonix.Visible = false;
                    cmdFechar.Location = new Point(310, 88);
                    cmdResubmitCallflex.Visible = true;
                }
                else
                {
                    cmdResubmitCallflex.Visible = false;
                }
            }
        }

        private void cmdMarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkLStatus.Items.Count; ++i)
                this.chkLStatus.SetItemChecked(i, true);
        }

        private void cmdDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chkLStatus.Items.Count; ++i)
                this.chkLStatus.SetItemChecked(i, false);
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fResubmitMailing_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdCalcular_Click(object sender, EventArgs e)
        {
            if (PodeResubmit())
            {
                prospect Prospect = new prospect();
                prospectCTL CProspect = new prospectCTL();

                string sDataInicial = "";
                string sDataFinal = "";
                int iIDOperador = -1;
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                string sIDStatus = "";
                string sBairro = "";
                string sCidade = "";
                string sCep = "";

                CProspect.LimparTabelaTemporariaResubmit();

                foreach (object itemChecked in chkLStatus.CheckedItems)
                {
                    if (chkFiltroAvancado.Checked)
                    {
                        sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                        sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                        iIDOperador = Convert.ToInt32(comboOperador.SelectedValue);
                        sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtBairro.Text);
                        sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCidade.Text);
                        sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCep.Text);
                    }

                    if (sIDStatus != "")
                        sIDStatus += ", ";

                    sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-", 1) - 1);
                }
                CProspect.InserirProspectTemporiamenteResubmit(sIDStatus, iIDMailing, sDataInicial, sDataFinal, iIDOperador, sBairro, sCidade, sCep);

                lblResubmit.Text = "Será dado resubmit em " + CProspect.RetornarQuantidadeResubmit().ToString() + " prospect(s).";
            }
        }

        private void cmdEfetuarResubmit_Click(object sender, EventArgs e)
        {
            if (PodeResubmit())
            {
                Resubmit();

                //if (fLogin.Usuario.TipoDiscador == "Preditivo" && ChkEnviarResubmitVonix.Checked == true)
                //    if (ChkEnviarResubmitVonix.Checked == true)
                //    Processar();
                //else
                //    LiberarFormulario();
            }
        }

        private void CarregarOperadores()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperador);
        }

        private void Processar()
        {
            try
            {
                prospectCTL CProspect = new prospectCTL();
                campanhaCTL CCampanha = new campanhaCTL();
                campanha Campanha = new campanha();
                string sMensagem;
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);

                Campanha = CCampanha.RetornarCampanha(Convert.ToInt32(comboCampanha.SelectedValue));
                int iNumeroProcessado = 0;
                string sMailing = comboMailing.Text;
                DataTable dataTable = CProspect.RetornarProspectsResubmit(iIDMailing);
                if (dataTable.Rows.Count != 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        string sID = Convert.ToString(dataRow["IDProspect"]);
                        string sContact_name = dataRow["Nome"].ToString();
                        if (sContact_name == "") sContact_name = "--";
                        string sQueue = Campanha.Fila;
                        string sBilling_group_id = "1";
                        string sTelefone1 = dataRow["Telefone1"].ToString();

                        EnviarResubmitPreditivoVonix(sID, sContact_name, sQueue, sBilling_group_id, sTelefone1);
                        iNumeroProcessado++;
                    }

                    sMensagem = "Mailing selecionado: " + sMailing + "\n\n";
                    sMensagem += "Resubmit [Vonix] executado com sucesso em " + iNumeroProcessado.ToString() + " prospect(s).";

                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Não há Prospect disponiveis para Resubmit.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                string sMensagem;
                sMensagem = "Não foi possível conectar no servidor Vonix! \n";
                sMensagem += "============================= \n";
                sMensagem += "O servidor não respondeu a solicitação de envio. Favor verificar a conectividade ou permissão ao Servidor.\n";
                sMensagem += "Favor verificar as configurações administrativas do Vonix e caso persista, contacte a PontoBR/Vonix.\n";

                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(sMensagem, "Tabulare Software");
            }
        }

        private void EnviarResubmitPreditivoVonix(string sID, string sContact_name, string sQueue, string sBilling_group_id, string sTelefone1)
        {
            string sRetorno = string.Empty;
            /*string sUrlBx = "http://192.168.0.3:8003/contact/" + sID; //Produção bx 
            string sUrlWea = "http://192.168.0.2:8003/contact/" + sID; //Produção wea
            string sUrlRdbh = "http://10.10.20.40:8003/contact/" + sID; //Produção wea
            //string sUrl = "http://feeder.vonix.com.br/contact/" + sID; //Teste Servidor Vonix*/

            string sUrl = "http://" + fLogin.Configuracao.IPServidor + ":8003/contact/" + sID; //Produção  

            using (var webClient = new WebClient())
            {
                var data = new NameValueCollection();
                data["contact_name"] = sContact_name;
                data["queue"] = sQueue;
                data["billing_group_id"] = sBilling_group_id;
                data["to[" + sID + "]"] = sTelefone1;

                webClient.Credentials = new NetworkCredential("pontocom", "i39G75hs4"); //Produção
                //webClient.Credentials = new NetworkCredential("pontocom", "f34b523a"); //Teste
                var response = webClient.UploadValues(sUrl, "POST", data);
            }

            //Para testes
           /* if (fLogin.Configuracao.Cliente == "Wea")
              {
                  using (var webClient = new WebClient())
                  {
                      var data = new NameValueCollection();
                      data["contact_name"] = sContact_name;
                      data["queue"] = sQueue;
                      data["billing_group_id"] = sBilling_group_id;
                      data["to[" + sID + "]"] = sTelefone1;

                      webClient.Credentials = new NetworkCredential("pontocom", "i39G75hs4"); //Produção, mas pode sofrer troca de senha.
                      //webClient.Credentials = new NetworkCredential("pontocom", "f34b523a"); //Teste
                      var response = webClient.UploadValues(sUrlWea, "POST", data);
                  }
              }*/
            
        }

        private bool PodeResubmitCallflex()
        {
            string sMensagem;
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (comboMailing.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione [Mailing].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            bool bAlgumSelecionado = false;
            foreach (object itemChecked in chkLStatus.CheckedItems)
            {
                bAlgumSelecionado = true;
            }
            if (bAlgumSelecionado == false)
            {
                sMensagem = "Selecione algum [Status].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void cmdResubmitCallflex_Click(object sender, EventArgs e)
        {
            if (PodeResubmitCallflex())
            {
                ResubmitCallflex();
            }
        }

        private void ResubmitCallflex()
        {
            try
            {
                prospectCTL CProspect = new prospectCTL();
                string sMensagem;
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                int iNumeroProspectResubmit = 0;
                string sIDStatus = "";

                foreach (object itemChecked in chkLStatus.CheckedItems)
                {
                    if (sIDStatus != "")
                        sIDStatus += ", ";

                    sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-", 1) - 1);
                }

                iNumeroProspectResubmit = CProspect.ExecutarResubmitCallFlex(fLogin.Usuario.IDUsuario, iIDMailing, sIDStatus);

                string sMailing = comboMailing.Text;
                sMensagem = "Mailing selecionado: " + sMailing + "\n\n";
                sMensagem += "Resubmit para Callflex executado com sucesso em " + iNumeroProspectResubmit.ToString() + " prospect(s).";

                LiberarFormulario();
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string sMensagem;
                sMensagem = "Sem conexão com o servidor da Callflex. Favor entrar em contato com a T.i local.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LiberarFormularioMundiale()
        {
            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboMailing.DataSource = null;
        }

        private void CarregarStatus(int iIDCampanha)
        {
            chkLStatus.Items.Clear();

            statusCTL CStatus = new statusCTL();
            CStatus.PreencherCheckBoxStatusResubmit(chkLStatus, iIDCampanha);
        }

        //Status para clientes Callflex
        private void CarregarStatusCallflex(int iIDCampanha)
        {
            chkLStatus.Items.Clear();

            statusCTL CStatus = new statusCTL();
            CStatus.PreencherCheckBoxStatusResubmitCallflex(chkLStatus, iIDCampanha);
        }
    }
}