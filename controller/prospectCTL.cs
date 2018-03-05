using System;
using System.Collections.Generic;
using System.Text;
using model.negocios;
using model.objetos;
using System.Data;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


namespace controller
{
    public class prospectCTL
    {
        public void ImportarProspect(prospect[] Prospects)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.ImportarProspect(Prospects);
        }

        public prospect RetornarProximoProspectPower(usuario Usuario)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarProximoProspectPower(Usuario);
        }

        public prospect RetornarProximoProspectPreditivo(int iIDCampanha, int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarProximoProspectPreditivo(iIDCampanha, iIDUsuario);
        }

        public prospect RetornarProspect(int iIDProspect, int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarProspect(iIDProspect, iIDUsuario);
        }

        public prospect RetornarProspect(int iIDProspect)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarProspect(iIDProspect);
        }

        public DataTable RetornarHistoricoContato(double dTelefone1, int iIDMailing, int iScript)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarHistoricoContato(dTelefone1, iIDMailing, iScript);
        }

        public string RetornarQtdeProspectMailing(int iIDMailing)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarQtdeProspectMailing(iIDMailing);
        }

        public int RetornarIDProspect(int iIDHistorico)
        {
            prospectBLL BProspect = new prospectBLL();
            return Convert.ToInt32(BProspect.RetornarIDProspect(iIDHistorico));
        }

        public DataTable RetornarBloqueiosDDD(int iIDCampanha)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarBloqueiosDDD(iIDCampanha);
        }

        public void AtualizarBloqueioDDD(int iBloqueio, int iDDD, int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.AtualizarBloqueioDDD(iBloqueio, iDDD, iIDUsuario);
        }

        public DataTable RetornarPerguntaResposta(int iIDHistorico)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarPerguntaResposta(iIDHistorico);
        }

        public void AtualizarDadosProspect(prospect Prospect, bool bAgendamento)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.AtualizarDadosProspect(Prospect, bAgendamento);
        }

        public void ExecutarResubmit(int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.ExecutarResubmit(iIDUsuario);
        }

        public DataTable RetornarAgendamentoOperador(int iIDUsuario, int iIDCampanha)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarAgendamentoOperador(iIDUsuario, iIDCampanha);
        }

        public void CadastrarBloqueioDDD(int iDDD, int iIDUsuario, int iIDCampanha)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.CadastrarBloqueioDDD(iDDD, iIDUsuario, iIDCampanha);
        }

        public void ExcluirBloqueioDDD(int iDDD, int iIDCampanha)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.ExcluirBloqueioDDD(iDDD, iIDCampanha);
        }

        public void ExcluirBloqueioDDD(int iIDCampanha)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.ExcluirBloqueioDDD(iIDCampanha);
        }

        public int CadastrarIndicacao(prospect Prospect)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.CadastrarIndicacao(Prospect);
        }

        public int RetornarQuantidadeAgendamentoOperador(int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarQuantidadeAgendamentoOperador(iIDUsuario);
        }

        public void PreencherComboBox_Midias(ComboBox comboMidias)
        {
            prospectBLL BProspect = new prospectBLL();
            DataTable dataTable = BProspect.RetornarMidias();

            PontoBr.Utilidades.WCL.CarregarComboBox(comboMidias, dataTable, "IDMidia", "Midia", false, true);
        }

        public void PreencherDropMidias(DropDownList dropMidias)//r
        {
            prospectBLL BProspect = new prospectBLL();
            string sSql = BProspect.RetornarDropMidias();

            PontoBr.Utilidades.WCL.CarregarDropDown(dropMidias, sSql, "Midia", "IDMidia", false, true);
        }

        public void InserirProspectTemporiamenteResubmit(string sIDStatus, int iIDMailing, string sDataInicial, string sDataFinal, int iIDOperador, string sBairro, string sCidade, string sCep)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.InserirProspectTemporiamenteResubmit(sIDStatus, iIDMailing, sDataInicial, sDataFinal, iIDOperador, sBairro, sCidade, sCep);
        }

        public void LimparTabelaTemporariaResubmit()
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.LimparTabelaTemporariaResubmit();
        }

        public int RetornarQuantidadeResubmit()
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarQuantidadeResubmit();
        }

        public double VerificarExistenciaTelefone(double dTelefone1, double dTelefone2, double dTelefone3)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.VerificarExistenciaTelefone(dTelefone1, dTelefone2, dTelefone3);
        }

        public DataTable RetornarUsuarioAgendamento(int iIDProspect)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarUsuarioAgendamento(iIDProspect);
        }

        public void AtualizarUsuarioAgendamento(int iIDProspectAgendamento, int iIDUsuarioAgendamento, int iIDStatusAgendamento)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.AtualizarUsuarioAgendamento(iIDProspectAgendamento, iIDUsuarioAgendamento, iIDStatusAgendamento);
        }

        public void LiberarProspectEmUso(int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.LiberarProspectEmUso(iIDUsuario);
        }

        public DataTable RetornarProspectsVirgens(int iIDMailing)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarProspectsVirgens(iIDMailing);
        }

        public DataTable RetornarProspectsResubmit(int iIDMailing)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarProspectsResubmit(iIDMailing);
        }

        public void CadastrarProspectEnviadoPreditivo(int iIDProspect)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.CadastrarProspectEnviadoPreditivo(iIDProspect);
        }

        //Mundiale Barrar a venda de um mesmo produto para o mesmo cliente no intervalo menor que 1 ano
        public DataTable RetornarUltimaVendaMundiale(string sCPF_CNPJ)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarUltimaVendaMundiale(sCPF_CNPJ);
        }

        public DataTable RetornarConsultaCEP(string sCEP)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarConsultaCEP(sCEP);
        }

        //Robson Mundiale - Campo observação Mundiale
        //public DataTable RetornarProspectObservacaoMundiale(int iIDProspect, int iIDUsuario)
        //{
        //    prospectBLL BProspect = new prospectBLL();
        //    return BProspect.RetornarProspectObservacaoMundiale(iIDProspect, iIDUsuario);
        //}

        //Rafael
        public void RetornaComboProdutos(ComboBox comboProduto, string tipo)
        {
            prospectBLL BProspect = new prospectBLL();
            DataTable dt = BProspect.RetornaProdutos(tipo);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboProduto, dt, "id", "nome", false, true);
        }

        public int ExecutarResubmitCallFlex(int iIDUsuario, int iIDMailing, string sIDStatus)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.ExecutarResubmitCallFlex(iIDUsuario, iIDMailing, sIDStatus);
        }

        public DataTable RetornarCuros(string sNomeCurso)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarCuros(sNomeCurso);
        }

        public void PreencherComboBox_Cursos(ComboBox comboNomeCurso,int iIDCampanha, bool bTodos, bool bSelecione)
        {
            prospectBLL BProspect = new prospectBLL();
            DataTable dataTable = BProspect.PreencherComboBox_Cursos(iIDCampanha);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboNomeCurso, dataTable, "IDCurso", "NomeCurso", bTodos, bSelecione);
        }

        public void CadastrarProspectInvalido(string sProspect, string sMotivo, int iIDMailing)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.CadastrarProspectInvalido(sProspect, sMotivo, iIDMailing);
        }

        public DataTable RetornarProspectsInvalido(int iIDMailing) 
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarProspectsInvalido(iIDMailing);
        }

        public void CadastrarProspectInvalidoLista(ArrayList ListaInvalidos)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.CadastrarProspectInvalidoLista(ListaInvalidos);
        }

        public void CadastrarBlackList(double dTelefone, int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.CadastrarBlackList(dTelefone, iIDUsuario);
        }

        public DataTable RetornarBlackList()
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarBlackList();
        }

        public bool VerificarTelefoneBlackList(double dTelefone)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.VerificarTelefoneBlackList(dTelefone);
        }

        public void ExcluirTelefoneBlackList(double dTelefone)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.ExcluirTelefoneBlackList(dTelefone);
        }

        public int SalvarContato(contato Contato)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.SalvarContato(Contato);
        }

        public int SalvarContatoConecctta(contato Contato)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.SalvarContatoConecctta(Contato);
        }

        public void SalvarContato(contato[] Contatos)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.SalvarContato(Contatos);
        }

        public void SalvarRespostasContato(int iIDPergunta, int iIDResposta, int iIDHistorico)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.SalvarRespostasContato(iIDPergunta, iIDResposta, iIDHistorico);
        }

        public bool VerificarExistenciaVenda(int iIDHistorico)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.VerificarExistenciaVenda(iIDHistorico);
        }

        public int SalvarDadosVenda(int iIDHistorico, prospect Prospect)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.SalvarDadosVenda(iIDHistorico, Prospect);
        }

        public void AtualizarDadosVenda(int iIDVenda, prospect Prospect)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.AtualizarDadosVenda(iIDVenda, Prospect);
        }

        public void AtualizarHistorico(int iIDHistorico, string sDataCadastro, string sObservacao)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.AtualizarHistorico(iIDHistorico, sDataCadastro, sObservacao);
        }

        public void AtualizarHistorico(int iIDHistorico, string sObservacao)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.AtualizarHistorico(iIDHistorico, sObservacao);
        }

        public void PegarVendaParaAuditarBackoffice(int iIDHistorio, int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.PegarVendaParaAuditarBackoffice(iIDHistorio, iIDUsuario);
        }

        public string VerificarVendaSendoAuditadaBackoffice(int iIDHistorio, int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.VerificarVendaSendoAuditadaBackoffice(iIDHistorio, iIDUsuario);
        }

        public void CarregarGridviewBlackList(GridView dgDados)//r
        {
            prospectBLL BProspect = new prospectBLL();
            DataTable dataTable = BProspect.RetornarBlackList();

            dgDados.DataSource = dataTable;
            dgDados.DataBind();
        }

        public void RetornarGridViewBloqueiosDDD(GridView dgDDD, int iIDCampanha)
        {
            prospectBLL BProspect = new prospectBLL();
            DataTable dataTable = BProspect.RetornarBloqueiosDDD(iIDCampanha);

            dgDDD.DataSource = dataTable;
            dgDDD.DataBind();
        }

        public void ExcluirMailing(int iIDMailing)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.ExcluirMailing(iIDMailing);
        }

        public int RetornarHistoricoVenda(int iIDProspect)
        {
            prospectBLL BProspect = new prospectBLL();
            return BProspect.RetornarHistoricoVenda(iIDProspect);
        }

        public void CadastrarLogAuditoria(int iIDHistorico, int iIDBackoffice, string sCampo, string sDe, string sPara, string sDNS)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.CadastrarLogAuditoria(iIDHistorico, iIDBackoffice, sCampo, sDe, sPara, sDNS);
        }

        public void EnviarObservacaoTratamentoVenda(int iIDVenda, int iIDUsuario, string sObservacao, int iRemetente)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.EnviarObservacaoTratamentoVenda(iIDVenda, iIDUsuario, sObservacao, iRemetente);
        
        }
        public void AtualizarLeituraTratamentoVenda(int iIDVenda, int iIDTratamento, int iIDUsuario)
        {
            prospectBLL BProspect = new prospectBLL();
            BProspect.AtualizarLeituraTratamentoVenda(iIDVenda, iIDTratamento, iIDUsuario);
        }


        //public DataTable RetornarMensagensTratamentoVenda(int iIDUsuario, string sPerfil)
        //{
        //    prospectBLL BProspect = new prospectBLL();
        //    DataTable dataTable = BProspect.RetornarMensagensTratamentoVenda(iIDUsuario, sPerfil);
        //    return dataTable;
        //}

        public DataTable RetornarMensagensTratamentoVenda(int iIDUsuario, string sPerfil)
        {
            prospectBLL BProspect = new prospectBLL();
            DataTable dataTable = BProspect.RetornarMensagensTratamentoVenda(iIDUsuario, sPerfil);
            return dataTable;
        }

        public DataTable RetornarMensagensTratamentoVendaBackoffice(int iIDUsuario, string sPerfil)
        {
            prospectBLL BProspect = new prospectBLL();
            DataTable dataTable = BProspect.RetornarMensagensTratamentoVendaBackoffice(iIDUsuario, sPerfil);
            return dataTable;
        }
    }
}
