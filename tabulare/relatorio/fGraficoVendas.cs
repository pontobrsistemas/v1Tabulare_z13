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
    public partial class fGraficoVendas : Form
    {
        private ReportDocument reportDocument;

        public fGraficoVendas()
        {
            InitializeComponent();
        }

        private void GerarRelatorio()
        {
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                string sCampanha = "";
                int iIDStatusAuditoria = Convert.ToInt32(comboAuditoria.SelectedValue);

                campanhaCTL CCampanha = new campanhaCTL();
                string sIDCampanhas = "";
                foreach (object itemChecked in chlCampanha.CheckedItems)
                {
                    if (sIDCampanhas != "")
                        sIDCampanhas = sIDCampanhas + ",";

                    sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(itemChecked.ToString());

                    if (sCampanha != "")
                        sCampanha = sCampanha + ", ";

                    sCampanha = sCampanha + itemChecked.ToString();
                }

                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarVendasSintetico(sDataInicial, sDataFinal, sIDCampanhas, iIDTipoAtendimento, iIDStatusAuditoria);

                reportDocument = new ReportDocument();
                reportDocument.Load(Application.StartupPath + @"\relatorio\cGraficoVendas.rpt");
                reportDocument.SetDataSource(dataTable);

                string sFiltro = "Data Inicial: " + datDataInicial.Value.ToString("dd/MM/yyyy");
                sFiltro += "; Data Final: " + datDataFinal.Value.ToString("dd/MM/yyyy");
                sFiltro += "; Campanha: " + sCampanha;
                sFiltro += "; Auditoria: " + comboAuditoria.Text.ToString();

                reportDocument.SetParameterValue("FILTRO", sFiltro);

                crystalReportViewer.ReportSource = reportDocument;
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

        private bool PodeGerar()
        {
            string sMensagem;
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataInicial.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "[Data Inicial] incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataFinal.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "[Data Final] incorreta.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool bSelecionado = false;
            foreach (object itemChecked in chlCampanha.CheckedItems)
            {
                bSelecionado = true;
            }
            if (bSelecionado == false)
            {
                MessageBox.Show("Selecione, pelo menos, uma Campanha.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void CarregarCampanhas(int iIDUsuario)
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

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fGraficoVendas_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
            CarregarStatusAuditoria();
            comboAuditoria.DropDownStyle = ComboBoxStyle.DropDownList;

            /*Se tiver testando o sistema*/
            //if (usuarioCTL.bTestandoSistema)
            //{
            //    datDataInicial.Value = DateTime.Now.AddMonths(-4);

            //    for (int i = 0; i < this.chlCampanha.Items.Count; ++i)
            //        this.chlCampanha.SetItemChecked(i, true);

            //    GerarRelatorio();
            //}
            /*Se tiver testando o sistema*/
        }

        private void fGraficoVendas_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void fGraficoVendas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                reportDocument.Close();
            }
            catch { }
        }
    }
}