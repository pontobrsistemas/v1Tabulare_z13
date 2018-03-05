using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.dados;
using System.Windows.Forms;

namespace model.negocios
{
    public class scriptBLL
    {
        public DataTable RetornarPrimeiraPergunta(int iIDCampanha)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarPrimeiraPergunta(iIDCampanha);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarPerguntas(int iIDCampanha)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarPerguntas(iIDCampanha);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarRespostas(int iIDPergunta)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarRespostas(iIDPergunta);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        //public string RetornarRespostaVenda(int iIDPergunta)
        //{
        //    scriptDAL DScript = new scriptDAL();
        //    string sSql = DScript.RetornarRespostaVenda(iIDPergunta);

        //    return sSql;
        //}

        public DataTable RetornarProximaPergunta(int iIDPergunta)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarProximaPergunta(iIDPergunta);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarAgendamentosPendentes()
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarAgendamentosPendentes();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarAgendamentos()
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarAgendamentos();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarPesquisaAgendamentos(string sNome)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarPesquisaAgendamentos(sNome);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public DataTable RetornarRespostasPendentes(string sIDsRespostas)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarRespostasPendentes(sIDsRespostas);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public void EditarRespostaProspect(int iIDHistorico, int iIDPergunta, int iIDResposta)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.EditarRespostaProspect(iIDHistorico, iIDPergunta, iIDResposta);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public int RetornarIDResposta(string sResposta)
        {
            scriptDAL DScript = new scriptDAL();
            string sSql = DScript.RetornarIDResposta(sResposta);

            string sIDResposta = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            if (sIDResposta == "")
                return 0;
            else
                return Convert.ToInt32(sIDResposta);
        }
    }
}
