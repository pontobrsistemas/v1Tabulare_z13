using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;
using System.Data;

namespace model.dados
{
    public class prospectDAL
    {
        internal string ImportarProspect(prospect Prospect)
        {
            string sSql = " exec sImportarProspect ";
            sSql += " @Nome = '" + Prospect.Nome + "', ";
            sSql += " @Telefone1  = " + Prospect.Telefone1 + ", ";
            sSql += " @Telefone2  = " + Prospect.Telefone2 + ", ";
            sSql += " @Telefone3  = " + Prospect.Telefone3 + ", ";
            sSql += " @CPF_CNPJ  = '" + Prospect.CPF_CNPJ + "', ";
            sSql += " @Logradouro  = '" + Prospect.Logradouro + "', ";
            sSql += " @Numero  = '" + Prospect.Numero + "', ";
            sSql += " @Complemento  = '" + Prospect.Complemento + "', ";
            sSql += " @Bairro = '" + Prospect.Bairro + "', ";
            sSql += " @Cidade = '" + Prospect.Cidade + "', ";
            sSql += " @Estado = '" + Prospect.Estado + "', ";
            sSql += " @Email = '" + Prospect.Email + "', ";
            sSql += " @Cep = '" + Prospect.Cep + "', ";
            sSql += " @Campo01 = '" + Prospect.Campo01 + "', ";
            sSql += " @Campo02 = '" + Prospect.Campo02 + "', ";
            sSql += " @Campo03 = '" + Prospect.Campo03 + "', ";
            sSql += " @Campo04 = '" + Prospect.Campo04 + "', ";
            sSql += " @Campo05 = '" + Prospect.Campo05 + "', ";
            sSql += " @Campo06 = '" + Prospect.Campo06 + "', ";
            sSql += " @Campo07 = '" + Prospect.Campo07 + "', ";
            sSql += " @Campo08 = '" + Prospect.Campo08 + "', ";
            sSql += " @Campo09 = '" + Prospect.Campo09 + "', ";
            sSql += " @Campo10 = '" + Prospect.Campo10 + "', ";
            sSql += " @IDMailing = " + Prospect.IDMailing + ", ";
            sSql += " @ImportarDuplicado = '" + Prospect.ImportarDuplicado + "' ";

            return sSql;
        }

        internal string RetornarProximoProspectPower(usuario Usuario)
        {
            string sSql = " exec sRetornarProximoProspectPower @IDCampanha = " + Usuario.IDCampanha + ", ";
            sSql += " @IDUsuario = " + Usuario.IDUsuario + " ";
            return sSql;
        }

        internal string RetornarProximoProspectPreditivo(int iIDCampanha, int iIDUsuario)
        {
            string sSql = " exec sRetornarProximoProspectPreditivo @IDCampanha = " + iIDCampanha + ", ";
            sSql += " @IDUsuario = " + iIDUsuario + " ";
            return sSql;
        }

        internal string RetornarProspect(string sCPF_CNPJ)
        {
            string sSql = " exec sRetornarProspectCpf @CPF ='" + sCPF_CNPJ + "' ";
            return sSql;
        }

        internal string RetornarHistoricoContato(double dTelefone1, int iIDMailing, int iScript)
        {
            string sSql = " select top 25 ";

            if (iScript == 1)
                sSql += " a.IDHistorico [Cód. Hist.], ";

            sSql += " a.IDProspect [Cód. Prosp.], e.Status, ";
            sSql += " a.Observacao [Observação], ";
            sSql += " Mailing,m.Campanha,  ";
            sSql += " d.Nome [Usuário], ";
            sSql += " a.DataCadastro [Data Contato] ";
            sSql += " from tHistorico a ";
            sSql += " inner join tProspect b on a.IDProspect = b.IDProspect ";
            sSql += " inner join tMailing c on b.IDMailing = c.IDMailing ";
            sSql += " inner join tCampanha m on c.IDCampanha = m.IDCampanha ";
            sSql += " inner join tUsuario d on a.IDUsuario = d.IDUsuario ";
            sSql += " inner join tStatus e on a.IDStatus = e.IDStatus ";
            sSql += " where a.Telefone1 = " + dTelefone1 + " ";

            if (iIDMailing != -1)
                sSql += " and b.IDMailing = " + iIDMailing + " ";

            sSql += " order by a.DataCadastro desc ";

            return sSql;
        }

        internal string RetornarQtdeProspectMailing(int iIDMailing)
        {
            string sSql = " select COUNT(*) Qtde from tProspect where IDMailing = " + iIDMailing + " ";
            return sSql;
        }

        internal string RetornarIDProspect(int iIDHistorico)
        {
            string sSql = " select IDProspect from tHistorico where IDHistorico = " + iIDHistorico + " ";
            return sSql;
        }

        internal string RetornarBloqueiosDDD(int iIDCampanha)
        {
            string sSql = " select c.Campanha, a.DDD, ";
            sSql += " a.DataCadastro [Data Cadastro],b.Nome [Usuário do Sistema] ";
            sSql += " from tBloqueioDDD a ";
            sSql += " inner join tUsuario b on a.IDUsuario = b.IDUsuario ";
            sSql += " inner join tCampanha c on a.IDCampanha = c.IDCampanha ";
            sSql += " where c.IDCampanha = " + iIDCampanha + " ";
            sSql += " order by a.DDD ";
            return sSql;
        }

        internal string AtualizarBloqueioDDD(int iBloqueio, int iDDD, int iIDUsuario)
        {
            string sSql = " update tBloqueioDDD ";
            sSql += " set Bloqueado = " + iBloqueio + ", ";
            sSql += " DataAlteracao = GETDATE(), IDUsuario = " + iIDUsuario + " ";
            sSql += " where DDD = " + iDDD + " ";
            return sSql;
        }

        internal string RetornarPerguntaResposta(int iIDHistorico)
        {
            string sSql = " select ";
            sSql += " rp.IDHistorico, ";
            sSql += " p.Pergunta, ";
            sSql += " r.Resposta  ";
            sSql += " from tResposta_Prospect rp ";
            sSql += " inner join tPergunta p on p.IDPergunta = rp.IDPergunta ";
            sSql += " inner join tResposta r on r.IDResposta = rp.IDResposta ";
            sSql += " where IDHistorico = " + iIDHistorico + " ";
            sSql += " order by p.IDPergunta ";

            return sSql;
        }

        internal string AtualizarDadosProspect(prospect Prospect, bool bAgendamento)
        {
            string sSql = " update tProspect ";
            sSql += " set Nome = '" + Prospect.Nome + "', ";
            sSql += " CPF_CNPJ = '" + Prospect.CPF_CNPJ + "', ";
            sSql += " Logradouro = '" + Prospect.Logradouro + "', ";
            sSql += " Numero = '" + Prospect.Numero + "', ";
            sSql += " Telefone2 = " + Prospect.Telefone2 + ", ";
            sSql += " Telefone3 = " + Prospect.Telefone3 + ",  ";
            sSql += " Bairro = '" + Prospect.Bairro + "',  ";
            sSql += " Cidade = '" + Prospect.Cidade + "',  ";
            sSql += " Complemento = '" + Prospect.Complemento + "',  ";
            sSql += " Estado = '" + Prospect.Estado + "',  ";
            sSql += " Email = '" + Prospect.Email + "',  ";
            sSql += " Cep = '" + Prospect.Cep + "',  ";//rr
            sSql += " Campo01 = '" + Prospect.Campo01 + "',  ";
            sSql += " Campo02 = '" + Prospect.Campo02 + "',  ";
            sSql += " Campo03 = '" + Prospect.Campo03 + "',  ";
            sSql += " Campo04 = '" + Prospect.Campo04 + "',  ";
            sSql += " Campo05 = '" + Prospect.Campo05 + "',  ";
            sSql += " Campo06 = '" + Prospect.Campo06 + "',  ";
            sSql += " Campo07 = '" + Prospect.Campo07 + "',  ";
            sSql += " Campo08 = '" + Prospect.Campo08 + "',  ";
            sSql += " Campo09 = '" + Prospect.Campo09 + "',  ";
            sSql += " Campo10 = '" + Prospect.Campo10 + "'  ";

            if (Prospect.IDMidia != 0 && Prospect.IDMidia != -1)
                sSql += ", IDMidia = '" + Prospect.IDMidia + "'  ";

            if (bAgendamento)
                sSql += ", Ativo = 1";

            sSql += " where IDProspect = " + Prospect.IDProspect + " ";

            return sSql;
        }

        internal string ExecutarResubmit(int iIDUsuario)
        {
            string sSql = " insert into tHistorico   ";
            sSql += " (IDProspect,Telefone1,IDUsuario,IDStatus,Observacao)  ";
            sSql += " select IDProspect, Telefone1, " + iIDUsuario + ", -3,'Resubmit - ' + CONVERT(varchar, getdate())  ";
            sSql += " from tTempResubmit  ";

            sSql += " update tProspect  ";
            sSql += " set IDStatus = -3,  ";
            sSql += " Ativo = 1,  ";
            sSql += " EmUso = 0  ";
            sSql += " where IDProspect in (select IDProspect from tTempResubmit)  ";

            sSql += "delete tTempResubmit ";

            return sSql;
        }

        internal string CadastrarBloqueioDDD(int iDDD, int iIDUsuario, int iIDCampanha)
        {
            string sSql = " if not exists (select * from tBloqueioDDD where DDD = " + iDDD + " and IDCampanha = " + iIDCampanha + ") insert into tBloqueioDDD(DDD,IDUsuario,IDCampanha) ";
            sSql += " values (" + iDDD + "," + iIDUsuario + "," + iIDCampanha + ") ";

            return sSql;
        }

        internal string ExcluirBloqueioDDD(int iDDD, int iIDCampanha)
        {
            string sSql = " delete tBloqueioDDD ";
            sSql += " where DDD = " + iDDD + " ";
            sSql += " and IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string ExcluirBloqueioDDD(int iIDCampanha)
        {
            string sSql = " delete tBloqueioDDD ";
            sSql += " where IDCampanha = " + iIDCampanha + " ";

            return sSql;
        }

        internal string RetornarAgendamentoOperador(int iIDUsuario, int iIDCampanha)
        {
            string sSql = " select  p.IDProspect [Cód. Prospect],  p.Nome [Cliente], ";
            sSql += " p.Telefone1 [Telefone 1], s.Status,   ";
            sSql += " Convert(varchar,p.DataProxContato,103)+ ' '+Convert(varchar,p.DataProxContato,108) [Data do Agendamento], ";
            sSql += " h.Observacao [Observação] ";
            sSql += " from  tProspect p   ";
            sSql += " inner join tStatus s on s.IDStatus = p.IDStatus  ";
            sSql += " inner join vUltimoHistorico u on u.IDProspect = p.IDProspect ";
            sSql += " inner join tHistorico h on h.IDHistorico = u.IDHistorico ";
            sSql += " where s.IDAcao = 2   ";
            sSql += " and p.EmUso = 0   ";
            sSql += " and p.Ativo = 1   ";
            sSql += " and DataProxContato is not null   ";
            sSql += " and p.IDUsuario = " + iIDUsuario + "   ";
            sSql += " order by DataProxContato  ";

            return sSql;
        }

        internal string RetornarProspect(int iIDProspect, int iIDUsuario)
        {
            string sSql = " exec sRetornarProspect @IDProspect = " + iIDProspect + ", ";
            sSql += " @IDUsuario = " + iIDUsuario + " ";
            return sSql;
        }

        internal string RetornarProspect(int iIDProspect)
        {
            string sSql = " SELECT a.IDProspect,a.Telefone1,a.Telefone2,a.Telefone3,a.Nome,a.CPF_CNPJ,a.Logradouro,a.Numero,a.Complemento, ";
            sSql += " a.Bairro,a.Cidade,a.Estado,a.Email,a.Cep,a.Campo01,a.Campo02,a.Campo03,a.Campo04,a.Campo05,a.Campo06,a.Campo07, ";
            sSql += " a.Campo08,a.Campo09,a.Campo10,a.IDMailing,b.Mailing,b.IDCampanha ";
            sSql += " FROM tProspect a ";
            sSql += " inner join tMailing b on a.IDMailing = b.IDMailing ";
            sSql += " where IDProspect = " + iIDProspect + " ";

            return sSql;
        }

        internal string CadastrarIndicacao(prospect Prospect)
        {
            string sSql = "  insert into tProspect ";
            sSql += " (Telefone1, ";
            sSql += " Telefone2, ";
            sSql += " Telefone3, ";
            sSql += " Nome, ";
            sSql += " IDMailing, ";
            sSql += " Email, ";
            sSql += " Cep, ";//rr
            sSql += " Logradouro, ";
            sSql += " Numero, ";
            sSql += " Complemento, ";
            sSql += " Bairro, ";
            sSql += " Cidade, ";
            sSql += " Estado, ";
            sSql += " CPF_CNPJ,  ";
            sSql += " Campo01,  ";
            sSql += " Campo02,  ";
            sSql += " Campo03,  ";
            sSql += " Campo04,  ";
            sSql += " Campo05,  ";
            sSql += " Campo06,  ";
            sSql += " Campo07,  ";
            sSql += " Campo08,  ";
            sSql += " Campo09,  ";
            sSql += " Campo10,  ";
            sSql += " EmUso, ";
            sSql += " IDUsuario, IDMidia) ";
            sSql += " values ";
            sSql += " (" + Prospect.Telefone1 + ", ";
            sSql += " " + Prospect.Telefone2 + ", ";
            sSql += " " + Prospect.Telefone3 + ", ";
            sSql += " '" + Prospect.Nome + "', ";
            sSql += " " + Prospect.IDMailing + ", ";
            sSql += " '" + Prospect.Email + "', ";
            sSql += " '" + Prospect.Cep + "', ";//rr
            sSql += " '" + Prospect.Logradouro + "', ";
            sSql += " '" + Prospect.Numero + "', ";
            sSql += " '" + Prospect.Complemento + "', ";
            sSql += " '" + Prospect.Bairro + "', ";
            sSql += " '" + Prospect.Cidade + "', ";
            sSql += " '" + Prospect.Estado + "', ";
            sSql += " '" + Prospect.CPF_CNPJ + "', ";
            sSql += " '" + Prospect.Campo01 + "', ";
            sSql += " '" + Prospect.Campo02 + "', ";
            sSql += " '" + Prospect.Campo03 + "', ";
            sSql += " '" + Prospect.Campo04 + "', ";
            sSql += " '" + Prospect.Campo05 + "', ";
            sSql += " '" + Prospect.Campo06 + "', ";
            sSql += " '" + Prospect.Campo07 + "', ";
            sSql += " '" + Prospect.Campo08 + "', ";
            sSql += " '" + Prospect.Campo09 + "', ";
            sSql += " '" + Prospect.Campo10 + "', ";
            sSql += " 1, ";
            sSql += " " + Prospect.IDUsuario + ", " + Prospect.IDMidia + ") ";

            return sSql;
        }

        internal string RetornarQuantidadeAgendamentoOperador(int iIDUsuario)
        {
            string sSql = " select ";
            sSql += " count(*) Quant ";
            sSql += " from tProspect a ";
            sSql += " inner join tStatus c on a.IDStatus = c.IDStatus ";
            sSql += " where a.IDUSuario = " + iIDUsuario + " ";
            sSql += " and a.Ativo = 1 and a.EmUSo = 0 and c.IDAcao = 2 ";
            sSql += " and a.DataProxContato < getdate() ";

            return sSql;
        }

        internal string RetornarMidias()
        {
            string sSql = " select IDMidia, Midia ";
            sSql += " from tMidia ";
            sSql += "  where Ativo = 1 ";
            sSql += " order by Midia ";

            return sSql;
        }

        internal string LimparTabelaTemporariaResubmit()
        {
            string sSql = " delete tTempResubmit ";
            return sSql;
        }

        internal string InserirProspectTemporiamenteResubmit(string sIDStatus, int iIDMailing, string sDataInicial, string sDataFinal, int iIDOperador, string sBairro, string sCidade, string sCep)
        {
            string sSql = " if object_id('tTempResubmit') is not null drop table tTempResubmit ";
            sSql += " select p.IDProspect, p.Telefone1 ";
            sSql += " into tTempResubmit  ";
            sSql += " from tHistorico h ";
            sSql += " inner join vUltimoHistorico u on h.IDHistorico = u.IDHistorico ";
            sSql += " inner join tProspect p on h.IDProspect = p.IDProspect ";
            sSql += " inner join tStatus s on h.IDStatus = s.IDStatus ";
            sSql += " where p.IDMailing = " + iIDMailing + " and p.Ativo = 0 ";
            sSql += " and s.PermiteResubmit = 1 ";
            sSql += " and h.IDStatus in (" + sIDStatus + ") ";

            if (sDataInicial != "")
                sSql += " and h.DataCadastro between '" + sDataInicial + "' and '" + sDataFinal + "' ";

            if (sBairro != "")
                sSql += " and p.Bairro like '%" + sBairro + "%'  ";

            if (sCidade != "")
                sSql += " and p.Cidade like '%" + sCidade + "%'  ";

            if (sCep != "")
                sSql += " and p.Cep like '%" + sCep + "%'  ";

            if (iIDOperador != -1)
                sSql += " and h.IDUsuario = " + iIDOperador + " ";

            return sSql;
        }

        internal string RetornarQuantidadeResubmit()
        {
            string sSql = " select count(*) from tTempResubmit ";
            return sSql;
        }

        internal string VerificarExistenciaTelefone(double dTelefone1, double dTelefone2, double dTelefone3)
        {
            string sSql = " select top 1 IDProspect ";
            sSql += " from tProspect  ";
            sSql += " where IDMailing is not null ";

            if (dTelefone1 != 0)
            {
                sSql += " and (Telefone1 = '" + dTelefone1 + "' ";
                sSql += " or Telefone2 = '" + dTelefone1 + "' ";
                sSql += " or Telefone3 = '" + dTelefone1 + "') ";
            }
            if (dTelefone2 != 0)
            {
                sSql += " and (Telefone2 = '" + dTelefone2 + "' ";
                sSql += " or Telefone3 = '" + dTelefone2 + "' ";
                sSql += " or Telefone1 = '" + dTelefone2 + "') ";
            }
            if (dTelefone3 != 0)
            {
                sSql += " and (Telefone3 = '" + dTelefone3 + "' ";
                sSql += " or Telefone2 = '" + dTelefone3 + "' ";
                sSql += " or Telefone1 = '" + dTelefone3 + "') ";
            }

            sSql += " order by IDProspect desc ";

            return sSql;
        }

        internal string RetornarUsuarioAgendamento(int iIDProspect)
        {
            string sSql = " select h.IDUsuario, s.IDStatus,s.IDAcao, u.Nome ";
            sSql += " from vUltimoHistorico v ";
            sSql += " inner join tHistorico h on v.IDHistorico = h.IDHistorico ";
            sSql += " inner join tStatus s on h.IDStatus = s.IDStatus ";
            sSql += " inner join tUsuario u on u.IDUsuario = h.IDUsuario ";
            sSql += " where v.IDProspect = " + iIDProspect + " ";
            sSql += " and s.IDAcao = 2 ";

            return sSql;
        }

        internal string AtualizarUsuarioAgendamento(int iIDProspectAgendamento, int iIDUsuarioAgendamento, int iIDStatusAgendamento)
        {
            string sSql = " update tProspect ";
            sSql += " set EmUso = 0, Ativo = 1, IDStatus = " + iIDStatusAgendamento + ",  ";
            sSql += " IDUsuario = " + iIDUsuarioAgendamento + " ";
            sSql += " where IDProspect = " + iIDProspectAgendamento + " ";
            return sSql;
        }

        internal string LiberarProspectEmUso(int iIDUsuario)
        {
            string sSql = " update tProspect ";
            sSql += " set EmUso = 0  ";
            sSql += " where IDUsuario = " + iIDUsuario + " ";

            return sSql;
        }

        internal string RetornarProspectsVirgens(int iIDMailing)
        {
            //string sSql = "  select top 50 * ";
            string sSql = "  select * ";
            sSql += " from tProspect ";
            sSql += " where IDMailing = " + iIDMailing + " ";
            sSql += " and IDStatus in (-1,-3) and IDProspect not in (select IDProspect from tEnviadoPreditivo)";

            return sSql;
        }

        internal string RetornarProspectsResubmit(int iIDMailing)
        {
            string sSql = "  select * ";
            sSql += " from tProspect ";
            sSql += " where IDMailing = " + iIDMailing + " ";
            sSql += " and IDStatus = -3";

            return sSql;
        }

        internal string CadastrarProspectEnviadoPreditivo(int iIDProspect)
        {
            string sSql = " insert into tEnviadoPreditivo (IDProspect) values (" + iIDProspect + ") ";

            return sSql;
        }

        //Mundiale Barrar a venda de um mesmo produto para o mesmo cliente no intervalo menor que 1 ano
        internal string RetornarUltimaVendaMundiale(string sCPF_CNPJ)
        {
            string sSql = " select top 1 DATEDIFF(day, [Data Venda], getDate()) [UltimaVenda] ";
            sSql += " from vVenda ";
            sSql += " where IDProspect in ";
            sSql += " (select IDProspect from tProspect where CPF_CNPJ = '" + sCPF_CNPJ + "') ";

            return sSql;
        }

        internal string RetornarConsultaCEP(string sCEP)
        {
            string sSql = " exec sRetornarEndereco @cep ='" + sCEP + "' ";
            return sSql;
        }

        internal DataTable RetornaProdutos(string tipo)
        {
            string sSql = " select id, nome from tProduto ";
            sSql += " where tipo = '" + tipo + "' and ativo = 1 order by nome ";

            DataTable dt = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dt;
        }

        internal string ExecutarResubmitCallFlex(int iIDUsuario, int iIDMailing, string sIDStatus)
        {
            string sSql = " exec sExecutarResubmitCallFlex ";
            sSql += " @IDUsuario = " + iIDUsuario + ",  ";
            sSql += " @IDMailing = " + iIDMailing + ", ";
            sSql += " @IDStatus = '" + sIDStatus + "' ";

            return sSql;
        }

        //VGX - Retornar produtos
        internal DataTable RetornarCuros(string sNomeCurso)
        {
            string sSql = " select NomeCurso, DescricaoCurso,AreaAtuacao, DuracaoCurso, ";
            sSql += " Localizacao, HorarioCurso, ValorCursoMatutino, ";
            sSql += " ValorCursoNoturno, ObservacaoCurso, Diferenciais ";
            sSql += " from tCurso ";
            sSql += " where NomeCurso = '" + sNomeCurso + "' ";

            DataTable DataTableCursos = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return DataTableCursos;
        }

        internal string PreencherComboBox_Cursos(int iIDCampanha)
        {
            string sSql = " select IDCurso, NomeCurso  from tCurso ";
            sSql += " where Ativo = 1 ";
            sSql += " and IDCampanha = " + iIDCampanha + " ";
            sSql += " order by NomeCurso asc ";

            return sSql;
        }

        internal string CadastrarProspectInvalido(string sProspect, string sMotivo, int iIDMailing)
        {
            string sSql = " insert into tProspectInvalido ";
            sSql += " (Prospect, Motivo, IDMailing) ";
            sSql += " values ";
            sSql += " ('" + sProspect + "', '" + sMotivo + "', " + iIDMailing + ") ";

            return sSql;
        }

        internal string RetornarProspectsInvalido(int iIDMailing)
        {
            string sSql = " select m.Mailing, i.Prospect, i.Motivo [Motivo da não importação] ";
            sSql += " from tProspectInvalido i ";
            sSql += " inner join tMailing m on i.IDMailing = m.IDMailing ";
            sSql += " where i.IDMailing = " + iIDMailing + " ";

            return sSql;
        }

        internal string CadastrarProspectInvalidoLista(prospect Prospect)
        {
            string sSql = " insert into tProspectInvalido ";
            sSql += " (Prospect, Motivo, IDMailing) ";
            sSql += " values ";
            sSql += " ('" + Prospect.sLinha + "', '" + Prospect.sMotivo + "', " + Prospect.IDMailing + ") ";//r

            return sSql;
        }

        internal string CadastrarBlackList(double dTelefone, int iIDUsuario)
        {
            string sSql = " insert into tBlackList ";
            sSql += " (Telefone, IDUsuario) ";
            sSql += " values ";
            sSql += " ('" + dTelefone + "', " + iIDUsuario + ") ";

            return sSql;
        }

        internal string RetornarBlackList()
        {
            string sSql = " select Telefone, ";
            sSql += " CONVERT(varchar, b.DataCadastro, 103) + ' ' + CONVERT(varchar, b.DataCadastro, 108) [Data/Hora Cadastro], ";
            sSql += " u.Nome [Responsável pela Inclusão] ";
            sSql += " from tBlackList b ";
            sSql += " inner join tUsuario u on b.IDUsuario = u.IDUsuario ";
            sSql += " order by Telefone ";

            return sSql;
        }

        internal string VerificarTelefoneBlackList(double dTelefone)
        {
            string sSql = " select * ";
            sSql += " from tBlackList ";
            sSql += " where Telefone = '" + dTelefone + "' ";

            return sSql;
        }

        internal string ExcluirTelefoneBlackList(double dTelefone)
        {
            string sSql = " delete tBlackList ";
            sSql += " where Telefone = '" + dTelefone + "' ";

            return sSql;
        }

        internal string SalvarContato(contato Contato)
        {
            string sSql = " exec sSalvarContato ";
            sSql += " @IDProspect = " + Contato.IDProspect + ", ";
            sSql += " @IDUsuario = " + Contato.IDUsuario + ", ";
            sSql += " @IDStatus = " + Contato.IDStatus + ", ";
            sSql += " @Observacao = '" + Contato.Observacao + "', ";
            sSql += " @IDTipoAtendimento = '" + Contato.IDTipoAtendimento + "', ";
            sSql += " @DataAbertura = '" + Contato.DataAbertura + "', ";
            sSql += " @RetornoPreditivo = " + Contato.RetornoPreditivo + " ";

            if (Contato.HoraAgendamento != null)
                sSql += " , @HoraAgendamento = '" + Contato.HoraAgendamento + "' ";

            sSql += " , @IDResposta = '" + Contato.IDResposta + "' ";


            if (Contato.Venda == true || Contato.IDStatus == -2)
            {
                sSql += ", @Venda01 = '" + Contato.Venda01 + "', ";
                sSql += " @Venda02 = '" + Contato.Venda02 + "', ";
                sSql += " @Venda03 = '" + Contato.Venda03 + "', ";
                sSql += " @Venda04 = '" + Contato.Venda04 + "', ";
                sSql += " @Venda05 = '" + Contato.Venda05 + "', ";
                sSql += " @Venda06 = '" + Contato.Venda06 + "', ";
                sSql += " @Venda07 = '" + Contato.Venda07 + "', ";
                sSql += " @Venda08 = '" + Contato.Venda08 + "', ";
                sSql += " @Venda09 = '" + Contato.Venda09 + "', ";
                sSql += " @Venda10 = '" + Contato.Venda10 + "', ";
                sSql += " @Venda11 = '" + Contato.Venda11 + "', ";
                sSql += " @Venda12 = '" + Contato.Venda12 + "', ";
                sSql += " @Venda13 = '" + Contato.Venda13 + "', ";
                sSql += " @Venda14 = '" + Contato.Venda14 + "', ";
                sSql += " @Venda15 = '" + Contato.Venda15 + "', ";
                sSql += " @Venda16 = '" + Contato.Venda16 + "', ";
                sSql += " @Venda17 = '" + Contato.Venda17 + "', ";
                sSql += " @Venda18 = '" + Contato.Venda18 + "', ";
                sSql += " @Venda19 = '" + Contato.Venda19 + "', ";
                sSql += " @Venda20 = '" + Contato.Venda20 + "', ";
                sSql += " @Venda21 = '" + Contato.Venda21 + "', ";
                sSql += " @Venda22 = '" + Contato.Venda22 + "', ";
                sSql += " @Venda23 = '" + Contato.Venda23 + "', ";
                sSql += " @Venda24 = '" + Contato.Venda24 + "', ";
                sSql += " @Venda25 = '" + Contato.Venda25 + "', ";
                sSql += " @Venda26 = '" + Contato.Venda26 + "', ";
                sSql += " @Venda27 = '" + Contato.Venda27 + "', ";
                sSql += " @Venda28 = '" + Contato.Venda28 + "', ";
                sSql += " @Venda29 = '" + Contato.Venda29 + "', ";
                sSql += " @Venda30 = '" + Contato.Venda30 + "', ";
                sSql += " @Venda31 = '" + Contato.Venda31 + "', ";
                sSql += " @Venda32 = '" + Contato.Venda32 + "', ";
                sSql += " @Venda33 = '" + Contato.Venda33 + "', ";
                sSql += " @Venda34 = '" + Contato.Venda34 + "', ";
                sSql += " @Venda35 = '" + Contato.Venda35 + "', ";
                sSql += " @Venda36 = '" + Contato.Venda36 + "', ";
                sSql += " @Venda37 = '" + Contato.Venda37 + "', ";
                sSql += " @Venda38 = '" + Contato.Venda38 + "', ";
                sSql += " @Venda39 = '" + Contato.Venda39 + "', ";
                sSql += " @Venda40 = '" + Contato.Venda40 + "', ";
                sSql += " @Venda41 = '" + Contato.Venda41 + "', ";
                sSql += " @Venda42 = '" + Contato.Venda42 + "', ";
                sSql += " @Venda43 = '" + Contato.Venda43 + "', ";
                sSql += " @Venda44 = '" + Contato.Venda44 + "', ";
                sSql += " @Venda45 = '" + Contato.Venda45 + "', ";
                sSql += " @Venda46 = '" + Contato.Venda46 + "', ";
                sSql += " @Venda47 = '" + Contato.Venda47 + "', ";
                sSql += " @Venda48 = '" + Contato.Venda48 + "', ";
                sSql += " @Venda49 = '" + Contato.Venda49 + "', ";
                sSql += " @Venda50 = '" + Contato.Venda50 + "', ";
                sSql += " @Venda51 = '" + Contato.Venda51 + "', ";
                sSql += " @Venda52 = '" + Contato.Venda52 + "', ";
                sSql += " @Venda53 = '" + Contato.Venda53 + "', ";
                sSql += " @Venda54 = '" + Contato.Venda54 + "', ";
                sSql += " @Venda55 = '" + Contato.Venda55 + "', ";
                sSql += " @Venda56 = '" + Contato.Venda56 + "', ";
                sSql += " @Venda57 = '" + Contato.Venda57 + "', ";
                sSql += " @Venda58 = '" + Contato.Venda58 + "', ";
                sSql += " @Venda59 = '" + Contato.Venda59 + "', ";
                sSql += " @Venda60 = '" + Contato.Venda60 + "' ";
            }
            return sSql;
        }

        internal string SalvarContatoConecctta(contato Contato)
        {
            string sSql = " exec sSalvarContato ";
            sSql += " @IDProspect = " + Contato.IDProspect + ", ";
            sSql += " @IDUsuario = " + Contato.IDUsuario + ", ";
            sSql += " @IDStatus = " + Contato.IDStatus + ", ";
            sSql += " @Observacao = '" + Contato.Observacao + "', ";
            sSql += " @IDTipoAtendimento = '" + Contato.IDTipoAtendimento + "', ";
            sSql += " @DataAbertura = '" + Contato.DataAbertura + "', ";
            sSql += " @RetornoPreditivo = " + Contato.RetornoPreditivo + " ";

            if (Contato.HoraAgendamento != null)
                sSql += " , @HoraAgendamento = '" + Contato.HoraAgendamento + "' ";

            sSql += " , @IDResposta = '" + Contato.IDResposta + "' ";


            if (Contato.Venda == true || Contato.IDStatus == -2 || Contato.IDStatus == 20)
            {
                sSql += ", @Venda01 = '" + Contato.Venda01 + "', ";
                sSql += " @Venda02 = '" + Contato.Venda02 + "', ";
                sSql += " @Venda03 = '" + Contato.Venda03 + "', ";
                sSql += " @Venda04 = '" + Contato.Venda04 + "', ";
                sSql += " @Venda05 = '" + Contato.Venda05 + "', ";
                sSql += " @Venda06 = '" + Contato.Venda06 + "', ";
                sSql += " @Venda07 = '" + Contato.Venda07 + "', ";
                sSql += " @Venda08 = '" + Contato.Venda08 + "', ";
                sSql += " @Venda09 = '" + Contato.Venda09 + "', ";
                sSql += " @Venda10 = '" + Contato.Venda10 + "', ";
                sSql += " @Venda11 = '" + Contato.Venda11 + "', ";
                sSql += " @Venda12 = '" + Contato.Venda12 + "', ";
                sSql += " @Venda13 = '" + Contato.Venda13 + "', ";
                sSql += " @Venda14 = '" + Contato.Venda14 + "', ";
                sSql += " @Venda15 = '" + Contato.Venda15 + "', ";
                sSql += " @Venda16 = '" + Contato.Venda16 + "', ";
                sSql += " @Venda17 = '" + Contato.Venda17 + "', ";
                sSql += " @Venda18 = '" + Contato.Venda18 + "', ";
                sSql += " @Venda19 = '" + Contato.Venda19 + "', ";
                sSql += " @Venda20 = '" + Contato.Venda20 + "', ";
                sSql += " @Venda21 = '" + Contato.Venda21 + "', ";
                sSql += " @Venda22 = '" + Contato.Venda22 + "', ";
                sSql += " @Venda23 = '" + Contato.Venda23 + "', ";
                sSql += " @Venda24 = '" + Contato.Venda24 + "', ";
                sSql += " @Venda25 = '" + Contato.Venda25 + "', ";
                sSql += " @Venda26 = '" + Contato.Venda26 + "', ";
                sSql += " @Venda27 = '" + Contato.Venda27 + "', ";
                sSql += " @Venda28 = '" + Contato.Venda28 + "', ";
                sSql += " @Venda29 = '" + Contato.Venda29 + "', ";
                sSql += " @Venda30 = '" + Contato.Venda30 + "', ";
                sSql += " @Venda31 = '" + Contato.Venda31 + "', ";
                sSql += " @Venda32 = '" + Contato.Venda32 + "', ";
                sSql += " @Venda33 = '" + Contato.Venda33 + "', ";
                sSql += " @Venda34 = '" + Contato.Venda34 + "', ";
                sSql += " @Venda35 = '" + Contato.Venda35 + "', ";
                sSql += " @Venda36 = '" + Contato.Venda36 + "', ";
                sSql += " @Venda37 = '" + Contato.Venda37 + "', ";
                sSql += " @Venda38 = '" + Contato.Venda38 + "', ";
                sSql += " @Venda39 = '" + Contato.Venda39 + "', ";
                sSql += " @Venda40 = '" + Contato.Venda40 + "', ";
                sSql += " @Venda41 = '" + Contato.Venda41 + "', ";
                sSql += " @Venda42 = '" + Contato.Venda42 + "', ";
                sSql += " @Venda43 = '" + Contato.Venda43 + "', ";
                sSql += " @Venda44 = '" + Contato.Venda44 + "', ";
                sSql += " @Venda45 = '" + Contato.Venda45 + "', ";
                sSql += " @Venda46 = '" + Contato.Venda46 + "', ";
                sSql += " @Venda47 = '" + Contato.Venda47 + "', ";
                sSql += " @Venda48 = '" + Contato.Venda48 + "', ";
                sSql += " @Venda49 = '" + Contato.Venda49 + "', ";
                sSql += " @Venda50 = '" + Contato.Venda50 + "', ";
                sSql += " @Venda51 = '" + Contato.Venda51 + "', ";
                sSql += " @Venda52 = '" + Contato.Venda52 + "', ";
                sSql += " @Venda53 = '" + Contato.Venda53 + "', ";
                sSql += " @Venda54 = '" + Contato.Venda54 + "', ";
                sSql += " @Venda55 = '" + Contato.Venda55 + "', ";
                sSql += " @Venda56 = '" + Contato.Venda56 + "', ";
                sSql += " @Venda57 = '" + Contato.Venda57 + "', ";
                sSql += " @Venda58 = '" + Contato.Venda58 + "', ";
                sSql += " @Venda59 = '" + Contato.Venda59 + "', ";
                sSql += " @Venda60 = '" + Contato.Venda60 + "' ";
            }
            return sSql;
        }

        internal string SalvarRespostasContato(int iIDPergunta, int iIDResposta, int iIDHistorico)
        {
            string sSql = " insert into tResposta_Prospect ";
            sSql += " (IDPergunta, IDResposta, IDHistorico) ";
            sSql += " values ";
            sSql += " (" + iIDPergunta + ", " + iIDResposta + ", " + iIDHistorico + ")  ";

            return sSql;
        }

        internal string VerificarExistenciaVenda(int iIDHistorico)
        {
            string sSql = " select * ";
            sSql += " from tVenda where IDHistorico = " + iIDHistorico + " ";

            return sSql;
        }

        internal string SalvarDadosVenda(int iIDHistorico, prospect Prospect)
        {
            string sSql = " insert into tVenda ";
            sSql += " (IDHistorico,   ";
            sSql += " Venda01,   ";
            sSql += " Venda02,   ";
            sSql += " Venda03,   ";
            sSql += " Venda04,   ";
            sSql += " Venda05,   ";
            sSql += " Venda06,   ";
            sSql += " Venda07,   ";
            sSql += " Venda08,   ";
            sSql += " Venda09,   ";
            sSql += " Venda10,   ";
            sSql += " Venda11,   ";
            sSql += " Venda12,   ";
            sSql += " Venda13,   ";
            sSql += " Venda14,   ";
            sSql += " Venda15,   ";
            sSql += " Venda16,   ";
            sSql += " Venda17,   ";
            sSql += " Venda18,   ";
            sSql += " Venda19,   ";
            sSql += " Venda20,   ";
            sSql += " Venda21,   ";
            sSql += " Venda22,   ";
            sSql += " Venda23,   ";
            sSql += " Venda24,   ";
            sSql += " Venda25,   ";
            sSql += " Venda26,   ";
            sSql += " Venda27,   ";
            sSql += " Venda28,   ";
            sSql += " Venda29,   ";
            sSql += " Venda30,   ";
            sSql += " Venda31,   ";
            sSql += " Venda32,   ";
            sSql += " Venda33,   ";
            sSql += " Venda34,   ";
            sSql += " Venda35,   ";
            sSql += " Venda36,   ";
            sSql += " Venda37,   ";
            sSql += " Venda38,   ";
            sSql += " Venda39,   ";
            sSql += " Venda40,   ";
            sSql += " Venda41,   ";
            sSql += " Venda42,   ";
            sSql += " Venda43,   ";
            sSql += " Venda44,   ";
            sSql += " Venda45,   ";
            sSql += " Venda46,   ";
            sSql += " Venda47,   ";
            sSql += " Venda48,   ";
            sSql += " Venda49,   ";
            sSql += " Venda50,   ";
            sSql += " Venda51,   ";
            sSql += " Venda52,   ";
            sSql += " Venda53,   ";
            sSql += " Venda54,   ";
            sSql += " Venda55,   ";
            sSql += " Venda56,   ";
            sSql += " Venda57,   ";
            sSql += " Venda58,   ";
            sSql += " Venda59,   ";
            sSql += " Venda60) ";
            sSql += " values ";
            sSql += " (" + iIDHistorico + ", ";
            sSql += " '" + Prospect.Venda01 + "',   ";
            sSql += " '" + Prospect.Venda02 + "',   ";
            sSql += " '" + Prospect.Venda03 + "',   ";
            sSql += " '" + Prospect.Venda04 + "',   ";
            sSql += " '" + Prospect.Venda05 + "',   ";
            sSql += " '" + Prospect.Venda06 + "',   ";
            sSql += " '" + Prospect.Venda07 + "',   ";
            sSql += " '" + Prospect.Venda08 + "',   ";
            sSql += " '" + Prospect.Venda09 + "',   ";
            sSql += " '" + Prospect.Venda10 + "',   ";
            sSql += " '" + Prospect.Venda11 + "',   ";
            sSql += " '" + Prospect.Venda12 + "',   ";
            sSql += " '" + Prospect.Venda13 + "',   ";
            sSql += " '" + Prospect.Venda14 + "',   ";
            sSql += " '" + Prospect.Venda15 + "',   ";
            sSql += " '" + Prospect.Venda16 + "',   ";
            sSql += " '" + Prospect.Venda17 + "',   ";
            sSql += " '" + Prospect.Venda18 + "',   ";
            sSql += " '" + Prospect.Venda19 + "',   ";
            sSql += " '" + Prospect.Venda20 + "',   ";
            sSql += " '" + Prospect.Venda21 + "',   ";
            sSql += " '" + Prospect.Venda22 + "',   ";
            sSql += " '" + Prospect.Venda23 + "',   ";
            sSql += " '" + Prospect.Venda24 + "',   ";
            sSql += " '" + Prospect.Venda25 + "',   ";
            sSql += " '" + Prospect.Venda26 + "',   ";
            sSql += " '" + Prospect.Venda27 + "',   ";
            sSql += " '" + Prospect.Venda28 + "',   ";
            sSql += " '" + Prospect.Venda29 + "',   ";
            sSql += " '" + Prospect.Venda30 + "',   ";
            sSql += " '" + Prospect.Venda31 + "',   ";
            sSql += " '" + Prospect.Venda32 + "',   ";
            sSql += " '" + Prospect.Venda33 + "',   ";
            sSql += " '" + Prospect.Venda34 + "',   ";
            sSql += " '" + Prospect.Venda35 + "',   ";
            sSql += " '" + Prospect.Venda36 + "',   ";
            sSql += " '" + Prospect.Venda37 + "',   ";
            sSql += " '" + Prospect.Venda38 + "',   ";
            sSql += " '" + Prospect.Venda39 + "',   ";
            sSql += " '" + Prospect.Venda40 + "',   ";
            sSql += " '" + Prospect.Venda41 + "',   ";
            sSql += " '" + Prospect.Venda42 + "',   ";
            sSql += " '" + Prospect.Venda43 + "',   ";
            sSql += " '" + Prospect.Venda44 + "',   ";
            sSql += " '" + Prospect.Venda45 + "',   ";
            sSql += " '" + Prospect.Venda46 + "',   ";
            sSql += " '" + Prospect.Venda47 + "',   ";
            sSql += " '" + Prospect.Venda48 + "',   ";
            sSql += " '" + Prospect.Venda49 + "',   ";
            sSql += " '" + Prospect.Venda50 + "',   ";
            sSql += " '" + Prospect.Venda51 + "',   ";
            sSql += " '" + Prospect.Venda52 + "',   ";
            sSql += " '" + Prospect.Venda53 + "',   ";
            sSql += " '" + Prospect.Venda54 + "',   ";
            sSql += " '" + Prospect.Venda55 + "',   ";
            sSql += " '" + Prospect.Venda56 + "',   ";
            sSql += " '" + Prospect.Venda57 + "',   ";
            sSql += " '" + Prospect.Venda58 + "',   ";
            sSql += " '" + Prospect.Venda59 + "',   ";
            sSql += " '" + Prospect.Venda60 + "')   ";

            return sSql;
        }

        internal string AtualizarDadosVenda(int iIDHistorico, prospect Prospect)
        {
            string sSql = " Update tVenda ";
            sSql += " set Venda01 = '" + Prospect.Venda01 + "',   ";
            sSql += " Venda02 = '" + Prospect.Venda02 + "',   ";
            sSql += " Venda03 = '" + Prospect.Venda03 + "',   ";
            sSql += " Venda04 = '" + Prospect.Venda04 + "',   ";
            sSql += " Venda05 = '" + Prospect.Venda05 + "',   ";
            sSql += " Venda06 = '" + Prospect.Venda06 + "',   ";
            sSql += " Venda07 = '" + Prospect.Venda07 + "',   ";
            sSql += " Venda08 = '" + Prospect.Venda08 + "',   ";
            sSql += " Venda09 = '" + Prospect.Venda09 + "',   ";
            sSql += " Venda10 = '" + Prospect.Venda10 + "',   ";
            sSql += " Venda11 = '" + Prospect.Venda11 + "',   ";
            sSql += " Venda12 = '" + Prospect.Venda12 + "',   ";
            sSql += " Venda13 = '" + Prospect.Venda13 + "',   ";
            sSql += " Venda14 = '" + Prospect.Venda14 + "',   ";
            sSql += " Venda15 = '" + Prospect.Venda15 + "',   ";
            sSql += " Venda16 = '" + Prospect.Venda16 + "',   ";
            sSql += " Venda17 = '" + Prospect.Venda17 + "',   ";
            sSql += " Venda18 = '" + Prospect.Venda18 + "',   ";
            sSql += " Venda19 = '" + Prospect.Venda19 + "',   ";
            sSql += " Venda20 = '" + Prospect.Venda20 + "',   ";
            sSql += " Venda21 = '" + Prospect.Venda21 + "',   ";
            sSql += " Venda22 = '" + Prospect.Venda22 + "',   ";
            sSql += " Venda23 = '" + Prospect.Venda23 + "',   ";
            sSql += " Venda24 = '" + Prospect.Venda24 + "',   ";
            sSql += " Venda25 = '" + Prospect.Venda25 + "',   ";
            sSql += " Venda26 = '" + Prospect.Venda26 + "',   ";
            sSql += " Venda27 = '" + Prospect.Venda27 + "',   ";
            sSql += " Venda28 = '" + Prospect.Venda28 + "',   ";
            sSql += " Venda29 = '" + Prospect.Venda29 + "',   ";
            sSql += " Venda30 = '" + Prospect.Venda30 + "',   ";
            sSql += " Venda31 = '" + Prospect.Venda31 + "',   ";
            sSql += " Venda32 = '" + Prospect.Venda32 + "',   ";
            sSql += " Venda33 = '" + Prospect.Venda33 + "',   ";
            sSql += " Venda34 = '" + Prospect.Venda34 + "',   ";
            sSql += " Venda35 = '" + Prospect.Venda35 + "',   ";
            sSql += " Venda36 = '" + Prospect.Venda36 + "',   ";
            sSql += " Venda37 = '" + Prospect.Venda37 + "',   ";
            sSql += " Venda38 = '" + Prospect.Venda38 + "',   ";
            sSql += " Venda39 = '" + Prospect.Venda39 + "',   ";
            sSql += " Venda40 = '" + Prospect.Venda40 + "',   ";
            sSql += " Venda41 = '" + Prospect.Venda41 + "',   ";
            sSql += " Venda42 = '" + Prospect.Venda42 + "',   ";
            sSql += " Venda43 = '" + Prospect.Venda43 + "',   ";
            sSql += " Venda44 = '" + Prospect.Venda44 + "',   ";
            sSql += " Venda45 = '" + Prospect.Venda45 + "',   ";
            sSql += " Venda46 = '" + Prospect.Venda46 + "',   ";
            sSql += " Venda47 = '" + Prospect.Venda47 + "',   ";
            sSql += " Venda48 = '" + Prospect.Venda48 + "',   ";
            sSql += " Venda49 = '" + Prospect.Venda49 + "',   ";
            sSql += " Venda50 = '" + Prospect.Venda50 + "',   ";
            sSql += " Venda51 = '" + Prospect.Venda51 + "',   ";
            sSql += " Venda52 = '" + Prospect.Venda52 + "',   ";
            sSql += " Venda53 = '" + Prospect.Venda53 + "',   ";
            sSql += " Venda54 = '" + Prospect.Venda54 + "',   ";
            sSql += " Venda55 = '" + Prospect.Venda55 + "',   ";
            sSql += " Venda56 = '" + Prospect.Venda56 + "',   ";
            sSql += " Venda57 = '" + Prospect.Venda57 + "',   ";
            sSql += " Venda58 = '" + Prospect.Venda58 + "',   ";
            sSql += " Venda59 = '" + Prospect.Venda59 + "',   ";
            sSql += " Venda60 = '" + Prospect.Venda60 + "',    ";

            if (Prospect.IDStatusAuditoria != 0)
                sSql += " IDStatus = '" + Prospect.IDStatusAuditoria + "',    ";

            if (Prospect.IDUsuarioAuditoria != 0)
                sSql += " IDUsuarioAuditoria = '" + Prospect.IDUsuarioAuditoria + "',    ";

            sSql += " DataAuditoria = getdate() ";
            sSql += " where IDHistorico = " + iIDHistorico + " ";

            return sSql;
        }

        internal string AtualizarHistorico(int iIDHistorico, string sDataCadastro, string sObservacao)
        {
            string sSql = " update tHistorico set Observacao = '" + sObservacao + "', ";
            sSql += " DataCadastro = '" + sDataCadastro + "' ";
            sSql += " where IDHistorico = " + iIDHistorico + " ";

            return sSql;
        }

        internal string AtualizarHistorico(int iIDHistorico, string sObservacao)
        {
            string sSql = " update tHistorico set Observacao = '" + sObservacao + "' ";
            sSql += " where IDHistorico = " + iIDHistorico + " ";

            return sSql;
        }

        internal string PegarVendaParaAuditarBackoffice(int iIDHistorio, int iIDUsuario)
        {
            string sSql = " update tVenda ";

            if (iIDUsuario != -1)
                sSql += " set IDUsuarioEmUso = " + iIDUsuario + " ";
            else
                sSql += " set IDUsuarioEmUso = null ";

            sSql += " Where IDHistorico = " + iIDHistorio + " ";

            return sSql;
        }

        internal string VerificarVendaSendoAuditadaBackoffice(int iIDHistorio, int iIDUsuario)
        {
            string sSql = " select u.Nome ";
            sSql += " from tVenda v ";
            sSql += " inner join tUsuario u on v.IDUsuarioEmUso = u.IDUsuario ";
            sSql += " where v.IDHistorico = " + iIDHistorio + " ";
            sSql += " and (v.IDUsuarioEmUso != " + iIDUsuario + " and v.IDUsuarioEmUso is not null) ";

            return sSql;
        }

        internal string ExcluirMailing(int iIDMailing)
        {
            string sSql = "delete tProspectInvalido where IDMailing = " + iIDMailing;
            sSql += " delete tMailing where IDMailing = " + iIDMailing + " ";

            return sSql;
        }

        internal string RetornarHistoricoVenda(int iIDProspect)
        {
            string sSql = " select h.IDHistorico  ";
            sSql += " from tVenda v ";
            sSql += " inner join tHistorico h on v.IDHistorico = h.IDHistorico ";
            sSql += " where h.IDProspect = " + iIDProspect + " ";

            return sSql;
        }

        internal string CadastrarLogAuditoria(int iIDHistorico, int iIDBackoffice, string sCampo, string sDe, string sPara, string sDNS)
        {
            string sSql = " insert into tLogAuditoria ";
            sSql += " (Campo, De, Para, IDHistorico, IDBackoffice, DNS) ";
            sSql += " values ";
            sSql += " ('" + sCampo + "', '" + sDe + "', '" + sPara + "', " + iIDHistorico + ", " + iIDBackoffice + ", '" + sDNS + "') ";

            return sSql;
        }

        internal string EnviarObservacaoTratamentoVenda(int iIDVenda, int iIDUsuario, string sObservacao, int iRemetente)
        {
            string sSql = " insert into tVendaTratamento ";
            sSql += " (IDVenda, Observacao, IDUsuarioCadastro, IDRemetente) ";
            sSql += " values ";
            sSql += " (" + iIDVenda + " ";
            sSql += " ,'" + sObservacao + "', " + iIDUsuario + ", " + iRemetente + ") ";

            return sSql;
        }

        internal string AtualizarLeituraTratamentoVenda(int iIDVenda, int iIDTratamento, int iIDUsuario)
        {

            string sSql = "update tVendaTratamento set DataHoraLeitura = getdate() ";
            sSql += "where IDVenda = " + iIDVenda + " ";
            sSql += "and IDTratamento = '" + iIDTratamento + "' ";
            sSql += "and DataHoraLeitura is null ";
            sSql += "and IDUsuarioCadastro != " + iIDUsuario + "";

            return sSql;
        }

        internal string RetornarMensagensTratamentoVenda(int iIDUsuario, string sPerfil)
        {
            string sSql = "select  h.IDHistorico ";
            sSql += "from tVendaTratamento vt ";
            sSql += "inner join tVenda v on v.IDVenda = vt.IDVenda ";
            sSql += "inner join tHistorico h on h.IDHistorico = v.IDHistorico ";
            sSql += "inner join tUsuario u on h.IDUsuario = u.IDUsuario ";
            sSql += "inner join tProspect p on h.IDProspect = p.IDProspect ";
            sSql += "where DataHoraLeitura is null ";

            if (sPerfil == "Operador")
                sSql += "and h.IDUsuario = " + iIDUsuario + " ";

            sSql += "and vt.IDUsuarioCadastro != " + iIDUsuario + " ";
            sSql += "group by h.IDHistorico ";
            sSql += "order by h.IDHistorico ";

            return sSql;
        }

        internal string RetornarMensagensTratamentoVendaBackoffice(int iIDUsuario, string sPerfil)
        {
            string sSql = "select  h.IDHistorico ";
            sSql += "from tVendaTratamento vt ";
            sSql += "inner join tVenda v on v.IDVenda = vt.IDVenda ";
            sSql += "inner join tHistorico h on h.IDHistorico = v.IDHistorico ";
            sSql += "inner join tUsuario u on h.IDUsuario = u.IDUsuario ";
            sSql += "inner join tProspect p on h.IDProspect = p.IDProspect ";
            sSql += "where DataHoraLeitura is null ";

            if (sPerfil == "Operador")
                sSql += "and vt.IDUsuarioCadastro = " + iIDUsuario + " ";
            
            sSql += "group by h.IDHistorico ";
            sSql += "order by h.IDHistorico ";

            return sSql;
        }
    }
}
