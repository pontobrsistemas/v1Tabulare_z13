using System;
using System.Collections.Generic;
using System.Text;
using model.objetos;
using model.dados;
using model.negocios;
using System.Data;
using System.Collections;

namespace model.negocios
{
    public class prospectBLL
    {
        public void ImportarProspect(prospect[] Prospects)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql;
            List<string> sListaSql = new List<string>();

            for (int i = 0; i < Prospects.Length; i++)
            {
                if (Prospects[i] != null) /*Verifica se há prospect*/
                {
                    sSql = DProspect.ImportarProspect(Prospects[i]);
                    sListaSql.Add(sSql);
                }
            }

            PontoBr.Banco.SqlServer.ExecutarSql(sListaSql);
        }

        public prospect RetornarProximoProspectPower(usuario Usuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarProximoProspectPower(Usuario);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            prospect Prospect = new prospect();

            if (dataTable.Rows.Count > 0)
            {
                Prospect.IDProspect = Convert.ToInt32(dataTable.Rows[0]["IDProspect"].ToString());
                Prospect.Telefone1 = Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString());
                Prospect.Telefone2 = Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString());
                Prospect.Telefone3 = Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString());
                Prospect.Nome = dataTable.Rows[0]["Nome"].ToString();
                Prospect.CPF_CNPJ = dataTable.Rows[0]["CPF_CNPJ"].ToString();
                Prospect.Logradouro = dataTable.Rows[0]["Logradouro"].ToString();
                Prospect.Numero = dataTable.Rows[0]["Numero"].ToString();
                Prospect.Complemento = dataTable.Rows[0]["Complemento"].ToString();
                Prospect.Bairro = dataTable.Rows[0]["Bairro"].ToString();
                Prospect.Cidade = dataTable.Rows[0]["Cidade"].ToString();
                Prospect.Estado = dataTable.Rows[0]["Estado"].ToString();
                Prospect.Email = dataTable.Rows[0]["Email"].ToString();
                Prospect.Cep = dataTable.Rows[0]["Cep"].ToString();//rr
                Prospect.Campo01 = dataTable.Rows[0]["Campo01"].ToString();
                Prospect.Campo02 = dataTable.Rows[0]["Campo02"].ToString();
                Prospect.Campo03 = dataTable.Rows[0]["Campo03"].ToString();
                Prospect.Campo04 = dataTable.Rows[0]["Campo04"].ToString();
                Prospect.Campo05 = dataTable.Rows[0]["Campo05"].ToString();
                Prospect.Campo06 = dataTable.Rows[0]["Campo06"].ToString();
                Prospect.Campo07 = dataTable.Rows[0]["Campo07"].ToString();
                Prospect.Campo08 = dataTable.Rows[0]["Campo08"].ToString();
                Prospect.Campo09 = dataTable.Rows[0]["Campo09"].ToString();
                Prospect.Campo10 = dataTable.Rows[0]["Campo10"].ToString();

                Prospect.IDMailing = Convert.ToInt32(dataTable.Rows[0]["IDMailing"].ToString());
                Prospect.IDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
                Prospect.Mailing = dataTable.Rows[0]["Mailing"].ToString();
            }

            return Prospect;
        }

        public prospect RetornarProximoProspectPreditivo(int iIDCampanha, int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarProximoProspectPreditivo(iIDCampanha, iIDUsuario);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            prospect Prospect = new prospect();

            if (dataTable.Rows.Count > 0)
            {
                Prospect.IDProspect = Convert.ToInt32(dataTable.Rows[0]["IDProspect"].ToString());
                Prospect.Telefone1 = Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString());
                Prospect.Telefone2 = Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString());
                Prospect.Telefone3 = Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString());
                Prospect.Nome = dataTable.Rows[0]["Nome"].ToString();
                Prospect.CPF_CNPJ = dataTable.Rows[0]["CPF_CNPJ"].ToString();
                Prospect.Logradouro = dataTable.Rows[0]["Logradouro"].ToString();
                Prospect.Numero = dataTable.Rows[0]["Numero"].ToString();
                Prospect.Complemento = dataTable.Rows[0]["Complemento"].ToString();
                Prospect.Bairro = dataTable.Rows[0]["Bairro"].ToString();
                Prospect.Cidade = dataTable.Rows[0]["Cidade"].ToString();
                Prospect.Estado = dataTable.Rows[0]["Estado"].ToString();
                Prospect.Email = dataTable.Rows[0]["Email"].ToString();
                Prospect.Cep = dataTable.Rows[0]["Cep"].ToString();//rr
                Prospect.Campo01 = dataTable.Rows[0]["Campo01"].ToString();
                Prospect.Campo02 = dataTable.Rows[0]["Campo02"].ToString();
                Prospect.Campo03 = dataTable.Rows[0]["Campo03"].ToString();
                Prospect.Campo04 = dataTable.Rows[0]["Campo04"].ToString();
                Prospect.Campo05 = dataTable.Rows[0]["Campo05"].ToString();
                Prospect.Campo06 = dataTable.Rows[0]["Campo06"].ToString();
                Prospect.Campo07 = dataTable.Rows[0]["Campo07"].ToString();
                Prospect.Campo08 = dataTable.Rows[0]["Campo08"].ToString();
                Prospect.Campo09 = dataTable.Rows[0]["Campo09"].ToString();
                Prospect.Campo10 = dataTable.Rows[0]["Campo10"].ToString();

                Prospect.IDMailing = Convert.ToInt32(dataTable.Rows[0]["IDMailing"].ToString());
                Prospect.IDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
                Prospect.Mailing = dataTable.Rows[0]["Mailing"].ToString();
            }

            return Prospect;
        }

        public prospect RetornarProspect(string sCPF_CNPJ)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarProspect(sCPF_CNPJ);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            prospect Prospect = new prospect();

            if (dataTable.Rows.Count > 0)
            {
                Prospect.IDProspect = Convert.ToInt32(dataTable.Rows[0]["IDProspect"].ToString());
                Prospect.Telefone1 = Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString());
                Prospect.Telefone2 = Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString());
                Prospect.Telefone3 = Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString());
                Prospect.Nome = dataTable.Rows[0]["Nome"].ToString();
                Prospect.CPF_CNPJ = dataTable.Rows[0]["CPF_CNPJ"].ToString();
                Prospect.Logradouro = dataTable.Rows[0]["Logradouro"].ToString();
                Prospect.Numero = dataTable.Rows[0]["Numero"].ToString();
                Prospect.Complemento = dataTable.Rows[0]["Complemento"].ToString();
                Prospect.Bairro = dataTable.Rows[0]["Bairro"].ToString();
                Prospect.Cidade = dataTable.Rows[0]["Cidade"].ToString();
                Prospect.Estado = dataTable.Rows[0]["Estado"].ToString();
                Prospect.Email = dataTable.Rows[0]["Email"].ToString();
                Prospect.Cep = dataTable.Rows[0]["Cep"].ToString();//rr
                Prospect.Campo01 = dataTable.Rows[0]["Campo01"].ToString();
                Prospect.Campo02 = dataTable.Rows[0]["Campo02"].ToString();
                Prospect.Campo03 = dataTable.Rows[0]["Campo03"].ToString();
                Prospect.Campo04 = dataTable.Rows[0]["Campo04"].ToString();
                Prospect.Campo05 = dataTable.Rows[0]["Campo05"].ToString();
                Prospect.Campo06 = dataTable.Rows[0]["Campo06"].ToString();
                Prospect.Campo07 = dataTable.Rows[0]["Campo07"].ToString();
                Prospect.Campo08 = dataTable.Rows[0]["Campo08"].ToString();
                Prospect.Campo09 = dataTable.Rows[0]["Campo09"].ToString();
                Prospect.Campo10 = dataTable.Rows[0]["Campo10"].ToString();

                Prospect.IDMailing = Convert.ToInt32(dataTable.Rows[0]["IDMailing"].ToString());
                Prospect.IDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
                Prospect.Mailing = dataTable.Rows[0]["Mailing"].ToString();
            }

            return Prospect;
        }

        public DataTable RetornarHistoricoContato(double dTelefone1, int iIDMailing, int iScript)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarHistoricoContato(dTelefone1, iIDMailing, iScript);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string RetornarQtdeProspectMailing(int iIDMailing)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarQtdeProspectMailing(iIDMailing);

            return PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);
        }

        public string RetornarIDProspect(int iIDHistorico)
        {
            prospectDAL DProspect = new prospectDAL();
            return PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(DProspect.RetornarIDProspect(iIDHistorico));
        }

        public DataTable RetornarBloqueiosDDD(int iIDCampanha)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarBloqueiosDDD(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void AtualizarBloqueioDDD(int iBloqueio, int iDDD, int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.AtualizarBloqueioDDD(iBloqueio, iDDD, iIDUsuario);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarPerguntaResposta(int iIDHistorico)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarPerguntaResposta(iIDHistorico);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void AtualizarDadosProspect(prospect Prospect, bool bAgendamento)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.AtualizarDadosProspect(Prospect, bAgendamento);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }
        public DataTable RetornarAgendamentoOperador(int iIDUsuario, int iIDCampanha)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarAgendamentoOperador(iIDUsuario, iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void ExecutarResubmit(int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.ExecutarResubmit(iIDUsuario);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void CadastrarBloqueioDDD(int iDDD, int iIDUsuario, int iIDCampanha)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.CadastrarBloqueioDDD(iDDD, iIDUsuario, iIDCampanha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void ExcluirBloqueioDDD(int iDDD, int iIDCampanha)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.ExcluirBloqueioDDD(iDDD, iIDCampanha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void ExcluirBloqueioDDD(int iIDCampanha)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.ExcluirBloqueioDDD(iIDCampanha);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public prospect RetornarProspect(int iIDProspect, int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();

            string sSql = DProspect.RetornarProspect(iIDProspect, iIDUsuario);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            prospect Prospect = new prospect();

            if (dataTable.Rows.Count > 0)
            {
                Prospect.IDProspect = Convert.ToInt32(dataTable.Rows[0]["IDProspect"].ToString());

                if (Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString()) != 0)
                    Prospect.Telefone1 = Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString());
                if (Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString()) != 0)
                    Prospect.Telefone2 = Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString());
                if (Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString()) != 0)
                    Prospect.Telefone3 = Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString());

                if (Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString()) != 0 && Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString()) != 0 && Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString()) != 0)
                {
                    Prospect.Telefone1 = Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString());
                    Prospect.Telefone2 = Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString());
                    Prospect.Telefone3 = Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString());
                }

                Prospect.Nome = dataTable.Rows[0]["Nome"].ToString();
                Prospect.CPF_CNPJ = dataTable.Rows[0]["CPF_CNPJ"].ToString();
                Prospect.Logradouro = dataTable.Rows[0]["Logradouro"].ToString();
                Prospect.Numero = dataTable.Rows[0]["Numero"].ToString();
                Prospect.Complemento = dataTable.Rows[0]["Complemento"].ToString();
                Prospect.Bairro = dataTable.Rows[0]["Bairro"].ToString();
                Prospect.Cidade = dataTable.Rows[0]["Cidade"].ToString();
                Prospect.Estado = dataTable.Rows[0]["Estado"].ToString();
                Prospect.Email = dataTable.Rows[0]["Email"].ToString();
                Prospect.Cep = dataTable.Rows[0]["Cep"].ToString();//rr

                Prospect.Campo01 = dataTable.Rows[0]["Campo01"].ToString();
                Prospect.Campo02 = dataTable.Rows[0]["Campo02"].ToString();
                Prospect.Campo03 = dataTable.Rows[0]["Campo03"].ToString();
                Prospect.Campo04 = dataTable.Rows[0]["Campo04"].ToString();
                Prospect.Campo05 = dataTable.Rows[0]["Campo05"].ToString();
                Prospect.Campo06 = dataTable.Rows[0]["Campo06"].ToString();
                Prospect.Campo07 = dataTable.Rows[0]["Campo07"].ToString();
                Prospect.Campo08 = dataTable.Rows[0]["Campo08"].ToString();
                Prospect.Campo09 = dataTable.Rows[0]["Campo09"].ToString();
                Prospect.Campo10 = dataTable.Rows[0]["Campo10"].ToString();

                Prospect.IDMailing = Convert.ToInt32(dataTable.Rows[0]["IDMailing"].ToString());
                Prospect.IDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
                Prospect.IDSatus = Convert.ToInt32(dataTable.Rows[0]["IDStatus"].ToString());//r
                Prospect.Mailing = dataTable.Rows[0]["Mailing"].ToString();
            }

            return Prospect;
        }

        public prospect RetornarProspect(int iIDProspect)
        {
            prospectDAL DProspect = new prospectDAL();

            string sSql = DProspect.RetornarProspect(iIDProspect);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            prospect Prospect = new prospect();

            if (dataTable.Rows.Count > 0)
            {
                Prospect.IDProspect = Convert.ToInt32(dataTable.Rows[0]["IDProspect"].ToString());

                if (Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString()) != 0)
                    Prospect.Telefone1 = Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString());
                if (Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString()) != 0)
                    Prospect.Telefone2 = Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString());
                if (Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString()) != 0)
                    Prospect.Telefone3 = Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString());

                if (Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString()) != 0 && Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString()) != 0 && Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString()) != 0)
                {
                    Prospect.Telefone1 = Convert.ToDouble(dataTable.Rows[0]["Telefone1"].ToString());
                    Prospect.Telefone2 = Convert.ToDouble(dataTable.Rows[0]["Telefone2"].ToString());
                    Prospect.Telefone3 = Convert.ToDouble(dataTable.Rows[0]["Telefone3"].ToString());
                }

                Prospect.Nome = dataTable.Rows[0]["Nome"].ToString();
                Prospect.CPF_CNPJ = dataTable.Rows[0]["CPF_CNPJ"].ToString();
                Prospect.Logradouro = dataTable.Rows[0]["Logradouro"].ToString();
                Prospect.Numero = dataTable.Rows[0]["Numero"].ToString();
                Prospect.Complemento = dataTable.Rows[0]["Complemento"].ToString();
                Prospect.Bairro = dataTable.Rows[0]["Bairro"].ToString();
                Prospect.Cidade = dataTable.Rows[0]["Cidade"].ToString();
                Prospect.Estado = dataTable.Rows[0]["Estado"].ToString();
                Prospect.Email = dataTable.Rows[0]["Email"].ToString();
                Prospect.Cep = dataTable.Rows[0]["Cep"].ToString();//rr

                Prospect.Campo01 = dataTable.Rows[0]["Campo01"].ToString();
                Prospect.Campo02 = dataTable.Rows[0]["Campo02"].ToString();
                Prospect.Campo03 = dataTable.Rows[0]["Campo03"].ToString();
                Prospect.Campo04 = dataTable.Rows[0]["Campo04"].ToString();
                Prospect.Campo05 = dataTable.Rows[0]["Campo05"].ToString();
                Prospect.Campo06 = dataTable.Rows[0]["Campo06"].ToString();
                Prospect.Campo07 = dataTable.Rows[0]["Campo07"].ToString();
                Prospect.Campo08 = dataTable.Rows[0]["Campo08"].ToString();
                Prospect.Campo09 = dataTable.Rows[0]["Campo09"].ToString();
                Prospect.Campo10 = dataTable.Rows[0]["Campo10"].ToString();

                Prospect.IDMailing = Convert.ToInt32(dataTable.Rows[0]["IDMailing"].ToString());
                Prospect.IDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
                Prospect.Mailing = dataTable.Rows[0]["Mailing"].ToString();
            }

            return Prospect;
        }

        public int CadastrarIndicacao(prospect Prospect)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.CadastrarIndicacao(Prospect);

            return Convert.ToInt32(PontoBr.Banco.SqlServer.ExecutarSqlComRetornoDeIdentity(sSql));
        }

        public int RetornarQuantidadeAgendamentoOperador(int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarQuantidadeAgendamentoOperador(iIDUsuario);

            return Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));
        }

        public DataTable RetornarMidias()
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarMidias();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public string RetornarDropMidias()//r
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarMidias();

            return sSql;
        }

        public void InserirProspectTemporiamenteResubmit(string sIDStatus, int iIDMailing, string sDataInicial, string sDataFinal, int iIDOperador,string sBairro, string sCidade,string sCep)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.InserirProspectTemporiamenteResubmit(sIDStatus, iIDMailing, sDataInicial, sDataFinal, iIDOperador, sBairro, sCidade, sCep);

            PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);
        }

        public void LimparTabelaTemporariaResubmit()
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.LimparTabelaTemporariaResubmit();

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public int RetornarQuantidadeResubmit()
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarQuantidadeResubmit();

            return Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));
        }

        public double VerificarExistenciaTelefone(double dTelefone1, double dTelefone2, double dTelefone3)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.VerificarExistenciaTelefone(dTelefone1, dTelefone2, dTelefone3);

            double dIDProspect = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql) == "" ? 0 : Convert.ToDouble(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));

            return dIDProspect;
        }

        public DataTable RetornarUsuarioAgendamento(int iIDProspect)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarUsuarioAgendamento(iIDProspect);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void AtualizarUsuarioAgendamento(int iIDProspectAgendamento, int iIDUsuarioAgendamento, int iIDStatusAgendamento)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.AtualizarUsuarioAgendamento(iIDProspectAgendamento, iIDUsuarioAgendamento, iIDStatusAgendamento);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void LiberarProspectEmUso(int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.LiberarProspectEmUso(iIDUsuario);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarProspectsVirgens(int iIDMailing)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarProspectsVirgens(iIDMailing);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarProspectsResubmit(int iIDMailing)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarProspectsResubmit(iIDMailing);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void CadastrarProspectEnviadoPreditivo(int iIDProspect)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.CadastrarProspectEnviadoPreditivo(iIDProspect);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        //Mundiale Barrar a venda de um mesmo produto para o mesmo cliente no intervalo menor que 1 ano
        public DataTable RetornarUltimaVendaMundiale(string sCPF_CNPJ)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarUltimaVendaMundiale(sCPF_CNPJ);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarConsultaCEP(string sCEP)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarConsultaCEP(sCEP);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

        }

        public DataTable RetornaProdutos(string tipo)
        {
            prospectDAL DProspect = new prospectDAL();
            DataTable dt = DProspect.RetornaProdutos(tipo);

            return dt;
        }

        public int ExecutarResubmitCallFlex(int iIDUsuario, int iIDMailing, string sIDStatus)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.ExecutarResubmitCallFlex(iIDUsuario, iIDMailing, sIDStatus);

            return Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));
        }

        //VGX - Retornar produtos
        public DataTable RetornarCuros(string sNomeCurso)
        {
            prospectDAL DProspect = new prospectDAL();
            DataTable DataTableCursos = DProspect.RetornarCuros((sNomeCurso));

            return DataTableCursos;
        }

        public DataTable PreencherComboBox_Cursos(int iIDCampanha)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.PreencherComboBox_Cursos(iIDCampanha);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void CadastrarProspectInvalido(string sProspect, string sMotivo, int iIDMailing)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.CadastrarProspectInvalido(sProspect, sMotivo, iIDMailing);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarProspectsInvalido(int iIDMailing)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarProspectsInvalido(iIDMailing);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void CadastrarProspectInvalidoLista(ArrayList ListaInvalidos)
        {
            prospectDAL DProspect = new prospectDAL();
            List<string> ListSql = new List<string>();
            for (int i = 0; i < ListaInvalidos.Count;i++ )
            {
                prospect ProspectInvalido = new prospect();
                ProspectInvalido = (prospect)ListaInvalidos[i];
                ListSql.Add(DProspect.CadastrarProspectInvalidoLista(ProspectInvalido)); 
            }
            PontoBr.Banco.SqlServer.ExecutarSql(ListSql);
        }

        public void CadastrarBlackList(double dTelefone, int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.CadastrarBlackList(dTelefone, iIDUsuario);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public DataTable RetornarBlackList()
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarBlackList();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public bool VerificarTelefoneBlackList(double dTelefone)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.VerificarTelefoneBlackList(dTelefone);
            return PontoBr.Banco.SqlServer.VerificarExistenciaDeDados(sSql);
        }

        public void ExcluirTelefoneBlackList(double dTelefone)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.ExcluirTelefoneBlackList(dTelefone);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public int SalvarContato(contato Contato)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.SalvarContato(Contato);

            return Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));
        }

        public int SalvarContatoConecctta(contato Contato)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.SalvarContatoConecctta(Contato);

            return Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql));
        }

        public void SalvarContato(contato[] Contatos)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql;
            List<string> sListaSql = new List<string>();

            for (int i = 0; i < Contatos.Length; i++)
            {
                if (Contatos[i] != null)
                {
                    sSql = DProspect.SalvarContato(Contatos[i]);
                    sListaSql.Add(sSql);
                    PontoBr.Utilidades.Log.RegistrarLog(sSql, "log");
                }
            }
            PontoBr.Banco.SqlServer.ExecutarSql(sListaSql);
        }

        public void SalvarRespostasContato(int iIDPergunta, int iIDResposta, int iIDHistorico)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.SalvarRespostasContato(iIDPergunta, iIDResposta, iIDHistorico);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public bool VerificarExistenciaVenda(int iIDHistorico)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.VerificarExistenciaVenda(iIDHistorico);

            return PontoBr.Banco.SqlServer.VerificarExistenciaDeDados(sSql);
        }

        public int SalvarDadosVenda(int iIDHistorico, prospect Prospect)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.SalvarDadosVenda(iIDHistorico, Prospect);

            return Convert.ToInt32(PontoBr.Banco.SqlServer.ExecutarSqlComRetornoDeIdentity(sSql));
        }

        public void AtualizarDadosVenda(int iIDVenda, prospect Prospect)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.AtualizarDadosVenda(iIDVenda, Prospect);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void AtualizarHistorico(int iIDHistorico, string sDataCadastro, string sObservacao)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.AtualizarHistorico(iIDHistorico, sDataCadastro, sObservacao);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void AtualizarHistorico(int iIDHistorico, string sObservacao)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.AtualizarHistorico(iIDHistorico, sObservacao);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void PegarVendaParaAuditarBackoffice(int iIDHistorio, int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.PegarVendaParaAuditarBackoffice(iIDHistorio, iIDUsuario);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public string VerificarVendaSendoAuditadaBackoffice(int iIDHistorio, int iIDUsuario)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.VerificarVendaSendoAuditadaBackoffice(iIDHistorio, iIDUsuario);
            return PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);
        }

        public DataTable RetornarGridViewBlackList()//r
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarBlackList();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public void ExcluirMailing(int iIDMailing)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.ExcluirMailing(iIDMailing);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public int RetornarHistoricoVenda(int iIDProspect)
        {
            prospectDAL DProspect = new prospectDAL();

            string sSql = DProspect.RetornarHistoricoVenda(iIDProspect);
            string sIDHistoricoVenda = PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql);

            return sIDHistoricoVenda == "" ? -1 : Convert.ToInt32(sIDHistoricoVenda);
        }

        public void CadastrarLogAuditoria(int iIDHistorico, int iIDBackoffice, string sCampo, string sDe, string sPara, string sDNS)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.CadastrarLogAuditoria(iIDHistorico, iIDBackoffice, sCampo, sDe, sPara, sDNS);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void EnviarObservacaoTratamentoVenda(int iIDVenda, int iIDUsuario, string sObservacao, int iRemetente)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.EnviarObservacaoTratamentoVenda(iIDVenda,iIDUsuario, sObservacao, iRemetente);
            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        public void AtualizarLeituraTratamentoVenda(int iIDVenda, int iIDTratamento, int iIDUsuario)
        {

            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.AtualizarLeituraTratamentoVenda(iIDVenda, iIDTratamento, iIDUsuario);

            PontoBr.Banco.SqlServer.ExecutarSql(sSql);
        }

        //public DataTable RetornarMensagensTratamentoVenda(int iIDUsuario, string sPerfil)
        //{
        //    prospectDAL DProspect = new prospectDAL();
        //    string sSql = DProspect.RetornarMensagensTratamentoVenda(iIDUsuario, sPerfil);

        //    return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        //}

        public DataTable RetornarMensagensTratamentoVenda(int iIDUsuario, string sPerfil)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarMensagensTratamentoVenda(iIDUsuario, sPerfil);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public DataTable RetornarMensagensTratamentoVendaBackoffice(int iIDUsuario, string sPerfil)
        {
            prospectDAL DProspect = new prospectDAL();
            string sSql = DProspect.RetornarMensagensTratamentoVendaBackoffice(iIDUsuario, sPerfil);

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }
    }
}
