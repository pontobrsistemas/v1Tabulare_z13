using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.dados;
using System.Windows.Forms;

namespace model.negocios
{
    public class acaoBLL
    {
        public DataTable RetornarAcoes()
        {
            acaoDAL DAcao = new acaoDAL();
            string sSql = DAcao.RetornarAcoes();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public string RetornarIDAcao(string sAcao)
        {
            acaoDAL DAcao = new acaoDAL();
            string sSql = DAcao.RetornarIDAcao(sAcao);

            return PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);
        }

        public string RetornarDropAcoes()//r
        {
            acaoDAL DAcao = new acaoDAL();
            string sSql = DAcao.RetornarAcoes();

            return sSql;
        }
    }
}
