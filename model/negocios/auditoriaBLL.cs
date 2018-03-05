using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.dados;
using System.Windows.Forms;
using model.objetos;

namespace model.negocios
{
    public class auditoriaBLL
    {
        public string RetornarStatusAuditoria(bool bSomenteAtivo)
        {
            auditoriaDAL DAuditoria = new auditoriaDAL();
            return DAuditoria.RetornarStatusAuditoria(bSomenteAtivo);
        }        

        public int RetornarIDAuditoria(string sAuditoria)
        {
            auditoriaDAL DAuditoria = new auditoriaDAL();
            string sSql = DAuditoria.RetornarIDAuditoria(sAuditoria);

            string sIDAuditoria = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            if (sIDAuditoria == "")
                return 0;
            else
                return Convert.ToInt32(sIDAuditoria);
        }

        public status RetornarStatusAuditoria(int iIDStatus)
        {
            auditoriaDAL DAuditoria = new auditoriaDAL();
            string sSql = DAuditoria.RetornarStatusAuditoria(iIDStatus);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            status Status = new status();
            if (dataTable.Rows.Count > 0)
            {
                Status.IDStatus = Convert.ToInt32(dataTable.Rows[0]["IDStatus"].ToString());
                Status.Status = dataTable.Rows[0]["Status"].ToString();
                Status.Ativo = Convert.ToInt32(dataTable.Rows[0]["Ativo"]);
            }

            return Status;
        }

        public void AtualizarStatusAuditoria(int iIDStatus, int iTempoExpiracao, int iAtivo)
        {
            auditoriaDAL DAuditoria = new auditoriaDAL();
            string sSql = DAuditoria.AtualizarStatusAuditoria(iIDStatus, iTempoExpiracao, iAtivo);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataSet RetornarQuantidadeVendasExpiradas()
        {
            auditoriaDAL DAuditoria = new auditoriaDAL();
            string sSql = DAuditoria.RetornarQuantidadeVendasExpiradas();
            DataSet dataSet = PontoBr.Banco.SqlServer.RetornarDataSet(sSql);

            return dataSet;
        }
    }
}
