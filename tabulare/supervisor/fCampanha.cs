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
    public partial class fCampanha : Form
    {
        public fCampanha()
        {
            InitializeComponent();
        }

        private void dgCampanha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIDCampanha.Text = dgCampanha.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCampanha.Text = dgCampanha.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtOperadora.Text = dgCampanha.Rows[e.RowIndex].Cells[3].Value.ToString();
                radSim.Checked = dgCampanha.Rows[e.RowIndex].Cells[4].Value.ToString() == "Sim" ? true : false;
                radNao.Checked = dgCampanha.Rows[e.RowIndex].Cells[4].Value.ToString() == "Não" ? true : false;
                chkEditarDadosProspect.Checked = dgCampanha.Rows[e.RowIndex].Cells[5].Value.ToString() == "Não" ? false : true;
                radPower.Checked = dgCampanha.Rows[e.RowIndex].Cells[6].Value.ToString() == "Power" ? true : false;
                radPreditivo.Checked = dgCampanha.Rows[e.RowIndex].Cells[6].Value.ToString() == "Preditivo" ? true : false;
            }
        }        

        private void fCampanha_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ListarCampanhas();
            txtCampanha.Focus();
        }

        private void ListarCampanhas()
        {
            campanhaCTL CCampanha = new campanhaCTL();
            dgCampanha.DataSource = CCampanha.RetornarCampanhas();
            dgCampanha.Columns[0].Width = 100;
            dgCampanha.Columns[1].Width = 300;
            dgCampanha.Columns[2].Width = 150;
            dgCampanha.Columns[3].Width = 100;
            dgCampanha.Columns[4].Width = 50;
            dgCampanha.Columns[5].Width = 150;
            dgCampanha.Columns[6].Width = 300;

            lblRegistros.Text = dgCampanha.RowCount.ToString() + " registro(s)";
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeSalvar())
            {
                if (txtIDCampanha.Text != "")
                {
                    campanha Campanha = new campanha();
                    Campanha.iIDCampanha = Convert.ToInt32(txtIDCampanha.Text);
                    Campanha.sCampanha = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCampanha.Text.ToString());
                    Campanha.sOperadora = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtOperadora.Text.ToString());
                    Campanha.iAtivo = radSim.Checked == true ? 1 : 0;
                    Campanha.PermiteEditarDadosProspect = chkEditarDadosProspect.Checked == true ? 1 : 0;
                    Campanha.iIDTipoDiscador = radPower.Checked == true ? 1 : 2;

                    campanhaCTL CCampanha = new campanhaCTL();
                    CCampanha.AtualizaCampanha(Campanha);

                    LimparFormulario();

                    MessageBox.Show("Alterações salvas com sucesso.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #region Não é permitido cadastrar novas Campanhas, apenas editar
                //else 
                //{
                //    campanha Campanha = new campanha();
                //    Campanha.sCampanha = txtCampanha.Text;
                //    Campanha.iAtivo = radSim.Checked == true ? 1 : 0;

                //    campanhaCTL Ccampanha = new campanhaCTL();
                //    Ccampanha.CadastrarCampanhas(Campanha);

                //    LimparFormulario();

                //    string sMensagem;
                //    sMensagem = "Campanha cadastrada com sucesso. \n";
                //    MessageBox.Show(sMensagem, "Tabulare");
                //}
                #endregion
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }       

        private bool PodeSalvar()
        {
            string sMensagem;
            if (txtCampanha.Text == "")
            {
                sMensagem = "Preencha ou selecione alguma [Campanha].";
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
            txtIDCampanha.Text = "";
            txtCampanha.Text = "";
            txtOperadora.Text = "";
            radSim.Checked = false;
            radNao.Checked = false;
            ListarCampanhas();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fCampanha_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}