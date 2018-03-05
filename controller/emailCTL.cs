using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;
using model.negocios;
using System.Data;


namespace controller
{
    public class emailCTL
    {
        public void EnviarEmailAgendamento(prospect Prospect, string sDataContato, DataTable dScript, string sObservacao, string sOperador)
        {
            emailBLL BEmail = new emailBLL();
            BEmail.EnviarEmailAgendamento(Prospect, sDataContato, dScript, sObservacao, sOperador);
        }

        public DataTable RetornarStatusMensagemEnvioEmail()
        {
            emailBLL BEmail = new emailBLL();
            return BEmail.RetornarStatusMensagemEnvioEmail();
        }

        public DataTable RetornarConfigEnviarEmail()
        {
            emailBLL BEmail = new emailBLL();
            return BEmail.RetornarConfigEnviarEmail();
        }

        public void CadastrarDadosConfiguracaoEmail(string sSmtp, string sUserName, string sPassword, int sProt, string sDestinatario, int iConfirmarEnvio, int iDefaultCredentials, int iIDStatus)
        {
            emailBLL BEmail = new emailBLL();
            BEmail.CadastrarDadosConfiguracaoEmail(sSmtp, sUserName, sPassword, sProt, sDestinatario, iConfirmarEnvio, iDefaultCredentials, iIDStatus);
        }

        public void CadastrarMensagemEmail(string sMensagemEmail, string sLinkImagem)
        {
            emailBLL BEmail = new emailBLL();
            BEmail.CadastrarMensagemEmail(sMensagemEmail,sLinkImagem);
        }
    }
}
