using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using model.negocios;
using model.objetos;
using System.Web.UI.WebControls;
using System.Web;

namespace controller
{
    public class usuarioCTL
    {
        //Variável usada para testar sistemas 
        public static bool bTestandoSistema = true;
        
        public int RetornarUsuario(string sLogin, string sSenha, int iAtivo)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarUsuario(sLogin, sSenha, iAtivo);
        }

        public usuario RetornarUsuario(string sLogin, string sSenha, string sRamal)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarUsuario(sLogin, sSenha, sRamal);
        }

        public DataTable RetornarUsuarios(bool bSomenteAtivo)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarUsuarios(bSomenteAtivo);
        }

        public string RetornarSenha(int iIDUsuario)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarSenha(iIDUsuario);
        }

        public void EditarUsuario(usuario Usuario)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.EditarUsuario(Usuario);
        }

        public void ExcluirUsuarioCampanhas(int iIDUsuario)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.ExcluirUsuarioCampanhas(iIDUsuario);
        }

        public string CadastrarUsuario(usuario Usuario, int iIDUsuarioCadastro)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.CadastrarUsuario(Usuario, iIDUsuarioCadastro);
        }

        public void CadastrarUsuarioCampanhas(int iIDUsuario, string sCampanha)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.CadastrarUsuarioCampanhas(iIDUsuario, sCampanha);
        }

        public void CadastrarUsuarioCampanhas(int iIDUsuario, int iIDCampanha)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.CadastrarUsuarioCampanhas(iIDUsuario, iIDCampanha);
        }

        public void PreencherComboBox_Operadores(ComboBox comboOperador)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            DataTable dataTable = BUsuario.RetornarOperadores();

            PontoBr.Utilidades.WCL.CarregarComboBox(comboOperador, dataTable, "IDUsuario", "Nome", false, true);
        }

        public void PreencherComboBox_Operadores(ComboBox comboOperador, bool bTodos, bool bSelecione)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            DataTable dataTable = BUsuario.RetornarOperadores();

            PontoBr.Utilidades.WCL.CarregarComboBox(comboOperador, dataTable, "IDUsuario", "Nome", bTodos, bSelecione);
        }

        public void PreencherDrop_Operadores(DropDownList DropOperador, bool bTodos, bool bSelecione)//r
        {
            usuarioBLL BUsuario = new usuarioBLL();
            string sSql = BUsuario.RetornarDropOperadores();

            PontoBr.Utilidades.WCL.CarregarDropDown(DropOperador, sSql, "Nome", "IDUsuario", bTodos, bSelecione);
        }

        public bool ValidarSenhaSupervisor(string sSenha)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.ValidarSenhaSupervisor(sSenha);
        }

        public void PreencherComboBox_Supervisores(ComboBox comboSupervisor, bool bTodos, bool bSelecione)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            DataTable dataTable = BUsuario.RetornarSupervisores();

            PontoBr.Utilidades.WCL.CarregarComboBox(comboSupervisor, dataTable, "IDUsuario", "Nome", bTodos, bSelecione);
        }

        public int RetornarQuantidadeOperadores()
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarQuantidadeOperadores();
        }

        public bool VerificarSenhaAtual(int iIDUsuario, string sSenha)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.VerificarSenhaAtual(iIDUsuario, sSenha);
        }

        public void AlterarSenha(int iIDUsuario, string sSenha)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.AlterarSenha(iIDUsuario, sSenha);
        }

        public void AtualizarNroAgente(int iIDUsuario, int iNroAgente)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.AtualizarNroAgente(iIDUsuario, iNroAgente);
        }

        public DataTable RetornarCampanhasUsuario(int iIDUsuario)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarCampanhasUsuario(iIDUsuario);
        }

        public usuario RetornarUsuario(int iIDUsuario)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarUsuario(iIDUsuario);
        }

        public void PausaAgente(int iIDUsuario, int iPausaAgente)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.PausaAgente(iIDUsuario, iPausaAgente);
        }

        public void TabulareLogado(int iIDUsuario, int iTabulareLogado)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            BUsuario.TabulareLogado(iIDUsuario, iTabulareLogado);
        }

        public int RetornarClientAtivos()
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarClientAtivos();
        }

        public bool RetornarNroAgentesRepetidos(int iIDUsuario, int iNroAgente)//robson
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarNroAgentesRepetidos(iIDUsuario, iNroAgente);
        }               

        public usuario RetornarUsuarioNet(string sEmail, string sSenha)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.RetornarUsuarioNet(sEmail, sSenha);
        }

        public void CarregarDropdownParceirosNet(DropDownList dropParceiro)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            string sSql = BUsuario.RetornarParceirosNet();

            PontoBr.Utilidades.WCL.CarregarDropDown(dropParceiro, sSql, "Parceiro", "IDParceiro", true, false);
        }

        public void CarregarRadioButtonListPerfis(RadioButtonList radPerfil)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            string sSql = BUsuario.RetornarPerfis();

            PontoBr.Utilidades.WCL.CarregarRadioButtonList(radPerfil, sSql, "Perfil", "IDPerfil");
        }

        public void CarregarGridviewUsuarios(bool bSomenteAtivo, GridView grdDados)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            DataTable dataTable = BUsuario.RetornarUsuarios(bSomenteAtivo);

            grdDados.DataSource = dataTable;
            grdDados.DataBind();
        }

        public static bool PermitirAcesso(string sPerfisComPermissaoDeAcesso)
        {
            //Se não tiver a sessão como autenticado, já desloga o usuário do sistema
            if (HttpContext.Current.Session["Usuario"] == null)
                return false;

            bool bPermiteAcesso = false;

            usuario Usuario = new usuario();
            Usuario = (usuario)HttpContext.Current.Session["Usuario"];

            string[] sPerfisAcesso = sPerfisComPermissaoDeAcesso.Split('|');
            foreach (string sPerfilAcesso in sPerfisAcesso)
            {
                if (sPerfilAcesso.Trim().Replace("\r\n", "") == Usuario.Perfil)
                    bPermiteAcesso = true;
            }

            return bPermiteAcesso;
        }

        public bool VerificarExistenciaUsuario(string sLogin, int iIDUsuario)
        {
            usuarioBLL BUsuario = new usuarioBLL();
            return BUsuario.VerificarExistenciaUsuario(sLogin, iIDUsuario);
        }
    }
}