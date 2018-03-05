using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;


namespace model
{
    public class emailDAL
    {
        internal string RetornarEnviarEmail ()
        {
            string sSql = " SELECT Destinatario ";
            sSql += " FROM tConfiguracao ";
            sSql += " WHERE ConfirmarEnvio = 1 ";

            return sSql;
        }

        internal string RetornarConfigEnviarEmail()
        {
            string sSql = " SELECT MensagemEmail, ";
            sSql += " Destinatario,  ";
            sSql += " ConfirmarEnvio, ";
            sSql += " Smtp, ";
            sSql += " userName, ";
            sSql += " defaultCredentials, ";
            sSql += " password, ";
            sSql += " port, ";
            sSql += " IDStatus, ";
            sSql += " MensagemEmail, ";
            sSql += " LinkImagem ";
            sSql += " FROM tConfiguracao ";

            return sSql;
        }

        internal string RetornarStatusMensagemEnvioEmail()
        {
            string sSql = " SELECT IDStatus, MensagemEmail, ";
            sSql += " LinkImagem ";
            sSql += " FROM tConfiguracao ";

            return sSql;
        }

        internal string CadastrarDadosConfiguracaoEmail(string sSmtp, string sUserName, string sPassword, int sProt, string sDestinatario, int iConfirmarEnvio, int iDefaultCredentials, int iIDStatus)
        {
            string sSql = " update tConfiguracao  ";
            sSql += " set Smtp = '"+sSmtp+"',  ";
            sSql += " UserName = '"+sUserName+"',  ";
            sSql += " Password = '"+sPassword+"',  ";
            sSql += " Port = "+sProt+",  ";
            sSql += " Destinatario = '" + sDestinatario + "', ";
            sSql += " ConfirmarEnvio = " + iConfirmarEnvio + ",  ";
            sSql += " DefaultCredentials = "+iDefaultCredentials+",  ";
            sSql += " IDStatus = " + iIDStatus + "  ";
            
            return sSql;
        }

        internal string CadastrarMensagemEmail(string sMensagemEmail, string sLinkImagem)
        {
            string sSql = " update tConfiguracao  ";
            sSql += " set MensagemEmail = '" + sMensagemEmail + "',  ";
            sSql += " LinkImagem = '" + sLinkImagem + "'  ";

            return sSql;
        }
    }
}
