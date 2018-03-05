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

namespace tabulare.relatorio
{
    public partial class fGraficoStatusMailing : Form
    {
        private ReportDocument reportDocument;

        public fGraficoStatusMailing()
        {
            InitializeComponent();
        }        

        private void fStatusMailing_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhasAtivas(fLogin.Usuario.IDUsuario);
            comboCampanha.Focus();
            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool PodeGerarDados()
        {
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Selecione uma [Campanha].", "Tabulare",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            if (comboMailing.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Selecione um [Mailing].", "Tabulare",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void CarregarMailings_DataCadastro()
        {
            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_Mailings_DataCadastro(comboMailing);
        }

        private void cmdGerar_Click(object sender, EventArgs e)
        {
            if (PodeGerarDados())
            {
                try
                {
                    int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
 
                    relatorioCTL CRelatorio = new relatorioCTL();
                    DataTable dataTable = CRelatorio.RetornarStatusMailing(iIDMailing);

                    reportDocument = new ReportDocument();
                    reportDocument.Load(Application.StartupPath + @"\relatorio\cGraficoStatusMailing.rpt");
                    reportDocument.SetDataSource(dataTable);

                    string sFiltro = "Mailing: " + comboMailing.Text.ToString();
                    sFiltro += "; Campanha: " + comboCampanha.Text.ToString();

                    reportDocument.SetParameterValue("FILTRO", sFiltro);

                    crystalReportViewer.ReportSource = reportDocument;

                    //Verifica se tem DDD bloqueado para a Campanha selecionada
                    prospectCTL CProspect = new prospectCTL();
                    dataTable = CProspect.RetornarBloqueiosDDD(Convert.ToInt32(comboCampanha.SelectedValue));
                    string sDDD = "";
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (sDDD != "")
                            sDDD += ", " + dataRow["DDD"].ToString();
                        else
                            sDDD = dataRow["DDD"].ToString();
                    }
                    if (sDDD != "")
                    {
                        string sMensagem = "O(s) DDD(s) " + sDDD + " está(ão) bloqueado(s) para a Campanha selecionada.";
                        PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(sMensagem, "Tabulare");
                    } 
                }
                catch (Exception ex)
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
                }
            }
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
                CarregarMailing(Convert.ToInt32(comboCampanha.SelectedValue.ToString()), Convert.ToInt32(chkListarAtivos.Checked));
                comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;

                lblRegistrosCombo.Text = comboMailing.SelectedIndex.ToString() + " registro(s)";
        }

        private void CarregarMailing(int iIDCampanha, int iAtivo)
        {
            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_MailingsAtivos(comboMailing, iIDCampanha,iAtivo, false, true, false);
        }

        private void CarregarCampanhasAtivas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fStatusMailing_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        
    }
}