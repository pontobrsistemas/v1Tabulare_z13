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
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class relatorio_clienteFiltro : App_Code.BaseWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtTelefone1_filtro.Focus();
        this.Form.DefaultButton = this.btnGerar.UniqueID;

        if (!IsPostBack)
        {

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
            int iIDTipoAtendimento = -1;

            relatorioCTL CRelatorio = new relatorioCTL();
            DataTable dataTable = CRelatorio.RetornarProspects(txtTelefone1_filtro.Text.Trim(), txtNome_filtro.Text.Replace("'", "").Trim(), txtCPFCNPJ_filtro.Text.Replace("'", "").Trim(), iIDTipoAtendimento);

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

        if (txtTelefone1_filtro.Text.ToString() != "" && txtTelefone1_filtro.Text.Length != 10 && txtTelefone1_filtro.Text.Length != 11)
        {
            sMensagem = "O [Telefone] deve conter 10 ou 11 dígitos.";
            txtTelefone1_filtro.Focus();
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        double dTelefone;
        if (Double.TryParse(txtTelefone1_filtro.Text, out dTelefone) == false && txtTelefone1_filtro.Text != "")
        {
            sMensagem = "O [Telefone] está incorreto.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtNome_filtro.Text != "" && txtNome_filtro.Text.Length < 3)
        {
            sMensagem = "O [Nome] deve conter, no mínimo, 3 caracteres.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtCPFCNPJ_filtro.Text != "" && txtCPFCNPJ_filtro.Text.Length < 6)
        {
            sMensagem = "O [CPF / CNPJ] deve conter, no mínimo, 6 caracteres.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }

        return true;
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

            int iIDProspect = Convert.ToInt32(grdDados.DataKeys[e.Row.RowIndex].Values[0].ToString());

            string sChave = ConfigurationManager.AppSettings["Chave"].ToString();
            string sVetorInicializacao = ConfigurationManager.AppSettings["VetorInicializacao"].ToString();
            PontoBr.Seguranca.Criptografia Criptografia = new PontoBr.Seguranca.Criptografia();
            string sIDProspect = Criptografia.Criptografar(iIDProspect.ToString(), sChave, sVetorInicializacao);

            string sLink = "window.location.href='cliente.aspx?idprospect=" + sIDProspect + "';";
            e.Row.Attributes.Add("onclick", sLink);
        }
    }
}