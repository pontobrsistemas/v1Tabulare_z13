using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;

namespace tabulare.operador
{
    public partial class fTrocarSenha : Form
    {

        public fTrocarSenha()
        {
            InitializeComponent();
        }

        private void CarregarLayout()
        {
            this.BackColor = System.Drawing.Color.FromName("Gainsboro");
            this.ControlBox = false;


            string sFormulario = "TABULARE - TROCAR SENHA";
            this.Text = sFormulario + " - " + fLogin.sVersaoAplicativo + " (" + fLogin.sRelease + ")";
        }

        private void fContatosTrabalhados_Load(object sender, EventArgs e)
        {
            CarregarLayout();
        }        
        
        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeSalvar())
            {
                usuarioCTL CUsuario = new usuarioCTL();
                CUsuario.AlterarSenha(fLogin.Usuario.IDUsuario, txtNovaSenha.Text);

                MessageBox.Show("Senha alterada com sucesso!", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (txtSenhaAtual.Text.Trim() == "")
            {
                LimparCampos();
                sMensagem = "Preencha [Senha Atual].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNovaSenha.Text.Trim() == "")
            {
                LimparCampos();
                sMensagem = "Preencha [Nova Senha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtRepetirNovaSenha.Text.Trim() == "")
            {
                LimparCampos();
                sMensagem = "Preencha [Repetir Nova Senha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNovaSenha.Text.Trim() != txtRepetirNovaSenha.Text.Trim())
            {
                LimparCampos();
                sMensagem = "[Nova Senha] está diferente de [Repetir Nova Senha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            usuarioCTL CUsuario = new usuarioCTL();
            if (CUsuario.VerificarSenhaAtual(fLogin.Usuario.IDUsuario, txtSenhaAtual.Text) == false)
            {
                LimparCampos();
                sMensagem = "[Senha Atual] está incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;  
        }

        private void LimparCampos()
        {
            txtSenhaAtual.Text = "";
            txtNovaSenha.Text = "";
            txtRepetirNovaSenha.Text = "";
            txtSenhaAtual.Focus();
        }
    }
}