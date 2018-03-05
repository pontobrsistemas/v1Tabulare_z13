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

public partial class supervisor_midia : /*App_Code.BaseWeb*/ System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarCampanhas();

            txtdatDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdatDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    private void CarregarCampanhas()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.CarregarCampanhasAtivasCheckBoxList(chkCampanha, Usuario.IDUsuario, Usuario.Perfil);
    }

    protected void bTnTodos_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
            this.chkCampanha.Items[i].Selected = true;
    }

    protected void bTnNenhum_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
            this.chkCampanha.Items[i].Selected = false;
    }

    protected void cmdGerar_Click(object sender, EventArgs e)
    {
        if (PodeGerar())
            GerarRelatorio();
    }
    protected void cmdExportar_Click(object sender, EventArgs e)
    {
        if (PodeGerar())
            ExportarRelatorio();
    }

    private void ExportarRelatorio()
    {
        try
        {
            string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
            string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";

            campanhaCTL CCampanha = new campanhaCTL();
            string sIDCampanhas = "";

            foreach (ListItem listItem in chkCampanha.Items)
            {
                if (listItem.Selected)
                    sIDCampanhas += sIDCampanhas != "" ? ", " + listItem.Value : listItem.Value;
            }

            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = CRelatorio.RetornarMidias(sDataInicial, sDataFinal, sIDCampanhas).Tables[1];

            dgDados.DataSource = dataTable;
            dgDados.DataBind();

            if (dataTable.Rows.Count > 0)
            {
                Response.Clear();
                string sNomeArquivo = "Tabulare_Midia.xls";
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
        catch { }
    }

    private void GerarRelatorio()
    {
        try
        {
            string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
            string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";

            campanhaCTL CCampanha = new campanhaCTL();
            string sIDCampanhas = "";

            foreach (ListItem listItem in chkCampanha.Items)
            {
                if (listItem.Selected)
                    sIDCampanhas += sIDCampanhas != "" ? ", " + listItem.Value : listItem.Value;
            }

            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = CRelatorio.RetornarMidias(sDataInicial, sDataFinal, sIDCampanhas).Tables[1];

            dgDados.DataSource = dataTable;
            dgDados.DataBind();

            lblRegistros.Text = "| " + dgDados.Rows.Count.ToString() + " registro(s) |";        
        }
        catch { }
    }

    private bool PodeGerar()
    {
        string sMensagem;
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataInicial.Text))
        {
            sMensagem = "[Data Inicial] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Nome].", this.Page);
            return false;
        }
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataInicial.Text))
        {
            sMensagem = "[Data Final] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Nome].", this.Page);
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

        bool bSelecionado = false;
        foreach (ListItem listItem in chkCampanha.Items)
        {
            if(listItem.Selected)
            bSelecionado = true;
        }
        if (bSelecionado == false)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Selecione, pelo menos, uma Campanha.", this.Page);
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

            //Conversão
            int iContatos = Convert.ToInt32(e.Row.Cells[1].Text);
            int iVendas = Convert.ToInt32(e.Row.Cells[2].Text);
            double dConversao = Convert.ToDouble(iVendas) / Convert.ToDouble(iContatos) * 100;

            e.Row.Cells[3].Text = Math.Round(dConversao, 1).ToString();
        }
    }
}
