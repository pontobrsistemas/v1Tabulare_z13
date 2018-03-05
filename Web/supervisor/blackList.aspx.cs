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

public partial class supervisor_blackList : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            ListarBlackList();
        }
    }

    private void ListarBlackList()
    {
        prospectCTL CProspect = new prospectCTL();
        CProspect.CarregarGridviewBlackList(dgDados);

        lblRegistros.Text = dgDados.Rows.Count.ToString() + " registro(s)";
    }

    protected void cmdSalvar_Click(object sender, EventArgs e)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
        try
        {
            if (PodeSalvar())
            {
                prospectCTL CProspect = new prospectCTL();
                CProspect.CadastrarBlackList(Convert.ToDouble(txtTelefone.Text), Usuario.IDUsuario);

                LimparFormulario();
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("[Telefone] incluído com sucesso!", this.Page);
            }
        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
        }
    }

    private void LimparFormulario()
    {
        txtTelefone.Text = "";
        ListarBlackList();
        txtTelefone.Focus();
    }

    private bool PodeSalvar()
    {
        string sMensagem;
        if (txtTelefone.Text.Trim().ToString() == "")
        {
            sMensagem = "Digite o [Telefone].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtTelefone.Text.Trim().Length != 10 && txtTelefone.Text.Trim().Length != 11)
        {
            sMensagem = "[Telefone] deve conter 10 ou 11 dígitos";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtTelefone.Text.Substring(0, 1) == "0")
        {
            sMensagem = "[Telefone] incorreto.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        prospectCTL CProspect = new prospectCTL();
        if (CProspect.VerificarTelefoneBlackList(Convert.ToDouble(txtTelefone.Text)))
        {
            sMensagem = "O [Telefone] já está cadastrado.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }        

    protected void dgDados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Abrir") // dúvida
        {
            string sTelefone = dgDados.DataKeys[int.Parse((string)e.CommandArgument)]["Telefone"].ToString();

            //prospectCTL CProspect = new prospectCTL();
            //prospect Prospect = new prospect();

            // CProspect.CarregarGridviewBlackList(dgDados);

            //hddId.Value = Status.IDStatus.ToString();
            txtTelefone.Text = sTelefone;
        }
    }
    protected void cmdExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            if (PodeExcluir())
            {
                prospectCTL CProspect = new prospectCTL();
                CProspect.ExcluirTelefoneBlackList(Convert.ToDouble(txtTelefone.Text));

                LimparFormulario();
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("[Telefone] excluído com sucesso!", this.Page);
            }
        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
        }
    }

    private bool PodeExcluir()
    {
        string sMensagem;
        if (txtTelefone.Text.Trim().ToString() == "")
        {
            sMensagem = "Digite ou clique no [Telefone].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtTelefone.Text.Trim().Length != 10 && txtTelefone.Text.Trim().Length != 11)
        {
            sMensagem = "[Telefone] deve conter 10 ou 11 dígitos";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtTelefone.Text.Substring(0, 1) == "0")
        {
            sMensagem = "[Telefone] incorreto.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        prospectCTL CProspect = new prospectCTL();
        if (!CProspect.VerificarTelefoneBlackList(Convert.ToDouble(txtTelefone.Text)))
        {
            sMensagem = "[Telefone] não está no Blacklist.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }
    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
        LimparFormulario();
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
}