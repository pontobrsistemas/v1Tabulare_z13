using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.negocios;
using model.objetos;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Web;

namespace controller
{
    public class auditoriaCTL
    {
        public void PreencherComboBox_StatusAuditoria(ComboBox comboAuditoria, bool bSomentoAtivo, bool bTodos, bool bSelecione)
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            string sSql = BAuditoria.RetornarStatusAuditoria(bSomentoAtivo);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboAuditoria, dataTable, "IDStatus", "Status da Auditoria", bTodos, bSelecione); 
        }

        public void PreencherCheckListBox_Auditoria(CheckedListBox chlAuditoria, bool bSomentoAtivo)//r
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            string sSql = BAuditoria.RetornarStatusAuditoria(bSomentoAtivo);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlAuditoria, dataTable, "Status da Auditoria", "IDStatus");
        }

        public void PreencherDropdownStatusAuditoria(DropDownList dropStatus, bool bSomentoAtivo, bool bTodos, bool bSelecione)
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            string sSql = BAuditoria.RetornarStatusAuditoria(bSomentoAtivo);

            PontoBr.Utilidades.WCL.CarregarDropDown(dropStatus, sSql, "Status da Auditoria", "IDStatus", bTodos, bSelecione);
        }

        public int RetornarIDAuditoria(string sStatus)//r
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            return BAuditoria.RetornarIDAuditoria(sStatus);
        }

        public DataTable RetornarStatusAuditoria(bool bSomentoAtivo)
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            string sSql = BAuditoria.RetornarStatusAuditoria(bSomentoAtivo);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }

        public status RetornarStatusAuditoria(int iIDStatus)
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            return BAuditoria.RetornarStatusAuditoria(iIDStatus);
        }

        public void AtualizarStatusAuditoria(int iIDStatus, int iTempoExpiracao, int iAtivo)
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            BAuditoria.AtualizarStatusAuditoria(iIDStatus, iTempoExpiracao, iAtivo);
        }

        public DataSet RetornarQuantidadeVendasExpiradas()
        {
            auditoriaBLL BAuditoria = new auditoriaBLL();
            DataSet dataSet = BAuditoria.RetornarQuantidadeVendasExpiradas();

            return dataSet;
        }
    }
}
