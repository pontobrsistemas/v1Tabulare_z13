using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using controller;
using System.Collections;
using model.objetos;
using System.Threading;
using System.Net;

namespace tabulare.supervisor
{
    public partial class fBackofficeVenda_detalhe : Form
    {
        private ReportDocument reportDocument;
        
        private class Item
        {
            public string Texto;
            public int Valor;
            public Item(string Texto, int Valor)
            {
                Texto = Texto;
                Valor = Valor;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Texto;
            }
        }

        public static int iIDHistorico;
        public static int iIDVenda;
        public static int iIDCampanha;
        delegate void SetTextCallback(string text);
        private static ArrayList arrayList;

        public fBackofficeVenda_detalhe()
        {
            InitializeComponent();
        }

        private void GerarRelatorio()
        {
            try
            {

            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }

        private void CarregarDadosVenda(int iIDHistorico)
        {
            relatorioCTL CRelatorio = new relatorioCTL();
            prospectCTL CProspect = new prospectCTL();
            DataTable dataTable = CRelatorio.RetornarDadosVenda(iIDHistorico);

            lblIDHistorico.Text = iIDHistorico.ToString();

            if (dataTable.Rows.Count == 0)
            {
                string sMensagem;
                sMensagem = "Dados não existentes.";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Colocar venda em uso pelo backoffice
                if (fLogin.Usuario.Perfil != "Operador")
                    CProspect.PegarVendaParaAuditarBackoffice(Convert.ToInt32(lblIDHistorico.Text), fLogin.Usuario.IDUsuario);

                txtoperador.Text = dataTable.Rows[0]["Usuario"].ToString();
                txtDataContato.Text = dataTable.Rows[0]["DataCadastro"].ToString();
                txtstatus.Text = dataTable.Rows[0]["Status"].ToString();

                lblIDProspect_valor.Text = dataTable.Rows[0]["IDProspect"].ToString();
                txtNome.Text = dataTable.Rows[0]["Nome"].ToString();
                txtCPF_CNPJ.Text = dataTable.Rows[0]["CPF_CNPJ"].ToString();
                txtTelefone1.Text = dataTable.Rows[0]["Telefone1"].ToString();
                txtTelefone2.Text = dataTable.Rows[0]["Telefone2"].ToString();
                txtTelefone3.Text = dataTable.Rows[0]["Telefone3"].ToString();
                txtLogradouro.Text = dataTable.Rows[0]["Logradouro"].ToString();
                txtNumero.Text = dataTable.Rows[0]["Numero"].ToString();
                txtComplemento.Text = dataTable.Rows[0]["Complemento"].ToString();
                txtBairro.Text = dataTable.Rows[0]["Bairro"].ToString();
                txtCidade.Text = dataTable.Rows[0]["Cidade"].ToString();
                txtEstado.Text = dataTable.Rows[0]["Estado"].ToString();
                txtEmail.Text = dataTable.Rows[0]["Email"].ToString();
                txtCep.Text = dataTable.Rows[0]["Cep"].ToString();//rr

                txtMailing.Text = dataTable.Rows[0]["Mailing"].ToString();
                txtCampanha.Text = dataTable.Rows[0]["Campanha"].ToString();
                txtObservacao.Text = dataTable.Rows[0]["Observacao"].ToString();

                //Verifica se o status existe no dropdown
                int iIDStatusAuditoria = dataTable.Rows[0]["IDStatus"].ToString() == "" ? 1 : Convert.ToInt32(dataTable.Rows[0]["IDStatus"].ToString());
                bool bExisteStatusAuditoria = false;
                DataTable dataStatusAuditoria = new DataTable();

                foreach (DataRowView rowView in comboAuditoria.Items)
                {
                    if (Convert.ToInt32(rowView.Row.ItemArray[0].ToString()) == iIDStatusAuditoria)
                        bExisteStatusAuditoria = true;
                }

                if (!bExisteStatusAuditoria)
                    comboAuditoria.Items.Add(new Item(dataTable.Rows[0]["Status Auditoria"].ToString(), iIDStatusAuditoria));

                comboAuditoria.SelectedValue = iIDStatusAuditoria.ToString();

                string sLabel, sTextBox;
                grbDadosProspect.Text = "Dados do Prospect";
                prospect prospect = new prospect();

                foreach (Control controlLabel in grbDadosProspect.Controls)
                {
                    if (controlLabel.Name.IndexOf("lblCampo") > -1)
                    {
                        foreach (Control controlTextBox in grbDadosProspect.Controls)
                        {
                            sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                            sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txtCampo") > -1)
                            {
                                TextBox textBox = (TextBox)controlTextBox;
                                if (textBox.Name == "txtCampo01") textBox.Text = dataTable.Rows[0]["Campo01"].ToString();
                                if (textBox.Name == "txtCampo02") textBox.Text = dataTable.Rows[0]["Campo02"].ToString();
                                if (textBox.Name == "txtCampo03") textBox.Text = dataTable.Rows[0]["Campo03"].ToString();
                                if (textBox.Name == "txtCampo04") textBox.Text = dataTable.Rows[0]["Campo04"].ToString();
                                if (textBox.Name == "txtCampo05") textBox.Text = dataTable.Rows[0]["Campo05"].ToString();
                                if (textBox.Name == "txtCampo06") textBox.Text = dataTable.Rows[0]["Campo06"].ToString();
                                if (textBox.Name == "txtCampo07") textBox.Text = dataTable.Rows[0]["Campo07"].ToString();
                                if (textBox.Name == "txtCampo08") textBox.Text = dataTable.Rows[0]["Campo08"].ToString();
                                if (textBox.Name == "txtCampo09") textBox.Text = dataTable.Rows[0]["Campo09"].ToString();
                                if (textBox.Name == "txtCampo10") textBox.Text = dataTable.Rows[0]["Campo10"].ToString();
                            }
                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("comboCampo") > -1)
                            {
                                ComboBox comboBox = (ComboBox)controlTextBox;
                                if (comboBox.Name == "comboCampo01") comboBox.Text = dataTable.Rows[0]["Campo01"].ToString();
                                if (comboBox.Name == "comboCampo02") comboBox.Text = dataTable.Rows[0]["Campo02"].ToString();
                                if (comboBox.Name == "comboCampo03") comboBox.Text = dataTable.Rows[0]["Campo03"].ToString();
                                if (comboBox.Name == "comboCampo04") comboBox.Text = dataTable.Rows[0]["Campo04"].ToString();
                                if (comboBox.Name == "comboCampo05") comboBox.Text = dataTable.Rows[0]["Campo05"].ToString();
                                if (comboBox.Name == "comboCampo06") comboBox.Text = dataTable.Rows[0]["Campo06"].ToString();
                                if (comboBox.Name == "comboCampo07") comboBox.Text = dataTable.Rows[0]["Campo07"].ToString();
                                if (comboBox.Name == "comboCampo08") comboBox.Text = dataTable.Rows[0]["Campo08"].ToString();
                                if (comboBox.Name == "comboCampo09") comboBox.Text = dataTable.Rows[0]["Campo09"].ToString();
                                if (comboBox.Name == "comboCampo10") comboBox.Text = dataTable.Rows[0]["Campo10"].ToString();
                            }
                        }
                    }
                }

                //Preencher campos Dados da Venda
                foreach (Control controlLabel in grbVenda.Controls)
                {
                    if (controlLabel.Name.IndexOf("lblVenda") > -1)
                    {
                        foreach (Control controlTextBox in grbVenda.Controls)
                        {
                            sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                            sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                            if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                            {
                                TextBox textBox = (TextBox)controlTextBox;
                                if (textBox.Name == "txtVenda01") textBox.Text = dataTable.Rows[0]["Venda01"].ToString();
                                if (textBox.Name == "txtVenda02") textBox.Text = dataTable.Rows[0]["Venda02"].ToString();
                                if (textBox.Name == "txtVenda03") textBox.Text = dataTable.Rows[0]["Venda03"].ToString();
                                if (textBox.Name == "txtVenda04") textBox.Text = dataTable.Rows[0]["Venda04"].ToString();
                                if (textBox.Name == "txtVenda05") textBox.Text = dataTable.Rows[0]["Venda05"].ToString();
                                if (textBox.Name == "txtVenda06") textBox.Text = dataTable.Rows[0]["Venda06"].ToString();
                                if (textBox.Name == "txtVenda07") textBox.Text = dataTable.Rows[0]["Venda07"].ToString();
                                if (textBox.Name == "txtVenda08") textBox.Text = dataTable.Rows[0]["Venda08"].ToString();
                                if (textBox.Name == "txtVenda09") textBox.Text = dataTable.Rows[0]["Venda09"].ToString();
                                if (textBox.Name == "txtVenda10") textBox.Text = dataTable.Rows[0]["Venda10"].ToString();
                                if (textBox.Name == "txtVenda11") textBox.Text = dataTable.Rows[0]["Venda11"].ToString();
                                if (textBox.Name == "txtVenda12") textBox.Text = dataTable.Rows[0]["Venda12"].ToString();
                                if (textBox.Name == "txtVenda13") textBox.Text = dataTable.Rows[0]["Venda13"].ToString();
                                if (textBox.Name == "txtVenda14") textBox.Text = dataTable.Rows[0]["Venda14"].ToString();
                                if (textBox.Name == "txtVenda15") textBox.Text = dataTable.Rows[0]["Venda15"].ToString();
                                if (textBox.Name == "txtVenda16") textBox.Text = dataTable.Rows[0]["Venda16"].ToString();
                                if (textBox.Name == "txtVenda17") textBox.Text = dataTable.Rows[0]["Venda17"].ToString();
                                if (textBox.Name == "txtVenda18") textBox.Text = dataTable.Rows[0]["Venda18"].ToString();
                                if (textBox.Name == "txtVenda19") textBox.Text = dataTable.Rows[0]["Venda19"].ToString();
                                if (textBox.Name == "txtVenda20") textBox.Text = dataTable.Rows[0]["Venda20"].ToString();
                                if (textBox.Name == "txtVenda21") textBox.Text = dataTable.Rows[0]["Venda21"].ToString();
                                if (textBox.Name == "txtVenda22") textBox.Text = dataTable.Rows[0]["Venda22"].ToString();
                                if (textBox.Name == "txtVenda23") textBox.Text = dataTable.Rows[0]["Venda23"].ToString();
                                if (textBox.Name == "txtVenda24") textBox.Text = dataTable.Rows[0]["Venda24"].ToString();
                                if (textBox.Name == "txtVenda25") textBox.Text = dataTable.Rows[0]["Venda25"].ToString();
                                if (textBox.Name == "txtVenda26") textBox.Text = dataTable.Rows[0]["Venda26"].ToString();
                                if (textBox.Name == "txtVenda27") textBox.Text = dataTable.Rows[0]["Venda27"].ToString();
                                if (textBox.Name == "txtVenda28") textBox.Text = dataTable.Rows[0]["Venda28"].ToString();
                                if (textBox.Name == "txtVenda29") textBox.Text = dataTable.Rows[0]["Venda29"].ToString();
                                if (textBox.Name == "txtVenda30") textBox.Text = dataTable.Rows[0]["Venda30"].ToString();
                                if (textBox.Name == "txtVenda31") textBox.Text = dataTable.Rows[0]["Venda31"].ToString();
                                if (textBox.Name == "txtVenda32") textBox.Text = dataTable.Rows[0]["Venda32"].ToString();
                                if (textBox.Name == "txtVenda33") textBox.Text = dataTable.Rows[0]["Venda33"].ToString();
                                if (textBox.Name == "txtVenda34") textBox.Text = dataTable.Rows[0]["Venda34"].ToString();
                                if (textBox.Name == "txtVenda35") textBox.Text = dataTable.Rows[0]["Venda35"].ToString();
                                if (textBox.Name == "txtVenda36") textBox.Text = dataTable.Rows[0]["Venda36"].ToString();
                                if (textBox.Name == "txtVenda37") textBox.Text = dataTable.Rows[0]["Venda37"].ToString();
                                if (textBox.Name == "txtVenda38") textBox.Text = dataTable.Rows[0]["Venda38"].ToString();
                                if (textBox.Name == "txtVenda39") textBox.Text = dataTable.Rows[0]["Venda39"].ToString();
                                if (textBox.Name == "txtVenda40") textBox.Text = dataTable.Rows[0]["Venda40"].ToString();
                                if (textBox.Name == "txtVenda41") textBox.Text = dataTable.Rows[0]["Venda41"].ToString();
                                if (textBox.Name == "txtVenda42") textBox.Text = dataTable.Rows[0]["Venda42"].ToString();
                                if (textBox.Name == "txtVenda43") textBox.Text = dataTable.Rows[0]["Venda43"].ToString();
                                if (textBox.Name == "txtVenda44") textBox.Text = dataTable.Rows[0]["Venda44"].ToString();
                                if (textBox.Name == "txtVenda45") textBox.Text = dataTable.Rows[0]["Venda45"].ToString();
                                if (textBox.Name == "txtVenda46") textBox.Text = dataTable.Rows[0]["Venda46"].ToString();
                                if (textBox.Name == "txtVenda47") textBox.Text = dataTable.Rows[0]["Venda47"].ToString();
                                if (textBox.Name == "txtVenda48") textBox.Text = dataTable.Rows[0]["Venda48"].ToString();
                                if (textBox.Name == "txtVenda49") textBox.Text = dataTable.Rows[0]["Venda49"].ToString();
                                if (textBox.Name == "txtVenda50") textBox.Text = dataTable.Rows[0]["Venda50"].ToString();
                                if (textBox.Name == "txtVenda51") textBox.Text = dataTable.Rows[0]["Venda51"].ToString();
                                if (textBox.Name == "txtVenda52") textBox.Text = dataTable.Rows[0]["Venda52"].ToString();
                                if (textBox.Name == "txtVenda53") textBox.Text = dataTable.Rows[0]["Venda53"].ToString();
                                if (textBox.Name == "txtVenda54") textBox.Text = dataTable.Rows[0]["Venda54"].ToString();
                                if (textBox.Name == "txtVenda55") textBox.Text = dataTable.Rows[0]["Venda55"].ToString();
                                if (textBox.Name == "txtVenda56") textBox.Text = dataTable.Rows[0]["Venda56"].ToString();
                                if (textBox.Name == "txtVenda57") textBox.Text = dataTable.Rows[0]["Venda57"].ToString();
                                if (textBox.Name == "txtVenda58") textBox.Text = dataTable.Rows[0]["Venda58"].ToString();
                                if (textBox.Name == "txtVenda59") textBox.Text = dataTable.Rows[0]["Venda59"].ToString();
                                if (textBox.Name == "txtVenda60") textBox.Text = dataTable.Rows[0]["Venda60"].ToString();
                            }
                            else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                            {
                                ComboBox comboBox = (ComboBox)controlTextBox;
                                if (comboBox.Items.Count > 0)
                                {
                                    string spausa;
                                }
                                if (comboBox.Name == "comboVenda01") comboBox.Text = dataTable.Rows[0]["Venda01"].ToString();
                                if (comboBox.Name == "comboVenda02") comboBox.Text = dataTable.Rows[0]["Venda02"].ToString();
                                if (comboBox.Name == "comboVenda03") comboBox.Text = dataTable.Rows[0]["Venda03"].ToString();
                                if (comboBox.Name == "comboVenda04") comboBox.Text = dataTable.Rows[0]["Venda04"].ToString();
                                if (comboBox.Name == "comboVenda05") comboBox.Text = dataTable.Rows[0]["Venda05"].ToString();
                                if (comboBox.Name == "comboVenda06") comboBox.Text = dataTable.Rows[0]["Venda06"].ToString();
                                if (comboBox.Name == "comboVenda07") comboBox.Text = dataTable.Rows[0]["Venda07"].ToString();
                                if (comboBox.Name == "comboVenda08") comboBox.Text = dataTable.Rows[0]["Venda08"].ToString();
                                if (comboBox.Name == "comboVenda09") comboBox.Text = dataTable.Rows[0]["Venda09"].ToString();
                                if (comboBox.Name == "comboVenda10") comboBox.Text = dataTable.Rows[0]["Venda10"].ToString();
                                if (comboBox.Name == "comboVenda11") comboBox.Text = dataTable.Rows[0]["Venda11"].ToString();
                                if (comboBox.Name == "comboVenda12") comboBox.Text = dataTable.Rows[0]["Venda12"].ToString();
                                if (comboBox.Name == "comboVenda13") comboBox.Text = dataTable.Rows[0]["Venda13"].ToString();
                                if (comboBox.Name == "comboVenda14") comboBox.Text = dataTable.Rows[0]["Venda14"].ToString();
                                if (comboBox.Name == "comboVenda15") comboBox.Text = dataTable.Rows[0]["Venda15"].ToString();
                                if (comboBox.Name == "comboVenda16") comboBox.Text = dataTable.Rows[0]["Venda16"].ToString();
                                if (comboBox.Name == "comboVenda17") comboBox.Text = dataTable.Rows[0]["Venda17"].ToString();
                                if (comboBox.Name == "comboVenda18") comboBox.Text = dataTable.Rows[0]["Venda18"].ToString();
                                if (comboBox.Name == "comboVenda19") comboBox.Text = dataTable.Rows[0]["Venda19"].ToString();
                                if (comboBox.Name == "comboVenda20") comboBox.Text = dataTable.Rows[0]["Venda20"].ToString();
                                if (comboBox.Name == "comboVenda21") comboBox.Text = dataTable.Rows[0]["Venda21"].ToString();
                                if (comboBox.Name == "comboVenda22") comboBox.Text = dataTable.Rows[0]["Venda22"].ToString();
                                if (comboBox.Name == "comboVenda23") comboBox.Text = dataTable.Rows[0]["Venda23"].ToString();
                                if (comboBox.Name == "comboVenda24") comboBox.Text = dataTable.Rows[0]["Venda24"].ToString();
                                if (comboBox.Name == "comboVenda25") comboBox.Text = dataTable.Rows[0]["Venda25"].ToString();
                                if (comboBox.Name == "comboVenda26") comboBox.Text = dataTable.Rows[0]["Venda26"].ToString();
                                if (comboBox.Name == "comboVenda27") comboBox.Text = dataTable.Rows[0]["Venda27"].ToString();
                                if (comboBox.Name == "comboVenda28") comboBox.Text = dataTable.Rows[0]["Venda28"].ToString();
                                if (comboBox.Name == "comboVenda29") comboBox.Text = dataTable.Rows[0]["Venda29"].ToString();
                                if (comboBox.Name == "comboVenda30") comboBox.Text = dataTable.Rows[0]["Venda30"].ToString();
                                if (comboBox.Name == "comboVenda31") comboBox.Text = dataTable.Rows[0]["Venda31"].ToString();
                                if (comboBox.Name == "comboVenda32") comboBox.Text = dataTable.Rows[0]["Venda32"].ToString();
                                if (comboBox.Name == "comboVenda33") comboBox.Text = dataTable.Rows[0]["Venda33"].ToString();
                                if (comboBox.Name == "comboVenda34") comboBox.Text = dataTable.Rows[0]["Venda34"].ToString();
                                if (comboBox.Name == "comboVenda35") comboBox.Text = dataTable.Rows[0]["Venda35"].ToString();
                                if (comboBox.Name == "comboVenda36") comboBox.Text = dataTable.Rows[0]["Venda36"].ToString();
                                if (comboBox.Name == "comboVenda37") comboBox.Text = dataTable.Rows[0]["Venda37"].ToString();
                                if (comboBox.Name == "comboVenda38") comboBox.Text = dataTable.Rows[0]["Venda38"].ToString();
                                if (comboBox.Name == "comboVenda39") comboBox.Text = dataTable.Rows[0]["Venda39"].ToString();
                                if (comboBox.Name == "comboVenda40") comboBox.Text = dataTable.Rows[0]["Venda40"].ToString();
                                if (comboBox.Name == "comboVenda41") comboBox.Text = dataTable.Rows[0]["Venda41"].ToString();
                                if (comboBox.Name == "comboVenda42") comboBox.Text = dataTable.Rows[0]["Venda42"].ToString();
                                if (comboBox.Name == "comboVenda43") comboBox.Text = dataTable.Rows[0]["Venda43"].ToString();
                                if (comboBox.Name == "comboVenda44") comboBox.Text = dataTable.Rows[0]["Venda44"].ToString();
                                if (comboBox.Name == "comboVenda45") comboBox.Text = dataTable.Rows[0]["Venda45"].ToString();
                                if (comboBox.Name == "comboVenda46") comboBox.Text = dataTable.Rows[0]["Venda46"].ToString();
                                if (comboBox.Name == "comboVenda47") comboBox.Text = dataTable.Rows[0]["Venda47"].ToString();
                                if (comboBox.Name == "comboVenda48") comboBox.Text = dataTable.Rows[0]["Venda48"].ToString();
                                if (comboBox.Name == "comboVenda49") comboBox.Text = dataTable.Rows[0]["Venda49"].ToString();
                                if (comboBox.Name == "comboVenda50") comboBox.Text = dataTable.Rows[0]["Venda50"].ToString();
                                if (comboBox.Name == "comboVenda51") comboBox.Text = dataTable.Rows[0]["Venda51"].ToString();
                                if (comboBox.Name == "comboVenda52") comboBox.Text = dataTable.Rows[0]["Venda52"].ToString();
                                if (comboBox.Name == "comboVenda53") comboBox.Text = dataTable.Rows[0]["Venda53"].ToString();
                                if (comboBox.Name == "comboVenda54") comboBox.Text = dataTable.Rows[0]["Venda54"].ToString();
                                if (comboBox.Name == "comboVenda55") comboBox.Text = dataTable.Rows[0]["Venda55"].ToString();
                                if (comboBox.Name == "comboVenda56") comboBox.Text = dataTable.Rows[0]["Venda56"].ToString();
                                if (comboBox.Name == "comboVenda57") comboBox.Text = dataTable.Rows[0]["Venda57"].ToString();
                                if (comboBox.Name == "comboVenda58") comboBox.Text = dataTable.Rows[0]["Venda58"].ToString();
                                if (comboBox.Name == "comboVenda59") comboBox.Text = dataTable.Rows[0]["Venda59"].ToString();
                                if (comboBox.Name == "comboVenda60") comboBox.Text = dataTable.Rows[0]["Venda60"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void fDadosVenda_detalhe_Load(object sender, EventArgs e)
        {
            AutoScrollPosition = new Point(0, 0);

            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            

            CarregarCamposCampanha(iIDCampanha);
            CarregarStatusAuditoria();

            DefinirAcessos();
            comboAuditoria.DropDownStyle = ComboBoxStyle.DropDownList;

         
        }

        private void cmdFechar_Click(object sender, EventArgs e)
        {
            //Liberar venda em uso pelo backoffice
            prospectCTL CProspect = new prospectCTL();

            if (fLogin.Usuario.Perfil != "Operador")
                CProspect.PegarVendaParaAuditarBackoffice(Convert.ToInt32(lblIDHistorico.Text), -1);

            //Seta variavel para atualizar resultado da consulta no formulário "fBackofficeVenda_filtro"
            fBackofficeVenda_filtro.bAtualizarRelatorio = true;

            this.Close();
        }

        private void DefinirAcessos()
        {
            if (fLogin.Usuario.Perfil == "Operador")
            {
                lblTituloFormulario.Text = "DADOS DA VENDA";
                this.Text = "DADOS DA VENDA";
                cmdSalvar.Visible = false;

                txtTelefone1.ReadOnly = true;
                txtTelefone2.ReadOnly = true;
                txtTelefone3.ReadOnly = true;
                txtObservacao.ReadOnly = true;
                txtNome.ReadOnly = true;
                txtCPF_CNPJ.ReadOnly = true;
                txtLogradouro.ReadOnly = true;
                txtNumero.ReadOnly = true;
                txtComplemento.ReadOnly = true;
                txtBairro.ReadOnly = true;
                txtCidade.ReadOnly = true;
                txtEstado.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtCep.ReadOnly = true;
                lblObs.Visible = false;
                txtDataContato.ReadOnly = true;
                comboAuditoria.Enabled = false;

                BloquearCampos();

                for (int i = 0; i < grbDadosProspect.Controls.Count; i++)
                {
                    if (grbDadosProspect.Controls[i].Name.IndexOf("txtCampo") > -1)
                    {
                        TextBox textBox = (TextBox)grbDadosProspect.Controls[i];
                        textBox.BackColor = Color.White;
                        textBox.ReadOnly = true;
                    }
                    if (grbDadosProspect.Controls[i].Name.IndexOf("combo") > -1)
                    {
                        ComboBox comboBox = (ComboBox)grbDadosProspect.Controls[i];
                        comboBox.Enabled = false;
                    }
                }
            }
            else
            {
                lblTituloFormulario.Text = "BACKOFFICE - AUDITORIA DADOS DA VENDA";
                this.Text = "BACKOFFICE - AUDITORIA DADOS DA VENDA";
                cmdSalvar.Visible = true;
                txtObservacao.ReadOnly = false;

                txtTelefone1.ReadOnly = true;
                lblObs.Visible = true;

                for (int i = 0; i < grbDadosProspect.Controls.Count; i++)
                {
                    if (grbDadosProspect.Controls[i].Name.IndexOf("txtCampo") > -1)
                    {
                        TextBox textBox = (TextBox)grbDadosProspect.Controls[i];
                        textBox.ReadOnly = false;
                    }
                }
            }
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (txtDataContato.Text.Length != 16)
            {
                sMensagem = "[Data Contato] inválido.\n\nFormato correto: dd/mm/aaaa hh:mm";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!PontoBr.Conversoes.Data.ValidarDataBr(txtDataContato.Text))
            {
                sMensagem = "[Data Contato] inválido.\n\nFormato correto: dd/mm/aaaa hh:mm";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Verificar se é venda e caso seja faz a verificação dos campos obrigatórios
            //#Contato com Sucesso# ou #Pesquisa Realizada#

            //Dados de Venda
            string sLabel, sTextBox;
            foreach (Control controlLabel in grbVenda.Controls)
            {
                if (controlLabel.Text.IndexOf("*") > -1 && controlLabel.Name.IndexOf("lblVenda") > -1)
                {
                    foreach (Control controlTextBox in grbVenda.Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                        {
                            TextBox textBox = (TextBox)controlTextBox;
                            if (textBox.Text.Trim() == "")
                            {
                                sMensagem = "Favor preencher [" + controlLabel.Text.Replace(":", "").Replace("*", "") + "].";
                                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                        {
                            ComboBox comboBox = (ComboBox)controlTextBox;
                            if (comboBox.Text == "-")
                            {
                                sMensagem = "Favor selecionar [" + controlLabel.Text.Replace(":", "").Replace("*", "") + "].";
                                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (PodeSalvar())
                {
                    prospectCTL CProspect = new prospectCTL();
                    try
                    {
                        //Atualizar dados do prospect
                        prospect prospect = new prospect();
                        prospect.IDProspect = Convert.ToInt32(lblIDProspect_valor.Text);
                        prospect.Nome = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNome.Text);
                        prospect.Telefone2 = Convert.ToDouble(txtTelefone2.Text == "" ? 0 : Convert.ToDouble(txtTelefone2.Text));
                        prospect.Telefone3 = Convert.ToDouble(txtTelefone3.Text == "" ? 0 : Convert.ToDouble(txtTelefone3.Text));
                        prospect.CPF_CNPJ = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCPF_CNPJ.Text);
                        prospect.Logradouro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtLogradouro.Text);
                        prospect.Numero = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtNumero.Text);
                        prospect.Complemento = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtComplemento.Text);
                        prospect.Bairro = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtBairro.Text);
                        prospect.Cidade = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCidade.Text);
                        prospect.Estado = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtEstado.Text);
                        prospect.Email = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtEmail.Text);
                        prospect.Cep = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtCep.Text);//rr

                        string sLabel, sTextBox;
                        foreach (Control controlLabel in grbDadosProspect.Controls)
                        {
                            if (controlLabel.Name.IndexOf("lblCampo") > -1)
                            {
                                foreach (Control controlTextBox in grbDadosProspect.Controls)
                                {
                                    sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                                    sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                                    if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txtCampo") > -1)
                                    {
                                        TextBox textBox = (TextBox)controlTextBox;
                                        if (textBox.Name == "txtCampo01") prospect.Campo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo02") prospect.Campo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo03") prospect.Campo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo04") prospect.Campo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo05") prospect.Campo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo06") prospect.Campo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo07") prospect.Campo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo08") prospect.Campo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo09") prospect.Campo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                        if (textBox.Name == "txtCampo10") prospect.Campo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    }
                                    else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("comboCampo") > -1)
                                    {
                                        ComboBox comboBox = (ComboBox)controlTextBox;
                                        if (comboBox.Name == "comboCampo01") prospect.Campo01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo02") prospect.Campo02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo03") prospect.Campo03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo04") prospect.Campo04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo05") prospect.Campo05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo06") prospect.Campo06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo07") prospect.Campo07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo08") prospect.Campo08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo09") prospect.Campo09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                        if (comboBox.Name == "comboCampo10") prospect.Campo10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    }
                                }
                            }
                        }
                        CProspect.AtualizarDadosProspect(prospect, false);

                    }
                    catch
                    {
                    }

                    relatorioCTL CRelatorio = new relatorioCTL();
                    DataTable dataTable = CRelatorio.RetornarDadosVenda(Convert.ToInt32(lblIDHistorico.Text));

                    int iNumeroAlteracoes = 0;
                    prospect Prospect = new prospect();
                    foreach (Control controlLabel in grbVenda.Controls)
                    {
                        string sLabel, sTextBox;

                        if (controlLabel.Name.IndexOf("lblVenda") > -1)
                        {
                            foreach (Control controlTextBox in grbVenda.Controls)
                            {
                                sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                                sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                                if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                                {
                                    TextBox textBox = (TextBox)controlTextBox;

                                    //Salva log de alterações dos campos feitas pelo Backoffice
                                    try
                                    {
                                        if (PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text) != dataTable.Rows[0][sLabel].ToString())
                                        {
                                            iNumeroAlteracoes++;

                                            string sCampo = controlLabel.Text.Replace(":", "").Replace("*", "");
                                            string sDe = dataTable.Rows[0][sLabel].ToString();
                                            string sPara = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                            int iIDBackoffice = fLogin.Usuario.IDUsuario;
                                            string sDns = Dns.GetHostName();

                                            CProspect.CadastrarLogAuditoria(Convert.ToInt32(lblIDHistorico.Text), iIDBackoffice, sCampo, sDe, sPara, sDns);
                                        }
                                    }
                                    catch { }

                                    if (textBox.Name == "txtVenda01") Prospect.Venda01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda02") Prospect.Venda02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda03") Prospect.Venda03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda04") Prospect.Venda04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda05") Prospect.Venda05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda06") Prospect.Venda06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda07") Prospect.Venda07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda08") Prospect.Venda08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda09") Prospect.Venda09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda10") Prospect.Venda10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda11") Prospect.Venda11 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda12") Prospect.Venda12 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda13") Prospect.Venda13 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda14") Prospect.Venda14 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda15") Prospect.Venda15 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda16") Prospect.Venda16 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda17") Prospect.Venda17 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda18") Prospect.Venda18 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda19") Prospect.Venda19 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda20") Prospect.Venda20 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda21") Prospect.Venda21 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda22") Prospect.Venda22 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda23") Prospect.Venda23 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda24") Prospect.Venda24 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda25") Prospect.Venda25 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda26") Prospect.Venda26 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda27") Prospect.Venda27 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda28") Prospect.Venda28 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda29") Prospect.Venda29 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda30") Prospect.Venda30 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda31") Prospect.Venda31 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda32") Prospect.Venda32 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda33") Prospect.Venda33 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda34") Prospect.Venda34 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda35") Prospect.Venda35 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda36") Prospect.Venda36 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda37") Prospect.Venda37 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda38") Prospect.Venda38 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda39") Prospect.Venda39 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda40") Prospect.Venda40 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda41") Prospect.Venda41 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda42") Prospect.Venda42 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda43") Prospect.Venda43 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda44") Prospect.Venda44 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda45") Prospect.Venda45 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda46") Prospect.Venda46 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda47") Prospect.Venda47 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda48") Prospect.Venda48 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda49") Prospect.Venda49 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda50") Prospect.Venda50 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda51") Prospect.Venda51 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda52") Prospect.Venda52 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda53") Prospect.Venda53 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda54") Prospect.Venda54 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda55") Prospect.Venda55 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda56") Prospect.Venda56 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda57") Prospect.Venda57 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda58") Prospect.Venda58 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda59") Prospect.Venda59 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                    if (textBox.Name == "txtVenda60") Prospect.Venda60 = PontoBr.Utilidades.String.RemoverCaracterInvalido(textBox.Text);
                                }
                                else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                                {
                                    ComboBox comboBox = (ComboBox)controlTextBox;

                                    //Salva log de alterações dos campos feitas pelo Backoffice
                                    try
                                    {
                                        if (PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text) != dataTable.Rows[0][sLabel].ToString())
                                        {
                                            iNumeroAlteracoes++;

                                            string sCampo = controlLabel.Text.Replace(":", "").Replace("*", "");
                                            string sDe = dataTable.Rows[0][sLabel].ToString();
                                            string sPara = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                            int iIDBackoffice = fLogin.Usuario.IDUsuario;
                                            string sDns = Dns.GetHostName();

                                            CProspect.CadastrarLogAuditoria(Convert.ToInt32(lblIDHistorico.Text), iIDBackoffice, sCampo, sDe, sPara, sDns);
                                        }
                                    }
                                    catch { }

                                    if (comboBox.Name == "comboVenda01") Prospect.Venda01 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda02") Prospect.Venda02 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda03") Prospect.Venda03 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda04") Prospect.Venda04 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda05") Prospect.Venda05 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda06") Prospect.Venda06 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda07") Prospect.Venda07 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda08") Prospect.Venda08 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda09") Prospect.Venda09 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda10") Prospect.Venda10 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda11") Prospect.Venda11 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda12") Prospect.Venda12 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda13") Prospect.Venda13 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda14") Prospect.Venda14 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda15") Prospect.Venda15 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda16") Prospect.Venda16 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda17") Prospect.Venda17 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda18") Prospect.Venda18 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda19") Prospect.Venda19 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda20") Prospect.Venda20 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda21") Prospect.Venda21 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda22") Prospect.Venda22 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda23") Prospect.Venda23 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda24") Prospect.Venda24 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda25") Prospect.Venda25 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda26") Prospect.Venda26 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda27") Prospect.Venda27 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda28") Prospect.Venda28 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda29") Prospect.Venda29 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda30") Prospect.Venda30 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda31") Prospect.Venda31 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda32") Prospect.Venda32 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda33") Prospect.Venda33 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda34") Prospect.Venda34 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda35") Prospect.Venda35 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda36") Prospect.Venda36 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda37") Prospect.Venda37 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda38") Prospect.Venda38 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda39") Prospect.Venda39 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda40") Prospect.Venda40 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda41") Prospect.Venda41 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda42") Prospect.Venda42 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda43") Prospect.Venda43 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda44") Prospect.Venda44 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda45") Prospect.Venda45 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda46") Prospect.Venda46 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda47") Prospect.Venda47 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda48") Prospect.Venda48 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda49") Prospect.Venda49 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda50") Prospect.Venda50 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda51") Prospect.Venda51 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda52") Prospect.Venda52 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda53") Prospect.Venda53 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda54") Prospect.Venda54 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda55") Prospect.Venda55 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda56") Prospect.Venda56 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda57") Prospect.Venda57 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda58") Prospect.Venda58 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda59") Prospect.Venda59 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                    if (comboBox.Name == "comboVenda60") Prospect.Venda60 = PontoBr.Utilidades.String.RemoverCaracterInvalido(comboBox.Text);
                                }
                            }
                        }
                    }

                    Prospect.IDUsuarioAuditoria = fLogin.Usuario.IDUsuario;
                    Prospect.IDStatusAuditoria = Convert.ToInt32(comboAuditoria.SelectedValue);

                    if (CProspect.VerificarExistenciaVenda(Convert.ToInt32(lblIDHistorico.Text)))
                        CProspect.AtualizarDadosVenda(Convert.ToInt32(lblIDHistorico.Text), Prospect);
                    else
                    {
                        CProspect.SalvarDadosVenda(Convert.ToInt32(lblIDHistorico.Text), Prospect);
                        CProspect.AtualizarDadosVenda(Convert.ToInt32(lblIDHistorico.Text), Prospect);
                    }

                    string sDataCadastro = PontoBr.Conversoes.Data.ConverterDataFormatoDDMMAAAAComBarraParaAAAAMMDDComBarra(
                            txtDataContato.Text.ToString()) + " " + txtDataContato.Text.Substring(11, 5);

                    //Salva Observacao da tHistorico
                    CProspect.AtualizarHistorico(Convert.ToInt32(lblIDHistorico.Text), sDataCadastro,
                    PontoBr.Utilidades.String.RemoverCaracterInvalido(txtObservacao.Text));

                    //Liberar venda em uso pelo backoffice
                    if (fLogin.Usuario.Perfil != "Operador")
                        CProspect.PegarVendaParaAuditarBackoffice(Convert.ToInt32(lblIDHistorico.Text), -1);

                    BloquearCampos();

                    string sMensagem = "Venda atualizada com sucesso!";
                    if (iNumeroAlteracoes == 1)
                        sMensagem += "\n\nFoi alterado " + iNumeroAlteracoes.ToString() + " campo na aba [Dados da Venda].";

                    if (iNumeroAlteracoes > 1)
                        sMensagem += "\n\nForam alterados " + iNumeroAlteracoes.ToString() + " campos na aba [Dados da Venda].";

                    MessageBox.Show(sMensagem, "Tabulare");

                    //Seta variavel para atualizar resultado da consulta no formulário "fBackofficeVenda_filtro"
                    fBackofficeVenda_filtro.bAtualizarRelatorio = true;

                    this.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private void CarregarStatusAuditoria()
        {
            auditoriaCTL CAuditoria = new auditoriaCTL();
            CAuditoria.PreencherComboBox_StatusAuditoria(comboAuditoria, true, false, false);
        }

        public static void ExibirForm(Form form)
        {
            form.MdiParent = tabulare.fBackOffice.ActiveForm;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void BloquearCampos()
        {
            string sLabel, sTextBox;
            foreach (Control controlLabel in grbVenda.Controls)
            {
                if (controlLabel.Name.IndexOf("lblVenda") > -1)
                {
                    foreach (Control controlTextBox in grbVenda.Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                        {
                            TextBox textBox = (TextBox)controlTextBox;
                            if (textBox.Name == "txtVenda01") textBox.ReadOnly = true; textBox.BackColor = Color.White;
                            if (textBox.Name == "txtVenda02") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda03") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda04") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda05") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda06") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda07") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda08") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda09") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda10") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda11") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda12") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda13") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda14") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda15") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda16") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda17") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda18") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda19") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda20") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda21") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda22") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda23") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda24") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda25") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda26") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda27") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda28") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda29") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda30") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda31") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda32") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda33") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda34") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda35") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda36") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda37") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda38") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda39") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda40") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda41") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda42") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda43") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda44") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda45") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda46") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda47") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda48") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda49") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda50") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda51") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda52") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda53") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda54") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda55") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda56") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda57") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda58") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda59") textBox.ReadOnly = true;
                            if (textBox.Name == "txtVenda60") textBox.ReadOnly = true;
                        }
                        else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                        {
                            ComboBox comboBox = (ComboBox)controlTextBox;
                            if (comboBox.Name == "comboVenda01") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda02") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda03") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda04") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda05") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda06") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda07") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda08") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda09") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda10") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda11") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda12") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda13") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda14") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda15") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda16") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda17") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda18") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda19") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda20") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda21") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda22") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda23") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda24") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda25") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda26") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda27") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda28") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda29") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda30") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda31") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda32") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda33") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda34") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda35") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda36") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda37") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda38") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda39") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda40") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda41") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda42") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda43") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda44") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda45") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda46") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda47") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda48") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda49") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda50") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda51") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda52") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda53") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda54") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda55") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda56") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda57") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda58") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda59") comboBox.Enabled = false;
                            if (comboBox.Name == "comboVenda60") comboBox.Enabled = false;
                        }
                    }
                }
            }
        }

        private void tabDadosVenda_MouseMove(object sender, MouseEventArgs e)
        {
            AutoScrollPosition = new Point(0, 0);
        }

        private void CarregarCamposCampanha(int iIDCampanha)
        {
            //Exclui os campos da tela principal do atendimento
            for (int i = 0; i < grbDadosProspect.Controls.Count; i++)
            {
                if (grbDadosProspect.Controls[i].Name.IndexOf("txtCampo") > -1
                    || grbDadosProspect.Controls[i].Name.IndexOf("lblCampo") > -1
                    || grbDadosProspect.Controls[i].Name.IndexOf("comboCampo") > -1)
                {
                    grbDadosProspect.Controls.Remove(grbDadosProspect.Controls[i]);
                    i = 0;
                }
            }

            //Exclui os dados de venda
            for (int i = 0; i < tabDadosVenda.TabPages[1].Controls.Count; i++)
            {
                if (tabDadosVenda.TabPages[1].Controls[i].Name.IndexOf("txtVenda") > -1
                    || tabDadosVenda.TabPages[1].Controls[i].Name.IndexOf("lblVenda") > -1
                    || tabDadosVenda.TabPages[1].Controls[i].Name.IndexOf("comboVenda") > -1)
                {
                    tabDadosVenda.TabPages[2].Controls.Remove(tabDadosVenda.TabPages[2].Controls[i]);
                    i = 0;
                }
            }

            configuracaoCTL CConfiguracao = new configuracaoCTL();
            arrayList = new ArrayList();
            arrayList.Clear();

            arrayList = CConfiguracao.RetornarCamposCampanha(iIDCampanha);

            int iTabIndexContato = 40;
            int iTabIndexVenda = 100;

            for (int iItem = 0; iItem < arrayList.Count; iItem++)
            {
                configuracao Configuracao = (configuracao)arrayList[iItem];
                int X, Y;
                string[] sSubstring;
                string[] sLista;

                Label label = new Label();
                TextBox textBox = new TextBox();
                ComboBox comboBox = new ComboBox();

                label.Name = Configuracao.Label;
                textBox.Name = Configuracao.TextBox;
                comboBox.Name = Configuracao.TextBox.Replace("txt", "combo");
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                textBox.MaxLength = 200;
                textBox.Enabled = true;
                textBox.Visible = true;

                sSubstring = Configuracao.LocalizacaoTextBox.Split(';');
                X = Convert.ToInt32(sSubstring[0].Trim());
                Y = Convert.ToInt32(sSubstring[1].Trim());
                textBox.Location = new System.Drawing.Point(X, Y);
                comboBox.Location = new System.Drawing.Point(X, Y);

                sSubstring = Configuracao.TamanhoTextBox.Split(';');
                X = Convert.ToInt32(sSubstring[0].Trim());
                Y = Convert.ToInt32(sSubstring[1].Trim());
                textBox.Size = new System.Drawing.Size(X, Y);
                comboBox.Size = new System.Drawing.Size(X, Y);

                sSubstring = Configuracao.LocalizacaoLabel.Split(';');
                X = Convert.ToInt32(sSubstring[0].Trim());
                Y = Convert.ToInt32(sSubstring[1].Trim());
                label.Location = new System.Drawing.Point(X, Y);

                label.Visible = true;
                label.Text = Configuracao.Obrigatorio == true ? Configuracao.Texto.Trim() + "*:" : Configuracao.Texto.Trim() + ":";
                label.Size = new System.Drawing.Size(label.PreferredWidth, 13);

                if (Configuracao.IDCampo.IndexOf("c") > -1)
                {
                    grbDadosProspect.Controls.Add(label);

                    /*TextBox ou DropDown*/
                    if (Configuracao.Lista == "")
                    {
                        grbDadosProspect.Controls.Add(textBox);
                        textBox.TabIndex = iTabIndexContato;
                    }
                    else
                    {
                        grbDadosProspect.Controls.Add(comboBox);
                        comboBox.TabIndex = iTabIndexContato;
                    }

                    iTabIndexContato++;
                }
                else if (Configuracao.IDCampo.IndexOf("v") > -1)
                {
                    grbVenda.Controls.Add(label);

                    /*TextBox ou DropDown*/
                    if (Configuracao.Lista == "")
                    {
                        grbVenda.Controls.Add(textBox);
                        textBox.TabIndex = iTabIndexVenda;
                    }
                    else
                    {
                        grbVenda.Controls.Add(comboBox);
                        comboBox.TabIndex = iTabIndexVenda;
                    }

                    iTabIndexVenda++;
                }
                /*Carrega lista no DropDown*/
                if (Configuracao.Lista != "")
                {
                    comboBox.Items.Clear();
                    Configuracao.Lista = "-;" + Configuracao.Lista;
                    sLista = Configuracao.Lista.Split(';');
                    Array.Sort(sLista);
                    comboBox.DataSource = sLista;
                    comboBox.Refresh();
                }
            }
        }

        private void fBackofficeVenda_detalhe_Shown(object sender, EventArgs e)
        {
            CarregarDadosVenda(iIDHistorico);
        }

        private void fBackofficeVenda_detalhe_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Liberar venda em uso pelo backoffice
            prospectCTL CProspect = new prospectCTL();
            if (fLogin.Usuario.Perfil != "Operador")
                CProspect.PegarVendaParaAuditarBackoffice(Convert.ToInt32(lblIDHistorico.Text), -1);
        }

        private void AtualizarLeituraTratamentoVenda(int iIDVenda, int iIDTratamento, int iIDUsuario)
        {
            prospectCTL CProspect = new prospectCTL();
            CProspect.AtualizarLeituraTratamentoVenda(iIDVenda, iIDTratamento, iIDUsuario);
        }

        private void cmdPDF_Click(object sender, EventArgs e)
        {
            try
            {
                relatorioCTL CRelatorio = new relatorioCTL();
                
                int iIDHistorico = Convert.ToInt32(lblIDHistorico.Text);
                DataTable dataTableRelatorio = CRelatorio.RetornarVenda(iIDHistorico);

                DataTable dataTableVenda = CRelatorio.RetornarDadosVenda(iIDHistorico);
                string sNome = dataTableVenda.Rows[0]["Nome"].ToString();
                string sTelefone = dataTableVenda.Rows[0]["Telefone1"].ToString();
                string sDataContato = dataTableVenda.Rows[0]["DataCadastro"].ToString();

                reportDocument = new ReportDocument();
                reportDocument.Load(Application.StartupPath + @"\relatorio\cVenda.rpt");
                reportDocument.SetDataSource(dataTableRelatorio);

                string sFiltro = "Protocolo: " + iIDHistorico.ToString();
                sFiltro += "; Telefone: " + sTelefone;
                sFiltro += "; Data Contato: " + sDataContato;
                
                reportDocument.SetParameterValue("FILTRO", sFiltro);

                crystalReportViewer.ReportSource = reportDocument;

                string sEnderecoArquivoPDF =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Tabulare_RelatorioVenda_" + iIDHistorico.ToString() + ".pdf";

                reportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, sEnderecoArquivoPDF);

                System.Diagnostics.Process.Start(@sEnderecoArquivoPDF);
            }
            catch (Exception ex)
            {
                PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm(ex.Message, "Tabulare Software");
            }
        }
    }
}