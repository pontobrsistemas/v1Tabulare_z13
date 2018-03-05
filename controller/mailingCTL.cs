using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.negocios;
using model.objetos;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace controller
{
    public class mailingCTL
    {
        public DataTable RetornarMailings(bool bAtivo, int iIDCampanha)
        {
            mailingBLL BMailing = new mailingBLL();
            return BMailing.RetornarMailings(bAtivo, iIDCampanha);
        }

        public int CadastrarMailing(mailing Mailing, int iIDUsuario)
        {
            mailingBLL BMailing = new mailingBLL();
            return BMailing.CadastrarMailing(Mailing, iIDUsuario);
        }

        public void PreencherComboBox_Mailings_DataCadastro(ComboBox comboMailing)
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailings_DataCadastro();

            PontoBr.Utilidades.WCL.CarregarComboBox(comboMailing, dataTable, "IDMailing", "Mailing", false, true);
        }

        public mailing RetornarMailing(int iIDMailing)
        {
            mailingBLL BMailing = new mailingBLL();
            return BMailing.RetornarMailing(iIDMailing);
        }

        public void PreencherComboBox_Mailings(ComboBox comboMailing, int iIDCampanha)
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailings(iIDCampanha);

            DataRow dr = dataTable.NewRow();
            dr["Mailing"] = "NENHUM";
            dr["IDMailing"] = "-1";
            dataTable.Rows.Add(dr);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboMailing, dataTable, "IDMailing", "Mailing", false, false);
        }

        public void PreencherComboBox_MailingsAtivos(ComboBox comboMailing, int iIDCampanha, int iAtivo, bool bTodos, bool bSelecione, bool bNenhum)
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailingsAtivos(iIDCampanha, iAtivo);

            //Adiciona o item "Nenhum" no ComboBox
            if (bNenhum == true)
            {
                DataRow dr = dataTable.NewRow();
                dr["Mailing"] = "NENHUM";
                dr["IDMailing"] = "-1";
                dataTable.Rows.Add(dr);
            }

            PontoBr.Utilidades.WCL.CarregarComboBox(comboMailing, dataTable, "IDMailing", "Mailing", bTodos, bSelecione);
        }

        public void EditarMailing(mailing Mailing)
        {
            mailingBLL BMailing = new mailingBLL();
            BMailing.EditarMailing(Mailing);
        }

        public bool VerificarExistenciaMailing(string sMailing)
        {
            mailingBLL BMailing = new mailingBLL();
            return BMailing.VerificarExistenciaMailing(sMailing);
        }

        public int RetornarMailingIndicacaoOperador(int iIDCampanha)
        {
            mailingBLL BMailing = new mailingBLL();
            return BMailing.RetornarMailingIndicacaoOperador(iIDCampanha);
        }

        public void SalvarMailingIndicacao(int iIDCampanha, int iIDMailingIndicacao)
        {
            mailingBLL BMailing = new mailingBLL();
            BMailing.SalvarMailingIndicacao(iIDCampanha, iIDMailingIndicacao);
        }

        public int RetornarMailingIndicacaoSupervisor(int iIDCampanha)
        {
            mailingBLL BMailing = new mailingBLL();
            return BMailing.RetornarMailingIndicacaoSupervisor(iIDCampanha);
        }

        public void AtualizarProspectVonix(int iIDProspect, int iIDStatusVonix)
        {
            mailingBLL BMailing = new mailingBLL();
            BMailing.AtualizarProspectVonix(iIDProspect, iIDStatusVonix);
        }

        public void PreencherComboBox_Mailings(ComboBox comboMailing, int iIDCampanha, bool bAtivosInativos, bool bTodos, bool bSelecione)
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailings(iIDCampanha, bAtivosInativos);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboMailing, dataTable, "IDMailing", "Mailing", bTodos, bSelecione);
        }

        public void GerarMailingCallFlex(int iIDCampanha, int iIDMailing)//CallFlex
        {
            mailingBLL BMailing = new mailingBLL();
            BMailing.GerarMailingCallFlex(iIDCampanha, iIDMailing);
        }

        public void CarregarDropdownMailings(DropDownList dropMailing, int iIDCampanha, bool bNenhum, bool bSelecione, bool bTodos)
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailings(iIDCampanha);

            dropMailing.Items.Clear();
            dropMailing.DataSource = dataTable;
            dropMailing.DataBind();

            dropMailing.DataTextField = "Mailing";
            dropMailing.DataValueField = "IDMailing";
            dropMailing.DataBind();

            if (bNenhum)
            {
                dropMailing.Items.Insert(0, new ListItem("NENHUM", "-1"));
                dropMailing.SelectedIndex = 0;
            }
            if (bSelecione)
            {
                dropMailing.Items.Insert(0, new ListItem("SELECIONE...", "-1"));
                dropMailing.SelectedIndex = 0;
            }
            if (bTodos)
            {
                dropMailing.Items.Insert(0, new ListItem("TODOS", "-1"));
                dropMailing.SelectedIndex = 0;
            }
        }

        public void CarregarGridviewMailingsIndicacao(GridView grdDados)
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailingsIndicacao();

            grdDados.DataSource = dataTable;
            grdDados.DataBind();
        }

        public void PreencherCheckListBox_MailingsInativos(CheckedListBox chlMailing, string sIDCampanhas, bool bAtivosInativos)//r
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailingsInativos(sIDCampanhas, bAtivosInativos);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlMailing, dataTable, "Mailing", "IDMailing");
        }

        public void PreencherCheckListBox_Mailing(CheckedListBox chlMailing, string sIDCampanhas)
        {
            mailingBLL BMailing = new mailingBLL();
            DataTable dataTable = BMailing.RetornarMailings(sIDCampanhas);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlMailing, dataTable, "Mailing", "IDMailing");
        }

         public int RetornarIDMailing(string sIDMailing)//r
        {
            mailingBLL BMailing = new mailingBLL();
            return BMailing.RetornarIDMailing(sIDMailing);
        }

         public void PreencherComboBox_TodosMailingsAtivos(ComboBox comboMailing, string sIDCampanhas, int iAtivo, bool bTodos, bool bSelecione, bool bNenhum)
         {
             mailingBLL BMailing = new mailingBLL();
             DataTable dataTable = BMailing.RetornarTodosMailingsAtivos(sIDCampanhas, iAtivo);

             //Adiciona o item "Nenhum" no ComboBox
             if (bNenhum == true)
             {
                 DataRow dr = dataTable.NewRow();
                 dr["Mailing"] = "NENHUM";
                 dr["IDMailing"] = "-1";
                 dataTable.Rows.Add(dr);
             }

             PontoBr.Utilidades.WCL.CarregarComboBox(comboMailing, dataTable, "IDMailing", "Mailing", bTodos, bSelecione);
         }
    }
}
