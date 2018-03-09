using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller;
using model.objetos;
using controller;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Configuration;

public partial class login_Default : App_Code.BaseWeb //// TESTE GITHUB DE ROBSON PARA CHICÃO!!!!!!!!!!!!1
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsuario.Focus();
        Page.Form.DefaultButton = cmdEntrar.UniqueID;

        if (!IsPostBack)
        {
            //Teste do Chicão para o Robson
            //Variável de sessão para guardar o browser do usuário
            HttpContext.Current.Session["Browser"] = Request.Browser.Browser.ToString();

            //Versão do sistema igual do Windows form
            string sVersaoAplicativo = "v6.0";
            string sRelease = "r03";

            CarregarConfiguracoes();

            usuarioCTL CUsuario = new usuarioCTL();
            configuracao Configuracao;
            Configuracao = (configuracao)HttpContext.Current.Session["Configuracao"];

            int iLicenca = Configuracao.Licenca;
            int iAtivos = CUsuario.RetornarQuantidadeOperadores();
            string nOperadores = "Licenciado para " + iLicenca + " operadores - Ativos: " + iAtivos;

            lblCopyright.Text = "Copyright © " + DateTime.Now.Year + " - PontoBR Sistemas - Versão Framework - " + PontoBr.Configuracao.Versao + " - " + sVersaoAplicativo + " (" + sRelease + ") - " + nOperadores;

            if (ConfigurationManager.AppSettings["TestandoSistema"].ToString() == "Sim")
            {
                txtUsuario.Attributes.Add("value", "s");
                txtSenha.Attributes.Add("value", "s"); 
                txtRamal.Attributes.Add("value", "12345");   
            }
       

            //CarregarConfiguracoes();

            if (Request.QueryString["e"] != null)
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Sessão encerrada!\\n\\nCaso queira, faça novo login no sistema.", this.Page);
        }
    }

    protected void cmdEntrar_Click(object sender, EventArgs e)
    {
        try
        {
    
            if (PodeLogar())
            {
                /*Registrar log de acesso*/
                try
                {
                    usuario Usuario = new usuario();
                    configuracao Configuracao;

                    configuracaoCTL CConfiguracao = new configuracaoCTL();
                    Configuracao = new configuracao(null, null, null, null, null, null, null, false, null);

                    Usuario = (usuario)HttpContext.Current.Session["Usuario"];
                    Configuracao = (configuracao)HttpContext.Current.Session["Configuracao"];

                    string sIP = HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];

                    if (Usuario.Perfil == "Operador")
                    {
                        Response.Redirect("../operador/atendimento.aspx");
                    }
                    else if (Usuario.Perfil == "Supervisor")
                    {
                        if (ConfigurationManager.AppSettings["TestandoSistema"].ToString() != "Sim")
                            Response.Redirect("../supervisor/default.aspx");
                        else
                            Response.Redirect("../relatorio/vendasSintetico.aspx");
                    }
                    else if (Usuario.Perfil == "BackOffice")
                    {
                        Response.Redirect("../backoffice/default.aspx");
                    }
                    else
                        PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Perfil " + Usuario.Perfil + " sem permissão para acesso.", this.Page);
                }
                catch { }
                /*Registrar log de acesso*/
            }
        }
        catch (Exception ex)
        {
            string sMensagem = ex.Message;

            if (sMensagem.IndexOf("error: 26") > 0)
                sMensagem = "O servidor de banco de dados está inacessível.\n\nFavor procurar a empresa ou pessoa responsável pelo servidor.";
            else if (sMensagem.IndexOf("timeout") > 0)
                sMensagem = "O servidor de banco de dados está inacessível.\n\nFavor procurar a empresa ou pessoa responsável pelo servidor.";

            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
        }
    }

    private bool PodeLogar()
    {
        if (txtUsuario.Text == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Login].", this.Page);
            return false;
        }
        if (txtSenha.Text == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Senha].", this.Page);
            return false;
        }
        if (txtRamal.Text == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Ramal].", this.Page);
            return false;
        }
        usuarioCTL CUsuario = new usuarioCTL();
        usuario Usuario = new usuario();
        Usuario = CUsuario.RetornarUsuario(PontoBr.Utilidades.String.RemoverCaracterInvalido(txtUsuario.Text.Replace(".", "").Replace("-", "")), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtSenha.Text), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtRamal.Text.Replace(".", "").Replace("-", "")));
        if (Usuario.IDUsuario == 0)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("[Login] e/ou [Senha] incorreto(s).", this.Page);
            return false;
        }
        else
            HttpContext.Current.Session["Usuario"] = Usuario;

        return true;
    }

    private void CarregarConfiguracoes()
    {
        try
        {
            configuracao Configuracao;

            configuracaoCTL CConfiguracao = new configuracaoCTL();
            Configuracao = new configuracao(null, null, null, null, null, null, null, false, null);
            Configuracao = CConfiguracao.RetornarConfiguracoes();

            Session["Configuracao"] = Configuracao;

            //Licenças
            int iNumeroOperadores = Configuracao.Licenca;
        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Erro para carregar informações iniciais do Tabulare.\n\n" + ex.Message, this.Page);
        }
    }
}
