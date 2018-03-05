using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.dados;
using model.objetos;
using System.Windows.Forms;

namespace model.negocios
{
    public class mailingBLL
    {
        public DataTable RetornarMailings(bool bAtivo, int iIDCampanha)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailings(bAtivo, iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public int CadastrarMailing(mailing Mailing, int iIDUsuario)
        {
            mailingDAL DMailing = new mailingDAL();

            string sSql = DMailing.CadastrarMailing(Mailing, iIDUsuario);
            return Convert.ToInt32(PontoBr.Banco.SqlServer.ExecutarSqlComRetornoDeIdentity(sSql));
        }

        public mailing RetornarMailing(int iIDMailing)
        {
            mailingDAL DMailing = new mailingDAL();
            mailing Mailing = new mailing();

            string sSql = DMailing.RetornarMailing(iIDMailing);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            if (dataTable.Rows.Count > 0)
            {
                Mailing.IDMailing = Convert.ToInt32(dataTable.Rows[0]["IDMailing"].ToString());
                Mailing.Mailing = dataTable.Rows[0]["Mailing"].ToString();
                Mailing.IDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
                Mailing.Ativo = Convert.ToInt32(dataTable.Rows[0]["Ativo"]);
            }

            return Mailing;
        }

        public DataTable RetornarMailings_DataCadastro()
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailings_DataCadastro();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarMailingsAtivos(int iIDCampanhas, int iAtivo)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailingsAtivos(iIDCampanhas, iAtivo);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarMailings(int iIDCampanha)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailings(iIDCampanha);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public void EditarMailing(mailing Mailing)
        {
            mailingDAL DMailing = new mailingDAL();

            string sSql = DMailing.EditarMailing(Mailing);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public bool VerificarExistenciaMailing(string sMailing)
        {
            mailingDAL DMailing = new mailingDAL();

            string sSql = DMailing.VerificarExistenciaMailing(sMailing);
            return PontoBr.Banco.SqlServer.VerificarExistenciaDeDados(sSql);
        }

        public int RetornarMailingIndicacaoOperador(int iIDCampanha)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailingIndicacaoOperador(iIDCampanha);
            string sIDMailing = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            return Convert.ToInt32(sIDMailing == "" ? "0" : sIDMailing);
        }

        public void SalvarMailingIndicacao(int iIDCampanha, int iIDMailingIndicacao)
        {
            mailingDAL DMailing = new mailingDAL();

            string sSql = DMailing.SalvarMailingIndicacao(iIDCampanha, iIDMailingIndicacao);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public int RetornarMailingIndicacaoSupervisor(int iIDCampanha)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailingIndicacaoSupervisor(iIDCampanha);
            string sIDMailing = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            return Convert.ToInt32(sIDMailing == "" ? "0" : sIDMailing);
        }

        public void AtualizarProspectVonix(int iIDProspect, int iIDStatusVonix)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.AtualizarProspectVonix(iIDProspect, iIDStatusVonix);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarMailings(int iIDCampanha, bool bSomentesAtivos)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailings(iIDCampanha, bSomentesAtivos);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public void GerarMailingCallFlex(int iIDCampanha, int iIDMailing)//CallFlex
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.GerarMailingCallFlex(iIDCampanha, iIDMailing);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql, 60 * 10);//Timeout para 5minutos
        }

        public DataTable RetornarMailingsIndicacao()
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailingsIndicacao();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarMailingsInativos(string sIDCampanhas, bool bSomentesAtivos)//r
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailingsInativos(sIDCampanhas, bSomentesAtivos);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarMailings(string sIDCampanhas)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarMailings(sIDCampanhas);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public int RetornarIDMailing(string sMailing)//r
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarIDMailing(sMailing);

            string sIDMailing = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            if (sIDMailing == "")
                return 0;
            else
                return Convert.ToInt32(sIDMailing);
        }

        public DataTable RetornarTodosMailingsAtivos(string sIDCampanha, int iAtivo)
        {
            mailingDAL DMailing = new mailingDAL();
            string sSql = DMailing.RetornarTodosMailingsAtivos(sIDCampanha, iAtivo);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }
        
    }
}
