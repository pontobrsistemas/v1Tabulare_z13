using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.dados;

namespace model.negocios
{
    public class relatorioBLL
    {
        public DataTable RetornarCampanhasMailing(int iIDMailing)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarCampanhasMailing(iIDMailing);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataSet RetornarContatosTrabalhadosSintetico(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento, string sIDStatus, int iAposUltimoResubmit)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarContatosTrabalhadosSintetico(sDataInicial, sDataFinal, iIDUsuario, iIDCampanha, iIDMailing, iIDTipoAtendimento, sIDStatus, iAposUltimoResubmit);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataTable RetornarContatosTrabalhadosDetalhado(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento, string sIDStatus)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarContatosTrabalhadosDetalhado(sDataInicial, sDataFinal, iIDUsuario, iIDCampanha, iIDMailing, iIDTipoAtendimento, sIDStatus);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarStatusMailing(int iIDMailing)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarStatusMailing(iIDMailing);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarContatosTrabalhadosOperador(int iIDUsuario, string sDataInicial, string sDataFinal)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarContatosTrabalhadosOperador(iIDUsuario, sDataInicial, sDataFinal);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarRespostasScript(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDPergunta, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarRespostasScript(sDataInicial, sDataFinal, iIDUsuario, iIDPergunta, iIDCampanha, iIDMailing, iIDTipoAtendimento);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }        

        public DataTable RetornarConversaoDDD(string sDataInicial, string sDataFinal, int iIDUsuario)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarConversaoDDD(sDataInicial, sDataFinal, iIDUsuario);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarStatusProspectDDD(int iIDMailing)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarStatusProspectDDD(iIDMailing);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarGerarMailing(int iIDMailing, int iIDCampanha, int iIDStatus)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarGerarMailing(iIDMailing, iIDCampanha, iIDStatus);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarVendasSintetico(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDTipoAtendimento, int iIDStatusAuditoria)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarVendasSintetico(sDataInicial, sDataFinal, sIDCampanhas, iIDTipoAtendimento, iIDStatusAuditoria);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarDadosProspect(int iIDProspect)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarDadosProspect(iIDProspect);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarProspects(string sTelefone, string sNome, string sCPF_CNPJ, int iIDTipoAtendimento)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarProspects(sTelefone, sNome, sCPF_CNPJ, iIDTipoAtendimento);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarDadosVenda(string sDataInicial, string sDataFinal, string sIDCampanha, int iIDMailing, int iIDOperador, int iIDTipoAtendimento, int iIDStatusAuditoria, int iMailingInativos)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarDadosVenda(sDataInicial, sDataFinal, sIDCampanha, iIDMailing, iIDOperador, iIDTipoAtendimento, iIDStatusAuditoria, iMailingInativos);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarDadosVendas(string DataInicial, string DataFinal, string sIDCampanhas, int iIDUsuario, int iIDStatusAuditoria, string sCamposVenda, string sCamposProspect, string sTelefone1, string sNome, string sCPF_CNPJ, string chkCamposFixoProspect, string chkCamposFixoProspectCPFCNPJ, string chkCamposFixoProspectLogradouro, string chkCamposFixoProspectNumero, string chkCamposFixoProspectComplemento, string chkCamposFixoProspectBairro, string chkCamposFixoProspectCidade, string chkCamposFixoProspectEstado, string chkCamposFixoProspectEmail)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarDadosVendas(DataInicial, DataFinal, sIDCampanhas, iIDUsuario, iIDStatusAuditoria, sCamposVenda, sCamposProspect, sTelefone1, sNome, sCPF_CNPJ, chkCamposFixoProspect, chkCamposFixoProspectCPFCNPJ, chkCamposFixoProspectLogradouro, chkCamposFixoProspectNumero, chkCamposFixoProspectComplemento, chkCamposFixoProspectBairro, chkCamposFixoProspectCidade, chkCamposFixoProspectEstado, chkCamposFixoProspectEmail);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarDadosVenda(int iIDHistorico)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarDadosVenda(iIDHistorico);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarTopSemanal(int iIDCampanha)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarTopSemanal(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarTopSemanalPontuacao(int iIDCampanha)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarTopSemanalPontuacao(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarVendaMotoBoy(int iIDVendaMotoBoy)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarVendaMotoBoy(iIDVendaMotoBoy);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarExportacaoMailing(int iIDCampanha, int iIDMailing, string sIDStatus)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarExportacaoMailing(iIDCampanha, iIDMailing, sIDStatus);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarOperadoresCampanha()
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarOperadoresCampanha();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarVendasMensal()
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarVendasMensal();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarTabulacoesVendasMensal()
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarTabulacoesVendasMensal();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarProspectsDisponiveis()
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarProspectsDisponiveis();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataSet RetornarMidiasSintetico(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarMidiasSintetico(sDataInicial, sDataFinal, sIDCampanhas);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataSet RetornarMidiasDetalhado(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarMidiasDetalhado(sDataInicial, sDataFinal, sIDCampanhas);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataSet RetornarMidias(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarMidias(sDataInicial, sDataFinal, sIDCampanhas);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataTable RetornarDadosVendasBackoffice(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDUsuario, string sIDAuditoria, string sCamposVenda,
            string sCamposProspectFixo, string sCamposProspectExtra, string sTelefone1, string sNome, string sCPF_CNPJ, string sCampoDadosVenda, string sTextoDadosVenda, int iIDOperadorAuditoria)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarDadosVendasBackoffice(sDataInicial, sDataFinal, sIDCampanhas, iIDUsuario, sIDAuditoria, sCamposVenda, sCamposProspectFixo, sCamposProspectExtra, sTelefone1, sNome, sCPF_CNPJ, sCampoDadosVenda, sTextoDadosVenda, iIDOperadorAuditoria);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarVendasAuditoria(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarVendasAuditoria(sDataInicial, sDataFinal, sIDCampanhas);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarGridContatosTrabalhadosOperador(int iIDUsuario, string sDataInicial, string sDataFinal)//
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarGridContatosTrabalhadosOperador(iIDUsuario, sDataInicial, sDataFinal);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
            return dataTable;
        }

        public DataTable RetornarContatosOperadorNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarContatosOperadorNet(iIDParceiro, sDataInicial, sDataFinal);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarVendasOperadorNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarVendasOperadorNet(iIDParceiro, sDataInicial, sDataFinal);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarTratadasBackofficeNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarTratadasBackofficeNet(iIDParceiro, sDataInicial, sDataFinal);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarMailingTrabalhadoNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarMailingTrabalhadoNet(iIDParceiro, sDataInicial, sDataFinal);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarProspectsVirgens_dashboard(int iIDCampanha)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarProspectsVirgens_dashboard(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataSet RetornarVendas_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarVendas_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataSet RetornarContatosOperadores_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarContatosOperadores_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataSet RetornarStatusContatos_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarStatusContatos_dashboard(iIDCampanha, sDataInicial, sDataFinal, bTop10);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataTable RetornarContatosTrabalhadosDetalhado(string sDataInicial, string sDataFinal, int iIDUsuario, string sIDCampanhas, string sIDMailing, int iIDTipoAtendimento, string sIDStatus)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarContatosTrabalhadosDetalhado(sDataInicial, sDataFinal, iIDUsuario, sIDCampanhas, sIDMailing, iIDTipoAtendimento, sIDStatus);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarQuantitativoDadosVenda(int iIDOperador, int iIDCampanha, string sIDStatusAuditoria, string sDataInicial, string sDataFinal, string[] sColunas)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarQuantitativoDadosVenda(iIDOperador, iIDCampanha, sIDStatusAuditoria, sDataInicial, sDataFinal, sColunas);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarObservacoesVenda(int iIDvenda)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarObservacoesVenda(iIDvenda);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataSet RetornarDashboard(int iIDCampanha)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarDashboard(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataSet(sSql);
        }

        public DataTable RetornarVenda(int iIDHistorico)
        {
            relatorioDAL DRelatorio = new relatorioDAL();
            string sSql = DRelatorio.RetornarVenda(iIDHistorico);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

    }
}
