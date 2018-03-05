using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class preditivo
    {
        private int _Ativo;
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }

        private string _Fila;
        public string Fila
        {
            get { return _Fila; }
            set { _Fila = value; }
        }

        private string _IDFila;
        public string IDFila
        {
            get { return _IDFila; }
            set { _IDFila = value; }
        }

        private int _IDCampanha;
        public int IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }
    }
}
