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
    public partial class fStatusAuditoria : Form
    {
        public fStatusAuditoria()
        {
            InitializeComponent();
        }       
        
        private void ListarStatusAuditoria()
        {
            auditoriaCTL CAuditoria = new auditoriaCTL();
            dgDados.DataSource = CAuditoria.RetornarStatusAuditoria(false);

            lblRegistros.Text = dgDados.RowCount.ToString() + " registro(s)";
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeSalvar())
            {
                if (txtIDStatusAuditoria.Text != "")
                {                    
                    int iIDStatusAuditoria = Convert.ToInt32(txtIDStatusAuditoria.Text);
                    int iTempoExpiracao = Convert.ToInt32(txtTempoExpiracao.Text);                    
                    int iAtivo = radSim.Checked == true ? 1 : 0;
                   
                    auditoriaCTL CAuditoria = new auditoriaCTL();
                    CAuditoria.AtualizarStatusAuditoria(iIDStatusAuditoria, iTempoExpiracao, iAtivo);

                    LimparFormulario();

                    MessageBox.Show("Alterações salvas com sucesso.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }       

        private bool PodeSalvar()
        {
            string sMensagem;
            if (txtIDStatusAuditoria.Text == "")
            {
                sMensagem = "Selecione algum Status de Auditoria.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtStatusAuditoria.Text == "")
            {
                sMensagem = "Preencha o campo [Status].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTempoExpiracao.Text == "")
            {
                sMensagem = "Preencha o campo [Tempo de Expiração].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (radSim.Checked == false && radNao.Checked == false)
            {
                MessageBox.Show("Selecione Sim ou Não para Ativo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void LimparFormulario()
        {
            txtIDStatusAuditoria.Text = "";
            txtStatusAuditoria.Text = "";
            txtTempoExpiracao.Text = "";
            radSim.Checked = false;
            radNao.Checked = false;
            ListarStatusAuditoria();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }        

        private void dgDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIDStatusAuditoria.Text = dgDados.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtStatusAuditoria.Text = dgDados.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTempoExpiracao.Text = dgDados.Rows[e.RowIndex].Cells[2].Value.ToString();
                radSim.Checked = dgDados.Rows[e.RowIndex].Cells[3].Value.ToString() == "Sim" ? true : false;
                radNao.Checked = dgDados.Rows[e.RowIndex].Cells[3].Value.ToString() == "Não" ? true : false;
            }
        }

        private void fStatusAuditoria_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ListarStatusAuditoria();
            txtStatusAuditoria.Focus();

            dgDados.Columns[0].Width = 50;
            dgDados.Columns[1].Width = 350;
            dgDados.Columns[2].Width = 100;
            dgDados.Columns[3].Width = 100;
            dgDados.Columns[3].Width = 100;
        }

        private void fStatusAuditoria_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtTempoExpiracao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}