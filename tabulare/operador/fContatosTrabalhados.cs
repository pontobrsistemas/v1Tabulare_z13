using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace tabulare.operador
{
    public partial class fContatosTrabalhados : Form
    {
        private ReportDocument reportDocument;

        public fContatosTrabalhados()
        {
            InitializeComponent();
        }

        private void CarregarLayout()
        {
            this.BackColor = System.Drawing.Color.FromName("White");
            this.ControlBox = false;

            string sFormulario = "TABULARE - CONTATOS TRABALHADOS";
            this.Text = sFormulario + " - " + fLogin.sVersaoAplicativo + " (" + fLogin.sRelease + ")";
        }

        private void fContatosTrabalhados_Load(object sender, EventArgs e)
        {
            CarregarLayout();
            GerarRelatorio();
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GerarRelatorio()
        {

            if (PodeGerar())
            {
                try
                {
                    string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                    string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy"));

                    relatorioCTL CRelatorio = new relatorioCTL();
                    DataTable dataTable = CRelatorio.RetornarContatosTrabalhadosOperador(fLogin.Usuario.IDUsuario, sDataInicial, sDataFinal);

                    reportDocument = new ReportDocument();
                    reportDocument.Load(Application.StartupPath + @"\relatorio\cContatosTrabalhadosOperador.rpt");
                    reportDocument.SetDataSource(dataTable);

                    reportDocument.SetParameterValue("OPERADOR", fLogin.Usuario.Nome.ToUpper());

                    crystalReportViewer.ReportSource = reportDocument;
                    crystalReportViewer.Zoom(80);
                }
                catch (Exception ex)
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
                }
            }
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

            return true;
        }

        private void datDataInicial_ValueChanged(object sender, EventArgs e)
        {
            //GerarRelatorio();
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            if (PodeGerar())
                GerarRelatorio();
        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {
            ExportarRelatorio();
        }

        private void ExportarRelatorio()
        {
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy"));

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarContatosTrabalhadosOperador(fLogin.Usuario.IDUsuario, sDataInicial, sDataFinal);

                reportDocument = new ReportDocument();
                reportDocument.Load(Application.StartupPath + @"\relatorio\cContatosTrabalhadosOperador.rpt");
                reportDocument.SetDataSource(dataTable);

                reportDocument.SetParameterValue("OPERADOR", fLogin.Usuario.Nome.ToUpper());

                crystalReportViewer.ReportSource = reportDocument;
                crystalReportViewer.Zoom(80);

                string sEnderecoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare - Contatos_Trabalhados_Operador.xls";
                dataTable.TableName = "Tabulare";
                dataTable.WriteXml(sEnderecoArquivo);

                MessageBox.Show("Dados exportados com sucesso!\n\nO arquivo encontra-se na Área de Trabalho.", "Tabulare");

            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }
    }
}