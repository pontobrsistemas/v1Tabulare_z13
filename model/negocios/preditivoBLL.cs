using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using model.objetos;
using model.dados;

namespace model.negocios
{
    public class preditivoBLL
    {
        public DataTable RetornarFilas()
        {
            preditivoDAL DPreditivo = new preditivoDAL();
            string sSql = DPreditivo.RetornarFilas();

            return PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
        }

        public preditivo RetornarFila(string sIDFila)
        {
            preditivo Preditivo = new preditivo();
            preditivoDAL DPreditivo = new preditivoDAL();
            string sSql = DPreditivo.RetornarFila(sIDFila);

            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);
            Preditivo.IDCampanha = Convert.ToInt32(dataTable.Rows[0]["IDCampanha"].ToString());
            Preditivo.IDFila = dataTable.Rows[0]["IDFila"].ToString();
            Preditivo.Fila = dataTable.Rows[0]["Fila"].ToString();
            
            return Preditivo;
        }

        public int RetornarIDUsuarioTelaLiberada(int iNroAgente)
        {
            preditivoDAL DPreditivo = new preditivoDAL();
            string sSql = DPreditivo.RetornarIDUsuarioTelaLiberada(iNroAgente);

            return PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql) == "" ? 0 : Convert.ToInt32(PontoBr.Banco.SqlServer.RetornarDadoUnicoDoBanco(sSql)) ;
        }

        public prospect PretornarProspectPreditivoUsuario(int iIDUsuario)
        {
            preditivoDAL DPreditivo = new preditivoDAL();
            string sSql = DPreditivo.PretornarProspectPreditivoUsuario(iIDUsuario);
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

        public DataTable RetornarProspectResubmit(int iIDProspect)
        {
            preditivoDAL DPreditivo = new preditivoDAL();
            string sSql = DPreditivo.RetornarProspectResubmit(iIDProspect);
            DataTable dataTable = PontoBr.Banco.SqlServer.RetornarDataTable(sSql);

            return dataTable;
        }
    }
}
