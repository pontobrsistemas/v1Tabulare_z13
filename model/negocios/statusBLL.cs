using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.dados;
using System.Windows.Forms;
using model.objetos;

namespace model.negocios
{
    public class statusBLL
    {
        public DataTable RetornarStatusCadastro(int iIDCampanha)
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarStatusCadastro(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarStatusAtendimento(int iIDCampanha, int iScript)
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarStatusAtendimento(iIDCampanha, iScript);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public string RetornarDropStatusAtendimento(int iIDCampanha, int iScript)//r
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarDropStatusAtendimento(iIDCampanha, iScript);
            //DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return sSql;
        }

        public DataTable RetornarStatusResubmit(int iIDCampanha)
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarStatusResubmit(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string AlteraStatus(status Status)
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.AlteraStatus(Status);

            return sSql;
        }

        public string RetornarStatusRelatorio(int iIDCampanha)
        {
            statusDAL DStatus = new statusDAL();
            return DStatus.RetornarStatusRelatorio(iIDCampanha);
        }

        public status RetornarStatus(int iIDStatus)
        {
            status Status = new status();

            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarStatus(iIDStatus);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            if (dataTable.Rows.Count > 0)
            {
                Status.IDStatus = Convert.ToInt32(dataTable.Rows[0]["IDStatus"].ToString());
                Status.IDAcao = Convert.ToInt32(dataTable.Rows[0]["IDAcao"].ToString());
                Status.Venda = Convert.ToInt32(dataTable.Rows[0]["Venda"]);
                Status.Status = dataTable.Rows[0]["Status"].ToString();
                Status.Acao = dataTable.Rows[0]["Acao"].ToString();

                Status.TempoRetorno = dataTable.Rows[0]["Tempo Retorno"].ToString();
                Status.Ativo = Convert.ToInt32(dataTable.Rows[0]["Ativo"]);
                Status.QtdeTentativas = Convert.ToInt32(dataTable.Rows[0]["QtdeTentativas"].ToString());
            }

            return Status;
        }

        public string RetornarDescricaoStatusRelatorio(int iIDCampanha)
        {
            statusDAL DStatus = new statusDAL();
            return DStatus.RetornarDescricaoStatusRelatorio(iIDCampanha);
        }

        public DataTable RetornarStatusResubmitCallflex(int iIDCampanha)
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarStatusResubmitCallflex(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarStatusVonix()
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarStatusVonix();
            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarGridViewStatusCadastro(int iIDCampanha)//r
        {
            statusDAL DStatus = new statusDAL();
            string sSql = DStatus.RetornarStatusCadastro(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string RetornarDescricaoStatusRelatorio(string sIDCampanha)
        {
            statusDAL DStatus = new statusDAL();
            return DStatus.RetornarDescricaoStatusRelatorio(sIDCampanha);
        }
    }
}
