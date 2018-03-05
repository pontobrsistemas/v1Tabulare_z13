using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using controller;

namespace tabulare.relatorio
{
    public partial class fVendaMotoBoy_filtro : Form
    {
        public string mail;
        public fVendaMotoBoy_filtro()
        {
            InitializeComponent();
        }

        private void GerarRelatorio()
        {
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                int iIDStatusAuditoria = Convert.ToInt32(comboAuditoria.SelectedValue);

                string sCampanha = "";
                campanhaCTL CCampanha = new campanhaCTL();
                string sIDCampanhas = "";
                
                foreach (object itemChecked in chlCampanha.CheckedItems)
                {
                    if (sIDCampanhas != "")
                        sIDCampanhas = sIDCampanhas + ",";

                    sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                    if (sCampanha != "")
                        sCampanha = sCampanha + "; ";

                    sCampanha = sCampanha + itemChecked.ToString();
                }                

                relatorioCTL CRelatorio = new relatorioCTL();
                dgDados.DataSource = CRelatorio.RetornarDadosVendas(sDataInicial, sDataFinal, sIDCampanhas, -1, iIDStatusAuditoria, "","" , txtTelefone1_filtro.Text, txtNome_filtro.Text, txtCPFCNPJ_filtro.Text,"","","","","","","","","");
                dgDados.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void CarregarStatusAuditoria()
        {
            auditoriaCTL CAuditoria = new auditoriaCTL();
            CAuditoria.PreencherComboBox_StatusAuditoria(comboAuditoria, true, true, false);
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            if (PodeGerar())
                GerarRelatorio();
        }

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherCheckListBox_CampanhasAtivas(chlCampanha, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private bool PodeGerar()
        {
            string sMensagem;
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataInicial.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "Data Inicial incorreta.";
                MessageBox.Show(sMensagem, "Tabulare");
                return false;
            }
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataFinal.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "Data Final incorreta.";
                MessageBox.Show(sMensagem, "Tabulare");
                return false;
            }
            bool bSelecionado = false;
            foreach (object itemChecked in chlCampanha.CheckedItems)
            {
                bSelecionado = true;
            }
            if (bSelecionado == false)
            {
                MessageBox.Show("Selecione, pelo menos, uma Campanha.", "Tabulare");
                return false;
            }
            return true;
        }

        private void dgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExibirForm(Form form)
        {
            form.WindowState = FormWindowState.Maximized;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void fDadosVenda_filtro_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = true;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            CarregarStatusAuditoria();
            DefinirAcessos();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void DefinirAcessos()
        {
            if (fLogin.Usuario.Perfil == "Operador")
            {
                cmdFechar.Enabled = true;
                lblTituloFormulario.Text = "DADOS DA VENDA MOTOBOY";
                this.Text = "DADOS DA VENDA MOTOBOY";
            }
            else
            {
                cmdFechar.Enabled = true;
                lblTituloFormulario.Text = "BACKOFFICE - DADOS DA VENDA MOTOBOY";
                this.Text = "BACKOFFICE - DADOS DA VENDA MOTOBOY";
            }
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