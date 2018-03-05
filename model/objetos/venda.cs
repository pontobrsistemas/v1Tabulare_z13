using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class venda
    {
        private string _Vendedor;
        public string Vendedor
        {
            get { return _Vendedor; }
            set { _Vendedor = value; }
        }

        private int _Ativo;
        public int Ativo
        {
        get { return _Ativo; }
        set { _Ativo = value; }
        }
        
    }
}
