using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using System.IO;
using System.Diagnostics;

namespace tabulare
{
    public partial class fAdministrador : Form
    {
        private static Form formAtivo;

        public fAdministrador()
        {
            InitializeComponent();            
        }

        private void CarregarInfoUsuario()
        {
            try
            {
                if (fLogin.Usuario != null)
                {
                    string sUsuario = fLogin.Usuario.Nome.ToUpper();
                    if (sUsuario.Length > 35)
                        sUsuario = sUsuario.Substring(0, 35);
                    lblUsuario.Text = sUsuario;
                    lblLogin.Text = fLogin.Usuario.Login.ToUpper();
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void CarregarLayout()
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.FromName("Gainsboro");
            this.ShowIcon = false;

            string sFormulario = "TABULARE - ADMINISTRADOR";
            this.Text = sFormulario + " - " + fLogin.sVersaoAplicativo + " (" + fLogin.sRelease + ")";

            foreach (Control control in this.Controls)
            {
                if (control is MdiClient)
                {
                    control.BackColor = Color.White;
                    break;
                }
            }
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            Button myButton = (Button)sender;
            string nomeFormulario = myButton.Parent.Parent.Name;

            if (MessageBox.Show("Deseja realmente fechar o Tabulare Software?", "Tabulare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }        

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fUsuario());
        }

        public static void ExibirForm(Form form)
        {
            form.MdiParent = tabulare.fAdministrador.ActiveForm;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void mailingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fMailing());
        }

        private void campanhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fCampanha());
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fStatus());
        }

        private void fSupervisor_Load(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(1135, 4);
            CarregarLayout();
            CarregarInfoUsuario();
            ConfigurarFuncionalidesDoCliente();

            //ExibirForm(new relatorio.fResumoGerencial());

            //Verifica se há script de atendimento
            if (fLogin.Configuracao.Script == 1)
            {
                respostasDoScriptToolStripMenuItem.Visible = true;
                respostasDoScriptSintéticoToolStripMenuItem.Visible = true;
                toolStripSeparatorScript.Visible = true;
            }

            if (fLogin.Configuracao.TipoPabx != "Vonix")
                enviarProspectsParaPreditivoToolStripMenuItem.Enabled = false;

            //Dashboard
            ExibirForm(new dashboard());
            lblModulo.Text = "Módulo Supervisor - Dashboard";
        }

        //Determinados clientes tem particularidades que são configuradas nessa função
        private void ConfigurarFuncionalidesDoCliente()
        {
            //Callflex Mundiale Níveis de acesso
            if (fLogin.Configuracao.TipoPabx == "Callflex")
            {
                if (fLogin.Usuario.IDPerfil == 5)
                {
                    enviarProspectsParaPreditivoToolStripMenuItem.Visible = false;
                    gráficoToolStripMenuItem.Visible = true;
                }
            }
        }

        private void statusMailingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fStatusMailing());
        }

        private void respostasDoScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fRespostasScriptDetalhado());
        }

        private void respostasDoScriptSintéticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fRespostasScriptSintetico());
        }

        private void contatosTrabalhadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fContatosTrabalhadosDetalhado());
        }

        private void contatosTrabalhadosSintéticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fContatosTrabalhadosSintetico());
        }

        private void bloqueioDeDDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fBloqueioDDD());
        }

        private void statusProspectPorDDDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fStatusProspectPorDDD());
        }

        private void resubmitMailingStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fResubmitMailing());
        }

        private void vendaDetalhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fVendasSintetico());
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fConsultarCliente());
        }

        private void dadosDaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fDadosVenda());
        }        

        private void exportaçãoDeMailingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fExportarMailing());
        }

        private void enviarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fPermitirEnvioEmail());
        }       

        private void dadosDaMidiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new tabulare.relatorio.fMidia());
        }

        private void auditarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fBackofficeVenda_filtro());
        }

        private void mainlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fMailingIndicacao());
        }

        private void tabulareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new fSobre();
            form.Show();
        }

        private void configuraçãoDeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fConfiguracaoEmail());
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExibirForm(new tabulare.relatorio.fMidiaDetalhado());
        }

        private void enviarProspectsParaPreditivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fEnviarPreditivo());
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fGraficoVendas());
        }

        private void contatosRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fGraficoContatosTrabalhados());
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new admin.fCampos());
        }

        private void blacklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fBlackList());
        }

        private void fAdministrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Liberar venda em uso pelo backoffice
            prospectCTL CProspect = new prospectCTL();
            if (fLogin.Usuario.Perfil != "Operador")
                CProspect.PegarVendaParaAuditarBackoffice(supervisor.fBackofficeVenda_detalhe.iIDHistorico, -1);
        }

        private void statusDaAuditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fStatusAuditoria());
        }
    }
}