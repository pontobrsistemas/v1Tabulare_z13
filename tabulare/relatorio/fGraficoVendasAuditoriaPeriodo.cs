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
    public partial class fGraficoVendasAuditoriaPeriodo : Form
    {
        private ReportDocument reportDocument;

        public fGraficoVendasAuditoriaPeriodo()
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

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarVendasAuditoria(sDataInicial, sDataFinal, sIDCampanhas);

                reportDocument = new ReportDocument();
                reportDocument.Load(Application.StartupPath + @"\relatorio\cGraficoVendasAuditoriaPeriodo.rpt");
                reportDocument.SetDataSource(dataTable);

                string sFiltro = "Data Inicial: " + datDataInicial.Value.ToString("dd/MM/yyyy");
                sFiltro += "; Data Final: " + datDataFinal.Value.ToString("dd/MM/yyyy");
                sFiltro += "; Campanha: " + sCampanha;

                reportDocument.SetParameterValue("FILTRO", sFiltro);

                crystalReportViewer.ReportSource = reportDocument;
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
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

        private void fGraficoVendasAuditoriaPeriodo_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);

            /*Se tiver testando o sistema*/
            if (usuarioCTL.bTestandoSistema)
            {
                datDataInicial.Value = DateTime.Now.AddMonths(-4);

                for (int i = 0; i < this.chlCampanha.Items.Count; ++i)
                    this.chlCampanha.SetItemChecked(i, true);

                GerarRelatorio();
            }
            /*Se tiver testando o sistema*/
        }

        private void fGraficoVendasAuditoriaPeriodo_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void fGraficoVendasAuditoriaPeriodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                reportDocument.Close();
            }
            catch { }
        }
    }
}