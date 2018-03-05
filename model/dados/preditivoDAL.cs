using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;

namespace model.dados
{
    public class preditivoDAL
    {
        internal string RetornarFilas()
        {
            string sSql = " select IDFila, Fila ";
            sSql += " from tFila ";
            sSql += " where Ativo = 1 ";
            sSql += " order by Fila ";

            return sSql;
        }

        internal string RetornarFila(string sIDFila)
        {
            string sSql = " select * ";
            sSql += " from tFila ";
            sSql += " where IDFila = '"+sIDFila+"' ";
            
            return sSql;
        }

        internal string RetornarIDUsuarioTelaLiberada(int iNroAgente)
        {
            string sSql = " select IDUsuario ";
            sSql += " from tUsuario ";
            //sSql += " where NroAgente = " + iNroAgente + " and IDProspect is null ";
            sSql += " where NroAgente = " + iNroAgente + " and IDProspect is null and TabulareLogado = 1 ";

            return sSql;
        }

        internal string PretornarProspectPreditivoUsuario(int iIDUsuario)
        {
            string sSql = " SELECT a.IDProspect, a.Telefone1, a.Telefone2, a.Telefone3, a.Nome, a.CPF_CNPJ, ";
            sSql += " a.Logradouro, a.Numero, a.Complemento, a.Bairro, a.Cidade, a.Estado, a.Email, ";
            sSql += " a.Campo01, a.Campo02, a.Campo03, a.Campo04, a.Campo05, a.Campo06, a.Campo07, ";
            sSql += " a.Campo08, a.Campo09, a.Campo10, a.IDMailing, b.Mailing,b.IDCampanha ";
            sSql += " FROM tProspect a ";
            sSql += " inner join tMailing b on a.IDMailing = b.IDMailing ";
            sSql += " where IDProspect in (	select IDProspect ";
            sSql += " from tUsuario ";
            sSql += " where IDUsuario = " + iIDUsuario + " ";
            sSql += " and IDProspect is not null) ";

            return sSql;
        }

        internal string RetornarProspectResubmit(int iIDProspect)
        {
            string sSql = " exec ResubmitVonix @IDProspect "+iIDProspect+" ";

            return sSql;
        }
    }
}
