using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller;
using model.objetos;
using System.Data;

public partial class supervisor_Default : App_Code.BaseWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");

        if (!IsPostBack)
        {
            CarregarCampanhas();

            if (HttpContext.Current.Session["IDCampanha"] == null)
            {
                txtdatDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtdatDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                dropCampanha.SelectedValue = HttpContext.Current.Session["IDCampanha"].ToString();
                txtdatDataInicial.Text = HttpContext.Current.Session["DataInicial"].ToString();
                txtdatDataFinal.Text = HttpContext.Current.Session["DataFinal"].ToString();
                chkTop10.Checked = Convert.ToBoolean(HttpContext.Current.Session["Top10"]);
            }
        }
    }

    private void CarregarCampanhas()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
        
        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDrop_Campanhas(dropCampanha, true, true, false, Usuario.IDUsuario, Usuario.Perfil);
    }

    public void RetornarMailingVirgem()
    {
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue);

        relatorioCTL CRelatorio = new relatorioCTL();
        DataTable dataTable = CRelatorio.RetornarProspectsVirgens_dashboard(iIDCampanha);

        string sDados = "['Campanha', 'Quantidade', { role: 'annotation' }]";
        string sLabelValor;
        int iQuantidade = 0;

        if (dataTable.Rows.Count > 0)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                sLabelValor = dataRow["Quantidade"].ToString() == "0" ? "" : dataRow["Quantidade"].ToString();
                sDados += ", ['" + dataRow["Campanha"].ToString() + "', " + dataRow["Quantidade"].ToString() + ", '" + sLabelValor + "'] ";

                iQuantidade += Convert.ToInt32(dataRow["Quantidade"]);
            }
        }
        else
            sDados += ", ['', 0, ''] ";

        legenda_mailing_virgem.InnerText = iQuantidade.ToString() + " prospects virgens disponíveis";
        Response.Write(sDados);
    }

    public void RetornarVendas()
    {
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue);
        string sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
        string sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";
        bool bTop10 = chkTop10.Checked;

        relatorioCTL CRelatorio = new relatorioCTL();
        DataSet dataSet = CRelatorio.RetornarVendas_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);
        
        string sDados = "['Televendedor', 'Quantidade', { role: 'annotation' }]";
        string sLabelValor;
        int iQuantidade = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]);
        
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                sLabelValor = dataRow["Quantidade"].ToString() == "0" ? "" : dataRow["Quantidade"].ToString();
                sDados += ", ['" + dataRow["Televendedor"].ToString() + "', " + dataRow["Quantidade"].ToString() + ", '" + sLabelValor + "'] ";
            }
        }
        else
            sDados += ", ['', 0, ''] ";

        legenda_vendas.InnerText = iQuantidade.ToString() + " venda(s) efetivadas";
        Response.Write(sDados);
    }

    public void RetornarContatosOperadores()
    {
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue);

        string sDataInicial = "";
        try
        {
            sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
        }
        catch
        {
            sDataInicial = DateTime.Now.ToString("yyyy/MM/dd");
        }

        string sDataFinal = "";
        try
        {
            sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";
        }
        catch
        {
            sDataFinal = DateTime.Now.ToString("yyyy/MM/dd");
        }

        bool bTop10 = chkTop10.Checked;

        relatorioCTL CRelatorio = new relatorioCTL();
        DataSet dataSet = CRelatorio.RetornarContatosOperadores_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);

        string sDados = "['Operador', 'Quantidade', { role: 'annotation' }]";
        string sLabelValor;
        int iQuantidade = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]);

        if (dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                sLabelValor = dataRow["Quantidade"].ToString() == "0" ? "" : dataRow["Quantidade"].ToString();
                sDados += ", ['" + dataRow["Operador"].ToString() + "', " + dataRow["Quantidade"].ToString() + ", '" + sLabelValor + "'] ";
            }
        }
        else
            sDados += ", ['', 0, ''] ";

        legenda_contatos_realizados.InnerText = iQuantidade.ToString() + " contatos dos operadores";
        Response.Write(sDados);
    }

    public void RetornarStatusContatos()
    {
        int iIDCampanha = Convert.ToInt32(dropCampanha.SelectedValue);

        string sDataInicial = "";
        try
        {
            sDataInicial = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataInicial.Text);
        }
        catch
        {
            sDataInicial = DateTime.Now.ToString("yyyy/MM/dd");
        }

        string sDataFinal = "";
        try
        {
            sDataFinal = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(txtdatDataFinal.Text) + " 23:59:59";
        }
        catch
        {
            sDataFinal = DateTime.Now.ToString("yyyy/MM/dd");
        }

        bool bTop10 = chkTop10.Checked;

        relatorioCTL CRelatorio = new relatorioCTL();
        DataSet dataSet = CRelatorio.RetornarStatusContatos_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);

        string sDados = "";

        foreach (DataRow dataRow in dataSet.Tables[0].Rows)
        {
            sDados += "['" + dataRow["Status"].ToString() + "', " + dataRow["Quantidade"].ToString() + "], ";
        }

        Response.Write(sDados);
    }

    protected void cmdAtualizar_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Session["IDCampanha"] = dropCampanha.SelectedValue;
        HttpContext.Current.Session["DataInicial"] = txtdatDataInicial.Text;
        HttpContext.Current.Session["DataFinal"] = txtdatDataFinal.Text;
        HttpContext.Current.Session["Top10"] = chkTop10.Checked;
        
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "drawChart();", true);
    }

    
}