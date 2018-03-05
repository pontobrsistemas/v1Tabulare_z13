using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms; 
using controller;
using model.objetos;
using v1Tabulare_z13.PlanetFone;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Xml;
using System.Net.NetworkInformation;

namespace tabulare.operador
{
    #region Variáveis
    public partial class fAtendimento : Form
    {
        private const string STATUS_DISCANDO = "STATUS_DISCANDO";
        private const string STATUS_DESCONECTADO_COM_PROSPECT = "STATUS_DESCONECTADO_COM_PROSPECT";
        private const string STATUS_DESCONECTADO_SEM_PROSPECT = "STATUS_DESCONECTADO_SEM_PROSPECT";
        private const string STATUS_CTI_DESATIVADO_COM_PROSPECT = "STATUS_CTI_DESATIVADO_COM_PROSPECT";
        private const string STATUS_CTI_DESATIVADO_SEM_PROSPECT = "STATUS_CTI_DESATIVADO_SEM_PROSPECT";
        private const string STATUS_CONECTADO_COM_PROSPECT = "STATUS_CONECTADO_COM_PROSPECT";
        private const string STATUS_SOLICITANDO_DISCAGEM = "STATUS_SOLICITANDO_DISCAGEM";

        public static int iIDUsuarioAgendamento;
        public static int iIDStatusAgendamento;
        public static int iIDAcaoAgendamento;
        public static int iIDProspectAgendamento;

        public static string sUsuarioAgendamento;
        public static string sAcao;

        public static string sCampanha;
        private static prospect Prospect;
        private static DataTable dataRespostas;
        private static string sHoraAgendamento;
        private static string sStatusFormulario;
        private string sRamal = new string(' ', 200);
        private static byte[] buff1 = new byte[200];
        private static byte[] buff2 = new byte[200];
        private static byte[] buff3 = new byte[200];
        public static int iIDResposta;
        public static int iVenda;
        public static int iIDHistorico;
        public string SsMensagem;

        //Variáveis Leucotron
        private TcpClient ClientTCP;
        private NetworkStream stream;
        byte[] m_dataBufferLeucotron = new byte[10];

        //Variavél DataAbertura na tHistórico
        private string sDataAbertura;

        //Variaveis de retorno do metodo "DiscaResultado"
        private string sIdLigacao;

        private static bool Indicacao = false;
        private static bool Venda = false;
        private static string sPortaModem = "COM3";
        private static string sOperadora;
        delegate void SetTextCallback(string text);
        private static ArrayList arrayList;
        private static status Status = new status();
        private wenvpabx2 wss;
        public static int NroAgente;
        public static string CodFila;
        public static string NomedoAgente;

        // Variáveis do Socket Client                                                                                
        private string sParametroRecebido = "";
        byte[] m_dataBuffer = new byte[10];
        IAsyncResult m_result;
        public AsyncCallback m_pfnCallBack;
        public Socket m_clientSocket;
        private static int Reconectar = 0;
        // Variáveis do Socket Client                                                                                

        // Variáveis Vonix                                                                                            
        public string IDStatus { get; set; }
        public string IDProspect { get; set; }
        public string IDCausaDesligamento { get; set; }
        public int ID { get; set; }
        // Variáveis Vonix  
        private bool prefixSeen;

        public TabPage page;

        //Variaveis que retorno da pesquisa de telefones dos contatos receptivos
        private double dTelefone1 = 0;
        private double dTelefone2 = 0;
        private double dTelefone3 = 0;

        #region Variáveis Digitar
        private string sComandoPabxDigistar = "";
        private string sComandoDigistar = "";
        private System.Net.Sockets.TcpClient socketDigistar;
        private System.IO.BinaryReader dataInputStream;
        private System.IO.BinaryWriter dataOutputStream;

        byte[] m_dataBufferDigistar = new byte[10];
        IAsyncResult ResultadoDigistar;
        public AsyncCallback RetornaChamadaDigistar;
        delegate void SetTextCallbackDigistar(string text);
        #endregion

        #region Variáveis VONIX

        //' Definido os metodos chamados no callback
        //' Esses metodos irao delegar as tarefas a outros metodos
        public delegate void cbConnect(
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbDial(
            [MarshalAs(UnmanagedType.BStr)] string CallId,
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            [MarshalAs(UnmanagedType.BStr)] string Agent,
            [MarshalAs(UnmanagedType.BStr)] string Queue,
            [MarshalAs(UnmanagedType.BStr)] string From,
            [MarshalAs(UnmanagedType.BStr)] string To,
            [MarshalAs(UnmanagedType.BStr)] string CallFilename,
            [MarshalAs(UnmanagedType.BStr)] string ContactName,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbDialFailure(
            [MarshalAs(UnmanagedType.BStr)] string CallId,
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            int CauseId,
            [MarshalAs(UnmanagedType.BStr)] string CauseDescription);

        public delegate void cbDialAnswer(
            [MarshalAs(UnmanagedType.BStr)] string CallId,
            [MarshalAs(UnmanagedType.BStr)] string strDate);

        public delegate void cbHangUp(
            [MarshalAs(UnmanagedType.BStr)] string CallId,
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            int CauseId,
            [MarshalAs(UnmanagedType.BStr)] string CauseDescription);

        public delegate void cbReceive(
            [MarshalAs(UnmanagedType.BStr)] string CallId,
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            [MarshalAs(UnmanagedType.BStr)] string Queue,
            [MarshalAs(UnmanagedType.BStr)] string From,
            [MarshalAs(UnmanagedType.BStr)] string To,
            [MarshalAs(UnmanagedType.BStr)] string CallFilename,
            [MarshalAs(UnmanagedType.BStr)] string ContactName,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbReceiveAnswer(
            [MarshalAs(UnmanagedType.BStr)] string CallId,
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            int WaitSeconds);

        public delegate void cbReceiveFailure(
            [MarshalAs(UnmanagedType.BStr)] string CallId,
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            int RingingSeconds);

        public delegate void cbLogin(
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            [MarshalAs(UnmanagedType.BStr)] string Location,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbLogoff(
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            [MarshalAs(UnmanagedType.BStr)] string Location,
            int Duration,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbPause(
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            int Reason,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbUnpause(
            [MarshalAs(UnmanagedType.BStr)] string strDate,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbError(
            [MarshalAs(UnmanagedType.BStr)] string ActionId,
            [MarshalAs(UnmanagedType.BStr)] string Message);

        public delegate void cbStatus(
            [MarshalAs(UnmanagedType.BStr)] string Status,
            [MarshalAs(UnmanagedType.BStr)] string Location,
            [MarshalAs(UnmanagedType.BStr)] string ActionId);

        public delegate void cbVersion(
            [MarshalAs(UnmanagedType.BStr)] string ActionId,
            [MarshalAs(UnmanagedType.BStr)] string Version);

        //' Declaração das funções da API Vonix.dll
        [DllImport("Vonix.dll")]
        public static extern void Connect(string ActionId, string Hostname, string AgentCode);

        [DllImport("Vonix.dll")]
        public static extern void Disconnect();

        [DllImport("Vonix.dll")]
        public static extern long FreeCallBacks();

        //' Declaração das ações
        [DllImport("Vonix.dll")]
        public static extern long doDial(string ActionId, string ToNumber, string ContactName, string QueueName, int BillingId);

        [DllImport("Vonix.dll")]
        public static extern void doTransfer(string ActionId, string CallId, string ToNumber);

        [DllImport("Vonix.dll")]
        public static extern void doHangUp(string ActionId, string CallId);

        [DllImport("Vonix.dll")]
        public static extern void doPause(string ActionId, int Reason);

        [DllImport("Vonix.dll")]
        public static extern void doUnpause(string ActionId);

        [DllImport("Vonix.dll")]
        public static extern void doLogin(string ActionId);

        [DllImport("Vonix.dll")]
        public static extern void doLogoff(string ActionId);

        [DllImport("Vonix.dll")]
        public static extern void doTag(string ActionId, string CallId, string TagName);

        [DllImport("Vonix.dll")]
        public static extern void doStatus(string ActionId, string QueueName);

        [DllImport("Vonix.dll")]
        public static extern void doVersion(string ActionId);

        //' Declaração dos metodos para registro dos callbacks
        //' Os registros serao feitos no metodo LoadCallBacks()
        [DllImport("Vonix.dll", EntryPoint = "onConnect")]
        public static extern long RegisterOnConnect(cbConnect callback);

        [DllImport("Vonix.dll", EntryPoint = "onDial")]
        public static extern long RegisterOnDial(cbDial callback);

        [DllImport("Vonix.dll", EntryPoint = "onDialAnswer")]
        public static extern long RegisterOnDialAnswer(cbDialAnswer callback);

        [DllImport("Vonix.dll", EntryPoint = "onDialFailure")]
        public static extern long RegisterOnDialFailure(cbDialFailure callback);

        [DllImport("Vonix.dll", EntryPoint = "onReceive")]
        public static extern long RegisterOnReceive(cbReceive callback);

        [DllImport("Vonix.dll", EntryPoint = "onReceiveAnswer")]
        public static extern long RegisterOnReceiveAnswer(cbReceiveAnswer callback);

        [DllImport("Vonix.dll", EntryPoint = "onReceiveFailure")]
        public static extern long RegisterOnReceiveFailure(cbReceiveFailure callback);

        [DllImport("Vonix.dll", EntryPoint = "onHangUp")]
        public static extern long RegisterOnHangUp(cbHangUp callback);

        [DllImport("Vonix.dll", EntryPoint = "onPause")]
        public static extern long RegisterOnPause(cbPause callback);

        [DllImport("Vonix.dll", EntryPoint = "onUnpause")]
        public static extern long RegisterOnUnpause(cbUnpause callback);

        [DllImport("Vonix.dll", EntryPoint = "onLogin")]
        public static extern long RegisterOnLogin(cbLogin callback);

        [DllImport("Vonix.dll", EntryPoint = "onLogoff")]
        public static extern long RegisterOnLogoff(cbLogoff callback);

        [DllImport("Vonix.dll", EntryPoint = "onStatus")]
        public static extern long RegisterOnStatus(cbStatus callback);

        [DllImport("Vonix.dll", EntryPoint = "onError")]
        public static extern long RegisterOnError(cbError callback);

        [DllImport("Vonix.dll", EntryPoint = "onVersion")]
        public static extern long RegisterOnVersion(cbVersion callback);

        private cbConnect myConnect;
        private cbDial myDial;
        private cbDialAnswer myDialAnswer;
        private cbDialFailure myDialFailure;
        private cbReceive myReceive;
        private cbReceiveAnswer myReceiveAnswer;
        private cbReceiveFailure myReceiveFailure;
        private cbHangUp myHangUp;
        private cbPause myPause;
        private cbUnpause myUnpause;
        private cbLogin myLogin;
        private cbLogoff myLogoff;
        private cbStatus myStatus;
        private cbError myError;
        private cbVersion myVersion;

        //Discalgem CallFlex #########################################
        private delegate void NewCallDelegate(String id, String tel);
        private static string StatusCallFlex;
        //############################################################

        #endregion

        public fAtendimento()
        {
            InitializeComponent();

            if (fLogin.Configuracao.TipoPabx == "Vonix")
                LoadCallBacks();
        }
    #endregion

        #region Configurar tipo discagem PABX
        private void ConfigurarTipoDiscagemPABX()
        {
            if (fLogin.Configuracao.TipoPabx == "Modem")
            {
                grpTelefonia.Height = 80;
                //comboCampanha.Location = new Point(1032, 59);
                //picCampanha.Location = new Point(1033, 41);
                //lblCampanha.Location = new Point(1051, 45);
                lblStatusConexao.Visible = false;
                txtStausConexao.Visible = false;
                lblTimerReconexão.Visible = false;
                txtTimerReconexao.Visible = false;

                chkDiscagemAutomatica.Visible = false;
                txtPorta.Visible = false;
                lblPorta.Visible = false;
                txtIP.Visible = false;
                lblIP.Visible = false;
            }
            else if (fLogin.Configuracao.TipoPabx == "PlanetFone")
            {
                try
                {
                    this.wss = ws.PlanetFone.getInstancia().getWS();

                    if (fLogin.Usuario.TipoDiscador != "Power")//Para não habilitar Socket a usuários fora do preditivo
                        IniciarConexao();
                }
                catch { }
            }
            else if (fLogin.Configuracao.TipoPabx == "Digistar")
            {
                grpTelefonia.Height = 80;
                //comboCampanha.Location = new Point(1032, 59);
                //picCampanha.Location = new Point(1033, 41);
                //lblCampanha.Location = new Point(1051, 45);
                lblStatusConexao.Visible = false;
                txtStausConexao.Visible = false;
                lblTimerReconexão.Visible = false;
                txtTimerReconexao.Visible = false;

                iniciarComunicacaoDigistar();
                chkDiscagemAutomatica.Visible = true;
            }
            else if (fLogin.Configuracao.TipoPabx == "Vonix")
            {
                try
                {
                    Connect("1", fLogin.Configuracao.IPServidor, fLogin.Usuario.Agente.ToString());
                    //doLogin("do_login");
                }
                catch { }

                grpTelefonia.Height = 80;
                //comboCampanha.Location = new Point(1032, 59);
                //picCampanha.Location = new Point(1033, 41);
                //lblCampanha.Location = new Point(1051, 45);
                lblStatusConexao.Visible = false;
                txtStausConexao.Visible = false;
                lblTimerReconexão.Visible = false;
                txtTimerReconexao.Visible = false;

                lblIP.Visible = false;
                lblPorta.Visible = false;
                txtIP.Visible = false;
                txtPorta.Visible = false;
                chkDiscagemAutomatica.Visible = false;
            }
        }
        #endregion

        #region Atendimento Load
        private void fAtendimento_Load(object sender, EventArgs e)
        {
            prospectCTL CProspect = new prospectCTL();
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CarregaCampanhasUsuario(fLogin.Usuario.IDUsuario);
            comboCampanha.SelectedIndex = 0;
            // timerTratamentoVenda.Enabled = true;

            fLogin.Usuario.IDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
            //RetornarMensagensTratamentoVenda(fLogin.Usuario.IDUsuario, fLogin.Usuario.Perfil);

            MontarDataTableResposta();

            AtualizarStatusFormulario(STATUS_DESCONECTADO_SEM_PROSPECT);
            CarregarStatus(fLogin.Usuario.IDCampanha);
            CarregarMidias();
            CarregarCamposCampanha(fLogin.Usuario.IDCampanha);
            RetornarOperadora(fLogin.Usuario.IDCampanha);

            sRamal = fLogin.Usuario.Ramal;
            txtNome.Focus();
            ConfigurarTipoDiscagemPABX();

            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMidia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboOperadorAgendamento.DropDownStyle = ComboBoxStyle.DropDownList;

            if (fLogin.Configuracao.TipoPabx == "PlanetFone")
            {
                if (fLogin.Usuario.TipoDiscador != "Power")
                {
                    cmdProximoProspect.Visible = false;
                    lblIP.Visible = true;
                    lblPorta.Visible = true;
                    txtIP.Visible = true;
                    txtPorta.Visible = true;
                    lblStatusConexao.Visible = true;
                    txtStausConexao.Visible = true;
                    AbrirProspectPreditivo(0);
                    grpPainelBotao.Text = "Painel de Atendimento - Discador no modo Preditivo";
                }
                else
                {
                    chkDiscagemAutomatica.Visible = false;

                    lblIP.Visible = false;
                    lblPorta.Visible = false;
                    txtIP.Visible = false;
                    txtPorta.Visible = false;
                    grpTelefonia.Height = 80;
                    lblStatusConexao.Visible = false;
                    txtStausConexao.Visible = false;
                    cmdProximoProspect.Visible = true;
                    timerReconectar.Enabled = false;
                    lblTimerReconexão.Visible = false;
                    txtTimerReconexao.Visible = false;
                }
            }

            if (fLogin.Configuracao.TipoPabx == "Vonix")
            {
                if (fLogin.Usuario.TipoDiscador == "Preditivo")
                {
                    //Abilita o Botão salvarContato grande no modo Preditivo
                    cmdProximoProspect.Visible = false;
                    cmdSalvarContato.Size = new Size(cmdSalvarContato.Size.Width, 57);
                    cmdSalvarContato.Location = new Point(16, 16);

                    cmdProximoProspect.Visible = false;

                    //Timer Vonix DESABILITADO ATÉ HOMOLOGAR
                    TimerAtualizarProspectVonix.Enabled = true;
                    RegistrarEventos("Timer preditivo ativado");
                    PontoBr.Utilidades.Log.RegistrarLog("Timer preditivo - " + "Timer preditivo ativado", "log");
                }
                else
                {
                    cmdProximoProspect.Visible = true;
                    cmdSalvarContato.Size = new Size(123, 26);
                    cmdSalvarContato.Location = new Point(16, 47);
                }
            }

            if (fLogin.Configuracao.TipoPabx == "Leucotron")
            {
                lblPreview.Visible = true;
                radSim.Visible = true;
                radNao.Visible = true;

                ConectarLeucotron(fLogin.Configuracao.IPServidor.ToString(), Convert.ToInt32(fLogin.Configuracao.PortaServidor));
            }

            //Verifica se há script de atendimento
            if (fLogin.Configuracao.Script == 0)
            {
                grbScript.Enabled = false;
                lblScript.Enabled = false;
                dgPerguntaResposta.Enabled = false;
                lsbRespostas.Enabled = false;
                dgResposta.Enabled = false;
                dgHistorico.Enabled = false;
                dgResposta.Enabled = false;
                cmdReiniciarScript.Enabled = false;
                grbScript.Visible = false;

                //Histórico
                grpHistorico.Location = new Point(9, 430);
                grpHistorico.Width = 1307;//grpHistorico.Width = 807;
                grpHistorico.Height = 180;
                dgHistorico.Width = 1291;//dgHistorico.Width = 789;
                dgHistorico.Height = 141;
                chkMailingDiferente.Location = new Point(1050, 11);//chkMailingDiferente.Location = new Point(548, 11);

                //Observação
                grpObservacao.Location = new Point(9, 309);
                grpObservacao.Width = 807;
                grpObservacao.Height = 115;
                txtObservacao.Width = 790;
                txtObservacao.Height = 88;

                //Top Semanal
                grpVendasSemana.Location = new Point(823, 242);
                grpVendasSemana.Width = 493;
                grpVendasSemana.Height = 181;
            }
            else
            {
                dgResposta.Enabled = false;
                dgHistorico.Enabled = false;
                grbScript.Enabled = true;
                lblScript.Enabled = true;
                dgPerguntaResposta.Enabled = true;
                lsbRespostas.Enabled = true;
                dgResposta.Enabled = true;
                cmdReiniciarScript.Enabled = false;

                tabControlAtendimento.TabPages[1].Text = "Dados da Venda";
            }
            BloquearFormulario();

            //AbrirProspectPreditivo(1836658);

            CarregarFuncionalidadesDeClientes();

            try
            {
                RetornarTopSemanal();
                RetornarQuantidadeAgendamentoOperador();
            }
            catch { }
        }

        private void CarregarFuncionalidadesDeClientes()
        {
            //Ocultar botão de pesquisar CEP (Valore - Lucas)
            if (fLogin.Configuracao.Cliente == "valore")
            {
                cmdBuscarCep.Visible = false;
                txtCep.Width = 169;
            }

            //Ocultar a Grid Histórico de contatos para RDBH [Regina]
            if (fLogin.Configuracao.Cliente == "Rdbh") grpHistorico.Visible = false;

            if (fLogin.Configuracao.Cliente == "Ortolancer") txtObservacao.Text = "Conversou com: ";
        }
        #endregion

        #region Retornar Top Semanal
        private void RetornarTopSemanal()
        {
            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = null;

            dataTable = CRelatorio.RetornarTopSemanal(fLogin.Usuario.IDCampanha);

            Invoke((MethodInvoker)delegate { lblTop.Text = ""; });

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Invoke((MethodInvoker)delegate { lblTop.Text += dataRow["Operador"].ToString() + " - " + dataRow["Quant. Vendas"].ToString() + "\n"; });
            }
        }
        #endregion

        #region Carregar Status (Campanha - Script)
        private void CarregarStatus(int iIDCampanha)
        {
            //Verifica se há script de atendimento
            if (fLogin.Configuracao.Script == 0)
            {
                statusCTL CStatus = new statusCTL();
                CStatus.PreencherComboBox_Status(comboStatus, iIDCampanha, fLogin.Configuracao.Script);
            }
            else
            {
                statusCTL CStatus = new statusCTL();
                CStatus.PreencherComboBox_Status(comboStatus, iIDCampanha, fLogin.Configuracao.Script);
            }
        }
        #endregion

        #region Carregar Mídias
        private void CarregarMidias()
        {
            prospectCTL CProspect = new prospectCTL();
            CProspect.PreencherComboBox_Midias(comboMidia);
        }
        #endregion

        #region Retornar Operadora
        private void RetornarOperadora(int iIDCampanha)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            sOperadora = CCampanha.RetornarOperadora(iIDCampanha);
        }
        #endregion

        #region Enviar E-Mail
        private void EnviarEmail(prospect Prospect, string sDataContato, DataTable dScript, string sObservacao, string sOperador)
        {
            emailCTL CEmail = new emailCTL();
            CEmail.EnviarEmailAgendamento(Prospect, sDataContato, dScript, sObservacao, sOperador);
        }
        #endregion

        #region Carrega textos dos labels, configurações e posicionamento na tela
        private void CarregarCamposCampanha(int iIDCampanha)
        {
            //Exclui os campos da tela principal do atendimento
            for (int i = 0; i < grbDadosProspect.Controls.Count; i++)
            {
                if (grbDadosProspect.Controls[i].Name.IndexOf("txtCampo") > -1
                    || grbDadosProspect.Controls[i].Name.IndexOf("lblCampo") > -1
                    || grbDadosProspect.Controls[i].Name.IndexOf("comboCampo") > -1)
                {
                    grbDadosProspect.Controls.Remove(grbDadosProspect.Controls[i]);
                    i = 0;
                }
            }

            //Exclui os dados de venda
            tabControlAtendimento.TabPages.Add(DadosDaVenda);
            for (int i = 0; i < tabControlAtendimento.TabPages[1].Controls.Count; i++)
            {
                if (tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("txtVenda") > -1
                    || tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("lblVenda") > -1
                    || tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("comboVenda") > -1)
                {
                    tabControlAtendimento.TabPages[1].Controls.Remove(tabControlAtendimento.TabPages[1].Controls[i]);
                    i = 0;
                }
            }

            configuracaoCTL CConfiguracao = new configuracaoCTL();
            arrayList = new ArrayList();
            arrayList.Clear();

            arrayList = CConfiguracao.RetornarCamposCampanha(iIDCampanha);

            int iTabIndexContato = 40;
            int iTabIndexVenda = 100;

            for (int iItem = 0; iItem < arrayList.Count; iItem++)
            {
                configuracao Configuracao = (configuracao)arrayList[iItem];
                int X, Y;
                string[] sSubstring;
                string[] sLista;

                Label label = new Label();
                TextBox textBox = new TextBox();
                ComboBox comboBox = new ComboBox();

                label.Name = Configuracao.Label;
                textBox.Name = Configuracao.TextBox;
                comboBox.Name = Configuracao.TextBox.Replace("txt", "combo");
                textBox.MaxLength = 200;
                textBox.Enabled = true;
                textBox.Visible = true;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                sSubstring = Configuracao.LocalizacaoTextBox.Split(';');
                X = Convert.ToInt32(sSubstring[0].Trim());
                Y = Convert.ToInt32(sSubstring[1].Trim());
                textBox.Location = new System.Drawing.Point(X, Y);
                comboBox.Location = new System.Drawing.Point(X, Y);

                sSubstring = Configuracao.TamanhoTextBox.Split(';');
                X = Convert.ToInt32(sSubstring[0].Trim());
                Y = Convert.ToInt32(sSubstring[1].Trim());
                textBox.Size = new System.Drawing.Size(X, Y);
                comboBox.Size = new System.Drawing.Size(X, Y);

                sSubstring = Configuracao.LocalizacaoLabel.Split(';');
                X = Convert.ToInt32(sSubstring[0].Trim());
                Y = Convert.ToInt32(sSubstring[1].Trim());
                label.Location = new System.Drawing.Point(X, Y);

                label.Visible = true;
                label.Text = Configuracao.Obrigatorio == true ? Configuracao.Texto.Trim() + "*:" : Configuracao.Texto.Trim() + ":";
                label.Size = new System.Drawing.Size(label.PreferredWidth, 13);

                if (Configuracao.IDCampo.IndexOf("c") > -1)
                {
                    grbDadosProspect.Controls.Add(label);

                    /*TextBox ou DropDown*/
                    if (Configuracao.Lista == "")
                    {
                        grbDadosProspect.Controls.Add(textBox);
                        textBox.TabIndex = iTabIndexContato;
                    }
                    else
                    {
                        grbDadosProspect.Controls.Add(comboBox);
                        comboBox.TabIndex = iTabIndexContato;
                    }

                    iTabIndexContato++;
                }
                else if (Configuracao.IDCampo.IndexOf("v") > -1)
                {
                    tabControlAtendimento.TabPages[1].Controls.Add(label);

                    /*TextBox ou DropDown*/
                    if (Configuracao.Lista == "")
                    {
                        tabControlAtendimento.TabPages[1].Controls.Add(textBox);
                        textBox.TabIndex = iTabIndexVenda;
                    }
                    else
                    {
                        tabControlAtendimento.TabPages[1].Controls.Add(comboBox);
                        comboBox.TabIndex = iTabIndexVenda;
                    }

                    iTabIndexVenda++;
                }
                /*Carrega lista no DropDown*/
                if (Configuracao.Lista != "")
                {
                    comboBox.Items.Clear();
                    Configuracao.Lista = "-;" + Configuracao.Lista;
                    sLista = Configuracao.Lista.Split(';');
                    Array.Sort(sLista);
                    comboBox.DataSource = sLista;
                    comboBox.Refresh();
                }
            }
            tabControlAtendimento.TabPages.Remove(DadosDaVenda);
        }
        #endregion

        #region Salvar Contato
        private void cmdSalvarContato_Click(object sender, EventArgs e)
        {
            if (Indicacao == true)
            {
                if (PodeCadastarIndicacao())
                {
                    if (PodeSalvarContato())
                    {
                        if (String.IsNullOrEmpty(txtIDProspect.Text))
                            SalvarIndicacao();
                        cmdSalvarContato.Enabled = false;
                        SalvarContato();
                    }
                }
            }
            else
            {
                if (PodeSalvarContato())
                {
                    cmdSalvarContato.Enabled = false;
                    cmdCadastrar.Enabled = true;
                    SalvarContato();
                }
            }
        }
        #endregion

        #region Salvar Contato - Indicação
        private void SalvarIndicacao()
        {
            mailingCTL CMailing = new mailingCTL();

            try
            {
                int iIDMailing = CMailing.RetornarMailingIndicacaoOperador(Convert.ToInt32(comboCampanha.SelectedValue.ToString()));
                if (iIDMailing != 0)
                {
                    prospect Prospect = new prospect();
                    Prospect.Telefone1 = Convert.ToDouble(txtTelefone1.Text);
                    Prospect.Nome = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome.Text);
                    Prospect.Telefone2 = Convert.ToDouble(txtTelefone2.Text == "" ? 0 : Convert.ToDouble(txtTelefone2.Text));
                    Prospect.Telefone3 = Convert.ToDouble(txtTelefone3.Text == "" ? 0 : Convert.ToDouble(txtTelefone3.Text));
                    Prospect.CPF_CNPJ = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPF_CNPJ.Text);
                    Prospect.Logradouro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtLogradouro.Text);
                    Prospect.Numero = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNumero.Text);
                    Prospect.Complemento = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtComplemento.Text);
                    Prospect.Bairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtBairro.Text);
                    Prospect.Cidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCidade.Text);
                    Prospect.Estado = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtEstado.Text);
                    Prospect.Email = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtEmail.Text);
                    Prospect.Cep = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCep.Text);//rr
                    Prospect.IDMailing = iIDMailing;
                    Prospect.IDUsuario = fLogin.Usuario.IDUsuario;
                    Prospect.IDMidia = Convert.ToInt32(comboMidia.SelectedValue);

                    string sLabel, sTextBox;
                    foreach (Control controlLabel in grbDadosProspect.Controls)
                    {
                        if (controlLabel.Name.IndexOf("lblCampo") > -1)
                        {
                            foreach (Control controlTextBox in grbDadosProspect.Controls)
                            {
                                sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                                sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                                if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                                {
                                    TextBox textBox = (TextBox)controlTextBox;
                                    if (textBox.Name == "txtCampo01") Prospect.Campo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo02") Prospect.Campo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo03") Prospect.Campo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo04") Prospect.Campo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo05") Prospect.Campo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo06") Prospect.Campo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo07") Prospect.Campo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo08") Prospect.Campo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo09") Prospect.Campo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtCampo10") Prospect.Campo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                }
                            }
                        }
                    }

                    prospectCTL CProspect = new prospectCTL();
                    int iIDProspect = CProspect.CadastrarIndicacao(Prospect);
                    txtIDProspect.Text = iIDProspect.ToString();

                    //Verifica se o último histórico do cliente era agendamento.
                    //Se for, salva um novo prospect e mantém o agendamento para o operador anterior.
                    if (iIDAcaoAgendamento == 2)
                        CProspect.AtualizarUsuarioAgendamento(iIDProspectAgendamento, iIDUsuarioAgendamento, iIDStatusAgendamento);
                }
                else
                {
                    MessageBox.Show("Não existe Mailing Indicação para esta campanha", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }
        #endregion

        #region Salvar
        private void SalvarContato()
        {
            prospectCTL CProspect = new prospectCTL();
            try
            {
                //Atualizar dados do prospect
                prospect prospect = new prospect();
                prospect.IDProspect = Convert.ToInt32(txtIDProspect.Text);
                prospect.Telefone1 = Convert.ToDouble(txtTelefone1.Text);
                prospect.Nome = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome.Text);
                prospect.Telefone2 = Convert.ToDouble(txtTelefone2.Text == "" ? 0 : Convert.ToDouble(txtTelefone2.Text));
                prospect.Telefone3 = Convert.ToDouble(txtTelefone3.Text == "" ? 0 : Convert.ToDouble(txtTelefone3.Text));
                prospect.CPF_CNPJ = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPF_CNPJ.Text);
                prospect.Logradouro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtLogradouro.Text);
                prospect.Numero = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNumero.Text);
                prospect.Complemento = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtComplemento.Text);
                prospect.Bairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtBairro.Text);
                prospect.Cidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCidade.Text);
                prospect.Estado = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtEstado.Text);
                prospect.Email = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtEmail.Text);
                prospect.Cep = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCep.Text);

                prospect.IDMidia = Convert.ToInt32(comboMidia.SelectedValue);

                string sLabel, sTextBox;
                foreach (Control controlLabel in grbDadosProspect.Controls)
                {
                    if (controlLabel.Name.IndexOf("lblCampo") > -1)
                    {
                        foreach (Control controlTextBox in grbDadosProspect.Controls)
                        {
                            sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                            sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txtCampo") > -1)
                            {
                                TextBox textBox = (TextBox)controlTextBox;
                                if (textBox.Name == "txtCampo01") prospect.Campo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo02") prospect.Campo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo03") prospect.Campo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo04") prospect.Campo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo05") prospect.Campo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo06") prospect.Campo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo07") prospect.Campo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo08") prospect.Campo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo09") prospect.Campo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                if (textBox.Name == "txtCampo10") prospect.Campo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                            }
                            else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("comboCampo") > -1)
                            {
                                ComboBox comboBox = (ComboBox)controlTextBox;
                                if (comboBox.Name == "comboCampo01") prospect.Campo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo02") prospect.Campo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo03") prospect.Campo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo04") prospect.Campo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo05") prospect.Campo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo06") prospect.Campo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo07") prospect.Campo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo08") prospect.Campo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo09") prospect.Campo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                if (comboBox.Name == "comboCampo10") prospect.Campo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                            }
                        }
                    }
                }
                string sMensagem = "";

                contato Contato = new contato();
                Contato.IDProspect = Convert.ToInt32(txtIDProspect.Text);

                Contato.IDStatus = Convert.ToInt32(comboStatus.SelectedValue);
                Contato.Observacao = txtObservacao.Text == "" ? "" : PontoBr.Utilidades.String.RemoverCaracterInvalido(txtObservacao.Text);
                Contato.DataAbertura = sDataAbertura;
                Contato.RetornoPreditivo = 0;

                if (Status.Acao == "Agendamento" || comboStatus.Text.ToUpper().IndexOf("ANALISANDO") != -1)
                {
                    Contato.HoraAgendamento = sHoraAgendamento;

                    //Contato - Verifica qual operador selecionado
                    Contato.IDUsuario = Convert.ToInt32(comboOperadorAgendamento.SelectedValue);
                }
                else
                {
                    Contato.HoraAgendamento = null;
                    Contato.IDUsuario = fLogin.Usuario.IDUsuario;
                }

                if (Indicacao == true)
                    Contato.IDTipoAtendimento = 2;
                else
                    Contato.IDTipoAtendimento = 1;

                //Recupera as respostas do Script
                if (fLogin.Configuracao.Script == 1)
                {
                    if (comboStatus.SelectedValue.ToString() == "-4") //Se for contato com sucesso
                    {
                        for (int iLinha = 0; iLinha < dataRespostas.Rows.Count; iLinha++)
                        {
                            if (Contato.IDResposta != "" && Contato.IDResposta != null)
                                Contato.IDResposta = Contato.IDResposta + ",";

                            Contato.IDResposta = Contato.IDResposta + dataRespostas.Rows[iLinha]["IDResposta"].ToString();
                        }
                    }
                }

                //Verifica se foi preenchido algo em Dados da Venda
                bool bPreencheuCamposVenda = false;
                if (comboStatus.SelectedValue.ToString() == "-2") //robson
                {
                    for (int i = 0; i < tabControlAtendimento.TabPages[1].Controls.Count; i++)
                    {
                        if (tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("txtVenda") > -1)
                        {
                            TextBox textBox = (TextBox)tabControlAtendimento.TabPages[1].Controls[i];
                            if (textBox.Text != "")
                            {
                                bPreencheuCamposVenda = true;
                                break;
                            }
                        }

                        if (tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("comboVenda") > -1)
                        {
                            ComboBox comboBox = (ComboBox)tabControlAtendimento.TabPages[1].Controls[i];
                            //comboBox.Text = "-"; 
                            if (comboBox.SelectedIndex != -1 && comboBox.SelectedIndex != 0)
                            {
                                bPreencheuCamposVenda = true;
                                break;
                            }
                        }
                    }
                }

                //if (Venda == true)
                if (Convert.ToBoolean(Status.Venda) || comboStatus.SelectedValue.ToString() == "-2")
                {
                    foreach (Control controlLabel in tabControlAtendimento.TabPages[1].Controls)
                    {
                        if (controlLabel.Name.IndexOf("lblVenda") > -1)
                        {
                            foreach (Control controlTextBox in tabControlAtendimento.TabPages[1].Controls)
                            {
                                sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                                sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                                if (Convert.ToBoolean(Status.Venda))
                                {
                                    if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txtVenda") > -1)
                                    {
                                        TextBox textBox = (TextBox)controlTextBox;
                                        if (textBox.Name == "txtVenda01") Contato.Venda01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda02") Contato.Venda02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda03") Contato.Venda03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda04") Contato.Venda04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda05") Contato.Venda05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda06") Contato.Venda06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda07") Contato.Venda07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda08") Contato.Venda08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda09") Contato.Venda09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda10") Contato.Venda10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda11") Contato.Venda11 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda12") Contato.Venda12 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda13") Contato.Venda13 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda14") Contato.Venda14 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda15") Contato.Venda15 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda16") Contato.Venda16 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda17") Contato.Venda17 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda18") Contato.Venda18 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda19") Contato.Venda19 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda20") Contato.Venda20 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda21") Contato.Venda21 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda22") Contato.Venda22 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda23") Contato.Venda23 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda24") Contato.Venda24 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda25") Contato.Venda25 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda26") Contato.Venda26 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda27") Contato.Venda27 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda28") Contato.Venda28 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda29") Contato.Venda29 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda30") Contato.Venda30 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda31") Contato.Venda31 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda32") Contato.Venda32 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda33") Contato.Venda33 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda34") Contato.Venda34 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda35") Contato.Venda35 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda36") Contato.Venda36 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda37") Contato.Venda37 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda38") Contato.Venda38 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda39") Contato.Venda39 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda40") Contato.Venda40 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda41") Contato.Venda41 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda42") Contato.Venda42 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda43") Contato.Venda43 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda44") Contato.Venda44 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda45") Contato.Venda45 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda46") Contato.Venda46 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda47") Contato.Venda47 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda48") Contato.Venda48 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda49") Contato.Venda49 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda50") Contato.Venda50 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda51") Contato.Venda51 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda52") Contato.Venda52 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda53") Contato.Venda53 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda54") Contato.Venda54 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda55") Contato.Venda55 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda56") Contato.Venda56 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda57") Contato.Venda57 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda58") Contato.Venda58 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda59") Contato.Venda59 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda60") Contato.Venda60 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);

                                        sMensagem += controlLabel.Text + " = " + textBox.Text + "; ";
                                    }
                                    else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("comboVenda") > -1)
                                    {
                                        ComboBox comboBox = (ComboBox)controlTextBox;
                                        if (comboBox.Name == "comboVenda01") Contato.Venda01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda02") Contato.Venda02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda03") Contato.Venda03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda04") Contato.Venda04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda05") Contato.Venda05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda06") Contato.Venda06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda07") Contato.Venda07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda08") Contato.Venda08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda09") Contato.Venda09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda10") Contato.Venda10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda11") Contato.Venda11 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda12") Contato.Venda12 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda13") Contato.Venda13 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda14") Contato.Venda14 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda15") Contato.Venda15 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda16") Contato.Venda16 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda17") Contato.Venda17 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda18") Contato.Venda18 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda19") Contato.Venda19 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda20") Contato.Venda20 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda21") Contato.Venda21 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda22") Contato.Venda22 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda23") Contato.Venda23 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda24") Contato.Venda24 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda25") Contato.Venda25 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda26") Contato.Venda26 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda27") Contato.Venda27 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda28") Contato.Venda28 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda29") Contato.Venda29 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda30") Contato.Venda30 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda31") Contato.Venda31 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda32") Contato.Venda32 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda33") Contato.Venda33 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda34") Contato.Venda34 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda35") Contato.Venda35 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda36") Contato.Venda36 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda37") Contato.Venda37 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda38") Contato.Venda38 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda39") Contato.Venda39 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda40") Contato.Venda40 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda41") Contato.Venda41 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda42") Contato.Venda42 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda43") Contato.Venda43 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda44") Contato.Venda44 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda45") Contato.Venda45 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda46") Contato.Venda46 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda47") Contato.Venda47 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda48") Contato.Venda48 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda49") Contato.Venda49 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda50") Contato.Venda50 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda51") Contato.Venda51 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda52") Contato.Venda52 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda53") Contato.Venda53 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda54") Contato.Venda54 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda55") Contato.Venda55 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda56") Contato.Venda56 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda57") Contato.Venda57 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda58") Contato.Venda58 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda59") Contato.Venda59 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());
                                        if (comboBox.Name == "comboVenda60") Contato.Venda60 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text.Trim());

                                        sMensagem += controlLabel.Text + " = " + comboBox.Text + "; ";
                                    }
                                }
                                else if (comboStatus.SelectedValue.ToString() == "-2" && bPreencheuCamposVenda == true)//robson
                                {
                                    if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                                    {
                                        TextBox textBox = (TextBox)controlTextBox;
                                        if (textBox.Name == "txtVenda01") prospect.Venda01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda02") prospect.Venda02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda03") prospect.Venda03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda04") prospect.Venda04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda05") prospect.Venda05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda06") prospect.Venda06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda07") prospect.Venda07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda08") prospect.Venda08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda09") prospect.Venda09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda10") prospect.Venda10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda11") prospect.Venda11 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda12") prospect.Venda12 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda13") prospect.Venda13 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda14") prospect.Venda14 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda15") prospect.Venda15 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda16") prospect.Venda16 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda17") prospect.Venda17 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda18") prospect.Venda18 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda19") prospect.Venda19 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda20") prospect.Venda20 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda21") prospect.Venda21 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda22") prospect.Venda22 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda23") prospect.Venda23 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda24") prospect.Venda24 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda25") prospect.Venda25 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda26") prospect.Venda26 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda27") prospect.Venda27 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda28") prospect.Venda28 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda29") prospect.Venda29 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda30") prospect.Venda30 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda31") prospect.Venda31 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda32") prospect.Venda32 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda33") prospect.Venda33 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda34") prospect.Venda34 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda35") prospect.Venda35 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda36") prospect.Venda36 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda37") prospect.Venda37 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda38") prospect.Venda38 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda39") prospect.Venda39 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda40") prospect.Venda40 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda41") prospect.Venda41 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda42") prospect.Venda42 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda43") prospect.Venda43 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda44") prospect.Venda44 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda45") prospect.Venda45 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda46") prospect.Venda46 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda47") prospect.Venda47 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda48") prospect.Venda48 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda49") prospect.Venda49 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda50") prospect.Venda50 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda51") prospect.Venda51 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda52") prospect.Venda52 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda53") prospect.Venda53 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda54") prospect.Venda54 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda55") prospect.Venda55 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda56") prospect.Venda56 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda57") prospect.Venda57 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda58") prospect.Venda58 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda59") prospect.Venda59 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtVenda60") prospect.Venda60 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    }
                                    else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                                    {
                                        ComboBox comboBox = (ComboBox)controlTextBox;
                                        if (comboBox.Name == "comboVenda01") prospect.Venda01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda02") prospect.Venda02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda03") prospect.Venda03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda04") prospect.Venda04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda05") prospect.Venda05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda06") prospect.Venda06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda07") prospect.Venda07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda08") prospect.Venda08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda09") prospect.Venda09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda10") prospect.Venda10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda11") prospect.Venda11 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda12") prospect.Venda12 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda13") prospect.Venda13 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda14") prospect.Venda14 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda15") prospect.Venda15 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda16") prospect.Venda16 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda17") prospect.Venda17 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda18") prospect.Venda18 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda19") prospect.Venda19 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda20") prospect.Venda20 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda21") prospect.Venda21 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda22") prospect.Venda22 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda23") prospect.Venda23 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda24") prospect.Venda24 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda25") prospect.Venda25 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda26") prospect.Venda26 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda27") prospect.Venda27 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda28") prospect.Venda28 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda29") prospect.Venda29 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda30") prospect.Venda30 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda31") prospect.Venda31 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda32") prospect.Venda32 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda33") prospect.Venda33 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda34") prospect.Venda34 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda35") prospect.Venda35 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda36") prospect.Venda36 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda37") prospect.Venda37 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda38") prospect.Venda38 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda39") prospect.Venda39 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda40") prospect.Venda40 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda41") prospect.Venda41 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda42") prospect.Venda42 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda43") prospect.Venda43 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda44") prospect.Venda44 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda45") prospect.Venda45 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda46") prospect.Venda46 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda47") prospect.Venda47 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda48") prospect.Venda48 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda49") prospect.Venda49 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda50") prospect.Venda50 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda51") prospect.Venda51 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda52") prospect.Venda52 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda53") prospect.Venda53 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda54") prospect.Venda54 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda55") prospect.Venda55 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda56") prospect.Venda56 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda57") prospect.Venda57 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda58") prospect.Venda58 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda59") prospect.Venda59 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboVenda60") prospect.Venda60 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    }
                                }
                            }
                        }
                    }
                }

                //Contato.Venda = Venda;
                //CProspect.SalvarContato(Contato);
                int iIDHistorico = 0;
                Contato.Venda = Convert.ToBoolean(Status.Venda);

                if (fLogin.Configuracao.Cliente == "Conecctta")
                    iIDHistorico = CProspect.SalvarContatoConecctta(Contato);
                else
                    iIDHistorico = CProspect.SalvarContato(Contato);

                //Salva ou Atualiza somente se tiver histórico
                if (comboStatus.SelectedValue.ToString() == "-2")
                {
                    int iIDHistoricoVenda = CProspect.RetornarHistoricoVenda(Contato.IDProspect);
                    if (bPreencheuCamposVenda)
                    {
                        if (iIDHistoricoVenda == -1)
                            CProspect.SalvarDadosVenda(iIDHistorico, prospect);
                        else
                            CProspect.AtualizarDadosVenda(iIDHistoricoVenda, prospect);
                    }
                }


                if ((Status.Acao == "Agendamento" || comboStatus.Text.ToUpper().IndexOf("ANALISANDO") != -1) && Indicacao)
                    CProspect.AtualizarDadosProspect(prospect, true);
                else
                    CProspect.AtualizarDadosProspect(prospect, false);

                string sStatus = comboStatus.Text.ToString();
                Indicacao = false;
                iIDResposta = 0;

                AtualizarStatusFormulario(STATUS_DESCONECTADO_SEM_PROSPECT);

                //Verifico se IDAcao = 2 (Agend. Analalisando.) do último usuário Mantenho no agendamento do operador anterior (wea)
                if (iIDAcaoAgendamento == 2)
                    CProspect.AtualizarUsuarioAgendamento(iIDProspectAgendamento, iIDUsuarioAgendamento, iIDStatusAgendamento);

                BloquearFormulario();
                lblRegistros.Text = "";
                lblRegistros.Visible = true;

                SsMensagem = "Contato salvo com sucesso. \n";
                SsMensagem += "================== \n";
                SsMensagem += "STATUS SELECIONADO: \n";
                SsMensagem += sStatus + "\n\n";
                SsMensagem += "Código do Prospect: " + Contato.IDProspect.ToString();
                MessageBox.Show(SsMensagem, "Tabulare");

                //Discagem Modo preview
                if (fLogin.Configuracao.TipoPabx == "Leucotron" && fLogin.Configuracao.Cliente == "Ceitel")
                {
                    if (radSim.Checked == true)
                    {
                        ProximoProspectPreview();
                        Thread.Sleep(1000);
                        DiscarPreviewLeucotron();
                    }
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }

            try
            {
                RetornarTopSemanal();
                RetornarQuantidadeAgendamentoOperador();
            }
            catch { }
        }
        #endregion

        #region Pode Salvar Contato
        private bool PodeSalvarContato()
        {
            string sMensagem;
            string sIDStatus;

            //Verifica se o Telefone1 é numérico
            double dTelefone1;
            try
            {
                dTelefone1 = Convert.ToDouble(txtTelefone1.Text.Trim());
            }
            catch
            {
                sMensagem = "[Telefone 1] incorreto(formato: 3188889999).";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Verifica se o Telefone1 tem 10 ou 11 dígitos
            if (txtTelefone1.Text.Trim().Length != 10 && txtTelefone1.Text.Trim().Length != 11)
            {
                sMensagem = "[Telefone 1] incorreto(formato: 3188889999).";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            sIDStatus = comboStatus.SelectedValue.ToString();
            if (sIDStatus == null)
            {
                sMensagem = "Selecione um [Status Ligação].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (sIDStatus == "-1" || sIDStatus == null)
            {
                sMensagem = "Selecione [Resultado Contato].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (comboStatus.Text.IndexOf("RECUSADO") != -1)
            {
                if (txtObservacao.Text == "")
                {
                    sMensagem = "É obrigatótio o Preencimento. \n";
                    sMensagem += " do campo [Observação]. \n";
                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            //Apenas para Ortolancer, verifica se o operador ligou para o cliente e descreveu no campo Observação
            if (fLogin.Configuracao.Cliente == "Ortolancer")
            {
                if (txtObservacao.TextLength < 30 || txtObservacao.Text == "")
                {
                    sMensagem = "O campo [Observação] é obrigatótio o Preencimento. \n";
                    sMensagem += " mínimo 30 caracteres . \n";
                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }



            //Verifica se é Reagendamento de Ligação
            if (Status.Acao == "Agendamento" || comboStatus.SelectedValue.ToString() == "-2")
            {
                sHoraAgendamento = datAgendamento.Value.ToString("yyyy/MM/dd") + " " + txtHoraRetorno.Text;
                if (!ValidarDataHoraAgenda(sHoraAgendamento))
                {
                    sMensagem = "O Hora do Agendamento está incorreta.";
                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            //Verificar se é venda e caso seja faz a verificação dos campos obrigatórios
            //#Contato com Sucesso# ou #Pesquisa Realizada#
            if (Venda == true || sIDStatus == "-4")
            {
                //Dados de Venda
                string sLabel, sTextBox;
                foreach (Control controlLabel in tabControlAtendimento.TabPages[1].Controls)
                {
                    if (controlLabel.Text.IndexOf("*") > -1 && controlLabel.Name.IndexOf("lblVenda") > -1)
                    {
                        foreach (Control controlTextBox in tabControlAtendimento.TabPages[1].Controls)
                        {
                            sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                            sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                            {
                                TextBox textBox = (TextBox)controlTextBox;
                                if (textBox.Text.Trim() == "")
                                {
                                    sMensagem = "Favor preencher [" + controlLabel.Text.Replace(":", "").Replace("*", "") + "].";
                                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                            {
                                ComboBox comboBox = (ComboBox)controlTextBox;
                                if (comboBox.Text == "-")
                                {
                                    sMensagem = "Favor selecionar [" + controlLabel.Text.Replace(":", "").Replace("*", "") + "].";
                                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region Pode Cadastrar Indicação
        private bool PodeCadastarIndicacao()
        {
            string sMensagem;
            if (txtTelefone1.Text.Trim().ToString() == "")
            {
                sMensagem = "Digite o [Telefone 1].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTelefone1.Text.Trim().Length != 10 && txtTelefone1.Text.Trim().Length != 11)
            {
                sMensagem = "[Telefone 1] deve conter 10 ou 11 dígitos";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTelefone1.Text.Substring(0, 1) == "0")
            {
                sMensagem = "[Telefone 1] incorreto.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //prospectCTL CProspect = new prospectCTL();
            //if (CProspect.VerificarTelefoneBlackList(Convert.ToDouble(txtTelefone1.Text)))
            //{
            //    sMensagem = "O [Telefone 1] não pode ser cadastrado\nporque está no Blacklist.";
            //    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (txtNome.Text.ToString() == "")
            {
                sMensagem = "Preencha [Nome].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (comboMidia.SelectedValue.ToString() == "-1")
            {
                sMensagem = "No cadastro de Receptivo/Indicação é obrigatório selecionar [Mídia].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion

        #region Retornar Próximo Prospect
        private void RetornarProxProspect()
        {
            string sMensagem;
            prospectCTL CProspect = new prospectCTL();

            Prospect = CProspect.RetornarProximoProspectPower(fLogin.Usuario);
            if (Prospect.IDProspect == 0)
            {
                tabControlAtendimento.TabPages.Remove(DadosDaVenda);

                comboStatus.Enabled = false;
                txtTelefone1.ReadOnly = true;

                AtualizarStatusFormulario(STATUS_DESCONECTADO_SEM_PROSPECT);
                sMensagem = "Não há prospects disponíveis para sua Campanha. \n";
                sMensagem += "CAMPANHA:  " + Convert.ToString(comboCampanha.Text).ToUpper() + "  ";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (chkDiscagemAutomatica.Checked == true)
                {
                    if (fLogin.Configuracao.TipoPabx == "Digistar")
                    {
                        LiberarRamalDigistar();
                    }
                }
                else
                {
                    chkDiscagemAutomatica.Enabled = false;
                }

                LiberarFormulario();

                comboStatus.Enabled = true;
                grbDadosProspect.Text = "Dados do Prospect";

                txtIDProspect.Text = Prospect.IDProspect.ToString();
                txtMailing.Text = Prospect.Mailing;
                txtTelefone1.Text = Prospect.Telefone1.ToString();
                txtTelefone2.Text = Prospect.Telefone2.ToString();
                txtTelefone3.Text = Prospect.Telefone3.ToString();
                radTel1.Checked = true;

                txtNome.Text = Prospect.Nome;
                txtCPF_CNPJ.Text = Prospect.CPF_CNPJ.ToString();
                txtLogradouro.Text = Prospect.Logradouro.ToString();
                txtNumero.Text = Prospect.Numero.ToString();
                txtComplemento.Text = Prospect.Complemento.ToString();
                txtBairro.Text = Prospect.Bairro.ToString();
                txtCidade.Text = Prospect.Cidade.ToString();
                txtEstado.Text = Prospect.Estado.ToString();
                txtEmail.Text = Prospect.Email.ToString();
                txtCep.Text = Prospect.Cep.ToString();//rr
                cmdBuscarCep.Enabled = true;//rr

                string sLabel, sTextBox;
                foreach (Control controlLabel in grbDadosProspect.Controls)
                {
                    if (controlLabel.Name.IndexOf("lblCampo") > -1)
                    {
                        foreach (Control controlTextBox in grbDadosProspect.Controls)
                        {
                            sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                            sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txtCampo") > -1)
                            {
                                TextBox textBox = (TextBox)controlTextBox;
                                if (textBox.Name == "txtCampo01") textBox.Text = Prospect.Campo01.ToString();
                                if (textBox.Name == "txtCampo02") textBox.Text = Prospect.Campo02.ToString();
                                if (textBox.Name == "txtCampo03") textBox.Text = Prospect.Campo03.ToString();
                                if (textBox.Name == "txtCampo04") textBox.Text = Prospect.Campo04.ToString();
                                if (textBox.Name == "txtCampo05") textBox.Text = Prospect.Campo05.ToString();
                                if (textBox.Name == "txtCampo06") textBox.Text = Prospect.Campo06.ToString();
                                if (textBox.Name == "txtCampo07") textBox.Text = Prospect.Campo07.ToString();
                                if (textBox.Name == "txtCampo08") textBox.Text = Prospect.Campo08.ToString();
                                if (textBox.Name == "txtCampo09") textBox.Text = Prospect.Campo09.ToString();
                                if (textBox.Name == "txtCampo10") textBox.Text = Prospect.Campo10.ToString();
                            }
                        }
                    }
                }
                ListarHistoricoContato(chkMailingDiferente.Checked == false ? Prospect.IDMailing : -1);
                dgHistorico.Columns[1].Width = 220;
                dgHistorico.Columns[3].Width = 230;
                dgHistorico.Columns[4].Width = 230;
                dgHistorico.Columns[5].Width = 230;
                dgHistorico.Columns[6].Width = 160;

                AtualizarStatusFormulario(STATUS_DESCONECTADO_COM_PROSPECT);
                lblRegistros.Text = dgHistorico.RowCount.ToString() + " registro(s)";
            }

            if (chkDiscagemAutomatica.Checked == true)
            {
                if (fLogin.Configuracao.TipoPabx == "Digistar")
                {
                    string sTelefone = "";

                    if (radTel1.Checked == true)
                        sTelefone = txtTelefone1.Text;
                    else if (radTel2.Checked == true)
                        sTelefone = txtTelefone2.Text;
                    else if (radTel3.Checked == true)
                        sTelefone = txtTelefone3.Text;

                    //Discagem Digistar
                    DiscarDigistar(sTelefone);
                    cmdDesconectar.Enabled = true;
                    cmdDiscar.Enabled = false;
                    chkDiscagemAutomatica.Enabled = false;
                }
            }
            else
            {
                if (fLogin.Configuracao.TipoPabx == "Digistar")
                {
                    LiberarRamalDigistar();
                }
            }

            CarregarFuncionalidadesDeClientes();
        }
        #endregion

        #region Abrir Prospect
        private void AbrirProspect(int iIDProspect)
        {
            double dIDProspect = 0;
            prospectCTL CProspect = new prospectCTL();
            if (txtTelefone1.Text != "" || txtTelefone2.Text != "" || txtTelefone3.Text != "")
            {
                dIDProspect = CProspect.VerificarExistenciaTelefone(Convert.ToDouble(txtTelefone1.Text == "" ? 0 : Convert.ToDouble(txtTelefone1.Text)), Convert.ToDouble(txtTelefone2.Text == "" ? 0 : Convert.ToDouble(txtTelefone2.Text)), Convert.ToDouble(txtTelefone3.Text == "" ? 0 : Convert.ToDouble(txtTelefone3.Text)));
                if (dIDProspect == 0 && txtIDProspect.Text != "")
                    LiberarFormulario();
            }

            Prospect = CProspect.RetornarProspect(iIDProspect, fLogin.Usuario.IDUsuario);

            //Só abre o cliente se o prospect estiver na mesma campanha do usuário (wea)
            if (fLogin.Usuario.IDCampanha == Prospect.IDCampanha)
            {
                if (Prospect.IDProspect != 0)
                {
                    comboStatus.Enabled = true;
                    grbDadosProspect.Text = "Dados do Prospect";

                    txtIDProspect.Text = Prospect.IDProspect.ToString();
                    if (Indicacao)
                    {
                        txtIDProspect.ForeColor = System.Drawing.Color.White;
                    }

                    txtMailing.Text = Prospect.Mailing;
                    txtTelefone1.Text = Prospect.Telefone1.ToString();
                    txtTelefone2.Text = Prospect.Telefone2.ToString();
                    txtTelefone3.Text = Prospect.Telefone3.ToString();
                    radTel1.Checked = true;

                    txtNome.Text = Prospect.Nome;
                    txtCPF_CNPJ.Text = Prospect.CPF_CNPJ.ToString();
                    txtLogradouro.Text = Prospect.Logradouro.ToString();
                    txtNumero.Text = Prospect.Numero.ToString();
                    txtComplemento.Text = Prospect.Complemento.ToString();
                    txtBairro.Text = Prospect.Bairro.ToString();
                    txtCidade.Text = Prospect.Cidade.ToString();
                    txtEstado.Text = Prospect.Estado.ToString();
                    txtEmail.Text = Prospect.Email.ToString();
                    txtCep.Text = Prospect.Cep.ToString();//rr

                    string sLabel, sTextBox;
                    foreach (Control controlLabel in grbDadosProspect.Controls)
                    {
                        if (controlLabel.Name.IndexOf("lblCampo") > -1)
                        {
                            foreach (Control controlTextBox in grbDadosProspect.Controls)
                            {
                                sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                                sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                                if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                                {
                                    TextBox textBox = (TextBox)controlTextBox;
                                    if (textBox.Name == "txtCampo01") textBox.Text = Prospect.Campo01.ToString();
                                    if (textBox.Name == "txtCampo02") textBox.Text = Prospect.Campo02.ToString();
                                    if (textBox.Name == "txtCampo03") textBox.Text = Prospect.Campo03.ToString();
                                    if (textBox.Name == "txtCampo04") textBox.Text = Prospect.Campo04.ToString();
                                    if (textBox.Name == "txtCampo05") textBox.Text = Prospect.Campo05.ToString();
                                    if (textBox.Name == "txtCampo06") textBox.Text = Prospect.Campo06.ToString();
                                    if (textBox.Name == "txtCampo07") textBox.Text = Prospect.Campo07.ToString();
                                    if (textBox.Name == "txtCampo08") textBox.Text = Prospect.Campo08.ToString();
                                    if (textBox.Name == "txtCampo09") textBox.Text = Prospect.Campo09.ToString();
                                    if (textBox.Name == "txtCampo10") textBox.Text = Prospect.Campo10.ToString();
                                }
                            }
                        }
                    }
                    ListarHistoricoContato(chkMailingDiferente.Checked == false ? Prospect.IDMailing : -1);
                    AtualizarStatusFormulario(STATUS_DESCONECTADO_COM_PROSPECT);
                    dgHistorico.Columns[1].Width = 220;
                    dgHistorico.Columns[3].Width = 230;
                    dgHistorico.Columns[4].Width = 230;
                    dgHistorico.Columns[5].Width = 230;
                    dgHistorico.Columns[6].Width = 150;

                    lblRegistros.Text = dgHistorico.RowCount.ToString() + " registro(s)";
                }
            }
        }
        #endregion

        #region Liberar Formulário
        private void LiberarFormulario()
        {
            grbDadosProspect.Text = "Dados do Prospect";
            radTel1.Checked = true;

            if (Indicacao)
                txtTelefone1.ReadOnly = false;

            txtTelefone2.ReadOnly = false;
            txtTelefone3.ReadOnly = false;
            txtNome.ReadOnly = false;
            txtLogradouro.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtComplemento.ReadOnly = false;
            txtBairro.ReadOnly = false;
            txtCidade.ReadOnly = false;
            txtEstado.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtCep.ReadOnly = false;//rr
            txtCPF_CNPJ.ReadOnly = false;

            txtObservacao.ReadOnly = false;
            grpObservacao.Enabled = true;
            txtObservacao.Enabled = true;
            cmdBuscarCep.Enabled = true;//rr

            for (int i = 0; i < grbDadosProspect.Controls.Count; i++)
            {
                if (grbDadosProspect.Controls[i].Name.IndexOf("txtCampo") > -1)
                {
                    TextBox textBox = (TextBox)grbDadosProspect.Controls[i];
                    textBox.ReadOnly = false;
                }
                if (grbDadosProspect.Controls[i].Name.IndexOf("combo") > -1)
                {
                    ComboBox comboBox = (ComboBox)grbDadosProspect.Controls[i];
                    comboBox.Enabled = true;
                }
            }
            tabControlAtendimento.TabPages.Add(DadosDaVenda);

            for (int i = 0; i < tabControlAtendimento.TabPages[1].Controls.Count; i++)
            {
                if (tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("txtVenda") > -1)
                {
                    TextBox textBox = (TextBox)tabControlAtendimento.TabPages[1].Controls[i];
                    textBox.ReadOnly = false;
                }
            }

            txtObservacao.Text = string.Empty;

            comboStatus.SelectedValue = -1;
            comboStatus.Enabled = true;
            comboMidia.SelectedValue = -1;

            //Só habilita mídia, se não for Indicação
            if (Indicacao)
                comboMidia.Enabled = true;

            datAgendamento.Visible = false;
            txtHoraRetorno.Text = string.Empty;
            txtHoraRetorno.Visible = false;

            //Oculta combo agendar para outro Operador WEA //implantar na wea
            //if (fLogin.Configuracao.Cliente == "Wea")
            //{
            //    comboOperadorAgendamento.Visible = false;
            //    lblAgendarPara.Visible = false;
            //}

            relatorio.fConsultarCliente.sIDPropect = null;

            dgPerguntaResposta.DataSource = null;
            txtIDProspect.ForeColor = System.Drawing.Color.Black;
            chkMailingDiferente.Checked = false;
            grpHistorico.Enabled = true;
            dgHistorico.Enabled = true;
            comboCampanha.Enabled = false;

            LiberarScript();

            fAgendamentos.sIDPropect = null;
            cmdAgendamento.Enabled = true;

            txtNome.Focus();
        }
        #endregion

        #region Combo Status
        private void comboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Oculta campos do Reagendamento de Ligação
                datAgendamento.Visible = false;
                txtHoraRetorno.Visible = false;
                txtHoraRetorno.Text = "";

                //Oculta combo agendar para outro Operador
                comboOperadorAgendamento.Visible = false;
                lblAgendarPara.Visible = false;

                try
                {
                    statusCTL CStatus = new statusCTL();
                    Status = CStatus.RetornarStatus(Convert.ToInt32(comboStatus.SelectedValue));
                }
                catch { }

                //Verifica se é Venda
                if (Status.Venda == 1)
                {
                    Venda = true;
                }
                else
                {
                    Venda = false;
                }

                //Callflex
                LiberarScript();//Oculta campos do #Contato com Sucesso#

                //Se Ação for Agendamento, exibe label e text box para inserir o horário do Reagendamento de Ligação
                if (Status.Acao == "Agendamento"
                    || comboStatus.SelectedValue.ToString() == "-2"
                    || comboStatus.SelectedValue.ToString() == ("155"))
                {
                    CarregarOperadoresAgendamento();
                    datAgendamento.Visible = true;
                    txtHoraRetorno.Visible = true;
                    txtHoraRetorno.Text = DateTime.Now.AddHours(1).ToString("HH:mm");

                    comboOperadorAgendamento.Visible = true;

                    //Mostra combo agendamento
                    lblAgendarPara.Visible = true;
                    comboOperadorAgendamento.Visible = true;
                }
                //Se for igual a #Contato com Sucesso#
                else if (comboStatus.SelectedValue.ToString() == "-4")
                {
                    if (Indicacao == true)
                    {
                        CarregarPrimeiraPergunta(Convert.ToInt32(comboCampanha.SelectedValue.ToString()));
                    }
                    else if (txtIDProspect.Text != "")
                    {
                        CarregarPrimeiraPergunta(Prospect.IDCampanha);
                    }
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }
        #endregion

        #region Validar Data Hora do Agendamento
        private bool ValidarDataHoraAgenda(string sDataHoraAAAAMMDD_HHMM)
        {
            try
            {
                DateTime dtDataAtual = DateTime.Now;
                DateTime dtDataAgendamento = PontoBr.Conversoes.Data.ConverteDataBancoParaDateTime(sDataHoraAAAAMMDD_HHMM);
                if (dtDataAtual >= dtDataAgendamento)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Carregar Primeira Pergunta
        private void CarregarPrimeiraPergunta(int iIDCampanha)
        {
            lblTextoDaPergunta.Text = "-";

            LiberarScript();
            grbScript.Enabled = true;

            scriptCTL CScript = new scriptCTL();
            DataTable dataTable = CScript.RetornarPrimeiraPergunta(iIDCampanha);
            if (dataTable.Rows.Count != 0)
            {
                if (comboStatus.SelectedValue.ToString() == "-4")//IDStatus for igual a -4)
                {
                    if (dataTable.Rows[0]["Pergunta"].ToString() != "")
                    {
                        lblTextoDaPergunta.Text = dataTable.Rows[0]["Pergunta"].ToString();
                        txtInformacao.Text = dataTable.Rows[0]["Informacao"].ToString();
                        CarregarRespostas(Convert.ToInt32(dataTable.Rows[0]["IDPergunta"].ToString()));
                    }
                    else
                        lblTextoDaPergunta.Text = "== FIM DO SCRIPT ==";
                }
            }
            else
            {
                string sMensagem = "Não existe script para esta campanha.\n";
                //sMensagem += "CAMPANHA: " + Convert.ToString(comboCampanha.Text).ToUpper() + " ";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Carregar Respostas
        private void CarregarRespostas(int iIDPergunta)
        {
            if (lblTextoDaPergunta.Text != "== FIM DO SCRIPT ==")
            {
                scriptCTL CScript = new scriptCTL();
                CScript.PreencherListBox_Respostas(lsbRespostas, iIDPergunta);
            }
        }
        #endregion

        #region Carregar Próxima Pergunta
        private void CarregarProximaPergunta(int iIDPergunta)
        {
            lsbRespostas.Items.Clear();

            scriptCTL CScript = new scriptCTL();
            DataTable dataTable = CScript.RetornarProximaPergunta(iIDPergunta);

            if (dataTable.Rows.Count > 0)
            {
                lblTextoDaPergunta.Text = dataTable.Rows[0]["Pergunta"].ToString();
                // txtInformacao.Text = dataTable.Rows[0]["Informacao"].ToString();
                CarregarRespostas(iIDPergunta);
            }
            else
            {
                lblTextoDaPergunta.Text = "== FIM DO SCRIPT ==";
                txtInformacao.AppendText("                                                                                                              " + lblTextoDaPergunta.Text + Environment.NewLine);
            }
        }
        #endregion

        #region Atualizar Status Formulário
        private void AtualizarStatusFormulario(string sNovoStatusFormulario)
        {
            sStatusFormulario = sNovoStatusFormulario;

            switch (sNovoStatusFormulario)
            {
                case STATUS_DESCONECTADO_SEM_PROSPECT:
                    cmdProximoProspect.Enabled = true;
                    cmdSalvarContato.Enabled = false;
                    cmdDiscar.Enabled = false;
                    cmdDesconectar.Enabled = false;
                    cmdCancelarInd.Enabled = false;
                    cmdCadastrar.Enabled = true;
                    break;

                case STATUS_DESCONECTADO_COM_PROSPECT:
                    cmdProximoProspect.Enabled = false;
                    cmdSalvarContato.Enabled = true;
                    cmdDiscar.Enabled = true;
                    cmdDesconectar.Enabled = false;
                    cmdCadastrar.Enabled = false;
                    break;

                case STATUS_DISCANDO:
                    cmdProximoProspect.Enabled = false;
                    cmdSalvarContato.Enabled = false;
                    cmdDiscar.Enabled = false;
                    cmdDesconectar.Enabled = true;
                    break;

                case STATUS_CONECTADO_COM_PROSPECT:
                    cmdProximoProspect.Enabled = false;
                    cmdSalvarContato.Enabled = false;
                    cmdDiscar.Enabled = false;
                    cmdDesconectar.Enabled = true;
                    break;

                case STATUS_SOLICITANDO_DISCAGEM:
                    cmdProximoProspect.Enabled = false;
                    cmdSalvarContato.Enabled = false;
                    cmdDiscar.Enabled = false;
                    cmdDesconectar.Enabled = false;
                    break;
            }
        }
        #endregion

        #region Botão Desconectar
        private void cmdDesconectar_Click(object sender, EventArgs e)
        {
            AtualizarStatusFormulario(STATUS_DESCONECTADO_COM_PROSPECT);

            if (fLogin.Configuracao.TipoPabx == "PlanetFone")
            {
                DesconectarPlanetFone(sIdLigacao);
            }
            //Discagem fax modem
            else if (fLogin.Configuracao.TipoPabx == "Modem")
            {
                DesconectarModem();
            }
            else if (fLogin.Configuracao.TipoPabx == "Digistar")
            {
                DesconectarDigistar();
            }
            else if (fLogin.Configuracao.TipoPabx == "Vonix")//robson
            {
                DesconectarVonix();

                //Receptivo
                if (txtIDProspect.Text == "")
                    AtualizarStatusFormulario(STATUS_DESCONECTADO_SEM_PROSPECT);
            }

            else if (fLogin.Configuracao.TipoPabx == "Leucotron")
            {
                try
                {
                    // Translate the passed message into ASCII and store it as a Byte array.
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("00004|RQ_RAMAL_GANCHO|" + sRamal + "|SIM" + "\n");

                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                    RegistrarEventos("Finalizando chamada do ramal: " + sRamal);
                }
                catch { }
            }
        }
        #endregion

        #region Botão Discar
        private void cmdDiscar_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizarStatusFormulario(STATUS_CONECTADO_COM_PROSPECT);

                string sTelefone = "";

                if (radTel1.Checked == true)
                    sTelefone = txtTelefone1.Text;
                else if (radTel2.Checked == true)
                    sTelefone = txtTelefone2.Text;
                else if (radTel3.Checked == true)
                    sTelefone = txtTelefone3.Text;

                //Discagem fax modem
                if (fLogin.Configuracao.TipoPabx == "Modem")
                {
                    DiscarModem(sTelefone);
                }
                else if (fLogin.Configuracao.TipoPabx == "PlanetFone")
                {
                    //Discagem PlanetFone
                    DiscarPlanetFone(sTelefone);
                }
                else if (fLogin.Configuracao.TipoPabx == "Digistar")
                {
                    //Discagem Digistar
                    DiscarDigistar(sTelefone);
                }
                else if (fLogin.Configuracao.TipoPabx == "Vonix")//robson
                {
                    // Discagem Vonix
                    DiscarVonix(sTelefone);
                }
                else if (fLogin.Configuracao.TipoPabx == "Leucotron")
                {
                    string sRamal = fLogin.Usuario.Ramal;
                    string sIPServidor = fLogin.Configuracao.IPServidor.ToString();
                    int iPortaServidor = Convert.ToInt32(fLogin.Configuracao.PortaServidor);
                    string sNomeOperador = fLogin.Usuario.Nome.ToString();

                    try
                    {
                        if (ClientTCP.Connected == false)
                        {
                            ConectarLeucotron(sIPServidor, iPortaServidor);
                            RegistrarEventos("Reconectando no Leucotron no Host: " + sIPServidor + "  na porta: " + iPortaServidor);
                        }
                    }
                    catch { }

                    string sTelefoneLeucotron = 0 + sTelefone;
                    Discar(sRamal, sTelefoneLeucotron, sNomeOperador);
                }
            }
            catch
            { }
        }
        #endregion

        #region Tratar Númerode Telefone
        private string TratarNumeroDeTelefone(string NumeroOriginal, string CodAcesso)
        {
            string NovoNumero = NumeroOriginal.Trim();
            int tamTel = NovoNumero.Length;
            switch (tamTel)
            {
                case 7:
                case 8:
                    NovoNumero = CodAcesso + NovoNumero;
                    break;
                case 10:
                    if (NovoNumero.Substring(0, 2).Equals("31"))
                    {
                        NovoNumero = CodAcesso + NovoNumero.Substring(2);
                    }
                    else
                        NovoNumero = CodAcesso + "0" + NovoNumero;
                    break;
                case 11:
                    NovoNumero = CodAcesso + NovoNumero;
                    break;
            }
            return NovoNumero;
        }
        #endregion

        #region Discar Planet Fone
        //Efetua a discagem via Webservice da Planet Fone
        private void DiscarPlanetFone(string sTelefone)
        {
            try
            {
                wenvpabx2 wss = ws.PlanetFone.getInstancia().getWS();
                Disca discar = new Disca();
                string sRamal = fLogin.Usuario.Ramal;

                if (sTelefone.Length == 10)
                {
                    //Se for DDD 31, retira o DDD - Ligação local não precisa de DDD
                    if (sTelefone.Substring(0, 2) == "31")
                    {
                        discar.NroTelefDestino = sTelefone.Substring(2, 8);
                    }
                    //Se for DDD diferente de 31 e o telefone tiver 10 digitos - "0" + "Operadora" + "DDD"
                    else if (sTelefone.Substring(0, 2) != "31" && sTelefone.Length == 10)
                    {
                        discar.NroTelefDestino = 0 + sOperadora + sTelefone;
                    }
                }
                else
                {
                    //Se for DDD 31, retira o DDD - Ligação local não precisa de DDD
                    if (sTelefone.Substring(0, 2) == "31")
                    {
                        discar.NroTelefDestino = sTelefone.Substring(2, 9);
                    }
                    //Se for DDD diferente de 31 e o telefone tiver 10 digitos - "0" + "Operadora" + "DDD"
                    else if (sTelefone.Substring(0, 2) != "31" && sTelefone.Length == 10)
                    {
                        discar.NroTelefDestino = 0 + sOperadora + sTelefone;
                    }
                }

                discar.QtdSegTimeout = 30;
                discar.QtdSegTimeoutDestino = 50;
                discar.NroAgente = Convert.ToString(NroAgente);
                discar.InverteOrdemChamada = 0;
                discar.PermissoesSistema = 1;
                discar.NroTelefOrigemNaoRamal = 0;
                discar.CodFila = CodFila;
                discar.NroTelefOrigem = sRamal;
                discar.AplicacaoDestino = "";
                discar.AplicacaoParam = "";
                discar.CanalOrigem = "";
                discar.Identificador = "";
                discar.IdtDestino = "";
                discar.NroIdentOrigem = "";
                discar.VariaveisDestino = "";
                discar.VariaveisOrigem = "";

                //Efetuar a discagem e recebe a resposta da mesma
                DiscaResponse discaResponse = new DiscaResponse();
                discaResponse = wss.Disca(discar);

                //Retorna o resultado da discagem
                DiscaResultado discaResultado = new DiscaResultado();
                discaResultado = discaResponse.DiscaResultado;

                sIdLigacao = discaResultado.IdLigacao;

                // Verifica se o retorno é "S"em resposta ou se é "E"rro e desconectar a ligação
                if (discaResultado.IdtResultado == "S" || discaResultado.IdtResultado == "E")
                {
                    RegistrarEventos(discaResultado.TextoErroDestino + " Ramal:" + sRamal);
                    AtualizarStatusFormulario(STATUS_DESCONECTADO_COM_PROSPECT);
                    DesconectarPlanetFone(sIdLigacao);
                }

                string sComando;
                string sCodigoAcessoExterno = "0";

                //Envia os eventos para o listBoxEventos
                if (sTelefone.Substring(0, 2) == "31")
                {
                    sComando = "Discando para " + sTelefone + "..." + Environment.NewLine; RegistrarEventos(sComando);
                }
                else
                {
                    sComando = "Discando para " + sCodigoAcessoExterno + sOperadora + sTelefone + "..." + Environment.NewLine; RegistrarEventos(sComando);
                }
            }
            catch (Exception ex)
            {
                RegistrarEventos("Não foi possível efetuar a chamada.");
            }
        }
        #endregion

        #region DiscarVonix
        private void DiscarVonix(string sTelefone)//robson
        {
            string sComando;
            try
            {
                if (radTel1.Checked && String.IsNullOrEmpty(txtTelefone1.Text) || radTel2.Checked && String.IsNullOrEmpty(txtTelefone2.Text)
                    || radTel3.Checked && String.IsNullOrEmpty(txtTelefone3.Text))
                {
                    sComando = "Não há telefone para discar..." + Environment.NewLine;
                    RegistrarEventos(sComando);
                    cmdDiscar.Enabled = true;
                    cmdDesconectar.Enabled = false;
                }
                else
                {
                    //Se for DDD 31, retira o DDD - Ligação local não precisa de DDD
                    if (sTelefone.Substring(0, 2) == "31")
                    {
                        doDial("1", sTelefone.Substring(2, 8), "Tabulare/Vonix", fLogin.Usuario.Fila, 1);
                    }
                    //Se for DDD diferente de 31 e o telefone tiver 10 digitos - "0" + "Operadora" + "DDD"
                    else if (sTelefone.Substring(0, 2) != "31" && sTelefone.Length == 10)
                    {
                        doDial("1", sTelefone, "Tabulare/Vonix", fLogin.Usuario.Fila, 1);
                    }

                    //string sComando;
                    string sCodigoAcessoExterno = "0";

                    //Envia os eventos para o listBoxEventos
                    if (sTelefone.Substring(0, 2) == "31")
                    {
                        sComando = "Discando para " + sTelefone + "..." + Environment.NewLine;
                        RegistrarEventos(sComando);
                    }
                    else
                    {
                        sComando = "Discando para " + sCodigoAcessoExterno + sOperadora + sTelefone + "..." + Environment.NewLine;
                        RegistrarEventos(sComando);
                    }
                }
            }
            catch (Exception ex)
            {
                RegistrarEventos(ex.Message);
            }
        }

        private void DesconectarVonix()//robson
        {
            doHangUp("1", "");

            //Envia o evento para o listBoxEventos
            string sComando = "Desconectado...";
            RegistrarEventos(sComando);
        }

        #endregion

        #region Discar Modem
        //Efetua a discagem via fax modem
        private void DiscarModem(string sTelefone)
        {
            try
            {
                //Função provisória para atender cliente ReD
                //Se for DDD 31, retira o DDD
                if (sTelefone.Substring(0, 2) == "31")
                {
                    sTelefone = sTelefone.Substring(2, 8);
                }
                else //Coloca a operadora antes do DDD
                {
                    sTelefone = 0 + sOperadora + sTelefone;
                }

                if (serialPort.IsOpen)
                    serialPort.Close();

                serialPort.PortName = sPortaModem;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;

                serialPort.Open();
                serialPort.DtrEnable = true;
                Thread.Sleep(1000);

                string sComando;
                string sCodigoAcessoExterno = "0";

                sComando = "AT&FX3 " + Environment.NewLine; RegistrarEventos(sComando);
                Thread.Sleep(1000);
                serialPort.WriteLine(sComando);

                sComando = "ATDT " + sCodigoAcessoExterno + "W" + sTelefone + Environment.NewLine; RegistrarEventos(sComando);
                Thread.Sleep(1000);
                serialPort.WriteLine(sComando);
            }
            catch (Exception ex)
            {
                RegistrarEventos(ex.Message);
            }
        }
        #endregion

        #region Desconectar PlanetFone
        //Desconecta a ligação do WebService do PlanetFone 
        private void DesconectarPlanetFone(string sIdLigacao)
        {
            wenvpabx2 wss = ws.PlanetFone.getInstancia().getWS();
            string sRamal = fLogin.Usuario.Ramal;

            DesligaChamada desligaChamada = new DesligaChamada();
            desligaChamada.IdLigacao = sIdLigacao;

            wss.DesligaChamada(desligaChamada);

            //Envia o evento para o listBoxEventos
            string sComando = "Desconectado...";
            RegistrarEventos(sComando);
        }
        #endregion

        #region Desconectar Modem
        // Desconecta a ligação do fax modem
        private void DesconectarModem()
        {
            try
            {
                if (serialPort.IsOpen)
                    serialPort.Close();

                serialPort.PortName = sPortaModem;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;

                serialPort.Open();
                serialPort.DtrEnable = true;
                Thread.Sleep(1000);

                string sComando;

                sComando = "ATH" + Environment.NewLine; RegistrarEventos(sComando);
                Thread.Sleep(1000);
                serialPort.WriteLine(sComando);
            }
            catch (Exception ex)
            {
                RegistrarEventos(ex.Message);
            }
        }

        private void DesconectarCallflex()
        {
            //Envia o evento para o listBoxEventos
            //Segundo Wilson, não há comando para desconectar, apenas pelo Softfone
            string sComando = "Desconectado...";
            RegistrarEventos(sComando);
        }

        #endregion

        #region Registrar Eventos
        //Registra Eventos
        private void RegistrarEventos(string sEvento)
        {
            if (this.listBoxEventos.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(RegistrarEventos);
                this.Invoke(d, new object[] { sEvento });
            }
            else
            {
                Invoke((MethodInvoker)delegate { listBoxEventos.Items.Insert(0, sEvento); });

                if (sComandoDigistar.IndexOf("SDN") > -1)
                    Invoke((MethodInvoker)delegate { listBoxEventos.Items.Insert(0, sEvento); });
                if (sComandoDigistar.IndexOf("SDO") > -1)
                    Invoke((MethodInvoker)delegate { listBoxEventos.Items.Insert(0, sEvento); });
                if (sComandoDigistar.IndexOf("SEP") > -1)
                    Invoke((MethodInvoker)delegate { listBoxEventos.Items.Insert(0, sEvento); });
                if (sComandoDigistar.IndexOf("SNA") > -1)
                    Invoke((MethodInvoker)delegate { listBoxEventos.Items.Insert(0, sEvento); });
            }
        }
        #endregion

        #region Atualizar Status Formulário
        private void fAtendimento_Shown(object sender, EventArgs e)
        {
            AtualizarStatusFormulario(STATUS_DESCONECTADO_SEM_PROSPECT);
        }
        #endregion

        #region ListBoxEventos
        private void listBoxEventos_DoubleClick(object sender, EventArgs e)
        {
            listBoxEventos.Items.Clear();
        }
        #endregion

        #region Listar Histórico do Contato
        private void ListarHistoricoContato(int iIDMailing)
        {
            if (txtTelefone1.Text != "")
            {
                prospectCTL CProspect = new prospectCTL();
                dgHistorico.DataSource = CProspect.RetornarHistoricoContato(Convert.ToDouble(txtTelefone1.Text), iIDMailing, fLogin.Configuracao.Script);

                foreach (DataGridViewRow dataGridViewRow in dgHistorico.Rows)
                {
                    if (dataGridViewRow.Cells["Mailing"].Value.ToString() != Prospect.Mailing)
                        dataGridViewRow.Cells["Mailing"].Style.BackColor = System.Drawing.Color.PaleGoldenrod;
                }
            }
            else
                dgHistorico.DataSource = null;
        }

        #endregion

        #region Exibir Contatos Trabalhdos
        private void cmdContatosTrab_Click(object sender, EventArgs e)
        {
            ExibirForm(new fContatosTrabalhados());
        }
        #endregion

        #region Exibir Form
        private void ExibirForm(Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
        #endregion

        #region LiberarProspectEmUso
        public void LiberarProspectEmUso()
        {
            prospectCTL CProspect = new prospectCTL();
            CProspect.LiberarProspectEmUso(fLogin.Usuario.IDUsuario);
        }
        #endregion

        #region Form Atendimento Closing
        private void fAtendimento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fLogin.Usuario.TipoDiscador == "Preditivo")
            {
                if (fLogin.Configuracao.TipoPabx == "Modem")
                {
                    if (serialPort.IsOpen)
                        serialPort.Close();
                }
                else if (fLogin.Configuracao.TipoPabx == "PlanetFone")
                {
                    FinalizarConexao();
                }
                else if (fLogin.Configuracao.TipoPabx == "Digistar")
                {
                    finalizarComunicacaoDigistar();
                }
                else if (fLogin.Configuracao.TipoPabx == "Vonix")
                {
                    // Timer Vonix                                                                                              
                    TimerAtualizarProspectVonix.Enabled = false;
                }
                else if (fLogin.Configuracao.TipoPabx == "Leucotron")
                {
                    DesconectarLeucotron();
                }
            }
            LiberarProspectEmUso();
        }
        #endregion

        #region Botão Próximo Prospect (Com Desconectar Digistar)
        private void cmdProximoProspect_Click(object sender, EventArgs e)
        {
            listBoxEventos.Text = "";
            RetornarProxProspect();

            //Salva a Data de Abertura na tabela tHistorico
            sDataAbertura = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
        #endregion

        #region Grid Histórico
        private void dgHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgHistorico.Rows[e.RowIndex].Cells[2].Value.ToString() != "## PESQUISA REALIZADA ##")
                {
                    //dgPerguntaResposta.Visible = true;
                    //lblScript.Visible = true; 

                    int iIDHistorico = Convert.ToInt32(dgHistorico.Rows[e.RowIndex].Cells[0].Value.ToString());
                    prospect Prospect = new prospect();
                    Prospect.IDHistorico = iIDHistorico;
                    CarregarPerguntaResposta(iIDHistorico);
                }
                else
                {
                    dgPerguntaResposta.Visible = false;
                    lblScript.Visible = false;
                }
            }
        }
        #endregion

        #region Carregar Pergunta resposta
        private void CarregarPerguntaResposta(int iIDHistorico)
        {
            prospectCTL CProspect = new prospectCTL();
            dgPerguntaResposta.DataSource = CProspect.RetornarPerguntaResposta(iIDHistorico);
            dgPerguntaResposta.Columns["IDHistorico"].Visible = false;
        }
        #endregion

        #region Botão consultar cliente
        private void cmdConsultarCliente_Click(object sender, EventArgs e)
        {
            if (txtIDProspect.Text == "" && Indicacao == false)
            {
                Form form = new relatorio.fConsultarCliente();

                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();

                if (relatorio.fConsultarCliente.sIDPropect != null)
                {
                    if (txtIDProspect.Text == "")
                    {
                        AbrirProspect(Convert.ToInt32(relatorio.fConsultarCliente.sIDPropect));

                        //Verifico se IDAcao = 2 (Agend. Anal.) do último usuário
                        //Mantenho no agendamento do operador anterior (WeA)
                        prospectCTL CProspect = new prospectCTL();
                        RetornarUsuarioAgendamento(Convert.ToInt32(relatorio.fConsultarCliente.sIDPropect));

                        if (iIDAcaoAgendamento == 2)
                            CProspect.AtualizarUsuarioAgendamento(iIDProspectAgendamento, iIDUsuarioAgendamento, iIDStatusAgendamento);

                        //Só abre o cliente se o prospect estiver na mesma campanha do usuário - RD RIO
                        if (fLogin.Usuario.IDCampanha != Prospect.IDCampanha)
                        {
                            string sMensagem = "O [Telefone] já existe em outra Campanha.";
                            MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cmdBuscarCep.Enabled = false;
                        }
                        else
                            LiberarFormulario();

                        CarregarFuncionalidadesDeClientes();
                    }
                }
            }
            else
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("Para [Consultar Cliente], encerre seu último contato.", "Tabulare Software");
            txtNome.Focus();
        }
        #endregion

        #region Botão cadastrar
        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            //Salva a Data de Abertura na tabela tHistorico
            sDataAbertura = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            Indicacao = true;
            if (fLogin.Usuario.TipoDiscador != "Power")
            {
                if (txtIDProspect.Text == "")
                {
                    //Coloca o usuario em pausa quando clicado no botão de cadastro manual
                    usuarioCTL CUsuario = new usuarioCTL();
                    CUsuario.PausaAgente(fLogin.Usuario.IDUsuario, -1);
                }
                else
                    MessageBox.Show("Você deve finalizar primeiro o Prospect da Tela", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AtualizarStatusFormulario(STATUS_DESCONECTADO_COM_PROSPECT);

            cmdAgendamento.Enabled = false;

            cmdCancelarInd.Enabled = true;
            cmdCadastrar.Enabled = false;


            LiberarFormulario();

            CarregarFuncionalidadesDeClientes();
        }
        #endregion

        #region Botão cancelar indicação
        private void cmdCancelarInd_Click(object sender, EventArgs e)
        {
            cmdDiscar.Enabled = false;
            if (fLogin.Usuario.TipoDiscador != "Power")
            {
                if (txtIDProspect.Text == "")
                {
                    LiberarProspectEmUso();

                    //Retira o usuario de pausa quando clicado no botão de cancelar cadastro manual
                    usuarioCTL CUsuario = new usuarioCTL();
                    CUsuario.PausaAgente(fLogin.Usuario.IDUsuario, 0);
                }
                else
                    MessageBox.Show("Você deve finalizar primeiro o Prospect da Tela", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BloquearFormulario();
        }
        #endregion

        #region Abrir prospect agendamento
        private void AbrirProspectAgendamento(int iIDProspect)
        {
            prospectCTL CProspect = new prospectCTL();

            Prospect = CProspect.RetornarProspect(iIDProspect, fLogin.Usuario.IDUsuario);
            int iIDHistoricoVenda = -1;

            if (Prospect.IDProspect == 0)
            {
                cmdSalvarContato.Enabled = false;
                comboStatus.Enabled = false;
                AtualizarStatusFormulario(STATUS_DESCONECTADO_SEM_PROSPECT);
            }
            else
            {
                LiberarFormulario();

                cmdSalvarContato.Enabled = true;
                cmdCadastrar.Enabled = false;
                comboStatus.Enabled = true;
                txtMailing.Text = "" + Prospect.Mailing + "" + Prospect.Campanha + "";

                txtTelefone1.Text = Prospect.Telefone1.ToString();
                txtTelefone2.Text = Prospect.Telefone2.ToString();
                txtTelefone3.Text = Prospect.Telefone3.ToString();
                radTel1.Checked = true;
                txtIDProspect.Text = Prospect.IDProspect.ToString();
                txtNome.Text = Prospect.Nome;
                txtLogradouro.Text = Prospect.Logradouro;
                txtBairro.Text = Prospect.Bairro;
                txtCidade.Text = Prospect.Cidade;
                txtEstado.Text = Prospect.Estado;
                txtEmail.Text = Prospect.Email;
                txtCep.Text = Prospect.Cep;//rr
                txtCPF_CNPJ.Text = Prospect.CPF_CNPJ.ToString();

                string sLabel, sTextBox;
                foreach (Control controlLabel in grbDadosProspect.Controls)
                {
                    if (controlLabel.Name.IndexOf("lblCampo") > -1)
                    {
                        foreach (Control controlTextBox in grbDadosProspect.Controls)
                        {
                            sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                            sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txtCampo") > -1)
                            {
                                TextBox textBox = (TextBox)controlTextBox;
                                if (textBox.Name == "txtCampo01") textBox.Text = Prospect.Campo01.ToString();
                                if (textBox.Name == "txtCampo02") textBox.Text = Prospect.Campo02.ToString();
                                if (textBox.Name == "txtCampo03") textBox.Text = Prospect.Campo03.ToString();
                                if (textBox.Name == "txtCampo04") textBox.Text = Prospect.Campo04.ToString();
                                if (textBox.Name == "txtCampo05") textBox.Text = Prospect.Campo05.ToString();
                                if (textBox.Name == "txtCampo06") textBox.Text = Prospect.Campo06.ToString();
                                if (textBox.Name == "txtCampo07") textBox.Text = Prospect.Campo07.ToString();
                                if (textBox.Name == "txtCampo08") textBox.Text = Prospect.Campo08.ToString();
                                if (textBox.Name == "txtCampo09") textBox.Text = Prospect.Campo09.ToString();
                                if (textBox.Name == "txtCampo10") textBox.Text = Prospect.Campo10.ToString();
                            }
                        }
                    }
                }

                try//robson
                {
                    iIDHistoricoVenda = CProspect.RetornarHistoricoVenda(iIDProspect);

                    if (iIDHistoricoVenda != -1)
                    {
                        //Preencher dados da venda quando for Agendamento
                        relatorioCTL CRelatorio = new relatorioCTL();
                        DataTable dataTable = CRelatorio.RetornarDadosVenda(iIDHistoricoVenda);

                        if (dataTable.Rows.Count > 0)
                        {
                            //Preencher campos Dados da Venda
                            foreach (Control controlLabel in DadosDaVenda.Controls)
                            {
                                if (controlLabel.Name.IndexOf("lblVenda") > -1)
                                {
                                    foreach (Control controlTextBox in DadosDaVenda.Controls)
                                    {
                                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                                        {
                                            TextBox textBox = (TextBox)controlTextBox;
                                            if (textBox.Name == "txtVenda01") textBox.Text = dataTable.Rows[0]["Venda01"].ToString();
                                            if (textBox.Name == "txtVenda02") textBox.Text = dataTable.Rows[0]["Venda02"].ToString();
                                            if (textBox.Name == "txtVenda03") textBox.Text = dataTable.Rows[0]["Venda03"].ToString();
                                            if (textBox.Name == "txtVenda04") textBox.Text = dataTable.Rows[0]["Venda04"].ToString();
                                            if (textBox.Name == "txtVenda05") textBox.Text = dataTable.Rows[0]["Venda05"].ToString();
                                            if (textBox.Name == "txtVenda06") textBox.Text = dataTable.Rows[0]["Venda06"].ToString();
                                            if (textBox.Name == "txtVenda07") textBox.Text = dataTable.Rows[0]["Venda07"].ToString();
                                            if (textBox.Name == "txtVenda08") textBox.Text = dataTable.Rows[0]["Venda08"].ToString();
                                            if (textBox.Name == "txtVenda09") textBox.Text = dataTable.Rows[0]["Venda09"].ToString();
                                            if (textBox.Name == "txtVenda10") textBox.Text = dataTable.Rows[0]["Venda10"].ToString();
                                            if (textBox.Name == "txtVenda11") textBox.Text = dataTable.Rows[0]["Venda11"].ToString();
                                            if (textBox.Name == "txtVenda12") textBox.Text = dataTable.Rows[0]["Venda12"].ToString();
                                            if (textBox.Name == "txtVenda13") textBox.Text = dataTable.Rows[0]["Venda13"].ToString();
                                            if (textBox.Name == "txtVenda14") textBox.Text = dataTable.Rows[0]["Venda14"].ToString();
                                            if (textBox.Name == "txtVenda15") textBox.Text = dataTable.Rows[0]["Venda15"].ToString();
                                            if (textBox.Name == "txtVenda16") textBox.Text = dataTable.Rows[0]["Venda16"].ToString();
                                            if (textBox.Name == "txtVenda17") textBox.Text = dataTable.Rows[0]["Venda17"].ToString();
                                            if (textBox.Name == "txtVenda18") textBox.Text = dataTable.Rows[0]["Venda18"].ToString();
                                            if (textBox.Name == "txtVenda19") textBox.Text = dataTable.Rows[0]["Venda19"].ToString();
                                            if (textBox.Name == "txtVenda20") textBox.Text = dataTable.Rows[0]["Venda20"].ToString();
                                            if (textBox.Name == "txtVenda21") textBox.Text = dataTable.Rows[0]["Venda21"].ToString();
                                            if (textBox.Name == "txtVenda22") textBox.Text = dataTable.Rows[0]["Venda22"].ToString();
                                            if (textBox.Name == "txtVenda23") textBox.Text = dataTable.Rows[0]["Venda23"].ToString();
                                            if (textBox.Name == "txtVenda24") textBox.Text = dataTable.Rows[0]["Venda24"].ToString();
                                            if (textBox.Name == "txtVenda25") textBox.Text = dataTable.Rows[0]["Venda25"].ToString();
                                            if (textBox.Name == "txtVenda26") textBox.Text = dataTable.Rows[0]["Venda26"].ToString();
                                            if (textBox.Name == "txtVenda27") textBox.Text = dataTable.Rows[0]["Venda27"].ToString();
                                            if (textBox.Name == "txtVenda28") textBox.Text = dataTable.Rows[0]["Venda28"].ToString();
                                            if (textBox.Name == "txtVenda29") textBox.Text = dataTable.Rows[0]["Venda29"].ToString();
                                            if (textBox.Name == "txtVenda30") textBox.Text = dataTable.Rows[0]["Venda30"].ToString();
                                            if (textBox.Name == "txtVenda31") textBox.Text = dataTable.Rows[0]["Venda31"].ToString();
                                            if (textBox.Name == "txtVenda32") textBox.Text = dataTable.Rows[0]["Venda32"].ToString();
                                            if (textBox.Name == "txtVenda33") textBox.Text = dataTable.Rows[0]["Venda33"].ToString();
                                            if (textBox.Name == "txtVenda34") textBox.Text = dataTable.Rows[0]["Venda34"].ToString();
                                            if (textBox.Name == "txtVenda35") textBox.Text = dataTable.Rows[0]["Venda35"].ToString();
                                            if (textBox.Name == "txtVenda36") textBox.Text = dataTable.Rows[0]["Venda36"].ToString();
                                            if (textBox.Name == "txtVenda37") textBox.Text = dataTable.Rows[0]["Venda37"].ToString();
                                            if (textBox.Name == "txtVenda38") textBox.Text = dataTable.Rows[0]["Venda38"].ToString();
                                            if (textBox.Name == "txtVenda39") textBox.Text = dataTable.Rows[0]["Venda39"].ToString();
                                            if (textBox.Name == "txtVenda40") textBox.Text = dataTable.Rows[0]["Venda40"].ToString();
                                            if (textBox.Name == "txtVenda41") textBox.Text = dataTable.Rows[0]["Venda41"].ToString();
                                            if (textBox.Name == "txtVenda42") textBox.Text = dataTable.Rows[0]["Venda42"].ToString();
                                            if (textBox.Name == "txtVenda43") textBox.Text = dataTable.Rows[0]["Venda43"].ToString();
                                            if (textBox.Name == "txtVenda44") textBox.Text = dataTable.Rows[0]["Venda44"].ToString();
                                            if (textBox.Name == "txtVenda45") textBox.Text = dataTable.Rows[0]["Venda45"].ToString();
                                            if (textBox.Name == "txtVenda46") textBox.Text = dataTable.Rows[0]["Venda46"].ToString();
                                            if (textBox.Name == "txtVenda47") textBox.Text = dataTable.Rows[0]["Venda47"].ToString();
                                            if (textBox.Name == "txtVenda48") textBox.Text = dataTable.Rows[0]["Venda48"].ToString();
                                            if (textBox.Name == "txtVenda49") textBox.Text = dataTable.Rows[0]["Venda49"].ToString();
                                            if (textBox.Name == "txtVenda50") textBox.Text = dataTable.Rows[0]["Venda50"].ToString();
                                            if (textBox.Name == "txtVenda51") textBox.Text = dataTable.Rows[0]["Venda51"].ToString();
                                            if (textBox.Name == "txtVenda52") textBox.Text = dataTable.Rows[0]["Venda52"].ToString();
                                            if (textBox.Name == "txtVenda53") textBox.Text = dataTable.Rows[0]["Venda53"].ToString();
                                            if (textBox.Name == "txtVenda54") textBox.Text = dataTable.Rows[0]["Venda54"].ToString();
                                            if (textBox.Name == "txtVenda55") textBox.Text = dataTable.Rows[0]["Venda55"].ToString();
                                            if (textBox.Name == "txtVenda56") textBox.Text = dataTable.Rows[0]["Venda56"].ToString();
                                            if (textBox.Name == "txtVenda57") textBox.Text = dataTable.Rows[0]["Venda57"].ToString();
                                            if (textBox.Name == "txtVenda58") textBox.Text = dataTable.Rows[0]["Venda58"].ToString();
                                            if (textBox.Name == "txtVenda59") textBox.Text = dataTable.Rows[0]["Venda59"].ToString();
                                            if (textBox.Name == "txtVenda60") textBox.Text = dataTable.Rows[0]["Venda60"].ToString();
                                        }
                                        else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                                        {
                                            ComboBox comboBox = (ComboBox)controlTextBox;
                                            if (comboBox.Items.Count > 0)
                                            {
                                                string spausa;
                                            }
                                            if (comboBox.Name == "comboVenda01") comboBox.Text = dataTable.Rows[0]["Venda01"].ToString();
                                            if (comboBox.Name == "comboVenda02") comboBox.Text = dataTable.Rows[0]["Venda02"].ToString();
                                            if (comboBox.Name == "comboVenda03") comboBox.Text = dataTable.Rows[0]["Venda03"].ToString();
                                            if (comboBox.Name == "comboVenda04") comboBox.Text = dataTable.Rows[0]["Venda04"].ToString();
                                            if (comboBox.Name == "comboVenda05") comboBox.Text = dataTable.Rows[0]["Venda05"].ToString();
                                            if (comboBox.Name == "comboVenda06") comboBox.Text = dataTable.Rows[0]["Venda06"].ToString();
                                            if (comboBox.Name == "comboVenda07") comboBox.Text = dataTable.Rows[0]["Venda07"].ToString();
                                            if (comboBox.Name == "comboVenda08") comboBox.Text = dataTable.Rows[0]["Venda08"].ToString();
                                            if (comboBox.Name == "comboVenda09") comboBox.Text = dataTable.Rows[0]["Venda09"].ToString();
                                            if (comboBox.Name == "comboVenda10") comboBox.Text = dataTable.Rows[0]["Venda10"].ToString();
                                            if (comboBox.Name == "comboVenda11") comboBox.Text = dataTable.Rows[0]["Venda11"].ToString();
                                            if (comboBox.Name == "comboVenda12") comboBox.Text = dataTable.Rows[0]["Venda12"].ToString();
                                            if (comboBox.Name == "comboVenda13") comboBox.Text = dataTable.Rows[0]["Venda13"].ToString();
                                            if (comboBox.Name == "comboVenda14") comboBox.Text = dataTable.Rows[0]["Venda14"].ToString();
                                            if (comboBox.Name == "comboVenda15") comboBox.Text = dataTable.Rows[0]["Venda15"].ToString();
                                            if (comboBox.Name == "comboVenda16") comboBox.Text = dataTable.Rows[0]["Venda16"].ToString();
                                            if (comboBox.Name == "comboVenda17") comboBox.Text = dataTable.Rows[0]["Venda17"].ToString();
                                            if (comboBox.Name == "comboVenda18") comboBox.Text = dataTable.Rows[0]["Venda18"].ToString();
                                            if (comboBox.Name == "comboVenda19") comboBox.Text = dataTable.Rows[0]["Venda19"].ToString();
                                            if (comboBox.Name == "comboVenda20") comboBox.Text = dataTable.Rows[0]["Venda20"].ToString();
                                            if (comboBox.Name == "comboVenda21") comboBox.Text = dataTable.Rows[0]["Venda21"].ToString();
                                            if (comboBox.Name == "comboVenda22") comboBox.Text = dataTable.Rows[0]["Venda22"].ToString();
                                            if (comboBox.Name == "comboVenda23") comboBox.Text = dataTable.Rows[0]["Venda23"].ToString();
                                            if (comboBox.Name == "comboVenda24") comboBox.Text = dataTable.Rows[0]["Venda24"].ToString();
                                            if (comboBox.Name == "comboVenda25") comboBox.Text = dataTable.Rows[0]["Venda25"].ToString();
                                            if (comboBox.Name == "comboVenda26") comboBox.Text = dataTable.Rows[0]["Venda26"].ToString();
                                            if (comboBox.Name == "comboVenda27") comboBox.Text = dataTable.Rows[0]["Venda27"].ToString();
                                            if (comboBox.Name == "comboVenda28") comboBox.Text = dataTable.Rows[0]["Venda28"].ToString();
                                            if (comboBox.Name == "comboVenda29") comboBox.Text = dataTable.Rows[0]["Venda29"].ToString();
                                            if (comboBox.Name == "comboVenda30") comboBox.Text = dataTable.Rows[0]["Venda30"].ToString();
                                            if (comboBox.Name == "comboVenda31") comboBox.Text = dataTable.Rows[0]["Venda31"].ToString();
                                            if (comboBox.Name == "comboVenda32") comboBox.Text = dataTable.Rows[0]["Venda32"].ToString();
                                            if (comboBox.Name == "comboVenda33") comboBox.Text = dataTable.Rows[0]["Venda33"].ToString();
                                            if (comboBox.Name == "comboVenda34") comboBox.Text = dataTable.Rows[0]["Venda34"].ToString();
                                            if (comboBox.Name == "comboVenda35") comboBox.Text = dataTable.Rows[0]["Venda35"].ToString();
                                            if (comboBox.Name == "comboVenda36") comboBox.Text = dataTable.Rows[0]["Venda36"].ToString();
                                            if (comboBox.Name == "comboVenda37") comboBox.Text = dataTable.Rows[0]["Venda37"].ToString();
                                            if (comboBox.Name == "comboVenda38") comboBox.Text = dataTable.Rows[0]["Venda38"].ToString();
                                            if (comboBox.Name == "comboVenda39") comboBox.Text = dataTable.Rows[0]["Venda39"].ToString();
                                            if (comboBox.Name == "comboVenda40") comboBox.Text = dataTable.Rows[0]["Venda40"].ToString();
                                            if (comboBox.Name == "comboVenda41") comboBox.Text = dataTable.Rows[0]["Venda41"].ToString();
                                            if (comboBox.Name == "comboVenda42") comboBox.Text = dataTable.Rows[0]["Venda42"].ToString();
                                            if (comboBox.Name == "comboVenda43") comboBox.Text = dataTable.Rows[0]["Venda43"].ToString();
                                            if (comboBox.Name == "comboVenda44") comboBox.Text = dataTable.Rows[0]["Venda44"].ToString();
                                            if (comboBox.Name == "comboVenda45") comboBox.Text = dataTable.Rows[0]["Venda45"].ToString();
                                            if (comboBox.Name == "comboVenda46") comboBox.Text = dataTable.Rows[0]["Venda46"].ToString();
                                            if (comboBox.Name == "comboVenda47") comboBox.Text = dataTable.Rows[0]["Venda47"].ToString();
                                            if (comboBox.Name == "comboVenda48") comboBox.Text = dataTable.Rows[0]["Venda48"].ToString();
                                            if (comboBox.Name == "comboVenda49") comboBox.Text = dataTable.Rows[0]["Venda49"].ToString();
                                            if (comboBox.Name == "comboVenda50") comboBox.Text = dataTable.Rows[0]["Venda50"].ToString();
                                            if (comboBox.Name == "comboVenda51") comboBox.Text = dataTable.Rows[0]["Venda51"].ToString();
                                            if (comboBox.Name == "comboVenda52") comboBox.Text = dataTable.Rows[0]["Venda52"].ToString();
                                            if (comboBox.Name == "comboVenda53") comboBox.Text = dataTable.Rows[0]["Venda53"].ToString();
                                            if (comboBox.Name == "comboVenda54") comboBox.Text = dataTable.Rows[0]["Venda54"].ToString();
                                            if (comboBox.Name == "comboVenda55") comboBox.Text = dataTable.Rows[0]["Venda55"].ToString();
                                            if (comboBox.Name == "comboVenda56") comboBox.Text = dataTable.Rows[0]["Venda56"].ToString();
                                            if (comboBox.Name == "comboVenda57") comboBox.Text = dataTable.Rows[0]["Venda57"].ToString();
                                            if (comboBox.Name == "comboVenda58") comboBox.Text = dataTable.Rows[0]["Venda58"].ToString();
                                            if (comboBox.Name == "comboVenda59") comboBox.Text = dataTable.Rows[0]["Venda59"].ToString();
                                            if (comboBox.Name == "comboVenda60") comboBox.Text = dataTable.Rows[0]["Venda60"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }

                ListarHistoricoContato(chkMailingDiferente.Checked == false ? Prospect.IDMailing : -1);
                AtualizarStatusFormulario(STATUS_DESCONECTADO_COM_PROSPECT);
                cmdSalvarContato.Enabled = true;

                lblRegistros.Text = dgHistorico.RowCount.ToString() + " registro(s)";

                CarregarFuncionalidadesDeClientes();
            }
        }
        #endregion

        #region KeyPress Telefones
        private void txtTelefone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTelefone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTelefone3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Serial port - Registrar eventos
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sMensagem = serialPort.ReadExisting();
            RegistrarEventos(sMensagem);
        }
        #endregion

        #region Botão dados da venda
        private void cmdDadosVenda_Click(object sender, EventArgs e)
        {
            ExibirForm(new supervisor.fBackofficeVenda_filtro());
        }
        #endregion

        #region Tab Control Atendimento
        private void tabControlAtendimento_Click(object sender, EventArgs e)
        {
            cmdSalvarContato.Select();
        }
        #endregion

        #region Botão Agendamento
        private void cmdAgendamento_Click(object sender, EventArgs e)
        {
            Form form = new fAgendamentos();

            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();

            if (fAgendamentos.sIDPropect != null)
            {
                if (txtIDProspect.Text == "" && Indicacao == false)
                {
                    AbrirProspectAgendamento(Convert.ToInt32(fAgendamentos.sIDPropect));
                    txtNome.Focus();
                }

                else
                {
                    fAgendamentos.sIDPropect = null;

                    string sMensagem;
                    sMensagem = "Favor finalizar o atendimento\n";
                    sMensagem += "antes de clicar no botão \n";
                    sMensagem += "[Agendamentos].";
                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (fAgendamentos.sIDPropect == null)
            {
                txtNome.Focus();
            }
        }
        #endregion

        #region Retornar quantidade de agendamentos do operador
        private void RetornarQuantidadeAgendamentoOperador()
        {
            prospectCTL CProspect = new prospectCTL();
            int iQuantidadeAgendamentos = CProspect.RetornarQuantidadeAgendamentoOperador(fLogin.Usuario.IDUsuario);
            if (iQuantidadeAgendamentos > 0)
            {
                Invoke((MethodInvoker)delegate { lblAgendamento.Visible = true; });
                Invoke((MethodInvoker)delegate { lblAgendamento.ForeColor = System.Drawing.Color.Red; });
                Invoke((MethodInvoker)delegate { lblAgendamento.Text = "" + iQuantidadeAgendamentos.ToString() + ""; });
            }
            else
            {
                Invoke((MethodInvoker)delegate { lblAgendamento.Visible = false; });
            }
        }
        #endregion


        #region Abrir prospect preditivo
        private void AbrirProspectPreditivo(int iIDProspect)
        {
            //Preditivo VONIX
            if (fLogin.Configuracao.TipoPabx == "Vonix")
            {
                if (PodeAbrirClientePreditivo())
                {
                    prospectCTL CProspect = new prospectCTL();
                    Prospect = CProspect.RetornarProspect(iIDProspect, fLogin.Usuario.IDUsuario);

                    if (Prospect.IDProspect == 0)
                    {
                        comboStatus.Enabled = false;
                        txtTelefone1.ReadOnly = true;

                        cmdDesconectar.Enabled = false;
                        cmdProximoProspect.Enabled = false;

                        AtualizarStatusFormulario(STATUS_DESCONECTADO_SEM_PROSPECT);
                    }
                    else
                    {
                        LiberarFormulario();

                        comboStatus.Enabled = true;

                        grbDadosProspect.Text = "Dados do Prospect";

                        txtTelefone1.ReadOnly = false;
                        txtIDProspect.Text = Prospect.IDProspect.ToString();
                        txtMailing.Text = Prospect.Mailing;
                        txtTelefone1.Text = Prospect.Telefone1.ToString();
                        txtTelefone2.Text = Prospect.Telefone2.ToString();
                        txtTelefone3.Text = Prospect.Telefone3.ToString();
                        radTel1.Checked = true;

                        txtNome.Text = Prospect.Nome;
                        txtCPF_CNPJ.Text = Prospect.CPF_CNPJ.ToString();
                        txtLogradouro.Text = Prospect.Logradouro.ToString();
                        txtNumero.Text = Prospect.Numero.ToString();
                        txtComplemento.Text = Prospect.Complemento.ToString();
                        txtBairro.Text = Prospect.Bairro.ToString();
                        txtCidade.Text = Prospect.Cidade.ToString();
                        txtEstado.Text = Prospect.Estado.ToString();
                        txtEmail.Text = Prospect.Email.ToString();
                        txtCep.Text = Prospect.Cep.ToString();//rr

                        string sLabel, sTextBox;
                        foreach (Control controlLabel in grbDadosProspect.Controls)
                        {
                            if (controlLabel.Name.IndexOf("lblCampo") > -1)
                            {
                                foreach (Control controlTextBox in grbDadosProspect.Controls)
                                {
                                    sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                                    sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                                    if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txtCampo") > -1)
                                    {
                                        TextBox textBox = (TextBox)controlTextBox;
                                        if (textBox.Name == "txtCampo01") textBox.Text = Prospect.Campo01.ToString();
                                        if (textBox.Name == "txtCampo02") textBox.Text = Prospect.Campo02.ToString();
                                        if (textBox.Name == "txtCampo03") textBox.Text = Prospect.Campo03.ToString();
                                        if (textBox.Name == "txtCampo04") textBox.Text = Prospect.Campo04.ToString();
                                        if (textBox.Name == "txtCampo05") textBox.Text = Prospect.Campo05.ToString();
                                        if (textBox.Name == "txtCampo06") textBox.Text = Prospect.Campo06.ToString();
                                        if (textBox.Name == "txtCampo07") textBox.Text = Prospect.Campo07.ToString();
                                        if (textBox.Name == "txtCampo08") textBox.Text = Prospect.Campo08.ToString();
                                        if (textBox.Name == "txtCampo09") textBox.Text = Prospect.Campo09.ToString();
                                        if (textBox.Name == "txtCampo10") textBox.Text = Prospect.Campo10.ToString();
                                    }
                                }
                            }
                        }
                        ListarHistoricoContato(chkMailingDiferente.Checked == false ? Prospect.IDMailing : -1);
                        dgHistorico.Columns[1].Width = 220;
                        dgHistorico.Columns[3].Width = 230;
                        dgHistorico.Columns[4].Width = 230;
                        dgHistorico.Columns[5].Width = 230;
                        dgHistorico.Columns[6].Width = 150;

                        AtualizarStatusFormulario(STATUS_DESCONECTADO_COM_PROSPECT);

                        lblRegistros.Text = dgHistorico.RowCount.ToString() + " registro(s)";
                    }

                    try
                    {
                        AtualizarStatusFormulario(STATUS_CONECTADO_COM_PROSPECT);
                        string sTelefone = "";

                        if (radTel1.Checked == true)
                            sTelefone = txtTelefone1.Text;
                        else if (radTel2.Checked == true)
                            sTelefone = txtTelefone2.Text;
                        else if (radTel3.Checked == true)
                            sTelefone = txtTelefone3.Text;

                        if (fLogin.Configuracao.TipoPabx == "PlanetFone")
                            DiscarPlanetFone(sTelefone);//Discagem PlanetFone
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Abrir prospect preditivo \n" + ex.ToString());
                    }
                }
            }
        }
        #endregion

        #region Pode abrir cliente preditivo
        private bool PodeAbrirClientePreditivo()
        {
            if (this.txtIDProspect.Text != "" || Indicacao == true)
                return false;
            else
                return true;
        }
        #endregion

        #region Grid script
        private void InserirRespostaDataGrid()
        {
            script Script = (script)lsbRespostas.SelectedItem;

            dataRespostas.Rows.Add(Script.Pergunta, Script.Resposta, Script.IDPergunta, Script.IDResposta);
            txtInformacao.AppendText("Pergunta: [" + Script.Pergunta + "]" + "   ->   Resposta: [" + Script.Resposta + "]" + Environment.NewLine);
            dgResposta.DataSource = dataRespostas;
            dgResposta.Columns["IDPergunta"].Visible = false;
            dgResposta.Columns["IDResposta"].Visible = false;
        }

        private void MontarDataTableResposta()
        {
            DataTable dataTable = new DataTable();
            dataRespostas = dataTable;

            dataRespostas.Columns.Add("Pergunta");
            dataRespostas.Columns.Add("Resposta");
            dataRespostas.Columns.Add("IDPergunta");
            dataRespostas.Columns.Add("IDResposta");

            dgResposta.DataSource = dataRespostas;
        }

        private void LiberarScript()
        {
            dataRespostas.Rows.Clear();
            lblTextoDaPergunta.Text = "-";
            lsbRespostas.DataSource = null;
            dgResposta.DataSource = null;
            txtInformacao.Text = "";
            grbScript.Enabled = false;
            lsbRespostas.Items.Clear();
            cmdReiniciarScript.Enabled = true;
        }

        private void cmdReiniciarScript_Click(object sender, EventArgs e)
        {
            LiberarScript();

            if (Indicacao == true)
            {
                CarregarPrimeiraPergunta(Convert.ToInt32(comboCampanha.SelectedValue.ToString()));
            }
            else if (txtIDProspect.Text != "")
            {
                CarregarPrimeiraPergunta(Prospect.IDCampanha);
            }
        }

        private void lsbRespostas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Venda = true;
                if (lsbRespostas.SelectedItem != null)
                {
                    InserirRespostaDataGrid();

                    script Script = (script)lsbRespostas.SelectedItem;

                    if (Script.IDResposta == 4)
                    {
                        iIDResposta = 4;
                        Script.Venda = true;
                    }

                    if (Script.Venda == true && Script.IDResposta == 4)
                    {
                        prospect Prospect = new prospect();
                        CarregarProximaPergunta(Script.IDProximaPergunta);
                    }
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }
        #endregion

        #region Bloquear formulário
        private void BloquearFormulario()
        {
            Prospect = null;
            txtTelefone1.ReadOnly = true;
            txtTelefone2.ReadOnly = true;
            txtTelefone3.ReadOnly = true;
            txtNome.ReadOnly = true;
            txtLogradouro.ReadOnly = true;
            txtNumero.ReadOnly = true;
            txtComplemento.ReadOnly = true;
            txtBairro.ReadOnly = true;
            txtCidade.ReadOnly = true;
            txtEstado.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtCep.ReadOnly = true;//rr
            txtCPF_CNPJ.ReadOnly = true;

            txtIDProspect.Text = string.Empty;
            txtMailing.Text = string.Empty;
            txtTelefone1.Text = string.Empty;
            txtTelefone2.Text = string.Empty;
            txtTelefone3.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCep.Text = string.Empty;//rr
            txtCPF_CNPJ.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            comboMidia.SelectedValue = "-1";
            comboStatus.SelectedValue = "-1";

            grpObservacao.Enabled = false;
            dgHistorico.Enabled = false;
            grpHistorico.Enabled = false;
            txtObservacao.BackColor = Color.White;
            cmdBuscarCep.Enabled = false;//rr

            tabControlAtendimento.TabPages.Remove(DadosDaVenda);
            for (int i = 0; i < grbDadosProspect.Controls.Count; i++)
            {
                if (grbDadosProspect.Controls[i].Name.IndexOf("txtCampo") > -1)
                {
                    TextBox textBox = (TextBox)grbDadosProspect.Controls[i];
                    textBox.Text = String.Empty;
                    textBox.ReadOnly = true;
                    textBox.BackColor = Color.White;
                }
                if (grbDadosProspect.Controls[i].Name.IndexOf("comboCampo") > -1)
                {
                    ComboBox comboBox = (ComboBox)grbDadosProspect.Controls[i];
                    comboBox.Text = "-";
                }
                if (grbDadosProspect.Controls[i].Name.IndexOf("combo") > -1)
                {

                    ComboBox comboBox = (ComboBox)grbDadosProspect.Controls[i];
                    comboBox.BackColor = Color.White;
                    comboBox.Enabled = false;
                }
            }

            tabControlAtendimento.TabPages.Add(DadosDaVenda);
            for (int i = 0; i < tabControlAtendimento.TabPages[1].Controls.Count; i++)
            {
                if (tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("txtVenda") > -1)
                {
                    TextBox textBox = (TextBox)tabControlAtendimento.TabPages[1].Controls[i];
                    textBox.Text = String.Empty;
                    textBox.ReadOnly = true;
                    textBox.BackColor = Color.White;
                }
                if (tabControlAtendimento.TabPages[1].Controls[i].Name.IndexOf("comboVenda") > -1)
                {
                    ComboBox comboBox = (ComboBox)tabControlAtendimento.TabPages[1].Controls[i];
                    comboBox.Text = "-";
                }
            }

            tabControlAtendimento.TabPages.Remove(DadosDaVenda);

            dgHistorico.DataSource = null;
            dgPerguntaResposta.DataSource = null;
            chkMailingDiferente.Checked = false;

            //Indicação
            cmdCancelarInd.Enabled = false;
            cmdCadastrar.Enabled = true;
            Indicacao = false;

            //Mídia
            comboMidia.Enabled = false;
            comboMidia.SelectedValue = "-1";

            comboStatus.Enabled = false;
            comboMidia.Enabled = false;
            cmdProximoProspect.Enabled = true;
            cmdSalvarContato.Enabled = false;
            Venda = false;
            comboCampanha.Enabled = true;

            // Variáveis de Agendamento - Wea
            iIDUsuarioAgendamento = 0;
            iIDStatusAgendamento = 0;
            iIDAcaoAgendamento = 0;
            iIDProspectAgendamento = 0;
            sUsuarioAgendamento = "";
            datAgendamento.Visible = false;
            txtHoraRetorno.Text = string.Empty;
            txtHoraRetorno.Visible = false;
            sDataAbertura = string.Empty;

            //Oculta combo agendamento para outro operador
            lblAgendarPara.Visible = false;
            comboOperadorAgendamento.Visible = false;
        }
        #endregion

        #region Campanhas, Verificação de Telefones e chkMailing diferentes
        private void CarregaCampanhasUsuario(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_CampanhasUsuario(comboCampanha, iIDUsuario, false, false);
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*Carrega todos os campos da campanha selecionada*/
            campanha Campanha = new campanha();
            campanhaCTL CCampanha = new campanhaCTL();
            Campanha = CCampanha.RetornarCampanha(Convert.ToInt32(comboCampanha.SelectedValue));

            fLogin.Usuario.IDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
            fLogin.Usuario.TipoDiscador = Campanha.TipoDiscador;
            fLogin.Usuario.Fila = Campanha.Fila;

            CarregarConfiguracaoTela(fLogin.Usuario.IDCampanha);
            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;


            //Abilita o Botão salvarContato grande no modo Preditivo
            if (fLogin.Usuario.TipoDiscador == "Preditivo")
            {
                if (fLogin.Configuracao.TipoPabx == "Callflex")
                    lblStatus.Visible = true;

                cmdProximoProspect.Visible = false;
                cmdSalvarContato.Size = new Size(cmdSalvarContato.Size.Width, 57);
                cmdSalvarContato.Location = new Point(16, 16);
            }
            else
            {
                if (fLogin.Configuracao.TipoPabx == "Callflex")
                    lblStatus.Visible = false;

                cmdProximoProspect.Visible = true;
                cmdSalvarContato.Size = new Size(123, 26);
                cmdSalvarContato.Location = new Point(16, 47);
            }
        }

        private void CarregarConfiguracaoTela(int iIDCampanha)
        {
            CarregarStatus(iIDCampanha);
            CarregarCamposCampanha(iIDCampanha);
            BloquearFormulario();
            if (fLogin.Configuracao.Script == 1)
                CarregarPrimeiraPergunta(iIDCampanha);
        }

        private void dgResposta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgResposta.Columns["IDPergunta"].Visible = true;
                CarregarProximaPergunta(Convert.ToInt32(dgResposta.Rows[e.RowIndex].Cells[2].Value.ToString()));
                dgResposta.Columns["IDPergunta"].Visible = false;

                for (int i = e.RowIndex; i < dgResposta.Rows.Count; i++)
                {
                    dgResposta.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void txtTelefone2_Leave(object sender, EventArgs e)
        {
            VerificarExistenciaTelefoneBase();
        }

        private void txtTelefone3_Leave(object sender, EventArgs e)
        {
            VerificarExistenciaTelefoneBase();
        }

        private void txtTelefone1_Leave(object sender, EventArgs e)
        {
            VerificarExistenciaTelefoneBase();
        }

        private void VerificarExistenciaTelefoneBase()
        {
            if (txtIDProspect.Text == "" && Indicacao == true && (txtTelefone1.Text.Length == 10 || txtTelefone1.Text.Length == 11 || txtTelefone2.Text.Length == 10 || txtTelefone2.Text.Length == 11 || txtTelefone3.Text.Length == 10 || txtTelefone3.Text.Length == 11))
            {
                //Se já tiver o número cadastrado, o sistema retorna o cliente do banco
                prospectCTL CProspect = new prospectCTL();

                //Telefone 1
                try { dTelefone1 = Convert.ToDouble(txtTelefone1.Text == "" ? 0 : Convert.ToDouble(txtTelefone1.Text)); }
                catch
                {
                    MessageBox.Show("Só é permitido números nos campos [Telefone 1].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelefone1.Focus();
                    return;
                }
                //Telefone 2
                try { dTelefone2 = Convert.ToDouble(txtTelefone2.Text == "" ? 0 : Convert.ToDouble(txtTelefone2.Text)); }
                catch
                {
                    MessageBox.Show("Só é permitido números nos campos [Telefone 2].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelefone2.Focus();
                    return;
                }
                //Telefone 3
                try { dTelefone3 = Convert.ToDouble(txtTelefone3.Text == "" ? 0 : Convert.ToDouble(txtTelefone3.Text)); }
                catch
                {
                    MessageBox.Show("Só é permitido números nos campos [Telefone 3].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelefone3.Focus();
                    return;
                }

                //Verifica se telefone começa com "0"
                if ((txtTelefone1.Text != "" && txtTelefone1.Text.Substring(0, 1) == "0")
                    || (txtTelefone2.Text != "" && txtTelefone2.Text.Substring(0, 1) == "0")
                    || (txtTelefone3.Text != "" && txtTelefone3.Text.Substring(0, 1) == "0"))
                {
                    MessageBox.Show("[Telefone] está incorreto.\n\nO [Telefone] não pode começar com 0.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double dIDProspect = CProspect.VerificarExistenciaTelefone(Convert.ToDouble(txtTelefone1.Text == "" ? 0 : Convert.ToDouble(txtTelefone1.Text)), Convert.ToDouble(txtTelefone2.Text == "" ? 0 : Convert.ToDouble(txtTelefone2.Text)), Convert.ToDouble(txtTelefone3.Text == "" ? 0 : Convert.ToDouble(txtTelefone3.Text)));
                if (dIDProspect != 0)
                {
                    RetornarUsuarioAgendamento(Convert.ToInt32(dIDProspect));
                    AbrirProspect(Convert.ToInt32(dIDProspect));

                    if (fLogin.Usuario.IDCampanha != Prospect.IDCampanha)//
                    {
                        string sMensagem = "O [Telefone] já existe em outra Campanha.";
                        sMensagem += "\n\nEste cliente será tabulado com um novo histórico.";
                        MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (iIDUsuarioAgendamento == 0)
                        {
                            string sMensagem = "O [Telefone] já existe na base de dados.";
                            sMensagem += "\n\nEste cliente será tabulado com um novo histórico.";
                            MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sMensagem = "O [Telefone] já existe na base de dados.";
                            sMensagem += "\n\nEste cliente será tabulado com um novo histórico.";
                            sMensagem += "\nExiste um agendamento anterior para o operador [" + sUsuarioAgendamento +
                                         "].";
                            MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        public void RetornarUsuarioAgendamento(int iIDProspect)
        {
            prospectCTL CProspect = new prospectCTL();
            DataTable dataTable = CProspect.RetornarUsuarioAgendamento(iIDProspect);

            if (dataTable.Rows.Count > 0)
            {
                iIDUsuarioAgendamento = Convert.ToInt32(dataTable.Rows[0]["IDUsuario"].ToString());
                iIDStatusAgendamento = Convert.ToInt32(dataTable.Rows[0]["IDStatus"].ToString());
                iIDAcaoAgendamento = Convert.ToInt32(dataTable.Rows[0]["IDAcao"].ToString());
                sUsuarioAgendamento = dataTable.Rows[0]["Nome"].ToString();
                iIDProspectAgendamento = iIDProspect;
            }
        }

        private void chkMailingDiferente_Click(object sender, EventArgs e)
        {
            if (Prospect != null)
                ListarHistoricoContato(chkMailingDiferente.Checked == false ? Prospect.IDMailing : -1);

            lblRegistros.Text = dgHistorico.RowCount.ToString() + " registro(s)";
        }

        private void tabControlAtendimento_MouseMove(object sender, MouseEventArgs e)
        {
            AutoScrollPosition = new Point(0, 0);
        }
        #endregion

        #region Cliente RoboPreditivo - Socket - listening
        private void IniciarConexao()
        {
            try
            {
                UpdateControls(false);
                // Create the socket instance
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //Retorna IP e a Prota salvos pela execução do RoboPreditivo no banco de dados na tabela tSocket
                configuracaoCTL CConfiguracao = new configuracaoCTL();
                DataTable dataTable = CConfiguracao.RetornarDadosSocket();
                if (dataTable.Rows.Count != 0)
                {
                    // Cet the remote IP address
                    IPAddress ip = IPAddress.Parse(dataTable.Rows[0]["IPServidor"].ToString());
                    int iPortNo = Convert.ToInt32(dataTable.Rows[0]["PortaServidor"]);
                    txtIP.Text = Convert.ToString(ip);
                    txtPorta.Text = Convert.ToString(iPortNo);
                    // Create the end point 
                    IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
                    // Connect to the remote host
                    m_clientSocket.Connect(ipEnd);
                    if (m_clientSocket.Connected)
                    {
                        timerReconectar.Enabled = false;
                        UpdateControls(true);
                        //Wait for data asynchronously 
                        WaitForData();
                    }
                }
                else
                    MessageBox.Show("Não existe IP e Porta dentro da tabela do Banco \n Favor executar o Robô Preditivo antes de logar o Tabulare");
            }
            catch
            {
                UpdateControls(false);
            }
        }

        public void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_clientSocket;
                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None,
                                                        m_pfnCallBack, theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[1];
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);

                if (sParametroRecebido.IndexOf(NroAgente.ToString()) == -1)
                    sParametroRecebido += szData.Substring(0, 1);
                else if (sParametroRecebido.Trim().Length > 0)
                {
                    if (sParametroRecebido.IndexOf(Convert.ToString(NroAgente)) > -1)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            if (PodeAbrirClientePreditivo())
                            {
                                AbrirProspectPreditivo(0);
                            }
                        });
                    }
                    sParametroRecebido = "";
                }

                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch
            {
                UpdateControls(false);
            }
        }

        private void UpdateControls(bool connected)
        {
            if (connected == true)
            {
                Invoke((MethodInvoker)delegate { txtStausConexao.Text = "Conectado"; });
                Invoke((MethodInvoker)delegate { timerReconectar.Enabled = false; });
                Invoke((MethodInvoker)delegate { lblTimerReconexão.Visible = false; });
                Invoke((MethodInvoker)delegate { txtTimerReconexao.Visible = false; });
                Invoke((MethodInvoker)delegate
                {
                    MudarTelaoperadorPreditivo();

                    if (txtIDProspect.Text == "")
                    {
                        //Retira o Robo Preditivo de pausa quando reconectar e nao tiver nada na tela
                        usuarioCTL CUsuario = new usuarioCTL();
                        CUsuario.PausaAgente(fLogin.Usuario.IDUsuario, 0);
                    }
                });
                Invoke((MethodInvoker)delegate { AbrirProspectPreditivo(0); });
            }
            else
            {
                Invoke((MethodInvoker)delegate { txtStausConexao.Text = "Disconectado"; });
                Invoke((MethodInvoker)delegate { FinalizarConexao(); });
                Invoke((MethodInvoker)delegate { lblTimerReconexão.Visible = true; });
                Invoke((MethodInvoker)delegate { txtTimerReconexao.Visible = true; });
                Invoke((MethodInvoker)delegate { timerReconectar.Enabled = true; });
                Invoke((MethodInvoker)delegate
                {
                    MudarTelaoperadorPower();

                    //Coloca o Robo Preditivo em pausa quando desconectar
                    usuarioCTL CUsuario = new usuarioCTL();
                    CUsuario.PausaAgente(fLogin.Usuario.IDUsuario, -1);
                });
            }
        }

        private void FinalizarConexao()
        {
            try
            {
                if (m_clientSocket != null)
                {
                    m_clientSocket.Close();
                    m_clientSocket = null;
                    UpdateControls(false);
                }
            }
            catch { }
        }

        //Função criada mas creio que nao seria usada
        private void EnviarParametros(string sEnviarParametros)
        {
            try
            {
                Object objData = sEnviarParametros;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                if (m_clientSocket != null)
                {
                    m_clientSocket.Send(byData);
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void timerReconectar_Tick(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                Reconectar++;
                if (Reconectar > 5)
                {
                    IniciarConexao();
                    Reconectar = 0;
                }
                txtTimerReconexao.Text = Convert.ToString(Reconectar);
            });
        }

        private void MudarTelaoperadorPower()
        {
            lblIP.Visible = true;
            lblPorta.Visible = true;
            txtIP.Visible = true;
            txtPorta.Visible = true;
            lblStatusConexao.Visible = true;
            txtStausConexao.Visible = true;
            cmdProximoProspect.Visible = true;
            timerReconectar.Enabled = true;
            lblTimerReconexão.Visible = true;
            txtTimerReconexao.Visible = true;
        }

        private void MudarTelaoperadorPreditivo()
        {
            cmdProximoProspect.Visible = false;
            lblIP.Visible = true;
            lblPorta.Visible = true;
            txtIP.Visible = true;
            txtPorta.Visible = true;
            lblStatusConexao.Visible = true;
            txtStausConexao.Visible = true;
            AbrirProspectPreditivo(0);
            grpPainelBotao.Text = "Painel de Atendimento - Discador no modo Preditivo";
        }

        #endregion

        #region Discar Digistar
        //Efetua a discagem via Digistar
        private void DiscarDigistar(string sTelefone)
        {
            try
            {
                string sRamal = fLogin.Usuario.Ramal;
                //Se for DDD 31, retira o DDD - Ligação local não precisa de DDD
                if (sTelefone.Substring(0, 2) == "31")
                {
                    sComandoPabxDigistar = "SSD" + sRamal + sTelefone.Substring(2, 8);
                    enviarComandoParaPabx(sComandoPabxDigistar);
                }
                //Se for DDD diferente de 31 e o telefone tiver 10 digitos - "0" + "Operadora" + "DDD"
                else if (sTelefone.Substring(0, 2) != "31" && sTelefone.Length == 10)
                {
                    sComandoPabxDigistar = "SSD" + sRamal + 0 + sOperadora + sTelefone;
                    enviarComandoParaPabx(sComandoPabxDigistar);
                }
            }
            catch
            { }
        }
        #endregion

        #region Desconectar Digistar
        //Desconecta a ligação do Digistar 
        private void DesconectarDigistar()
        {
            try
            {
                string sRamal = fLogin.Usuario.Ramal;
                sComandoPabxDigistar = "SEX" + sRamal + "D";
                enviarComandoParaPabx(sComandoPabxDigistar);
            }
            catch
            { }
        }
        #endregion

        #region conexão Pabx Digistar
        public void iniciarComunicacaoDigistar()
        {
            configuracaoCTL CConfiguracao = new configuracaoCTL();
            DataTable dataTable = CConfiguracao.RetornarDadosSocket();

            System.String hostStr = dataTable.Rows[0]["IPServidor"].ToString();
            System.String portaStr = dataTable.Rows[0]["PortaServidor"].ToString();

            int porta = 0;

            try
            {
                porta = System.Int32.Parse(portaStr);
                AbrirSocketDigistar(hostStr, porta);
            }
            catch (System.IO.IOException except)
            {
                RegistrarEventos(except.ToString());
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //	 Socket Digistar
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void AbrirSocketDigistar(System.String host, int porta)
        {
            try
            {
                socketDigistar = new System.Net.Sockets.TcpClient(host, porta);

                dataInputStream = new System.IO.BinaryReader(socketDigistar.GetStream());
                dataOutputStream = new System.IO.BinaryWriter(socketDigistar.GetStream());
                RegistrarEventos("Conexão estabelecida com sucesso!");

                AtualizarControleDigistar(false);

                if (socketDigistar.Connected)
                {
                    AtualizarControleDigistar(true);

                    //Aguarde dados de forma assíncrona 
                    EsperarDadosDigistar();
                }
            }
            catch (System.IO.IOException e)
            {
                RegistrarEventos("Não foi possivel efetuar conexao! Favor Verificar IP de conexão!");
                RegistrarEventos(e.ToString());
            }
        }

        public void EsperarDadosDigistar()
        {
            try
            {
                if (RetornaChamadaDigistar == null)
                {
                    RetornaChamadaDigistar = new AsyncCallback(RecebendoDadosDigistar);
                }

                SocketPacketDisigstar theSocPkt = new SocketPacketDisigstar();
                theSocPkt.thisSocketDigistar = socketDigistar.Client;

                // Comece ouvindo os dados de forma assíncrona
                ResultadoDigistar = socketDigistar.Client.BeginReceive(theSocPkt.dataBufferDigistar, 0, theSocPkt.dataBufferDigistar.Length, SocketFlags.None, m_pfnCallBack, theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public class SocketPacketDisigstar
        {
            public System.Net.Sockets.Socket thisSocketDigistar;
            public byte[] dataBufferDigistar = new byte[1];
        }

        public void RecebendoDadosDigistar(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);

                if (szData.IndexOf("\r") == -1 && szData.IndexOf("\n") == -1 && szData != "")
                    sComandoDigistar += szData.Substring(0, 1);
                else if (sComandoDigistar.Trim().Length > 0)
                {
                    if (sComandoDigistar.IndexOf(sRamal) > -1)
                    {
                        Invoke((MethodInvoker)delegate { RegistrarEventos("PABX para CRM : " + sComandoDigistar); });

                        #region Comandos de retorno para identificação dos status da ligação com licenca
                        if (sComandoDigistar.IndexOf("SDN") > -1)
                            Invoke((MethodInvoker)delegate { RegistrarEventos("PABX para CRM : " + sComandoDigistar); });
                        if (sComandoDigistar.IndexOf("SDO") > -1)
                            Invoke((MethodInvoker)delegate { RegistrarEventos("PABX para CRM : " + sComandoDigistar); });
                        if (sComandoDigistar.IndexOf("SFI") > -1)
                            Invoke((MethodInvoker)delegate { RegistrarEventos("PABX para CRM : " + sComandoDigistar); });
                        if (sComandoDigistar.IndexOf("SEP") > -1)
                            Invoke((MethodInvoker)delegate { RegistrarEventos("PABX para CRM : " + sComandoDigistar); });
                        if (sComandoDigistar.IndexOf("SNA") > -1)
                            Invoke((MethodInvoker)delegate { RegistrarEventos("PABX para CRM : " + sComandoDigistar); });
                    }
                        #endregion
                    sComandoDigistar = "";
                }
                EsperarDadosDigistar();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed" + Environment.NewLine);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void AtualizarControleDigistar(bool connected)
        {
            if (connected == true)
            {
                Invoke((MethodInvoker)delegate { txtStausConexao.Text = "Conectado"; });
            }
            else
            {
                Invoke((MethodInvoker)delegate { txtStausConexao.Text = "Disconectado"; });
            }
        }

        private void FinalizarConexaoDigistar()
        {
            if (socketDigistar != null)
            {
                AtualizarControleDigistar(false);
                finalizarComunicacaoDigistar();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //	 finalizarComunicacao
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void finalizarComunicacaoDigistar()
        {
            RegistrarEventos("Comunicação finalizada.");
            try
            {
                if (dataInputStream != null)
                {
                    dataInputStream.Close();
                }

                if (dataOutputStream != null)
                {
                    dataOutputStream.Close();
                }

                if (socketDigistar != null)
                {
                    socketDigistar.Close();
                    socketDigistar = null;
                }
            }
            catch (System.IO.IOException except)
            {
                RegistrarEventos(except.ToString());
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //	 enviarComandoParaPabxDigistar
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void enviarComandoParaPabx(string sComandoPabxDigistar)
        {
            System.String comStr = new System.Text.StringBuilder(sComandoPabxDigistar + "\n").ToString();
            RegistrarEventos("CRM para PABX: " + comStr);

            if (dataOutputStream == null)
                return;
            try
            {
                dataOutputStream.Write(comStr);
            }
            catch (System.IO.IOException except)
            {
                RegistrarEventos(except.ToString());
            }
        }

        private void LiberarRamalDigistar()
        {
            try
            {
                string sRamal = fLogin.Usuario.Ramal;
                sComandoPabxDigistar = "SEX" + sRamal + "L";
                enviarComandoParaPabx(sComandoPabxDigistar);
            }
            catch
            { }
        }
        #endregion

        #region Chek discagem automática
        private void chkDiscagemAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscagemAutomatica.Checked == true)
            {
                chkDiscagemAutomatica.ForeColor = Color.Green;
            }
            else
            {
                chkDiscagemAutomatica.ForeColor = Color.Red;
            }
        }
        #endregion

        #region Timer liberar ramal
        private void TimeLiberarRamal_Tick(object sender, EventArgs e)
        {
            LiberarRamalDigistar();
            TimeLiberarRamal.Enabled = false;
        }
        #endregion

        #region FecharTodasComexoes
        public void FecharTodasComexoes()
        {
            if (fLogin.Configuracao.TipoPabx == "Modem")
            {
                // Desconectar Modem
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
            if (fLogin.Configuracao.TipoPabx == "PlanetFone")
            {
                // Desconectar Planetfone
                FinalizarConexao();
            }
            if (fLogin.Configuracao.TipoPabx == "Digistar")
            {
                // Desconectar Digistar
                finalizarComunicacaoDigistar();
            }
            if (fLogin.Configuracao.TipoPabx == "Vonix")
            {
                // Timer Vonix                                                                                              
                TimerAtualizarProspectVonix.Enabled = false;
            }

            LiberarProspectEmUso();
        }
        #endregion



        #region Vonix
        //' RECEBIMENTO DE CALLBACKS
        //'
        //' Customize as ações destes métodos junto a sua
        //' aplicação para poder interagir com o Discador.
        //' Caso queira ter mais informações sobre quando cada
        //' callback ocorre consulte a documentação de integração!
        //'
        //' ATENÇÃO: As variáveis string não vem codificadas
        //' no formato do VB e para que possa usa-las é preciso
        //' fazer a conversão usando ConvertString()

        //'        onConnect – Ocorre quando a conexão com o Dialer é estabelida
        //'        strDate – Data da conexão (String)
        //'        ActionId – Identificador da Ação (String)
        private void onConnect(string strDate, string ActionId)
        {
            RegistrarEventos("onConnect: " + strDate + ", " + ActionId);
            doStatus("do_status", "");
        }

        //'        onDial – Ocorre quando o agente realiza uma chamada
        //'        CallId – Identificador da Chamada (String)
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        AgentCode – Matrícula do agente (String)
        //'        QueueName – Nome da fila a qual a chamada pertence (String)
        //'        FromNumber – Número de Origem (String)
        //'        ToNumber – Número de Destino (String)
        //'        CallFilename – Nome do arquivo de áudio da chamada (String)
        //'        ContactName – Nome do contato, caso exista (String)
        //'        ActionId – Identificador da Ação (String)
        private void onDial(string CallId, string strDate, string AgentCode, string QueueName, string FromNumber, string ToNumber, string CallFilename, string ContactName, string ActionId)
        {
            RegistrarEventos("onDial: " + CallId + " , " + strDate + ", " + AgentCode + ", " + QueueName + ", " + FromNumber + ", " + ToNumber + ", " + CallFilename + ", " + ContactName + ", " + ActionId);
        }

        //'        onDialAnswer – Ocorre quando a chamada é atendida
        //'        CallId – Identificador da Chamada (String)
        //'        strDate – Hora em que ocorreu o evento (String)
        public void onDialAnswer(string CallId, string strDate)
        {
            RegistrarEventos("onDialAnswer: " + CallId + ", " + strDate);
            // AbrirProspectPreditivoVonix();
        }

        //'        onDialFailure – Ocorre quando a chamada não é atendida
        //'        CallId – Identifcador da Chamada (String)
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        CauseId – Identificador da causa (Integer)
        //'        CauseDescription – Decrição da causa (String)
        private void onDialFailure(string CallId, string strDate, int CauseId, string CauseDescription)
        {
            RegistrarEventos("onDialFailure: " + CallId + ", " + strDate + ", " + (CauseId) + ", " + CauseDescription);
        }

        //'        onReceive – Ocorre quando o agente recebe uma chamada
        //'        CallId – Identificador da Chamada (String)
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        QueueName – Nome da fila a qual a chamada pertence (String)
        //'        FromNumber – Número de origem (String)
        //'        ToNumber – Número de destino (String)
        //'        CallFilename – Nome do arquivo de áudio da chamada (String)
        //'        ContactName – Nome do contato, caso exista (String)
        //'        ActionId – Identificador da Ação (String)

        private void onReceive(string CallId, string strDate, string QueueName, string FromNumber, string ToNumber, string CallFilename, string ContactName, string ActionId)
        {
            RegistrarEventos("onReceive: " + CallId + " , " + strDate + ", " + QueueName + ", " + FromNumber + ", " + ToNumber + ", " + CallFilename + ", " + ContactName + ", " + ActionId);
            AbrirProspectPreditivo(Convert.ToInt32(ActionId));
        }

        //'        onReceiveAnswer – Ocorre quando o agente atende a chamada
        //'        CallId – Identificador da Chamada (String)
        //'        strDate – Hora me que ocorreu o evento (String)
        //'        WaitSeconds – Tempo de espera antes do atendimento (Integer)
        private void onReceiveAnswer(string CallId, string strDate, int WaitSeconds)
        {
            RegistrarEventos("onReceiveAnswer: " + CallId + ", " + strDate + ", " + (WaitSeconds));
        }

        //'        onReceiveFailure – Ocorre quando o agente não atende a chamada
        //'        CallId – Identificador da Chamada (String)
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        RingingSeconds – Tempo de espera antes do abandono (Integer)
        private void onReceiveFailure(string CallId, string strDate, int RingingSeconds)
        {
            RegistrarEventos("onReceiveFailure: " + CallId + ", " + strDate + ", " + (RingingSeconds));
        }

        //'        onHangUp – Ocorre no encerramento da chamada (tando discada quanto recebida)
        //'        CallId – Identificador da Chamada (String)
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        CauseId – Identificador da causa (Integer)
        //'        CauseDescription – Descrição da causa (String)
        private void onHangUp(string CallId, string strDate, int CauseId, string CauseDescription)
        {
            RegistrarEventos("onHangUp: " + CallId + ", " + strDate + ", " + (CauseId) + ", " + CauseDescription);
        }

        //'        onPause – Ocorre quando o agente entra em pausa
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        Reason – Motivo da pausa (Integer)
        //'        ActionId – Identificador da Ação (String)
        private void onPause(string strDate, int Reason, string ActionId)
        {
            RegistrarEventos("onPause: " + strDate + ", " + (Reason) + ", " + ActionId);
        }

        //'        onUnpause – Ocorre quando o agente sai da pausa
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        ActionId – Identificador da Ação (String)
        private void onUnpause(string strDate, string ActionId)
        {
            RegistrarEventos("onUnpause: " + strDate + ", " + ActionId);
        }

        //'        onLogin – Ocorre quando o agente se loga para trabalho
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        Location – Numero da PA (ramal) que o usuario se logou (String)
        //'        ActionId – Identificador da Ação (String)
        private void onLogin(string strDate, string Location, string ActionId)
        {
            RegistrarEventos("onLogin: " + strDate + ", " + Location + ", " + ActionId);
        }

        //'        onLogoff – Ocorre quando o agente se desloga do trabalho
        //'        strDate – Hora em que ocorreu o evento (String)
        //'        Location – Numero da PA (ramal) que o usuario se logou (String)
        //'        Duration – Tempo total da sessao que o usuario ficou logado (Integer)
        //'        ActionId – Identificador da Ação (String)
        private void onLogoff(string strDate, string Location, int Duration, string ActionId)
        {
            RegistrarEventos("onLogoff: " + strDate + ", " + Location + ", " + (Duration) + ", " + ActionId);
        }

        //'        onStatus – Ocorre em resposta a chamada de doStatus
        //'        Status – Descrição do estado do agente (String)
        //'        Location – Numero da PA (ramal) que o usuario se logou (String)
        //'        ActionId – Identificador da Ação (String)
        private void onStatus(string Status, string Location, string ActionId)
        {
            RegistrarEventos("onStatus: " + Status + ", " + Location);
        }

        //'        onError – Ocorre quando algum erro ocorreu na biblioteca
        //'        ActionId – Identificador da Ação que originou o erro(String)
        //'        Messsage – Descrição do Erro (String)
        private void onError(string ActionId, string Message)
        {
            RegistrarEventos("onError: " + ActionId + ", " + Message);
        }

        //'        onVersion – Ocorre em resposta a chamada de doVersion
        //'        ActionId – Identificador da Ação (String)
        //'        Version – Versão da API (String)
        private void onVersion(string ActionId, string Version)
        {
            RegistrarEventos("onVersion: " + ActionId + ", " + Version);
        }

        //' Delegando e registrando os metodos de callback 
        public void LoadCallBacks()
        {
            myConnect = new cbConnect(onConnect);
            RegisterOnConnect(myConnect);

            myDial = new cbDial(onDial);
            RegisterOnDial(myDial);

            myDialAnswer = new cbDialAnswer(onDialAnswer);
            RegisterOnDialAnswer(myDialAnswer);

            myDialFailure = new cbDialFailure(onDialFailure);
            RegisterOnDialFailure(myDialFailure);

            myReceive = new cbReceive(onReceive);
            RegisterOnReceive(myReceive);

            myReceiveAnswer = new cbReceiveAnswer(onReceiveAnswer);
            RegisterOnReceiveAnswer(myReceiveAnswer);

            myReceiveFailure = new cbReceiveFailure(onReceiveFailure);
            RegisterOnReceiveFailure(myReceiveFailure);

            myHangUp = new cbHangUp(onHangUp);
            RegisterOnHangUp(myHangUp);

            myPause = new cbPause(onPause);
            RegisterOnPause(myPause);

            myUnpause = new cbUnpause(onUnpause);
            RegisterOnUnpause(myUnpause);

            myLogin = new cbLogin(onLogin);
            RegisterOnLogin(myLogin);

            myLogoff = new cbLogoff(onLogoff);
            RegisterOnLogoff(myLogoff);

            myStatus = new cbStatus(onStatus);
            RegisterOnStatus(myStatus);

            myError = new cbError(onError);
            RegisterOnError(myError);

            myVersion = new cbVersion(onVersion);
            RegisterOnVersion(myVersion);
        }

        #endregion


        private void TimerAtualizarProspectVonix_Tick(object sender, EventArgs e)
        {
            PegarRetornoTentativasVonix();
        }

        private void AtualizarProspectVonix(int iIDProspect, int iIDStatusVonix)
        {
            if (iIDProspect != 0)
            {
                mailingCTL CMailing = new mailingCTL();
                CMailing.AtualizarProspectVonix(iIDProspect, iIDStatusVonix);
            }
        }

        #region TimerAtualizarProspectVonix
        private void PegarRetornoTentativasVonix()
        {
            try
            {
                RegistrarEventos("Início do timer preditivo");
                PontoBr.Utilidades.Log.RegistrarLog("Início do timer preditivo", "log");

                prospectCTL CProspect = new prospectCTL();
                statusCTL CStatus = new statusCTL();
                contato[] Contatos;

                int i = 0;
                int contador = 0;
                List<string> Dados = new List<string>();
                Dados.Clear();

                if (fLogin.Configuracao.TipoPabx == "Vonix")
                {
                    var ping = new Ping();
                    if (fLogin.Configuracao.IPServidor == "") fLogin.Configuracao.IPServidor = "192.192.192.192";
                    var reply = ping.Send(fLogin.Configuracao.IPServidor, 100);

                    if (reply.Status == IPStatus.Success)
                    {
                        if (fLogin.Usuario.TipoDiscador == "Power")
                            cmdProximoProspect.Visible = true;
                        else
                            cmdProximoProspect.Visible = false;

                        string sUrl = "http://" + fLogin.Configuracao.IPServidor + ":8003/results"; //Produção
                        PontoBr.Utilidades.Log.RegistrarLog("URL - " + sUrl, "log");

                        string sRetorno = "";
                        try
                        {
                            using (var webClient = new WebClient())
                            {
                                var data = new NameValueCollection();
                                webClient.Credentials = new NetworkCredential("pontocom", "i39G75hs4"); //Produção
                                sRetorno = webClient.DownloadString(sUrl);
                            }
                            PontoBr.Utilidades.Log.RegistrarLog("Retorno - " + sRetorno, "log");
                        }
                        catch (Exception ex)
                        {
                            PontoBr.Utilidades.Log.RegistrarLog("Erro ao pegar retorno - " + ex.Message, "log");
                        }

                        if (sRetorno != "")
                        {
                            PontoBr.Utilidades.Log.RegistrarLog("XML diferente de vazio", "log");

                            if (sRetorno.IndexOf("<?xml") != -1)
                            {
                                string[] arrLinhas = sRetorno.Split('\n');
                                sRetorno = "";

                                for (int ix = 1; ix < arrLinhas.Length; ix++)
                                    sRetorno += arrLinhas[ix].Replace("-", "").Trim() + "\n";
                            }

                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(sRetorno);

                            XmlNode root = doc.ChildNodes[i];
                            foreach (XmlNode xmlnode in root.ChildNodes)
                            {
                                foreach (XmlNode atributos in xmlnode.Attributes)
                                {
                                    if (atributos.InnerText != "labpontocom")
                                        Dados.Add(atributos.InnerText);
                                }

                                foreach (XmlNode texto in xmlnode.ChildNodes)
                                    Dados.Add(texto.FirstChild.Value);
                            }

                            DataTable dataTable = new DataTable("ResubmitVonix");
                            dataTable.Clear();
                            dataTable = null;

                            PontoBr.Utilidades.Log.RegistrarLog("Número de linhas do XML - " + Dados.Count.ToString(), "log");
                            for (int j = 0; j < Dados.Count; j++)
                            {
                                contador = ID * 4;
                                if (j == contador)
                                {
                                    ID++;
                                    if (dataTable == null)
                                    {
                                        dataTable = new DataTable();
                                        DataColumn dataColumn;

                                        dataColumn = new DataColumn();
                                        dataColumn.DataType = System.Type.GetType("System.String");
                                        dataColumn.ColumnName = "IDStatus";
                                        dataTable.Columns.Add(dataColumn);

                                        dataColumn = new DataColumn();
                                        dataColumn.DataType = System.Type.GetType("System.String");
                                        dataColumn.ColumnName = "Fila";
                                        dataTable.Columns.Add(dataColumn);

                                        dataColumn = new DataColumn();
                                        dataColumn.DataType = System.Type.GetType("System.String");
                                        dataColumn.ColumnName = "IDProspect";
                                        dataTable.Columns.Add(dataColumn);

                                        dataColumn = new DataColumn();
                                        dataColumn.DataType = System.Type.GetType("System.String");
                                        dataColumn.ColumnName = "IDStatusVonix";
                                        dataTable.Columns.Add(dataColumn);
                                    }

                                    DataRow dataRow = dataTable.NewRow();
                                    dataRow["IDStatus"] = Dados[j].ToString();
                                    dataRow["Fila"] = Dados[1 + j].ToString();
                                    dataRow["IDProspect"] = Dados[2 + j].ToString();
                                    dataRow["IDStatusVonix"] = Dados[3 + j].ToString();
                                    if (dataRow["IDStatus"].ToString() == "failure")
                                        dataTable.Rows.Add(dataRow);
                                }
                            }
                            contador = 0;
                            ID = 0;
                            Contatos = new contato[dataTable.Rows.Count];
                            int iArrayContato = 0;

                            /*Retorna todos os status da Vonix*/
                            DataTable dataTableStatusVonix = new DataTable();
                            dataTableStatusVonix = CStatus.RetornarStatusVonix();

                            foreach (DataRow dataRowStatusVonix in dataTableStatusVonix.Rows)
                                PontoBr.Utilidades.Log.RegistrarLog("dataRowStatusVonix - IDStatusVonix " + dataRowStatusVonix["IDStatusVonix"].ToString() + "; IDStatus " + dataRowStatusVonix["IDStatus"].ToString(), "log");

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                try
                                {
                                    string sIDStatus = dataRow["IDStatus"].ToString();
                                    string sFila = dataRow["Fila"].ToString();
                                    int iIDProspect = Convert.ToInt32(dataRow["IDProspect"].ToString());
                                    int iIDStatusVonix = Convert.ToInt32(dataRow["IDStatusVonix"].ToString());
                                    string sContato;
                                    contato Contato = new contato();

                                    Contato.IDProspect = iIDProspect;
                                    Contato.IDUsuario = -1;
                                    Contato.Observacao = "*****Retorno do preditivo";
                                    Contato.IDTipoAtendimento = 1;
                                    Contato.Venda = false;
                                    Contato.RetornoPreditivo = 1;
                                    foreach (DataRow dataRowStatusVonix in dataTableStatusVonix.Rows)
                                    {
                                        if (Convert.ToInt32(dataRowStatusVonix["IDStatusVonix"]) == iIDStatusVonix)
                                            Contato.IDStatus = Convert.ToInt32(dataRowStatusVonix["IDStatus"]);
                                    }

                                    Contatos[iArrayContato] = Contato;

                                    sContato = "IDProspect = " + Contato.IDProspect.ToString();
                                    sContato += "; IDUsuario = " + Contato.IDUsuario.ToString();
                                    sContato += "; IDStatus = " + Contato.IDStatus.ToString();
                                    sContato += "; Observacao = " + Contato.Observacao.ToString();
                                    sContato += "; IDTipoAtendimento = " + Contato.IDTipoAtendimento.ToString();
                                    sContato += "; RetornoPreditivo = " + Contato.RetornoPreditivo.ToString();
                                    PontoBr.Utilidades.Log.RegistrarLog("Contato - " + sContato, "log");
                                }
                                catch (Exception ex)
                                {
                                    PontoBr.Utilidades.Log.RegistrarLog("Erro - " + ex.Message, "log");
                                }
                                iArrayContato++;
                            }
                            /*Salva, de uma vez só, todos os retornos da Vonix*/
                            CProspect.SalvarContato(Contatos);

                            /*Registrar evento*/
                            RegistrarEventos("Retorno pred. - " + Contatos.Length.ToString());
                        }
                    }
                    else
                    {
                        //VINICIUS  - 09/07/2013
                        if (fLogin.Usuario.TipoDiscador == "Power")
                        {
                            string sComando;
                            cmdProximoProspect.Visible = true;
                            sComando = "Falha na comunicação com Servidor Vonix..." + Environment.NewLine;
                            RegistrarEventos(sComando);
                        }
                        else
                        {
                            string sComando;
                            cmdProximoProspect.Visible = true;
                            sComando = "Falha na comunicação com Servidor Vonix..." + Environment.NewLine;
                            RegistrarEventos(sComando);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Log.RegistrarLog("Erro - " + ex.Message, "log");
                MessageBox.Show("TimerAtualizarProspectVonix \n" + ex.Message);
            }
        }
        #endregion

        private void NewCallPlugRises()
        {
            Callflex.CallFlexMidnet clx = new Callflex.CallFlexMidnet();
            clx.NewCall += new Callflex.CallFlexMidnet.NewCallEventHandler(new NewCallDelegate(NewCall));

            Thread.Sleep(200);
            if (Convert.ToBoolean(clx.isConnected) == true)
                lblStatus.Text = "Status: Conectado com CallFlex.";
            //else
            //    lblStatus.Text = "Status: Desconectado com CallFlex.";
        }

        private void NewCall(string sID, string sTelefone)
        {
            if (sID != "0" || sID != "" && sTelefone.Length != 4)
                Invoke((MethodInvoker)delegate { AbrirProspectPreditivo(Convert.ToInt32(sID)); });
            else if (sTelefone.Length == 4)
                MessageBox.Show("Ligação efetuado do Ramal (" + sTelefone + ") ");
            else
                MessageBox.Show("Dados enviados pelo CallFlex fora dos paramentros do discador \n Favor entrar em contato com TI local.");
        }

        private void DiscarCallflex(string sTelefone)
        {
            string sComando;
            string sNroTelefDestino = "";

            try
            {
                if (radTel1.Checked && String.IsNullOrEmpty(txtTelefone1.Text)
                    || radTel2.Checked && String.IsNullOrEmpty(txtTelefone2.Text)
                    || radTel3.Checked && String.IsNullOrEmpty(txtTelefone3.Text))
                {
                    sComando = "Não há telefone para discar..." + Environment.NewLine;
                    RegistrarEventos(sComando);
                    cmdDiscar.Enabled = true;
                    cmdDesconectar.Enabled = false;
                }
                else
                {
                    if (sTelefone.Length == 10 || sTelefone.Length == 11)
                    {
                        //Se for DDD 31, retira o DDD - Ligação local não precisa de DDD
                        if (sTelefone.Substring(0, 2) == sOperadora)
                        {
                            sNroTelefDestino = 0 + sTelefone.Substring(2, 8);

                            sComando = "Discando para " + sNroTelefDestino + "..." + Environment.NewLine;
                            RegistrarEventos(sComando);

                            string sUrl = "callflex://" + sNroTelefDestino;
                            Process.Start(sUrl);
                        }

                        //Se for DDD diferente de 31 e o telefone tiver 10 ou 11 digitos - "00" + "Operadora" + "DDD" + "Telefone"
                        else if (sTelefone.Substring(0, 2) != sOperadora)
                        {
                            sNroTelefDestino = "0" + "0" + sOperadora + sTelefone;

                            sComando = "Discando para " + sNroTelefDestino + "..." + Environment.NewLine;
                            RegistrarEventos(sComando);

                            string sUrl = "callflex://" + sNroTelefDestino;
                            Process.Start(sUrl);
                        }
                    }
                    else
                    {
                        sComando = "Telefone incorreto..." + Environment.NewLine;
                        RegistrarEventos(sComando);
                    }
                }
            }
            catch (Exception ex)
            {
                RegistrarEventos(ex.Message);
            }
        }

        private bool ValidarDataHoraProva(string sDataHoraAAAAMMDD_HHMM)
        {
            try
            {
                DateTime dtDataAtual = DateTime.Now;
                DateTime dtDataProva = PontoBr.Conversoes.Data.ConverteDataBancoParaDateTime(sDataHoraAAAAMMDD_HHMM);
                if (dtDataAtual >= dtDataProva)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void CarregarOperadoresAgendamento()
        {
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.PreencherComboBox_Operadores(comboOperadorAgendamento, false, false);
            comboOperadorAgendamento.Text = fLogin.Usuario.Nome;
            comboOperadorAgendamento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmdBuscarCep_Click(object sender, EventArgs e)
        {
            BuscaCepWeb(txtCep.Text);
        }

        private void BuscaCepWeb(string sCEP)
        {
            try
            {
                sCEP = PontoBr.Utilidades.String.RemoverCaracteresMascara(sCEP.Trim());

                string sViaCEP = "http://viacep.com.br/ws/" + sCEP + "/xml/";
                string Cep, Retorno;
                XmlTextReader xml = new XmlTextReader(sViaCEP);
                xml.MoveToContent();

                do
                {
                    Cep = xml.Name;
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        xml.Read();
                        Retorno = xml.Value;
                        switch (Cep)
                        {
                            case "logradouro":
                                {
                                    txtLogradouro.Text = Retorno;
                                    break;
                                }
                            case "bairro":
                                {
                                    txtBairro.Text = Retorno;
                                    break;
                                }
                            case "localidade":
                                {
                                    txtCidade.Text = Retorno;
                                    break;
                                }
                            case "uf":
                                {
                                    txtEstado.Text = Retorno;
                                    break;
                                }
                        }
                    }
                }
                while (xml.Read());
            }
            catch
            {
                MessageBox.Show("Não foi possível localizar [CEP] \nou não há conectividade com o serviço [http://viacep.com.br/].", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdTeste_Click(object sender, EventArgs e)
        {
            PegarRetornoTentativasVonix();
        }

        //===============LEUCOTRON==========================================

        //Conectar Host
        private void ConectarLeucotron(String sIPServidor, Int32 iPortaServidor)
        {
            try
            {
                if (ClientTCP != null)
                {
                    ClientTCP.Close();
                    RegistrarEventos("(ConectarLeucotron) Client Nulo, Client Fechado..");
                }
                ClientTCP = new TcpClient(sIPServidor, iPortaServidor);
                RegistrarEventos("Conectado com (PABX Leucotron) no Host: " + sIPServidor + "  na porta: " + iPortaServidor);
            }
            catch (Exception ex)
            {
                RegistrarEventos("Não conectado com a Leucotron..  " + ex);
            }
        }

        //Desconectar
        private void DesconectarLeucotron()
        {
            if (ClientTCP != null)
            {
                ClientTCP.Close();
                ClientTCP = null;
                RegistrarEventos("(DesconectarLeucotron) Client Nulo, Client Fechado..");
            }
        }

        //Discar
        private void Discar(String sRamal, String sTelefoneLeucotron, String sNomeOperador)
        {
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("00001|LOGIN_CALLCENTER|Simulador Call Center" + "\n");
                stream = ClientTCP.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                Thread.Sleep(1000);

                // Translate the passed message into ASCII and store it as a Byte array.
                data = System.Text.Encoding.ASCII.GetBytes("00002|LOGIN_RAMAL|" + sRamal + "|" + sNomeOperador + "\n");

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                Thread.Sleep(1000);

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //RegistrarEventos(responseData); informações de retorno

                // Translate the passed message into ASCII and store it as a Byte array.
                data = System.Text.Encoding.ASCII.GetBytes("00003|RQ_CHAMADA_EXTERNA|" + sRamal + "|" + sTelefoneLeucotron + "\n");

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                Thread.Sleep(1000);

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //RegistrarEventos(responseData);//informações de retorno

                RegistrarEventos("Discando para: " + sTelefoneLeucotron + " no Ramal: " + sRamal + " do Operador(a): " + sNomeOperador);
            }
            catch
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("Não foi possível estabelecer uma comunicação com o PABX da Leucotron. \nFavor entrar em contato com a T.i local", "Tabulare Software");
            }
        }

        //Discagem Preview para Ceitel
        private void DiscarPreviewLeucotron()//r
        {
            try
            {
                AtualizarStatusFormulario(STATUS_CONECTADO_COM_PROSPECT);

                string sTelefone = "";

                if (radTel1.Checked == true)
                    sTelefone = txtTelefone1.Text;
                else if (radTel2.Checked == true)
                    sTelefone = txtTelefone2.Text;
                else if (radTel3.Checked == true)
                    sTelefone = txtTelefone3.Text;


                string sRamal = fLogin.Usuario.Ramal;
                string sIPServidor = fLogin.Configuracao.IPServidor.ToString();
                int iPortaServidor = Convert.ToInt32(fLogin.Configuracao.PortaServidor);
                string sNomeOperador = fLogin.Usuario.Nome.ToString();

                try
                {
                    if (ClientTCP.Connected == false)
                    {
                        ConectarLeucotron(sIPServidor, iPortaServidor);
                        RegistrarEventos("Reconectando no Leucotron no Host: " + sIPServidor + "  na porta: " + iPortaServidor);
                    }
                }
                catch { }

                string sTelefoneLeucotron = 0 + sTelefone;
                Discar(sRamal, sTelefoneLeucotron, sNomeOperador);
            }
            catch
            { }
        }

        //Próximo Prospect Preview para Ceitel (futuramente generico para todos cliente Leumcotron)
        private void ProximoProspectPreview()//r
        {
            listBoxEventos.Text = "";
            RetornarProxProspect();

            //Salva a Data de Abertura na tabela tHistorico
            sDataAbertura = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void DiscarURL(string sTelefone)
        {
            try
            {
                string sRamal = fLogin.Usuario.Ramal;

                if (sTelefone.Length == 10)
                {
                    //Se for DDD 31, retira o DDD - Ligação local não precisa de DDD
                    if (sTelefone.Substring(0, 2) == "31")
                    {

                        // discar.NroTelefDestino = sTelefone.Substring(2, 8);
                        ///https://capitaltelecom.virtualpabxip.com.br/api/call.php?apikey=GsZggivfFBP6F8ZU07PtJolK1CpIR3GD&ramal=RAMAL&telefone=TELEFONE
                    }
                    //Se for DDD diferente de 31 e o telefone tiver 10 digitos - "0" + "Operadora" + "DDD"
                    else if (sTelefone.Substring(0, 2) != "31" && sTelefone.Length == 10)
                    {
                        // discar.NroTelefDestino = 0 + sOperadora + sTelefone;
                    }
                }
                else
                {
                    //Se for DDD 31, retira o DDD - Ligação local não precisa de DDD
                    if (sTelefone.Substring(0, 2) == "31")
                    {
                        // discar.NroTelefDestino = sTelefone.Substring(2, 9);
                    }
                    //Se for DDD diferente de 31 e o telefone tiver 10 digitos - "0" + "Operadora" + "DDD"
                    else if (sTelefone.Substring(0, 2) != "31" && sTelefone.Length == 10)
                    {
                        // discar.NroTelefDestino = 0 + sOperadora + sTelefone;
                    }
                }

                string sComando;
                string sCodigoAcessoExterno = "0";

                //Envia os eventos para o listBoxEventos
                if (sTelefone.Substring(0, 2) == "31")
                {
                    sComando = "Discando para " + sTelefone + "..." + Environment.NewLine; RegistrarEventos(sComando);
                }
                else
                {
                    sComando = "Discando para " + sCodigoAcessoExterno + sOperadora + sTelefone + "..." + Environment.NewLine; RegistrarEventos(sComando);
                }
            }
            catch (Exception ex)
            {
                RegistrarEventos("Não foi possível efetuar a chamada.");
            }
        }

        //private void RetornarMensagensTratamentoVenda(int iIDUsuario, string sPerfil)
        //{

        //    prospectCTL CProspect = new prospectCTL();
        //    DataTable dataTable = CProspect.RetornarMensagensTratamentoVenda(iIDUsuario, sPerfil);
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        lblAlertaMsg.Visible = true;
        //        picMsg.Visible = true;
        //        lblAlertaMsg.Text = "Você tem uma nova mensagem, favor consultar suas vendas.";
        //    }
        //    else
        //    {
        //        lblAlertaMsg.Visible = false;
        //        picMsg.Visible = false;
        //    }
        //}

        //private void timerTratamentoVenda_Tick(object sender, EventArgs e)
        //{
        //    RetornarMensagensTratamentoVenda(fLogin.Usuario.IDUsuario, fLogin.Usuario.Perfil);
        //}

    }
}
