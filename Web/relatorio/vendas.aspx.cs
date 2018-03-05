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

public partial class relatorio_vendas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
            CarregarCampanhas(Usuario.IDUsuario);
            CarregarStatusAuditoria();

            txtdatDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtdatDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CarregarOperadores();

            GerarRelatorio();
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

    public void GerarRelatorio()
    {
        try
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

            string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
            string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";

            int iIDOperadorAuditoria = Convert.ToInt32(DropOperador.SelectedValue);

            DataTable dataTable;
            campanhaCTL CCampanha = new campanhaCTL();
            string sIDCampanhas = dropCampanha.SelectedValue;

            string sCampoDadosVenda = "-1";
            if (dropDadosVenda.SelectedValue != null
                && dropDadosVenda.SelectedValue != "")
                sCampoDadosVenda = dropDadosVenda.SelectedValue;

            string sCamposVenda = "";
            dataTable = CCampanha.RetornarCamposVendaCampanhas(Convert.ToInt32(dropCampanha.SelectedValue));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                sCamposVenda += sCamposVenda != "" ? ", " + "'" + dataRow["Texto"].ToString() + "'" : "'" + dataRow["Texto"].ToString() + "'";
            }

            string sCamposProspectExtra = "";
            string sCamposProspectFixo = "";

            //Status da Auditoria
            string sIDAuditoria = "";
            if (dropStatusAuditoria.SelectedValue == "-1")
            {
                auditoriaCTL CAuditoria = new auditoriaCTL();
                dataTable = CAuditoria.RetornarStatusAuditoria(false);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    sIDAuditoria += sIDAuditoria != "" ? ", " + dataRow["Cód."] : dataRow["Cód."];
                }
            }
            else
                sIDAuditoria = dropStatusAuditoria.SelectedValue;

            relatorioCTL CRelatorio = new relatorioCTL();

            //Se o perfil for Supervisor, exibe todas as vendas.
            //Se for Operador, exibe só as vendas do usuário logado
            if (Usuario.Perfil == "Supervisor"
                || Usuario.Perfil == "BackOffice"
                || Usuario.Perfil == "Administrador")
            {
                dataTable = CRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, -1, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, txtTelefone1_filtro.Text, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome_filtro.Text), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPFCNPJ_filtro.Text), sCampoDadosVenda, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtTextoDadosVenda.Text), iIDOperadorAuditoria);
            }
            else
            {
                dataTable = CRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, Usuario.IDUsuario, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, txtTelefone1_filtro.Text, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome_filtro.Text), PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPFCNPJ_filtro.Text), sCampoDadosVenda, PontoBr.Utilidades.String.RemoverCaracterInvalido(txtTextoDadosVenda.Text), iIDOperadorAuditoria);
            }

            dataTable.Columns.Remove("IDVenda");
            dataTable.Columns.Remove("IDCampanha");
            dataTable.Columns.Remove("Cód. Hist.");

            grdDados.DataSource = dataTable;
            grdDados.DataBind();

            lblRegistros.Text = "| " + grdDados.Rows.Count.ToString() + " registro(s) |";
        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(ex.Message, this.Page);
        }
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

        double dTelefone;
        if (Double.TryParse(txtTelefone1_filtro.Text, out dTelefone) == false && txtTelefone1_filtro.Text != "")
        {
            sMensagem = "O [Telefone] está incorreto.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (dropCampanha.SelectedValue == "-1")
        {
            sMensagem = "Selecione uma [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }

    private void CarregarOperadores()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
        usuarioCTL CUsuario = new usuarioCTL();

        CUsuario.PreencherDrop_Operadores(DropOperador, true, false);

        if (Usuario.Perfil == "Operador")
        {
            DropOperador.SelectedValue = Usuario.IDUsuario.ToString();
            dropCampanha.SelectedValue = Usuario.IDCampanha.ToString();
            DropOperador.Enabled = false;
            dropCampanha.Enabled = false;

            CarregarDadosVenda();
        }
    }

    protected void dropCampanha_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregarDadosVenda();
    }

    private void CarregarDadosVenda()
    {
        string sIDCampanha = dropCampanha.SelectedValue;

        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDropdownDadosVenda(dropDadosVenda, sIDCampanha, false, true);
    }

    private void CarregarCampanhas(int iIDUsuario)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDrop_Campanhas(dropCampanha, true, false, true, iIDUsuario, Usuario.Perfil);
    }

    private void CarregarStatusAuditoria()
    {
        auditoriaCTL CAuditoria = new auditoriaCTL();
        CAuditoria.PreencherDropdownStatusAuditoria(dropStatusAuditoria, true, true, false);
    }

    protected void btnGerar_Click(object sender, EventArgs e)
    {
        if (PodeGerar())
            GerarRelatorio();
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

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (grdDados.Rows.Count > 0)
        {
            Response.Clear();
            string sNomeArquivo = "Tabulare_Vendas.xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + sNomeArquivo + "");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter sWr = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hWr = new HtmlTextWriter(sWr);
            grdDados.RenderControl(hWr);
            Response.Write(sWr.ToString());
            Response.End();
        }
    }
}