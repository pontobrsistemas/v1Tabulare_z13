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
    public partial class fBloqueioDDD : Form
    {
        public fBloqueioDDD()
        {
            InitializeComponent();
        }

        private void fCampanha_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            comboCampanha.Focus();
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void SelecionarDDDBloqueado(int iIDCampanha)
        {
            prospectCTL CProspect = new prospectCTL();
            DataTable dataTable = CProspect.RetornarBloqueiosDDD(iIDCampanha);
            dgDDD.DataSource = dataTable;

            //Desmarca todos os DDD
            for (int i = 0; i < this.chkDDD.Items.Count; ++i)
                this.chkDDD.SetItemChecked(i, false); 

            for (int i = 0; i < this.chkDDD.Items.Count; ++i)            
                foreach (DataRow dataRow in dataTable.Rows)
                    if (chkDDD.Items[i].ToString() == dataRow["DDD"].ToString())
                        this.chkDDD.SetItemChecked(i, true);                
        }

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeSalvar())
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);

                prospectCTL CProspect = new prospectCTL();
                
                //Exclui todos os DDDs para cadastrar novamente
                CProspect.ExcluirBloqueioDDD(iIDCampanha);
                foreach (object itemChecked in chkDDD.CheckedItems)
                {
                    CProspect.CadastrarBloqueioDDD(Convert.ToInt32(itemChecked.ToString()), fLogin.Usuario.IDUsuario, iIDCampanha);                    
                }

                SelecionarDDDBloqueado(Convert.ToInt32(comboCampanha.SelectedValue.ToString()));

                lblRegistros.Text = dgDDD.RowCount.ToString() + " registro(s)";

                MessageBox.Show("Registros salvos com sucesso!", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LiberarFormulario();
        }

        private void LiberarFormulario()
        {
            comboCampanha.SelectedValue = "-1";
            SelecionarDDDBloqueado(Convert.ToInt32(comboCampanha.SelectedValue.ToString()));
        }

        private bool PodeSalvar()
        {
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Selecione [Campanha].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                if (iIDCampanha != -1)
                {
                    SelecionarDDDBloqueado(iIDCampanha);
                    lblRegistros.Text = dgDDD.RowCount.ToString() + " registro(s)";
                }
                else
                {
                    SelecionarDDDBloqueado(-1);
                    lblRegistros.Text = dgDDD.RowCount.ToString() + " registro(s)";
                }
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fBloqueioDDD_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }               
    }
}