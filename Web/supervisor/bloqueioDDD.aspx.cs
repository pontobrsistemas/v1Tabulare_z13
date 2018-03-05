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

public partial class supervisor_bloqueioDDD : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

            CarregarCampanhas(Usuario.IDUsuario);
            CarregarCampanhasDDD();
        }
    }

    private void CarregarCampanhas(int iIDUsuario)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDrop_Campanhas(dropCampanha, true, false, true, Usuario.IDUsuario, Usuario.Perfil);
    }

    private void CarregarCampanhasDDD()
    {
        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.CarregarGridviewCampanhas(dgDDD);

        lblRegistros.Text = "| " + dgDDD.Rows.Count.ToString() + " registro(s) |";
    }

    protected void dropCampanha_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue.ToString());
        if (iIDCampanha != -1)
            SelecionarDDDBloqueado(iIDCampanha);
        else
            SelecionarDDDBloqueado(-1);
    }

    private void SelecionarDDDBloqueado(int iIDCampanha)
    {
        prospectCTL CProspect = new prospectCTL();
        
        //Desmarca todos os DDD
        for (int i = 0; i < this.chkDDD.Items.Count; ++i)
            this.chkDDD.Items[i].Selected = false;

        DataTable dataTable = CProspect.RetornarBloqueiosDDD(iIDCampanha);

        for (int i = 0; i < this.chkDDD.Items.Count; ++i)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["DDD"].ToString() == chkDDD.Items[i].ToString())
                    chkDDD.Items[i].Selected = true;
            }
        }
    }

    protected void dgDDD_RowDataBound(object sender, GridViewRowEventArgs e)
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

            int iIDCampanha = Convert.ToInt32(dgDDD.DataKeys[e.Row.RowIndex].Values[0].ToString());

            campanhaCTL CCampanha = new campanhaCTL();
            DataTable dataTable = new DataTable();

            dataTable = CCampanha.RetornarBloqueioDDD(iIDCampanha);
            string sDDD = "";

            foreach (DataRow dataRow in dataTable.Rows)
            {
                sDDD += sDDD != "" ? "; " + dataRow["DDD"] : dataRow["DDD"];
            }
            e.Row.Cells[1].Text = sDDD;
        }
    }
    protected void cmdSalvar_Click(object sender, EventArgs e)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        if (PodeSalvar())
        {
            int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue);

            prospectCTL CProspect = new prospectCTL();

            //Exclui todos os DDDs para cadastrar novamente
            CProspect.ExcluirBloqueioDDD(iIDCampanha);
            foreach (ListItem itemChecked in chkDDD.Items)
            {
                if (itemChecked.Selected == true)
                    CProspect.CadastrarBloqueioDDD(Convert.ToInt32(itemChecked.ToString()), Usuario.IDUsuario, iIDCampanha);
            }

            LimparCampos();
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Registros salvos com sucesso!", this.Page);
        }
    }

    private bool PodeSalvar()
    {
        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Selecione [Campanha].", this.Page);
            return false;
        }
        return true;
    }
    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
        LimparCampos();
    }

    private void LimparCampos()
    {
        dropCampanha.SelectedValue = "-1";

        //Desmarca todos os DDD
        for (int i = 0; i < this.chkDDD.Items.Count; ++i)
            this.chkDDD.Items[i].Selected = false;

        CarregarCampanhasDDD();
    }
}