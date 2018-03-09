using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.negocios;
using model.objetos;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace controller
{
    public class acaoCTL
    {
        public void PreencherComboBox_Acao(ComboBox comboAcao)     
        {
            acaoBLL BAcao = new acaoBLL();
            DataTable dataTable = BAcao.RetornarAcoes();

            PontoBr.Utilidades.WCL.CarregarComboBox(comboAcao, dataTable, "IDAcao", "Acao", false, true);
        }

        public string RetornarIDAcao(string sAcao)
        {
            acaoBLL BAcao = new acaoBLL();
            return BAcao.RetornarIDAcao(sAcao);            
        }

        public void PreencherDrop_Acao(DropDownList dropAcao)//r
        {
            acaoBLL BAcao = new acaoBLL();
            string sSql = BAcao.RetornarDropAcoes();

            PontoBr.Utilidades.WCL.CarregarDropDown(dropAcao, sSql, "Acao", "IDAcao", false, true);
        }
    }
}
