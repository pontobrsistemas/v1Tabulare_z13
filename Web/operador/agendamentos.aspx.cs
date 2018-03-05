using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller;
using System.Data;
using model.objetos;
using System.Web.UI.HtmlControls;
using System.Configuration;

public partial class operador_agendamentos : App_Code.BaseWeb 
{
    private static DateTime dateTimeProximo = DateTime.Now.AddSeconds(15);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
            CarregarAgendamentosOperador(Usuario.IDUsuario, Usuario.IDCampanha);
        }
    }

    private void CarregarAgendamentosOperador(int iIDUsuario, int iIDCampanha)
    {
        prospectCTL CProspect = new prospectCTL();
        DataTable dataTable = CProspect.RetornarAgendamentoOperador(iIDUsuario, iIDCampanha);

        dgProspects.DataSource = dataTable;
        dgProspects.DataBind();

        lblRegistros.Text = "| " + dgProspects.Rows.Count.ToString() + " registro(s) |";
    }

    protected void bTnAtualizar_Click(object sender, EventArgs e)
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
        CarregarAgendamentosOperador(Usuario.IDUsuario, Usuario.IDCampanha);
    }

    protected void dgProspects_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            try
            {
                DateTime dDataAgendamento;
                DateTime dDataAtual = DateTime.Now;

                dDataAgendamento = PontoBr.Conversoes.Data.ConverterDataDDMMAAAAComBarraeHoraComSegundosParaDateTime(e.Row.Cells[3].Text);

                if (dDataAgendamento < dDataAtual)
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Black;
                }

                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='grid_row_selecionado'");
                    e.Row.Attributes.Add("onmouseout", "this.className='grid_alternative_row'");
                }
                else
                {
                    e.Row.Attributes.Add("onmouseover", "this.className='grid_row_selecionado'");
                    e.Row.Attributes.Add("onmouseout", "this.className='grid'");
                }

                int iIDProspect = Convert.ToInt32(dgProspects.DataKeys[e.Row.RowIndex].Values[0].ToString());

                string sChave = ConfigurationManager.AppSettings["Chave"].ToString();
                string sVetorInicializacao = ConfigurationManager.AppSettings["VetorInicializacao"].ToString();
                PontoBr.Seguranca.Criptografia Criptografia = new PontoBr.Seguranca.Criptografia();
                string sIDProspect = Criptografia.Criptografar(iIDProspect.ToString(), sChave, sVetorInicializacao);

                e.Row.Attributes.Add("onclick", "parent.AbrirAgendamento('" + sIDProspect + "');");
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(ex.Message, this.Page);
            }
        }
    }
 
}