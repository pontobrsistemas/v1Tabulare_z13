using System;
using System.Collections.Generic;
using System.Text;

namespace model.dados
{
    public class scriptDAL
    {
        internal string RetornarPrimeiraPergunta(int iIDCampanha)
        {
            string sSql = " select top 1 a.IDPergunta, Pergunta, a.Informacao ";
            sSql += " from tPergunta a ";
            sSql += " where a.IDCampanha = " + iIDCampanha + " ";
            sSql += " and Ativo = 1  ";
            sSql += " order by a.Ordem ";

            return sSql;
        }

        internal string RetornarRespostas(int iIDPergunta)
        {
            string sSql = " select a.IDResposta, a.Resposta, a.IDPergunta, ";
            sSql += " a.IDProximaPergunta, b.Pergunta, a.Venda ";
            sSql += " from tResposta a ";
            sSql += " inner join tPergunta b on a.IDPergunta = b.IDPergunta ";
            sSql += " where a.IDPergunta = "+iIDPergunta+" ";
            sSql += " and a.Ativo = 1 ";
            sSql += " order by Resposta ";

            return sSql;
        }

        internal string RetornarProximaPergunta(int iIDPergunta)
        {
            string sSql = " select top 1 a.IDPergunta, Pergunta, a.Informacao ";
            sSql += " from tPergunta a ";
            sSql += " where a.IDPergunta = " + iIDPergunta + " ";
            sSql += " and Ativo = 1  ";

            return sSql;
        }

        internal string RetornarPerguntas(int iIDCampanha)
        {
            string sSql = " select IDPergunta, Pergunta ";
            sSql += " from tPergunta ";
            sSql += " where IDCampanha = "+iIDCampanha+" ";
            sSql += " and Ativo = 1 ";
            sSql += " order by Ordem ";

            return sSql;
        }

        internal string RetornarAgendamentosPendentes()
        {
            string sSql = " select c.IDHistorico [Cód. Histórico], ";
            sSql += " d.Telefone1 [Telefone 1], d.Nome, d.NumeroFAC [Número FAC], ";
            sSql += " e.Nome as [Operador], c.DataCadastro [Data Contato], b.Resposta "; 
            sSql += " from tResposta_Prospect a ";
            sSql += " inner join tResposta b on a.IDResposta = b.IDResposta ";
            sSql += " inner join tHistorico c on a.IDHistorico = c.IDHistorico ";
            sSql += " inner join tProspect d on c.IDProspect = d.IDProspect ";
            sSql += " inner join tUsuario e on c.IDUsuario = e.IDUsuario ";
            sSql += " where a.IDPergunta in (25,46) and b.Resposta = 'Pendente' ";
            sSql += " order by c.DataCadastro ";

            return sSql;
        }

        internal string RetornarAgendamentos()
        {

            string sSql = " select b.IDHistorico [Cód. Histórico], ";
            sSql += " c.Telefone1 [Telefone 1], c.Nome, c.NumeroFAC [Número FAC], ";
            sSql += " f.Nome [Operador],b.DataCadastro [Data Contato], ";
            sSql += " e.Resposta [Status FAC] ";
            sSql += " from tResposta_Prospect a ";
            sSql += " inner join tHistorico b on a.IDHistorico = b.IDHistorico ";
            sSql += " inner join tProspect c on b.IDProspect = c.IDProspect ";
            sSql += " inner join tPergunta d on a.IDPergunta = d.IDPergunta ";
            sSql += " inner join tResposta e on a.IDResposta = e.IDResposta ";
            sSql += " inner join tUsuario f on b.IDUsuario = f.IDUsuario ";
            sSql += " where a.IDPergunta in (25,46) ";
            sSql += " order by b.DataCadastro ";


            return sSql;
        }

        // Este Item ainda não esta em operação 03/03/2010 - Paulo César Dias da Silva
        internal string RetornarPesquisaAgendamentos(string sNome)
        {
            string sSql = " select c.IDHistorico [Cód. Histórico], d.Telefone1 [Telefone 1], d.Nome, d.NumeroFAC [Número FAC], ";
            sSql += " e.Nome as [Operador], c.DataCadastro [Data Contato], b.Resposta ";
            sSql += " from tResposta_Prospect a ";
            sSql += " inner join tResposta b on a.IDResposta = b.IDResposta ";
            sSql += " inner join tHistorico c on a.IDHistorico = c.IDHistorico ";
            sSql += " inner join tProspect d on c.IDProspect = d.IDProspect ";
            sSql += " inner join tUsuario e on c.IDUsuario = e.IDUsuario ";
            sSql += " where a.IDPergunta in (25,46) and d.Nome like '%" + sNome + "%' ";
            sSql += " order by c.DataCadastro ";

            return sSql;
        }

        internal string RetornarRespostasPendentes(string sIDsRespostas)
        {
            string sSql = " select IDResposta, Resposta ";
            sSql += " from tResposta ";
            sSql += " where IDResposta in ("+sIDsRespostas+") ";

            return sSql;
        }

        internal string EditarRespostaProspect(int iIDHistorico, int iIDPergunta, int iIDResposta)
        {
            string sSql = " update tResposta_Prospect ";
            sSql += " set IDResposta = "+iIDResposta+" ";
            sSql += " where IDHistorico = "+iIDHistorico+" ";
            sSql += " and IDPergunta in ("+iIDPergunta+") ";

            return sSql;
        }

        internal string RetornarIDResposta(string sResposta)
        {
            string sSql = " select IDResposta, Resposta ";
            sSql += " from tResposta ";
            sSql += " where Resposta = '" + sResposta + "' ";

            return sSql;
        }

        // Este Item ainda não esta em operação 03/03/2010 - Paulo César Dias da Silva
        internal string HabilitarDesabilitarScriptsPerguntas(int iAtivo, int IDCampanha)
        {

            string sSql = " update dbo.tPergunta  ";
            sSql += " set Ativo = "+iAtivo+"  ";
            sSql += " where IDCampanha = "+IDCampanha+"  ";
            
            return sSql;
        }

        // Este Item ainda não esta em operação 03/03/2010 - Paulo César Dias da Silva
        internal string HabilitarDesabilitarScriptsRespostas(int iAtivo, int IDCampanha)
        {

            string sSql = " UPDATE dbo.tResposta  ";
            sSql += " set Ativo = " + iAtivo + "  ";
            sSql += " where IDPergunta in (select IDPergunta from dbo.tPergunta where IDCampanha = " + IDCampanha + ") ";
            
            return sSql;
        }        
    }
}
