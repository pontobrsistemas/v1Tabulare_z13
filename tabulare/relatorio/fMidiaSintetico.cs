using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using CrystalDecisions.CrystalReports.Engine;
using model.objetos;

namespace tabulare.relatorio
{
    public partial class fMidia : Form
    {
        private ReportDocument reportDocument; 
        
        public fMidia()
        {
            InitializeComponent();
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

        private bool PodeGerar()
        {
            string sMensagem;
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataInicial.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "[Data Inicial] incorreta.";
                MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                MessageBox.Show("Selecione, pelo menos, uma Campanha.", "Tabulare");
                return false;
            }
            return true;
        }

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherCheckListBox_CampanhasAtivas(chlCampanha, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void fMidia_Load(object sender, EventArgs e)
        {
            usuario Usuario = new usuario();

            this.ShowIcon = false;
            this.MaximizeBox = true;
            this.MinimizeBox = false;

            CarregarCampanhas(fLogin.Usuario.IDUsuario);
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            if (PodeGerar())
                GerarRelatorio();
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
                DataTable dataTable = CRelatorio.RetornarMidiasSintetico(sDataInicial, sDataFinal, sIDCampanhas).Tables[0];

                reportDocument = new ReportDocument();
                
                if (chkAgrupadoStatus.Checked == true)                
                    reportDocument.Load(Application.StartupPath + @"\relatorio\cMidias_Status.rpt");
                else
                    reportDocument.Load(Application.StartupPath + @"\relatorio\cMidiasSintetico.rpt");

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

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }        

        private void fMidia_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
