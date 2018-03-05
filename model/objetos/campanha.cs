using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class campanha
    {
        private int _iAtivo;
        public int iAtivo
        {
            get { return _iAtivo; }
            set { _iAtivo = value; }
        }

        private string _sCampanha;
        public string sCampanha
        {
            get { return _sCampanha; }
            set { _sCampanha = value; }
        }

        private int _iIDCampanha;
        public int iIDCampanha
        {
            get { return _iIDCampanha; }
            set { _iIDCampanha = value; }
        }

        private string _sOperadora;
        public string sOperadora
        {
            get { return _sOperadora; }
            set { _sOperadora = value; }
        }

        private int _PermiteEditarDadosProspect;
        public int PermiteEditarDadosProspect
        {
            get { return _PermiteEditarDadosProspect; }
            set { _PermiteEditarDadosProspect = value; }
        }

        private string _Fila;
        public string Fila
        {
            get { return _Fila; }
            set { _Fila = value; }
        }

        private int _iIDTipoDiscador;
        public int iIDTipoDiscador
        {
            get { return _iIDTipoDiscador; }
            set { _iIDTipoDiscador = value; }
        }

        private string _TipoDiscador;
        public string TipoDiscador
        {
            get { return _TipoDiscador; }
            set { _TipoDiscador = value; }
        }

    }
}
