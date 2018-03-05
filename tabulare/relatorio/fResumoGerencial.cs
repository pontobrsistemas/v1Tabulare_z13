using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using System.ServiceProcess;

namespace tabulare.relatorio
{
    public partial class fResumoGerencial : Form
    {
        public fResumoGerencial()
        {
            InitializeComponent();
        }

        private void CarregarRelatorios()
        {
            ValidarLicencaNumeroOperadores2();
            RetornarTopSemanal();
            Invoke((MethodInvoker)delegate { lblData.Text = "GERADO EM: " + DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss"); });

            //Número de usuários por Campanha
            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable;

            dataTable = CRelatorio.RetornarOperadoresCampanha();
            Invoke((MethodInvoker)delegate { gridOperadores.DataSource = dataTable; });

            //Número de Tabulações e Vendas Mensal por Campanha
            dataTable = CRelatorio.RetornarTabulacoesVendasMensal();
            Invoke((MethodInvoker)delegate { gridTrabalhados.DataSource = dataTable; });

            //Prospects disponíveis
            dataTable = CRelatorio.RetornarProspectsDisponiveis();
            Invoke((MethodInvoker)delegate { gridProspectDisponivel.DataSource = dataTable; });
        }

        private void fResumoGerencial_Load(object sender, EventArgs e)
        {
            rad3.Checked = true;
            backgroundWorker_CRelatorio.RunWorkerAsync();
        }

        private void cmdAtualizar_Click(object sender, EventArgs e)
        {
            if (backgroundWorker_CRelatorio.IsBusy == true)
            {
            }
            else
                backgroundWorker_CRelatorio.RunWorkerAsync();
        }

        private void timerAtualizacao_Tick(object sender, EventArgs e)
        {
            //3 Minutos
            if (rad3.Checked == true)
            {
                if (backgroundWorker_CRelatorio.IsBusy == true)
                {
                }
                else
                {
                    backgroundWorker_CRelatorio.RunWorkerAsync();
                }
            }

            //5 Minutos
            if (rad5.Checked == true)
            {
                if (backgroundWorker_CRelatorio.IsBusy == true)
                {
                }
                else
                {
                    backgroundWorker_CRelatorio.RunWorkerAsync();
                }
            }
            
            //10 Minutos
            if (rad10.Checked == true)
            {
                if (backgroundWorker_CRelatorio.IsBusy == true)
                {
                }
                else
                {
                    backgroundWorker_CRelatorio.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker_CRelatorio_DoWork(object sender, DoWorkEventArgs e)
        {
            CarregarRelatorios();
        }

        private void RetornarTopSemanal()
        {
            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = CRelatorio.RetornarTopSemanal(fLogin.Usuario.IDCampanha);
            Invoke((MethodInvoker)delegate { lblTop.Text = ""; });

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Invoke((MethodInvoker)delegate { lblTop.Text += dataRow["Operador"].ToString() + " - " + dataRow["Quant. Vendas"].ToString() + "\n"; });
            }
        }

        private void ValidarLicencaNumeroOperadores2()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            Invoke((MethodInvoker)delegate { lblQuantidadeAtual.Text = Convert.ToString(CUsuario.RetornarQuantidadeOperadores()); });
            Invoke((MethodInvoker)delegate { lblOperadorLicenca.Text = Convert.ToString(fLogin.iNumeroOperadores); });
            Invoke((MethodInvoker)delegate { lblVersao.Text = Convert.ToString(fLogin.sVersaoAplicativo); });
            Invoke((MethodInvoker)delegate { lblRelease.Text = Convert.ToString(fLogin.sRelease); });

            if (CUsuario.RetornarQuantidadeOperadores() > fLogin.iNumeroOperadores)
            {
                Invoke((MethodInvoker)delegate { lblAlerta.Text = "[Sua licença execedeu o limite de usuários.]"; });
                lblAlerta.ForeColor = Color.Red;
                lblQuantidadeAtual.ForeColor = Color.Red;
            }
        }

        private void rad3_CheckedChanged(object sender, EventArgs e)
        {
            if (rad3.Checked == true)
            {
                timerAtualizacao.Interval = 180000;
                timerAtualizacao.Enabled = true;
            }
            else
            {
                timerAtualizacao.Enabled = false;
            }
        }

        private void rad5_CheckedChanged(object sender, EventArgs e)
        {
            if (rad5.Checked == true)
            {
                timerAtualizacao.Interval = 300000;
                timerAtualizacao.Enabled = true;
            }
            else
            {
                timerAtualizacao.Enabled = false;
            }
        }

        private void rad10_CheckedChanged(object sender, EventArgs e)
        {
            if (rad10.Checked == true)
            {
                timerAtualizacao.Interval = 600000;
                timerAtualizacao.Enabled = true;
            }
            else
            {
                timerAtualizacao.Enabled = false;
            }
        }

        private void fResumoGerencial_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void cmdReativarRoboPreditivo_Click(object sender, EventArgs e)
        {
           // Get all instances of Notepad running on the specifiec
            // computer.
            // 1. Using the computer alias (do not precede with "\\").
            System.Diagnostics.Process[] remoteByName = System.Diagnostics.Process.GetProcessesByName(txtCaminhoServidor.Text.ToString(),txtNomeServidor.Text.ToString());
            remoteByName.ToString();

            // 2. Using an IP address to specify the machineName parameter. 
            System.Diagnostics.Process[] ipByName = System.Diagnostics.Process.GetProcessesByName(txtCaminhoServidor.Text.ToString(), txtIPServidor.Text.ToString());
            ipByName.ToString();

            // Get all processes running on the remote computer.
            System.Diagnostics.Process[] remoteAll = System.Diagnostics.Process.GetProcesses(txtNomeServidor.Text.ToString());
            remoteAll.ToString();

            campanhaCTL CCampanha = new campanhaCTL();
            string sIDCampanhas;
            string sCodFilaCampanha;
            string sPrimeiroNomeCampanha;
            foreach (object itemChecked in chlFilas.CheckedItems)
            {
                string sitemChecked = itemChecked.ToString();
                string[] ItemChecked = sitemChecked.Split('-');

                sIDCampanhas = Convert.ToString(CCampanha.RetornarIDCampanhaPreditivo(ItemChecked[1].Trim().ToString()));
                sPrimeiroNomeCampanha = ItemChecked[0].Trim().ToString();
                sCodFilaCampanha = ItemChecked[1].Trim().ToString();

                if (remoteByName.ToString() != "v1Tabulare_z13_Preditivo.exe" && ipByName.ToString() != "v1Tabulare_z13_Preditivo.exe" && remoteAll.ToString() != "v1Tabulare_z13_Preditivo.exe")
                {
                    string sAtivar = sPrimeiroNomeCampanha+';'+sCodFilaCampanha;
                    System.Diagnostics.Process.Start(txtCaminhoServidor.Text.ToString(), sAtivar);
                }
            }
        }

        #region CarregarCampanhasCheckBoxList()
        private void CarregarCampanhasCheckBoxList()
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherCheckListBox_CampanhasAtivasFilas(chlFilas);
        }
        #endregion
    }
}
    

