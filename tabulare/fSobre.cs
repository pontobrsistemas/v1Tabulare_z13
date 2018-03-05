using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tabulare
{
    public partial class fSobre : Form
    {
        public fSobre()
        {
            InitializeComponent();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Blue; 
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Black; 
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string url = "http://www.pontobrsistemas.com.br";
            System.Diagnostics.Process.Start(url);
        }

        private void fSobre_Load(object sender, EventArgs e)
        {
            lblVersao.Text = "Versão " + fLogin.sVersaoAplicativo + " - (Compilação " + fLogin.sRelease + ")";
            lblVersaoFramework.Text = "Versão Framework - " + PontoBr.Configuracao.Versao;
            lblCopyright.Text = "Copyright © "+ DateTime.Now.Year.ToString()+ " PontoBR Sistemas";
        }
    }
}
