using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace model.dados
{
    public class relatorioDAL
    {
        internal string RetornarCampanhasMailing(int iIDMailing)
        {
            string sSql = " select b.Campanha, count(*) [Quant.] ";
            sSql += " from tProspect a ";
            sSql += " inner join tCampanha b on a.IDCampanha = b.IDCampanha ";
            sSql += " where a.IDMailing = " + iIDMailing + " ";
            sSql += " group by Campanha ";
            sSql += " order by Campanha ";

            return sSql;
        }

        internal string RetornarContatosTrabalhadosSintetico(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento, string sIDStatus, int iAposUltimoResubmit)
        {
            string sSql = " exec sRetornarContatosTrabalhadosSintetico ";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', ";
            sSql += " @IDUsuario = " + iIDUsuario + ", ";
            sSql += " @IDCampanha = " + iIDCampanha + ", ";
            sSql += " @IDMailing = " + iIDMailing + ", ";
            sSql += " @IDTipoAtendimento = " + iIDTipoAtendimento + ", ";
            sSql += " @IDStatus = '" + sIDStatus + "', ";
            sSql += " @AposUltimoResubmit = " + iAposUltimoResubmit + " ";

            sSql += " SELECT d.Nome [Operador], ";
            sSql += " c.Status, count(*) Quantidade  ";
            sSql += " FROM  dbo.tHistorico AS a  ";
            sSql += " INNER JOIN dbo.tProspect AS b ON a.IDProspect = b.IDProspect  ";
            sSql += " INNER JOIN dbo.tStatus AS c ON a.IDStatus = c.IDStatus  ";
            sSql += " INNER JOIN dbo.tUsuario AS d ON a.IDUsuario = d.IDUsuario  ";
            sSql += " INNER JOIN dbo.tMailing AS e ON b.IDMailing = e.IDMailing  ";
            sSql += " where a.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and e.IDCampanha = " + iIDCampanha + " ";
            sSql += " and a.IDUsuario != -1 ";
            sSql += " and a.IDStatus in (select Items from fSplit('" + sIDStatus + "',',')) "; 
            
            if (iIDUsuario != -1)
                sSql += " and a.IDUsuario = " + iIDUsuario + " ";

            if (iIDMailing != -1)
                sSql += " and b.IDMailing = " + iIDMailing + " ";

            sSql += " group by d.Nome, c.Status ";
            sSql += " order by d.Nome, c.Status ";

            return sSql;
        }

        internal string RetornarContatosTrabalhadosDetalhado(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento, string sIDStatus)
        {
            //Retorna os Campos genéricos da tela do Prospect
            string sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";
            sSql += " and a.IDCampo like '%c%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableCampo = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            //Retorna os campos de Venda genéricos da tela Dados da Venda
            sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";
            sSql += " and a.IDCampo like '%v%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableVenda = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            sSql = " SELECT /*b.IDProspect AS [Cód. Prospect],*/ b.Nome AS Prospect,  ";
            sSql += " b.CPF_CNPJ [CPF / CNPJ],  ";
            sSql += " b.Logradouro, b.Numero, b.Complemento, b.Bairro, b.Cidade,  ";
            sSql += " b.Estado, b.Email, b.Cep,  ";
            sSql += " b.Telefone1 [Telefone 1], b.Telefone2 [Telefone 2], b.Telefone3 [Telefone 3], e.Mailing,     ";
            //sSql += " convert(varchar, a.DataCadastro, 103) + ' ' + convert(varchar, a.DataCadastro, 108) AS [Data Contato],   ";
            sSql += " convert(varchar, a.DataCadastro, 108) AS [Hora Contato],   ";
            sSql += " convert(varchar, a.DataCadastro, 103) AS [Data Contato],   ";
            sSql += " UPPER(d.Nome) AS [Usuário do Tabulare],  ";
            sSql += " c.Status, a.Observacao [Observação],   ";
            sSql += " case when (g.IDHistorico is not null) then 'Venda efetivada' else '-' end Venda ";

            if (dataTableCampo.Rows.Count > 0)
                foreach (DataRow dataRow in dataTableCampo.Rows)
                    sSql += ", b." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "] ";

            if (dataTableVenda.Rows.Count > 0)
                foreach (DataRow dataRow in dataTableVenda.Rows)
                    sSql += ", h." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "]";

            sSql += " FROM  dbo.tHistorico AS a  ";
            sSql += " INNER JOIN dbo.tProspect AS b ON a.IDProspect = b.IDProspect  ";
            sSql += " INNER JOIN dbo.tStatus AS c ON a.IDStatus = c.IDStatus  ";
            sSql += " INNER JOIN dbo.tUsuario AS d ON a.IDUsuario = d.IDUsuario  ";
            sSql += " INNER JOIN dbo.tMailing AS e ON b.IDMailing = e.IDMailing  ";
            sSql += " INNER JOIN dbo.tCampanha AS f ON e.IDCampanha = f.IDCampanha ";
            sSql += " left join vVenda g on a.IDHistorico = g.IDHistorico ";
            sSql += " left join tVenda h on g.IDHistorico = h.IDHistorico ";
            sSql += " where a.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and e.IDCampanha = " + iIDCampanha + " ";

            if (iIDMailing != -1) 
                sSql += " and e.IDMailing = " + iIDMailing + " ";

            if (iIDUsuario != -1)
                sSql += " and a.IDUsuario = " + iIDUsuario + " ";

            if (iIDTipoAtendimento != -1)
                sSql += " and a.IDTipoAtendimento = " + iIDTipoAtendimento + " ";

            sSql += " and a.IDStatus in (select Items from fSplit('" + sIDStatus + "',','))  ";

            sSql += " order by a.DataCadastro asc ";

            return sSql;
        }

        internal string RetornarStatusMailing(int iIDMailing)
        {
            string sSql = " exec sRetornarStatusMailing @IDMailing = " + iIDMailing + " ";

            return sSql;
        }

        internal string RetornarContatosTrabalhadosOperador(int iIDUsuario, string sDataInicial, string sDataFinal)
        {
            string sSql = " exec sRetornarContatosTrabalhadosOperador @IDUsuario = " + iIDUsuario + ", ";
            sSql += "@DataInicial = '" + sDataInicial + "', @DataFinal = '" + sDataFinal + "' ";

            return sSql;
        }

        internal string RetornarRespostasScript(string sDataInicial, string sDataFinal, int iIDUsuario, int iIDPergunta, int iIDCampanha, int iIDMailing, int iIDTipoAtendimento)
        {
            string sSql = " select * from vRespostasScript ";
            sSql += " where [Data Contato] between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            if (iIDPergunta != -1)
                sSql += " and IDPergunta = " + iIDPergunta + " ";
            if (iIDUsuario != -1)
                sSql += " and IDUsuario = " + iIDUsuario + " ";
            if (iIDCampanha != -1)
                sSql += " and IDCampanha = " + iIDCampanha + " ";
            if (iIDMailing != -1)
                sSql += " and IDMailing = " + iIDMailing + " ";
            if (iIDTipoAtendimento != -1)
                sSql += " and IDTipoAtendimento = " + iIDTipoAtendimento + " ";

            sSql += " order by Ordem ";

            return sSql;
        }

        internal string RetornarConversaoDDD(string sDataInicial, string sDataFinal, int iIDUsuario)
        {
            string sSql = " exec sRetornarConversaoDDD ";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', ";
            sSql += " @IDUsuario = " + iIDUsuario + " ";

            return sSql;
        }

        internal string RetornarStatusProspectDDD(int iIDMailing)
        {
            string sSql = " exec sRetornarStatusProspectDDD ";
            sSql += " @IDMailing =  " + iIDMailing + " ";

            return sSql;
        }

        internal string RetornarGerarMailing(int iIDMailing, int iIDCampanha, int iIDStatus)
        {
            string sSql = " exec sRetornarGerarMailing ";
            sSql += " @IDMailing = " + iIDMailing + ", ";
            sSql += " @IDCampanha = " + iIDCampanha + ",  ";
            sSql += " @IDStatus = " + iIDStatus + "  ";

            return sSql;
        }

        internal string RetornarVendasSintetico(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDTipoAtendimento, int iIDStatusAuditoria)
        {
            string sSql = " exec sRetornarVendasSintetico ";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', ";
            sSql += " @IDCampanhas = '" + sIDCampanhas + "', ";
            sSql += " @IDTipoAtendimento = " + iIDTipoAtendimento + ", ";
            sSql += " @IDStatusAuditoria = " + iIDStatusAuditoria + " ";

            return sSql;
        }

        internal string RetornarDadosProspect(int iIDProspect)
        {
            string sSql = " select top 1 ";
            sSql += " IDProspect,  ";
            sSql += " Telefone1,  ";
            sSql += " Telefone2,  ";
            sSql += " Telefone3,  ";
            sSql += " Nome,  ";
            sSql += " Logradouro,  ";
            sSql += " Bairro,  ";
            sSql += " Cidade,  ";
            sSql += " Estado,  ";
            sSql += " Email,  ";
            sSql += " CPF_CNPJ,  ";
            sSql += " Cep,  ";
            sSql += " Numero  ";
            sSql += " from tProspect  ";
            sSql += " where IDProspect = " + iIDProspect + " ";

            return sSql;
        }

        internal string RetornarProspects(string sTelefone, string sNome, string sCPF_CNPJ, int iIDTipoAtendimento)
        {
            string sSql = " if object_id('tempdb..#temp') is not null drop table #temp ";

            sSql += " create table #temp ";
            sSql += " ([Cód. Prospect] bigint, ";
            sSql += " [Nome Prospect] varchar(200), ";
            sSql += " [CPF / CNPJ] varchar(50), ";
            sSql += " [Telefone 1] bigint, ";
            sSql += " [Telefone 2] bigint, ";
            sSql += " [Telefone 3] bigint, ";
            sSql += " Mailing varchar(200), ";
            sSql += " Campanha varchar(200), ";
            sSql += " [Último Status] varchar(200), ";
            sSql += " [Data Último Contato] varchar(20), ";
            sSql += " [Usuário do Sistema] varchar(200), ";
            sSql += " IDTipoAtendimento int, ";
            sSql += " IDMailing int, ";
            sSql += " IDCampanha int, ";
            sSql += " IDStatus int, ";
            sSql += " IDUsuario int) ";

            sSql += " insert into #temp ";
            sSql += " ([Cód. Prospect], ";
            sSql += " [Nome Prospect], ";
            sSql += " [CPF / CNPJ], ";
            sSql += " [Telefone 1], ";
            sSql += " [Telefone 2], ";
            sSql += " [Telefone 3], ";
            sSql += " Mailing, ";
            sSql += " Campanha, ";
            sSql += " [Último Status], ";
            sSql += " [Data Último Contato], ";
            sSql += " [Usuário do Sistema], ";
            sSql += " IDTipoAtendimento, ";
            sSql += " IDMailing, ";
            sSql += " IDCampanha, ";
            sSql += " IDStatus, ";
            sSql += " IDUsuario) ";
            sSql += " select top 25 p.IDProspect, ";
            sSql += " p.Nome,  ";
            sSql += "  p.CPF_CNPJ, ";
            sSql += " p.Telefone1, ";
            sSql += " p.Telefone2, ";
            sSql += " p.Telefone3, ";
            sSql += " '', ";
            sSql += " '', ";
            sSql += " '', ";
            sSql += " case when (h.DataCadastro is null) then '-' else CONVERT(varchar,h.DataCadastro, 103) + ' ' + CONVERT(varchar, h.DataCadastro, 108) end , ";
            sSql += " '', ";
            sSql += " h.IDTipoAtendimento, ";
            sSql += " p.IDMailing, m.IDCampanha, p.IDStatus, h.IDUsuario ";
            sSql += " from tProspect p  ";
            sSql += " left join vUltimoHistorico vu on p.IDProspect = vu.IDProspect ";
            sSql += " left join tHistorico h on vu.IDHistorico = h.IDHistorico ";
            sSql += " inner join tMailing m on p.IDMailing = m.IDMailing ";
            sSql += " where p.IDStatus != 0 ";

            if (sCPF_CNPJ != "")
                sSql += " and p.CPF_CNPJ like '%" + sCPF_CNPJ + "%'  ";

            if (sTelefone != "")
                sSql += " and (p.Telefone1 = '" + sTelefone + "' or p.Telefone2 = '" + sTelefone + "' or p.Telefone3 = '" + sTelefone + "')  ";

            if (sNome != "")
                sSql += " and Nome like '%" + sNome + "%'  ";

            if (iIDTipoAtendimento != -1)
                sSql += " and p.IDTipoAtendimento = " + iIDTipoAtendimento + " ";

            sSql += " update #temp ";
            sSql += " set Mailing = tMailing.Mailing ";
            sSql += " from tMailing ";
            sSql += " where #temp.IDMailing = tMailing.IDMailing ";

            sSql += " update #temp ";
            sSql += " set Campanha = tCampanha.Campanha ";
            sSql += " from tCampanha ";
            sSql += " where #temp.IDCampanha = tCampanha.IDCampanha ";

            sSql += " update #temp ";
            sSql += " set [Usuário do Sistema] = tUsuario.Nome ";
            sSql += " from tUsuario ";
            sSql += " where #temp.IDUsuario = tUsuario.IDUsuario ";

            sSql += " update #temp ";
            sSql += " set [Usuário do Sistema] = '-' ";
            sSql += " where [Usuário do Sistema] is null or [Usuário do Sistema] = '' ";

            sSql += " update #temp ";
            sSql += " set [Último Status] = tStatus.Status ";
            sSql += " from tStatus ";
            sSql += " where #temp.IDStatus = tStatus.IDStatus ";

            sSql += " select [Cód. Prospect], ";
            sSql += " [Nome Prospect], ";
            sSql += " [CPF / CNPJ], ";
            sSql += " [Telefone 1], ";
            sSql += " [Telefone 2], ";
            sSql += " [Telefone 3], ";
            sSql += " Mailing, ";
            sSql += " Campanha, ";
            sSql += " [Último Status], ";
            sSql += " [Data Último Contato], ";
            sSql += " [Usuário do Sistema] ";
            sSql += " from #temp ";
            sSql += " order by [Nome Prospect] "; 

            return sSql;
        }

        internal string RetornarDadosVenda(string sDataInicial, string sDataFinal, string sIDCampanha, int iIDMailing, int iIDOperador, int iIDTipoAtendimento, int iIDStatusAuditoria, int  iMailingInativos)
        {
            string sSql;

            //Retorna os Campos genéricos da tela do Prospect
            sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha in (" + sIDCampanha + ") ";
            sSql += " and a.IDCampo like '%c%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableCampo = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            //Retorna os campos de Venda genéricos da tela Dados da Venda
            sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha in (" + sIDCampanha + ") ";
            sSql += " and a.IDCampo like '%v%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableVenda = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            ////////////////////////////////////////////////////////////////////////////////////////

            sSql = " select f.Status [Status / Result. Contato], sa.Status [Auditoria], d.Telefone1 [Telefone 1], ";
            sSql += " d.Nome [Nome Prospect], d.CPF_CNPJ [CPF / CPNJ],e.Mailing [Nome do Mailing], ";
            sSql += " d.Logradouro, d.Numero [Número], d.Bairro, ";
            sSql += " d.Cidade, d.Estado, d.Email, d.Cep, ";

            if (sIDCampanha.IndexOf(",") < 0)
            {
                if (dataTableCampo.Rows.Count > 0)
                    foreach (DataRow dataRow in dataTableCampo.Rows)
                        sSql += "d." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "], ";

                if (dataTableVenda.Rows.Count > 0)
                    foreach (DataRow dataRow in dataTableVenda.Rows)
                        sSql += "a." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "], ";
            }

            //sSql += " CONVERT(varchar, b.DataCadastro, 103) + ' ' + CONVERT(varchar, b.DataCadastro, 106) [Data da Venda], ";
            sSql += " CONVERT(varchar, b.DataCadastro, 103)[Data da Venda] , CONVERT(varchar, b.DataCadastro, 108) [Hora da Venda], ";
            sSql += " c.Nome [Operador (Usuário Tabulare)] ";
            sSql += " from vVenda x ";
            
            sSql += " left join tVenda a on a.IDHistorico = x.IDHistorico ";
            sSql += " inner join tHistorico b on x.IDHistorico = b.IDHistorico ";
            sSql += " inner join tUsuario c on b.IDUsuario = c.IDUsuario ";
            sSql += " inner join tProspect d on b.IDProspect = d.IDProspect ";
            sSql += " inner join tMailing e on d.IDMailing = e.IDMailing ";
            sSql += " inner join tStatusAuditoria sa on sa.IDStatus = a.IDStatus ";
            sSql += " inner join tStatus f on f.IDStatus = b.IDStatus ";
            sSql += " where b.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and e.IDCampanha in (" + sIDCampanha + ") ";
            sSql += " and e.Ativo = " + iMailingInativos + " ";

            if (iIDMailing != -1)
                sSql += " and e.IDMailing = " + iIDMailing + " ";

            if (iIDOperador != -1)
                sSql += " and b.IDUsuario = " + iIDOperador + " ";

            if (iIDTipoAtendimento != -1)
                sSql += " and x.IDTipoAtendimento = " + iIDTipoAtendimento + " ";

            if (iIDStatusAuditoria != -1)
                sSql += " and a.IDStatus = " + iIDStatusAuditoria + " ";

            return sSql;
        }

        internal string RetornarDadosVendas(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDUsuario, int iIDStatusAuditoria, string sCamposVenda, string sCamposProspect, string sTelefone1, string sNome, string sCPF_CNPJ, string chkCamposFixoProspect, string chkCamposFixoProspectCPFCNPJ, string chkCamposFixoProspectLogradouro, string chkCamposFixoProspectNumero, string chkCamposFixoProspectComplemento, string chkCamposFixoProspectBairro, string chkCamposFixoProspectCidade, string chkCamposFixoProspectEstado, string chkCamposFixoProspectEmail)
        {
            string sSql = " select v.IDVenda ,m.IDCampanha, ";
            sSql += " h.IDHistorico [Cód. Hist.], ";
            sSql += " p.nome [Cliente], p.Telefone1 [Telefone 1],p.Telefone2 [Telefone2],p.Telefone3 [Telefone3], s.Status, h.Observacao [Observação], ";

            if (chkCamposFixoProspectCPFCNPJ == "1")
                sSql += " p.CPF_CNPJ [CPF_CNPJ], ";

            if (chkCamposFixoProspectLogradouro == "1")
                sSql += " p.Logradouro [Logradouro], ";

            if (chkCamposFixoProspectNumero == "1")
                sSql += " p.Numero [Número], ";

            if (chkCamposFixoProspectComplemento == "1")
                sSql += " p.Complemento [Complemento], ";

            if (chkCamposFixoProspectBairro == "1")
                sSql += " p.Bairro [Bairro], ";

            if (chkCamposFixoProspectCidade == "1")
                sSql += " p.Cidade [Cidade], ";

            if (chkCamposFixoProspectEstado == "1")
                sSql += " p.Estado [Estado], ";

            if (chkCamposFixoProspectEmail == "1")
                sSql += " p.Email [Email], ";


            sSql += " u.nome [Resp. Operador], ";
            sSql += " convert(varchar,h.DataCadastro,103) + ' ' + convert(varchar,h.DataCadastro, 108)[Data da Venda], ";
            sSql += " sa.Status [Auditoria] ";

            //Verifica se selecionou campos de venda
            if (sCamposVenda != "")
            {
                string sSqlVenda = " select 'Venda' + RIGHT(IDCampo, 2) CampoVenda, Texto ";
                sSqlVenda += " from tCampanha_Campo ";
                sSqlVenda += " where Texto in (" + sCamposVenda + ") and left(IDCampo, 1) = 'V' ";
                sSqlVenda += " and IDCampanha = " + sIDCampanhas + " ";

                DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSqlVenda);
                foreach (DataRow dataRow in dataTable.Rows)
                    sSql += " , v." + dataRow["CampoVenda"].ToString() + " [" + dataRow["Texto"].ToString() + " - Venda" + "]";
            }

            //Verifica se selecionou campos do prospect
            if (sCamposProspect != "")
            {
                string sSqlVenda = " select 'Campo' + RIGHT(IDCampo, 2) CampoExtras, Texto ";
                sSqlVenda += " from tCampanha_Campo ";
                sSqlVenda += " where Texto in (" + sCamposProspect + ") and left(IDCampo, 1) = 'C' ";
                sSqlVenda += " and IDCampanha = " + sIDCampanhas + " ";

                DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSqlVenda);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    sSql += " , p." + dataRow["CampoExtras"].ToString() + " [" + dataRow["Texto"].ToString() + "]";
                }
            }

            sSql += " from tHistorico h ";
            sSql += " inner join tProspect p on p.IDProspect = h.IDProspect ";
            sSql += " inner join tUsuario u on h.IDUsuario = u.IDUsuario ";
            sSql += " left join tVenda v on h.IDHistorico = v.IDHistorico ";
            sSql += " inner join tMailing m on p.IDMailing = m.IDMailing ";
            sSql += " inner join tStatus s on s.IDStatus = h.IDStatus ";
            sSql += " left join tStatusAuditoria sa on sa.IDStatus = v.IDStatus ";
            sSql += " where h.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and m.IDCampanha in (select Items from fSplit('" + sIDCampanhas + "', ','))  ";
            sSql += " and h.IDStatus in (select IDStatus from tStatus where Venda = 1)  ";

            if (iIDUsuario != -1)
                sSql += " and h.IDUsuario = " + iIDUsuario + "  ";

            if (iIDStatusAuditoria != -1)
                sSql += " and (v.IDStatus = " + iIDStatusAuditoria + ")";

            if (sCPF_CNPJ != "")
                sSql += " and p.CPF_CNPJ like '%" + sCPF_CNPJ + "%'  ";

            if (sTelefone1 != "")
                sSql += " and p.Telefone1 = '" + sTelefone1 + "'  ";

            if (sNome != "")
                sSql += " and p.Nome like '%" + sNome + "%'  ";

            sSql += " order by v.IDVenda asc ";

            return sSql;
        }

        internal string RetornarDadosVenda(int iIDHistorico)
        {
            string sSql = " SELECT v.IDVenda,h.IDHistorico,p.IDProspect, ";
            sSql += " p.IDProspect ,p.Telefone1,p.Nome,p.Telefone2,p.Telefone3,p.CPF_CNPJ,p.Logradouro,p.Numero,p.Complemento,p.Bairro,p.Cidade,p.Estado,p.Email,p.Cep,p.Campo01,p.Campo02,p.Campo03,p.Campo04,p.Campo05,p.Campo06,p.Campo07,p.Campo08,p.Campo09,p.Campo10,u.Nome Usuario, ";
            sSql += " Convert (varchar,h.DataCadastro,103)+' '+Convert (varchar(5),h.DataCadastro,108) DataCadastro, ";
            sSql += " m.Mailing,c.Campanha, ";
            sSql += " v.Venda01,v.Venda02,v.Venda03,v.Venda04,v.Venda05,v.Venda06,v.Venda07,v.Venda08,v.Venda09,v.Venda10, ";
            sSql += " v.Venda11,v.Venda12,v.Venda13,v.Venda14,v.Venda15,v.Venda16,v.Venda17,v.Venda18,v.Venda19,v.Venda20, ";
            sSql += " v.Venda21,v.Venda22,v.Venda23,v.Venda24,v.Venda25,v.Venda26,v.Venda27,v.Venda28,v.Venda29,v.Venda30, ";
            sSql += " v.Venda31,v.Venda32,v.Venda33,v.Venda34,v.Venda35,v.Venda36,v.Venda37,v.Venda38,v.Venda39,v.Venda40, ";
            sSql += " v.Venda41,v.Venda42,v.Venda43,v.Venda44,v.Venda45,v.Venda46,v.Venda47,v.Venda48,v.Venda49,v.Venda50, ";
            sSql += " v.Venda51,v.Venda52,v.Venda53,v.Venda54,v.Venda55,v.Venda56,v.Venda57,v.Venda58,v.Venda59,v.Venda60, ";
            sSql += " s.Status, h.Observacao, v.IDStatus, m.IDCampanha, sa.Status [Status Auditoria], ";
            sSql += " ua.Nome Backoffice, Convert (varchar,v.DataAuditoria,103)+' '+Convert (varchar(5),v.DataAuditoria,108) DataAuditoria ";
            sSql += " FROM tHistorico h ";
            sSql += " left join tVenda v on h.IDHistorico = v.IDHistorico ";
            sSql += " inner join tProspect p on p.IDProspect = h.IDProspect ";
            sSql += " inner join tUsuario u on u.IDUsuario = h.IDUsuario ";
            sSql += " inner join tMailing m on p.IDMailing = m.IDMailing ";
            sSql += " inner join tCampanha c on m.IDCampanha = c.IDCampanha ";
            sSql += " inner join tStatus s on s.IDStatus = h.IDStatus ";
            sSql += " left join tStatusAuditoria sa on v.IDStatus = sa.IDStatus ";
            sSql += " left join tUsuario ua on v.IDUsuarioAuditoria = ua.IDUsuario ";
            sSql += " WHERE h.IDHistorico = " + iIDHistorico + " ";

            return sSql;
        }

        internal string RetornarTopSemanal(int iIDCampanha)
        {
            string sSql = " exec sRetornarTopSemanal ";
            sSql += " @IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string RetornarTopSemanalPontuacao(int iIDCampanha)
        {
            string sSql = " exec sRetornarTopSemanalPontuacao ";
            sSql += " @IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string RetornarVendaMotoBoy(int iIDVendaMotoBoy)
        {
            string sSql = " exec sRetornarVendaMotoBoy ";
            sSql += " @IDVendaMotoBoy = " + iIDVendaMotoBoy + " ";

            return sSql;
        }

        internal string RetornarExportacaoMailing(int iIDCampanha, int iIDMailing, string sIDStatus)
        {
            //Retorna os Campos genéricos da tela do Prospect
            string sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";
            sSql += " and a.IDCampo like '%c%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableCampo = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            //Retorna os campos de Venda genéricos da tela Dados da Venda
            sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";
            sSql += " and a.IDCampo like '%v%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableVenda = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            sSql = " SELECT b.Nome AS Prospect,  ";
            sSql += " b.CPF_CNPJ [CPF / CNPJ],  ";
            sSql += " b.Logradouro, b.Numero, b.Complemento, b.Bairro, b.Cidade,  ";
            sSql += " b.Estado,  ";
            sSql += " b.Telefone1 [Telefone 1], e.Mailing,     ";
            sSql += " convert(varchar, a.DataCadastro, 103) + ' ' + convert(varchar, a.DataCadastro, 108) AS [Data Contato],   ";
            sSql += " UPPER(d.Nome) AS [Usuário do Tabulare],  ";
            sSql += " c.Status, a.Observacao [Observação],   ";
            sSql += " case when (g.IDHistorico is not null) then 'Venda efetivada' else '-' end Venda ";

            sSql = " if object_id('tempdb..#temp') is not null drop table #temp ";

            sSql += " select a.IDProspect, a.Nome, a.Telefone1 [Telefone 1], a.Telefone2 [Telefone 2], ";
            sSql += " a.Telefone3 [Telefone 3], a.CPF_CNPJ [CPF / CNPJ], ";
            sSql += " a.Logradouro, a.Numero [Número], a.Complemento, a.Bairro, ";
            sSql += " a.Cidade, a.Estado, a.Email, a.Cep, case when a.Ativo = 1 then 'Sim' else 'Não' end Ativo, ";
            sSql += " b.Status ";
            sSql += " into #temp ";
            sSql += " from tProspect a ";
            sSql += " inner join tStatus b on a.IDStatus = b.IDStatus ";
            sSql += " where a.IDMailing = " + iIDMailing + " ";

            if (sIDStatus != "")
                sSql += " and a.IDStatus in ("+sIDStatus+") ";

            sSql += " select a.Nome, a.[Telefone 1], a.[Telefone 2],  ";
            sSql += " a.[Telefone 3], a.[CPF / CNPJ], ";
            sSql += " a.Logradouro, a.[Número], a.Complemento, a.Bairro, ";
            sSql += " a.Cidade, a.Estado, a.Email, a.Cep ";

            if (dataTableCampo.Rows.Count > 0)
                foreach (DataRow dataRow in dataTableCampo.Rows)
                    sSql += ", e." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "] ";

            sSql += " , a.Ativo, a.Status,  ";
            sSql += " c.Observacao [Observação] ";

            if (dataTableVenda.Rows.Count > 0)
                foreach (DataRow dataRow in dataTableVenda.Rows)
                    sSql += ", g." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "]";

            sSql += " , convert (varchar, c.DataCadastro, 103) +' '+ convert (varchar, c.DataCadastro, 108) [Data Contato],  ";
            sSql += " d.Nome [Operador] ";

            sSql += " from #temp a ";
            sSql += " left join vUltimoHistorico b on a.IDProspect = b.IDProspect ";
            sSql += " left join tHistorico c on b.IDHistorico = c.IDHistorico ";
            sSql += " left join tUsuario d on c.IDUsuario = d.IDUsuario ";
            sSql += " left join tProspect e on a.IDProspect = e.IDProspect ";
            sSql += " left join vVenda f on b.IDHistorico = f.IDHistorico ";
            sSql += " left join tVenda g on f.IDHistorico = g.IDHistorico ";

            sSql += " order by b.IDProspect asc ";

            return sSql;
        }

        internal string RetornarOperadoresCampanha()
        {
            string sSql = " select top 10 upper(c.Campanha) CAMPANHA, COUNT(*) QUANTIDADE ";
            sSql += " from tUsuario u ";
            sSql += " inner join tCampanha c on u.IDCampanha = c.IDCampanha ";
            sSql += " where u.Ativo = 1 ";
            sSql += " and u.IDPerfil = 2 ";
            sSql += " group by c.Campanha ";
            sSql += " order by COUNT(*) desc ";

            return sSql;
        }

        internal string RetornarVendasMensal()
        {
            string sSql = " select top 20 upper(Televendedor) Televendedor, COUNT(*) [Quant] ";
            sSql += " from vVenda ";
            sSql += " where DATEPART(month, [Data Venda]) =  DATEPART(month, GETDATE()) ";
            sSql += " and DATEPART(YEAR, [Data Venda]) = DATEPART(year, GETDATE()) ";
            sSql += " group by Televendedor ";
            sSql += " order by COUNT(*) asc ";

            return sSql;
        }

        internal string RetornarTabulacoesVendasMensal()
        {
            string sSql = " if object_id('tempdb..#temp') is not null drop table #temp ";

            sSql += " create table #temp ";
            sSql += " (IDCampanha int, ";
            sSql += " Trabalhados int, ";
            sSql += " Vendas int) ";

            sSql += " insert into #temp ";
            sSql += " (IDCampanha, Trabalhados, Vendas) ";
            sSql += " select IDCampanha, 0, 0 ";
            sSql += " from tCampanha c ";
            sSql += " where c.Ativo = 1 ";

            sSql += " update #temp ";
            sSql += " set Trabalhados = x.Quant ";
            sSql += " from (select IDCampanha, COUNT(*) Quant   ";
            sSql += " from vContatosTrabalhados ";
            sSql += " where DATEPART(year, [Data Contato]) = DATEPART(year, GETDATE()) ";
            sSql += " and DATEPART(month, [Data Contato]) = DATEPART(month, GETDATE())  ";
            sSql += " group by IDCampanha) x   ";
            sSql += " where #temp.IDCampanha = x.IDCampanha  ";

            sSql += " update #temp ";
            sSql += " set Vendas = x.Quant ";
            sSql += " from (select IDCampanha, COUNT(*) Quant ";
            sSql += " from vVenda v ";
            sSql += " where DATEPART(year, v.[Data Venda]) = DATEPART(year, GETDATE()) ";
            sSql += " and DATEPART(month, v.[Data Venda]) = DATEPART(month, GETDATE()) ";
            sSql += " group by v.IDCampanha) x ";
            sSql += " where #temp.IDCampanha = x.IDCampanha ";

            sSql += " select upper(Campanha) CAMPANHA, TRABALHADOS, VENDAS ";
            sSql += " from #temp t ";
            sSql += " inner join tCampanha c on t.IDCampanha = c.IDCampanha ";
            return sSql;
        }

        internal string RetornarProspectsDisponiveis()
        {
            string sSql = " if object_id('tempdb..#temp') is not null drop table #temp ";

            sSql += " Declare ";
            sSql += " @IDCampanha int, ";
            sSql += " @Quantidade int ";

            sSql += " create table #temp ";
            sSql += " (IDCampanha int,  ";
            sSql += " VIRGEM int,  ";
            sSql += " FILA int, ";
            sSql += " REAGENDAMENTO int) ";

            sSql += " if object_id('tempdb..#Campanha') is not null drop table #Campanha ";
            sSql += " create table #Campanha ";
            sSql += " (IDCampanha int) ";

            sSql += " insert into #temp ";
            sSql += " (IDCampanha, Virgem, Fila, Reagendamento) ";
            sSql += " select IDCampanha, 0, 0, 0 ";
            sSql += " from tCampanha c ";
            sSql += " where c.Ativo = 1 ";

            sSql += " /*Virgem*/ ";
            sSql += " delete #Campanha ";
            sSql += " insert into #Campanha ";
            sSql += " select IDCampanha from tCampanha where Ativo = 1 ";

            sSql += " while exists (select * from #Campanha) ";
            sSql += " Begin ";
            sSql += " select @IDCampanha = IDCampanha from #Campanha ";

            sSql += " select @Quantidade = count(a.IDProspect) ";
            sSql += " from tProspect a ";
            sSql += " inner join tMailing b on a.IDMailing = b.IDMailing ";
            sSql += " where a.Ativo = 1  ";
            sSql += " and a.EmUso = 0  ";
            sSql += " and b.IDCampanha = @IDCampanha  ";
            sSql += " and a.IDStatus in (-1, -3)  ";
            sSql += " and b.Ativo = 1 ";
            sSql += " and LEFT(a.Telefone1, 2) not in (select DDD from tBloqueioDDD where IDCampanha = @IDCampanha) ";

            sSql += " update #temp ";
            sSql += " set Virgem = @Quantidade ";
            sSql += " where IDCampanha = @IDCampanha ";

            sSql += " delete #Campanha where IDCampanha = @IDCampanha ";
            sSql += " End ";

            sSql += " /*Fila*/ ";
            sSql += " delete #Campanha ";
            sSql += " insert into #Campanha ";
            sSql += " select IDCampanha from tCampanha where Ativo = 1 ";

            sSql += " while exists (select * from #Campanha) ";
            sSql += " Begin ";
            sSql += " select @IDCampanha = IDCampanha from #Campanha ";

            sSql += " select @Quantidade = count(a.IDProspect) ";
            sSql += " from tProspect a ";
            sSql += " inner join tMailing b on a.IDMailing = b.IDMailing ";
            sSql += " inner join tStatus c on a.IDStatus = c.IDStatus ";
            sSql += " where a.Ativo = 1  ";
            sSql += " and a.EmUso = 0  ";
            sSql += " and b.IDCampanha = @IDCampanha  ";
            sSql += " and (a.DataProxContato < Getdate()) ";
            sSql += " and b.Ativo = 1  ";
            sSql += " and c.IDAcao = 1  ";
            sSql += " and LEFT(a.Telefone1, 2) not in (select DDD from tBloqueioDDD where IDCampanha = @IDCampanha) ";

            sSql += " update #temp ";
            sSql += " set Fila = @Quantidade ";
            sSql += " where IDCampanha = @IDCampanha ";

            sSql += " delete #Campanha where IDCampanha = @IDCampanha ";
            sSql += " End ";

            sSql += " /*Reagendamento*/ ";
            sSql += " delete #Campanha ";
            sSql += " insert into #Campanha ";
            sSql += " select IDCampanha from tCampanha where Ativo = 1 ";

            sSql += " while exists (select * from #Campanha) ";
            sSql += " Begin ";
            sSql += " select @IDCampanha = IDCampanha from #Campanha ";

            sSql += " select @Quantidade = count(a.IDProspect) ";
            sSql += " from tProspect a ";
            sSql += " inner join tMailing b on a.IDMailing = b.IDMailing ";
            sSql += " where a.Ativo = 1  ";
            sSql += " and a.EmUso = 0  ";
            sSql += " and b.IDCampanha = @IDCampanha  ";
            sSql += " and a.IDStatus in (-1, -3)  ";
            sSql += " and b.Ativo = 1 ";
            sSql += " and LEFT(a.Telefone1, 2) not in (select DDD from tBloqueioDDD where IDCampanha = @IDCampanha) ";

            sSql += " select @Quantidade = count(a.IDProspect) ";
            sSql += " from tProspect a ";
            sSql += " inner join tMailing b on a.IDMailing = b.IDMailing ";
            sSql += " inner join tStatus c on a.IDStatus = c.IDStatus ";
            sSql += " where a.Ativo = 1 ";
            sSql += " and b.IDCampanha = @IDCampanha ";
            sSql += " and c.IDAcao = 2  ";
            sSql += " and a.EmUso = 0	 ";
            sSql += " and LEFT(a.Telefone1, 2) not in (select DDD from tBloqueioDDD where IDCampanha = @IDCampanha) ";

            sSql += " update #temp ";
            sSql += " set Reagendamento = @Quantidade ";
            sSql += " where IDCampanha = @IDCampanha ";

            sSql += " delete #Campanha where IDCampanha = @IDCampanha ";
            sSql += " End ";

            sSql += " select upper(Campanha) CAMPANHA, VIRGEM, FILA, REAGENDAMENTO ";
            sSql += " from #temp t ";
            sSql += " inner join tCampanha c on t.IDCampanha = c.IDCampanha ";

            return sSql;
        }

        internal string RetornarMidiasSintetico(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            string sSql = " exec sRetornarMidias ";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', ";
            sSql += " @IDCampanhas = '" + sIDCampanhas + "' ";

            return sSql;
        }

        internal string RetornarMidiasDetalhado(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            string sSql = " exec sRetornarMidias ";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', ";
            sSql += " @IDCampanhas = '" + sIDCampanhas + "' ";

            return sSql;
        }

        internal string RetornarMidias(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            string sSql = " exec sRetornarMidias ";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', ";
            sSql += " @IDCampanhas = '" + sIDCampanhas + "' ";

            return sSql;
        }

        internal string RetornarDadosVendasBackoffice(string sDataInicial, string sDataFinal, string sIDCampanhas, int iIDUsuario, string sIDAuditoria, string sCamposVenda, string sCamposProspectFixo, string sCamposProspectExtra, string sTelefone1, string sNome, string sCPF_CNPJ, string sCampoDadosVenda, string sTextoDadosVenda, int iIDOperadorAuditoria)
        {
            string sSql = " select v.IDVenda ,m.IDCampanha, ";
            sSql += " h.IDHistorico [Cód. Hist.], ";
            sSql += " p.nome [Cliente], p.Telefone1 [Telefone 1],p.Telefone2 [Telefone 2],p.Telefone3 [Telefone 3],m.Mailing, ";

            if (sCamposProspectFixo.Trim() != "")
                sSql += sCamposProspectFixo + ", ";

            sSql += " s.Status, h.Observacao [Observação], ";
            sSql += " u.nome [Resp. Operador], ";
            sSql += " convert(varchar,h.DataCadastro,103)[Data da Venda], convert(varchar,h.DataCadastro, 108)[Horário da Venda], ";
            sSql += " case  ";
            sSql += " when (dateadd(hour, convert(decimal, sa.TempoExpiracao) * 0.8, h.DataCadastro) > getdate() and sa.TempoExpiracao > 0) then sa.Status+ ' (no prazo)'  ";
            sSql += " when (dateadd(hour, convert(decimal, sa.TempoExpiracao) * 1, h.DataCadastro) >= getdate())   ";
            sSql += " and (dateadd(hour, convert(decimal, sa.TempoExpiracao) * 0.8, h.DataCadastro) <= getdate() and sa.TempoExpiracao > 0) then sa.Status+ ' (expirando)'  ";
            sSql += " when (dateadd(hour, convert(decimal, sa.TempoExpiracao) * 1, h.DataCadastro) < getdate() and sa.TempoExpiracao > 0) then sa.Status+ ' (expirado)'  ";
            sSql += " else sa.Status  ";
            sSql += " end Auditoria,  ";
            sSql += " case when (uu.Nome is null) then ua.Nome else (case when (ua.Nome is null) then '' else ua.Nome + ' ' end) + '(sendo auditada por ' + uu.Nome + ')' end [Backoffice], ";
            sSql += " CONVERT(varchar, v.DataAuditoria, 103) [Data Auditoria], CONVERT(varchar, v.DataAuditoria, 108) [Hora Auditoria] ";

            //Verifica se selecionou campos de venda
            if (sCamposVenda != "")
            {
                string sSqlVenda = " select 'Venda' + RIGHT(IDCampo, 2) CampoVenda, Texto ";
                sSqlVenda += " from tCampanha_Campo ";
                sSqlVenda += " where Texto in (" + sCamposVenda + ") and left(IDCampo, 1) = 'V' ";
                sSqlVenda += " and IDCampanha = " + sIDCampanhas + " ";

                DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSqlVenda);
                foreach (DataRow dataRow in dataTable.Rows)
                    sSql += " , v." + dataRow["CampoVenda"].ToString() + " [" + dataRow["Texto"].ToString() + " - Venda" + "]";
            }

            //Verifica se selecionou campos do prospect
            if (sCamposProspectExtra != "")
            {
                string sSqlVenda = " select 'Campo' + RIGHT(IDCampo, 2) CampoExtras, Texto ";
                sSqlVenda += " from tCampanha_Campo ";
                sSqlVenda += " where Texto in (" + sCamposProspectExtra + ") ";
                sSqlVenda += " and IDCampanha = " + sIDCampanhas + " ";

                DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSqlVenda);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    sSql += " , p." + dataRow["CampoExtras"].ToString() + " [" + dataRow["Texto"].ToString() + "]";
                }
            }

            sSql += " from tHistorico h ";
            sSql += " inner join tProspect p on p.IDProspect = h.IDProspect ";
            sSql += " inner join tUsuario u on h.IDUsuario = u.IDUsuario ";
            sSql += " left join tVenda v on h.IDHistorico = v.IDHistorico ";
            sSql += " inner join tMailing m on p.IDMailing = m.IDMailing ";
            sSql += " inner join tStatus s on s.IDStatus = h.IDStatus ";
            sSql += " left join tStatusAuditoria sa on sa.IDStatus = v.IDStatus ";
            sSql += " left join tUsuario ua on v.IDUsuarioAuditoria = ua.IDUsuario ";
            sSql += " left join tUsuario uu on v.IDUsuarioEmUso = uu.IDUsuario ";
            sSql += " where h.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and m.IDCampanha in (select Items from fSplit('" + sIDCampanhas + "', ','))  ";
            sSql += " and h.IDStatus in (select IDStatus from tStatus where Venda = 1)  ";

            if (iIDUsuario != -1)
                sSql += " and h.IDUsuario = " + iIDUsuario + "  ";

            if (sIDAuditoria != "-1")
                sSql += " and (v.IDStatus in (select Items from fSplit('" + sIDAuditoria + "', ',')))  ";
                                         

            if (sCPF_CNPJ != "")
                sSql += " and p.CPF_CNPJ like '%" + sCPF_CNPJ + "%'  ";

            if (sTelefone1 != "")
                sSql += " and p.Telefone1 = '" + sTelefone1 + "'  ";

            if (sNome != "")
                sSql += " and p.Nome like '%" + sNome + "%'  ";

            if (iIDOperadorAuditoria != -1)//r
                sSql += " and u.IDUsuario = '" + iIDOperadorAuditoria + "' ";

            if (sCampoDadosVenda != "-1")
            {
                if (sCampoDadosVenda.IndexOf("v") != -1)
                    sSql += " and v.venda" + sCampoDadosVenda.Replace("v", "") + "     like '%" + sTextoDadosVenda + "%'  ";
                else
                    sSql += " and p.campo" + sCampoDadosVenda.Replace("c", "") + "     like '%" + sTextoDadosVenda + "%'  ";
            }

            sSql += " order by v.IDVenda asc ";

            return sSql;
        }

        internal string RetornarVendasAuditoria(string sDataInicial, string sDataFinal, string sIDCampanhas)
        {
            string sSql = " exec sRetornarVendasAuditoria ";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', ";
            sSql += " @IDCampanhas = '" + sIDCampanhas + "' ";

            return sSql;
        }

        internal string RetornarGridContatosTrabalhadosOperador(int iIDUsuario, string sDataInicial, string sDataFinal)
        {
            string sSql = " exec sRetornarContatosTrabalhadosOperador @IDUsuario = " + iIDUsuario + ", ";
            //sSql += "@Data = '" + sData + "'";
            sSql += " @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "'";

            return sSql;
        }

        internal string RetornarContatosOperadorNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            string sSql = " exec sRetornarContatosOperador @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', @IDParceiro = "+iIDParceiro+" ";

            return sSql;
        }

        internal string RetornarVendasOperadorNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            string sSql = " exec sRetornarVendasOperador @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', @IDParceiro = " + iIDParceiro + " ";

            return sSql;
        }

        internal string RetornarTratadasBackofficeNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            string sSql = " exec sRetornarTratadasBackoffice @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', @IDParceiro = " + iIDParceiro + " ";

            return sSql;
        }

        internal string RetornarMailingTrabalhadoNet(int iIDParceiro, string sDataInicial, string sDataFinal)
        {
            string sSql = " exec sRetornarMailingTrabalhado @DataInicial = '" + sDataInicial + "', ";
            sSql += " @DataFinal = '" + sDataFinal + "', @IDParceiro = " + iIDParceiro + " ";

            return sSql;
        }

        internal string RetornarProspectsVirgens_dashboard(int iIDCampanha)
        {
            string sSql = " select top 10 c.Campanha, count(*) Quantidade ";
            sSql += " from tProspect p ";
            sSql += " inner join tMailing m on p.IDMailing = m.IDMailing ";
            sSql += " inner join tCampanha c on m.IDCampanha = c.IDCampanha ";
            sSql += " where p.IDStatus = -1 /*Virgem*/ ";
            sSql += " and p.EmUso = 0 ";
            sSql += " and c.Ativo = 1 ";
            sSql += " and m.Ativo = 1 ";

            if (iIDCampanha != -1)
                sSql += " and c.IDCampanha = "+iIDCampanha+" ";

            sSql += " group by c.Campanha ";
            sSql += " order by count(*) desc ";

            return sSql;
        }

        internal string RetornarVendas_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            string sSql = " select ";
            if (bTop10) sSql += " top 10 ";
            sSql += " Televendedor, count(*) Quantidade ";
            sSql += " from vVenda ";
            sSql += " where [Data Venda] between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            if (iIDCampanha != -1) sSql += " and IDCampanha = " + iIDCampanha + " ";
            sSql += " group by Televendedor ";
            sSql += " order by count(*) desc ";

            //////////////////////////////////////////////////////////

            sSql += " select count(*) Quantidade ";
            sSql += " from vVenda ";
            sSql += " where [Data Venda] between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            if (iIDCampanha != -1) sSql += " and IDCampanha = " + iIDCampanha + " ";
           
            return sSql;
        }

        internal string RetornarContatosOperadores_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            string sSql = " select ";
            if (bTop10) sSql += " top 10 ";
            sSql += " u.Nome Operador, count(*) Quantidade ";
            sSql += " from tHistorico h ";
            sSql += " inner join tUsuario u on h.IDUsuario = u.IDUsuario ";
            sSql += " inner join tProspect p on p.IDProspect = h.IDProspect ";
            sSql += " inner join tMailing m on m.IDMailing = p.IDMailing ";
            sSql += " where h.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and u.IDUsuario > -1 ";
            if (iIDCampanha != -1) sSql += " and m.IDCampanha = " + iIDCampanha + " ";
            sSql += " group by u.Nome ";
            sSql += " order by count(*) desc ";

            /////////////////////////////////////////////////////////////////

            sSql += " select count(*) Quantidade ";
            sSql += " from tHistorico h ";
            sSql += " inner join tUsuario u on h.IDUsuario = u.IDUsuario ";
            sSql += " inner join tProspect p on p.IDProspect = h.IDProspect ";
            sSql += " inner join tMailing m on m.IDMailing = p.IDMailing ";
            sSql += " where h.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and u.IDUsuario > -1 ";
            if (iIDCampanha != -1) sSql += " and m.IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string RetornarStatusContatos_dashboard(int iIDCampanha, string sDataInicial, string sDataFinal, bool bTop10)
        {
            string sSql = " select ";
            if (bTop10) sSql += " top 10 ";
            sSql += " s.Status, count(*) Quantidade ";
            sSql += " from tHistorico h ";
            sSql += " inner join tStatus s on h.IDStatus = s.IDStatus ";
            sSql += " inner join tProspect p on p.IDProspect = h.IDProspect ";
            sSql += " inner join tMailing m on m.IDMailing = p.IDMailing ";
            sSql += " where h.DataCadastro between '"+sDataInicial+"' and '"+sDataFinal+"' ";
            if (iIDCampanha != -1) sSql += " and m.IDCampanha = " + iIDCampanha + " ";
            sSql += " group by s.Status ";
            sSql += " order by count(*) desc ";

            //////////////////////////////////////////////////////////////////

            sSql += " select count(*) Quantidade ";
            sSql += " from tHistorico h ";
            sSql += " inner join tStatus s on h.IDStatus = s.IDStatus ";
            sSql += " inner join tProspect p on p.IDProspect = h.IDProspect ";
            sSql += " inner join tMailing m on m.IDMailing = p.IDMailing ";
            sSql += " where h.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            if (iIDCampanha != -1) sSql += " and m.IDCampanha = " + iIDCampanha + " ";
            
            return sSql;
        }

        internal string RetornarContatosTrabalhadosDetalhado(string sDataInicial, string sDataFinal, int iIDUsuario, string sIDCampanhas, string sIDMailing, int iIDTipoAtendimento, string sIDStatus)
        {
            //Retorna os Campos genéricos da tela do Prospect
            string sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha in (" + sIDCampanhas + ") ";
            sSql += " and a.IDCampo like '%c%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableCampo = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            //Retorna os campos de Venda genéricos da tela Dados da Venda
            sSql = "select b.Campo, a.Texto ";
            sSql += " from tCampanha_Campo a ";
            sSql += " inner join tCampo b on a.IDCampo = b.IDCampo ";
            sSql += " where IDCampanha in (" + sIDCampanhas + ") ";
            sSql += " and a.IDCampo like '%v%' ";
            sSql += " order by b.Campo  ";
            DataTable dataTableVenda = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            sSql = " SELECT /*b.IDProspect AS [Cód. Prospect],*/ b.Nome AS Prospect,  ";
            sSql += " b.CPF_CNPJ [CPF / CNPJ],  ";
            sSql += " b.Logradouro, b.Numero, b.Complemento, b.Bairro, b.Cidade,  ";
            sSql += " b.Estado, b.Email, b.Cep,  ";
            sSql += " b.Telefone1 [Telefone 1], b.Telefone2 [Telefone 2], b.Telefone3 [Telefone 3], e.Mailing, m.Midia as [Midia Prospect],      ";
            //sSql += " convert(varchar, a.DataCadastro, 103) + ' ' + convert(varchar, a.DataCadastro, 108) AS [Data Contato],   ";
            sSql += " convert(varchar, a.DataCadastro, 108) AS [Hora Contato],   ";
            sSql += " convert(varchar, a.DataCadastro, 103) AS [Data Contato],   ";
            sSql += " UPPER(d.Nome) AS [Usuário do Tabulare],  ";
            sSql += " c.Status, a.Observacao [Observação],   ";
            sSql += " case when (g.IDHistorico is not null) then 'Venda efetivada' else '-' end Venda ";


            if (sIDCampanhas.IndexOf(",") == -1)
            {
                if (dataTableCampo.Rows.Count > 0)
                    foreach (DataRow dataRow in dataTableCampo.Rows)
                        sSql += ", b." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "] ";

                if (dataTableVenda.Rows.Count > 0)
                    foreach (DataRow dataRow in dataTableVenda.Rows)
                        sSql += ", h." + dataRow["Campo"].ToString() + " as [" + dataRow["Texto"].ToString() + "]";
            }

            sSql += " FROM  dbo.tHistorico AS a  ";
            sSql += " INNER JOIN dbo.tProspect AS b ON a.IDProspect = b.IDProspect  ";
            sSql += " INNER JOIN dbo.tStatus AS c ON a.IDStatus = c.IDStatus  ";
            sSql += " INNER JOIN dbo.tUsuario AS d ON a.IDUsuario = d.IDUsuario  ";
            sSql += " INNER JOIN dbo.tMailing AS e ON b.IDMailing = e.IDMailing  ";
            sSql += " INNER JOIN dbo.tCampanha AS f ON e.IDCampanha = f.IDCampanha ";
            sSql += " left join vVenda g on a.IDHistorico = g.IDHistorico ";
            sSql += " left join tVenda h on g.IDHistorico = h.IDHistorico ";
            sSql += " left join tMidia m on m.IDMidia = b.IDMidia  ";
            sSql += " where a.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and e.IDCampanha in (" + sIDCampanhas + ") ";

            if (sIDMailing != "")
                sSql += " and e.IDMailing in (" + sIDMailing + ") ";

            if (iIDUsuario != -1)
                sSql += " and a.IDUsuario = " + iIDUsuario + " ";

            if (iIDTipoAtendimento != -1)
                sSql += " and a.IDTipoAtendimento = " + iIDTipoAtendimento + " ";

            if (sIDStatus != "")
            sSql += " and a.IDStatus in (select Items from fSplit('" + sIDStatus + "',','))  ";

            sSql += " order by a.DataCadastro asc ";

            return sSql;
        }

        internal string RetornarQuantitativoDadosVenda(int iIDOperador, int iIDCampanha, string sIDStatusAuditoria, string sDataInicial, string sDataFinal, string[] sColunas)
        {
            string sSql = " if object_id('tempdb..#Consolidado') is not null drop table #Consolidado ";
            sSql += " if object_id('tempdb..#Vendas') is not null drop table #Vendas ";

            sSql += " select * ";
            sSql += " into #Vendas ";
            sSql += " from vVenda  ";
            sSql += " where [Data Venda] between '" + sDataInicial + "' and '" + sDataFinal + "' ";
            sSql += " and IDCampanha = " + iIDCampanha + " ";
            sSql += " and IDStatusAuditoria in (" + sIDStatusAuditoria + ") ";

            if (iIDOperador != -1)
                sSql += " and IDUsuario = " + iIDOperador + " "; 

            sSql += " create table #Consolidado ";
            sSql += " ([Usuário/Operador] varchar(500), ";
            sSql += " IDUsuario int) ";

            sSql += " insert into #Consolidado ";
            sSql += " (IDUsuario, [Usuário/Operador]) ";
            sSql += " select distinct(IDUsuario), Televendedor ";
            sSql += " from #Vendas ";

            foreach (string sColuna in sColunas)
            {
                string sOpcao = sColuna.Substring(sColuna.IndexOf("=>") + 2).Trim();
                string sCampo = sColuna.Substring(0, sColuna.IndexOf("=>")).Trim();

                if (!String.IsNullOrEmpty(sOpcao))
                {
                    ////////////////////////////////////////////////////////////////////////////////////////
                    string sSqlColuna = " select REPLACE(cc.IDCampo, 'v', 'Venda') Coluna ";
                    sSqlColuna += " from tCampanha_Campo cc   ";
                    sSqlColuna += " where cc.IDCampanha = " + iIDCampanha + "  ";
                    sSqlColuna += " and Texto in ('" + sCampo + "') ";

                    sCampo = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSqlColuna);
                    ////////////////////////////////////////////////////////////////////////////////////////

                    sSql += " alter table #Consolidado ";
                    sSql += " add [" + sOpcao + "] int  not null default(0) ";

                    sSql += " update #Consolidado ";
                    sSql += " set [" + sOpcao + "] = temp.Quantidade ";
                    sSql += " from (select IDUsuario, count(*) Quantidade ";
                    sSql += "       from #Vendas ";
                    sSql += "       where " + sCampo + " = '" + sOpcao + "' ";
                    sSql += "       group by IDUsuario) temp ";
                    sSql += " where temp.IDUsuario = #Consolidado.IDUsuario ";
                }
            }

            sSql += " alter table #Consolidado ";
            sSql += " drop column IDUsuario ";

            sSql += " select * from #Consolidado ";

            sSql += " if object_id('tempdb..#Consolidado') is not null drop table #Consolidado ";

            return sSql;
        }

        internal string RetornarObservacoesVenda(int iIDvenda)
        {
            string sSql = "select v.IDTratamento, v.Observacao [Observação], v.DataHoraCadastro[Horário do Envio], v.DataHoraLeitura[Horário da Leitura], r.Remetente [Remetente] ";
            sSql += "  from tVendaTratamento v ";
            sSql += "  inner join tRemetente r on r.IDRemetente = v.IDRemetente";
            sSql += "  where IDVenda = "+ iIDvenda +"";
            return sSql;
        }

        internal string RetornarDashboard(int iIDCampanha)
        {
            StringBuilder sSql = new StringBuilder();

            //Produtividade hoje (Resultado do contato)
            sSql.Append(" select s.Status, COUNT(*) Quantidade ");
            sSql.Append(" from tHistorico h ");
            sSql.Append(" inner join tStatus s on h.IDStatus = s.IDStatus ");
            sSql.Append(" inner join tProspect p on h.IDProspect = p.IDProspect ");
            sSql.Append(" inner join tMailing m on p.IDMailing = m.IDMailing ");
            sSql.Append(" where h.DataCadastro > CONVERT(varchar, getdate(), 111) ");
            if (iIDCampanha != -1) sSql.Append(" and m.IDCampanha = "+iIDCampanha+" ");
            sSql.Append(" group by s.Status ");
            sSql.Append(" order by COUNT(*) desc ");

            //Produtividade (todos operadores, últimos 10 dias)
            sSql.Append(" select top 10 DATEPART(YEAR, h.DataCadastro) Ano, ");
            sSql.Append(" DATEPART(MONTH, h.DataCadastro) Mes, ");
            sSql.Append(" DATEPART(DAY , h.DataCadastro) Dia, ");
            sSql.Append(" sum (case when (s.Venda = 1) then 1 else 0 end) Vendas, ");
            sSql.Append(" sum (case when (s.Venda = 1) then 0 else 1 end) NaoVenda ");
            sSql.Append(" from tHistorico h ");
            sSql.Append(" inner join tStatus s on h.IDStatus = s.IDStatus ");
            sSql.Append(" inner join tProspect p on h.IDProspect = p.IDProspect ");
            sSql.Append(" inner join tMailing m on p.IDMailing = m.IDMailing ");
            if (iIDCampanha != -1) sSql.Append(" where m.IDCampanha = " + iIDCampanha + " ");
            sSql.Append(" group by DATEPART(YEAR, h.DataCadastro), ");
            sSql.Append(" DATEPART(MONTH, h.DataCadastro), ");
            sSql.Append(" DATEPART(DAY , h.DataCadastro) ");
            sSql.Append(" order by DATEPART(YEAR, h.DataCadastro) desc, ");
            sSql.Append(" DATEPART(MONTH, h.DataCadastro) desc, ");
            sSql.Append(" DATEPART(DAY , h.DataCadastro) desc ");

            //Contatos realizados por operador (mês atual, top 10)
            sSql.Append(" select top 10 u.Nome Operador, ");
            sSql.Append(" sum (case when (s.Venda = 1) then 1 else 0 end) Vendas, ");
            sSql.Append(" sum (case when (s.Venda = 1) then 0 else 1 end) NaoVenda ");
            sSql.Append(" from tHistorico h ");
            sSql.Append(" inner join tStatus s on h.IDStatus = s.IDStatus ");
            sSql.Append(" inner join tProspect p on h.IDProspect = p.IDProspect ");
            sSql.Append(" inner join tMailing m on p.IDMailing = m.IDMailing ");
            sSql.Append(" inner join tUsuario u on h.IDUsuario = u.IDUsuario ");
            sSql.Append(" where h.DataCadastro > convert(varchar, DATEPART(YEAR, GETDATE())) + '/' + convert(varchar, DATEPART(MONTH, GETDATE())) + '/01' ");
            if (iIDCampanha != -1) sSql.Append(" and m.IDCampanha = " + iIDCampanha + " ");
            sSql.Append(" group by u.Nome ");
            sSql.Append(" order by COUNT(*) desc ");

            //Status mailing (ativos)
            sSql.Append(" select s.Status, count(*) Quantidade ");
            sSql.Append(" from tProspect p ");
            sSql.Append(" inner join tMailing m on p.IDMailing = m.IDMailing ");
            sSql.Append(" inner join tStatus s on p.IDStatus = s.IDStatus ");
            sSql.Append(" where m.Ativo = 1 ");
            if (iIDCampanha != -1) sSql.Append(" and m.IDCampanha = " + iIDCampanha + " ");
            sSql.Append(" group by s.Status ");
            sSql.Append(" order by COUNT(*) desc ");

            //Vendas (últimos 12 meses)
            sSql.Append(" select top 12 DATEPART(YEAR, h.DataCadastro) Ano, ");
            sSql.Append(" DATEPART(MONTH, h.DataCadastro) Mes, ");
            sSql.Append(" COUNT(*) Quantidade ");
            sSql.Append(" from tHistorico h ");
            sSql.Append(" inner join tStatus s on h.IDStatus = s.IDStatus ");
            sSql.Append(" inner join tProspect p on h.IDProspect = p.IDProspect ");
            sSql.Append(" inner join tMailing m on p.IDMailing = m.IDMailing ");
            sSql.Append(" where s.Venda = 1 ");
            if (iIDCampanha != -1) sSql.Append(" and m.IDCampanha = " + iIDCampanha + " ");
            sSql.Append(" group by DATEPART(YEAR, h.DataCadastro), ");
            sSql.Append(" DATEPART(MONTH, h.DataCadastro) ");
            sSql.Append(" order by DATEPART(YEAR, h.DataCadastro) desc, ");
            sSql.Append(" DATEPART(MONTH, h.DataCadastro) desc ");

            return sSql.ToString();
        }

        internal string RetornarVenda(int iIDHistorico)
        {
            string sSql = "exec sRetornarVenda ";
            sSql += "  @IDHistorico = "+iIDHistorico+" ";
            return sSql;
        }
    }
}

