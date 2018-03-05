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

public partial class operador_venda : App_Code.BaseWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AbrirVenda();
        }
        AdpaterMenu();
    }

    protected override void OnPreInit(EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Operador")) Response.Redirect("../login/logout.aspx?e=logout");
    }

    private void AdpaterMenu()
    {
        if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
        {
            Request.Browser.Adapters.Clear();
        }
    }

    private void LiberarFormulario()
    {
        configuracao Configuracao = (configuracao)HttpContext.Current.Session["Configuracao"];

        //radTel1.Checked = true;

        if (Convert.ToBoolean(ViewState["Indicacao"]) == true)
            txtTelefone1.ReadOnly = false;

        txtTelefone2.ReadOnly = false;
        txtTelefone3.ReadOnly = false;
        txtNome.ReadOnly = false;
        txtLogradouro.ReadOnly = false;
        txtNumero.ReadOnly = false;
        txtComplemento.ReadOnly = false;
        txtBairro.ReadOnly = false;
        txtCidade.ReadOnly = false;
        txtEstado.ReadOnly = false;
        txtEmail.ReadOnly = false;
        txtCep.ReadOnly = false;
        txtCPF_CNPJ.ReadOnly = false;


        //Liberar  campos extras Prospect
        foreach (Control controlTextBox in PainelDadosProspect.Controls)
        {
            if (controlTextBox.ID != null)
            {
                if (controlTextBox.ID.IndexOf("txtCampo") > -1)
                {
                    TextBox textBox = (TextBox)controlTextBox;
                    textBox.ReadOnly = false;
                }
                if (controlTextBox.ID.IndexOf("dropCampo") > -1)
                {
                    DropDownList dropBox = (DropDownList)controlTextBox;
                    dropBox.Enabled = true;
                }
            }
        }

        //Liberar campos Venda
        foreach (Control controlTextBox in PainelDadosVenda.Controls)
        {
            if (controlTextBox.ID != null)
            {
                if (controlTextBox.ID.IndexOf("txtVenda") > -1)
                {
                    TextBox textBox = (TextBox)controlTextBox;
                    textBox.ReadOnly = true;
                }
                if (controlTextBox.ID.IndexOf("dropVenda") > -1)
                {
                    DropDownList dropBox = (DropDownList)controlTextBox;
                    dropBox.Enabled = true;
                }
            }
        }

        txtNome.Focus();
    }


    private void AbrirVenda()
    {
        string sChave = ConfigurationManager.AppSettings["Chave"].ToString();
        string sVetorInicializacao = ConfigurationManager.AppSettings["VetorInicializacao"].ToString();
        PontoBr.Seguranca.Criptografia Criptografia = new PontoBr.Seguranca.Criptografia();
        string sIDHistorico = Criptografia.Descriptografar(Request.QueryString["idhistorico"].ToString(), sChave, sVetorInicializacao);

        relatorioCTL CRelatorio = new relatorioCTL();
        DataTable dataTable = CRelatorio.RetornarDadosVenda(Convert.ToInt32(sIDHistorico));

        configuracaoCTL CConfiguracao = new configuracaoCTL();
        configuracao Configuracao = (configuracao)HttpContext.Current.Session["Configuracao"];

        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        if (dataTable.Rows.Count > 0)
        {
            //Colocar venda em uso pelo backoffice            
            if (Usuario.Perfil != "Operador")
            {
                prospectCTL CProspect = new prospectCTL();
                CProspect.PegarVendaParaAuditarBackoffice(Convert.ToInt32(dataTable.Rows[0]["IDHistorico"].ToString()), Usuario.IDUsuario);
            }

            hddIDHistorico.Value = dataTable.Rows[0]["IDHistorico"].ToString();
            hddIDProspect.Value = dataTable.Rows[0]["IDProspect"].ToString();
            hddIDCampanha.Value = dataTable.Rows[0]["IDCampanha"].ToString();

            CarregarCamposCampanha(Convert.ToInt32(hddIDCampanha.Value));

            txtNome.Text = dataTable.Rows[0]["Nome"].ToString();
            txtCPF_CNPJ.Text = dataTable.Rows[0]["CPF_CNPJ"].ToString();
            txtTelefone1.Text = dataTable.Rows[0]["Telefone1"].ToString();
            txtTelefone2.Text = dataTable.Rows[0]["Telefone2"].ToString();
            txtTelefone3.Text = dataTable.Rows[0]["Telefone3"].ToString();
            txtLogradouro.Text = dataTable.Rows[0]["Logradouro"].ToString();
            txtNumero.Text = dataTable.Rows[0]["Numero"].ToString();
            txtComplemento.Text = dataTable.Rows[0]["Complemento"].ToString();
            txtBairro.Text = dataTable.Rows[0]["Bairro"].ToString();
            txtCidade.Text = dataTable.Rows[0]["Cidade"].ToString();
            txtEstado.Text = dataTable.Rows[0]["Estado"].ToString();
            txtEmail.Text = dataTable.Rows[0]["Email"].ToString();
            txtCep.Text = dataTable.Rows[0]["Cep"].ToString();//rr

            lblMailing_valor.Text = dataTable.Rows[0]["Mailing"].ToString().ToUpper();
            lblCampanha_valor.Text = dataTable.Rows[0]["Campanha"].ToString().ToUpper();
            lblOperador_valor.Text = dataTable.Rows[0]["Usuario"].ToString().ToUpper();
            lblDataContato_valor.Text = dataTable.Rows[0]["DataCadastro"].ToString().ToUpper();
            txtObservacao.Text = dataTable.Rows[0]["Observacao"].ToString();

            lblBackoffice_valor.Text = dataTable.Rows[0]["Backoffice"].ToString().ToUpper() == "" ? "-" : dataTable.Rows[0]["Backoffice"].ToString().ToUpper();
            lblDataAuditoria_valor.Text = dataTable.Rows[0]["DataAuditoria"].ToString().ToUpper() == "" ? "-" : dataTable.Rows[0]["DataAuditoria"].ToString().ToUpper();
            lblStatusAuditoria_valor.Text = dataTable.Rows[0]["Status Auditoria"].ToString();

            //Retornar Campos extras Prospect
            ArrayList arrayList = new ArrayList();
            arrayList.Clear();
            arrayList = CConfiguracao.RetornarCamposCampanha(Convert.ToInt32(hddIDCampanha.Value));

            for (int iItem = 0; iItem < arrayList.Count; iItem++)
            {
                Configuracao = (configuracao)arrayList[iItem];

                String sCamposExtras = Configuracao.IDCampo;
                if (Configuracao.IDCampo.IndexOf("c") > -1)
                {
                    if (sCamposExtras == "c01") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo01.Text = dataTable.Rows[0]["Campo01"].ToString(); else dropCampo01.SelectedValue = dataTable.Rows[0]["Campo01"].ToString(); }
                    if (sCamposExtras == "c02") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo02.Text = dataTable.Rows[0]["Campo02"].ToString(); else dropCampo02.SelectedValue = dataTable.Rows[0]["Campo02"].ToString(); }
                    if (sCamposExtras == "c03") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo03.Text = dataTable.Rows[0]["Campo03"].ToString(); else dropCampo03.SelectedValue = dataTable.Rows[0]["Campo03"].ToString(); }
                    if (sCamposExtras == "c04") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo04.Text = dataTable.Rows[0]["Campo04"].ToString(); else dropCampo04.SelectedValue = dataTable.Rows[0]["Campo04"].ToString(); }
                    if (sCamposExtras == "c05") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo05.Text = dataTable.Rows[0]["Campo05"].ToString(); else dropCampo05.SelectedValue = dataTable.Rows[0]["Campo05"].ToString(); }
                    if (sCamposExtras == "c06") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo06.Text = dataTable.Rows[0]["Campo06"].ToString(); else dropCampo06.SelectedValue = dataTable.Rows[0]["Campo06"].ToString(); }
                    if (sCamposExtras == "c07") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo07.Text = dataTable.Rows[0]["Campo07"].ToString(); else dropCampo07.SelectedValue = dataTable.Rows[0]["Campo07"].ToString(); }
                    if (sCamposExtras == "c08") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo08.Text = dataTable.Rows[0]["Campo08"].ToString(); else dropCampo08.SelectedValue = dataTable.Rows[0]["Campo08"].ToString(); }
                    if (sCamposExtras == "c09") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo09.Text = dataTable.Rows[0]["Campo09"].ToString(); else dropCampo09.SelectedValue = dataTable.Rows[0]["Campo09"].ToString(); }
                    if (sCamposExtras == "c10") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo10.Text = dataTable.Rows[0]["Campo10"].ToString(); else dropCampo10.SelectedValue = dataTable.Rows[0]["Campo10"].ToString(); }
                }
                else if (Configuracao.IDCampo.IndexOf("v") > -1)
                {
                    if (sCamposExtras == "v01") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda01.Text = dataTable.Rows[0]["Venda01"].ToString(); else dropVenda01.SelectedValue = dataTable.Rows[0]["Venda01"].ToString(); }
                    if (sCamposExtras == "v02") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda02.Text = dataTable.Rows[0]["Venda02"].ToString(); else dropVenda02.SelectedValue = dataTable.Rows[0]["Venda02"].ToString(); }
                    if (sCamposExtras == "v03") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda03.Text = dataTable.Rows[0]["Venda03"].ToString(); else dropVenda03.SelectedValue = dataTable.Rows[0]["Venda03"].ToString(); }
                    if (sCamposExtras == "v04") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda04.Text = dataTable.Rows[0]["Venda04"].ToString(); else dropVenda04.SelectedValue = dataTable.Rows[0]["Venda04"].ToString(); }
                    if (sCamposExtras == "v05") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda05.Text = dataTable.Rows[0]["Venda05"].ToString(); else dropVenda05.SelectedValue = dataTable.Rows[0]["Venda05"].ToString(); }
                    if (sCamposExtras == "v06") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda06.Text = dataTable.Rows[0]["Venda06"].ToString(); else dropVenda06.SelectedValue = dataTable.Rows[0]["Venda06"].ToString(); }
                    if (sCamposExtras == "v07") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda07.Text = dataTable.Rows[0]["Venda07"].ToString(); else dropVenda07.SelectedValue = dataTable.Rows[0]["Venda07"].ToString(); }
                    if (sCamposExtras == "v08") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda08.Text = dataTable.Rows[0]["Venda08"].ToString(); else dropVenda08.SelectedValue = dataTable.Rows[0]["Venda08"].ToString(); }
                    if (sCamposExtras == "v09") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda09.Text = dataTable.Rows[0]["Venda09"].ToString(); else dropVenda09.SelectedValue = dataTable.Rows[0]["Venda09"].ToString(); }
                    if (sCamposExtras == "v10") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda10.Text = dataTable.Rows[0]["Venda10"].ToString(); else dropVenda10.SelectedValue = dataTable.Rows[0]["Venda10"].ToString(); }
                    if (sCamposExtras == "v11") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda11.Text = dataTable.Rows[0]["Venda11"].ToString(); else dropVenda11.SelectedValue = dataTable.Rows[0]["Venda11"].ToString(); }
                    if (sCamposExtras == "v12") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda12.Text = dataTable.Rows[0]["Venda12"].ToString(); else dropVenda12.SelectedValue = dataTable.Rows[0]["Venda12"].ToString(); }
                    if (sCamposExtras == "v13") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda13.Text = dataTable.Rows[0]["Venda13"].ToString(); else dropVenda13.SelectedValue = dataTable.Rows[0]["Venda13"].ToString(); }
                    if (sCamposExtras == "v14") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda14.Text = dataTable.Rows[0]["Venda14"].ToString(); else dropVenda14.SelectedValue = dataTable.Rows[0]["Venda14"].ToString(); }
                    if (sCamposExtras == "v15") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda15.Text = dataTable.Rows[0]["Venda15"].ToString(); else dropVenda15.SelectedValue = dataTable.Rows[0]["Venda15"].ToString(); }
                    if (sCamposExtras == "v16") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda16.Text = dataTable.Rows[0]["Venda16"].ToString(); else dropVenda16.SelectedValue = dataTable.Rows[0]["Venda16"].ToString(); }
                    if (sCamposExtras == "v17") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda17.Text = dataTable.Rows[0]["Venda17"].ToString(); else dropVenda17.SelectedValue = dataTable.Rows[0]["Venda17"].ToString(); }
                    if (sCamposExtras == "v18") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda18.Text = dataTable.Rows[0]["Venda18"].ToString(); else dropVenda18.SelectedValue = dataTable.Rows[0]["Venda18"].ToString(); }
                    if (sCamposExtras == "v19") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda19.Text = dataTable.Rows[0]["Venda19"].ToString(); else dropVenda19.SelectedValue = dataTable.Rows[0]["Venda19"].ToString(); }
                    if (sCamposExtras == "v20") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda20.Text = dataTable.Rows[0]["Venda20"].ToString(); else dropVenda20.SelectedValue = dataTable.Rows[0]["Venda20"].ToString(); }
                    if (sCamposExtras == "v21") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda21.Text = dataTable.Rows[0]["Venda21"].ToString(); else dropVenda21.SelectedValue = dataTable.Rows[0]["Venda21"].ToString(); }
                    if (sCamposExtras == "v22") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda22.Text = dataTable.Rows[0]["Venda22"].ToString(); else dropVenda22.SelectedValue = dataTable.Rows[0]["Venda22"].ToString(); }
                    if (sCamposExtras == "v23") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda23.Text = dataTable.Rows[0]["Venda23"].ToString(); else dropVenda23.SelectedValue = dataTable.Rows[0]["Venda23"].ToString(); }
                    if (sCamposExtras == "v24") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda24.Text = dataTable.Rows[0]["Venda24"].ToString(); else dropVenda24.SelectedValue = dataTable.Rows[0]["Venda24"].ToString(); }
                    if (sCamposExtras == "v25") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda25.Text = dataTable.Rows[0]["Venda25"].ToString(); else dropVenda25.SelectedValue = dataTable.Rows[0]["Venda25"].ToString(); }
                    if (sCamposExtras == "v26") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda26.Text = dataTable.Rows[0]["Venda26"].ToString(); else dropVenda26.SelectedValue = dataTable.Rows[0]["Venda26"].ToString(); }
                    if (sCamposExtras == "v27") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda27.Text = dataTable.Rows[0]["Venda27"].ToString(); else dropVenda27.SelectedValue = dataTable.Rows[0]["Venda27"].ToString(); }
                    if (sCamposExtras == "v28") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda28.Text = dataTable.Rows[0]["Venda28"].ToString(); else dropVenda28.SelectedValue = dataTable.Rows[0]["Venda28"].ToString(); }
                    if (sCamposExtras == "v29") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda29.Text = dataTable.Rows[0]["Venda29"].ToString(); else dropVenda29.SelectedValue = dataTable.Rows[0]["Venda29"].ToString(); }
                    if (sCamposExtras == "v30") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda30.Text = dataTable.Rows[0]["Venda30"].ToString(); else dropVenda30.SelectedValue = dataTable.Rows[0]["Venda30"].ToString(); }
                    if (sCamposExtras == "v31") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda31.Text = dataTable.Rows[0]["Venda31"].ToString(); else dropVenda31.SelectedValue = dataTable.Rows[0]["Venda31"].ToString(); }
                    if (sCamposExtras == "v32") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda32.Text = dataTable.Rows[0]["Venda32"].ToString(); else dropVenda32.SelectedValue = dataTable.Rows[0]["Venda32"].ToString(); }
                    if (sCamposExtras == "v33") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda33.Text = dataTable.Rows[0]["Venda33"].ToString(); else dropVenda33.SelectedValue = dataTable.Rows[0]["Venda33"].ToString(); }
                    if (sCamposExtras == "v34") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda34.Text = dataTable.Rows[0]["Venda34"].ToString(); else dropVenda34.SelectedValue = dataTable.Rows[0]["Venda34"].ToString(); }
                    if (sCamposExtras == "v35") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda35.Text = dataTable.Rows[0]["Venda35"].ToString(); else dropVenda35.SelectedValue = dataTable.Rows[0]["Venda35"].ToString(); }
                    if (sCamposExtras == "v36") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda36.Text = dataTable.Rows[0]["Venda36"].ToString(); else dropVenda36.SelectedValue = dataTable.Rows[0]["Venda36"].ToString(); }
                    if (sCamposExtras == "v37") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda37.Text = dataTable.Rows[0]["Venda37"].ToString(); else dropVenda37.SelectedValue = dataTable.Rows[0]["Venda37"].ToString(); }
                    if (sCamposExtras == "v38") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda38.Text = dataTable.Rows[0]["Venda38"].ToString(); else dropVenda38.SelectedValue = dataTable.Rows[0]["Venda38"].ToString(); }
                    if (sCamposExtras == "v39") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda39.Text = dataTable.Rows[0]["Venda39"].ToString(); else dropVenda39.SelectedValue = dataTable.Rows[0]["Venda39"].ToString(); }
                    if (sCamposExtras == "v40") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda40.Text = dataTable.Rows[0]["Venda40"].ToString(); else dropVenda40.SelectedValue = dataTable.Rows[0]["Venda40"].ToString(); }
                    if (sCamposExtras == "v41") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda41.Text = dataTable.Rows[0]["Venda41"].ToString(); else dropVenda41.SelectedValue = dataTable.Rows[0]["Venda41"].ToString(); }
                    if (sCamposExtras == "v42") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda42.Text = dataTable.Rows[0]["Venda42"].ToString(); else dropVenda42.SelectedValue = dataTable.Rows[0]["Venda42"].ToString(); }
                    if (sCamposExtras == "v43") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda43.Text = dataTable.Rows[0]["Venda43"].ToString(); else dropVenda43.SelectedValue = dataTable.Rows[0]["Venda43"].ToString(); }
                    if (sCamposExtras == "v44") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda44.Text = dataTable.Rows[0]["Venda44"].ToString(); else dropVenda44.SelectedValue = dataTable.Rows[0]["Venda44"].ToString(); }
                    if (sCamposExtras == "v45") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda45.Text = dataTable.Rows[0]["Venda45"].ToString(); else dropVenda45.SelectedValue = dataTable.Rows[0]["Venda45"].ToString(); }
                    if (sCamposExtras == "v46") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda46.Text = dataTable.Rows[0]["Venda46"].ToString(); else dropVenda46.SelectedValue = dataTable.Rows[0]["Venda46"].ToString(); }
                    if (sCamposExtras == "v47") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda47.Text = dataTable.Rows[0]["Venda47"].ToString(); else dropVenda47.SelectedValue = dataTable.Rows[0]["Venda47"].ToString(); }
                    if (sCamposExtras == "v48") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda48.Text = dataTable.Rows[0]["Venda48"].ToString(); else dropVenda48.SelectedValue = dataTable.Rows[0]["Venda48"].ToString(); }
                    if (sCamposExtras == "v49") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda49.Text = dataTable.Rows[0]["Venda49"].ToString(); else dropVenda49.SelectedValue = dataTable.Rows[0]["Venda49"].ToString(); }
                    if (sCamposExtras == "v50") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda50.Text = dataTable.Rows[0]["Venda50"].ToString(); else dropVenda50.SelectedValue = dataTable.Rows[0]["Venda50"].ToString(); }
                    if (sCamposExtras == "v51") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda51.Text = dataTable.Rows[0]["Venda51"].ToString(); else dropVenda51.SelectedValue = dataTable.Rows[0]["Venda51"].ToString(); }
                    if (sCamposExtras == "v52") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda52.Text = dataTable.Rows[0]["Venda52"].ToString(); else dropVenda52.SelectedValue = dataTable.Rows[0]["Venda52"].ToString(); }
                    if (sCamposExtras == "v53") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda53.Text = dataTable.Rows[0]["Venda53"].ToString(); else dropVenda53.SelectedValue = dataTable.Rows[0]["Venda53"].ToString(); }
                    if (sCamposExtras == "v54") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda54.Text = dataTable.Rows[0]["Venda54"].ToString(); else dropVenda54.SelectedValue = dataTable.Rows[0]["Venda54"].ToString(); }
                    if (sCamposExtras == "v55") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda55.Text = dataTable.Rows[0]["Venda55"].ToString(); else dropVenda55.SelectedValue = dataTable.Rows[0]["Venda55"].ToString(); }
                    if (sCamposExtras == "v56") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda56.Text = dataTable.Rows[0]["Venda56"].ToString(); else dropVenda56.SelectedValue = dataTable.Rows[0]["Venda56"].ToString(); }
                    if (sCamposExtras == "v57") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda57.Text = dataTable.Rows[0]["Venda57"].ToString(); else dropVenda57.SelectedValue = dataTable.Rows[0]["Venda57"].ToString(); }
                    if (sCamposExtras == "v58") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda58.Text = dataTable.Rows[0]["Venda58"].ToString(); else dropVenda58.SelectedValue = dataTable.Rows[0]["Venda58"].ToString(); }
                    if (sCamposExtras == "v59") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda59.Text = dataTable.Rows[0]["Venda59"].ToString(); else dropVenda59.SelectedValue = dataTable.Rows[0]["Venda59"].ToString(); }
                    if (sCamposExtras == "v60") { if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda60.Text = dataTable.Rows[0]["Venda60"].ToString(); else dropVenda60.SelectedValue = dataTable.Rows[0]["Venda60"].ToString(); }
                }
            }
        }

        //Bloqueia campos
        txtTelefone1.ReadOnly = true;
        txtTelefone2.ReadOnly = true;
        txtTelefone3.ReadOnly = true;
        txtNome.ReadOnly = true;
        txtLogradouro.ReadOnly = true;
        txtNumero.ReadOnly = true;
        txtComplemento.ReadOnly = true;
        txtBairro.ReadOnly = true;
        txtCidade.ReadOnly = true;
        txtEstado.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtCep.ReadOnly = true;
        txtCPF_CNPJ.ReadOnly = true;
        txtObservacao.ReadOnly = true;

        foreach (Control controlTextBox in PainelDadosProspect.Controls)
        {
            if (controlTextBox.ID != null)
            {
                if (controlTextBox.ID.IndexOf("txtCampo") > -1)
                {
                    TextBox textBox = (TextBox)controlTextBox;
                    textBox.ReadOnly = true;
                }
                if (controlTextBox.ID.IndexOf("dropCampo") > -1)
                {
                    DropDownList dropBox = (DropDownList)controlTextBox;
                    dropBox.Enabled = false;
                }
            }
        }

        foreach (Control controlTextBox in PainelDadosVenda.Controls)
        {
            if (controlTextBox.ID != null)
            {
                if (controlTextBox.ID.IndexOf("txtVenda") > -1)
                {
                    TextBox textBox = (TextBox)controlTextBox;
                    textBox.ReadOnly = true;
                }
                if (controlTextBox.ID.IndexOf("dropVenda") > -1)
                {
                    DropDownList dropBox = (DropDownList)controlTextBox;
                    dropBox.Enabled = false;
                }
            }
        }

        hddIDVenda.Value = dataTable.Rows[0]["IDVenda"].ToString();
        int iIDVenda = Convert.ToInt32(hddIDVenda.Value);
        RetornarObservacoesVenda(iIDVenda);
        
      }

    #region Carrega textos dos labels, configurações e posicionamento na tela
    private void CarregarCamposCampanha(int iIDCampanha)
    {
        configuracaoCTL CConfiguracao = new configuracaoCTL();
        prospect prospect = new prospect();
        ArrayList arrayList = new ArrayList();
        arrayList.Clear();

        arrayList = CConfiguracao.RetornarCamposCampanha(iIDCampanha);

        //Tabela
        HtmlTable tableDadosVenda = new HtmlTable();
        HtmlTable tableProspect = new HtmlTable();

        // Propriedades de formatação.
        tableDadosVenda.Border = 1;
        tableProspect.Border = 1;
        tableProspect.BorderColor = "black";
        tableDadosVenda.BorderColor = "black";

        // Início do conteúdo da tabela.
        HtmlTableRow rowProspect = new HtmlTableRow();
        HtmlTableRow rowDadosVenda = new HtmlTableRow();

        for (int iItem = 0; iItem < arrayList.Count; iItem++)
        {
            configuracao Configuracao = (configuracao)arrayList[iItem];
            int X, Y;
            string[] sSubstring;
            string[] sLista = null;
            string sLabel;

            System.Web.UI.WebControls.TextBox textBox = new System.Web.UI.WebControls.TextBox();
            System.Web.UI.WebControls.DropDownList comboBox = new System.Web.UI.WebControls.DropDownList();

            textBox.ID = Configuracao.TextBox;
            comboBox.ID = Configuracao.TextBox.Replace("txt", "combo");
            textBox.ToolTip = Configuracao.Texto;
            comboBox.ToolTip = Configuracao.Texto;
            textBox.Enabled = true;
            textBox.Visible = true;

            sSubstring = Configuracao.TamanhoTextBox.Split(';');
            X = Convert.ToInt32(sSubstring[0].Trim());
            Y = Convert.ToInt32(sSubstring[1].Trim());

            sLabel = Configuracao.Obrigatorio == true ? Configuracao.Texto.Trim() + "*:" : Configuracao.Texto.Trim() + ":";

            if (Configuracao.IDCampo.IndexOf("c") > -1)
            {
                String sCamposExtras = Configuracao.IDCampo;
                //Dropdownlist
                if (Configuracao.Lista != "")
                {
                    Configuracao.Lista = "-;" + Configuracao.Lista;
                    sLista = Configuracao.Lista.Split(';');

                    Array.Sort(sLista);
                }

                if (sCamposExtras == "c01") { lblCampo01.Visible = true; lblCampo01.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo01.Visible = true; else { dropCampo01.Visible = true; dropCampo01.DataSource = sLista; dropCampo01.DataBind(); } }
                if (sCamposExtras == "c02") { lblCampo02.Visible = true; lblCampo02.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo02.Visible = true; else { dropCampo02.Visible = true; dropCampo02.DataSource = sLista; dropCampo02.DataBind(); } }
                if (sCamposExtras == "c03") { lblCampo03.Visible = true; lblCampo03.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo03.Visible = true; else { dropCampo03.Visible = true; dropCampo03.DataSource = sLista; dropCampo03.DataBind(); } }
                if (sCamposExtras == "c04") { lblCampo04.Visible = true; lblCampo04.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo04.Visible = true; else { dropCampo04.Visible = true; dropCampo04.DataSource = sLista; dropCampo04.DataBind(); } }
                if (sCamposExtras == "c05") { lblCampo05.Visible = true; lblCampo05.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo05.Visible = true; else { dropCampo05.Visible = true; dropCampo05.DataSource = sLista; dropCampo05.DataBind(); } }
                if (sCamposExtras == "c06") { lblCampo06.Visible = true; lblCampo06.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo06.Visible = true; else { dropCampo06.Visible = true; dropCampo06.DataSource = sLista; dropCampo06.DataBind(); } }
                if (sCamposExtras == "c07") { lblCampo07.Visible = true; lblCampo07.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo07.Visible = true; else { dropCampo07.Visible = true; dropCampo07.DataSource = sLista; dropCampo07.DataBind(); } }
                if (sCamposExtras == "c08") { lblCampo08.Visible = true; lblCampo08.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo08.Visible = true; else { dropCampo08.Visible = true; dropCampo08.DataSource = sLista; dropCampo08.DataBind(); } }
                if (sCamposExtras == "c09") { lblCampo09.Visible = true; lblCampo09.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo09.Visible = true; else { dropCampo09.Visible = true; dropCampo09.DataSource = sLista; dropCampo09.DataBind(); } }
                if (sCamposExtras == "c10") { lblCampo10.Visible = true; lblCampo10.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtCampo10.Visible = true; else { dropCampo10.Visible = true; dropCampo10.DataSource = sLista; dropCampo10.DataBind(); } }
            }
            else if (Configuracao.IDCampo.IndexOf("v") > -1)
            {
                String sCamposExtras = Configuracao.IDCampo;
                //Dropdownlist
                if (Configuracao.Lista != "")
                {
                    Configuracao.Lista = "-;" + Configuracao.Lista;
                    sLista = Configuracao.Lista.Split(';');

                    Array.Sort(sLista);
                }

                if (sCamposExtras == "v01") { lblVenda01.Visible = true; lblVenda01.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda01.Visible = true; else { dropVenda01.Visible = true; dropVenda01.DataSource = sLista; dropVenda01.DataBind(); } }
                if (sCamposExtras == "v02") { lblVenda02.Visible = true; lblVenda02.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda02.Visible = true; else { dropVenda02.Visible = true; dropVenda02.DataSource = sLista; dropVenda02.DataBind(); } }
                if (sCamposExtras == "v03") { lblVenda03.Visible = true; lblVenda03.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda03.Visible = true; else { dropVenda03.Visible = true; dropVenda03.DataSource = sLista; dropVenda03.DataBind(); } }
                if (sCamposExtras == "v04") { lblVenda04.Visible = true; lblVenda04.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda04.Visible = true; else { dropVenda04.Visible = true; dropVenda04.DataSource = sLista; dropVenda04.DataBind(); } }
                if (sCamposExtras == "v05") { lblVenda05.Visible = true; lblVenda05.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda05.Visible = true; else { dropVenda05.Visible = true; dropVenda05.DataSource = sLista; dropVenda05.DataBind(); } }
                if (sCamposExtras == "v06") { lblVenda06.Visible = true; lblVenda06.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda06.Visible = true; else { dropVenda06.Visible = true; dropVenda06.DataSource = sLista; dropVenda06.DataBind(); } }
                if (sCamposExtras == "v07") { lblVenda07.Visible = true; lblVenda07.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda07.Visible = true; else { dropVenda07.Visible = true; dropVenda07.DataSource = sLista; dropVenda07.DataBind(); } }
                if (sCamposExtras == "v08") { lblVenda08.Visible = true; lblVenda08.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda08.Visible = true; else { dropVenda08.Visible = true; dropVenda08.DataSource = sLista; dropVenda08.DataBind(); } }
                if (sCamposExtras == "v09") { lblVenda09.Visible = true; lblVenda09.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda09.Visible = true; else { dropVenda09.Visible = true; dropVenda09.DataSource = sLista; dropVenda09.DataBind(); } }
                if (sCamposExtras == "v10") { lblVenda10.Visible = true; lblVenda10.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda10.Visible = true; else { dropVenda10.Visible = true; dropVenda10.DataSource = sLista; dropVenda10.DataBind(); } }
                if (sCamposExtras == "v11") { lblVenda11.Visible = true; lblVenda11.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda11.Visible = true; else { dropVenda11.Visible = true; dropVenda11.DataSource = sLista; dropVenda11.DataBind(); } }
                if (sCamposExtras == "v12") { lblVenda12.Visible = true; lblVenda12.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda12.Visible = true; else { dropVenda12.Visible = true; dropVenda12.DataSource = sLista; dropVenda12.DataBind(); } }
                if (sCamposExtras == "v13") { lblVenda13.Visible = true; lblVenda13.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda13.Visible = true; else { dropVenda13.Visible = true; dropVenda13.DataSource = sLista; dropVenda13.DataBind(); } }
                if (sCamposExtras == "v14") { lblVenda14.Visible = true; lblVenda14.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda14.Visible = true; else { dropVenda14.Visible = true; dropVenda14.DataSource = sLista; dropVenda14.DataBind(); } }
                if (sCamposExtras == "v15") { lblVenda15.Visible = true; lblVenda15.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda15.Visible = true; else { dropVenda15.Visible = true; dropVenda15.DataSource = sLista; dropVenda15.DataBind(); } }
                if (sCamposExtras == "v16") { lblVenda16.Visible = true; lblVenda16.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda16.Visible = true; else { dropVenda16.Visible = true; dropVenda16.DataSource = sLista; dropVenda16.DataBind(); } }
                if (sCamposExtras == "v17") { lblVenda17.Visible = true; lblVenda17.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda17.Visible = true; else { dropVenda17.Visible = true; dropVenda17.DataSource = sLista; dropVenda17.DataBind(); } }
                if (sCamposExtras == "v18") { lblVenda18.Visible = true; lblVenda18.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda18.Visible = true; else { dropVenda18.Visible = true; dropVenda18.DataSource = sLista; dropVenda18.DataBind(); } }
                if (sCamposExtras == "v19") { lblVenda19.Visible = true; lblVenda19.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda19.Visible = true; else { dropVenda19.Visible = true; dropVenda19.DataSource = sLista; dropVenda19.DataBind(); } }
                if (sCamposExtras == "v20") { lblVenda20.Visible = true; lblVenda20.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda20.Visible = true; else { dropVenda20.Visible = true; dropVenda20.DataSource = sLista; dropVenda20.DataBind(); } }
                if (sCamposExtras == "v21") { lblVenda21.Visible = true; lblVenda21.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda21.Visible = true; else { dropVenda21.Visible = true; dropVenda21.DataSource = sLista; dropVenda21.DataBind(); } }
                if (sCamposExtras == "v22") { lblVenda22.Visible = true; lblVenda22.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda22.Visible = true; else { dropVenda22.Visible = true; dropVenda22.DataSource = sLista; dropVenda22.DataBind(); } }
                if (sCamposExtras == "v23") { lblVenda23.Visible = true; lblVenda23.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda23.Visible = true; else { dropVenda23.Visible = true; dropVenda23.DataSource = sLista; dropVenda23.DataBind(); } }
                if (sCamposExtras == "v24") { lblVenda24.Visible = true; lblVenda24.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda24.Visible = true; else { dropVenda24.Visible = true; dropVenda24.DataSource = sLista; dropVenda24.DataBind(); } }
                if (sCamposExtras == "v25") { lblVenda25.Visible = true; lblVenda25.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda25.Visible = true; else { dropVenda25.Visible = true; dropVenda25.DataSource = sLista; dropVenda25.DataBind(); } }
                if (sCamposExtras == "v26") { lblVenda26.Visible = true; lblVenda26.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda26.Visible = true; else { dropVenda26.Visible = true; dropVenda26.DataSource = sLista; dropVenda26.DataBind(); } }
                if (sCamposExtras == "v27") { lblVenda27.Visible = true; lblVenda27.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda27.Visible = true; else { dropVenda27.Visible = true; dropVenda27.DataSource = sLista; dropVenda27.DataBind(); } }
                if (sCamposExtras == "v28") { lblVenda28.Visible = true; lblVenda28.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda28.Visible = true; else { dropVenda28.Visible = true; dropVenda28.DataSource = sLista; dropVenda28.DataBind(); } }
                if (sCamposExtras == "v29") { lblVenda29.Visible = true; lblVenda29.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda29.Visible = true; else { dropVenda29.Visible = true; dropVenda29.DataSource = sLista; dropVenda29.DataBind(); } }
                if (sCamposExtras == "v30") { lblVenda30.Visible = true; lblVenda30.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda30.Visible = true; else { dropVenda30.Visible = true; dropVenda30.DataSource = sLista; dropVenda30.DataBind(); } }
                if (sCamposExtras == "v31") { lblVenda31.Visible = true; lblVenda31.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda31.Visible = true; else { dropVenda31.Visible = true; dropVenda31.DataSource = sLista; dropVenda31.DataBind(); } }
                if (sCamposExtras == "v32") { lblVenda32.Visible = true; lblVenda32.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda32.Visible = true; else { dropVenda32.Visible = true; dropVenda32.DataSource = sLista; dropVenda32.DataBind(); } }
                if (sCamposExtras == "v33") { lblVenda33.Visible = true; lblVenda33.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda33.Visible = true; else { dropVenda33.Visible = true; dropVenda33.DataSource = sLista; dropVenda33.DataBind(); } }
                if (sCamposExtras == "v34") { lblVenda34.Visible = true; lblVenda34.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda34.Visible = true; else { dropVenda34.Visible = true; dropVenda34.DataSource = sLista; dropVenda34.DataBind(); } }
                if (sCamposExtras == "v35") { lblVenda35.Visible = true; lblVenda35.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda35.Visible = true; else { dropVenda35.Visible = true; dropVenda35.DataSource = sLista; dropVenda35.DataBind(); } }
                if (sCamposExtras == "v36") { lblVenda36.Visible = true; lblVenda36.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda36.Visible = true; else { dropVenda36.Visible = true; dropVenda36.DataSource = sLista; dropVenda36.DataBind(); } }
                if (sCamposExtras == "v37") { lblVenda37.Visible = true; lblVenda37.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda37.Visible = true; else { dropVenda37.Visible = true; dropVenda37.DataSource = sLista; dropVenda37.DataBind(); } }
                if (sCamposExtras == "v38") { lblVenda38.Visible = true; lblVenda38.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda38.Visible = true; else { dropVenda38.Visible = true; dropVenda38.DataSource = sLista; dropVenda38.DataBind(); } }
                if (sCamposExtras == "v39") { lblVenda39.Visible = true; lblVenda39.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda39.Visible = true; else { dropVenda39.Visible = true; dropVenda39.DataSource = sLista; dropVenda39.DataBind(); } }
                if (sCamposExtras == "v40") { lblVenda40.Visible = true; lblVenda40.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda40.Visible = true; else { dropVenda40.Visible = true; dropVenda40.DataSource = sLista; dropVenda40.DataBind(); } }
                if (sCamposExtras == "v41") { lblVenda41.Visible = true; lblVenda41.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda41.Visible = true; else { dropVenda41.Visible = true; dropVenda41.DataSource = sLista; dropVenda41.DataBind(); } }
                if (sCamposExtras == "v42") { lblVenda42.Visible = true; lblVenda42.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda42.Visible = true; else { dropVenda42.Visible = true; dropVenda42.DataSource = sLista; dropVenda42.DataBind(); } }
                if (sCamposExtras == "v43") { lblVenda43.Visible = true; lblVenda43.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda43.Visible = true; else { dropVenda43.Visible = true; dropVenda43.DataSource = sLista; dropVenda43.DataBind(); } }
                if (sCamposExtras == "v44") { lblVenda44.Visible = true; lblVenda44.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda44.Visible = true; else { dropVenda44.Visible = true; dropVenda44.DataSource = sLista; dropVenda44.DataBind(); } }
                if (sCamposExtras == "v45") { lblVenda45.Visible = true; lblVenda45.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda45.Visible = true; else { dropVenda45.Visible = true; dropVenda45.DataSource = sLista; dropVenda45.DataBind(); } }
                if (sCamposExtras == "v46") { lblVenda46.Visible = true; lblVenda46.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda46.Visible = true; else { dropVenda46.Visible = true; dropVenda46.DataSource = sLista; dropVenda46.DataBind(); } }
                if (sCamposExtras == "v47") { lblVenda47.Visible = true; lblVenda47.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda47.Visible = true; else { dropVenda47.Visible = true; dropVenda47.DataSource = sLista; dropVenda47.DataBind(); } }
                if (sCamposExtras == "v48") { lblVenda48.Visible = true; lblVenda48.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda48.Visible = true; else { dropVenda48.Visible = true; dropVenda48.DataSource = sLista; dropVenda48.DataBind(); } }
                if (sCamposExtras == "v49") { lblVenda49.Visible = true; lblVenda49.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda49.Visible = true; else { dropVenda49.Visible = true; dropVenda49.DataSource = sLista; dropVenda49.DataBind(); } }
                if (sCamposExtras == "v50") { lblVenda50.Visible = true; lblVenda50.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda50.Visible = true; else { dropVenda50.Visible = true; dropVenda50.DataSource = sLista; dropVenda50.DataBind(); } }
                if (sCamposExtras == "v51") { lblVenda51.Visible = true; lblVenda51.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda51.Visible = true; else { dropVenda51.Visible = true; dropVenda51.DataSource = sLista; dropVenda51.DataBind(); } }
                if (sCamposExtras == "v52") { lblVenda52.Visible = true; lblVenda52.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda52.Visible = true; else { dropVenda52.Visible = true; dropVenda52.DataSource = sLista; dropVenda52.DataBind(); } }
                if (sCamposExtras == "v53") { lblVenda53.Visible = true; lblVenda53.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda53.Visible = true; else { dropVenda53.Visible = true; dropVenda53.DataSource = sLista; dropVenda53.DataBind(); } }
                if (sCamposExtras == "v54") { lblVenda54.Visible = true; lblVenda54.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda54.Visible = true; else { dropVenda54.Visible = true; dropVenda54.DataSource = sLista; dropVenda54.DataBind(); } }
                if (sCamposExtras == "v55") { lblVenda55.Visible = true; lblVenda55.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda55.Visible = true; else { dropVenda55.Visible = true; dropVenda55.DataSource = sLista; dropVenda55.DataBind(); } }
                if (sCamposExtras == "v56") { lblVenda56.Visible = true; lblVenda56.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda56.Visible = true; else { dropVenda56.Visible = true; dropVenda56.DataSource = sLista; dropVenda56.DataBind(); } }
                if (sCamposExtras == "v57") { lblVenda57.Visible = true; lblVenda57.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda57.Visible = true; else { dropVenda57.Visible = true; dropVenda57.DataSource = sLista; dropVenda57.DataBind(); } }
                if (sCamposExtras == "v58") { lblVenda58.Visible = true; lblVenda58.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda58.Visible = true; else { dropVenda58.Visible = true; dropVenda58.DataSource = sLista; dropVenda58.DataBind(); } }
                if (sCamposExtras == "v59") { lblVenda59.Visible = true; lblVenda59.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda59.Visible = true; else { dropVenda59.Visible = true; dropVenda59.DataSource = sLista; dropVenda59.DataBind(); } }
                if (sCamposExtras == "v60") { lblVenda60.Visible = true; lblVenda60.Text = sLabel; if (String.IsNullOrEmpty(Configuracao.Lista)) txtVenda60.Visible = true; else { dropVenda60.Visible = true; dropVenda60.DataSource = sLista; dropVenda60.DataBind(); } }
            }
        }

        //Preenche a linha de 'Prospect', caso tenha 1 ou 2
        if (tableProspect.Rows.Count == 1)
        {
            tableProspect.Rows.Add(rowProspect);
            rowProspect = new HtmlTableRow();
        }
        else if (tableProspect.Rows.Count == 2)
        {
            tableProspect.Rows.Add(rowProspect);
            rowProspect = new HtmlTableRow();
        }
        else if (tableProspect.Rows.Count == 3)
        {
            tableProspect.Rows.Add(rowProspect);
            rowProspect = new HtmlTableRow();
        }

        //Preenche a linha de Venda, caso tenha 1 ou 2
        if (tableDadosVenda.Rows.Count == 0x00000012)//Mostrar Victor
        {
            tableDadosVenda.Rows.Add(rowDadosVenda);
            rowDadosVenda = new HtmlTableRow();
        }
        TabContainerAtendimento.ActiveTabIndex = 0;
    }
    #endregion

    protected void cmdVoltarTopo_Click(object sender, EventArgs e)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
        prospectCTL CProspect = new prospectCTL();

        //Liberar venda em uso pelo backoffice
        int iIDHistorico = Convert.ToInt32(hddIDHistorico.Value);
        if (Usuario.Perfil != "Operador")
            CProspect.PegarVendaParaAuditarBackoffice(iIDHistorico, -1);

        string sLink = "vendaFiltro.aspx";
        if (Request.QueryString["IDCampanha"] != null)
        {
            sLink += "?IDCampanha=" + Request.QueryString["IDCampanha"].ToString();
            sLink += "&DataInicial=" + Request.QueryString["DataInicial"].ToString();
            sLink += "&DataFinal=" + Request.QueryString["DataFinal"].ToString();
            sLink += "&Telefone1=" + Request.QueryString["Telefone1"].ToString();
            sLink += "&Nome=" + Request.QueryString["Nome"].ToString();
            sLink += "&CPF_CNPJ=" + Request.QueryString["CPF_CNPJ"].ToString();
            sLink += "&IDOperador=" + Request.QueryString["IDOperador"].ToString();
            sLink += "&IDStatusAuditoria=" + Request.QueryString["IDStatusAuditoria"].ToString();
            sLink += "&IDDadosVenda=" + Request.QueryString["IDDadosVenda"].ToString();
            sLink += "&TextoDadosVenda=" + Request.QueryString["TextoDadosVenda"].ToString();
        }

        Response.Redirect(sLink);
    }

    protected void cmdVoltarRodape_Click(object sender, EventArgs e)
    {
        string sLink = "vendaFiltro.aspx";
        if (Request.QueryString["IDCampanha"] != null)
        {
            sLink += "?IDCampanha=" + Request.QueryString["IDCampanha"].ToString();
            sLink += "&DataInicial=" + Request.QueryString["DataInicial"].ToString();
            sLink += "&DataFinal=" + Request.QueryString["DataFinal"].ToString();
            sLink += "&Telefone1=" + Request.QueryString["Telefone1"].ToString();
            sLink += "&Nome=" + Request.QueryString["Nome"].ToString();
            sLink += "&CPF_CNPJ=" + Request.QueryString["CPF_CNPJ"].ToString();
            sLink += "&IDOperador=" + Request.QueryString["IDOperador"].ToString();
            sLink += "&IDStatusAuditoria=" + Request.QueryString["IDStatusAuditoria"].ToString();
            sLink += "&IDDadosVenda=" + Request.QueryString["IDDadosVenda"].ToString();
            sLink += "&TextoDadosVenda=" + Request.QueryString["TextoDadosVenda"].ToString();
        }

        Response.Redirect(sLink);
    }

    protected void EnviarObservacaoVenda()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
        prospect Prospect = new prospect();
        prospectCTL CProspect = new prospectCTL();
        string sobservacao = txtEnviarObsVenda.Text.Trim();
        int iIDVenda = Convert.ToInt32(hddIDVenda.Value);
        int iIDUsuario = Usuario.IDUsuario;
        int iRemetente = Convert.ToInt32(Usuario.IDPerfil);
        CProspect.EnviarObservacaoTratamentoVenda(iIDVenda, iIDUsuario, sobservacao, iRemetente);
        LimparCampos();
        RetornarObservacoesVenda(iIDVenda);

    }

    protected void cmdMensagem_Click(object sender, EventArgs e)
    {
        string sMensagem;

        if (txtEnviarObsVenda.Text != "")
        {
            EnviarObservacaoVenda();

            sMensagem = "Nova observação enviada para equipe Backoffice!";
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
        }

        else
            sMensagem = "Favor preencher o campo!";
        PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
    }

    public void RetornarObservacoesVenda(int iIDVenda)
    {
        relatorioCTL CRelatorio = new relatorioCTL();
        DataTable dataTable;

        dataTable = CRelatorio.RetornarObservacoesVenda(iIDVenda);
        grdHistoricoVenda.DataSource = dataTable;
        grdHistoricoVenda.Columns[0].Visible = true;
        grdHistoricoVenda.DataBind();
    }

    protected void grdHistoricoVenda_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
        if (e.CommandName == "Abrir")
        {
            string sObservacao = grdHistoricoVenda.DataKeys[int.Parse((string)e.CommandArgument)]["Observação"].ToString();
            txtObsVenda.Text = sObservacao;
            int iIDVenda = Convert.ToInt32(hddIDVenda.Value);
            int iIDUsuario = Usuario.IDUsuario;
            int iIDTratamento = Convert.ToInt32(grdHistoricoVenda.DataKeys[int.Parse((string)e.CommandArgument)]["IDTratamento"].ToString());
            AtualizarLeituraTratamentoVenda(iIDVenda, iIDTratamento, iIDUsuario);
         
        }
    }
    protected void cmdLimpar_Click(object sender, EventArgs e)
    {
        LimparCampos();
    }

    private void LimparCampos()
    {
        txtEnviarObsVenda.Text = string.Empty;
    }

    private void AtualizarLeituraTratamentoVenda(int iIDVenda, int iIDTratamento, int iIDUsuario)
    {
        prospectCTL CProspect = new prospectCTL();
        CProspect.AtualizarLeituraTratamentoVenda(iIDVenda, iIDTratamento, iIDUsuario);
        RetornarObservacoesVenda(iIDVenda);
    }
}
