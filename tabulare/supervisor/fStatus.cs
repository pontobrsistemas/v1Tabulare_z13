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
    public partial class fStatus : Form
    {
        public fStatus()
        {
            InitializeComponent();
        }

        private void fStatus_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarAcoes();
            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboCampanha.Focus();
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ListarStatus(int iIDCampanha)
        {
            statusCTL CStatus = new statusCTL();
            dgStatus.DataSource = CStatus.RetornarStatusCadastro(iIDCampanha);


            //dgStatus.Columns[1].Width = 400;
            //dgStatus.Columns[2].Width = 200;
            //dgStatus.Columns[3].Width = 200;
            //dgStatus.Columns[4].Width = 170;
            //dgStatus.Columns[5].Width = 196;
        }

        private void CarregarAcoes()
        {
            acaoCTL CAcao = new acaoCTL();
            CAcao.PreencherComboBox_Acao(comboAcao);
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PodeSalvar())
                {
                    status Status = new status();

                    statusCTL CStatus = new statusCTL();

                    Status.IDStatus = Convert.ToInt32(txtIDStatus.Text);
                    Status.QtdeTentativas = Convert.ToInt32(txtQtdeTentativas.Text);
                    Status.TempoRetorno = txtHoraRetorno.Text;
                    if (radSim.Checked == true)
                    {
                        Status.Ativo = 1;
                    }
                    else
                    {
                        Status.Ativo = 0;
                    }

                    CStatus.AlteraStatus(Status);

                    MessageBox.Show("Alterações salvas com sucesso.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparFormulario();
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void dgStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIDStatus.Text = dgStatus.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtStatus.Text = dgStatus.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtQtdeTentativas.Text = dgStatus.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtHoraRetorno.Text = dgStatus.Rows[e.RowIndex].Cells[4].Value.ToString();

                acaoCTL CAcao = new acaoCTL();
                string sIDAcao = CAcao.RetornarIDAcao(dgStatus.Rows[e.RowIndex].Cells[2].Value.ToString());
                comboAcao.SelectedValue = sIDAcao;

                if (txtIDStatus.Text != "")
                {
                    cmdSalvar.Enabled = true;
                    comboAcao.Enabled = false;
                    txtStatus.Enabled = false;
                    txtHoraRetorno.Enabled = true;
                    txtQtdeTentativas.Enabled = true;
                    radNao.Enabled = true;
                    radSim.Enabled = true;
                }
                else
                {
                    cmdSalvar.Enabled = false;
                    comboAcao.Enabled = false;
                    txtStatus.Enabled = false;
                    txtHoraRetorno.Enabled = false;
                    txtQtdeTentativas.Enabled = false;
                    radNao.Enabled = false;
                    radSim.Enabled = false;
                }

                //Ativo
                if (dgStatus.Rows[e.RowIndex].Cells[5].Value.ToString() == "Sim")
                {
                    radSim.Checked = true;
                    radNao.Checked = false;
                }
                else
                {
                    radSim.Checked = false;
                    radNao.Checked = true;
                }
            }
        }

        private void LimparFormulario()
        {
            //txtIDStatus.Text = "";
            txtStatus.Text = "";
            txtQtdeTentativas.Text = "";
            txtHoraRetorno.Text = "";

            cmdSalvar.Enabled = false;
            comboAcao.Enabled = false;
            txtStatus.Enabled = false;
            txtHoraRetorno.Enabled = false;
            txtQtdeTentativas.Enabled = false;
            radNao.Enabled = false;
            radSim.Enabled = false;

            comboAcao.SelectedValue = "-1";
            ListarStatus(Convert.ToInt32(comboCampanha.SelectedValue));
        }

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (txtQtdeTentativas.Text == "0")
            {
                sMensagem = "A [Quant. Tentativas] está incorreta. Selecione acima de 0 (Zero).";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            if (txtQtdeTentativas.Text == "")
            {
                sMensagem = "Preencha o campo [Quant. Tentativas].";
                MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            double dQtdeTentativas;
            if (Double.TryParse(txtQtdeTentativas.Text, out dQtdeTentativas) == false && txtQtdeTentativas.Text != "")
            {
                sMensagem = "A [Quant. Tentativas] está incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!PontoBr.Conversoes.Data.ValidarDataBr("01/01/1900 " + txtHoraRetorno.Text))
            {
                sMensagem = "[Tempo de Retorno] inválido.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }           
            return true;
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                ListarStatus(Convert.ToInt32(comboCampanha.SelectedValue));

                lblRegistros.Text = dgStatus.RowCount.ToString() + " registro(s)";
            }
        }

        private void txtQtdeTentativas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fStatus_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}