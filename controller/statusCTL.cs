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
    public class statusCTL
    {
        public DataTable RetornarStatusCadastro(int iIDCampanha)
        {
            statusBLL BStatus = new statusBLL();
            return BStatus.RetornarStatusCadastro(iIDCampanha);
        }

        public void PreencherComboBox_Status(ComboBox comboStatus, int iIDCampanha, int iScript)
        {
            statusBLL BStatus = new statusBLL();
            DataTable dataTable = BStatus.RetornarStatusAtendimento(iIDCampanha, iScript);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboStatus, dataTable, "IDStatus", "Status", false, true);
        }

        public void PreencherDropStatus(DropDownList DropStatus, int iIDCampanha, int iScript)//r
        {
            statusBLL BStatus = new statusBLL();
            string sSql = BStatus.RetornarDropStatusAtendimento(iIDCampanha, iScript);

            PontoBr.Utilidades.WCL.CarregarDropDown(DropStatus, sSql, "Status", "IDStatus", false, true);
        }

        public void PreencherCheckBoxStatusResubmit(CheckedListBox cblStatus, int iIDCampanha)
        {
            statusBLL BStatus = new statusBLL();
            DataTable dataTable = BStatus.RetornarStatusResubmit(iIDCampanha);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cblStatus.Items.Add(dataTable.Rows[i]["Status"].ToString());
            }            
        }

        public void AlteraStatus(status Status)
        {
            statusBLL BStatus = new statusBLL();
            string sSql = BStatus.AlteraStatus(Status);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void PreencherComboBox_StatusRelatorio(ComboBox comboStatus, int iIDCampanha)
        {
            statusBLL BStatus = new statusBLL();
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(BStatus.RetornarStatusRelatorio(iIDCampanha));

            PontoBr.Utilidades.WCL.CarregarComboBox(comboStatus, dataTable, "IDStatus", "Status", true, false);
        }

        public status RetornarStatus(int iIDStatus)
        {
            statusBLL BStatus = new statusBLL();
            return BStatus.RetornarStatus(iIDStatus);
        }

        public void PreencherCheckListBox_DescricaoStatus(CheckedListBox chlStatus, int iIDCampanha)
        {
            statusBLL BStatus = new statusBLL();
            DataTable datatable = PontoBr.Banco.SqlServer.RetornarDataTable(BStatus.RetornarDescricaoStatusRelatorio(iIDCampanha));
                
            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlStatus, datatable, "Status", "IDStatus");
        }


        public void PreencherCheckBoxListStatus(CheckBoxList chkStatus, int iIDCampanha)
        {
            statusBLL BStatus = new statusBLL();
            string sSql = BStatus.RetornarStatusRelatorio(iIDCampanha);

            PontoBr.Utilidades.WCL.CarregarCheckBoxList(chkStatus, sSql, "Status", "IDStatus");
        }

        public void PreencherCheckBoxStatusResubmitCallflex(CheckedListBox cblStatus, int iIDCampanha)
        {
            statusBLL BStatus = new statusBLL();
            DataTable dataTable = BStatus.RetornarStatusResubmitCallflex(iIDCampanha);


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cblStatus.Items.Add(dataTable.Rows[i]["Status"].ToString());
            }
        }

        public DataTable RetornarStatusVonix()
        {
            statusBLL BStatus = new statusBLL();
            return BStatus.RetornarStatusVonix();
        }

        public void CarregarGridviewStatusCadastro(GridView dgStatus, int iIDCampanha)//r
        {
            statusBLL BStatus = new statusBLL();
            DataTable dataTable = BStatus.RetornarGridViewStatusCadastro(iIDCampanha);

            dgStatus.DataSource = dataTable;
            dgStatus.DataBind();
        }

        public void PreencherCheckListBox_DescricaoStatus(CheckedListBox chlStatus, string sIDCampanha)//
        {
            statusBLL BStatus = new statusBLL();
            DataTable datatable = PontoBr.Banco.SqlServer.RetornarDataTable(BStatus.RetornarDescricaoStatusRelatorio(sIDCampanha));

            PontoBr.Utilidades.WCL.CarregarCheckedListBox(chlStatus, datatable, "Status", "IDStatus");
        }
    }
}
