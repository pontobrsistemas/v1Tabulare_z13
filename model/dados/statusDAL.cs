using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;

namespace model.dados
{
    public class statusDAL
    {
        internal string RetornarStatusAtendimento(int iIDCampanha, int iScript)
        {
            string sSql = " select a.IDStatus, upper(a.Status) Status, b.Acao, a.QtdeTentativas, ";
            sSql += " convert(varchar, a.TempoRetorno, 108) TempoRetorno ";
            sSql += " from tStatus a ";
            sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            sSql += " inner join tCampanha_Status c on a.IDStatus = c.IDStatus ";
            sSql += " where a.Ativo = 1 ";

            if (iScript == 0)
                sSql += " and a.IDStatus not in (-1,-3,-4) /*Virgem, Resubmit, Contato com Sucesso*/ ";
            else
                //sSql += " and a.IDStatus in (-4,-2,8,12,9,10,7,5)";
                sSql += " and a.IDStatus not in (-1,-3,-4) /*Virgem, Resubmit, Contato com Sucesso*/ ";

            sSql += " and c.IDCampanha = "+iIDCampanha+" ";
            sSql += " order by a.Status ";
            return sSql;
        }

        internal string RetornarDropStatusAtendimento(int iIDCampanha, int iScript)
        {
            string sSql = " select a.IDStatus, upper(a.Status) Status, b.Acao, a.QtdeTentativas, ";
            sSql += " convert(varchar, a.TempoRetorno, 108) TempoRetorno ";
            sSql += " from tStatus a ";
            sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            sSql += " inner join tCampanha_Status c on a.IDStatus = c.IDStatus ";
            sSql += " where a.Ativo = 1 ";

            if (iScript == 0)
                sSql += " and a.IDStatus not in (-1,-3,-4) /*Virgem, Resubmit, Contato com Sucesso*/ ";
            else
                //sSql += " and a.IDStatus in (-4,-2,8,12,9,10,7,5)";
                sSql += " and a.IDStatus not in (-1,-3,-4) /*Virgem, Resubmit, Contato com Sucesso*/ ";

            sSql += " and c.IDCampanha = " + iIDCampanha + " ";
            sSql += " order by a.Status ";
            return sSql;
        }

        internal string RetornarStatusResubmit(int iIDCampanha)
        {
            //string sSql = " select a.IDStatus, upper(a.Status) Status, b.Acao, a.QtdeTentativas, ";
            //sSql += " convert(varchar, a.TempoRetorno, 108) TempoRetorno ";
            //sSql += " from tStatus a ";
            //sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            //sSql += " inner join tCampanha_Status c on a.IDStatus = c.IDStatus ";
            //sSql += " where a.Ativo = 1 ";
            //sSql += " and a.PermiteResubmit = 1 ";
            //sSql += " and c.IDCampanha = " + iIDCampanha + " ";
            //sSql += " order by a.Status ";
            //return sSql;

            string sSql = " select (Convert (varchar ,a.IDStatus)+' - '+Convert(varchar,a.Status))STATUS , upper(a.Status) Status, b.Acao, a.QtdeTentativas, ";
            sSql += " convert(varchar, a.TempoRetorno, 108) TempoRetorno ";
            sSql += " from tStatus a ";
            sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            sSql += " inner join tCampanha_Status c on a.IDStatus = c.IDStatus ";
            sSql += " where a.Ativo = 1 ";
            sSql += " and a.PermiteResubmit = 1 ";
            sSql += " and c.IDCampanha = " + iIDCampanha + " ";
            sSql += " order by a.IDStatus ";
            return sSql;
        }

        internal string RetornarStatusCadastro(int iIDCampanha)
        {
            string sSql = " select a.IDStatus [Cód. Status], upper(a.Status) Status, b.Acao, a.QtdeTentativas [Qtde Tent.], ";
            sSql += " convert(varchar, a.TempoRetorno, 108) [Tempo Retorno], ";
            sSql += " case when a.Ativo = 1 then 'Sim' else 'Não' end Ativo ";
            sSql += " from tStatus a ";
            sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            sSql += " inner join tCampanha_Status c on a.IDStatus = c.IDStatus ";
            //sSql += " where a.IDStatus not in (-1, -2, -3, -4) ";
            sSql += " where a.IDStatus not in (-1, -3, -4) ";//Se colocar '-2' não aparece no status o 'Agendamento da ligação'
            //sSql += " and a.PermiteEditar = 1 "; //Mesma coisa acima, essa abilitada não exibe 'Agendamento da ligação' (Alteração realizada por Robson/Paulo)
            sSql += " and c.IDCampanha = "+iIDCampanha+" ";
            sSql += " order by a.Status ";
            return sSql;
        }

        internal string AlteraStatus(status Status)
        {
            string sSql = "update tStatus ";
            sSql += " set QtdeTentativas = "+Status.QtdeTentativas+", ";
            sSql += " TempoRetorno = '" +Status.TempoRetorno+ "', ";
            sSql += " Ativo = " +Status.Ativo+ " ";
            sSql += " where IDStatus = " +Status.IDStatus+ " ";

            return sSql;
        }

        internal string RetornarStatusRelatorio(int iIDCampanha)
        {
            string sSql = " select a.IDStatus, a.Status ";
            sSql += " from tStatus a ";
            sSql += " inner join tCampanha_Status b on a.IDStatus = b.IDStatus ";
            sSql += " where a.IDStatus not in (-1) ";
            sSql += " and b.IDCampanha = "+iIDCampanha+" ";
            return sSql;
        }


        internal string RetornarStatus(int iIDStatus)
        {
            string sSql = " select a.*, b.Acao, convert(varchar(5), a.TempoRetorno, 108) [Tempo Retorno] ";
            sSql += " from tStatus a ";
            sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            sSql += " where IDStatus = "+iIDStatus+" ";
            return sSql;
        }

        internal string RetornarDescricaoStatusRelatorio(int iIDCampanha)
        {
            string sSql = " select distinct (Convert (varchar ,s.IDStatus)+' - '+Convert(varchar,s.Status))STATUS  ";
            sSql += " from tStatus s";
            sSql += " inner join tCampanha_Status cs on s.IDStatus = cs.IDStatus ";
            sSql += " where cs.IDStatus not in (-1) and cs.IDCampanha = " + iIDCampanha + " ";
            return sSql;
        }

        //Retornar Status de Avaliação de qualidade quando não é Venda
        internal string RetornarStatusAvaliacaoQualidade(int iIDCampanha, int iVenda)
        {
            string sSql = " select a.IDStatus, (Convert (varchar ,a.IDStatus)+' - '+Convert(varchar,a.Status))STATUS  ";
            //sSql += " convert(varchar, a.TempoRetorno, 108) TempoRetorno ";
            sSql += " from tStatus a ";
            //sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            sSql += " inner join tCampanha_Status c on a.IDStatus = c.IDStatus ";
            sSql += " where a.Ativo = 1 ";
            sSql += " and a.Venda = " + iVenda + " ";
            sSql += " and a.IDStatus not in (-3, -1) ";
            sSql += " and c.IDCampanha = " + iIDCampanha + " ";
            sSql += " order by a.Status ";
            return sSql;
        }

        internal string RetornarStatusResubmitCallflex(int iIDCampanha)
        {
             string sSql = " select (Convert (varchar ,a.IDStatus)+' - '+Convert(varchar,a.Status))STATUS , upper(a.Status) Status, b.Acao, a.QtdeTentativas, ";
            sSql += " convert(varchar, a.TempoRetorno, 108) TempoRetorno ";
            sSql += " from tStatus a ";
            sSql += " inner join tAcao b on a.IDAcao = b.IDAcao ";
            //sSql += " inner join tCampanha_Status c on a.IDStatus = c.IDStatus ";
            sSql += " where a.PermiteResubmit = 1 ";
            //sSql += " and c.IDCampanha = " + iIDCampanha + " ";
            sSql += " order by a.IDStatus ";
            return sSql;
        }

        internal string RetornarStatusVonix()
        {
            string sSql = " select * from tStatusVonix ";
            return sSql;
        }

        internal string RetornarDescricaoStatusRelatorio(string sIDCampanha)//r
        {
            string sSql = " select distinct (Convert (varchar ,s.IDStatus)+' - '+Convert(varchar,s.Status))STATUS  ";
            sSql += " from tStatus s";
            sSql += " inner join tCampanha_Status cs on s.IDStatus = cs.IDStatus ";
            sSql += " where cs.IDStatus not in (-1) and cs.IDCampanha in (" + sIDCampanha + ") ";
            return sSql;
        }
    }
}
