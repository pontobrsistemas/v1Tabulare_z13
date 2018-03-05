using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller;
using model.objetos;
using System.Configuration;

public partial class MasterPage_backoffice : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.Session["Usuario"] != null)
            {
                CarregarInformacoesUsuario();
            }
            else
                Response.Redirect("../login/logout.aspx?e=logout");
        }
        AdpaterMenu();
    }

    private void AdpaterMenu()
    {
        if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
        {
            Request.Browser.Adapters.Clear();
        }
    }
    
    private void CarregarInformacoesUsuario()
    {
        usuario Usuario = new usuario();
        Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        lblUsuario.Text += Usuario.Nome.ToUpper() + " (" + Usuario.Perfil.ToUpper() + ")";
    }
}
