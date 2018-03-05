using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using model.objetos;
using model.dados;
using System.Web;

namespace model.negocios
{
    public class usuarioBLL
    {
        public static usuario Usuario;

        public int RetornarUsuario(string sLogin, string sSenha, int iAtivo)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarUsuario(sLogin, sSenha, iAtivo);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            if (dataTable.Rows.Count > 0)
                return Convert.ToInt32(dataTable.Rows[0]["IDUsuario"].ToString());
            else
                return 0;
        }

        public usuario RetornarUsuario(string sLogin, string sSenha, string sRamal)
        {
            usuarioDAL DUusario = new usuarioDAL();
            string sSql = DUusario.RetornarUsuario(sLogin, sSenha, 1);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            usuario Usuario = new usuario();
            if (dataTable.Rows.Count > 0)
            {
                Usuario.IDUsuario = Convert.ToInt32(dataTable.Rows[0]["IDUsuario"].ToString());
                Usuario.Nome = dataTable.Rows[0]["Nome"].ToString();
                Usuario.Login = dataTable.Rows[0]["Login"].ToString();
                Usuario.Senha = dataTable.Rows[0]["Senha"].ToString();
                Usuario.IDPerfil = Convert.ToInt32(dataTable.Rows[0]["IDPerfil"].ToString());
                Usuario.Perfil = dataTable.Rows[0]["Perfil"].ToString();
                Usuario.TipoDiscador = dataTable.Rows[0]["TipoDiscador"].ToString();
                Usuario.Fila = dataTable.Rows[0]["Fila"].ToString();
                Usuario.IDCampanha = dataTable.Rows[0]["IDCampanha"].ToString() == "" ? 0 : Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());//r
                Usuario.Ramal = sRamal;
                Usuario.DNS = System.Net.Dns.GetHostName();
            }
            
            return Usuario;
        }

        public DataTable RetornarUsuarios(bool bSomenteAtivo)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarUsuarios(bSomenteAtivo);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string RetornarSenha(int iIDUsuario)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarSenha(iIDUsuario);

            return PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);
        }

        public void EditarUsuario(usuario Usuario)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.EditarUsuario(Usuario);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void ExcluirUsuarioCampanhas(int iIDUsuario)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.ExcluirUsuarioCampanhas(iIDUsuario);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public string CadastrarUsuario(usuario Usuario, int iIDUsuarioCadastro)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = "";

            //Callflex Mundiale
            if (Usuario.IDPerfil == 2) sSql = DUsuario.CadastrarOperador(Usuario, iIDUsuarioCadastro);
            else if (Usuario.IDPerfil == 1) sSql = DUsuario.CadastrarSupervisor(Usuario, iIDUsuarioCadastro);
            else if (Usuario.IDPerfil == 4) sSql = DUsuario.CadastrarBackOffice(Usuario, iIDUsuarioCadastro);
            else if (Usuario.IDPerfil == 5) sSql = DUsuario.CadastrarAdministrador(Usuario, iIDUsuarioCadastro);

            return PontoBr.Banco.SqlServer.ExecutarSqlComRetornoDeIdentity(sSql);
        }

        public void CadastrarUsuarioCampanhas(int iIDUsuario, string sCampanha)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.CadastrarUsuarioCampanhas(iIDUsuario, sCampanha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void CadastrarUsuarioCampanhas(int iIDUsuario, int iIDCampanha)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.CadastrarUsuarioCampanhas(iIDUsuario, iIDCampanha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarOperadores()
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarOperadores();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public string RetornarDropOperadores()//r
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarDropOperadores();
          
            return sSql;
        }

        public bool ValidarSenhaSupervisor(string sSenha)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarSupervisor(sSenha);

            if (PontoBr.Banco.SqlServer.VerificarExistenciaDeDados(sSql))
                return true;
            else
                return false;
        }
        
        public DataTable RetornarSupervisores()
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarSupervisores();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public int RetornarQuantidadeOperadores()
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarQuantidadeOperadores();

            return Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));
        }

        public bool VerificarSenhaAtual(int iIDUsuario, string sSenha)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.VerificarSenhaAtual(iIDUsuario, sSenha);

            return PontoBr.Banco.SqlServer.VerificarExistenciaDeDados(sSql);
        }

        public void AlterarSenha(int iIDUsuario, string sSenha)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.AlterarSenha(iIDUsuario, sSenha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void AtualizarNroAgente(int iIDUsuario, int iNroAgente)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.AtualizarNroAgente(iIDUsuario, iNroAgente);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarCampanhasUsuario(int iIDUsuario)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarCampanhasUsuario(iIDUsuario);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public usuario RetornarUsuario(int iIDUsuario)
        {
            usuarioDAL DUusario = new usuarioDAL();
            string sSql = DUusario.RetornarUsuario(iIDUsuario);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            usuario Usuario = new usuario();
            if (dataTable.Rows.Count > 0)
            {
                Usuario.IDUsuario = Convert.ToInt32(dataTable.Rows[0]["IDUsuario"].ToString());
                Usuario.Nome = dataTable.Rows[0]["Nome"].ToString();
                Usuario.Login = dataTable.Rows[0]["Login"].ToString();
                Usuario.Senha = dataTable.Rows[0]["Senha"].ToString();
                Usuario.IDPerfil = Convert.ToInt32(dataTable.Rows[0]["IDPerfil"].ToString());
                Usuario.IDCampanha = dataTable.Rows[0]["IDCampanha"].ToString() == "" ? 0 : Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
                Usuario.Perfil = dataTable.Rows[0]["Perfil"].ToString();
                Usuario.DNS = System.Net.Dns.GetHostName();
                Usuario.Ativo = Convert.ToInt32(dataTable.Rows[0]["Ativo"]);
               
                if (dataTable.Rows[0]["Perfil"].ToString() == "Operador")
                {
                    Usuario.PermiteEditarDadosProspect = dataTable.Rows[0]["PermiteEditarDadosProspect"].ToString() == "" ? 0 : Convert.ToInt32(dataTable.Rows[0]["PermiteEditarDadosProspect"]);
                    Usuario.IDCampanha = dataTable.Rows[0]["IDCampanha"].ToString() == "" ? 0 : Convert.ToInt32(dataTable.Rows[0]["IDCampanha"]);
                    Usuario.Campanha = dataTable.Rows[0]["Campanha"].ToString();
                }
                Usuario.TipoDiscador = dataTable.Rows[0]["TipoDiscador"].ToString();
            }

            return Usuario;
        }

        public void PausaAgente(int iIDUsuario, int iPausaAgente)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.PausaAgente(iIDUsuario, iPausaAgente);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void TabulareLogado(int iIDUsuario, int iTabulareLogado)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.TabulareLogado(iIDUsuario, iTabulareLogado);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public int RetornarClientAtivos()
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarClientAtivos();
            return Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));
        }

        public bool RetornarNroAgentesRepetidos(int iIDUsuario, int iNroAgente)//robson
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarNroAgentesRepetidos(iIDUsuario, iNroAgente);
            return PontoBr.Banco.SqlServer.VerificarExistenciaDeDados(sSql);
        }

        public usuario RetornarUsuarioNet(string sEmail, string sSenha)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.RetornarUsuarioNet(sEmail, sSenha);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            usuario Usuario = new usuario();
            if (dataTable.Rows.Count > 0)
            {
                Usuario.IDUsuario = Convert.ToInt32(dataTable.Rows[0]["IDUsuario"].ToString());
                Usuario.Nome = dataTable.Rows[0]["Nome"].ToString();
                Usuario.Email = dataTable.Rows[0]["Email"].ToString();
                Usuario.Senha = dataTable.Rows[0]["Senha"].ToString();

                HttpContext.Current.Session["Usuario"] = Usuario;
            }
            return Usuario;
        }

        public string RetornarParceirosNet()
        {
            usuarioDAL DUsuario = new usuarioDAL();
            return DUsuario.RetornarParceirosNet();
        }

        public string RetornarPerfis()
        {
            usuarioDAL DUsuario = new usuarioDAL();
            return DUsuario.RetornarPerfis();
        }

        public bool VerificarExistenciaUsuario(string sLogin, int iIDUsuario)
        {
            usuarioDAL DUsuario = new usuarioDAL();
            string sSql = DUsuario.VerificarExistenciaUsuario(sLogin, iIDUsuario);

            return PontoBr.Banco.SqlServer.VerificarExistenciaDeDados(sSql);
        }
    }
}
