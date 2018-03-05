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

public partial class relatorio_statusMailing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

            CarregarCampanhas(Usuario.IDUsuario);
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor|BackOffice")) Response.Redirect("../login/logout.aspx?e=logout");

        usuario Usuario = new usuario();
        Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        if (Usuario.Perfil == "Supervisor")
        {
            MasterPageFile = "~/MasterPage/supervisor.master";
        }
        else if (Usuario.Perfil == "BackOffice")
        {
            MasterPageFile = "~/MasterPage/backoffice.master";
        }
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
            CMailing.CarregarDropdownMailings(dropMailing, iIDCampanha, false, true, false);
        }
        catch { }
    }    

    private bool PodePesquisar()
    {
        string sMensagem;
        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (dropMailing.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione [Mailing].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void cmdPesquisar_Click(object sender, EventArgs e)
    {
        if (PodePesquisar())
        {
            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = CRelatorio.RetornarStatusMailing(Convert.ToInt32(dropMailing.SelectedValue));

            dgDados.DataSource = dataTable;
            dgDados.DataBind();

            lblRegistros.Text = "| " + dgDados.Rows.Count.ToString() + " registro(s) |";
        }
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (dgDados.Rows.Count > 0)
        {
            Response.Clear();
            string sNomeArquivo = "Tabulare_StatusMailing.xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + sNomeArquivo + "");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter sWr = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hWr = new HtmlTextWriter(sWr);
            dgDados.RenderControl(hWr);
            Response.Write(sWr.ToString());
            Response.End();
        }
    }

    protected void dgDados_RowDataBound(object sender, GridViewRowEventArgs e)
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