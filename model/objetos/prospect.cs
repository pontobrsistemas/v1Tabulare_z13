using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class prospect
    {
        private int _IDProspect;
        public int IDProspect
        {
            get { return _IDProspect; }
            set { _IDProspect = value; }
        }

        private int _IDSatus;
        public int IDSatus
        {
            get { return _IDSatus; }
            set { _IDSatus = value; }
        }

        private string _MensagemEmail;
        public string MensagemEmail
        {
            get { return _MensagemEmail; }
            set { _MensagemEmail = value; }
        }

        private string _LinkImagem;
        public string LinkImagem
        {
            get { return _LinkImagem; }
            set { _LinkImagem = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Campanha;
        public string Campanha
        {
            get { return _Campanha; }
            set { _Campanha = value; }
        }

        private int _IDUsuario;
        public int IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private string _Usuario;
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private double _Telefone1;
        public double Telefone1
        {
            get { return _Telefone1; }
            set { _Telefone1 = value; }
        }

        private double _Telefone2;
        public double Telefone2
        {
            get { return _Telefone2; }
            set { _Telefone2 = value; }
        }

        private double _Telefone3;
        public double Telefone3
        {
            get { return _Telefone3; }
            set { _Telefone3 = value; }
        }

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Logradouro;
        public string Logradouro
        {
            get { return _Logradouro; }
            set { _Logradouro = value; }
        }

        private string _Numero;
        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        private string _Complemento;
        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        private string _Bairro;
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        private string _Cidade;
        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        } 

        private int _IDCampanha;
        public int IDCampanha
        {
            get { return _IDCampanha; }
            set { _IDCampanha = value; }
        }

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
        
        private string _CPF_CNPJ;
        public string CPF_CNPJ
        {
            get { return _CPF_CNPJ; }
            set { _CPF_CNPJ = value; }
        }        

        private int _IDHistorico;
        public int IDHistorico
        {
            get { return _IDHistorico; }
            set { _IDHistorico = value; }
        }

        private string _ImportarDuplicado;
        public string ImportarDuplicado
        {
            get { return _ImportarDuplicado; }
            set { _ImportarDuplicado = value; }
        }

        private string _Campo01;
        public string Campo01
        {
            get { return _Campo01; }
            set { _Campo01 = value; }
        }

       
        private string _Campo02;
        public string Campo02
        {
            get { return _Campo02; }
            set { _Campo02 = value; }
        }

        private string _Campo03;
        public string Campo03
        {
            get { return _Campo03; }
            set { _Campo03 = value; }
        }

        private string _Campo04;
        public string Campo04
        {
            get { return _Campo04; }
            set { _Campo04 = value; }
        }

        private string _Campo05;
        public string Campo05
        {
            get { return _Campo05; }
            set { _Campo05 = value; }
        }

        private string _Campo06;
        public string Campo06
        {
            get { return _Campo06; }
            set { _Campo06 = value; }
        }

        private string _Campo07;
        public string Campo07
        {
            get { return _Campo07; }
            set { _Campo07 = value; }
        }

        private string _Campo08;
        public string Campo08
        {
            get { return _Campo08; }
            set { _Campo08 = value; }
        }

        private string _Campo09;
        public string Campo09
        {
            get { return _Campo09; }
            set { _Campo09 = value; }
        }

        private string _Campo10;
        public string Campo10
        {
            get { return _Campo10; }
            set { _Campo10 = value; }
        }

        private string _sDataProxContato;
        public string sDataProxContato
        {
            get { return _sDataProxContato; }
            set { _sDataProxContato = value; }
        }

        private string _Venda01; public string Venda01 { get { return _Venda01; } set { _Venda01 = value; } }
        private string _Venda02; public string Venda02 { get { return _Venda02; } set { _Venda02 = value; } }
        private string _Venda03; public string Venda03 { get { return _Venda03; } set { _Venda03 = value; } }
        private string _Venda04; public string Venda04 { get { return _Venda04; } set { _Venda04 = value; } }
        private string _Venda05; public string Venda05 { get { return _Venda05; } set { _Venda05 = value; } }
        private string _Venda06; public string Venda06 { get { return _Venda06; } set { _Venda06 = value; } }
        private string _Venda07; public string Venda07 { get { return _Venda07; } set { _Venda07 = value; } }
        private string _Venda08; public string Venda08 { get { return _Venda08; } set { _Venda08 = value; } }
        private string _Venda09; public string Venda09 { get { return _Venda09; } set { _Venda09 = value; } }
        private string _Venda10; public string Venda10 { get { return _Venda10; } set { _Venda10 = value; } }
        private string _Venda11; public string Venda11 { get { return _Venda11; } set { _Venda11 = value; } }
        private string _Venda12; public string Venda12 { get { return _Venda12; } set { _Venda12 = value; } }
        private string _Venda13; public string Venda13 { get { return _Venda13; } set { _Venda13 = value; } }
        private string _Venda14; public string Venda14 { get { return _Venda14; } set { _Venda14 = value; } }
        private string _Venda15; public string Venda15 { get { return _Venda15; } set { _Venda15 = value; } }
        private string _Venda16; public string Venda16 { get { return _Venda16; } set { _Venda16 = value; } }
        private string _Venda17; public string Venda17 { get { return _Venda17; } set { _Venda17 = value; } }
        private string _Venda18; public string Venda18 { get { return _Venda18; } set { _Venda18 = value; } }
        private string _Venda19; public string Venda19 { get { return _Venda19; } set { _Venda19 = value; } }
        private string _Venda20; public string Venda20 { get { return _Venda20; } set { _Venda20 = value; } }
        private string _Venda21; public string Venda21 { get { return _Venda21; } set { _Venda21 = value; } }
        private string _Venda22; public string Venda22 { get { return _Venda22; } set { _Venda22 = value; } }
        private string _Venda23; public string Venda23 { get { return _Venda23; } set { _Venda23 = value; } }
        private string _Venda24; public string Venda24 { get { return _Venda24; } set { _Venda24 = value; } }
        private string _Venda25; public string Venda25 { get { return _Venda25; } set { _Venda25 = value; } }
        private string _Venda26; public string Venda26 { get { return _Venda26; } set { _Venda26 = value; } }
        private string _Venda27; public string Venda27 { get { return _Venda27; } set { _Venda27 = value; } }
        private string _Venda28; public string Venda28 { get { return _Venda28; } set { _Venda28 = value; } }
        private string _Venda29; public string Venda29 { get { return _Venda29; } set { _Venda29 = value; } }
        private string _Venda30; public string Venda30 { get { return _Venda30; } set { _Venda30 = value; } }
        private string _Venda31; public string Venda31 { get { return _Venda31; } set { _Venda31 = value; } }
        private string _Venda32; public string Venda32 { get { return _Venda32; } set { _Venda32 = value; } }
        private string _Venda33; public string Venda33 { get { return _Venda33; } set { _Venda33 = value; } }
        private string _Venda34; public string Venda34 { get { return _Venda34; } set { _Venda34 = value; } }
        private string _Venda35; public string Venda35 { get { return _Venda35; } set { _Venda35 = value; } }
        private string _Venda36; public string Venda36 { get { return _Venda36; } set { _Venda36 = value; } }
        private string _Venda37; public string Venda37 { get { return _Venda37; } set { _Venda37 = value; } }
        private string _Venda38; public string Venda38 { get { return _Venda38; } set { _Venda38 = value; } }
        private string _Venda39; public string Venda39 { get { return _Venda39; } set { _Venda39 = value; } }
        private string _Venda40; public string Venda40 { get { return _Venda40; } set { _Venda40 = value; } }
        private string _Venda41; public string Venda41 { get { return _Venda41; } set { _Venda41 = value; } }
        private string _Venda42; public string Venda42 { get { return _Venda42; } set { _Venda42 = value; } }
        private string _Venda43; public string Venda43 { get { return _Venda43; } set { _Venda43 = value; } }
        private string _Venda44; public string Venda44 { get { return _Venda44; } set { _Venda44 = value; } }
        private string _Venda45; public string Venda45 { get { return _Venda45; } set { _Venda45 = value; } }
        private string _Venda46; public string Venda46 { get { return _Venda46; } set { _Venda46 = value; } }
        private string _Venda47; public string Venda47 { get { return _Venda47; } set { _Venda47 = value; } }
        private string _Venda48; public string Venda48 { get { return _Venda48; } set { _Venda48 = value; } }
        private string _Venda49; public string Venda49 { get { return _Venda49; } set { _Venda49 = value; } }
        private string _Venda50; public string Venda50 { get { return _Venda50; } set { _Venda50 = value; } }
        private string _Venda51; public string Venda51 { get { return _Venda51; } set { _Venda51 = value; } }
        private string _Venda52; public string Venda52 { get { return _Venda52; } set { _Venda52 = value; } }
        private string _Venda53; public string Venda53 { get { return _Venda53; } set { _Venda53 = value; } }
        private string _Venda54; public string Venda54 { get { return _Venda54; } set { _Venda54 = value; } }
        private string _Venda55; public string Venda55 { get { return _Venda55; } set { _Venda55 = value; } }
        private string _Venda56; public string Venda56 { get { return _Venda56; } set { _Venda56 = value; } }
        private string _Venda57; public string Venda57 { get { return _Venda57; } set { _Venda57 = value; } }
        private string _Venda58; public string Venda58 { get { return _Venda58; } set { _Venda58 = value; } }
        private string _Venda59; public string Venda59 { get { return _Venda59; } set { _Venda59 = value; } }
        private string _Venda60; public string Venda60 { get { return _Venda60; } set { _Venda60 = value; } }

        private int _IDTipoAtendimento;
        public int IDTipoAtendimento
        {
            get { return _IDTipoAtendimento; }
            set { _IDTipoAtendimento = value; }
        }

        private int _IDMidia;
        public int IDMidia
        {
            get { return _IDMidia; }
            set { _IDMidia = value; }
        }

        private int _IDStatusAuditoria;
        public int IDStatusAuditoria
        {
            get { return _IDStatusAuditoria; }
            set { _IDStatusAuditoria = value; }
        }

        private int _IDUsuarioAuditoria;
        public int IDUsuarioAuditoria
        {
            get { return _IDUsuarioAuditoria; }
            set { _IDUsuarioAuditoria = value; }
        }

        private int _NroAgente;
        public int NroAgente
        {
            get { return _NroAgente; }
            set { _NroAgente = value; }
        }

        private string _DataCadastro;
        public string DataCadastro
        {
            get { return _DataCadastro; }
            set { _DataCadastro = value; }
        }

        private int _Ativo;
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }

        private int _EmUso;
        public int EmUso
        {
            get { return _EmUso; }
            set { _EmUso = value; }
        }

        //Callflex Mundiale
        private string _ObservacaoMundiale;
        public string ObservacaoMundiale
        {
            get { return _ObservacaoMundiale; }
            set { _ObservacaoMundiale = value; }
        }

        private string _Raca;
        public string Raca
        {
            get { return _Raca; }
            set { _Raca = value; }
        }

        private string _NomeCurso;
        public string NomeCurso
        {
            get { return _NomeCurso; }
            set { _NomeCurso = value; }
        }

        public string sLinha { get; set; }
        public string sMotivo { get; set; }

        private string _Cep;
        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }        
    }
}
