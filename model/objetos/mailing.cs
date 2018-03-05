using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class mailing
    {
        private int _IDMailing;
        public int IDMailing
        {
            get { return _IDMailing; }
            set { _IDMailing = value; }
        }

        private string _Mailing;
        public string Mailing
        {
            get { return _Mailing; }
            set { _Mailing = value; }
        }

        private int _Ativo;
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }

        private int _IDCampanha;
        public int IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }        
    }
}
