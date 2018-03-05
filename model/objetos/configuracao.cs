using System;
using System.Collections.Generic;
using System.Text;

namespace model.objetos
{
    public class configuracao
    {
        public string IDCampo;
        public string Texto;
        public string Label;
        public string TextBox;
        public string TamanhoTextBox;
        public string LocalizacaoTextBox;
        public string LocalizacaoLabel;
        public bool Obrigatorio;
        public string Lista;

        public configuracao(string sIDCampo,
            string sTexto,
            string sLabel,
            string sTextBox,
            string sTamanhoTextBox,
            string sLocalizacaoTextBox,
            string sLocalizacaoLabel,
            bool bObrigatorio,
            string sLista)
        {
            IDCampo = sIDCampo;
            Texto = sTexto;
            Label = sLabel;
            TextBox = sTextBox;
            TamanhoTextBox = sTamanhoTextBox;
            LocalizacaoTextBox = sLocalizacaoTextBox;
            LocalizacaoLabel = sLocalizacaoLabel;
            Obrigatorio = bObrigatorio;
            Lista = sLista;
        }

        private string _VersaoDiscador;
        public string VersaoDiscador
        {
            get { return _VersaoDiscador; }
            set { _VersaoDiscador = value; }
        }

        private string _TipoPabx;
        public string TipoPabx
        {
            get { return _TipoPabx; }
            set { _TipoPabx = value; }
        }

        private int _Script;
        public int Script
        {
            get { return _Script; }
            set { _Script = value; }
        }

        private string _IPServidor;
        public string IPServidor
        {
            get { return _IPServidor; }
            set { _IPServidor = value; }
        }

        private string _PortaServidor;
        public string PortaServidor
        {
            get { return _PortaServidor; }
            set { _PortaServidor = value; }
        }

        private string _Cliente;
        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        private int _Licenca;
        public int Licenca
        {
            get { return _Licenca; }
            set { _Licenca = value; }
        }
    }
}
