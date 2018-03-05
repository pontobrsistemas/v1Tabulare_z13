using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using model.negocios;
using model.objetos;
using System.Windows.Forms;
using System.Web.UI.WebControls;


namespace controller
{
    public class preditivoCTL
    {
        public DataTable RetornarFilas()
        {
            preditivoBLL BPreditivo = new preditivoBLL();
            return BPreditivo.RetornarFilas();
        }

        public preditivo RetornarFila(string sIDFila)
        {                
            preditivoBLL BPreditivo = new preditivoBLL();
            return BPreditivo.RetornarFila(sIDFila);
        }

        public int RetornarIDUsuarioTelaLiberada(int iNroAgente)
        {
            preditivoBLL BPreditivo = new preditivoBLL();
            return BPreditivo.RetornarIDUsuarioTelaLiberada(iNroAgente);
        }

        public prospect PretornarProspectPreditivoUsuario(int iIDUsuario)
        {
            preditivoBLL BPreditivo = new preditivoBLL();
            return BPreditivo.PretornarProspectPreditivoUsuario(iIDUsuario);
        }

        public DataTable RetornarProspectResubmit(int iIDProspect)
        {
            preditivoBLL BPreditivo = new preditivoBLL();
            return BPreditivo.RetornarProspectResubmit(iIDProspect);
        }

    }
}
