using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class script
    {
        public int IDPergunta;
        public int IDResposta;
        public string Resposta;
        public int IDProximaPergunta;
        public string Pergunta;
        public bool Venda;

        public override string ToString()
        {
            return Resposta;
        }

        public script(int iIDPergunta, int iIDResposta, string sResposta, int iIDProximaPergunta, string sPergunta, bool bVenda)
        {
            IDPergunta = iIDPergunta;
            IDResposta = iIDResposta;
            Resposta = sResposta;
            IDProximaPergunta = iIDProximaPergunta;
            Pergunta = sPergunta;
            Venda = bVenda;
        }
    }
}
