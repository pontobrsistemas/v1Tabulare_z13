using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using controller;
using model.objetos;
using PontoBr.Utilidades;
using System.IO;
using System.Net;
using v1Tabulare_z13.PlanetFone;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Win32;

namespace tabulare
{
    public partial class fLogin : Form
    {
        public static string sVersaoAplicativo = "v6.0";
        public static string sRelease = "r04";
        public static int iIDDiaSemana;
        public static usuario Usuario;
        public static usuario UsuarioInfo;
        public static configuracao Configuracao;
        public static int iNumeroOperadores;
        public static int iIntervaloAtualizacaoTempoExpiracao = 5; //Segundos   
        private wenvpabx2 wss;

        public fLogin()
        {
            InitializeComponent();
        }

        private void CarregarLayout()
        {
            // this.BackColor = System.Drawing.Color.FromName("Gainsboro"); 
            this.ControlBox = false;

            string sFormulario = "TABULARE - LOGIN";
            this.Text = sFormulario + " - " + fLogin.sVersaoAplicativo + " (" + fLogin.sRelease + ")";
            login Login = new login();

            usuarioCTL CUsuario = new usuarioCTL();
            int iAtivos = CUsuario.RetornarQuantidadeOperadores();

            lblVersaoFramework.Text = "Versão Framework - " + PontoBr.Configuracao.Versao;
            lblLicenca.Text = "Licenciado para " + fLogin.iNumeroOperadores.ToString() + " operadores - Ativos: " + iAtivos;
        }

        private void ExibirForm(Form form)
        {
            this.Hide();
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
            form.Show();
            this.Close();
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            Application.Exit();
            this.Close();
        }

        private void cmdEntrar_Click(object sender, EventArgs e)
        {
            if (PodeEntrar())
            {
                try
                {
                    usuarioCTL CUsuario = new usuarioCTL();

                    string sLogin = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtLogin.Text);
                    string sSenha = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtSenha.Text);
                    string sRamal = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtRamal.Text);

                    int iIDUsuario = CUsuario.RetornarUsuario(sLogin, sSenha, 1);
                    if (iIDUsuario != 0)
                    {
                        //Cadastra ou atualiza o ramal de acordo com o DNS da máquina
                        CadastrarRamal();

                        Usuario = CUsuario.RetornarUsuario(iIDUsuario);
                        if (Usuario.IDUsuario == 0)
                        {
                            MessageBox.Show("O usuário não está vinculado à nenhuma Campanha.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Usuario = CUsuario.RetornarUsuario(sLogin, sSenha, sRamal);
                        Usuario.Agente = txtRamal.Text;
                        string sPerfil = Usuario.Perfil;

                        //De acordo com o Usuário do Agent (PlanetFone), retorna o NroAgente
                        if (fLogin.Configuracao.TipoPabx == "PlanetFone")
                        {
                            if (Usuario.Perfil == "Operador")
                            {
                                try
                                {
                                    RetornarNroAgente();

                                    CUsuario.AtualizarNroAgente(Usuario.IDUsuario, operador.fAtendimento.NroAgente);

                                    //Libera a tela do Operador porque o robô envia contato mesmo não logado no Tabulare
                                    if (fLogin.Usuario.TipoDiscador != "Power")
                                    {
                                        //Deixa o IDProspect = NULL - Para liberar a tela do Operador (Preditivo)
                                        CUsuario = new usuarioCTL();
                                        CUsuario.PausaAgente(fLogin.Usuario.IDUsuario, 0);

                                        //1 = Tabulare Logado (Necessário Preditivo) | 0 = Tabulare não Logado
                                        CUsuario.TabulareLogado(fLogin.Usuario.IDUsuario, 1);
                                    }
                                }
                                catch (Exception ex) /*Quando não conseguir integrar */
                                {
                                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message + "\n\nNão foi possível conectar no PlanetFone.\n\nO Tabulare irá funcionar sem a integração com o PABX.", "Tabulare Software");
                                }
                            }
                        }

                        //Licença
                        if (Usuario.Perfil == "Operador")
                        {
                            if (CUsuario.RetornarQuantidadeOperadores() > fLogin.iNumeroOperadores)
                            {
                                string sMensagem = "Sua licença execedeu o limite de usuários (perfil Operador).";
                                sMensagem += " Atualmente seu limite é de " + fLogin.iNumeroOperadores.ToString() + " operadores.";
                                sMensagem += "\n\nPeça o supervisor para acessar o Tabulare e, dentro do Módulo de Usuários, gerenciar a quantidade de operadores.";

                                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(sMensagem, "Tabulare Software");
                                return;
                            }
                        }

                        // int user = Convert.ToInt32(fLogin.iNumeroOperadores.ToString()) - CUsuario.RetornarQuantidadeOperadores();

                        if (VerificarVersaoDiscador() == true)
                            Logar(Usuario.Perfil);
                    }
                    else
                    {
                        MessageBox.Show("Login e/ou Senha inválido(s).", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Text = "";
                        txtSenha.Text = "";
                        txtLogin.Focus();
                    }
                }
                catch (Exception ex)
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
                }
            }
        }

        private bool PodeEntrar()
        {
            string sMensagem;

            //Verifica se existe o arquivo conexao.ini
            if (!File.Exists("conexao.ini"))
            {
                sMensagem = "O arquivo de configuração conexao.ini não existe. Favor entrar em contato com a TI local.";

                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdEntrar.Enabled = false;
                return false;
            }

            #region Data de Expiração do Tabulare
            //DateTime dataExpiracao = new DateTime(2011, 7, 3);
            //if (DateTime.Now > dataExpiracao)
            //{
            //    sMensagem = "A Licença do Tabulare expirou.\n\nFavor entrar em contato com a PontoBR Sistemas.";
            //    MessageBox.Show(sMensagem, "Tabulare");
            //    return false;
            //}
            #endregion

            if (txtLogin.Text.Trim() == "")
            {
                sMensagem = "Login inválido.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return false;
            }
            if (txtSenha.Text.Trim() == "")
            {
                sMensagem = "Senha inválida.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Focus();
                return false;
            }
            if (txtRamal.Text.Trim() == "")
            {
                sMensagem = "Ramal inválido.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtRamal.Text.Length < 3)
            {
                sMensagem = "Ramal inválido.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            double dRamal;
            if (Double.TryParse(PontoBr.Utilidades.String.RemoverCaracterInvalido(txtRamal.Text), out dRamal) == false && PontoBr.Utilidades.String.RemoverCaracterInvalido(txtRamal.Text) != "")
            {
                sMensagem = "Ramal inválido.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (fLogin.Configuracao.TipoPabx == "PlanetFone")
            {
                if (txtAgent.Text.Trim() == "")
                {
                    sMensagem = "Agente inválido.";
                    MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void CarregarStringConexao()
        {
            try
            {
                configuracaoCTL CConfiguracao = new configuracaoCTL();
                CConfiguracao.CarregarStringConexao();
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            usuarioCTL CUsuario = new usuarioCTL();
            //Permite apenas 1 Tabulare aberto por máquina
            Process[] processos = Process.GetProcesses();
            int iNumTabuAberto = 0;
            foreach (Process processo in processos)
            {
                if (processo.ProcessName.ToUpper().IndexOf("TABULA") > -1 && processo.MainModule.ModuleName != "v1Tabulare_z13.vshost.exe")
                    iNumTabuAberto++;
            }

            if (iNumTabuAberto > 1)
            {
                cmdEntrar.Visible = false;
                MessageBox.Show("Só é permitida a abertura de uma instância do Tabulare.", "Tabulare Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            /*Verifica se o Crystal está instalado na máquina*/
            string sProgramasInstalados = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            bool bCrystalInstalado = false;
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(sProgramasInstalados))
            {
                foreach (string sPrograma in registryKey.GetSubKeyNames())
                {
                    using (RegistryKey subRegistryKey = registryKey.OpenSubKey(sPrograma))
                    {
                        try
                        {
                            string x = (subRegistryKey.GetValue("DisplayName") + "  " + subRegistryKey.GetValue("DisplayVersion"));
                            if (x.IndexOf("Crystal Reports") > -1)
                            {
                                bCrystalInstalado = true;
                            }
                        }
                        catch { }
                    }
                }
                if (!bCrystalInstalado)
                {
                    cmdEntrar.Visible = false;
                    MessageBox.Show("Componente Crystal Reports não instalado neste computador.\n\nFavor contactar a TI local.", "Tabulare Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            CarregarStringConexao();
            CarregarConfiguracoes();
            CarregarLayout();
            try
            {
                VerificarExistenciaRamal();
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare");
            }

            /*Se tiver testando o sistema*/
            if (usuarioCTL.bTestandoSistema == false)
            {
                txtLogin.Text = "s";
                txtSenha.Text = "s";
                txtRamal.Text = "1712";
                txtAgent.Text = "everkelly.lima";
            }

            //txtLogin.Text = "planetfone.s";
            //txtSenha.Text = "planeta";
            //txtRamal.Text = "9999";
            //txtAgent.Text = "planetfone.s";
        }

        private void VerificarExistenciaRamal()
        {
            string sDns = Dns.GetHostName();
            configuracaoCTL CConfiguracao = new configuracaoCTL();

            int iRamal = CConfiguracao.VerificarRamalDNS(sDns);

            if (iRamal != 0)
                txtRamal.Text = iRamal.ToString();
        }

        private void CadastrarRamal()
        {
            string sDns = Dns.GetHostName();
            configuracaoCTL CConfiguracao = new configuracaoCTL();

            CConfiguracao.CadastrarRamalDNS(Convert.ToInt32(PontoBr.Utilidades.String.RemoverCaracterInvalido(txtRamal.Text)), sDns, txtAgent.Text);
        }

        private void CarregarConfiguracoes()
        {
            try
            {
                configuracaoCTL CConfiguracao = new configuracaoCTL();
                Configuracao = new configuracao(null, null, null, null, null, null, null, false, null);
                Configuracao = CConfiguracao.RetornarConfiguracoes();

                if (fLogin.Configuracao.TipoPabx == "Modem")
                {
                    txtAgent.Visible = false;
                    lblAgent.Visible = false;
                    cmdEntrar.Location = new Point(62, 146);
                    cmdSair.Location = new Point(148, 146);
                }
                else if (fLogin.Configuracao.TipoPabx == "PlanetFone")
                {
                    txtAgent.Visible = true;
                    lblAgent.Visible = true;
                    cmdEntrar.Location = new Point(61, 178);
                    cmdSair.Location = new Point(148, 177);
                }
                else if (fLogin.Configuracao.TipoPabx == "Digistar")
                {
                    txtAgent.Visible = false;
                    lblAgent.Visible = false;
                    cmdEntrar.Location = new Point(62, 146);
                    cmdSair.Location = new Point(148, 146);
                }
                else if (fLogin.Configuracao.TipoPabx == "Vonix")
                {
                    txtAgent.Visible = false;
                    lblAgent.Visible = false;
                    lblRamal.Text = "Agente (Vonix):";
                    lblRamal.Location = new Point(59, 97);

                    cmdEntrar.Location = new Point(62, 146);
                    cmdSair.Location = new Point(148, 146);
                }
                else if (fLogin.Configuracao.Cliente == "Mundiale" || fLogin.Configuracao.Cliente == "Vgx")
                {
                    lblRamal.Text = "Ramal (Callflex):";
                    lblRamal.Location = new Point(33, 89);
                }
                else if (fLogin.Configuracao.TipoPabx == "Leucotron")
                {
                    txtAgent.Visible = false;
                    lblAgent.Visible = false;
                    lblRamal.Text = "Ramal (Leucotron):";
                    lblRamal.Location = new Point(59, 97);

                    cmdEntrar.Location = new Point(62, 146);
                    cmdSair.Location = new Point(148, 146);

                    //txtAgent.Visible = false;
                    //lblAgent.Visible = false;
                    //lblRamal.Text = "Ramal (Leucotron):";
                    //lblRamal.Location = new Point(20, 89);

                    //cmdEntrar.Location = new Point(115, 113);
                    //cmdSair.Location = new Point(202, 113);
                }

                //Licenças
                iNumeroOperadores = Configuracao.Licenca;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro para carregar informações iniciais do Tabulare.\n\n" + ex.Message, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool VerificarVersaoDiscador()
        {
            try
            {
                if (sVersaoAplicativo != Configuracao.VersaoDiscador)
                {
                    cmdEntrar.Enabled = false;
                    MessageBox.Show("A versão correta do Tabulare é " + Configuracao.VersaoDiscador + ". Você está com a versão desatualizada " + sVersaoAplicativo + ". \n\nReinicie o computador e, caso o problema persista, favor entrar em contato com a TI local.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparFormulario();
                    return false;
                }
                if (sVersaoAplicativo == Configuracao.VersaoDiscador)
                {
                    cmdEntrar.Enabled = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
            return false;
        }

        private void Logar(string sPerfil)
        {
            if (sPerfil == "Supervisor") ExibirForm(new fSupervisor());
            else if (sPerfil == "Administrador") ExibirForm(new fAdministrador());
            else if (sPerfil == "BackOffice") ExibirForm(new fBackOffice());
            else if (sPerfil == "Operador") ExibirForm(new fOperador());
        }

        private void LimparFormulario()
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtRamal.Text = "";
        }

        private void txtRamal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.", "Tabulare Software", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RetornarNroAgente()
        {
            wenvpabx2 wss = ws.PlanetFone.getInstancia().getWS();
            string sAgent = txtAgent.Text;

            preditivoCTL CPreditivo = new preditivoCTL();
            foreach (DataRow dataRow in CPreditivo.RetornarFilas().Rows)
            {
                StatusAgentesFilasAtual statusAgentesFilasAtual = new StatusAgentesFilasAtual();
                statusAgentesFilasAtual.CodFila = dataRow["IDFila"].ToString();

                StatusAgentesFilasAtualResponse statusAgentesFilasAtualResponse = new StatusAgentesFilasAtualResponse();
                statusAgentesFilasAtualResponse = wss.StatusAgentesFilasAtual(statusAgentesFilasAtual);

                StatusAgentesFilasAtualResultado statusAgentesFilasAtualResultado = new StatusAgentesFilasAtualResultado();
                statusAgentesFilasAtualResultado = statusAgentesFilasAtualResponse.StatusAgentesFilasAtualResultado;

                for (int i = 0; i < statusAgentesFilasAtualResponse.StatusAgentesFilasAtualResultado.ArrayOfStatusAgentesFilasAtualStatusAgentesFila.Length; i++)
                {
                    SituacaoAgente situacaoAgente = new SituacaoAgente();
                    situacaoAgente.NroAgente = statusAgentesFilasAtualResultado.ArrayOfStatusAgentesFilasAtualStatusAgentesFila[i].NroAgente;

                    SituacaoAgenteResponse situacaoAgenteResponse = new SituacaoAgenteResponse();
                    situacaoAgenteResponse = wss.SituacaoAgente(situacaoAgente);

                    SituacaoAgenteResultado situacaoAgenteResultado = new SituacaoAgenteResultado();
                    situacaoAgenteResultado = situacaoAgenteResponse.SituacaoAgenteResultado;

                    if (situacaoAgenteResultado.ArrayOfSituacaoAgenteStatusAgente[0].NomeAgente == sAgent)
                    {
                        operador.fAtendimento.NroAgente = statusAgentesFilasAtualResultado.ArrayOfStatusAgentesFilasAtualStatusAgentesFila[i].NroAgente;
                        operador.fAtendimento.CodFila = statusAgentesFilasAtual.CodFila;
                        operador.fAtendimento.NomedoAgente = sAgent;
                        return;
                    }
                }
            }
        }
    }
}
