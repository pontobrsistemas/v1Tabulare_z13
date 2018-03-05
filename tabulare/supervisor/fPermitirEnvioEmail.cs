using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using model.objetos;
using PontoBr.Utilidades;
using controller;

namespace tabulare.supervisor
{
    public partial class fPermitirEnvioEmail : Form
    {
        public fPermitirEnvioEmail()
        {
            InitializeComponent();
        }

        private void fConfiguracao_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            RetornarConfigEnviarEmail();
        }

        private void cmdAtivarDesativarEnvio_Click(object sender, EventArgs e)
        {
            RetornarConfigEnviarEmail();
        }

        private void cmdConfiguracaoContaEmail_Click(object sender, EventArgs e)
        {
            RetornarConfigEnviarEmail();
        }

        private void RetornarConfigEnviarEmail()
        {
            emailCTL CEmail = new emailCTL();
            DataTable dataTable = CEmail.RetornarConfigEnviarEmail();
            txtEnviarEmail.Text = dataTable.Rows[0]["EnviarEmail"].ToString();
            int sConfimarEnvio = Convert.ToInt32(dataTable.Rows[0]["ConfimarEnvio"]);
            if (sConfimarEnvio == 0)
                chkAtivarDesativarEnvio.Checked = false;
            else
                chkAtivarDesativarEnvio.Checked = true;
            txtFrom.Text = dataTable.Rows[0]["from"].ToString();
            txtHost.Text = dataTable.Rows[0]["host"].ToString();
            txtUserName.Text = dataTable.Rows[0]["userName"].ToString();
            txtdefaultCredentials.Text = dataTable.Rows[0]["defaultCredentials"].ToString();
            txtpassword.Text = dataTable.Rows[0]["password"].ToString();
            txtPort.Text = dataTable.Rows[0]["port"].ToString();
        }
    }
}
