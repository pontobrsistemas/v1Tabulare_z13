using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;

namespace tabulare.relatorio
{
    public partial class fExportarMailing : Form
    {
        public fExportarMailing()
        {
            InitializeComponent();
        }

        private void GerarRelatorio()
        {
            try
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                string sIDStatus = "";
                if (chlStatus.Items.Count != chlStatus.CheckedItems.Count)
                {
                    foreach (object itemChecked in chlStatus.CheckedItems)
                    {
                        if (sIDStatus != "")
                            sIDStatus += ", ";

                        sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-", 1) - 1);
                    }
                }

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarExportacaoMailing(iIDCampanha, iIDMailing, sIDStatus);

                dgDados.DataSource = dataTable;
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

            lblRegistros.Text = dgDados.RowCount.ToString() + " registro(s)";
        }

        private bool PodeGerar()
        {
            string sMensagem;            
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione uma [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            if (comboMailing.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione um [Mailing].";
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
            CMailing.PreencherComboBox_MailingsAtivos(comboMailing, iIDCampanha, iAtivo, false, true, false);
        }      

        private void fContatosTrabalhados_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregarCampanhasAtivas(fLogin.Usuario.IDUsuario);

            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            if (comboCampanha.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                if (iIDCampanha != -1)
                {
                    CarregarMailing(iIDCampanha, Convert.ToInt32(chkListarAtivos.Checked));
                    comboMailing.DropDownStyle = ComboBoxStyle.DropDownList;

                    lblRegistrosCombo.Text = comboMailing.SelectedIndex.ToString() + " registro(s)";

                    CarregarStatus(iIDCampanha);
                    for (int i = 0; i < this.chlStatus.Items.Count; ++i)
                        this.chlStatus.SetItemChecked(i, true);
                }
            }
        }

        private void CarregarStatus(int iIDCampanha)
        {
            statusCTL CStatus = new statusCTL();
            CStatus.PreencherCheckListBox_DescricaoStatus(chlStatus, iIDCampanha);
        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {
            if (PodeGerar())
                ExportarRelatorio();  
        }

        private void ExportarRelatorio()
        {
            try
            {
                int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
                int iIDMailing = Convert.ToInt32(comboMailing.SelectedValue);
                string sIDStatus = "";
                if (chlStatus.Items.Count != chlStatus.CheckedItems.Count)
                {
                    foreach (object itemChecked in chlStatus.CheckedItems)
                    {
                        if (sIDStatus != "")
                            sIDStatus += ", ";

                        sIDStatus += itemChecked.ToString().Substring(0, 1) != "-" ? itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-") - 1) : itemChecked.ToString().Substring(0, itemChecked.ToString().IndexOf("-", 1) - 1);
                    }
                }

                relatorioCTL CRelatorio = new relatorioCTL();
                DataTable dataTable = CRelatorio.RetornarExportacaoMailing(iIDCampanha, iIDMailing, sIDStatus);

                string sEnderecoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare - ExportacaoMailing.xls";
                dataTable.TableName = "Tabulare";
                dataTable.WriteXml(sEnderecoArquivo, System.Data.XmlWriteMode.IgnoreSchema);

                MessageBox.Show("Dados exportados com sucesso!\n\nO arquivo encontra-se na Área de Trabalho.", "Tabulare");
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

        private void fExportarMailing_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
    }
}