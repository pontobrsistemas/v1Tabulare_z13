using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using model.objetos;

namespace tabulare.supervisor
{
    public partial class fBlackList : Form
    {
        public fBlackList()
        {
            InitializeComponent();
        }

        private void fUsuario_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ListarBlackList();
            txtTelefone.Focus();
        }

        private void ListarBlackList()
        {
            prospectCTL CProspect = new prospectCTL();
            dgDados.DataSource = CProspect.RetornarBlackList();

            dgDados.Columns[0].Width = 100;
            dgDados.Columns[1].Width = 200;
            dgDados.Columns[2].Width = 400;

            lblRegistros.Text = dgDados.RowCount.ToString() + " registro(s)";            
        }

        private void dgDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                txtTelefone.Text = dgDados.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PodeSalvar())
                {
                    prospectCTL CProspect = new prospectCTL();
                    CProspect.CadastrarBlackList(Convert.ToDouble(txtTelefone.Text), fLogin.Usuario.IDUsuario);
                    
                    LimparFormulario();
                    MessageBox.Show("[Telefone] incluído com sucesso!", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void ExibirForm(Form form)
        {
            this.Hide();
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            form.Show();
            this.Close();
        }

        private void LimparFormulario()
        {            
            txtTelefone.Text = "";
            ListarBlackList();
            txtTelefone.Focus();
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (txtTelefone.Text.Trim().ToString() == "")
            {
                sMensagem = "Digite o [Telefone].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTelefone.Text.Trim().Length != 10 && txtTelefone.Text.Trim().Length != 11)
            {
                sMensagem = "[Telefone] deve conter 10 ou 11 dígitos";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTelefone.Text.Substring(0, 1) == "0")
            {
                sMensagem = "[Telefone] incorreto.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            prospectCTL CProspect = new prospectCTL();
            if (CProspect.VerificarTelefoneBlackList(Convert.ToDouble(txtTelefone.Text)))
            {
                sMensagem = "O [Telefone] já está cadastrado.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }        

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool PodeExcluir()
        {
            string sMensagem;
            if (txtTelefone.Text.Trim().ToString() == "")
            {
                sMensagem = "Digite ou clique no [Telefone].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTelefone.Text.Trim().Length != 10 && txtTelefone.Text.Trim().Length != 11)
            {
                sMensagem = "[Telefone] deve conter 10 ou 11 dígitos";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTelefone.Text.Substring(0, 1) == "0")
            {
                sMensagem = "[Telefone] incorreto.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            prospectCTL CProspect = new prospectCTL();
            if (!CProspect.VerificarTelefoneBlackList(Convert.ToDouble(txtTelefone.Text)))
            {
                sMensagem = "[Telefone] não está no Blacklist.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }   

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (PodeExcluir())
                {
                    prospectCTL CProspect = new prospectCTL();
                    CProspect.ExcluirTelefoneBlackList(Convert.ToDouble(txtTelefone.Text));

                    LimparFormulario();
                    MessageBox.Show("[Telefone] excluído com sucesso!", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }
    }
}