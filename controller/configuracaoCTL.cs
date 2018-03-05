using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using model.negocios;
using model.objetos;

namespace controller
{
    public class configuracaoCTL
    {
        public void CarregarStringConexao() 
        {
            configuracaoBLL BConfiguracao = new configuracaoBLL();
            BConfiguracao.CarregarStringConexao();
        }

        public configuracao RetornarConfiguracoes()
        {
            configuracaoBLL BConfiguracao = new configuracaoBLL();
            return BConfiguracao.RetornarConfiguracoes();
        }
       
        public int VerificarRamalDNS(string sDNS)
        {
            configuracaoBLL BConfiguracao = new configuracaoBLL();
            return BConfiguracao.VerificarRamalDNS(sDNS);
        }

        public void CadastrarRamalDNS(int iRamal, string sDNS, string sAgent) 
        {
            configuracaoBLL BConfiguracao = new configuracaoBLL();
            BConfiguracao.CadastrarRamalDNS(iRamal, sDNS, sAgent);
        }

        public ArrayList RetornarCamposCampanha(int iIDCampanha)
        {
            ArrayList arrayList = new ArrayList();
                        
            configuracaoBLL BConfiguracao = new configuracaoBLL();
            DataTable dataTable =  BConfiguracao.RetornarCamposCampanha(iIDCampanha);

            for (int iLinha = 0; iLinha < dataTable.Rows.Count; iLinha++)
            {
                string sIDCampo = dataTable.Rows[iLinha]["IDCampo"].ToString();
                string sTexto = dataTable.Rows[iLinha]["Texto"].ToString();
                string sLabel = dataTable.Rows[iLinha]["Label"].ToString();
                string sTextBox = dataTable.Rows[iLinha]["TextBox"].ToString();
                string sTamanhoTextBox = dataTable.Rows[iLinha]["TamanhoTextBox"].ToString();
                string sLocalizacaoTextBox = dataTable.Rows[iLinha]["LocalizacaoTextBox"].ToString();
                string sLocalizacaoLabel = dataTable.Rows[iLinha]["LocalizacaoLabel"].ToString();
                bool bObrigatorio = Convert.ToBoolean(dataTable.Rows[iLinha]["Obrigatorio"].ToString());
                string sLista = dataTable.Rows[iLinha]["Lista"].ToString().Trim();

                if (!String.IsNullOrEmpty(sLista) && sLista.Substring(sLista.Length - 1) == ";")
                    sLista = sLista.Remove(sLista.Length - 1);

                configuracao Configuracao = new configuracao(sIDCampo, sTexto, sLabel, sTextBox, sTamanhoTextBox, sLocalizacaoTextBox, sLocalizacaoLabel, bObrigatorio, sLista);
                arrayList.Add(Configuracao);
            }
            return arrayList;
        }

        public void CadastrarDadosSocket(string sIP, int iPort)
        {
            configuracaoBLL BConfiguracao = new configuracaoBLL();
            BConfiguracao.CadastrarDadosSocket(sIP, iPort);
        }

        public DataTable RetornarDadosSocket()
        {
            configuracaoBLL BConfiguracao = new configuracaoBLL();
            DataTable dataTable = BConfiguracao.RetornarDadosSocket();

            return dataTable;
        }
    }
}
