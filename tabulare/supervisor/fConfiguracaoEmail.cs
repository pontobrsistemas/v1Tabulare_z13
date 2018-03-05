using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using model.objetos;
using System.Threading;

namespace tabulare.supervisor
{
    public partial class fConfiguracaoEmail : Form
    {
        int iConfirmarEnvio = 0;
        int iDefaultCredentials = 0;

        public fConfiguracaoEmail()
        {
            InitializeComponent();
        }

        private void fConfiguracaoEmail_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            CarregarStatus();
            RetornarConfigEnviarEmail();
        }

        private void CarregarStatus()
        {
            //Verifica se há script de atendimento
            if (fLogin.Configuracao.Script == 0)
            {
                statusCTL CStatus = new statusCTL();
                CStatus.PreencherComboBox_Status(comboStatus, fLogin.Usuario.IDCampanha, fLogin.Configuracao.Script);
            }
            else
            {
                statusCTL CStatus = new statusCTL();
                CStatus.PreencherComboBox_Status(comboStatus, fLogin.Usuario.IDCampanha, fLogin.Configuracao.Script);
            }
        }

        private void RetornarConfigEnviarEmail()
        { 
            emailCTL CEmail =  new emailCTL();
            DataTable dataTable = CEmail.RetornarConfigEnviarEmail();
            txtSmtp.Text = dataTable.Rows[0]["Smtp"].ToString();
            txtUserName.Text = dataTable.Rows[0]["userName"].ToString();
            txtPassword.Text = dataTable.Rows[0]["password"].ToString();
            txtPort.Text = Convert.ToString(dataTable.Rows[0]["port"].ToString());
            txtDestinatario.Text = Convert.ToString(dataTable.Rows[0]["Destinatario"].ToString());

            iConfirmarEnvio = Convert.ToInt32(dataTable.Rows[0]["ConfirmarEnvio"].ToString());
            if (iConfirmarEnvio == 1)
                radSimConfirmaEnvio.Checked = true;
            else
                radNaoConfirmaEnvio.Checked = true;

            iDefaultCredentials = Convert.ToInt32(dataTable.Rows[0]["defaultCredentials"]);
            if (iDefaultCredentials == 1)
                radSimDefaultCredentials.Checked = true;
            else
                radNaoDefaultCredentials.Checked = true;

            comboStatus.SelectedValue = dataTable.Rows[0]["IDStatus"].ToString();

            txtMensagemEmail.Text = dataTable.Rows[0]["MensagemEmail"].ToString();
            txtLinkImagem.Text = dataTable.Rows[0]["LinkImagem"].ToString();
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            string sSmtp = txtSmtp.Text.ToString();
            string sUserName = txtUserName.Text.ToString();
            string sPassword = txtPassword.Text.ToString();
            int sProt = Convert.ToInt32(txtPort.Text.ToString());
            string sDestinatario = txtDestinatario.Text.ToString();

            if (radSimConfirmaEnvio.Checked == true)
                iConfirmarEnvio = 1;
            else
                iConfirmarEnvio = 0;

            if (radSimDefaultCredentials.Checked == true)
                iDefaultCredentials = 1;
            else
                iDefaultCredentials = 0;

            int iIDStatus = Convert.ToInt32(comboStatus.SelectedValue.ToString());

            emailCTL CEmail = new emailCTL();
            CEmail.CadastrarDadosConfiguracaoEmail(sSmtp, sUserName, sPassword, sProt, sDestinatario, iConfirmarEnvio, iDefaultCredentials, iIDStatus);

            string sMensagem =  "====================== \n";
                   sMensagem += "Configuração salva com sucesso.\n";
                   sMensagem += "====================== \n";

            MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void cmdSalvaMensagem_Click(object sender, EventArgs e)
        {
            emailCTL CEmail = new emailCTL();
            CEmail.CadastrarMensagemEmail(txtMensagemEmail.Text, txtLinkImagem.Text);

            string sMensagem = "========================== \n";
            sMensagem += "Mensagem e Link salvos com sucesso.\n";
            sMensagem += "========================== \n";

            MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
