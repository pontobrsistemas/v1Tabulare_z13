using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using controller;
using model.objetos;
using System.Collections.Specialized;
using System.Xml;
using model;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.IO;

public partial class supervisor_mailingIndicacao : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

            CarregarCampanhas(Usuario.IDUsuario);
            CarregarMailingsIndicacao();
        }
    }

    private void CarregarMailingsIndicacao()
    {
        mailingCTL CMailing = new mailingCTL();
        CMailing.CarregarGridviewMailingsIndicacao(grdDados);

        lblRegistros.Text = "| " + grdDados.Rows.Count.ToString() + " registro(s) |";
    }

    private void CarregarCampanhas(int iIDUsuario)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDrop_Campanhas(dropCampanha, true, false, true, iIDUsuario, Usuario.Perfil);
    }

    protected void dropCampanha_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue.ToString());
        if (iIDCampanha != -1)
        {
            CarregarMailings(iIDCampanha);
        }
    }

    private void CarregarMailings(int iIDCampanha)
    {
        mailingCTL CMailing = new mailingCTL();

        try
        {
            CMailing.CarregarDropdownMailings(dropMailing, iIDCampanha,true, false, false);

            int iIDMailing = CMailing.RetornarMailingIndicacaoSupervisor(iIDCampanha);

            if (iIDMailing == 0)
                dropMailing.SelectedValue = "-1";
            else
                dropMailing.SelectedValue = iIDMailing.ToString();
        }
        catch { }
    }
    protected void cmdSalvar_Click(object sender, EventArgs e)
    {
        if (PodeSalvar())
        {
            mailingCTL CMailing = new mailingCTL();
            CMailing.SalvarMailingIndicacao(Convert.ToInt32(dropCampanha.SelectedValue), Convert.ToInt32(dropMailing.SelectedValue));

            CarregarMailingsIndicacao();
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Alterações salvas com sucesso.", this.Page);
        }
    }

    private bool PodeSalvar()
    {
        string sMensagem;
        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }

    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
        dropCampanha.SelectedValue = "-1";
        dropMailing.SelectedValue = "-1";
    }

    protected void grdDados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Alternate)
            {
                e.Row.Attributes.Add("onmouseover", "this.className='grid_row_selecionado'");
                e.Row.Attributes.Add("onmouseout", "this.className='grid_alternative_row'");
            }
            else
            {
                e.Row.Attributes.Add("onmouseover", "this.className='grid_row_selecionado'");
                e.Row.Attributes.Add("onmouseout", "this.className='grid'");
            }
        }
    }
}