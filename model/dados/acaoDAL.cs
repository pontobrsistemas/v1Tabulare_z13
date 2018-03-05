using System;
using System.Collections.Generic;
using System.Text;

namespace model.dados
{
    public class acaoDAL
    {
        internal string RetornarAcoes()
        {
            string sSql = " select IDAcao, Acao from tACao ";            
            return sSql;
        }

        internal string RetornarIDAcao(string sAcao)
        {
            string sSql = " select IDAcao from tACao ";
            sSql += " where Acao = '"+sAcao+"' ";
            return sSql;
        }
    }
}
