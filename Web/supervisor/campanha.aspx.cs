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

public partial class supervisor_campanha : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            ListarCampanhas();
        }
    }

    private void ListarCampanhas()
    {
        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.CarregarGridviewCampanhas(dgCampanha);

        lblRegistros.Text = dgCampanha.Rows.Count.ToString() + " registro(s)";
    }

    protected void dgCampanha_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void dgCampanha_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Abrir")
        {
            int iIDCampanha = Convert.ToInt32(dgCampanha.DataKeys[int.Parse((string)e.CommandArgument)]["Cód. Campanha"].ToString());

            campanha Campanha = new campanha();
            campanhaCTL CCampanha = new campanhaCTL();

            Campanha = CCampanha.CarregarGridviewCampanha(dgCampanha, iIDCampanha);

            hddId.Value = Campanha.iIDCampanha.ToString();
            txtCampanha.Text = Campanha.sCampanha.ToString();
            txtOperadora.Text = Campanha.sOperadora == null ? "0" :  Campanha.sOperadora;
            radAtivo.SelectedValue = Campanha.iAtivo.ToString();
        }
    }
    protected void cmdSalvar_Click(object sender, EventArgs e)
    {
        if (PodeSalvar())
        {
            if (hddId.Value != "")
            {
                campanha Campanha = new campanha();
                Campanha.iIDCampanha = Convert.ToInt32(hddId.Value);
                Campanha.sCampanha = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCampanha.Text.ToString());
                Campanha.sOperadora = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtOperadora.Text.ToString());
                Campanha.iAtivo = Convert.ToInt32(radAtivo.SelectedValue);
                Campanha.PermiteEditarDadosProspect = chkEditarDadosProspect.Checked == true ? 1 : 0;
                Campanha.iIDTipoDiscador = 1;

                campanhaCTL CCampanha = new campanhaCTL();
                CCampanha.AtualizaCampanha(Campanha);

                LimparFormulario();
               
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Alterações salvas com sucesso.", this.Page);
            }
        }
    }

    private void LimparFormulario()
    {
        hddId.Value = "";
        txtCampanha.Text = "";
        txtOperadora.Text = "";
        radAtivo.SelectedValue = "1";
        ListarCampanhas();
    }

    private bool PodeSalvar()
    {
        string sMensagem;
        if (txtCampanha.Text == "")
        {
            sMensagem = "Preencha ou selecione alguma [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }

        if (radAtivo.SelectedValue == "")
        {
            sMensagem = "Selecione Sim ou Não para Ativo.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }
    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
        LimparFormulario();
    }
}