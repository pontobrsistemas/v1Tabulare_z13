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

public partial class relatorio_exportarMailing : System.Web.UI.Page 
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
        CarregarMailings(iIDCampanha);
        CarregarStatus(iIDCampanha);
    }

    private void CarregarStatus(int iIDCampanha)
    {
        statusCTL CStatus = new statusCTL();
        CStatus.PreencherCheckBoxListStatus(chkStatus, iIDCampanha);

        foreach (ListItem listItem in chkStatus.Items)
            listItem.Selected = true;
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

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    private void ExportarRelatorio()
    {
        try
        {
            int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue);
            int iIDMailing = Convert.ToInt32(dropMailing.SelectedValue);
            string sIDStatus = "";

            int iSelecionados = 0;
            foreach (ListItem listItem in chkStatus.Items)
            {
                if (listItem.Selected)
                {
                    sIDStatus += sIDStatus != "" ? ", " + listItem.Value : listItem.Value;
                    iSelecionados++;
                }
            }
            if (iSelecionados == chkStatus.Items.Count)
                sIDStatus = "";

            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = CRelatorio.RetornarExportacaoMailing(iIDCampanha, iIDMailing, sIDStatus);

            dgDados.DataSource = dataTable;
            dgDados.DataBind();

            if (dataTable.Rows.Count > 0)
            {
                lblMensagem.Text = "";
                
                Response.Clear();
                string sNomeArquivo = "Tabulare_ExportacaoMailing.xls";
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
            else
                lblMensagem.Text = "Não há prospects neste [Mailing].";

        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(ex.Message, this.Page);
        }
    }

    private bool PodeExportar()
    {
        lblMensagem.Text = "";
        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            lblMensagem.Text = "Selecione uma [Campanha].";
            return false;
        }
        if (dropMailing.SelectedValue.ToString() == "-1")
        {
            lblMensagem.Text = "Selecione um [Mailing].";
            return false;
        }
        return true;
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

    protected void cmdTodos_Click(object sender, EventArgs e)
    {
        foreach (ListItem listItem in chkStatus.Items)
            listItem.Selected = true;
    }

    protected void cmdNenhum_Click(object sender, EventArgs e)
    {
        foreach (ListItem listItem in chkStatus.Items)
            listItem.Selected = false;
    }

    protected void cmdExportar_Click(object sender, EventArgs e)
    {
        if (PodeExportar())
            ExportarRelatorio();  
    }
}