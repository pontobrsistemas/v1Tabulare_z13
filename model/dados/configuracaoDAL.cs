using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;

namespace model.dados
{
    public class configuracaoDAL
    {   
        internal string RetornarConfiguracoes()
        {
            string sSql = " SELECT c.*, t.TipoPabx  ";
            sSql += " FROM tConfiguracao c ";
            sSql += " inner join tTipoPabx t on c.IDTipoPabx = t.IDTipoPabx ";

            return sSql;
        }

        internal string RetornarCamposCampanha(int iIDCampanha)
        {
            string sSql = " SELECT a.*, b.Label, b.TextBox ";
            sSql += " FROM tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha = "+iIDCampanha+" ";
            sSql += " order by b.IDCampo ";

            return sSql;
        }

        internal string AtualizarVersaoDiscador(string sVersaoDiscador)
        {
            string sSql = "update tConfiguracao ";
            sSql += " set VersaoDiscador = '" + sVersaoDiscador + "' ";

            return sSql;
        }

        internal string VerificarRamalDNS(string sDNS)
        {
            string sSql = " select Ramal from tRamal ";
            sSql += " where DNS = '" + sDNS + "' ";

            return sSql;
        }

        internal string CadastrarRamalDNS(int iRamal, string sDNS, string sAgent)
        {
            string sSql = " if not exists (select * from tRamal where DNS = '" + sDNS + "') ";
            sSql += " insert into tRamal (Ramal, DNS, Agent) ";
            sSql += " values (" + iRamal + ", '" + sDNS + "', '" + sAgent + "') ";
            sSql += " else ";
            sSql += " update tRamal set Ramal = " + iRamal + ", Agent = '"+sAgent+"' where DNS = '" + sDNS + "' ";

            return sSql;
        }

        internal string CadastrarDadosSocket(string sIP, int iPort)
        {
            string sSql = " if exists (select * from tConfiguracao where IPServidor is null or PortaServidor is null) ";
            sSql += "   update tConfiguracao set IPServidor = '" + sIP + "', PortaServidor = " + iPort + " ";
            sSql += " else ";
            sSql += "   update tConfiguracao set IPServidor = '" + sIP + "', PortaServidor = " + iPort + " ";

            return sSql;
        }

        internal string RetornarDadosSocket()
        {
            string sSql = " SELECT ";
            sSql += " IPServidor, ";
            sSql += " PortaServidor ";
            sSql += " FROM tConfiguracao ";

            return sSql;
        }
    }
}
