using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using model.objetos;
using System.Diagnostics;
using tabulare.operador;
using MarqueControl.Entity;
using System.Collections;

namespace tabulare
{
    public partial class fOperador : Form
    {
        fAtendimento FecharTodasConexoes = new fAtendimento();
        fAtendimento LogarAgenteVonix = new fAtendimento();
        fAtendimento LiberarProspectEmUso = new fAtendimento();

        public static string sNomeFormulario;
        public fOperador()
        {
            InitializeComponent();
        }

        private void CarregarLayout()
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.FromName("Gainsboro");
            this.ShowIcon = false;

            string sFormulario = "TABULARE - OPERADOR";
            this.Text = sFormulario + " - " + fLogin.sVersaoAplicativo + " (" + fLogin.sRelease + ")";
        }

        private void CarregarInfoUsuario()
        {
            try
            {
                if (fLogin.Usuario != null)
                {
                    string sUsuario = fLogin.Usuario.Nome.ToUpper();
                    if (sUsuario.Length > 35)
                        sUsuario = sUsuario.Substring(0, 35);

                    lblUsuario.Text = sUsuario;
                    lblLogin.Text = fLogin.Usuario.Login.ToUpper();
                    lblInformacoes.Text = fLogin.Usuario.Ramal.ToUpper();
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            string nomeFormulario = myButton.Parent.Parent.Name;

            if (MessageBox.Show("Deseja realmente fechar o Tabulare Software?", "Tabulare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LiberarProspectEmUso.LiberarProspectEmUso();

                //Fecha conexão: Planetfone - Digistar - Vonix
                FecharTodasConexoes.FecharTodasComexoes();

                Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void fOperador_Load(object sender, EventArgs e)
        {

            pictureBox3.Location = new Point(1135, 4);
            CarregarLayout(); 
            CarregarInfoUsuario();
            ExibirForm(new operador.fAtendimento());

            timerTratamentoVenda.Enabled = true;
        }


        public static void ExibirForm(Form form)
        {
            form.MdiParent = tabulare.fOperador.ActiveForm;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void picLogin_Click(object sender, EventArgs e)
        {
            Form form = new operador.fTrocarSenha();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void fOperador_FormClosing(object sender, FormClosingEventArgs e)
        {
            LiberarProspectEmUso.LiberarProspectEmUso();

            //Fecha conexão: Planetfone - Digistar - Vonix
            FecharTodasConexoes.FecharTodasComexoes();

            Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}