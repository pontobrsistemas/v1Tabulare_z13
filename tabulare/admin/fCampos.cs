
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using model.objetos;
using controller;
using System.IO.Ports;
using System.Threading;
using System.Collections;
using v1Tabulare_z13.PlanetFone;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace tabulare.admin
{
    public partial class fCampos : Form
    {
        private string sRamal = new string(' ', 200);
        private static byte[] buff1 = new byte[200];
        private static byte[] buff2 = new byte[200];
        private static byte[] buff3 = new byte[200];
        delegate void SetTextCallback(string text);
        private static ArrayList arrayList;
        private static status Status = new status();

        public fCampos()
        {
            InitializeComponent();
        }

        private void fCampos_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblTituloFormulario.Select();
            CarregarCampanhas(fLogin.Usuario.IDUsuario);

            comboCampanha.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCampos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RetornarCamposCampanhas()
        {
            int IDCampanha;
            IDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);

            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.RetornarCamposCampanhas(comboCampos, IDCampanha, false, true);
        }

        #region Carrega textos dos labels, configurações e posicionamento na tela
        private void CarregarCamposCampanha()
        {
            RetirarCampos();

            configuracaoCTL CConfiguracao = new configuracaoCTL();
            arrayList = new ArrayList();

            arrayList = CConfiguracao.RetornarCamposCampanha(Convert.ToInt32(comboCampanha.SelectedValue));
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
                textBox.MaxLength = 200;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

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
                        grbDadosProspect.Controls.Add(textBox);
                    else
                        grbDadosProspect.Controls.Add(comboBox);

                    textBox.TabIndex = iTabIndexContato;
                    iTabIndexContato++;
                }
                else if (Configuracao.IDCampo.IndexOf("v") > -1)
                {
                    tabControlAtendimento.TabPages[1].Controls.Add(label);

                    /*TextBox ou DropDown*/
                    if (Configuracao.Lista == "")
                        tabControlAtendimento.TabPages[1].Controls.Add(textBox);
                    else
                        tabControlAtendimento.TabPages[1].Controls.Add(comboBox);

                    textBox.TabIndex = iTabIndexVenda;
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
        #endregion

        private void ExibirForm(Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        /// <summary>
        /// De acordo com o tipo de licença do cliente, ele tem direito à um número de operadores
        /// </summary>                      

        private void CarregarCampanhas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, false, true, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RetornarCamposCampanhas();
            CarregarCamposCampanha();
            comboCampos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RetirarCampos()
        {
            string sLabel, sTextBox;

            foreach (Control controlLabel in grbDadosProspect.Controls)
            {
                if (controlLabel.Name.IndexOf("lblCampo") > -1)
                {
                    foreach (Control controlTextBox in grbDadosProspect.Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                        {
                            Label label = (Label)controlLabel;
                            TextBox textBox = (TextBox)controlTextBox;

                            for (int num1 = 1; num1 < 11; ++num1)
                                if ((textBox.Name == "txtCampo0" + Convert.ToString(num1)) || (textBox.Name == "txtCampo" + Convert.ToString(num1)))
                                {
                                    textBox.Visible = false;
                                    label.Visible = false;
                                }
                        }
                        else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                        {
                            Label label = (Label)controlLabel;
                            ComboBox comboBox = (ComboBox)controlTextBox;

                            for (int num1 = 1; num1 < 11; ++num1)
                                if ((comboBox.Name == "comboCampo0" + Convert.ToString(num1)) || (comboBox.Name == "comboCampo" + Convert.ToString(num1)))
                                {
                                    comboBox.Visible = false;
                                    label.Visible = false;
                                }
                        }
                    }
                }
            }

            foreach (Control controlLabel in tabControlAtendimento.TabPages[1].Controls)
            {
                if (controlLabel.Name.IndexOf("lblVenda") > -1)
                {
                    foreach (Control controlTextBox in tabControlAtendimento.TabPages[1].Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                        {
                            Label label = (Label)controlLabel;
                            TextBox textBox = (TextBox)controlTextBox;

                            for (int num = 1; num < 61; ++num)
                                if ((textBox.Name == "txtVenda0" + Convert.ToString(num)) || (textBox.Name == "txtVenda" + Convert.ToString(num)))
                                {
                                    textBox.Visible = false;
                                    label.Visible = false;
                                }
                        }
                        else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                        {
                            Label label = (Label)controlLabel;
                            ComboBox comboBox = (ComboBox)controlTextBox;

                            for (int num = 1; num < 61; ++num)
                                if ((comboBox.Name == "comboVenda0" + Convert.ToString(num)) || (comboBox.Name == "comboVenda" + Convert.ToString(num)))
                                {
                                    comboBox.Visible = false;
                                    label.Visible = false;
                                }
                        }
                    }
                }
            }
        }

        private void RedimensionarLabel()
        {
            string sLabel, sTextBox;

            foreach (Control controlLabel in grbDadosProspect.Controls)
            {
                if (controlLabel.Name.IndexOf("lblCampo") > -1)
                {
                    foreach (Control controlTextBox in grbDadosProspect.Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && (controlTextBox.Name.IndexOf("txt") > -1 || controlTextBox.Name.IndexOf("combo") > -1))
                        {
                            Label label = (Label)controlLabel;

                            for (int num1 = 1; num1 < 11; ++num1)
                                if ((label.Name == "lblCampo0" + Convert.ToString(num1) || label.Name == "lblCampo" + Convert.ToString(num1)) && (comboCampos.SelectedValue.ToString() == "c0" + Convert.ToString(num1) || comboCampos.SelectedValue.ToString() == "c" + Convert.ToString(num1)))
                                {
                                    label.Location = new Point(Convert.ToInt32(txtLabelX.Text), Convert.ToInt32(txtLabelY.Text));
                                }
                        }
                    }
                }
            }

            foreach (Control controlLabel in tabControlAtendimento.TabPages[1].Controls)
            {
                if (controlLabel.Name.IndexOf("lblVenda") > -1)
                {
                    foreach (Control controlTextBox in tabControlAtendimento.TabPages[1].Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && (controlTextBox.Name.IndexOf("txt") > -1 || controlTextBox.Name.IndexOf("combo") > -1))
                        {
                            Label label = (Label)controlLabel;

                            for (int num = 1; num < 61; ++num)
                                if ((label.Name == "lblVenda0" + Convert.ToString(num) || label.Name == "lblVenda" + Convert.ToString(num)) && (comboCampos.SelectedValue.ToString() == "v0" + Convert.ToString(num) || comboCampos.SelectedValue.ToString() == "v" + Convert.ToString(num)))
                                {
                                    label.Location = new Point(Convert.ToInt32(txtLabelX.Text), Convert.ToInt32(txtLabelY.Text));
                                }
                        }
                    }
                }
            }
        }

        private void RedimensionarTextBox()
        {
            string sLabel, sTextBox;

            foreach (Control controlLabel in grbDadosProspect.Controls)
            {
                if (controlLabel.Name.IndexOf("lblCampo") > -1)
                {
                    foreach (Control controlTextBox in grbDadosProspect.Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                        {
                            Label label = (Label)controlLabel;
                            TextBox textBox = (TextBox)controlTextBox;

                            for (int num1 = 1; num1 < 11; ++num1)
                                if ((textBox.Name == "txtCampo0" + Convert.ToString(num1) || textBox.Name == "txtCampo" + Convert.ToString(num1)) && (comboCampos.SelectedValue.ToString() == "c0" + Convert.ToString(num1) || comboCampos.SelectedValue.ToString() == "c" + Convert.ToString(num1)))
                                {
                                    textBox.Location = new Point(Convert.ToInt32(txtTextBoxX.Text), Convert.ToInt32(txtTextBoxY.Text));
                                    textBox.Size = new System.Drawing.Size(Convert.ToInt32(txtTamanhoTextBoxW.Text), Convert.ToInt32(txtTamanhoTextBoxH.Text));
                                }
                        }
                        else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                        {
                            Label label = (Label)controlLabel;
                            ComboBox comboBox = (ComboBox)controlTextBox;

                            for (int num1 = 1; num1 < 11; ++num1)
                                if ((comboBox.Name == "comboCampo0" + Convert.ToString(num1) || comboBox.Name == "comboCampo" + Convert.ToString(num1)) && (comboCampos.SelectedValue.ToString() == "c0" + Convert.ToString(num1) || comboCampos.SelectedValue.ToString() == "c" + Convert.ToString(num1)))
                                {
                                    comboBox.Location = new Point(Convert.ToInt32(txtTextBoxX.Text), Convert.ToInt32(txtTextBoxY.Text));
                                    comboBox.Size = new System.Drawing.Size(Convert.ToInt32(txtTamanhoTextBoxW.Text), Convert.ToInt32(txtTamanhoTextBoxH.Text));
                                }
                        }
                    }
                }
            }

            foreach (Control controlLabel in tabControlAtendimento.TabPages[1].Controls)
            {
                if (controlLabel.Name.IndexOf("lblVenda") > -1)
                {
                    foreach (Control controlTextBox in tabControlAtendimento.TabPages[1].Controls)
                    {
                        sLabel = controlLabel.Name.Substring(controlLabel.Name.Length - 7, 7);
                        sTextBox = controlTextBox.Name.Length >= 7 ? controlTextBox.Name.Substring(controlTextBox.Name.Length - 7, 7) : "";

                        if (sLabel == sTextBox && controlTextBox.Name.IndexOf("txt") > -1)
                        {
                            Label label = (Label)controlLabel;
                            TextBox textBox = (TextBox)controlTextBox;

                            for (int num = 1; num < 61; ++num)
                                if ((textBox.Name == "txtVenda0" + Convert.ToString(num) || textBox.Name == "txtVenda" + Convert.ToString(num)) && (comboCampos.SelectedValue.ToString() == "v0" + Convert.ToString(num) || comboCampos.SelectedValue.ToString() == "v" + Convert.ToString(num)))
                                {
                                    textBox.Location = new Point(Convert.ToInt32(txtTextBoxX.Text), Convert.ToInt32(txtTextBoxY.Text));
                                    textBox.Size = new System.Drawing.Size(Convert.ToInt32(txtTamanhoTextBoxW.Text), Convert.ToInt32(txtTamanhoTextBoxH.Text));
                                }
                        }
                        else if (sLabel == sTextBox && controlTextBox.Name.IndexOf("combo") > -1)
                        {
                            Label label = (Label)controlLabel;
                            ComboBox comboBox = (ComboBox)controlTextBox;

                            for (int num1 = 1; num1 < 61; ++num1)
                                if ((comboBox.Name == "comboVenda0" + Convert.ToString(num1) || comboBox.Name == "comboVenda" + Convert.ToString(num1)) && (comboCampos.SelectedValue.ToString() == "v0" + Convert.ToString(num1) || comboCampos.SelectedValue.ToString() == "v" + Convert.ToString(num1)))
                                {
                                    comboBox.Location = new Point(Convert.ToInt32(txtTextBoxX.Text), Convert.ToInt32(txtTextBoxY.Text));
                                    comboBox.Size = new System.Drawing.Size(Convert.ToInt32(txtTamanhoTextBoxW.Text), Convert.ToInt32(txtTamanhoTextBoxH.Text));
                                }
                        }
                    }
                }
            }
        }

        private void comboCampos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LiberarCampos();

            int iIDCampanha;
            iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
            campanhaCTL CCampanha = new campanhaCTL();
            DataTable dataTable = CCampanha.RetornarCampo(iIDCampanha, Convert.ToString(comboCampos.SelectedValue));

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Campo não configurado");
            }
            else
            {
                string sLocalizcaoLabel = dataTable.Rows[0]["LocalizacaoLabel"].ToString();
                string[] Label = sLocalizcaoLabel.Split(';');

                string sLocalizacaoTextBox = dataTable.Rows[0]["LocalizacaoTextBox"].ToString();
                string[] TextBox = sLocalizacaoTextBox.Split(';');

                string sTamanhoTextBox = dataTable.Rows[0]["TamanhoTextBox"].ToString();
                string[] TamanhoTextBox = sTamanhoTextBox.Split(';');

                txtLabel.Text = dataTable.Rows[0]["Texto"].ToString();
                txtLabelX.Text = Label[0];
                txtLabelY.Text = Label[1];
                txtTextBoxX.Text = TextBox[0];
                txtTextBoxY.Text = TextBox[1];
                txtTamanhoTextBoxW.Text = TamanhoTextBox[0];
                txtTamanhoTextBoxH.Text = TamanhoTextBox[1];
            }
        }

        private void LiberarCampos()
        {
            txtLabel.Text = "";
            txtLabelX.Text = "";
            txtLabelY.Text = "";
            txtTextBoxX.Text = "";
            txtTextBoxY.Text = "";
            txtTamanhoTextBoxW.Text = "";
            txtTamanhoTextBoxH.Text = "";
            txtOpcoes.Text = "";
            chkObrigatorio.Checked = false;
            txtOpcoes.Text = "";

            RetornarCamposCampanhas();
            CarregarCamposCampanha();
        }

        int iMais;
        int iMenos;

        private string Somar(string sCampo)
        {
            /*Escala*/
            int iEscala = 1;
            if (rad1.Checked) iEscala = 1;
            else if (rad10.Checked) iEscala = 10;
            else if (rad100.Checked) iEscala = 100;

            iMais = Convert.ToInt32(sCampo) + iEscala;
            return Convert.ToString(iMais);
        }

        private string Subtrair(string sCampo)
        {
            /*Escala*/
            int iEscala = 1;
            if (rad1.Checked) iEscala = 1;
            else if (rad10.Checked) iEscala = 10;
            else if (rad100.Checked) iEscala = 100;

            if (sCampo == "0")
            {
                MessageBox.Show("Não pode ser menor que 0.");
                return sCampo;
            }
            else
            {
                iMenos = Convert.ToInt32(sCampo) - iEscala;
                if (iMenos < 0) iMenos = 0;
                return Convert.ToString(iMenos);
            }
        }

        private void cmdLabelMaisY_Click(object sender, EventArgs e)
        {
            txtLabelY.Text = Somar(txtLabelY.Text);
            RedimensionarLabel();
        }

        private void cmdLabelMenosY_Click_1(object sender, EventArgs e)
        {
            txtLabelY.Text = Subtrair(txtLabelY.Text);
            RedimensionarLabel();
        }

        private void cmdTextBoxMaisX_Click(object sender, EventArgs e)
        {
            txtTextBoxX.Text = Somar(txtTextBoxX.Text);
            RedimensionarTextBox();
        }

        private void cmdTextBoxMenosX_Click(object sender, EventArgs e)
        {
            txtTextBoxX.Text = Subtrair(txtTextBoxX.Text);
            RedimensionarTextBox();
        }

        private void cmdTextBoxMaisY_Click(object sender, EventArgs e)
        {
            txtTextBoxY.Text = Somar(txtTextBoxY.Text);
            RedimensionarTextBox();
        }

        private void cmdTextBoxMenosY_Click(object sender, EventArgs e)
        {
            txtTextBoxY.Text = Subtrair(txtTextBoxY.Text);
            RedimensionarTextBox();
        }

        private void cmdLabelMaisX_Click(object sender, EventArgs e)
        {
            txtLabelX.Text = Somar(txtLabelX.Text);
            RedimensionarLabel();
        }

        private void cmdLabelMenosX_Click(object sender, EventArgs e)
        {
            txtLabelX.Text = Subtrair(txtLabelX.Text);
            RedimensionarLabel();
        }

        private void cmdTextBoxMenosW_Click(object sender, EventArgs e)
        {
            txtTamanhoTextBoxW.Text = Subtrair(txtTamanhoTextBoxW.Text);
            RedimensionarTextBox();
        }

        private void cmdTextBoxMaisW_Click(object sender, EventArgs e)
        {
            txtTamanhoTextBoxW.Text = Somar(txtTamanhoTextBoxW.Text);
            RedimensionarTextBox();
        }

        private void cmdTextBoxMenosH_Click(object sender, EventArgs e)
        {
            txtTamanhoTextBoxH.Text = Subtrair(txtTamanhoTextBoxH.Text);
            RedimensionarTextBox();
        }

        private void cmdTextBoxMaisH_Click(object sender, EventArgs e)
        {
            txtTamanhoTextBoxH.Text = Somar(txtTamanhoTextBoxH.Text);
            RedimensionarTextBox();
        }

        private void txtLabelX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }

        }

        private void txtLabelY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }

        }

        private void txtTextBoxX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }
        }

        private void txtTextBoxY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }
        }

        private void comboCampos_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            int iIDCampanha;
            iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue);
            campanhaCTL CCampanha = new campanhaCTL();
            DataTable dataTable = CCampanha.RetornarCampo(iIDCampanha, Convert.ToString(comboCampos.SelectedValue));

            if (dataTable.Rows.Count == 0)
            {
                dataTable = CCampanha.RetornarCampoConfiguracaoInicial(Convert.ToString(comboCampos.SelectedValue));

                string sLocalizcaoLabel = dataTable.Rows[0]["LocalizacaoLabel"].ToString();
                string[] Label = sLocalizcaoLabel.Split(';');

                string sLocalizacaoTextBox = dataTable.Rows[0]["LocalizacaoTextBox"].ToString();
                string[] TextBox = sLocalizacaoTextBox.Split(';');

                string sTamanhoTextBox = dataTable.Rows[0]["TamanhoTextBox"].ToString();
                string[] TamanhoTextBox = sTamanhoTextBox.Split(';');

                txtLabel.Text = dataTable.Rows[0]["Texto"].ToString();
                txtLabelX.Text = Label[0];
                txtLabelY.Text = Label[1];
                txtTextBoxX.Text = TextBox[0];
                txtTextBoxY.Text = TextBox[1];
                txtTamanhoTextBoxW.Text = TamanhoTextBox[0];
                txtTamanhoTextBoxH.Text = TamanhoTextBox[1];
            }
            else
            {
                string sLocalizcaoLabel = dataTable.Rows[0]["LocalizacaoLabel"].ToString();
                string[] Label = sLocalizcaoLabel.Split(';');

                string sLocalizacaoTextBox = dataTable.Rows[0]["LocalizacaoTextBox"].ToString();
                string[] TextBox = sLocalizacaoTextBox.Split(';');

                string sTamanhoTextBox = dataTable.Rows[0]["TamanhoTextBox"].ToString();
                string[] TamanhoTextBox = sTamanhoTextBox.Split(';');

                txtLabel.Text = dataTable.Rows[0]["Texto"].ToString();
                txtLabelX.Text = Label[0];
                txtLabelY.Text = Label[1];
                txtTextBoxX.Text = TextBox[0];
                txtTextBoxY.Text = TextBox[1];
                txtTamanhoTextBoxW.Text = TamanhoTextBox[0];
                txtTamanhoTextBoxH.Text = TamanhoTextBox[1];

                txtOpcoes.Text = dataTable.Rows[0]["Lista"].ToString();
            }
        }

        private void cmdLabelMenosY_Click(object sender, EventArgs e)
        {
            txtLabelY.Text = Subtrair(txtLabelY.Text);
            RedimensionarLabel();
        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if (PodeSalvar())
            {
                try
                {
                    string sIDCampo = comboCampos.SelectedValue.ToString();
                    int iIDCampanha = Convert.ToInt32(comboCampanha.SelectedValue.ToString());
                    string sTexto = txtLabel.Text;
                    string sTamanhoTextBox = txtTamanhoTextBoxW.Text + ';' + txtTamanhoTextBoxH.Text;
                    string sLocalizacaoTextBox = txtTextBoxX.Text + ';' + txtTextBoxY.Text;
                    string sLocalizacaoLabel = txtLabelX.Text + ';' + txtLabelY.Text;
                    int iObrigatorio;
                    if (chkObrigatorio.Checked == true)
                        iObrigatorio = 1;
                    else
                        iObrigatorio = 0;
                    string sLista = PontoBr.Utilidades.String.RemoverCaracterInvalido(txtOpcoes.Text.Trim());

                    campanhaCTL CCampanha = new campanhaCTL();

                    if (txtLabel.Text.Trim() == "") /*Exclue o campo*/
                        CCampanha.ExcluirCampoCampanha(iIDCampanha, sIDCampo);
                    else /*Atualiza o campo*/
                        CCampanha.ReconfigurarCampo(iIDCampanha, sIDCampo, sTexto, sTamanhoTextBox, sLocalizacaoTextBox, sLocalizacaoLabel, iObrigatorio, sLista);

                    RetornarCamposCampanhas();
                    CarregarCamposCampanha();
                    comboCampos.SelectedValue = sIDCampo;
                }
                catch (Exception ex)
                {
                    PontoBr.Utilidades.Diversos.ExibirAlertaWindowsForm("Erro:\n\n" + ex.Message, "Tabulare Software");
                }
                comboCampos.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LiberarCampos();
            comboCampos.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool PodeSalvar()
        {
            string sMensagem;
            if (comboCampanha.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione uma [Campanha].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (comboCampos.SelectedValue.ToString() == "-1")
            {
                sMensagem = "Selecione um [Campo].";
                MessageBox.Show(sMensagem, "Tabulare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void tabControlAtendimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTituloFormulario.Select();
        }

        private void cmdTextBoxMenosH_Click_1(object sender, EventArgs e)
        {
            txtTamanhoTextBoxH.Text = Subtrair(txtTamanhoTextBoxH.Text);
            RedimensionarTextBox();
        }

        private void txtLabelX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                txtLabelY.Text = Subtrair(txtLabelY.Text);
                RedimensionarLabel();
            }
            else if (e.KeyData == Keys.Down)
            {
                txtLabelY.Text = Somar(txtLabelY.Text);
                RedimensionarLabel();
            }
            else if (e.KeyData == Keys.Right)
            {
                txtLabelX.Text = Somar(txtLabelX.Text);
                RedimensionarLabel();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtLabelX.Text = Subtrair(txtLabelX.Text);
                RedimensionarLabel();
            }
        }

        private void txtLabelY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                txtLabelY.Text = Subtrair(txtLabelY.Text);
                RedimensionarLabel();
            }
            else if (e.KeyData == Keys.Down)
            {
                txtLabelY.Text = Somar(txtLabelY.Text);
                RedimensionarLabel();
            }
            else if (e.KeyData == Keys.Right)
            {
                txtLabelX.Text = Somar(txtLabelX.Text);
                RedimensionarLabel();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtLabelX.Text = Subtrair(txtLabelX.Text);
                RedimensionarLabel();
            }
        }

        private void txtTextBoxX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                txtTextBoxY.Text = Subtrair(txtTextBoxY.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Down)
            {
                txtTextBoxY.Text = Somar(txtTextBoxY.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Right)
            {
                txtTextBoxX.Text = Somar(txtTextBoxX.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtTextBoxX.Text = Subtrair(txtTextBoxX.Text);
                RedimensionarTextBox();
            }
        }

        private void txtTextBoxY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                txtTextBoxY.Text = Subtrair(txtTextBoxY.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Down)
            {
                txtTextBoxY.Text = Somar(txtTextBoxY.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Right)
            {
                txtTextBoxX.Text = Somar(txtTextBoxX.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtTextBoxX.Text = Subtrair(txtTextBoxX.Text);
                RedimensionarTextBox();
            }
        }

        private void txtTamanhoTextBoxW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }
        }

        private void txtTamanhoTextBoxH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Favor informar apenas números no campo.");
            }
        }

        private void txtTamanhoTextBoxW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                txtTamanhoTextBoxH.Text = Somar(txtTamanhoTextBoxH.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Down)
            {
                txtTamanhoTextBoxH.Text = Subtrair(txtTamanhoTextBoxH.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Right)
            {
                txtTamanhoTextBoxW.Text = Somar(txtTamanhoTextBoxW.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtTamanhoTextBoxW.Text = Subtrair(txtTamanhoTextBoxW.Text);
                RedimensionarTextBox();
            }
        }

        private void txtTamanhoTextBoxH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                txtTamanhoTextBoxH.Text = Somar(txtTamanhoTextBoxH.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Down)
            {
                txtTamanhoTextBoxH.Text = Subtrair(txtTamanhoTextBoxH.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Right)
            {
                txtTamanhoTextBoxW.Text = Somar(txtTamanhoTextBoxW.Text);
                RedimensionarTextBox();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtTamanhoTextBoxW.Text = Subtrair(txtTamanhoTextBoxW.Text);
                RedimensionarTextBox();
            }
        }
    }
}