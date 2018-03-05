using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.negocios;
using model.objetos;
using System.Web.UI.WebControls;

namespace controller
{
    public class relatorioCTL
    {
        public DataTable RetornarCampanhasMailing(int iIDMailing)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarCampanhasMailing(iIDMailing);
        }

        public DataSet RetornarContatosTrabalhadosSintetico(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento, string sIDStatus, int iAposUltimoResubmit)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarContatosTrabalhadosSintetico(sDataInicial, sDataFinal, iIDUsuario, iIDCampanha, iIDMailing, iIDTipoAtendimento, sIDStatus, iAposUltimoResubmit);
        }

        public DataTable RetornarContatosTrabalhadosDetalhado(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento, string sIDStatus)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarContatosTrabalhadosDetalhado(sDataInicial, sDataFinal, iIDUsuario, iIDCampanha, iIDMailing, iIDTipoAtendimento, sIDStatus);
        }

        public DataTable RetornarStatusMailing(int iIDMailing)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarStatusMailing(iIDMailing);
        }

        public DataTable RetornarContatosTrabalhadosOperador(int iIDUsuario, string sDataInicial, string sDataFinal)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarContatosTrabalhadosOperador(iIDUsuario, sDataInicial, sDataFinal);
        }

        public DataTable RetornarRespostasScript(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDPergunta, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarRespostasScript(sDataInicial, sDataFinal, iIDUsuario, iIDPergunta,iIDCampanha,iIDMailing, iIDTipoAtendimento);
        }               

        public DataTable RetornarConversaoDDD(string sDataInicial, string sDataFinal, int iIDUsuario)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarConversaoDDD(sDataInicial, sDataFinal, iIDUsuario);
        }

        public DataTable RetornarStatusProspectDDD(int iIDMailing)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarStatusProspectDDD(iIDMailing);
        }

        public DataTable RetornarGerarMailing(int iIDMailing, int iIDCampanha, int iIDStatus)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarGerarMailing(iIDMailing, iIDCampanha, iIDStatus);
        }

        public DataTable RetornarVendasSintetico(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDTipoAtendimento, int iIDStatusAuditoria)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarVendasSintetico(sDataInicial, sDataFinal, sIDCampanhas, iIDTipoAtendimento, iIDStatusAuditoria);
        }

        public DataTable RetornarDadosProspect(int iIDProspect)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarDadosProspect(iIDProspect);
        }

        public DataTable RetornarProspects(string sTelefone, string sNome, string sCPF_CNPJ, int iIDTipoAtendimento)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarProspects(sTelefone, sNome, sCPF_CNPJ, iIDTipoAtendimento);
        }

        public DataTable RetornarDadosVenda(string sDataInicial, string sDataFinal, string sIDCampanha, int iIDMailing, int iIDOperador, int iIDTipoAtendimento, int iIDStatusAuditoria, int iMailingInativos)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarDadosVenda(sDataInicial, sDataFinal, sIDCampanha, iIDMailing, iIDOperador, iIDTipoAtendimento, iIDStatusAuditoria, iMailingInativos);
        }

        public DataTable RetornarDadosVendas(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDUsuario, int iIDStatusAuditoria, string sCamposVenda, string sCamposProspect, string sTelefone1, string sNome, string sCPF_CNPJ, string chkCamposFixoProspect, string chkCamposFixoProspectCPFCNPJ, string chkCamposFixoProspectLogradouro, string chkCamposFixoProspectNumero, string chkCamposFixoProspectComplemento, string chkCamposFixoProspectBairro, string chkCamposFixoProspectCidade, string chkCamposFixoProspectEstado, string chkCamposFixoProspectEmail)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarDadosVendas(sDataInicial, sDataFinal, sIDCampanhas, iIDUsuario, iIDStatusAuditoria, sCamposVenda, sCamposProspect, sTelefone1, sNome, sCPF_CNPJ, chkCamposFixoProspect, chkCamposFixoProspectCPFCNPJ, chkCamposFixoProspectLogradouro, chkCamposFixoProspectNumero, chkCamposFixoProspectComplemento, chkCamposFixoProspectBairro, chkCamposFixoProspectCidade, chkCamposFixoProspectEstado, chkCamposFixoProspectEmail);
        }

        public DataTable RetornarDadosVenda(int iIDHistorico)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarDadosVenda(iIDHistorico);
        }

        public DataTable RetornarTopSemanal(int iIDCampanha)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarTopSemanal(iIDCampanha);
        }

        public DataTable RetornarTopSemanalPontuacao(int iIDCampanha)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarTopSemanalPontuacao(iIDCampanha);
        }

        public DataTable RetornarVendaMotoBoy(int iIDVendaMotoBoy)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarVendaMotoBoy(iIDVendaMotoBoy);
        }

        public DataTable RetornarExportacaoMailing(int iIDCampanha, int iIDMailing, string sIDStatus)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarExportacaoMailing(iIDCampanha, iIDMailing, sIDStatus);
        }

        public DataTable RetornarOperadoresCampanha()
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarOperadoresCampanha();
        }

        public DataTable RetornarVendasMensal()
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarVendasMensal();
        }

        public DataTable RetornarTabulacoesVendasMensal()
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarTabulacoesVendasMensal();
        }

        public DataTable RetornarProspectsDisponiveis()
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarProspectsDisponiveis();
        }

        public DataSet RetornarMidiasSintetico(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarMidiasSintetico(sDataInicial, sDataFinal, sIDCampanhas);
        }

        public DataSet RetornarMidiasDetalhado(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarMidiasDetalhado(sDataInicial, sDataFinal, sIDCampanhas);
        }

        public DataSet RetornarMidias(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarMidias(sDataInicial, sDataFinal, sIDCampanhas);
        }

        public DataTable RetornarDadosVendasBackoffice(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDUsuario, string sIDAuditoria, string sCamposVenda, string sCamposProspectFixo,
            string sCamposProspectExtra, string sTelefone1, string sNome, string sCPF_CNPJ, string sCampoDadosVenda, string sTextoDadosVenda, int iIDOperadorAuditoria)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, iIDUsuario, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, sTelefone1, sNome, sCPF_CNPJ, sCampoDadosVenda, sTextoDadosVenda, iIDOperadorAuditoria);
        }

        public DataTable RetornarVendasAuditoria(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarVendasAuditoria(sDataInicial, sDataFinal, sIDCampanhas);
        }

        public void RetornarGridContatosTrabalhadosOperador(GridView GridContatosTrabalhados, int iIDUsuario, string sDataInicial, string sDataFinal)//
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            DataTable dataTable = BRelatorio.RetornarGridContatosTrabalhadosOperador(iIDUsuario, sDataInicial, sDataFinal);

            GridContatosTrabalhados.DataSource = dataTable;
            GridContatosTrabalhados.DataBind();
        }

        public DataTable RetornarContatosOperadorNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarContatosOperadorNet(iIDParceiro, sDataInicial, sDataFinal);
        }

        public DataTable RetornarVendasOperadorNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarVendasOperadorNet(iIDParceiro, sDataInicial, sDataFinal);
        }

        public DataTable RetornarTratadasBackofficeNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarTratadasBackofficeNet(iIDParceiro, sDataInicial, sDataFinal);
        }

        public DataTable RetornarMailingTrabalhadoNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarMailingTrabalhadoNet(iIDParceiro, sDataInicial, sDataFinal);
        }

        public DataTable RetornarProspectsVirgens_dashboard(int iIDCampanha)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarProspectsVirgens_dashboard(iIDCampanha);
        }

        public DataSet RetornarVendas_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarVendas_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);
        }

        public DataSet RetornarContatosOperadores_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarContatosOperadores_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);
        }

        public DataSet RetornarStatusContatos_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarStatusContatos_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);
        }

        public DataTable RetornarContatosTrabalhadosDetalhado(string sDataInicial, string sDataFinal, int iIDUsuario, string sIDCampanhas, string sIDMailing, int iIDTipoAtendimento, string sIDStatus)//r
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarContatosTrabalhadosDetalhado(sDataInicial, sDataFinal, iIDUsuario, sIDCampanhas, sIDMailing, iIDTipoAtendimento, sIDStatus);
        }

        public DataTable RetornarQuantitativoDadosVenda(int iIDOperador, int iIDCampanha, string sIDStatusAuditoria, string sDataInicial, string sDataFinal, string[] sColunas)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarQuantitativoDadosVenda(iIDOperador, iIDCampanha, sIDStatusAuditoria, sDataInicial, sDataFinal, sColunas);
        }
        
        public DataTable RetornarObservacoesVenda(int iIDvenda)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarObservacoesVenda(iIDvenda);
        }

        public DataSet RetornarDashboard(int iIDCampanha)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarDashboard(iIDCampanha);
        }

        public DataTable RetornarVenda(int iIDHistorico)
        {
            relatorioBLL BRelatorio = new relatorioBLL();
            return BRelatorio.RetornarVenda(iIDHistorico);
        }
    }
}
