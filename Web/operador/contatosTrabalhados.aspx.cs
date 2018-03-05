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
using model;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Linq;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Configuration;

public partial class operador_contatosTrabalhados : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            datDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
            datDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (PodeGerar())
                GerarRelatorio();
        }
    }

    private void GerarRelatorio()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        try
        {
            string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Text);
            string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Text);

            relatorioCTL CRelatorio = new relatorioCTL();
            CRelatorio.RetornarGridContatosTrabalhadosOperador(GridContatosTrabalhados, Usuario.IDUsuario, sDataInicial, sDataFinal);

            lblNumeroLinhas.Text = "| " + GridContatosTrabalhados.Rows.Count.ToString() + " registro(s) |";
        }
        catch
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Tabulare Software", this.Page);
        }
    }

    private bool PodeGerar()
    {
        string sMensagem;
        if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataInicial.Text))
        {
            sMensagem = "[Data Inicial] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }

        if (!PontoBr.Conversoes.Data.ValidarDataBr(datDataFinal.Text))
        {
            sMensagem = "[Data Final] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }

        if (datDataInicial.Text != "" && datDataFinal.Text != "")
        {
            DateTime dDataInicial = Convert.ToDateTime(datDataInicial.Text);
            DateTime dDataFinal = Convert.ToDateTime(datDataFinal.Text);
            if (dDataFinal < dDataInicial)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("[Data Inicial] deve ser menor que a [Data Final].", this.Page);
                return false;
            }
        }

        return true;
    }

    protected void GridContatosTrabalhados_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (GridContatosTrabalhados.Rows.Count > 0)
        {
            Response.Clear();
            string sNomeArquivo = "Tabulare_ContatosTrabalhados.xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + sNomeArquivo + "");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter sWr = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hWr = new HtmlTextWriter(sWr);
            GridContatosTrabalhados.RenderControl(hWr);
            Response.Write(sWr.ToString());
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void cmdGerarDados_Click(object sender, EventArgs e)
    {
        if (PodeGerar())
            GerarRelatorio();
    }
}