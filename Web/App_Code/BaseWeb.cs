using System;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Xml;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;

namespace App_Code
{
	/// <summary>
	/// Classe base das interfaces web.
	/// </summary>
	public class BaseWeb : System.Web.UI.Page
	{
        /// <summary>
		/// Garante que as paginas fiquem fora do cache do browser.
		/// </summary>
		/// <param name="e"></param>
        override protected void OnInit(EventArgs e)
        {
            //se o div de Aguarde ainda estiver mostrando ele tira
            ScriptManager src = ScriptManager.GetCurrent(Page);
            if (src != null)
                ScriptManager.RegisterClientScriptBlock(this, typeof(void), "TiraDivAguarde", "if(document.getElementById('divProcessando'))document.getElementById('divProcessando').style.display = 'none';", true);
            else
                ClientScript.RegisterStartupScript(typeof(Page), "TiraDivAguarde", "if(document.getElementById('divProcessando'))document.getElementById('divProcessando').style.display = 'none';", true);

            Response.Expires = -1;
            base.OnInit(e);

            RenderizarAguarde();
        }

		/// <summary>
		/// Scripts para renderizar o aviso de processamento 
		/// </summary>
        /// 
		private void RenderizarAguarde()
		{
            StringBuilder stringBuilder = new StringBuilder();            

            stringBuilder.Append("<script language=\"javascript\" src=\"../scripts/web.js\"></script>");
            stringBuilder.Append("<script>document.forms[0].BP_RealOnSubmit = document.forms[0].submit;");
            stringBuilder.Append("function BP_OnSubmit(){");
            stringBuilder.Append("try {document.forms[0].BP_RealOnSubmit();} catch(e) { }");
            stringBuilder.Append("}");
            stringBuilder.Append("document.forms[0].submit = BP_OnSubmit;</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "IncluirAguarde", stringBuilder.ToString(), false);
            ClientScript.RegisterOnSubmitStatement(this.GetType(), "Aguarde", "if (typeof(ValidatorOnSubmit) == 'function' && ValidatorOnSubmit() == false) return false; if(typeof(avisoAguarde) == 'function')avisoAguarde();");
		}

    }
}
