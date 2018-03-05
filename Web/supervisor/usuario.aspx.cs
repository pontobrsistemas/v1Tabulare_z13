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

public partial class supervisor_usuario : App_Code.BaseWeb 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!usuarioCTL.PermitirAcesso("Supervisor")) Response.Redirect("../login/logout.aspx?e=logout");
        
        if (!IsPostBack)
        {
            CarregarCampanhas();
            CarregarPerfis();
            CarregarUsuarios();
        }

        //Senha
        if (txtSenha.Text != "") ViewState["senha"] = txtSenha.Text;
        if (ViewState["senha"] != null) txtSenha.Attributes.Add("value", ViewState["senha"].ToString()); 
    }

    private void CarregarUsuarios()
    {
        usuarioCTL CUsuario = new usuarioCTL();
        CUsuario.CarregarGridviewUsuarios(Convert.ToBoolean(CheckBoxUsuariosAtivos.Checked), gridUsuario);

        int iNumeroOperadoresAtivo = CUsuario.RetornarQuantidadeOperadores();
        lblUsuariosAtivos.Text = "| " + iNumeroOperadoresAtivo.ToString() + " operador(es) ativo(s) |";
    }

    private void CarregarCampanhas()
    {
        usuario Usuario = (usuario)HttpContext.Current.Session["Usuario"];

        campanhaCTL CCampanha = new campanhaCTL();
        CCampanha.CarregarCampanhasAtivasCheckBoxList(chkCampanha, Usuario.IDUsuario, Usuario.Perfil);
    }

    private void CarregarPerfis()
    {
        usuarioCTL CUsuario = new usuarioCTL();
        CUsuario.CarregarRadioButtonListPerfis(radPerfil);

        radPerfil.Items.RemoveAt(0);
    }

    protected void gridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Abrir")
        {
            int iIDUsuario = Convert.ToInt32(gridUsuario.DataKeys[int.Parse((string)e.CommandArgument)]["Cód. Usuário"].ToString());

            usuario Usuario = new usuario();
            usuarioCTL CUsuario = new usuarioCTL();

            Usuario = CUsuario.RetornarUsuario(iIDUsuario);

            hddId.Value = Usuario.IDUsuario.ToString();
            txtNome.Text = Usuario.Nome;
            txtLogin.Text = Usuario.Login;
            txtSenha.Attributes.Add("value", Usuario.Senha);
            radAtivo.SelectedValue = Convert.ToInt32(Usuario.Ativo).ToString();
            radPerfil.SelectedValue = Usuario.IDPerfil.ToString();
            
            //Desmarca todas as campanhas
            foreach (ListItem listItem in chkCampanha.Items)
            {
                listItem.Selected = false;
            }

            //Carregar campanhas do usuários
            DataTable dataTable = CUsuario.RetornarCampanhasUsuario(Usuario.IDUsuario);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (ListItem listItem in chkCampanha.Items)
                {
                    if (dataRow["IDCampanha"].ToString() == listItem.Value)
                        listItem.Selected = true;
                }
            }
            txtNome.Focus();
        }
    }

    private void LimparCampos()
    {
        hddId.Value = null;
        txtNome.Text = "";
        txtLogin.Text = "";
        txtSenha.Attributes.Add("value", "");
        radAtivo.SelectedValue = "1";
        radPerfil.SelectedValue = "2";

        foreach (ListItem listItem in chkCampanha.Items)
        {
            listItem.Selected = false;
        }
        CarregarUsuarios();
    }

    private bool PodeSalvar()
    {
        if (txtNome.Text.Trim() == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Nome].", this.Page);
            return false;
        }
        if (txtLogin.Text.Trim() == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Login].", this.Page);
            return false;
        }
        if (txtSenha.Text.Trim() == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Preencha [Senha].", this.Page);
            return false;
        }
        if (radPerfil.SelectedValue == "")
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Selecione [Perfil].", this.Page);
            return false;
        }

        bool bCampanhaSelecionada = false;
        foreach (ListItem listItem in chkCampanha.Items)
        {
            if (listItem.Selected)
                bCampanhaSelecionada = true;
        }
        if (bCampanhaSelecionada == false)
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("Selecione, pelo menos, uma [Campannha].", this.Page);
            return false;
        }

        int iIDUsuario = String.IsNullOrEmpty(hddId.Value) ? -1 : Convert.ToInt32(hddId.Value);
        usuarioCTL CUsuario = new usuarioCTL();
        if (CUsuario.VerificarExistenciaUsuario(txtLogin.Text.Trim(), iIDUsuario))
        {
            PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager("[Login] já cadastrado.", this.Page);
            return false;
        }        
        return true;
    }

    protected void gridUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
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

            //Obs: Não existia a linha: e.Row.Cells[3].Text == "Supervisor" - foi adicionado para listar as campanhas do Supervisor
            if (e.Row.Cells[3].Text == "Operador" || e.Row.Cells[3].Text == "BackOffice" || e.Row.Cells[3].Text == "Supervisor")
            {
                int iIDUsuario = Convert.ToInt32(gridUsuario.DataKeys[e.Row.RowIndex].Values[0].ToString());
                string sCampanha = "";

                usuarioCTL CUsuario = new usuarioCTL();
                DataTable dataTable = CUsuario.RetornarCampanhasUsuario(iIDUsuario);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    sCampanha += sCampanha != "" ? "; " + dataRow["Campanha"].ToString() : dataRow["Campanha"].ToString();
                }
                e.Row.Cells[3].Text = sCampanha == "" ? "-" : sCampanha;
            }
            else
            {
                e.Row.Cells[3].Text = "-";
            }                
        }
    }

    protected void bTnTodos_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
            this.chkCampanha.Items[i].Selected = true;
    }

    protected void bTnNenhum_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.chkCampanha.Items.Count; ++i)
            this.chkCampanha.Items[i].Selected = false;
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
                usuario UsuarioCadastro = (usuario)HttpContext.Current.Session["Usuario"];
                
                usuario Usuario = new usuario();
                usuarioCTL CUsuario = new usuarioCTL();

                Usuario.Nome = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome.Text);
                Usuario.Login = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtLogin.Text);
                Usuario.Senha = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtSenha.Text);
                Usuario.Ativo = Convert.ToInt32(radAtivo.SelectedValue);
                Usuario.IDPerfil = Convert.ToInt32(radPerfil.SelectedValue);

                //Editar
                if (!String.IsNullOrEmpty(hddId.Value))
                {
                    Usuario.IDUsuario = Convert.ToInt32(hddId.Value);                    

                    //Editar dados da tabela de Usuário
                    CUsuario.EditarUsuario(Usuario);
                    //Exclui todas as campanhas do usuário
                    CUsuario.ExcluirUsuarioCampanhas(Usuario.IDUsuario);
                    foreach (ListItem listItem in chkCampanha.Items) 
                    {
                        if (listItem.Selected)
                            CUsuario.CadastrarUsuarioCampanhas(Usuario.IDUsuario, Convert.ToInt32(listItem.Value));
                    }

                    sMensagem = "Alterações salvas com sucesso!";                    
                }
                else //Salvar novo
                {
                    int iIDUsuario = Convert.ToInt32(CUsuario.CadastrarUsuario(Usuario, UsuarioCadastro.IDUsuario));
                    foreach (ListItem listItem in chkCampanha.Items)
                    {
                        if (listItem.Selected)
                            CUsuario.CadastrarUsuarioCampanhas(iIDUsuario, Convert.ToInt32(listItem.Value));
                    }
                    sMensagem = "Usuário salvo com sucesso!";    
                }
                LimparCampos();
                CarregarUsuarios();
                PontoBr.Utilidades.Diversos.ExibirAlertaScriptManager(sMensagem, this.Page);
            }
        }
        catch { }
    }

    protected void CheckBoxUsuariosAtivos_CheckedChanged(object sender, EventArgs e)
    {
        CarregarUsuarios();
    }
}
