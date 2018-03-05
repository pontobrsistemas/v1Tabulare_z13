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
    public partial class fRespostasScriptSintetico : Form
    {
        private ReportDocument reportDocument;
        
        public fRespostasScriptSintetico()
        {
            InitializeComponent();
        }

        private void fRespostasScript_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhasAtivas(fLogin.Usuario.IDUsuario);
            CarregarOperadores();

            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        private void GerarRelatorio()
        {
            try
            {
                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy"));
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " 23:59:59";
                int iIDUsuario = Convert.ToInt32(comboOperador.SelectedValue);
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);

                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarRespostasScript(sDataInicial, sDataFinal, iIDUsuario, -1, iIDCampanha, iIDMailing, iIDTipoAtendimento);
                
                reportDocument = new ReportDocument();
                reportDocument.Load(Application.StartupPath + @"\relatorio\cRespostasScriptSintetico.rpt");                
                reportDocument.SetDataSource(dataTable);

                string sFiltro = "Data Inicial: " + datDataInicial.Value.ToString("dd/MM/yyyy");
                sFiltro += "; Data Final: " + datDataFinal.Value.ToString("dd/MM/yyyy");
                sFiltro += "; Operador: " + comboOperador.Text.ToString();
                sFiltro += "; Campanha: " + comboCampanha.Text.ToString();

                reportDocument.SetParameterValue("FILTRO", sFiltro);

                crystalReportViewer.ReportSource = reportDocument;
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void fRespostasScript_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                reportDocument.Close();
            }
            catch { }
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
                MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataFinal.Value.ToString("dd/MM/yyyy")))
            {
                sMensagem = "[Data Final] incorreta.";
                MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione uma [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void CarregarCampanhasAtivas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void CarregarMailing(int iIDCampanha, int iAtivo)
        {
            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_MailingsAtivos(comboMailing, iIDCampanha, iAtivo, true, false, false);
        }

        private void CarregarOperadores()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperador);
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
                CarregarMailing(Convert.ToInt32(comboCampanha.SelectedValue.ToString()), 0);
                comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fRespostasScriptSintetico_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}