using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.dados;
using model.objetos;
using System.Windows.Forms;

namespace model.negocios
{
    public class campanhaBLL
    {
        public int RetornarIDCampanha(string sCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarIDCampanha(sCampanha);

            string sIDCampanha = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            if (sIDCampanha == "")
                return 0;
            else
                return Convert.ToInt32(sIDCampanha);
        }

        public int RetornarIDCampanhaPreditivo(string sCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarIDCampanhaPreditivo(sCampanha);

            string sIDCampanha = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            if (sIDCampanha == "")
                return 0;
            else
                return Convert.ToInt32(sIDCampanha);
        }

        public DataTable RetornarCampanhas()
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhas();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);        
        }

        public DataTable RetornarCamposOperador()
        {
            campanhaDAL DcamposOperador = new campanhaDAL();
            string sSql = DcamposOperador.RetornarCamposOperador();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string RetornarOperadora(int iIDCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarOperadora(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);
        }

        public DataTable RetornarCampanhas(bool bAtiva, int iIDUsuario, string sPerfil)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhas(bAtiva, iIDUsuario, sPerfil);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarCampanhasFilas(bool bAtiva)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhasFilas(bAtiva);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void CadastrarCampanhas(campanha campanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.CadastrarCampanhas(campanha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void AtualizaCampanha(campanha campanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.AtualizaCampanha(campanha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarCampanhaLogar(int IDCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhaLogar(IDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarCamposCampanha(int IDCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCamposCampanha(IDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarCampo(int IDCampanha, string sIDCampo)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampo(IDCampanha, sIDCampo);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarCampoConfiguracaoInicial(string sIDCampo)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampoConfiguracaoInicial(sIDCampo);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void ReconfigurarCampo(int iIDCampanha, string sIDCampo, string sTexto, string sTamanhoTextBox, string sLocalizacaoTextBox, string sLocalizacaoLabel, int iObrigatorio, string sLista)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.ReconfigurarCampo(iIDCampanha, sIDCampo, sTexto, sTamanhoTextBox, sLocalizacaoTextBox, sLocalizacaoLabel, iObrigatorio, sLista);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarCampanha(string sCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanha(sCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarCampanhasUsuario(int iIDUsuario)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhasUsuario(iIDUsuario);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string RetornarCampanhas(int iIDUsuario)//r
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhasUsuario(iIDUsuario);
            return sSql;
        }

        public DataTable RetornarCamposVendaCampanhas(string sCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCamposVendaCampanhas(sCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarCamposListaVendaCampanhas(string sCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCamposListaVendaCampanhas(sCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarCamposVendaCampanhas(int iIDCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCamposVendaCampanhas(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string RetornarDadosVenda(string sIDCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            return DCampanha.RetornarDadosVenda(sIDCampanha);
        }

        public DataTable RetornarCamposProspect(string sCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCamposProspect(sCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public campanha RetornarCampanha(int iIDCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanha(iIDCampanha);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            campanha Campanha = new campanha();
            Campanha.iIDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
            Campanha.sCampanha = dataTable.Rows[0]["Campanha"].ToString();
            Campanha.Fila = dataTable.Rows[0]["Fila"].ToString();
            Campanha.TipoDiscador = dataTable.Rows[0]["TipoDiscador"].ToString();

            Campanha.iAtivo = Convert.ToInt32(dataTable.Rows[0]["Ativo"]);//r
            Campanha.sOperadora = dataTable.Rows[0]["operadora"].ToString();

            return Campanha;
        }

        public void ExcluirCampoCampanha(int iIDCampanha, string sIDCampo)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.ExcluirCampoCampanha(iIDCampanha, sIDCampo);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public string RetornarCampanhasAtivas(bool bAtiva, int iIDUsuario, string sPerfil)//r
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhasAtivas(bAtiva, iIDUsuario, sPerfil);

            return sSql;
        }
      
        public string RetornarDropCampanhas(bool bAtiva, int iIDUsuario, string sPerfil)//r
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarCampanhas(bAtiva, iIDUsuario, sPerfil);

            return sSql;
        }

        public DataTable RetornarBloqueioDDD(int iIDCampanha)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarBloqueioDDD(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarListaCampoVenda(int iIDCampanha, string sCampo)
        {
            campanhaDAL DCampanha = new campanhaDAL();
            string sSql = DCampanha.RetornarListaCampoVenda(iIDCampanha, sCampo);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }
    }
}
