using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using controller;
using model.objetos;
using System.Collections.Specialized;
using System.Xml;
using model;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.IO;
using System.Windows.Forms;


public partial class supervisor_mailing : App_Code.BaseWeb 
{
    private string sArquivo;
    private static DataSet dataSetMailing;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            CarregarCampanhas();
            CarregarMailings();
        }
    }

    private void CarregarMailings()
    {
        mailingCTL CMailing = new mailingCTL();
        DataTable dataTable = CMailing.RetornarMailings(chkAtivos.Checked, Convert.ToInt32(dropCampanha.SelectedValue));

        grdDados.DataSource = dataTable;
        grdDados.DataBind();

        lblRegistros.Text = "| " + grdDados.Rows.Count.ToString() + " registro(s) |";
    }

    private void CarregarCampanhas()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.PreencherDrop_Campanhas(dropCampanha, true, false, true, Usuario.IDUsuario, Usuario.Perfil);
    }

    protected void grdDados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Abrir")
        {
            int iIDMailing = Convert.ToInt32(grdDados.DataKeys[int.Parse((string)e.CommandArgument)]["Cód. Mailing"].ToString());

            mailing Mailing = new mailing();
            mailingCTL CMailing = new mailingCTL();

            Mailing = CMailing.RetornarMailing(iIDMailing);

            hddId.Value = Mailing.IDMailing.ToString();
            txtMailing.Text = Mailing.Mailing;
            radAtivo.SelectedValue = Convert.ToInt32(Mailing.Ativo).ToString();
            dropCampanha.SelectedValue = Mailing.IDCampanha.ToString();
        }
    }

    private void LimparCampos()
    {
        hddId.Value = null;
        txtMailing.Text = "";
        radAtivo.SelectedValue = "1";
        chkDuplicado.Checked = false;
        lblMensagem.Text = "";
       
        CarregarMailings();
    }

    private bool PodeSalvar()
    {
        if (String.IsNullOrEmpty(hddId.Value))
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Selecione algum [Mailing].", this.Page);
            return false;
        }
        if (txtMailing.Text.Trim() == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Nome].", this.Page);
            return false;
        }
        if (dropCampanha.SelectedValue == "-1")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Selecione [Campanha].", this.Page);
            return false;
        }
            
        return true;
    }

    private bool PodeImportar()
    {
        lblMensagem.Text = "";
        if (txtMailing.Text.Trim() == "")
        {
            lblMensagem.Text = "Preencha [Nome].";
            return false;
        }
        if (dropCampanha.SelectedValue == "-1")
        {
            lblMensagem.Text = "Selecione [Campanha].";
            return false;
        }
        mailingCTL CMailing = new mailingCTL();
        if (CMailing.VerificarExistenciaMailing(txtMailing.Text) == true)
        {
            lblMensagem.Text = "[Mailing] já existente. Escolha outro nome para o Mailing.";
            return false;
        }

        return true;
    }

    protected void grdDados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
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
        }
    }

    protected void cmdCancelar_Click(object sender, EventArgs e)
    {
        LimparCampos();
    }

    protected void cmdSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            string sMensagem = "";
            if (PodeSalvar())
            {
                usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];
                
                //Editar
                if (!String.IsNullOrEmpty(hddId.Value))
                {
                    mailing Mailing = new mailing();
                    Mailing.IDMailing = Convert.ToInt32(hddId.Value);
                    Mailing.Ativo = Convert.ToInt32(radAtivo.SelectedValue);

                    mailingCTL CMailing = new mailingCTL();
                    CMailing.EditarMailing(Mailing);                
                    
                    sMensagem = "Alterações salvas com sucesso!";                    
                }
                
                LimparCampos();
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            }
        }
        catch { }
    }

    protected void cmdImportar_Click(object sender, EventArgs e)
    {
        try
        {
            if (PodeImportar())
            {
                string sExtensao;
                string sEnderecoPasta = "~/mailing/";

                if (fileDocumento.PostedFile != null && fileDocumento.HasFile)
                {
                    string sFilePath;
                    string sFileName = fileDocumento.PostedFile.FileName;

                    sExtensao = sFileName.Substring(sFileName.Length - 4).ToLower();
                    if (sExtensao == ".xlsx")
                    {
                        sFilePath = MapPath(@sEnderecoPasta) + fileDocumento.FileName;
                        fileDocumento.SaveAs(MapPath(@sEnderecoPasta) + fileDocumento.FileName);
                        LeArquivo(sFilePath);
                    }
                    else
                        lblMensagem.Text = "Extensão do arquivo inválido!";
                }
                else
                    lblMensagem.Text = "Arquivo inválido!";
            }
        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }


        //try
        //{
        //    if (PodeImportar())
        //    {
        //        string sExtensao;
        //        string sEnderecoPasta = "~/mailing/";

        //        if (fileDocumento.PostedFile != null && fileDocumento.HasFile)
        //        {
        //            string sFilePath;
        //            string sFileName = fileDocumento.PostedFile.FileName;

        //            sExtensao = sFileName.Substring(sFileName.Length - 4).ToLower();
        //            if (sExtensao == ".txt")
        //            {
        //                sFilePath = MapPath(@sEnderecoPasta) + fileDocumento.FileName;
        //                fileDocumento.SaveAs(MapPath(@sEnderecoPasta) + fileDocumento.FileName);
        //                LeArquivo(sFilePath);
        //            }
        //            else
        //                lblMensagem.Text = "Extensão do arquivo inválido!";
        //        }
        //        else
        //            lblMensagem.Text = "Arquivo inválido!";
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblMensagem.Text = ex.Message;
        //}
    }

    private void LeArquivo(string sFileRetorno)
    {
        try
        {
            int iQtdeImportado = 0;
            int iQtdeRegistro = 0;
            string sMensagem;

            txtMailing.Text = "Mailing - " + DateTime.Now.ToString("ddMMyyyy HHmmss");

            OpenFileDialog FileDialog = new OpenFileDialog();
            DialogResult DialogResult;

            FileDialog.Title = "Abrir Como";
            FileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            DialogResult = FileDialog.ShowDialog();
            string sEnderecoCompletoArquivo = FileDialog.FileName;
            sArquivo = FileDialog.SafeFileName;
            //txtArquivo.Text = sEnderecoCompletoArquivo;


            if (string.IsNullOrEmpty(sEnderecoCompletoArquivo))
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("[Arquivo] inválido.", "Tabulare");
            }
            else
            {
                dataSetMailing = new DataSet();
                dataSetMailing = PontoBr.Banco.Excel.RetornarRegistrosExcel(sEnderecoCompletoArquivo);

                if (dataSetMailing.Tables.Count == 0)
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("Nenhum registro encontrado no arquivo!", "Tabulare");
                    return;
                }
                if (dataSetMailing.Tables[0].Columns[0].ColumnName == "Erro")
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(dataSetMailing.Tables[0].Rows[0]["Erro"].ToString(), "Tabulare");
                    return;
                }
                else
                {
                    grdMailingPlanilha.DataSource = dataSetMailing.Tables[0];
                    //grdMailingPlanilha.t = "Mailing - " + dataSetMailing.Tables[0].Rows.Count.ToString() + " registro(s)";

                }

                sMensagem = "Resumo da leitura do arquivo: \n";
                sMensagem += "================= \n";
                sMensagem += "Quantidade de registros do arquivo: " + dataSetMailing.Tables[0].Rows.Count.ToString() + "\n";
                sMensagem += "================= \n";
                sMensagem += "Clique no botão Importar para salvar os registros.";
                MessageBox.Show(sMensagem, "Tabulare");
            }
        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
        }
    }

    private prospect ImportarProspect(string[] sItem, int iIDMailing, string sImportarDuplicado)
    {
        prospect Prospect = new prospect();
        try
        {
            string sTelefone1 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[0].ToString().Trim());
            string sTelefone2 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[1].ToString().Trim());
            string sTelefone3 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[2].ToString().Trim());
            string sNome = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[3].ToString().Trim());
            string sCPF_CNPJ = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[4].ToString().Trim());
            string sLogradouro = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[5].ToString().Trim());
            string sNumero = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[6].ToString().Trim());
            string sComplemento = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[7].ToString().Trim());
            string sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[8].ToString().Trim());
            string sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[9].ToString().Trim());
            string sEstado = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[10].ToString().Trim());
            string sEmail = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[11].ToString().Trim());
            string sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[12].ToString().Trim());//rr

            string sCampo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[13].ToString().Trim());
            string sCampo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[14].ToString().Trim());
            string sCampo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[15].ToString().Trim());
            string sCampo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[16].ToString().Trim());
            string sCampo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[17].ToString().Trim());
            string sCampo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[18].ToString().Trim());
            string sCampo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[19].ToString().Trim());
            string sCampo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[20].ToString().Trim());
            string sCampo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[21].ToString().Trim());
            string sCampo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[22].ToString().Trim());

            Prospect.Telefone1 = Convert.ToDouble(sTelefone1);
            Prospect.Telefone2 = sTelefone2 == "" ? 0 : Convert.ToDouble(sTelefone2);
            Prospect.Telefone3 = sTelefone3 == "" ? 0 : Convert.ToDouble(sTelefone3);
            Prospect.Nome = sNome.Replace("'", "");
            Prospect.CPF_CNPJ = sCPF_CNPJ.Replace("'", "");
            Prospect.Logradouro = sLogradouro.Replace("'", "");
            Prospect.Numero = sNumero.Replace("'", "");
            Prospect.Complemento = sComplemento.Replace("'", "");
            Prospect.Bairro = sBairro.Replace("'", "");
            Prospect.Cidade = sCidade.Replace("'", "");
            Prospect.Estado = sEstado.Replace("'", "");
            Prospect.Email = sEmail.Replace("'", "");
            Prospect.Cep = sCep.Replace("'", "");

            Prospect.Campo01 = sCampo01.Replace("'", "");
            Prospect.Campo02 = sCampo02.Replace("'", "");
            Prospect.Campo03 = sCampo03.Replace("'", "");
            Prospect.Campo04 = sCampo04.Replace("'", "");
            Prospect.Campo05 = sCampo05.Replace("'", "");
            Prospect.Campo06 = sCampo06.Replace("'", "");
            Prospect.Campo07 = sCampo07.Replace("'", "");
            Prospect.Campo08 = sCampo08.Replace("'", "");
            Prospect.Campo09 = sCampo09.Replace("'", "");
            Prospect.Campo10 = sCampo10.Replace("'", "");

            Prospect.IDMailing = iIDMailing;
            Prospect.ImportarDuplicado = sImportarDuplicado;

            return Prospect;
        }
        catch (Exception ex)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(ex.Message, this.Page);
            return Prospect;
        }
    }

    private string RegistroValido(string[] sItem, prospect[] Prospects)
    {
        string sMotivo = "";

        if (sItem.Length != 23)
        {
            sMotivo = "Registro não possui 23 colunas";
            return sMotivo;
        }

        string sTelefone1 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[0].ToString().Trim());
        string sTelefone2 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[1].ToString().Trim());
        string sTelefone3 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[2].ToString().Trim());
        string sNome = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[3].ToString().Trim());
        string sCPF_CNPJ = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[4].ToString().Trim());
        string sLogradouro = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[5].ToString().Trim());
        string sNumero = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[6].ToString().Trim());
        string sComplemento = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[7].ToString().Trim());
        string sBairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[8].ToString().Trim());
        string sCidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[9].ToString().Trim());
        string sEstado = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[10].ToString().Trim());
        string sEmail = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[11].ToString().Trim());
        string sCep = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[12].ToString().Trim());

        string sCampo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[13].ToString().Trim());
        string sCampo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[14].ToString().Trim());
        string sCampo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[15].ToString().Trim());
        string sCampo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[16].ToString().Trim());
        string sCampo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[17].ToString().Trim());
        string sCampo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[18].ToString().Trim());
        string sCampo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[19].ToString().Trim());
        string sCampo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[20].ToString().Trim());
        string sCampo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[21].ToString().Trim());
        string sCampo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(sItem[22].ToString().Trim());

        double dTelefone1, dTelefone2, dTelefone3;

        //Telefone1////////////////////////////////////////////////////////
        //Verifica se o Telefone1 é numérico
        try
        {
            dTelefone1 = Convert.ToDouble(sTelefone1);
            sTelefone1 = dTelefone1.ToString();
        }
        catch
        {
            sMotivo = "[Telefone 1] não é numérico";
            return sMotivo;
        }

        //Verifica se o Telefone1 tem 10 ou 11 dígitos
        if (sTelefone1.Length != 10 && sTelefone1.Length != 11)
        {
            sMotivo = "[Telefone 1] não possui 10 ou 11 caracteres";
            return sMotivo;
        }
        //////////////////////////////////////////////////////////

        //Telefone2////////////////////////////////////////////////////////
        //Verifica se o Telefone2 é numérico
        try
        {
            if (sTelefone2 != "")
            {
                dTelefone2 = Convert.ToDouble(sTelefone2);
                sTelefone2 = dTelefone2.ToString();


                //Verifica se o Telefone2 tem 10 ou 11 dígitos
                if (sTelefone2.Length != 10 && sTelefone2.Length != 11)
                {
                    sMotivo = "[Telefone 2] não possui 10 ou 11 caracteres";
                    return sMotivo;
                }
            }
        }
        catch
        {
            sMotivo = "[Telefone 2] não é numérico";
            return sMotivo;
        }
        /////////////////////////////////////////////////////////////////////

        ////Telefone3////////////////////////////////////////////////////////
        //Verifica se o Telefone3 é numérico
        try
        {
            if (sTelefone3 != "")
            {
                dTelefone3 = Convert.ToDouble(sTelefone3);
                sTelefone3 = dTelefone3.ToString();

                //Verifica se o Telefone3 tem 10 ou 11 dígitos
                if (sTelefone3.Length != 10 && sTelefone3.Length != 11)
                {
                    sMotivo = "[Telefone 3] não possui 10 ou 11 caracteres";
                    return sMotivo;
                }
            }
        }
        catch
        {
            sMotivo = "[Telefone 3] não é numérico";
            return sMotivo;
        }

        /*Verifica se o telefone já existe no mesmo mailing*/
        for (int i = 0; i < Prospects.Length; i++)
        {
            if (Prospects[i] != null) /*Verifica se há prospect*/
            {
                if (Prospects[i].Telefone1 == dTelefone1)
                {
                    sMotivo = "[Telefone 1] já existe no mesmo mailing";
                    return sMotivo;
                }
            }
        }

        //Verifica se o tamanho do Nome é maior que 200
        if (sNome.Length >= 200)
        {
            sMotivo = "[Nome] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCPF_CNPJ.Length >= 50)
        {
            sMotivo = "[CPF / CNPJ] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sLogradouro.Length >= 200)
        {
            sMotivo = "[Logradouro] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sNumero.Length >= 50)
        {
            sMotivo = "[Número] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sComplemento.Length >= 50)
        {
            sMotivo = "[Complemento] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sBairro.Length >= 200)
        {
            sMotivo = "[Bairro] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCidade.Length >= 200)
        {
            sMotivo = "[Cidade] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sEstado.Length >= 200)
        {
            sMotivo = "[Estado] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sEmail.Length >= 200)
        {
            sMotivo = "[E-mail] possui mais de 200 caracteres";
            return sMotivo;
        }

        if (sCep.Length > 10)
        {
            sMotivo = "[CEP] possui mais de 10 caracteres";
            return sMotivo;
        }

        if (sCampo01.Length >= 200)
        {
            sMotivo = "[Campo 01] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo02.Length >= 200)
        {
            sMotivo = "[Campo 02] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo03.Length >= 200)
        {
            sMotivo = "[Campo 03] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo04.Length >= 200)
        {
            sMotivo = "[Campo 04] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo05.Length >= 200)
        {
            sMotivo = "[Campo 05] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo06.Length >= 200)
        {
            sMotivo = "[Campo 06] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo07.Length >= 200)
        {
            sMotivo = "[Campo 07] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo08.Length >= 200)
        {
            sMotivo = "[Campo 08] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo09.Length >= 200)
        {
            sMotivo = "[Campo 09] possui mais de 200 caracteres";
            return sMotivo;
        }
        if (sCampo10.Length >= 200)
        {
            sMotivo = "[Campo 10] possui mais de 200 caracteres";
            return sMotivo;
        }
        return sMotivo;
    }

    protected void chkAtivos_CheckedChanged(object sender, EventArgs e)
    {
        CarregarMailings();
    }

    protected void dropCampanha_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregarMailings();
    }
}
