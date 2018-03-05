using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using model.objetos;
using controller;

namespace tabulare.relatorio
{
    public partial class fConsultarCliente : Form
    {
        public static string sIDPropect;

        public fConsultarCliente()
        {
            InitializeComponent();
        }

        private void cmdConsultarCliente_Click(object sender, EventArgs e)
        {
            if (PodeConsultar())
            {
                LiberarFormulario();

                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                string sMensagem;
                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarProspects(txtTelefone1_filtro.Text.Trim(), txtNome_filtro.Text.Replace("'", "").Trim(), txtCPFCNPJ_filtro.Text.Replace("'", "").Trim(), iIDTipoAtendimento);
                dgProspect.DataSource = dataTable;
                dgProspect.Columns[1].Width = 200;

                lblRegistros.Text = dgProspect.RowCount.ToString() + " registro(s)";
                if (dataTable.Rows.Count == 0)
                {
                    sMensagem = "Dados não existentes.";
                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HabilitarBotoes()
        {
            if (fLogin.Usuario.Perfil == "Operador")
            {
                cmdNovoContato.Enabled = true;
                cmdFechar.Visible = true;
            }
            else
            {
                cmdNovoContato.Enabled = false;
                //cmdFechar.Visible = false;
            }
        }

        private void ListarHistoricoContato(double dTelefone1)
        {
            prospectCTL CProspect = new prospectCTL();
            dgHistorico.DataSource = CProspect.RetornarHistoricoContato(dTelefone1, -1, 0);
            dgHistorico.Columns[1].Width = 235;
            dgHistorico.Columns[2].Width = 200;
            dgHistorico.Columns[3].Width = 200;
            dgHistorico.Columns[4].Width = 200;
            dgHistorico.Columns[5].Width = 200;
            dgHistorico.Columns[6].Width = 150;
        }

        private bool PodeConsultar()
        {
            string sMensagem;

            if (txtTelefone1_filtro.Text.ToString() != "" && txtTelefone1_filtro.Text.Length != 10 && txtTelefone1_filtro.Text.Length != 11)
            {
                sMensagem = "O [Telefone] deve conter 10 ou 11 dígitos.";
                txtTelefone1_filtro.Focus();
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }  
            double dTelefone;
            if (Double.TryParse(txtTelefone1_filtro.Text, out dTelefone) == false && txtTelefone1_filtro.Text != "")
            {
                sMensagem = "O [Telefone] está incorreto.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNome_filtro.Text != "" && txtNome_filtro.Text.Length < 3)
            {
                sMensagem = "O [Nome] deve conter, no mínimo, 3 caracteres.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtCPFCNPJ_filtro.Text != "" && txtCPFCNPJ_filtro.Text.Length < 6)
            {
                sMensagem = "O [CPF / CNPJ] deve conter, no mínimo, 6 caracteres.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void LiberarFormulario()
        {
            grbDadosProspect.Text = "Dados do Prospect";
            txtTelefone1.Text = string.Empty;
            txtTelefone2.Text = string.Empty;
            txtTelefone3.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCodProspect.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCep.Text = string.Empty;//rr
            txtNumero.Text = string.Empty;
            txtCPF_CNPJ.Text = string.Empty;

            dgHistorico.DataSource = null;
            dgPerguntaResposta.DataSource = null;

            grbDadosProspect.Enabled = false;
            grbHistorico.Enabled = false;
            grbScript.Enabled = false;
        }

        private void fConsultarCliente_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            txtTelefone1_filtro.Focus();
            HabilitarBotoes();
        }

        private void dgHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region #Contato com Sucesso# e Script - desabilitado
            //if (e.RowIndex >= 0)
            //{
            //    if (dgHistorico.Rows[e.RowIndex].Cells[1].Value.ToString() == "#Contato com Sucesso#")
            //    { 
            //        int iIDHistorico = Convert.ToInt32(dgHistorico.Rows[e.RowIndex].Cells[0].Value.ToString());
            //        prospect Prospect = new prospect();
            //        Prospect.IDHistorico = iIDHistorico;
            //        CarregarPerguntaResposta(iIDHistorico);
            //    }                
            //}
            #endregion
        }

        private void CarregarPerguntaResposta(int iIDHistorico)
        {
            prospectCTL CProspect = new prospectCTL();
            dgPerguntaResposta.DataSource = CProspect.RetornarPerguntaResposta(iIDHistorico);
            dgPerguntaResposta.Columns["IDHistorico"].Visible = false;
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdNovoContato_Click(object sender, EventArgs e)
        {
            if (txtCodProspect.Text != "")
            {
                sIDPropect = txtCodProspect.Text;
                this.Close();
            }
            else
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("Selecione um Prospect para Fazer novo Contato.", "Tabulare Software");
        }

        private void dgProspect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LiberarFormulario();

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarDadosProspect(Convert.ToInt32(dgProspect.Rows[e.RowIndex].Cells[0].Value.ToString()));

                txtTelefone1.Text = dataTable.Rows[0]["Telefone1"].ToString();
                txtTelefone2.Text = dataTable.Rows[0]["Telefone2"].ToString();
                txtTelefone3.Text = dataTable.Rows[0]["Telefone3"].ToString();
                txtCodProspect.Text = dataTable.Rows[0]["IDProspect"].ToString();
                txtNome.Text = dataTable.Rows[0]["Nome"].ToString();
                txtLogradouro.Text = dataTable.Rows[0]["Logradouro"].ToString();
                txtBairro.Text = dataTable.Rows[0]["Bairro"].ToString();
                txtCidade.Text = dataTable.Rows[0]["Cidade"].ToString();
                txtEstado.Text = dataTable.Rows[0]["Estado"].ToString();
                txtEmail.Text = dataTable.Rows[0]["Email"].ToString();
                txtCep.Text = dataTable.Rows[0]["Cep"].ToString();//rr
                txtNumero.Text = dataTable.Rows[0]["Numero"].ToString();
                txtCPF_CNPJ.Text = dataTable.Rows[0]["CPF_CNPJ"].ToString();

                ListarHistoricoContato(Convert.ToDouble(txtTelefone1.Text));

                lblRegistrosHistorico.Text = dgHistorico.RowCount.ToString() + " Registro de histórico(s)";
                lblRegistrosHistorico.ForeColor = Color.Blue;

                grbDadosProspect.Enabled = true;
                grbHistorico.Enabled = true;
                grbScript.Enabled = true;
            }
        }

        private void txtTelefone1_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.","Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTelefone2_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTelefone3_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}