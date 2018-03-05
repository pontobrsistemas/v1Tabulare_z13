using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using controller;
using System.Data;
using model.objetos;

public partial class operador_trocarSenha : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSenhaAtual.Focus();
    }

    protected void bntSalvar_Click(object sender, EventArgs e)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        if (PodeSalvar())
        {
            string sMensagem;
            usuarioCTL CUsuario = new usuarioCTL();
            CUsuario.AlterarSenha(Usuario.IDUsuario, txtNovaSenha.Text);

            sMensagem = "Senha alterada com sucesso!";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
        }
    }

    private bool PodeSalvar()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        string sMensagem;
        if (txtSenhaAtual.Text.Trim() == "")
        {
            LimparCampos();
            sMensagem = "Preencha [Senha Atual].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtNovaSenha.Text.Trim() == "")
        {
            LimparCampos();
            sMensagem = "Preencha [Nova Senha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtRepetirNovaSenha.Text.Trim() == "")
        {
            LimparCampos();
            sMensagem = "Preencha [Repetir Nova Senha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtNovaSenha.Text.Trim() != txtRepetirNovaSenha.Text.Trim())
        {
            LimparCampos();
            sMensagem = "[Nova Senha] está diferente de [Repetir Nova Senha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        usuarioCTL CUsuario = new usuarioCTL();
        if (CUsuario.VerificarSenhaAtual(Usuario.IDUsuario, txtSenhaAtual.Text) == false)
        {
            LimparCampos();
            sMensagem = "[Senha Atual] está incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        Usuario = CUsuario.RetornarUsuario(Usuario.IDUsuario);
        if (Usuario.Senha == txtNovaSenha.Text.Trim())
        {
            LimparCampos();
            sMensagem = "A [Nova Senha] não pode ser igual a [Senha Atual].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }

    private void LimparCampos()
    {
        txtSenhaAtual.Text = "";
        txtNovaSenha.Text = "";
        txtRepetirNovaSenha.Text = "";
        txtSenhaAtual.Focus();
    }
}