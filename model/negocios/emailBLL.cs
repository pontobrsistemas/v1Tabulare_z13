using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using System.Net;
using System.Text.RegularExpressions;

namespace model.negocios
{
    public class emailBLL
    {
        //Envia e-mail para MRV com os dados do prospect, respostas do questionario e a observacao
        public void EnviarEmailAgendamento(prospect ProspectEnvioEmail, string sDataContato, DataTable dScript, string sObservacao, string sOperador)
        {
            string sHTML = "<b>Sistema Tabulare_z13 - Dados Venda</b>";
            sHTML += "<BR><BR>Código Prospect: " + ProspectEnvioEmail.IDProspect;

            //sHTML += "<BR><BR>Operador: " + Prospect.Usuario;
            sHTML += "<BR><BR>Cliente: " + ProspectEnvioEmail.Nome;
            sHTML += "<BR>Telefone 1: " + ProspectEnvioEmail.Telefone1;
            sHTML += "<BR>Telefone 2: " + ProspectEnvioEmail.Telefone2;
            sHTML += "<BR>VENDA : " + ProspectEnvioEmail.Status;

            if (ProspectEnvioEmail.MensagemEmail != "")
            {
                sHTML += "<BR><BR>-----------------------------------------<BR>";
                sHTML += "<BR>Mensagem: " + ProspectEnvioEmail.MensagemEmail;
                sHTML += "<BR><BR>-----------------------------------------<BR><BR>";
            }

            if (ProspectEnvioEmail.LinkImagem != "")
            {
                sHTML += "<BR>Link da Imagem: <a HREF=" + ProspectEnvioEmail.LinkImagem + "> Informações </a><BR><BR>";
            }

            if (dScript.Rows.Count != 0)
            {
                sHTML += "<BR><BR>-----------------------------------------<BR><BR>";
                string sPergunta, sResposta;
                sHTML += " <table border=1> ";
                for (int iLinha = 0; iLinha < dScript.Rows.Count; iLinha++)
                {
                    sPergunta = dScript.Rows[iLinha][0].ToString();
                    sResposta = dScript.Rows[iLinha][1].ToString();

                    sHTML += " <tr> <td> " + sPergunta + "</td>";
                    sHTML += " <td> " + sResposta + "</td> </tr>";
                }
                sHTML += " </table> ";
                sHTML += "<BR><BR>-----------------------------------------<BR><BR>";
            }

            sHTML += "<BR>-----------------------------------------<BR>";
            sHTML += " Observação: "+ sObservacao + "<BR>";
            sHTML += "<BR>-----------------------------------------<BR>";

            sHTML += "Operador: " + sOperador;
            sHTML += "<BR>Data do Contato: " + sDataContato;

            emailDAL DEmail = new emailDAL();
            string sSql = DEmail.RetornarConfigEnviarEmail();
            DataTable dataTable =  PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
            if (dataTable.Rows.Count != 0)
            {
                #region Envio de email via banco de dados
                //// Forma de enviar email pegando dados de configuração direto do banco de dados em vez do app.config
                //SmtpClient smtp = new SmtpClient(dataTable.Rows[0]["Smtp"].ToString(),Convert.ToInt32(dataTable.Rows[0]["port"]));
                //NetworkCredential credentials = new NetworkCredential();
                //credentials.UserName = dataTable.Rows[0]["userName"].ToString();
                //credentials.Password = dataTable.Rows[0]["password"].ToString();
                //smtp.EnableSsl = false;
                //smtp.Credentials = credentials;
                //smtp.UseDefaultCredentials = Convert.ToBoolean(dataTable.Rows[0]["defaultCredentials"]);
                //string sDestinatario = Convert.ToString(dataTable.Rows[0]["Destinatario"]); 
                //MailMessage mensagemEmail = new MailMessage("Tabulare_z13 <paulo@pontobrsistemas.com.br>", sDestinatario, "PontoBR Sistemas - Tabulare_z13 ", sHTML);
                //smtp.Send(mensagemEmail);
                #endregion

                //Utilização da PontoBR para envio de email - Utiliza o app.config para enviar
                string sDestinatario = System.Configuration.ConfigurationSettings.AppSettings["DestinatariosEmail"].ToString(); //Convert.ToString(dataTable.Rows[0]["Destinatario"]);  
                PontoBr.Utilidades.Email.EnviarEmail("PontoBR Sistemas - Tabulare_z13 ", "Tabulare_z13 <suporte@pontobrsistemas.com.br>", sDestinatario, sHTML, null, false);
            }
        }

        public DataTable RetornarStatusMensagemEnvioEmail()
        {
            emailDAL DEmail = new emailDAL();
            string sSql = DEmail.RetornarStatusMensagemEnvioEmail();
            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarConfigEnviarEmail()
        {
            emailDAL DEmail = new emailDAL();
            string sSql = DEmail.RetornarConfigEnviarEmail();
            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void CadastrarDadosConfiguracaoEmail(string sSmtp, string sUserName, string sPassword, int sProt, string sDestinatario, int iConfirmarEnvio, int iDefaultCredentials, int iIDStatus)
        {
            emailDAL DEmail = new emailDAL();
            string sSql = DEmail.CadastrarDadosConfiguracaoEmail(sSmtp, sUserName, sPassword, sProt, sDestinatario, iConfirmarEnvio, iDefaultCredentials, iIDStatus);

            PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void CadastrarMensagemEmail(string sMensagemEmail, string sLinkImagem)
        {
            emailDAL DEmail = new emailDAL();
            string sSql = DEmail.CadastrarMensagemEmail(sMensagemEmail,sLinkImagem);

            PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }
    }
}
