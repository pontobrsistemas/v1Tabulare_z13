using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Session.Clear();

        if (Request.QueryString["e"] != null) 
            Response.Redirect("Default.aspx?e=logout");
        else
            Response.Redirect("Default.aspx");
    }
}