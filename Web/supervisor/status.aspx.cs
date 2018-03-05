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

public partial class supervisor_status : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            usuario Usuario = new usuario();

            CarregarAcoes();
            CarregarCampanhas(Usuario.IDUsuario);
        }
    }

    private void CarregarCampanhas(int iIDUsuario)
    {
        usuario Usuario = new usuario();
        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDrop_Campanhas(dropCampanha, true, false, true, iIDUsuario, Usuario.Perfil);
    }

    private void CarregarAcoes()
    {
        acaoCTL CAcao = new acaoCTL();
        CAcao.PreencherDrop_Acao(dropAcao);
    }

    private void LimparFormulario()
    {
        txtStatus.Text = "";
        txtQtdeTentativas.Text = "";
        txtHoraRetorno.Text = "";
        radAtivo.SelectedValue = "1";

        dropAcao.SelectedValue = "-1";
        ListarStatus(Convert.ToInt32(dropCampanha.SelectedValue));
    }

    private void ListarStatus(int iIDCampanha)
    {
        statusCTL CStatus = new statusCTL();
        CStatus.CarregarGridviewStatusCadastro(dgStatus, iIDCampanha);
    }

    private bool PodeSalvar()
    {
        string sMensagem;
        if (txtQtdeTentativas.Text == "0")
        {
            sMensagem = "A [Quant. Tentativas] está incorreta. Selecione acima de 0 (Zero).";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (txtQtdeTentativas.Text == "")
        {
            sMensagem = "Preencha o campo [Quant. Tentativas].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        double dQtdeTentativas;
        if (Double.TryParse(txtQtdeTentativas.Text, out dQtdeTentativas) == false && txtQtdeTentativas.Text != "")
        {
            sMensagem = "A [Quant. Tentativas] está incorreta.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (!PontoBr.Conversoes.Data.ValidarDataBr("01/01/1900 " + txtHoraRetorno.Text))
        {
            sMensagem = "[Tempo de Retorno] inválido.";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }

    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
        LimparFormulario();
    }

    protected void cmdSalvar_Click(object sender, EventArgs e)
    {
        if (PodeSalvar())
        {
            status Status = new status();
            statusCTL CStatus = new statusCTL();

            Status.IDStatus = Convert.ToInt32(hddId.Value);
            Status.QtdeTentativas = Convert.ToInt32(txtQtdeTentativas.Text);
            Status.TempoRetorno = txtHoraRetorno.Text;
            Status.Ativo = Convert.ToInt32(radAtivo.SelectedValue);


            CStatus.AlteraStatus(Status);

            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Alterações salvas com sucesso.", this.Page);
            LimparFormulario();
        }
    }

    protected void dropCampanha_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        else
        {
            ListarStatus(Convert.ToInt32(dropCampanha.SelectedValue));
            LimparFormulario();

            lblRegistro.Text = "| " + dgStatus.Rows.Count.ToString() + " registro(s) |";
        }
    }

    protected void dgStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Abrir")
        {
            int iIDStatus = Convert.ToInt32(dgStatus.DataKeys[int.Parse((string)e.CommandArgument)]["Cód. Status"].ToString());

            statusCTL CStatus = new statusCTL();
            status Status = new status();

            Status = CStatus.RetornarStatus(iIDStatus);

            hddId.Value = Status.IDStatus.ToString();
            txtStatus.Text = Status.Status;
            dropAcao.SelectedValue = Status.IDAcao.ToString();
            txtQtdeTentativas.Text = Status.QtdeTentativas.ToString();
            txtHoraRetorno.Text = Status.TempoRetorno;
            radAtivo.SelectedValue = Status.Ativo.ToString();
        }
    }

    protected void dgStatus_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void cmdFechar_Click(object sender, EventArgs e)
    {

    }
}
