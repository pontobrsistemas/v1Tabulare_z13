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
using System.Configuration;

public partial class supervisor_vendasSintetico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
            CarregarCampanhas(Usuario.IDUsuario, Usuario.Perfil);
            CarregarStatusAuditoria();

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

    private void CarregarStatusAuditoria()
    {
        auditoriaCTL CAuditoria = new auditoriaCTL();
        CAuditoria.PreencherDropdownStatusAuditoria(dropAuditoria, true, true, false);
    }

    private void CarregarCampanhas(int IDUsuario, string Perfil)
    {
        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.CarregarCampanhasAtivasCheckBoxList(chkCampanha, IDUsuario, Perfil);
    }

    private bool PodeGerar()
    {
        string sMensagem;
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataInicial.Text))
        {
            sMensagem = "[Data Inicial] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlerta(sMensagem);
            return false;
        }
        if (!PontoBr.Conversoes.Data.ValidarDataBr(txtdatDataFinal.Text))
        {
            sMensagem = "[Data Final] incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlerta(sMensagem);
            return false;
        }

        if (txtdatDataInicial.Text != "" && txtdatDataFinal.Text != "")
        {
            DateTime dDataInicial = Convert.ToDateTime(txtdatDataInicial.Text);
            DateTime dDataFinal = Convert.ToDateTime(txtdatDataFinal.Text);
            if (dDataFinal < dDataInicial)
            {
                PontoBr.Utilidades.Diversos.ExibirAlerta("[Data Inicial] deve ser menor que a [Data Final].");
                return false;
            }
        }

        bool bSelecionado = false;
        foreach (ListItem listItem in chkCampanha.Items)
        {
            if (listItem.Selected)
                bSelecionado = true;
        }
        if (bSelecionado == false)
        {
            PontoBr.Utilidades.Diversos.ExibirAlerta("Selecione, pelo menos, uma Campanha.");
           
            return false;
        }
        return true;
    }

    protected void cmdGerar_Click(object sender, EventArgs e)
    {
        if (PodeGerar())
            GerarRelatorio();
    }

    public void GerarRelatorio()
    {
        try
        {
            string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
            string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";
            int iIDStatusAuditoria = Convert.ToInt32(dropAuditoria.SelectedValue);

            campanhaCTL CCampanha = new campanhaCTL();
            string sIDCampanhas = "";
            foreach (ListItem listItem in chkCampanha.Items)
            {
                if (listItem.Selected)
                {
                    if (sIDCampanhas != "")
                        sIDCampanhas = sIDCampanhas + ",";

                    sIDCampanhas = sIDCampanhas + CCampanha.RetornarIDCampanha(listItem.ToString());
                }
            }

            int iIDTipoAtendimento = -1;

            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = CRelatorio.RetornarVendasSintetico(sDataInicial, sDataFinal, sIDCampanhas, iIDTipoAtendimento, iIDStatusAuditoria);

            dgDados.DataSource = dataTable;
            dgDados.DataBind();
            lblRegistros.Text = "| " + dgDados.Rows.Count.ToString() + " registro(s) |";

            CarregarGrafico();
        }
        catch
        { }
    }

    private void CarregarGrafico()
    {
        //Gráfico
        StringBuilder strScript = new StringBuilder();
        strScript.Append(@"<script type=""text/javascript""
          src=""https://www.google.com/jsapi?autoload={
            'modules':[{
              'name':'visualization',
              'version':'1',
              'packages':['corechart']
            }]
          }""></script>

        <script type=""text/javascript"">
        google.setOnLoadCallback(drawChart);

        function drawChart() {
        var data = google.visualization.arrayToDataTable([");
        
        strScript.Append("['Operador', 'Vendas'] ");
        if (dgDados.Rows.Count > 0)
        {
            fieldsetVendasSintetico.Visible = true;

            foreach (GridViewRow gridViewRow in dgDados.Rows)
            {
                strScript.Append(", ['" + gridViewRow.Cells[0].Text + "', " + gridViewRow.Cells[2].Text + "]");
            }
        }
        else
        {
            fieldsetVendasSintetico.Visible = false;
            
            strScript.Append(", ['', 0, '']");
        }

        strScript.Append("]);");

        strScript.Append(@"var options = {
                title: '',
                legend: { position: 'bottom' },
                hAxis: {textStyle : {fontSize: 10} }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('VendasSintetico'));
            chart.draw(data, options);
        }
        </script> ");

        string sScript = strScript.ToString();
        lblScript.Text = strScript.ToString();      
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

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (dgDados.Rows.Count > 0)
        {
            Response.Clear();
            string sNomeArquivo = "Tabulare_VendasSintetico.xls";
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

            //Conversão
            int iContatos = Convert.ToInt32(e.Row.Cells[1].Text);
            int iVendas = Convert.ToInt32(e.Row.Cells[2].Text);
            double dConversao = Convert.ToDouble(iVendas) / Convert.ToDouble(iContatos) * 100;
            e.Row.Cells[3].Text = Math.Round(dConversao, 1).ToString() + " %";

            //Conversão - "Prospects Únicos
            int iContatosProspectsUnicos = Convert.ToInt32(e.Row.Cells[4].Text);
            int iVendasProspectsUnicos = Convert.ToInt32(e.Row.Cells[2].Text);
            double dConversaoProspectsUnicos = Convert.ToDouble(iVendasProspectsUnicos) / Convert.ToDouble(iContatosProspectsUnicos) * 100;
            e.Row.Cells[5].Text = Math.Round(dConversaoProspectsUnicos, 1).ToString() + " %";            
        }
    }
}