using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;

namespace model.dados
{
    public class mailingDAL
    {
        internal string RetornarMailings(bool bAtivo, int iIDCampanha)
        {
            string sSql = " select a.IDMailing [Cód. Mailing], a.Mailing,c.Campanha, a.DataCadastro [Data Cadastro], ";
            sSql += " case when a.Ativo = 1 then 'Sim' else 'Não' end Ativo, ";
            sSql += " b.Nome [Cadastrado por] ";
            sSql += " from tMailing a ";
            sSql += " inner join tUsuario b on a.IDUsuario = b.IDUsuario ";
            sSql += " inner join tCampanha c on a.IDCampanha = c.IDCampanha ";

            if (bAtivo == true)
            {
                sSql += " where a.Ativo = 1 ";
                if (iIDCampanha != -1)
                    sSql += " and a.IDCampanha = " + iIDCampanha + " ";
            }
            if (bAtivo == false)
            {
                if (iIDCampanha != -1)
                    sSql += " where a.IDCampanha = " + iIDCampanha + " ";
            }

            sSql += " order by a.DataCadastro desc ";
            return sSql;
        }

        internal string CadastrarMailing(mailing Mailing, int iIDUsuario)
        {
            string sSql = " insert into tMailing ";
            sSql += " (Mailing, IDUsuario, IDCampanha, Ativo) ";
            sSql += " values ";
            sSql += " ('" + Mailing.Mailing + "', " + iIDUsuario + ", " + Mailing.IDCampanha + ", " + Mailing.Ativo + ") ";
            return sSql;
        }

        internal string RetornarMailings_DataCadastro()
        {
            string sSql = " select IDMailing, Mailing ";
            sSql += " from tMailing ";
            sSql += " where Ativo = 1 ";
            sSql += " order by DataCadastro desc ";
            return sSql;
        }

        internal string RetornarMailing(int iIDMailing)
        {
            string sSql = " select * ";
            sSql += " from tMailing ";
            sSql += " where IDMailing = "+iIDMailing+" ";
            return sSql;
        }

        internal string RetornarMailingsAtivos(int iIDCampanha, int iAtivo)
        {
            string sSql = " select IDMailing, Mailing ";
            sSql += " from tMailing ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";

            if (iAtivo != 2)
            {
                if (iAtivo == 1)
                    sSql += " and Ativo = 0 ";
                else
                    sSql += " and Ativo = 1 ";
            }

            sSql += " order by DataCadastro desc ";
            return sSql;
        }

        internal string RetornarMailings(int iIDCampanha)
        {
            string sSql = " select IDMailing, Mailing ";
            sSql += " from tMailing ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";
            sSql += " order by DataCadastro desc ";
            return sSql;
        }

        internal string EditarMailing(mailing Mailing)
        {
            string sSql = " update tMailing ";
            sSql += " set Ativo = " + Mailing.Ativo + " ";
            sSql += " where IDMailing = " + Mailing.IDMailing + " ";

            return sSql;
        }

        internal string VerificarExistenciaMailing(string sMailing)
        {
            string sSql = " select IDMailing ";
            sSql += " from tMailing ";
            sSql += " where Mailing = '" + sMailing + "' ";

            return sSql;
        }

        internal string RetornarMailingIndicacaoOperador(int iIDCampanha)
        {
            string sSql = " if exists (select * from tCampanha where IDCampanha = " + iIDCampanha + " and IDMailingIndicacao is not null) ";
            sSql += "   select IDMailingIndicacao from tCampanha where IDCampanha = " + iIDCampanha + " and IDMailingIndicacao is not null ";
            sSql += " else ";
            sSql += "   select max(IDMailing) from tMailing where IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string SalvarMailingIndicacao(int iIDCampanha, int iIDMailingIndicacao)
        {
            string sSql = " update tCampanha ";

            if (iIDMailingIndicacao == -1)
                sSql += " set IDMailingIndicacao = null ";
            else
                sSql += " set IDMailingIndicacao = " + iIDMailingIndicacao + " ";

            sSql += " where IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string RetornarMailingIndicacaoSupervisor(int iIDCampanha)
        {
            string sSql = " select IDMailingIndicacao ";
            sSql += " from tCampanha ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string AtualizarProspectVonix(int iIDProspect, int iIDStatusVonix)
        {
            string sSql = " exec AtualizarProspectVonix ";
            sSql += " @IDProspect = " + iIDProspect + ", ";
            sSql += " @IDStatusVonix = " + iIDStatusVonix + " ";

            return sSql;
        }

        internal string RetornarMailings(int iIDCampanha, bool bSomentesAtivos)
        {
            string sSql = " select IDMailing, ";
            sSql += " case when (Ativo = 1) then Mailing + ' - ATIVO (' + convert(varchar, DataCadastro, 103) + ' ' + convert(varchar, DataCadastro, 108) + ')' ";
            sSql += " ELSE Mailing + ' - INATIVO (' + convert(varchar, DataCadastro, 103) + ' ' + convert(varchar, DataCadastro, 108) + ')' end Mailing ";

            sSql += " from tMailing ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";

            if (!bSomentesAtivos)
                sSql += " and Ativo = 1 ";

            sSql += " order by DataCadastro desc ";

            return sSql;
        }

        //CallFlex 
        internal string GerarMailingCallFlex(int iIDCampanha, int iIDMailing)
        {
            string sSql = " exec sGerarMailingIntegracao ";
            sSql += " @IDCampanha = " + iIDCampanha + ", ";
            sSql += " @IDMailing = " + iIDMailing + " ";

            return sSql;
        }

        internal string RetornarMailingsIndicacao()
        {
            string sSql = " select c.Campanha,  ";
            sSql += " case when (m.Mailing is null) then '-' else m.Mailing end Mailing  ";
            sSql += " from tCampanha c ";
            sSql += " left join tMailing m on c.IDMailingIndicacao = m.IDMailing  ";

            return sSql;
        }

        internal string RetornarMailingsInativos(string sIDCampanhas, bool bSomentesAtivos)//r
        {
            string sSql = " select IDMailing, ";
            sSql += " case when (Ativo = 1) then Mailing ELSE Mailing   + '' end Mailing  ";
            sSql += " from tMailing ";
            sSql += " where IDCampanha in (" + sIDCampanhas + ") ";

            if (!bSomentesAtivos)
                sSql += " and Ativo = 1 ";

            sSql += " order by DataCadastro desc ";

            return sSql;
        }

        internal string RetornarMailings(string sIDCampanhas)
        {
            string sSql = " select IDMailing, ";
            sSql += " case when (Ativo = 1) then Mailing";
            sSql += " ELSE Mailing + ' - INATIVO (' + convert(varchar, DataCadastro, 103) + ' ' + convert(varchar, DataCadastro, 108) + ')' end Mailing ";
            sSql += " from tMailing ";
            sSql += " where IDCampanha in (" + sIDCampanhas + ") ";
            sSql += " and Ativo = 1 ";
            sSql += " order by DataCadastro desc ";

            return sSql;
        }

        internal string RetornarIDMailing(string sMailing)//r
        {
            string sSql = " select IDMailing ";
            sSql += " from tMailing ";
            sSql += " where Mailing  = '" + sMailing + "' ";

            return sSql;
        }

        internal string RetornarTodosMailingsAtivos(string sIDCampanhas, int iAtivo)
        {
            string sSql = " select IDMailing, Mailing ";
            sSql += " from tMailing ";
            sSql += " where IDCampanha in (" + sIDCampanhas + ") ";

            if (iAtivo != 2)
            {
                if (iAtivo == 1)
                    sSql += " and Ativo = 1 ";
                else
                    sSql += " and Ativo = 0 ";
            }

            sSql += " order by DataCadastro desc ";
            return sSql;
        }
    }
}
