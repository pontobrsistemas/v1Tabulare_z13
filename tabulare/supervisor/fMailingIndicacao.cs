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
    public partial class fMailingIndicacao : Form
    {
        public fMailingIndicacao()
        {
            InitializeComponent();
        }

        private void LiberarFormulario()
        {
            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboMailing.DataSource = null;            
        }

        private void fResubmitMailing_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CarregarMailings(int iIDCampanha)
        {
            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_Mailings(comboMailing, iIDCampanha);

            int iIDMailing = CMailing.RetornarMailingIndicacaoSupervisor(iIDCampanha);

            if (iIDMailing == 0)
                comboMailing.SelectedValue = "-1";
            else
                comboMailing.SelectedValue = iIDMailing.ToString();
        }

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }  

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                if (iIDCampanha != -1)
                {
                    CarregarMailings(iIDCampanha);                    
                    comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        private void fMailingIndicacao_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeSalvar())
            {
                mailingCTL CMailing = new mailingCTL();
                CMailing.SalvarMailingIndicacao(Convert.ToInt32(comboCampanha.SelectedValue), Convert.ToInt32(comboMailing.SelectedValue));

                MessageBox.Show("Alterações salvas com sucesso.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }   
            return true;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboMailing.DataSource = null;

            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fMailingIndicacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
