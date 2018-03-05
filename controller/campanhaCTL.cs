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
    public class campanhaCTL
    {
        public int RetornarIDCampanha(string sCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarIDCampanha(sCampanha);
        }

        public int RetornarIDCampanhaPreditivo(string sCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarIDCampanhaPreditivo(sCampanha);
        }

        public DataTable RetornarCampanhasOperador(bool bAtiva, int iIDUsuario, string sPerfil)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCampanhas(bAtiva, iIDUsuario, sPerfil);
            // DataTable dataTable = BCampanha.RetornarCampanhas(bAtiva, iIDUsuario, sPerfil);
        }


        public DataTable RetornarCampanhas()
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCampanhas();
        }

        public string RetornarOperadora(int iIDCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarOperadora(iIDCampanha);
        }

        public void PreencherComboBox_Campanhas(ComboBox comboCampanha, bool bAtiva, bool bTodos, bool bSelecione, int iIDUsuario, string sPerfil)//
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCampanhas(bAtiva, iIDUsuario, sPerfil);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboCampanha, dataTable, "IDCampanha", "Campanha", bTodos, bSelecione);
        }

        public void CadastrarCampanhas(campanha campanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            BCampanha.CadastrarCampanhas(campanha);
        }

        public void AtualizaCampanha(campanha campanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            BCampanha.AtualizaCampanha(campanha);
        }

        public void PreencherCheckListBox_CampanhasAtivas(CheckedListBox chlCampanha, int iIDUsuario, string sPerfil)//r
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCampanhas(true, iIDUsuario, sPerfil);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlCampanha, dataTable, "Campanha", "IDCampanha");
        }

        public void PreencherCheckListBox_CampanhasAtivasFilas(CheckedListBox chlCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCampanhasFilas(true);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlCampanha, dataTable, "Campanha", "IDCampanha");
        }

        public void PreencherComboBox_CampanhaLogar(ComboBox comboCampanha, int IDCampanha, bool bTodos, bool bSelecione)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCampanhaLogar(IDCampanha);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboCampanha, dataTable, "IDCampanha", "Campanha", bTodos, bSelecione);
        }

        public void RetornarCamposCampanhas(ComboBox comboCampos, int iIDCampanha, bool bTodos, bool bSelecione)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable datatable = BCampanha.RetornarCamposCampanha(iIDCampanha);//ROBSON

            PontoBr.Utilidades.WCL.CarregarComboBox(comboCampos, datatable, "IDCampo", "Campo", bTodos, bSelecione);
        }

        public DataTable RetornarCampo(int iIDCampanha, string sIDCampo)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCampo(iIDCampanha, sIDCampo);
        }

        public DataTable RetornarCamposCampanha(int iIDCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCamposCampanha(iIDCampanha);
        }

        public DataTable RetornarCamposVendaCampanhas(int iIDCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCamposVendaCampanhas(iIDCampanha);
        }

        public DataTable RetornarCampoConfiguracaoInicial(string sIDCampo)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCampoConfiguracaoInicial(sIDCampo);
        }

        public void ReconfigurarCampo(int iIDCampanha, string sIDCampo, string sTexto, string sTamanhoTextBox, string sLocalizacaoTextBox, string sLocalizacaoLabel, int iObrigatorio, string sLista)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            BCampanha.ReconfigurarCampo(iIDCampanha, sIDCampo, sTexto, sTamanhoTextBox, sLocalizacaoTextBox, sLocalizacaoLabel, iObrigatorio, sLista);
        }

        public DataTable RetornarCampanha(string sCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCampanha(sCampanha);
        }

        public void PreencherComboBox_CampanhasUsuario(ComboBox comboCampanha, int iIDUsuario, bool bTodos, bool bSelecione)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCampanhasUsuario(iIDUsuario);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboCampanha, dataTable, "IDCampanha", "Campanha", bTodos, bSelecione);
        }

        public void PreencherDropCampanha(DropDownList dropCampanha, int iIDUsuario, bool bTodos, bool bSelecione)//r
        {
            campanhaBLL BCampanha = new campanhaBLL();
            string sSql = BCampanha.RetornarCampanhas(iIDUsuario);

            PontoBr.Utilidades.WCL.CarregarDropDown(dropCampanha, sSql, "Campanha", "IDCampanha", bTodos, bSelecione);
        }

        public void PreencherCheckListBox_CamposVendaCampanhas(CheckedListBox chlCampos, string sCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCamposVendaCampanhas(sCampanha);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlCampos, dataTable, "Texto", "IDCampo");
        }

        public void PreencherCheckListBox_CamposListaVendaCampanhas(CheckedListBox chlCampos, string sCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCamposListaVendaCampanhas(sCampanha);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlCampos, dataTable, "Texto", "IDCampo");
        }

        public void PreencherComboBox_DadosVenda(ComboBox comboDadosVenda, string sCampanha, bool bTodos, bool bSelecione)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCamposVendaCampanhas(sCampanha);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboDadosVenda, dataTable, "IDCampo", "Texto", bTodos, bSelecione);
        }

        public void PreencherDropdownDadosVenda(DropDownList dropDadosVenda, string sIDCampanha, bool bTodos, bool bSelecione)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            string sSql = BCampanha.RetornarDadosVenda(sIDCampanha);

            PontoBr.Utilidades.WCL.CarregarDropDown(dropDadosVenda, sSql, "Texto", "IDCampo", bTodos, bSelecione);
        }

        public void PreencherCheckListBox_CamposProspect(CheckedListBox chlCampos, string sCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCamposProspect(sCampanha);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlCampos, dataTable, "Texto", "IDCampo");
        }

        public campanha RetornarCampanha(int iIDCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCampanha(iIDCampanha);
        }

        public void ExcluirCampoCampanha(int iIDCampanha, string sIDCampo)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            BCampanha.ExcluirCampoCampanha(iIDCampanha, sIDCampo);
        }

        public void CarregarCampanhasAtivasCheckBoxList(CheckBoxList CheckBoxCampanha, int iIDUsuario, string sPerfil)//r
        {
            campanhaBLL BCampanha = new campanhaBLL();
            string sSql = BCampanha.RetornarCampanhasAtivas(true, iIDUsuario, sPerfil);

            PontoBr.Utilidades.WCL.CarregarCheckBoxList(CheckBoxCampanha, sSql, "Campanha", "IDCampanha");
        }

        public void PreencherDrop_Campanhas(DropDownList dropCampanha, bool bAtiva, bool bTodos, bool bSelecione, int iIDUsuario, string sPerfil)//r
        {
            campanhaBLL BCampanha = new campanhaBLL();
            string sSql = BCampanha.RetornarDropCampanhas(bAtiva, iIDUsuario, sPerfil);

            PontoBr.Utilidades.WCL.CarregarDropDown(dropCampanha, sSql, "Campanha", "IDCampanha", bTodos, bSelecione);
        }

        public void CarregarGridviewCampanhas(GridView grdDados)//r
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarCampanhas();

            grdDados.DataSource = dataTable;
            grdDados.DataBind();
        }

        public campanha CarregarGridviewCampanha(GridView dgCampanha, int iIDCampanha)//r
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarCampanha(iIDCampanha);
        }

        public DataTable RetornarBloqueioDDD(int iIDCampanha)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            return BCampanha.RetornarBloqueioDDD(iIDCampanha);
        }

        public void PreencherCheckListBox_ListaCampoVenda(CheckedListBox chlLista, int iIDCampanha, string sCampo)
        {
            campanhaBLL BCampanha = new campanhaBLL();
            DataTable dataTable = BCampanha.RetornarListaCampoVenda(iIDCampanha, sCampo);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                sCampo = dataRow["Lista"].ToString().Substring(0,dataRow["Lista"].ToString().IndexOf("=>")).Trim();

                string[] sOpcoes = dataRow["Lista"].ToString().Substring(dataRow["Lista"].ToString().IndexOf("=>") + 2).Trim().Split(';');
                foreach (string sOpcao in sOpcoes)
                {
                    chlLista.Items.Add(sCampo + " => " + sOpcao);
                }
            }
        }
    }
}
