using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class usuario
    {
        private int _IDUsuario;
        public int IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Login;
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }

        private string _Agente;
        public string Agente
        {
            get { return _Agente; }
            set { _Agente = value; }
        }

        private string _Senha;
        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }

        private int _IDPerfil;
        public int IDPerfil
        {
            get { return _IDPerfil; }
            set { _IDPerfil = value; }
        }

        private string _Perfil;
        public string Perfil
        {
            get { return _Perfil; }
            set { _Perfil = value; }
        }

        private int _IDCampanha;
        public int IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

        private string _Campanha;
        public string Campanha
        {
            get { return _Campanha; }
            set { _Campanha = value; }
        }

        private string _Ramal;
        public string Ramal
        {
            get { return _Ramal; }
            set { _Ramal = value; }
        }

        private string _DNS;
        public string DNS
        {
            get { return _DNS; }
            set { _DNS = value; }
        }

        private int _Ativo;
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }

        private int _NroAgente;
        public int NroAgente
        {
            get { return _NroAgente; }
            set { _NroAgente = value; }
        }

        private int _PermiteEditarDadosProspect;
        public int PermiteEditarDadosProspect
        {
            get { return _PermiteEditarDadosProspect; }
            set { _PermiteEditarDadosProspect = value; }
        }

        private string _TipoDiscador;
        public string TipoDiscador
        {
            get { return _TipoDiscador; }
            set { _TipoDiscador = value; }
        }

        private string _Fila;
        public string Fila
        {
            get { return _Fila; }
            set { _Fila = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
