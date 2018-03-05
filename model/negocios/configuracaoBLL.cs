using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using model.dados;
using model.objetos;
using System.Windows.Forms;

namespace model.negocios
{
    public class configuracaoBLL
    {
        public static configuracao Configuracao;

        public void CarregarStringConexao()
        {
            string sConexao = string.Empty;
            string sChave1 = "Conexao=";

            StreamReader StreamReader = new StreamReader("conexao.ini");
            while (true)
            {
                string sLinha = StreamReader.ReadLine();
                if (sLinha == null) break;
                sConexao = PontoBr.Seguranca.Criptografia.Descriptografar(sLinha.Substring(sChave1.Length), PontoBr.Seguranca.Criptografia.sChaveComum);
                Console.WriteLine(sLinha);
            }
            StreamReader.Close();
            PontoBr.Banco.SqlServer.sConexao = sConexao;
        }

        public DataTable RetornarCamposCampanha(int iIDCampanha)
        {
            configuracaoDAL DConfiguracao = new configuracaoDAL();
            string sSql = DConfiguracao.RetornarCamposCampanha(iIDCampanha);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
            return dataTable;
        }

        public configuracao RetornarConfiguracoes()
        {
            configuracaoDAL DConfiguracao = new configuracaoDAL();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(DConfiguracao.RetornarConfiguracoes());

            configuracao Configuracao = new configuracao(null, null, null, null, null, null, null, false, null);
            Configuracao.VersaoDiscador = dataTable.Rows[0]["VersaoDiscador"].ToString();
            Configuracao.TipoPabx = dataTable.Rows[0]["TipoPabx"].ToString();
            Configuracao.Script = Convert.ToInt32(dataTable.Rows[0]["Script"]);
            Configuracao.IPServidor = dataTable.Rows[0]["IPServidor"].ToString();
            Configuracao.PortaServidor = dataTable.Rows[0]["PortaServidor"].ToString();
            Configuracao.Cliente = dataTable.Rows[0]["Cliente"].ToString();

            try
            {
                Configuracao.Licenca = Convert.ToInt32(PontoBr.Seguranca.Criptografia.Descriptografar(dataTable.Rows[0]["Licenca"].ToString(), PontoBr.Seguranca.Criptografia.sChaveComum));
            }
            catch
            {
                MessageBox.Show("A licença do Tabulare não é válida, favor entrar em contato com o suporte.", "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            
            return Configuracao;
        }

        public int VerificarRamalDNS(string sDNS)
        {
            configuracaoDAL DConfiguracao = new configuracaoDAL();
            string sSql = DConfiguracao.VerificarRamalDNS(sDNS);

            string sRamal = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);
            return Convert.ToInt32(sRamal == "" ? "0" : sRamal);
        }

        public void CadastrarRamalDNS(int iRamal, string sDNS, string sAgent)
        {
            configuracaoDAL DConfiguracao = new configuracaoDAL();
            string sSql = DConfiguracao.CadastrarRamalDNS(iRamal, sDNS, sAgent);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void CadastrarDadosSocket(string sIP, int iPort)
        {
            configuracaoDAL DConfiguracao = new configuracaoDAL();
            string sSql = DConfiguracao.CadastrarDadosSocket(sIP, iPort);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarDadosSocket()
        {
            configuracaoDAL DConfiguracao = new configuracaoDAL();
            string sSql = DConfiguracao.RetornarDadosSocket();

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
            return dataTable;
        }
    }
}
