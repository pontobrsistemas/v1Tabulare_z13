using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using model.objetos;
using controller;
using PontoBr.Utilidades;
using System.IO;

namespace tabulare.operador
{
    public partial class fAgendamentos : Form
    {
        public static string sIDPropect;
        private static DateTime dateTimeProximo = DateTime.Now.AddSeconds(15);

        public fAgendamentos()
        {
            InitializeComponent();
        }

        private void CarregarGrid(int iIDUsuario,int iIDCampanha)
        {
            prospectCTL CProspect = new prospectCTL();
            DataTable dataTable = CProspect.RetornarAgendamentoOperador(iIDUsuario,iIDCampanha);
            
            if (dataTable.Rows.Count != 0)
            {
                dgProspects.DataSource = dataTable;

                DateTime dDataAgendamento;
                DateTime dDataAtual = DateTime.Now;

                foreach (DataGridViewRow dataGridViewRow in dgProspects.Rows)
                {
                    dDataAgendamento = PontoBr.Conversoes.Data.ConverterDataDDMMAAAAComBarraeHoraComSegundosParaDateTime(dataGridViewRow.Cells[4].Value.ToString());

                    if (dDataAgendamento < dDataAtual)
                    {
                        dataGridViewRow.Cells[4].Style.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        dataGridViewRow.Cells[4].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }            
        }

        private void CarregarLayout()
        {
            this.BackColor = System.Drawing.Color.FromName("White");
            this.ControlBox = false;

            string sFormulario = "TABULARE - AGENDAMENTOS DO OPERADOR";
            this.Text = sFormulario + " - " + fLogin.sVersaoAplicativo + " (" + fLogin.sRelease + ")";
        }

        private void dgProspects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0)
            {
                sIDPropect = dgProspects.Rows[e.RowIndex].Cells[0].Value.ToString();
                
                string sLog = "Clicou para abrir agendamento: ";
                sLog += "IDProspect - " + sIDPropect;
                sLog += "; Telefone 1 - " + dgProspects.Rows[e.RowIndex].Cells[2].Value.ToString();
                sLog += "; Nome do cliente - " + dgProspects.Rows[e.RowIndex].Cells[1].Value.ToString();
                sLog += "; Data/hora que estava agendado - " + dgProspects.Rows[e.RowIndex].Cells[4].Value.ToString();
                sLog += "; Data/Hora que clicou para abrir o cliente - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                sLog += "; IDOperador - " + fLogin.Usuario.IDUsuario;
                sLog += "; Nome do Operador - " + fLogin.Usuario.Nome;

                PontoBr.Utilidades.Log.RegistrarLog(sLog, "log");

                this.Close();
            }        
        }      

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void fAgendamentos_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarLayout();
                CarregarGrid(fLogin.Usuario.IDUsuario, fLogin.Usuario.IDCampanha);
                cmdAtualizar.Enabled = true;
                dgProspects.Columns[1].Width = 200;
                dgProspects.Columns[2].Width = 150;
                dgProspects.Columns[4].Width = 200;

                lblRegistros.Text = dgProspects.RowCount.ToString() + " registro(s)";
            }
            catch { }
        }

        private void cmdAtualizar_Click(object sender, EventArgs e)
        {
            CarregarGrid(fLogin.Usuario.IDUsuario, fLogin.Usuario.IDCampanha);

            lblRegistros.Text = dgProspects.RowCount.ToString() + " registro(s)";
        }

        private void timerAtualizacao_Tick(object sender, EventArgs e)
        {
            if (dateTimeProximo.Second == DateTime.Now.Second)
            {
                dateTimeProximo = DateTime.Now.AddSeconds(15);
                int iIDUsuario = fLogin.Usuario.IDUsuario;
                int iIDCampanha = fLogin.Usuario.IDCampanha;
                CarregarGrid(iIDUsuario, iIDCampanha);
            }
        }
    }
}
