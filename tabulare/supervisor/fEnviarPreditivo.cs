using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using controller;
using model.objetos;
using System.Net;
using System.Collections.Specialized;
using System.Xml;

namespace tabulare.supervisor
{
    public partial class fEnviarPreditivo : Form
    {
        private bool bNomeVonix = false;

        public fEnviarPreditivo()
        {
            InitializeComponent();
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
                DataTable dataTable = CProspect.RetornarProspectsVirgens(iIDMailing);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    string sID = Convert.ToString(dataRow["IDProspect"]);
                    string sContact_name = dataRow["Nome"].ToString() == "" ? "Prospect " + Convert.ToString(dataRow["IDProspect"]) : dataRow["Nome"].ToString();
                    string sQueue = Campanha.Fila;
                    string sBilling_group_id = "1";
                    string sTelefone1 = dataRow["Telefone1"].ToString();

                    EnviarContatosPreditivoVonix(sID, sContact_name, sQueue, sBilling_group_id, sTelefone1);
                    CProspect.CadastrarProspectEnviadoPreditivo(Convert.ToInt32(dataRow["IDProspect"]));

                    iNumeroProcessado++;
                }

                sMensagem = "Mailing selecionado: " + sMailing + "\n\n";
                sMensagem += "Prospects enviados para o preditivo: " + iNumeroProcessado.ToString();

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
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                if (iIDCampanha != -1)
                {
                    CarregarMailings(iIDCampanha, 0);
                    comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    comboMailing.SelectedValue = -1;
                }
            }
        }

        private bool PodeProcessar()
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
            return true;
        }

        private void fEnviarPreditivo_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fEnviarPreditivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeProcessar())
                Processar();
        }

        private void EnviarContatosPreditivoVonix(string sID, string sContact_name, string sQueue, string sBilling_group_id, string sTelefone1)
        {
            try
            {
                string sRetorno = string.Empty;

                string sUrl = "http://" + fLogin.Configuracao.IPServidor + ":8003/contact/" + sID; //Produção  
                using (var webClient = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["contact_name"] = sContact_name;
                    data["queue"] = sQueue;
                    data["billing_group_id"] = sBilling_group_id;
                    data["to[" + sID + "]"] = sTelefone1;

                    webClient.Credentials = new NetworkCredential("pontocom", "i39G75hs4"); //Produção
                    var response = webClient.UploadValues(sUrl, "POST", data);
                }
                
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
    }
}