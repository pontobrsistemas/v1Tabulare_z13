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

public partial class relatorio_contatosSintetico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
            CarregarCampanhas(Usuario.IDUsuario);

            txtdatDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdatDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CarregarOperadores();
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

    private void CarregarOperadores()
    {
        usuarioCTL CUsuario = new usuarioCTL();
        CUsuario.PreencherDrop_Operadores(dropOperador, true, false);
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
            CMailing.CarregarDropdownMailings(dropMailing, iIDCampanha, false, false, true);
        }
        catch { }
    }

    private bool PodePesquisar()
    {
        string sMensagem;
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataInicial.Text))
        {
            sMensagem = "[Data Inicial] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataFinal.Text))
        {
            sMensagem = "[Data Final] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }

        if (txtdatDataInicial.Text != "" && txtdatDataFinal.Text != "")
        {
            DateTime dDataInicial = Convert.ToDateTime(txtdatDataInicial.Text);
            DateTime dDataFinal = Convert.ToDateTime(txtdatDataFinal.Text);
            if (dDataFinal < dDataInicial)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("[Data Inicial] deve ser menor que a [Data Final].", this.Page);
                return false;
            }
        }


        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
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
    protected void cmdGerarDados_Click(object sender, EventArgs e)
    {
        if (PodeGerar())
            GerarRelatorio();
    }

    private void GerarRelatorio()
    {
        string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
        string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";
        int iIDUsuario = Convert.ToInt32(dropOperador.SelectedValue);
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue);
        int iIDMailing = Convert.ToInt32(dropMailing.SelectedValue);
        int iIDTipoAtendimento = -1;
        int iAposUltimoResubmit = 0;

        string sIDStatus = "";
        foreach (ListItem listItem in chkStatus.Items)
        {
            if (listItem.Selected)
                sIDStatus += sIDStatus != "" ? ", " + listItem.Value : listItem.Value;
        }

        relatorioCTL CRelatorio = new relatorioCTL();
        DataTable dataTable = CRelatorio.RetornarContatosTrabalhadosSintetico(sDataInicial, sDataFinal, iIDUsuario, iIDCampanha, iIDMailing, iIDTipoAtendimento, sIDStatus, iAposUltimoResubmit).Tables[1];

        dgDados.DataSource = dataTable;
        dgDados.DataBind();
    }

    private bool PodeGerar()
    {
        string sMensagem;
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataInicial.Text))
        {
            sMensagem = "[Data Inicial] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataFinal.Text))
        {
            sMensagem = "[Data Final] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }

        if (txtdatDataInicial.Text != "" && txtdatDataFinal.Text != "")
        {
            DateTime dDataInicial = Convert.ToDateTime(txtdatDataInicial.Text);
            DateTime dDataFinal = Convert.ToDateTime(txtdatDataFinal.Text);
            if (dDataFinal < dDataInicial)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("[Data Inicial] deve ser menor que a [Data Final].", this.Page);
                return false;
            }
        }

        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione uma [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (dgDados.Rows.Count > 0)
        {
            Response.Clear();
            string sNomeArquivo = "Tabulare_ContatosSintetico.xls";
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

    public override void VerifyRenderingInServerForm(Control control)
    {

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

        //Agrupar
        int iRowSpan = 2;
        int iColuna = 0;
        for (int i = dgDados.Rows.Count - 2; i >= 0; i--)
        {
            GridViewRow GridViewRowAtual = dgDados.Rows[i];
            GridViewRow GridViewRowAnterior = dgDados.Rows[i + 1];
            if (GridViewRowAtual.Cells[iColuna].Text == GridViewRowAnterior.Cells[iColuna].Text)
            {
                GridViewRowAtual.Cells[iColuna].RowSpan = iRowSpan;
                GridViewRowAnterior.Cells[iColuna].Visible = false;
                iRowSpan += 1;
            }
            else
                iRowSpan = 2;
        }
    }
}