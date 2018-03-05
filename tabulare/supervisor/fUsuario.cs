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
    public partial class fUsuario : Form
    {
        public fUsuario()
        {
            InitializeComponent();
        }

        private void fUsuario_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhasAtivasCheckBoxList(-1);
            ListarUsuarios(-1);

            txtNome.Focus();
        }

        private void ListarUsuarios(int iIDCampanha)
        {
            usuarioCTL CUsuario = new usuarioCTL();
            dgUsuario.DataSource = CUsuario.RetornarUsuarios(Convert.ToBoolean(chkListarAtivos.Checked));
            dgUsuario.Columns[1].Width = 400;
            dgUsuario.Columns[2].Width = 200;
            dgUsuario.Columns[3].Width = 200;
            dgUsuario.Columns[4].Width = 200;
            dgUsuario.Columns[5].Width = 165;

            int iNumeroOperadoresAtivo = CUsuario.RetornarQuantidadeOperadores();
            lblOperadorAtivo.Text = "Sua licença é de " + fLogin.iNumeroOperadores.ToString() + " operador(es) ativo(s), ";
            lblOperadorAtivo.Text += "há atualmente " + iNumeroOperadoresAtivo.ToString() + " ativo(s).";

            if (iNumeroOperadoresAtivo > fLogin.iNumeroOperadores)
            {
                lblOperadorAtivo.ForeColor = System.Drawing.Color.Red;
                lblOperadorAtivo.Text += " Não será possível logar com o Perfil Operador.";
            }
            else
            {
                lblOperadorAtivo.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void dgUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIDUsuario.Text = dgUsuario.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNome.Text = dgUsuario.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLogin.Text = dgUsuario.Rows[e.RowIndex].Cells[2].Value.ToString();

                //Robson
                if (dgUsuario.Rows[e.RowIndex].Cells[3].Value.ToString() == "Operador") radOperador.Checked = true;
                else if (dgUsuario.Rows[e.RowIndex].Cells[3].Value.ToString() == "Supervisor") radSupervisor.Checked = true;
                else if (dgUsuario.Rows[e.RowIndex].Cells[3].Value.ToString() == "BackOffice") radBackoffice.Checked = true;
                
                //Campanha
                usuarioCTL CUsuario = new usuarioCTL();
                if (dgUsuario.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
                {
                    DataTable dataTable = CUsuario.RetornarCampanhasUsuario(Convert.ToInt32(dgUsuario.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    //chlCampanha.DataSource = dataTable;

                    //Desmarca todas as Campanhas
                    for (int i = 0; i < this.chlCampanha.Items.Count; ++i)
                        this.chlCampanha.SetItemChecked(i, false);

                    for (int i = 0; i < this.chlCampanha.Items.Count; ++i)
                        foreach (DataRow dataRow in dataTable.Rows)
                            if (chlCampanha.Items[i].ToString() == dataRow["Campanha"].ToString())
                                this.chlCampanha.SetItemChecked(i, true);
                }

                //Ativo
                if (dgUsuario.Rows[e.RowIndex].Cells[5].Value.ToString() == "Sim")
                {
                    radSim.Checked = true;
                    radNao.Checked = false;
                }
                else
                {
                    radSim.Checked = false;
                    radNao.Checked = true;
                }

                txtSenha.Text = CUsuario.RetornarSenha(Convert.ToInt32(dgUsuario.Rows[e.RowIndex].Cells[0].Value.ToString()));
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
                    string sMensagem = "";
                    usuario Usuario = new usuario();
                    usuarioCTL CUsuario = new usuarioCTL();

                    Usuario.Nome = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome.Text);
                    Usuario.Login = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtLogin.Text);
                    Usuario.Senha = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtSenha.Text);
                    Usuario.Ativo = radSim.Checked == true ? 1 : 0;

                    //Robson
                    if (radSupervisor.Checked == true) Usuario.IDPerfil = 1;
                    else if (radOperador.Checked == true) Usuario.IDPerfil = 2;
                    else if (radBackoffice.Checked == true) Usuario.IDPerfil = 4;                    
                    
                    if (txtIDUsuario.Text != "")
                    {
                        Usuario.IDUsuario = Convert.ToInt32(txtIDUsuario.Text);
                        
                        //Editar dados da tabela de Usuário
                        CUsuario.EditarUsuario(Usuario);
                        //Exclui todas as campanhas do usuário
                        CUsuario.ExcluirUsuarioCampanhas(Usuario.IDUsuario);
                        foreach (object itemChecked in chlCampanha.CheckedItems)
                        {
                            CUsuario.CadastrarUsuarioCampanhas(Usuario.IDUsuario, itemChecked.ToString());
                        }
                        sMensagem = "Alterações salvas com sucesso!"; 
                     }
                    else
                    {
                        Usuario.IDUsuario = Convert.ToInt32(CUsuario.CadastrarUsuario(Usuario, fLogin.Usuario.IDUsuario));
                        foreach (object itemChecked in chlCampanha.CheckedItems)
                        {
                            CUsuario.CadastrarUsuarioCampanhas(Usuario.IDUsuario, itemChecked.ToString());
                        }
                        sMensagem = "Usuário cadastrado com sucesso!";                        
                    }
                    chkListarAtivos.Checked = true;
                    LimparFormulario();
                    ListarUsuarios(-1);
                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtIDUsuario.Text = "";
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";

            radNao.Checked = false;
            radSim.Checked = false;
            radOperador.Checked = false;
            radSupervisor.Checked = false;

            //Marca todos as Campanhas
            for (int i = 0; i < this.chlCampanha.Items.Count; ++i)
                this.chlCampanha.SetItemChecked(i, false);
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (chlCampanha.CheckedItems.Count == 0)
            {
                sMensagem = "Selecione [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNome.Text == "")
            {
                sMensagem = "Preencha [Nome].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtNome.Text.IndexOf("'") > -1)
            {
                sMensagem = "Não utilize aspas simples (') no campo [Nome].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtLogin.Text == "")
            {
                sMensagem = "Preencha [Login].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtLogin.Text.IndexOf("'") > -1)
            {
                sMensagem = "Não utilize aspas simples (') no campo [Login].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtSenha.Text == "")
            {
                sMensagem = "Preencha [Senha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtSenha.Text.IndexOf("'") > -1)
            {
                sMensagem = "Não utilize aspas simples (') no campo [Senha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (radNao.Checked == false && radSim.Checked == false)
            {
                sMensagem = "Selecione Sim ou Não para Ativo.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (radOperador.Checked == false && radSupervisor.Checked == false && radBackoffice.Checked == false)
            {
                sMensagem = "Selecione [Perfil].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (radOperador.Checked == true && chlCampanha.CheckedItems.Count == 0)
            {
                sMensagem = "Selecione [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //Verifica se o login já está cadastrado
            int iIDUsuario = txtIDUsuario.Text == "" ? -1 : Convert.ToInt32(txtIDUsuario.Text);
            usuarioCTL CUsuario = new usuarioCTL();
            if (CUsuario.VerificarExistenciaUsuario(PontoBr.Utilidades.String.RemoverCaracterInvalido(txtLogin.Text), iIDUsuario))
            {
                sMensagem = "O [Login] já está cadastrado.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void chkListarAtivos_CheckedChanged(object sender, EventArgs e)
        {
            ListarUsuarios(-1);

            if (txtIDUsuario.Text != "")
                LimparFormulario();
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

        private void CarregarCampanhasAtivasCheckBoxList(int iIDUsuario)//r
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherCheckListBox_CampanhasAtivas(chlCampanha, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void cmdMarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chlCampanha.Items.Count; ++i)
                this.chlCampanha.SetItemChecked(i, true);
        }

        private void cmdDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chlCampanha.Items.Count; ++i)
                this.chlCampanha.SetItemChecked(i, false);
        }
    }
}