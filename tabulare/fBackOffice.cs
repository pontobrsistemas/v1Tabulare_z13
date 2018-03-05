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
using System.Collections;

namespace tabulare
{
    public partial class fBackOffice : Form
    {
        private static Form formAtivo;
                
        public fBackOffice()
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

            string sFormulario = "TABULARE - BACKOFFICE";
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

        private void usu�rioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fUsuario());
            lblModulo.Text = "M�dulo Backoffice - Usu�rio";
        }

        public static void ExibirForm(Form form)
        {
            form.MdiParent = tabulare.fBackOffice.ActiveForm;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void mailingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fMailing());
            lblModulo.Text = "M�dulo Backoffice - Mailing";
        }

        private void campanhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fCampanha());
            lblModulo.Text = "M�dulo Backoffice - Campanha";
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fStatus());
            lblModulo.Text = "M�dulo Backoffice - Status";
        }

        private void fSupervisor_Load(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(1135, 4);
            CarregarLayout();
            CarregarInfoUsuario();

            //Verifica se h� script de atendimento
            if (fLogin.Configuracao.Script == 1)
            {
                respostasDoScriptToolStripMenuItem.Visible = true;
                respostasDoScriptSint�ticoToolStripMenuItem.Visible = true;
                toolStripSeparatorScript.Visible = true;
            }

            if (fLogin.Configuracao.TipoPabx != "Vonix")
                enviarProspectsParaPreditivoToolStripMenuItem.Enabled = false;

            timerTratamentoVenda.Enabled = true;

            //Dashboard
            ExibirForm(new dashboard());
            lblModulo.Text = "M�dulo Supervisor - Dashboard";
        }       

        private void statusMailingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fStatusMailing());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio Status Mailing";
        }

        private void respostasDoScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fRespostasScriptDetalhado());
        }

        private void respostasDoScriptSint�ticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fRespostasScriptSintetico());
        }

        private void contatosTrabalhadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fContatosTrabalhadosDetalhado());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio Contatos Trabalhados (Detalhado)";
        }

        private void contatosTrabalhadosSint�ticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fContatosTrabalhadosSintetico());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio Contatos Trabalhados (Sint�tico)";
        }

        private void bloqueioDeDDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fBloqueioDDD());
            lblModulo.Text = "M�dulo Backoffice - Bloqueio de DDD";
        }

        private void statusProspectPorDDDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fStatusProspectPorDDD());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio Status Prospect/Mailing por DDD";
        }

        private void resubmitMailingStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fResubmitMailing());
            lblModulo.Text = "M�dulo Backoffice - Resubmit Mailing";
        }

        private void vendaDetalhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fVendasSintetico());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio Vendas (Sint�tico)";
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fConsultarCliente());
            lblModulo.Text = "M�dulo Backoffice - Consultar Cliente";
        }

        private void dadosDaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fDadosVenda());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio Dados da Venda";
        }        

        private void exporta��oDeMailingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fExportarMailing());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio Exportar de Mailing";
        }

        private void enviarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fPermitirEnvioEmail());
        }

        private void dadosDaMidiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new tabulare.relatorio.fMidia());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio de M�dia (Sint�tico)";
        }

        private void auditarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fBackofficeVenda_filtro());
            lblModulo.Text = "M�dulo Backoffice";
        }

        private void mainlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fMailingIndicacao());
            lblModulo.Text = "M�dulo Backoffice - Mailing Indica��o";
        }

        private void tabulareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new fSobre();
            form.Show();
        }

        private void configura��oDeEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fConfiguracaoEmail());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExibirForm(new tabulare.relatorio.fMidiaDetalhado());
            lblModulo.Text = "M�dulo Backoffice - Relat�rio de M�dia (Detalhado)";
        }

        private void enviarProspectsParaPreditivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fEnviarPreditivo());
            lblModulo.Text = "M�dulo Backoffice - Enviar Prospect para Preditivo";
        }        

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fGraficoVendas());
            lblModulo.Text = "M�dulo Backoffice - Gr�fico de Vendas";
        }

        private void contatosRealizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fGraficoContatosTrabalhados());
            lblModulo.Text = "M�dulo Backoffice - Gr�fico Contatos Trabalhados";
        }

        private void blacklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fBlackList());
            lblModulo.Text = "M�dulo Backoffice - BlackList";
        }

        private void fBackOffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Liberar venda em uso pelo backoffice
            prospectCTL CProspect = new prospectCTL();
            if (fLogin.Usuario.Perfil != "Operador")
                CProspect.PegarVendaParaAuditarBackoffice(supervisor.fBackofficeVenda_detalhe.iIDHistorico, -1);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ExibirForm(new relatorio.fQuantitativoDadosVenda());
            lblModulo.Text = "M�dulo Backoffice - Quantitativo (Dados da Venda)";
        }
    }
}