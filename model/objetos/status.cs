using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class status
    {
        private int _IDStatus;
        public int IDStatus
        {
            get { return _IDStatus; }
            set { _IDStatus = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _sIDStatus;
        public string sIDStatus
        {
            get { return _sIDStatus; }
            set { _sIDStatus = value; }
        }

        private int _IDAcao;
        public int IDAcao
        {
            get { return _IDAcao; }
            set { _IDAcao = value; }
        }

        private int _QtdeTentativas;
        public int QtdeTentativas
        {
            get { return _QtdeTentativas; }
            set { _QtdeTentativas = value; }
        }

        private string _TempoRetorno;
        public string TempoRetorno
        {
            get { return _TempoRetorno; }
            set { _TempoRetorno = value; }
        }

        private int _Ativo;
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }

        private int _Venda;
        public int Venda
        {
            get { return _Venda; }
            set { _Venda = value; }
        }

        private string _Acao;
        public string Acao
        {
            get { return _Acao; }
            set { _Acao = value; }
        }
    }
}
