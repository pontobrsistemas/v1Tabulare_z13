using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;

namespace model.dados
{
    public class campanhaDAL
    {
        internal string RetornarIDCampanha(string sCampanha)
        {
            string sSql = " select IDCampanha ";
            sSql += " from tCampanha ";
            sSql += " where Campanha = '" + sCampanha + "' ";

            return sSql;
        }

        internal string RetornarIDCampanhaPreditivo(string sCampanha)
        {
            string sSql = " select c.IDCampanha ";
            sSql += " from tCampanha c ";
            sSql += " inner join tFila f on c.IDCampanha = f.IDCampanha ";
            sSql += " where f.IDFila = '" + sCampanha + "' ";

            return sSql;
        }

        internal string RetornarCampanhas()
        {
            string sSql = " select IDCampanha [Cód. Campanha], Campanha, CONVERT(varchar, DataCadastro, 103) + ' ' + CONVERT(varchar, DataCadastro, 106) [Data de Cadastro], ";
            sSql += " Operadora, case when Ativo = 1 then 'Sim' else 'Não' end Ativo, case when PermiteEditarDadosProspect = 1 then 'Sim' else 'Não' end [Editar Dados Prospect], ";
            sSql += " case when IDTipoDiscador = 1 then 'Power' else 'Preditivo' end [Tipo de discador] ";
            sSql += " from tCampanha ";
            sSql += " order by Campanha ";

            return sSql;
        }

        internal string RetornarCamposOperador()
        {
            string sSql = " select campo, TextBox, IDAtivo ";
            sSql += " from tCampo ";
            sSql += " where IDCampo like 'c%' ";
            sSql += " order by IDCampo asc ";

            return sSql;
        }

        internal string RetornarOperadora(int iIDCampanha)
        {
            string sSql = " SELECT Operadora ";
            sSql += " FROM tCampanha ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string RetornarCampanhas(bool bAtiva, int iIDUsuario, string sPerfil)
        {
            string sSql = " select c.IDCampanha, c.Campanha  ";
            sSql += " from tCampanha c ";

            if (sPerfil == "Administrador")
            {
                if (bAtiva == true) sSql += " where c.Ativo = 1 ";
            }
            else
            {
                sSql += " inner join tUsuario_Campanha u on c.IDCampanha = u.IDCampanha ";
                sSql += " where u.IDUsuario = " + iIDUsuario + " ";

                if (bAtiva == true) sSql += " and c.Ativo = 1 ";
            }

            sSql += " order by Campanha ";

            return sSql;
        }

        internal string RetornarCampanhasFilas(bool bAtiva)
        {
            string sSql = " select c.IDCampanha, c.Campanha+' - '+f.IDFila Campanha ";
            sSql += " from tCampanha c ";
            sSql += " inner join tFila f on c.IDCampanha = f.IDCampanha ";

            if (bAtiva == true)
                sSql += " where c.Ativo = 1 and c.campanha like '%preditivo%'";

            sSql += " order by Campanha ";

            return sSql;
        }

        internal string HabilitarDesabilitarCampanhas(int iAtivo, int IDCampanha)
        {
            string sSql = " update dbo.tCampanha ";
            sSql += "set Ativo = " + iAtivo + " ";
            sSql += "where IDCampanha = " + IDCampanha + " ";

            return sSql;
        }

        internal string CadastrarCampanhas(campanha campanha)
        {
            string sSql = " exec sCadastrarCampanha ";
            sSql += " '" + campanha.sCampanha + "', ";
            sSql += " " + campanha.iAtivo + " ";

            return sSql;
        }

        internal string AtualizaCampanha(campanha Campanha)
        {
            string sSql = " update tCampanha ";
            sSql += " set Campanha = '" + Campanha.sCampanha + "', ";
            sSql += " operadora = '" + Campanha.sOperadora + "', ";
            sSql += " Ativo = " + Campanha.iAtivo + ", ";
            sSql += " PermiteEditarDadosProspect = " + Campanha.PermiteEditarDadosProspect + ", ";
            sSql += " IDTipoDiscador = " + Campanha.iIDTipoDiscador + " ";
            sSql += " where IDCampanha = " + Campanha.iIDCampanha + " ";

            return sSql;
        }

        internal string RetornarCampanhaLogar(int IDCampanha)
        {
            string sSql = " select Campanha,IDCampanha  ";
            sSql += " from tcampanha ";
            sSql += " where IDCampanha = " + IDCampanha + " ";
            //sSql += " and Ativo = 1 ";
            sSql += " order by Campanha ";

            return sSql;
        }

        internal string RetornarCamposCampanha(int iIDCampanha)
        {
            string sSql = " select c.IDCampo,  ";
            sSql += " c.Campo + ' (' + case when (cc.Texto is null) then '*Não utilizado' else cc.Texto end  + ')' Campo ";
            sSql += " from tCampo c ";
            sSql += " left join (select * ";
            sSql += " from tCampanha_Campo cc  ";
            sSql += " where cc.IDCampanha = " + iIDCampanha + ") cc on cc.IDCampo = c.IDCampo ";

            return sSql;
        }

        internal string RetornarCampo(int iIDCampanha, string sIDCampo)
        {
            string sSql = "select Texto,LocalizacaoLabel,TamanhoTextBox,LocalizacaoTextBox,Obrigatorio, Lista ";
            sSql += "from tCampanha_Campo where IDCampanha = " + iIDCampanha + "and IDCampo = '" + sIDCampo + "'";

            return sSql;
        }

        internal string RetornarCampoConfiguracaoInicial(string sIDCampo)
        {
            string sSql = " select '' Texto, LocalizacaoLabel,TamanhoTextBox,LocalizacaoTextBox, 0 Obrigatorio ";
            sSql += " from tCampo where IDCampo = '" + sIDCampo + "' ";

            return sSql;
        }

        internal string ReconfigurarCampo(int iIDCampanha, string sIDCampo, string sTexto, string sTamanhoTextBox, string sLocalizacaoTextBox, string sLocalizacaoLabel, int iObrigatorio, string sLista)
        {
            string sSql = " if exists (select * from tCampanha_Campo where IDCampanha = " + iIDCampanha + " and IDCampo = '" + sIDCampo + "') ";

            sSql += " update tCampanha_Campo ";
            sSql += " set Texto = '" + sTexto + "',TamanhoTextBox = '" + sTamanhoTextBox + "',LocalizacaoTextBox = '" + sLocalizacaoTextBox + "',LocalizacaoLabel = '" + sLocalizacaoLabel + "',Obrigatorio = " + iObrigatorio + ", Lista = '" + sLista + "' ";
            sSql += " where IDCampo = '" + sIDCampo + "' and IDCampanha = " + iIDCampanha + " ";

            sSql += " else ";
            sSql += " insert into tCampanha_Campo ";
            sSql += " (IDCampanha, IDCampo, Texto, TamanhoTextBox, LocalizacaoTextBox, LocalizacaoLabel, Obrigatorio, Lista) ";
            sSql += " values ";
            sSql += " (" + iIDCampanha + ", '" + sIDCampo + "', '" + sTexto + "', '" + sTamanhoTextBox + "', '" + sLocalizacaoTextBox + "', '" + sLocalizacaoLabel + "', " + iObrigatorio + ", '" + sLista + "') ";

            return sSql;

        }

        internal string RetornarCampanha(string sCampanha)
        {
            string sSql = " select Campanha ";
            sSql += " from tCampanha ";
            sSql += " where Campanha = '" + sCampanha + "' ";

            return sSql;
        }

        internal string RetornarCampanhasUsuario(int iIDUsuario)
        {
            string sSql = " select ";
            sSql += " c.IDCampanha, ";
            sSql += " c.Campanha ";
            sSql += " from tUsuario_Campanha uc ";
            sSql += " inner join tCampanha c on uc.IDCampanha = c.IDCampanha ";
            sSql += " where uc.IDUsuario = '" + iIDUsuario + "' ";
            sSql += " and Ativo = 1 ";// Incluído pois estava retornando as campanhas inativas para o operador
            sSql += " order by IDCampanha  ";

            return sSql;
        }

        internal string RetornarCamposVendaCampanhas(string sCampanha)
        {
            string sSql = " select IDCampo,  Texto ";
            sSql += " from tCampanha_Campo cc ";
            sSql += " inner join tCampanha c on cc.IDCampanha = c.IDCampanha ";
            sSql += " and c.Campanha = '" + sCampanha + "' ";
            sSql += " order by Texto ";

            return sSql;
        }

        internal string RetornarCamposListaVendaCampanhas(string sCampanha)
        {
            string sSql = " select IDCampo,  Texto ";
            sSql += " from tCampanha_Campo cc ";
            sSql += " inner join tCampanha c on cc.IDCampanha = c.IDCampanha ";
            sSql += " and c.Campanha = '" + sCampanha + "' ";
            sSql += " and convert(varchar, cc.Lista) != '' and convert(varchar, cc.Lista) is not null ";
            sSql += " and cc.IDCampo like '%v%' ";
            sSql += " order by Texto ";

            return sSql;
        }

        internal string RetornarCamposVendaCampanhas(int iIDCampanha)
        {
            string sSql = " select IDCampo,  Texto ";
            sSql += " from tCampanha_Campo cc ";
            sSql += " where left(cc.IDCampo, 1) = 'v' ";
            sSql += " and cc.IDCampanha = " + iIDCampanha + " ";
            sSql += " order by Texto ";

            return sSql;
        }

        internal string RetornarDadosVenda(string sIDCampanha)
        {

            string sSql = " select IDCampo,  Texto ";
            sSql += " from tCampanha_Campo cc ";
            sSql += " inner join tCampanha c on cc.IDCampanha = c.IDCampanha ";
            sSql += " where c.IDCampanha = '" + sIDCampanha + "' ";
            sSql += " order by Texto ";

            return sSql;
        }

        internal string RetornarCamposProspect(string sCampanha)
        {
            string sSql = " select IDCampo,  Texto ";
            sSql += " from tCampanha_Campo cc ";
            sSql += " inner join tCampanha c on cc.IDCampanha = c.IDCampanha ";
            sSql += " where left(cc.IDCampo, 1) = 'c' ";
            sSql += " and c.Campanha = '" + sCampanha + "' ";
            sSql += " order by Texto ";

            return sSql;
        }

        internal string RetornarCampanha(int iIDCampanha)
        {
            string sSql = " select c.*, td.TipoDiscador ";
            sSql += " from tCampanha c ";
            sSql += " inner join tTipoDiscador td on td.IDTipoDiscador = c.IDTipoDiscador ";
            sSql += " where c.IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string ExcluirCampoCampanha(int iIDCampanha, string sIDCampo)
        {
            string sSql = " delete tCampanha_Campo where IDCampanha = " + iIDCampanha + " and IDCampo = '" + sIDCampo + "' ";
            return sSql;
        }

        internal string RetornarCampanhasAtivas(bool bAtiva, int iIDUsuario, string sPerfil)//r
        {
            string sSql = " select c.IDCampanha, c.Campanha  ";
            sSql += " from tCampanha c ";

            if (sPerfil == "BackOffice")
            {
                sSql += " inner join tUsuario_Campanha u on c.IDCampanha = u.IDCampanha ";
                if (bAtiva == true) sSql += " where c.Ativo = 1 and u.IDUsuario = " + iIDUsuario + " ";
            }
            else
            {
                if (bAtiva == true) sSql += " where c.Ativo = 1 ";
            }

            sSql += " order by Campanha ";

            return sSql;
        }

        internal string RetornarBloqueioDDD(int iIDCampanha)
        {
            string sSql = " select * from tBloqueioDDD where IDCampanha = "+iIDCampanha+" ";
            return sSql;
        }

        internal string RetornarListaCampoVenda(int iIDCampanha, string sCampo)
        {
            string sSql = " select cc.Texto + ' => ' +  convert(varchar, cc.Lista) Lista ";
            sSql += " from tCampanha_Campo cc  ";
            sSql += " inner join tCampanha c on cc.IDCampanha = c.IDCampanha  ";
            sSql += " and c.IDCampanha = " + iIDCampanha + " ";
            sSql += " and Texto in ("+sCampo+") ";

            return sSql;
        }

    }
}
