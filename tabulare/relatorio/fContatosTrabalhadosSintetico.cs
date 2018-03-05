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
    public partial class fContatosTrabalhadosSintetico : Form
    {
        private ReportDocument reportDocument;

        public fContatosTrabalhadosSintetico() 
        {
            InitializeComponent();
        }

        private void GerarRelatorio()
        {
            try
            {
                string sHoraInicial = "";
                string sHoraFinal = "23:59:59";

                if (comboHoraInicial.Text != "") sHoraInicial = comboHoraInicial.Text.ToString() + ":00";
                if (comboHoraFinal.Text != "") sHoraFinal = comboHoraFinal.Text.ToString() + ":00";

                string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Value.ToString("dd/MM/yyyy")) + " " + sHoraInicial;
                string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Value.ToString("dd/MM/yyyy")) + " " + sHoraFinal;
                int iIDUsuario = Convert.ToInt32(comboOperador.SelectedValue);
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                int iAposUltimoResubmit = chkUltimoResubmit.Checked ? 1 : 0;

                int iIDTipoAtendimento = -1;
                if (radAtivo.Checked == true)
                    iIDTipoAtendimento = 1;
                else if (radReceptivo.Checked == true)
                    iIDTipoAtendimento = 2;

                string sIDStatus = "";

                foreach (object itemChecked in chlStatus.CheckedItems)
                {
                    if (sIDStatus != "")
                        sIDStatus += ", ";

                    sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-",1) - 1);                    
                }

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarContatosTrabalhadosSintetico(sDataInicial, sDataFinal, iIDUsuario, iIDCampanha, iIDMailing, iIDTipoAtendimento, sIDStatus, iAposUltimoResubmit).Tables[0];
                
                reportDocument = new ReportDocument();
                
                if (chkAgrupadoOperador.Checked == true)
                    reportDocument.Load(Application.StartupPath + @"\relatorio\cContatosTrabalhadosSintetico_Operador.rpt");                
                else
                    reportDocument.Load(Application.StartupPath + @"\relatorio\cContatosTrabalhadosSintetico_Total.rpt");                
                
                reportDocument.SetDataSource(dataTable);

                string sFiltro = "Data Inicial: " + datDataInicial.Value.ToString("dd/MM/yyyy") + " " + sHoraInicial;
                sFiltro += "; Data Final: " + datDataFinal.Value.ToString("dd/MM/yyyy") + " " + sHoraFinal;
                sFiltro += "; Operador: " + comboOperador.Text.ToString();
                sFiltro += "; Campanha: " + comboCampanha.Text.ToString();
                if (chkUltimoResubmit.Checked)
                    sFiltro += "; Retornar apenas os contatos depois do último Resubmit";

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

        private void CarregarMailing(int iIDCampanha)
        {
            try
            {
                comboMailing.Items.Clear();
            }
            catch { }

            mailingCTL CMailing = new mailingCTL();
            CMailing.PreencherComboBox_Mailings(comboMailing, iIDCampanha, Convert.ToBoolean(chkListarAtivos.Checked), true, false);
        }

        private void CarregarOperadores()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperador);
        }

        private void CarregarStatusSitentico(int iIDCampanha)
        {
            statusCTL CStatus = new statusCTL();
            CStatus.PreencherCheckListBox_DescricaoStatus(chlStatus, iIDCampanha);
        }

        private void fContatosTrabalhados_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhasAtivas(fLogin.Usuario.IDUsuario);
            CarregarOperadores();
            chlStatus.Items.Clear();
            comboCampanha.Focus();

            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            comboHoraInicial.DropDownStyle = ComboBoxStyle.DropDownList;
            comboHoraFinal.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void fContatosTrabalhados_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                reportDocument.Close();
            }
            catch { }
        }        

        private void cmdMarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chlStatus.Items.Count; ++i)
                this.chlStatus.SetItemChecked(i, true);
        }

        private void cmdDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chlStatus.Items.Count; ++i)
                this.chlStatus.SetItemChecked(i, false);
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chlStatus.Items.Clear();
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                if (iIDCampanha != -1)
                {
                    CarregarMailing(iIDCampanha);

                    CarregarStatusSitentico(iIDCampanha);
                    comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;

                    for (int i = 0; i < this.chlStatus.Items.Count; ++i)
                        this.chlStatus.SetItemChecked(i, true);
                }
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }       

        private void fContatosTrabalhadosSintetico_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void chkListarAtivos_CheckedChanged(object sender, EventArgs e)
        {
            int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
            if (iIDCampanha != -1)
            {
                CarregarMailing(iIDCampanha);

                CarregarStatusSitentico(iIDCampanha);
                comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }
}