using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;
using System.Data;

namespace model.dados
{
    public class usuarioDAL
    {
        internal string RetornarUsuario(string sLogin, string sSenha, int iAtivo)
        {
            string sSql = " select a.IDUsuario, a.Nome, a.Login, ";
            sSql += " a.Senha, a.IDPerfil, b.Perfil, t.TipoDiscador, c.Fila, c.IDCampanha  ";//r
            sSql += " from tUsuario a ";
            sSql += " inner join tPerfil b on a.IDPerfil = b.IDPerfil ";

            sSql += " left join tUsuario_Campanha uc on a.IDUsuario = uc.IDUsuario ";
            sSql += " left join tCampanha c on uc.IDCampanha = c.IDCampanha ";
            sSql += " left join tTipoDiscador t on c.IDTipoDiscador = t.IDTipoDiscador  ";
            
            sSql += " where a.Login = '" + sLogin + "' and a.Senha = '" + sSenha + "' ";
            sSql += " and a.Ativo = " + iAtivo + " ";

            return sSql;
        }

        internal string RetornarUsuarios(bool bSomenteAtivo)
        {
            string sSql = " select a.IDUsuario [Cód. Usuário], a.Nome, a.Login, ";
            sSql += " b.Perfil, ";
            sSql += " a.DataCadastro as [Data Cadastro], ";
            sSql += " case when a.Ativo = 1 then 'Sim' else 'Não' end Ativo ";
            sSql += " from tUsuario a ";
            sSql += " inner join tPerfil b on a.IDPerfil = b.IDPerfil ";
            sSql += " where a.IDPerfil in (1, 2, 3, 4) and a.IDUsuario > 0 ";

            if (bSomenteAtivo == true)
            {
                sSql += " and a.Ativo = 1 ";
            }
            sSql += " order by a.Nome ";

            return sSql;
        }

        internal string RetornarSenha(int iIDUsuario)
        {
            string sSql = " select Senha ";
            sSql += " from tUsuario ";
            sSql += " Where IDUsuario = " + iIDUsuario + " ";
            return sSql;
        }

        internal string AtualizarNroAgente(int iIDUsuario, int iNroAgente)
        {
            string sSql = " update tUsuario ";
            if (iNroAgente == 0)
                sSql += " set NroAgente = null, IDProspect = null ";
            else
                sSql += " set NroAgente = " + iNroAgente + ", IDProspect = null ";

            sSql += " where IDUsuario = " + iIDUsuario + " ";
            return sSql;
        }

        internal string EditarUsuario(usuario Usuario)
        {
            string sSql = " update tUsuario ";
            sSql += " set Nome = '" + Usuario.Nome + "', ";
            sSql += " Login = '" + Usuario.Login + "', ";
            sSql += " Senha = '" + Usuario.Senha + "' ";
            //if (Usuario.IDPerfil == 2) //Perfil Operador
            sSql += " , Ativo = " + Usuario.Ativo + " ";
            sSql += " , IDPerfil = " + Usuario.IDPerfil + " ";
            sSql += " where IDUsuario = " + Usuario.IDUsuario + " ";

            return sSql;
        }

        internal string ExcluirUsuarioCampanhas(int iIDUsuario)
        {
            string sSql = " delete tUsuario_Campanha ";
            sSql += " where IDUsuario = " + iIDUsuario + " ";           

            return sSql;
        }

        internal string CadastrarOperador(usuario Usuario, int iIDUsuarioCadastro)
        {
            string sSql = " declare ";
            sSql += " @IDUsuario int ";
            sSql += " insert into tUsuario ";
            sSql += " (Nome, Login, Senha, Ativo, IDPerfil, IDUsuarioCadastro) ";
            sSql += " values ";
            sSql += " ('" + Usuario.Nome + "', '" + Usuario.Login + "', '" + Usuario.Senha + "'," + Usuario.Ativo + ", 2, " + iIDUsuarioCadastro + ") ";
            sSql += " set @IDUsuario = @@IDENTITY ";
            sSql += " select @IDUsuario ";

            return sSql;
        }

        internal string CadastrarSupervisor(usuario Usuario, int iIDUsuarioCadastro)
        {
            string sSql = " declare ";
            sSql += " @IDUsuario int ";
            sSql += " insert into tUsuario ";
            sSql += " (Nome, Login, Senha, Ativo, IDPerfil, IDUsuarioCadastro) ";
            sSql += " values ";
            sSql += " ('" + Usuario.Nome + "', '" + Usuario.Login + "', '" + Usuario.Senha + "', " + Usuario.Ativo + ", 1, " + iIDUsuarioCadastro + ") ";
            sSql += " set @IDUsuario = @@IDENTITY ";
            sSql += " select @IDUsuario ";

            return sSql;
        }

        internal string CadastrarBackOffice(usuario Usuario, int iIDUsuarioCadastro)
        {
            string sSql = " declare ";
            sSql += " @IDUsuario int ";
            sSql += " insert into tUsuario ";
            sSql += " (Nome, Login, Senha, Ativo, IDPerfil, IDUsuarioCadastro) ";
            sSql += " values ";
            sSql += " ('" + Usuario.Nome + "', '" + Usuario.Login + "', '" + Usuario.Senha + "', " + Usuario.Ativo + ", 4, " + iIDUsuarioCadastro + ") ";
            sSql += " set @IDUsuario = @@IDENTITY ";
            sSql += " select @IDUsuario ";

            return sSql;
        }

        internal string CadastrarAdministrador(usuario Usuario, int iIDUsuarioCadastro)
        {
            string sSql = " declare ";
            sSql += " @IDUsuario int ";
            sSql += " insert into tUsuario ";
            sSql += " (Nome, Login, Senha, Ativo, IDPerfil, IDUsuarioCadastro) ";
            sSql += " values ";
            sSql += " ('" + Usuario.Nome + "', '" + Usuario.Login + "', '" + Usuario.Senha + "', " + Usuario.Ativo + ", 5, " + iIDUsuarioCadastro + ") ";
            sSql += " set @IDUsuario = @@IDENTITY ";
            sSql += " select @IDUsuario ";

            return sSql;
        }

        internal string CadastrarUsuarioCampanhas(int iIDUsuario, string sCampanha)
        {
            string sSql = " insert into tUsuario_Campanha ";
            sSql += " select "+iIDUsuario+", IDCampanha ";
            sSql += " from tCampanha ";
            sSql += " where Campanha = '"+sCampanha+"' ";

            return sSql;
        }

        internal string CadastrarUsuarioCampanhas(int iIDUsuario, int iIDCampanha)
        {
            string sSql = " insert into tUsuario_Campanha ";
            sSql += " (IDUsuario, IDCampanha) ";
            sSql += " values ";
            sSql += " ("+iIDUsuario+", "+iIDCampanha+") ";

            return sSql;
        }

        internal string RetornarOperadores()
        {
            string sSql = " select IDUsuario, Nome ";
            sSql += " from tUsuario ";
            sSql += " where IDPerfil = 2 ";
            sSql += " and Ativo = 1 ";
            sSql += " order by Nome ";

            return sSql;
        }

        internal string RetornarDropOperadores()
        {
            string sSql = " select IDUsuario, Nome ";
            sSql += " from tUsuario ";
            sSql += " where IDPerfil = 2 ";
            sSql += " and Ativo = 1 ";
            sSql += " order by Nome ";

            return sSql;
        }

        //Validar senha do supervisor quando o
        //operador troca o dia de semana
        internal string RetornarSupervisor(string sSenha)
        {
            string sSql = " select IDUsuario from tUsuario ";
            sSql += " where IDPerfil = 1 ";
            sSql += " and Ativo = 1 ";
            sSql += " and Senha = '" + sSenha + "' ";

            return sSql;
        }

        internal string RetornarSupervisores()
        {
            string sSql = " select IDUsuario, Nome ";
            sSql += " from tUsuario ";
            sSql += " where IDPerfil = 1 ";
            sSql += " and Ativo = 1 ";
            sSql += " order by Nome ";

            return sSql;
        }

        internal string RetornarQuantidadeOperadores()
        {
            string sSql = " select COUNT(*) Quant from tUsuario where IDPerfil = 2 and Ativo = 1 ";

            return sSql;
        }

        internal string VerificarSenhaAtual(int iIDUsuario, string sSenha)
        {
            string sSql = " select * ";
            sSql += " from tUsuario ";
            sSql += " where IDUsuario = " + iIDUsuario + " ";
            sSql += " and Senha = '" + sSenha + "' ";

            return sSql;
        }

        internal string AlterarSenha(int iIDUsuario, string sSenha)
        {
            string sSql = " update tUsuario ";
            sSql += " set Senha = '" + sSenha + "' ";
            sSql += " where IDUsuario = " + iIDUsuario + " ";

            return sSql;
        }

        internal string RetornarCampanhasUsuario(int iIDUsuario)
        {
            string sSql = " select uc.IDCampanha, Campanha ";
            sSql += " from tUsuario_Campanha uc ";
            sSql += " inner join tCampanha c on c.IDCampanha = uc.IDCampanha ";
            sSql += " where uc.IDUsuario = " + iIDUsuario + " ";

            return sSql;
        }

        internal string RetornarUsuario(int iIDUsuario)
        {
            string sSql = " select a.IDUsuario, a.Nome, a.Login, ";
            sSql += " a.Senha, a.IDPerfil, b.Perfil, uc.IDCampanha, c.Campanha, ";
            sSql += " c.PermiteEditarDadosProspect,c.IDTipoDiscador, t.TipoDiscador, a.Ativo  ";
            sSql += " from tUsuario a ";
            sSql += " inner join tPerfil b on a.IDPerfil = b.IDPerfil ";
            sSql += " left join tUsuario_Campanha uc on a.IDUsuario = uc.IDUsuario ";
            sSql += " left join tCampanha c on uc.IDCampanha = c.IDCampanha ";
            sSql += " left join tTipoDiscador t on c.IDTipoDiscador = t.IDTipoDiscador  ";
            sSql += " where a.IDUsuario = '" + iIDUsuario + "' ";

            return sSql;
        }

        internal string PausaAgente(int iIDUsuario, int iPausaAgente)
        {
            string sSql = "";

            if (iPausaAgente == -1)
                sSql += "update tUsuario set IDProspect = " + iPausaAgente + " where IDUsuario = " + iIDUsuario + " ";
            if (iPausaAgente == 0)
                sSql += "update tUsuario set IDProspect = null where IDUsuario = " + iIDUsuario + " ";

            return sSql;
        }

        internal string TabulareLogado(int iIDUsuario, int iTabulareLogado)
        {
            string sSql = "";

            if (iTabulareLogado == 0)
                sSql += " update tUsuario set TabulareLogado = null, IDProspect = null where IDUsuario = " + iIDUsuario + " ";
            if (iTabulareLogado == 1)
                sSql += " update tUsuario set TabulareLogado = 1 , IDProspect = null where IDUsuario = " + iIDUsuario + " ";
                //sSql += " update tUsuario set TabulareLogado = 1 where IDUsuario = " + iIDUsuario + " ";

            return sSql;
        }

        internal string RetornarClientAtivos()
        {
            string sSql = " select count(*) Qtde ";
            sSql += " from tUsuario ";
            sSql += " where IDPerfil = 2 ";
            sSql += " and Ativo = 1 ";

            return sSql;
        }

        internal string RetornarNroAgentesRepetidos(int iIDUsuario, int iNroAgente)
        {
            string sSql = " select NroAgente ";
            sSql += " from tUsuario ";
            sSql += " where NroAgente != 0 ";
            sSql += " and NroAgente = "+iNroAgente+" ";
            sSql += " and IDUsuario != " + iIDUsuario + " ";
            
            return sSql;
        }

        internal string RetornarUsuarioNet(string sEmail, string sSenha)
        {
            string sSql = " select *  ";
            sSql += " from tUsuario a ";
            sSql += " where a.Email = '" + sEmail + "' and a.Senha = '" + sSenha + "' ";
            sSql += " and a.Ativo = 1 ";

            return sSql;
        }

        internal string RetornarParceirosNet()
        {
            string sSql = " select * from tParceiro ";

            return sSql;
        }

        internal string RetornarPerfis()
        {
            string sSql = " select * from tPerfil ";

            return sSql;
        }

        internal string VerificarExistenciaUsuario(string sLogin, int iIDUsuario)
        {
            string sSql = " select IDUsuario from tUsuario where Login = '" + sLogin + "'";
            if (iIDUsuario != -1)
                sSql += " and IDUsuario != " + iIDUsuario + " ";

            return sSql;
        }


    }
}
