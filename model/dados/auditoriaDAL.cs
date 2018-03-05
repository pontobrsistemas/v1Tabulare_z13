using System;
using System.Collections.Generic;
using System.Text;

namespace model.dados
{
    public class auditoriaDAL
    {
        internal string RetornarStatusAuditoria(bool bSomenteAtivo)
        {
            string sSql = " select IDStatus [Cód.], Status [Status da Auditoria], TempoExpiracao [Tempo de Expiração (Horas)], ";
            sSql += " case when (Ativo = 1) then 'Sim' else 'Não' end Ativo, IDStatus  ";
            sSql += " from tStatusAuditoria ";

            if (bSomenteAtivo)
                sSql += " where Ativo = 1 ";

            sSql += " order by Status ";

            return sSql;
        }
        
        internal string RetornarIDAuditoria(string sAuditoria)
        {
            string sSql = " select IDStatus ";
            sSql += " from tStatusAuditoria ";
            sSql += " where Status = '" + sAuditoria +  "' and Ativo = 1 ";

            return sSql;
        }

        internal string RetornarStatusAuditoria(int iIDStatus)
        {
            string sSql = " select * ";
            sSql += " from tStatusAuditoria ";
            sSql += " where IDStatus = "+iIDStatus+" ";

            return sSql;
        }

        internal string AtualizarStatusAuditoria(int iIDStatus, int iTempoExpiracao, int iAtivo)
        {
            string sSql = " update tStatusAuditoria ";
            sSql += " set TempoExpiracao = "+iTempoExpiracao+", ";
            sSql += " Ativo = "+iAtivo+" ";
            sSql += " where IDStatus = "+iIDStatus+" ";

            return sSql;
        }

        internal string RetornarQuantidadeVendasExpiradas()
        {
            string sSql = " select count(*) VendasExpiradas ";
            sSql += " from tHistorico h  ";
            sSql += " left join tVenda v on h.IDHistorico = v.IDHistorico  ";
            sSql += " left join tStatusAuditoria sa on sa.IDStatus = v.IDStatus  ";
            sSql += " where h.IDStatus in (select IDStatus from tStatus where Venda = 1) ";
            sSql += " and (dateadd(hour, convert(decimal, sa.TempoExpiracao) * 1, h.DataCadastro) < getdate())  ";

            sSql += " and sa.TempoExpiracao > 0 ";

            sSql += " select count(*) VendasExpirando ";
            sSql += " from tHistorico h  ";
            sSql += " left join tVenda v on h.IDHistorico = v.IDHistorico  ";
            sSql += " left join tStatusAuditoria sa on sa.IDStatus = v.IDStatus  ";
            sSql += " where h.IDStatus in (select IDStatus from tStatus where Venda = 1) ";
            sSql += " and (dateadd(hour, convert(decimal, sa.TempoExpiracao) * 1, h.DataCadastro) >= getdate())  ";
            sSql += " and (dateadd(hour, convert(decimal, sa.TempoExpiracao) * 0.8, h.DataCadastro) <= getdate())  ";
            sSql += " and sa.TempoExpiracao > 0 ";

            return sSql;
        }
    }
}
