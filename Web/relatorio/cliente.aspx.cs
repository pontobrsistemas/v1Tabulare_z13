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

public partial class relatorio_cliente : App_Code.BaseWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AbrirProspect();
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

    private void AbrirProspect()
    {
        string sChave = ConfigurationManager.AppSettings["Chave"].ToString();
        string sVetorInicializacao = ConfigurationManager.AppSettings["VetorInicializacao"].ToString();
        PontoBr.Seguranca.Criptografia Criptografia = new PontoBr.Seguranca.Criptografia();
        string sIDProspect = Criptografia.Descriptografar(Request.QueryString["idprospect"].ToString(), sChave, sVetorInicializacao);

        prospect Prospect = new prospect();
        prospectCTL CProspect = new prospectCTL();

        Prospect = CProspect.RetornarProspect(Convert.ToInt32(sIDProspect));

        txtTelefone1.Text = Prospect.Telefone1.ToString();
        txtTelefone2.Text = Prospect.Telefone2.ToString();
        txtTelefone3.Text = Prospect.Telefone3.ToString();
        txtNome.Text = Prospect.Nome.ToString();
        txtLogradouro.Text = Prospect.Logradouro.ToString();
        txtBairro.Text = Prospect.Bairro.ToString();
        txtCidade.Text = Prospect.Cidade.ToString();
        txtEstado.Text = Prospect.Estado.ToString();
        txtEmail.Text = Prospect.Email.ToString();
        txtCep.Text = Prospect.Cep.ToString();//rr
        txtNumero.Text = Prospect.Numero.ToString();
        txtCPF_CNPJ.Text = Prospect.CPF_CNPJ.ToString();

        ListarHistoricoContato(Convert.ToDouble(txtTelefone1.Text));
    }

    private void ListarHistoricoContato(double dTelefone1)
    {
        prospectCTL CProspect = new prospectCTL();
        grdDados.DataSource = CProspect.RetornarHistoricoContato(dTelefone1, -1, 0);
        grdDados.DataBind();

        lblRegistros.Text = "| " + grdDados.Rows.Count.ToString() + " registro(s) |";
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