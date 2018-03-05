using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.negocios;
using model.objetos;
using model.dados;
using System.Windows.Forms;

namespace controller
{
    public class scriptCTL
    {
        public DataTable RetornarPrimeiraPergunta(int iIDCampanha)
        {
            scriptBLL BScript = new scriptBLL();
            return BScript.RetornarPrimeiraPergunta(iIDCampanha);
        }

        public void PreencherComboBox_Perguntas(ComboBox comboPerguntas, int iIDCampanha)
        {
            scriptBLL BScript = new scriptBLL();
            DataTable dataTable = BScript.RetornarPerguntas(iIDCampanha);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboPerguntas, dataTable, "IDPergunta", "Pergunta", true, false);
        }

        public void PreencherComboBox_Respostas(ComboBox comboResposta, int iIDPergunta, bool bTodos, bool bSelecione)
        {
            scriptBLL BScript = new scriptBLL();
            DataTable dataTable = BScript.RetornarRespostas(iIDPergunta);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboResposta, dataTable, "IDResposta", "Resposta", bTodos, bSelecione);
        }

        public DataTable RetornarRespostas(int iIDPergunta)
        {
            scriptBLL BScript = new scriptBLL();
            return BScript.RetornarRespostas(iIDPergunta);
        }

        public void PreencherListBox_Respostas(ListBox listBox, int iIDPergunta)
        {
            scriptBLL BScript = new scriptBLL();
            DataTable dataTable = BScript.RetornarRespostas(iIDPergunta);

            //Adiciona os itens no ListBox
            for (int iLinha = 0; iLinha < dataTable.Rows.Count; iLinha++)
            {
                int iIDResposta = Convert.ToInt32(dataTable.Rows[iLinha]["IDResposta"].ToString());
                string sResposta = dataTable.Rows[iLinha]["Resposta"].ToString();
                int iIDProximaPergunta = dataTable.Rows[iLinha]["IDProximaPergunta"].ToString() == "" ? 0 : Convert.ToInt32(dataTable.Rows[iLinha]["IDProximaPergunta"].ToString());
                string sPergunta = dataTable.Rows[iLinha]["Pergunta"].ToString();
                bool bVenda = Convert.ToBoolean(dataTable.Rows[iLinha]["Venda"]);

                script Script = new script(iIDPergunta, iIDResposta, sResposta, iIDProximaPergunta, sPergunta, bVenda);
                listBox.Items.Add(Script);
            }                
        }

        public DataTable RetornarProximaPergunta(int iIDPergunta)
        {
            scriptBLL BScript = new scriptBLL();
            return BScript.RetornarProximaPergunta(iIDPergunta);
        }

        public DataTable RetornarAgendamentosPendentes()
        {
            scriptBLL BScript = new scriptBLL();
            return BScript.RetornarAgendamentosPendentes();
        }

        public DataTable RetornarAgendamentos()
        {
            scriptBLL BScript = new scriptBLL();
            return BScript.RetornarAgendamentos();
        }

        public DataTable RetornarPesquisaAgendamentos(string sNome)
        {
            scriptBLL BScript = new scriptBLL();
            return BScript.RetornarPesquisaAgendamentos(sNome);
        }

        public void PreencherComboBox_RespostasPendente(ComboBox comboRespostas, string sIDsRespostas)
        {
            scriptBLL BScript = new scriptBLL();
            DataTable dataTable = BScript.RetornarRespostasPendentes(sIDsRespostas);

            PontoBr.Utilidades.WCL.CarregarComboBox(comboRespostas, dataTable, "IDResposta", "Resposta", false, false);
        }

        public void EditarRespostaProspect(int iIDHistorico, int iIDPergunta, int iIDResposta)
        {
            scriptBLL BScript = new scriptBLL();
            BScript.EditarRespostaProspect(iIDHistorico, iIDPergunta, iIDResposta);
        }

        public int RetornarIDResposta(string sResposta)
        {
            scriptBLL BScript = new scriptBLL();
            return BScript.RetornarIDResposta(sResposta);
        }
    }
}
