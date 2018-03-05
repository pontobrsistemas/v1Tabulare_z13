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

public partial class supervisor_resubmitMailing : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            usuario Usuario = new usuario();
           
            CarregarCampanhas(Usuario.IDUsuario);
            CarregarOperadores();
            datDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
            datDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    private void CarregarCampanhas(int iIDUsuario)
    {
        usuario Usuario = new usuario();
        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDrop_Campanhas(dropCampanha, true, false, true, iIDUsuario, Usuario.Perfil);
    }

    private void CarregarOperadores()
    {
        usuarioCTL CUsuario = new usuarioCTL();
        CUsuario.PreencherDrop_Operadores(dropOperador, true, false);
    }
    protected void dropCampanha_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue.ToString());
        CarregarMailings(iIDCampanha);
        CarregarStatus(iIDCampanha);
    }

    private void CarregarMailings(int iIDCampanha)
    {
        mailingCTL CMailing = new mailingCTL();

        try
        {
            CMailing.CarregarDropdownMailings(dropMailing, iIDCampanha, false, true, false);
        }
        catch { }
    }

    private void CarregarStatus(int iIDCampanha)
    {
        statusCTL CStatus = new statusCTL();
        CStatus.PreencherCheckBoxListStatus(chkLStatus, iIDCampanha);

        foreach (ListItem listItem in chkLStatus.Items)
            listItem.Selected = true;
    }


    protected void cmdCalcular_Click(object sender, EventArgs e)
    {
        if (PodeResubmit())
        {
            prospect Prospect = new prospect();
            prospectCTL CProspect = new prospectCTL();

            string sDataInicial = "";
            string sDataFinal = "";
            int iIDOperador = -1;
            int iIDMailing = Convert.ToInt32(dropMailing.SelectedValue);
            string sIDStatus = "";
            string sBairro = "";
            string sCidade = "";
            string sCep = "";

            CProspect.LimparTabelaTemporariaResubmit();

            foreach (ListItem itemChecked in chkLStatus.Items)
            {
                if (chkFiltroAvancado.Checked)
                {
                    sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Text);
                    sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Text) + " 23:59:59";
                    iIDOperador = Convert.ToInt32(dropOperador.SelectedValue);
                    sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtBairro.Text);
                    sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCidade.Text);
                    sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCep.Text);
                }

                if (sIDStatus != "")
                    sIDStatus += ", ";

                sIDStatus += itemChecked.Value;
            }
            CProspect.InserirProspectTemporiamenteResubmit(sIDStatus, iIDMailing, sDataInicial, sDataFinal, iIDOperador, sBairro, sCidade, sCep);

            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Será dado resubmit em " + CProspect.RetornarQuantidadeResubmit().ToString() + " prospect(s).", this.Page);
        }
    }

    private bool PodeResubmit()
    {
        string sMensagem;
        if (dropCampanha.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione [Campanha].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        if (dropMailing.SelectedValue.ToString() == "-1")
        {
            sMensagem = "Selecione [Mailing].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }

        bool bAlgumSelecionado = false;
        foreach (ListItem itemChecked in chkLStatus.Items)
        {
            if (itemChecked.Selected == true)
            bAlgumSelecionado = true;
        }
        if (bAlgumSelecionado == false)
        {
            sMensagem = "Selecione algum [Status].";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            return false;
        }
        return true;
    }

    protected void cmdTodos_Click(object sender, EventArgs e)
    {        
        foreach (ListItem listItem in chkLStatus.Items)
            listItem.Selected = true;
    }

    protected void cmdNenhum_Click(object sender, EventArgs e)
    {
        foreach (ListItem listItem in chkLStatus.Items)
            listItem.Selected = false;
    }

    protected void cmdEfetuarResubmit_Click(object sender, EventArgs e)
    {
        if (PodeResubmit())
        {
            Resubmit();
        }
    }

    private void Resubmit()
    {
        try
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
            prospectCTL CProspect = new prospectCTL();
            string sMensagem;
            string sDataInicial = "";
            string sDataFinal = "";
            int iIDOperador = -1;
            int iIDMailing = Convert.ToInt32(dropMailing.SelectedValue);
            string sIDStatus = "";
            string sBairro = "";
            string sCidade = "";
            string sCep = "";

            foreach (ListItem itemChecked in chkLStatus.Items)
            {
                if (chkFiltroAvancado.Checked)
                {
                    sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataInicial.Text);
                    sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(datDataFinal.Text) + " 23:59:59";
                    iIDOperador = Convert.ToInt32(dropOperador.SelectedValue);
                    sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtBairro.Text);
                    sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCidade.Text);
                    sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCep.Text);
                }

                if (sIDStatus != "")
                    sIDStatus += ", ";

                sIDStatus += itemChecked.Value;
            }

            CProspect.InserirProspectTemporiamenteResubmit(sIDStatus.ToString(), iIDMailing, sDataInicial, sDataFinal, iIDOperador, sBairro, sCidade, sCep);

            int iNumeroProspectResubmit = CProspect.RetornarQuantidadeResubmit();
            string sMailing = dropMailing.Text;

            CProspect.ExecutarResubmit(Usuario.IDUsuario);


            sMensagem = "Mailing selecionado: " + sMailing + "\n\n";
            sMensagem += "Resubmit executado com sucesso em " + iNumeroProspectResubmit.ToString() + " prospect(s).";

            LiberarFormulario();


            PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(sMensagem, "Tabulare Software");
        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
        }
    }

    private void LiberarFormulario()
    {
        usuario Usuario = new usuario();

        CarregarCampanhas(Usuario.IDUsuario);
        dropMailing.DataSource = null;

        CarregarStatus(Convert.ToInt32(dropCampanha.SelectedValue));
    }
}