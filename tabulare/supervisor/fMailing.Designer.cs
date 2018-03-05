namespace tabulare.supervisor
{
    partial class fMailing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMailing));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDMailing = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.grpAtivo = new System.Windows.Forms.GroupBox();
            this.radNao = new System.Windows.Forms.RadioButton();
            this.radSim = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdPlanilhaExcel = new System.Windows.Forms.Button();
            this.cmdGerarMailingCallfex = new System.Windows.Forms.Button();
            this.grpTelefones = new System.Windows.Forms.GroupBox();
            this.chkDuplicado = new System.Windows.Forms.CheckBox();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmdSalvar = new System.Windows.Forms.Button();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.cmdNovo = new System.Windows.Forms.Button();
            this.cmdImportar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.txtMailing = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.prbProgresso = new System.Windows.Forms.ProgressBar();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.dgMailing = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.chkListarAtivos = new System.Windows.Forms.CheckBox();
            this.comboCampanha_filtro = new System.Windows.Forms.ComboBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grpMailing = new System.Windows.Forms.GroupBox();
            this.dgMailingPlanilha = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpAtivo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTelefones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMailing)).BeginInit();
            this.grpMailing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMailingPlanilha)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(580, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód.:";
            this.label1.Visible = false;
            // 
            // txtIDMailing
            // 
            this.txtIDMailing.BackColor = System.Drawing.Color.White;
            this.txtIDMailing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDMailing.Location = new System.Drawing.Point(614, 70);
            this.txtIDMailing.Name = "txtIDMailing";
            this.txtIDMailing.ReadOnly = true;
            this.txtIDMailing.Size = new System.Drawing.Size(100, 20);
            this.txtIDMailing.TabIndex = 1;
            this.txtIDMailing.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arquivo:";
            // 
            // txtArquivo
            // 
            this.txtArquivo.BackColor = System.Drawing.Color.White;
            this.txtArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArquivo.Location = new System.Drawing.Point(86, 44);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.ReadOnly = true;
            this.txtArquivo.Size = new System.Drawing.Size(313, 20);
            this.txtArquivo.TabIndex = 1;
            // 
            // grpAtivo
            // 
            this.grpAtivo.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.grpAtivo.Controls.Add(this.radNao);
            this.grpAtivo.Controls.Add(this.radSim);
            this.grpAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAtivo.Location = new System.Drawing.Point(419, 77);
            this.grpAtivo.Name = "grpAtivo";
            this.grpAtivo.Size = new System.Drawing.Size(124, 41);
            this.grpAtivo.TabIndex = 48;
            this.grpAtivo.TabStop = false;
            this.grpAtivo.Text = "Ativo";
            // 
            // radNao
            // 
            this.radNao.AutoSize = true;
            this.radNao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNao.Location = new System.Drawing.Point(75, 18);
            this.radNao.Name = "radNao";
            this.radNao.Size = new System.Drawing.Size(45, 17);
            this.radNao.TabIndex = 3;
            this.radNao.Text = "Não";
            this.radNao.UseVisualStyleBackColor = true;
            // 
            // radSim
            // 
            this.radSim.AutoSize = true;
            this.radSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSim.Location = new System.Drawing.Point(14, 17);
            this.radSim.Name = "radSim";
            this.radSim.Size = new System.Drawing.Size(42, 17);
            this.radSim.TabIndex = 2;
            this.radSim.Text = "Sim";
            this.radSim.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdPlanilhaExcel);
            this.groupBox1.Controls.Add(this.cmdGerarMailingCallfex);
            this.groupBox1.Controls.Add(this.grpTelefones);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.cmdSalvar);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.cmdNovo);
            this.groupBox1.Controls.Add(this.grpAtivo);
            this.groupBox1.Controls.Add(this.cmdImportar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmdCancelar);
            this.groupBox1.Controls.Add(this.txtMailing);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIDMailing);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.prbProgresso);
            this.groupBox1.Controls.Add(this.txtArquivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 132);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mailing";
            // 
            // cmdPlanilhaExcel
            // 
            this.cmdPlanilhaExcel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdPlanilhaExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPlanilhaExcel.FlatAppearance.BorderSize = 0;
            this.cmdPlanilhaExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdPlanilhaExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPlanilhaExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdPlanilhaExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdPlanilhaExcel.Image")));
            this.cmdPlanilhaExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdPlanilhaExcel.Location = new System.Drawing.Point(742, 19);
            this.cmdPlanilhaExcel.Name = "cmdPlanilhaExcel";
            this.cmdPlanilhaExcel.Size = new System.Drawing.Size(255, 25);
            this.cmdPlanilhaExcel.TabIndex = 164;
            this.cmdPlanilhaExcel.Text = "Planilha de importação - Excel";
            this.cmdPlanilhaExcel.UseVisualStyleBackColor = true;
            this.cmdPlanilhaExcel.Click += new System.EventHandler(this.cmdPlanilhaExcel_Click);
            // 
            // cmdGerarMailingCallfex
            // 
            this.cmdGerarMailingCallfex.Image = global::v1Tabulare_z13.Properties.Resources.Callflex;
            this.cmdGerarMailingCallfex.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGerarMailingCallfex.Location = new System.Drawing.Point(1164, 55);
            this.cmdGerarMailingCallfex.Name = "cmdGerarMailingCallfex";
            this.cmdGerarMailingCallfex.Size = new System.Drawing.Size(109, 25);
            this.cmdGerarMailingCallfex.TabIndex = 163;
            this.cmdGerarMailingCallfex.Text = "Gerar Call Flex    ";
            this.cmdGerarMailingCallfex.UseVisualStyleBackColor = true;
            this.cmdGerarMailingCallfex.Visible = false;
            // 
            // grpTelefones
            // 
            this.grpTelefones.Controls.Add(this.chkDuplicado);
            this.grpTelefones.Location = new System.Drawing.Point(419, 13);
            this.grpTelefones.Name = "grpTelefones";
            this.grpTelefones.Size = new System.Drawing.Size(299, 48);
            this.grpTelefones.TabIndex = 79;
            this.grpTelefones.TabStop = false;
            this.grpTelefones.Text = "Telefones";
            // 
            // chkDuplicado
            // 
            this.chkDuplicado.AutoSize = true;
            this.chkDuplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDuplicado.Location = new System.Drawing.Point(14, 19);
            this.chkDuplicado.Name = "chkDuplicado";
            this.chkDuplicado.Size = new System.Drawing.Size(281, 17);
            this.chkDuplicado.TabIndex = 62;
            this.chkDuplicado.Text = "Não importar telefones já existentes na base de dados";
            this.chkDuplicado.UseVisualStyleBackColor = true;
            // 
            // cmdFechar
            // 
            this.cmdFechar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFechar.FlatAppearance.BorderSize = 0;
            this.cmdFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdFechar.Image = global::v1Tabulare_z13.Properties.Resources.fFechar;
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.Location = new System.Drawing.Point(1164, 86);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(109, 25);
            this.cmdFechar.TabIndex = 123;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // cmdSalvar
            // 
            this.cmdSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSalvar.FlatAppearance.BorderSize = 0;
            this.cmdSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalvar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalvar.Image = global::v1Tabulare_z13.Properties.Resources.SalvarP;
            this.cmdSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalvar.Location = new System.Drawing.Point(742, 86);
            this.cmdSalvar.Name = "cmdSalvar";
            this.cmdSalvar.Size = new System.Drawing.Size(109, 25);
            this.cmdSalvar.TabIndex = 74;
            this.cmdSalvar.Text = "Salvar";
            this.cmdSalvar.UseVisualStyleBackColor = true;
            this.cmdSalvar.Click += new System.EventHandler(this.cmdSalvar_Click);
            // 
            // comboCampanha
            // 
            this.comboCampanha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(86, 69);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(313, 21);
            this.comboCampanha.TabIndex = 66;
            // 
            // cmdNovo
            // 
            this.cmdNovo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdNovo.FlatAppearance.BorderSize = 0;
            this.cmdNovo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNovo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdNovo.Image = global::v1Tabulare_z13.Properties.Resources.bNovo;
            this.cmdNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNovo.Location = new System.Drawing.Point(742, 56);
            this.cmdNovo.Name = "cmdNovo";
            this.cmdNovo.Size = new System.Drawing.Size(109, 25);
            this.cmdNovo.TabIndex = 76;
            this.cmdNovo.Text = "Novo";
            this.cmdNovo.UseVisualStyleBackColor = true;
            this.cmdNovo.Click += new System.EventHandler(this.cmdNovo_Click);
            // 
            // cmdImportar
            // 
            this.cmdImportar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdImportar.FlatAppearance.BorderSize = 0;
            this.cmdImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImportar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdImportar.Image = global::v1Tabulare_z13.Properties.Resources.Prospect;
            this.cmdImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdImportar.Location = new System.Drawing.Point(888, 56);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(109, 25);
            this.cmdImportar.TabIndex = 77;
            this.cmdImportar.Text = "Importar";
            this.cmdImportar.UseVisualStyleBackColor = true;
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(23, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Campanha:";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancelar.FlatAppearance.BorderSize = 0;
            this.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancelar.Image = global::v1Tabulare_z13.Properties.Resources.Abort1;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.Location = new System.Drawing.Point(888, 86);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(109, 25);
            this.cmdCancelar.TabIndex = 75;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // txtMailing
            // 
            this.txtMailing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailing.Location = new System.Drawing.Point(86, 19);
            this.txtMailing.Name = "txtMailing";
            this.txtMailing.Size = new System.Drawing.Size(313, 20);
            this.txtMailing.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Mailing:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Progresso:";
            // 
            // prbProgresso
            // 
            this.prbProgresso.BackColor = System.Drawing.Color.White;
            this.prbProgresso.Location = new System.Drawing.Point(86, 95);
            this.prbProgresso.Name = "prbProgresso";
            this.prbProgresso.Size = new System.Drawing.Size(313, 23);
            this.prbProgresso.TabIndex = 58;
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.BackColor = System.Drawing.Color.Transparent;
            this.lblFormulario.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFormulario.Location = new System.Drawing.Point(408, 11);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(179, 26);
            this.lblFormulario.TabIndex = 13;
            this.lblFormulario.Text = "lblFormulario";
            // 
            // dgMailing
            // 
            this.dgMailing.AllowUserToAddRows = false;
            this.dgMailing.AllowUserToDeleteRows = false;
            this.dgMailing.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgMailing.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMailing.BackgroundColor = System.Drawing.Color.White;
            this.dgMailing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMailing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgMailing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMailing.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMailing.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgMailing.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgMailing.Location = new System.Drawing.Point(19, 50);
            this.dgMailing.MultiSelect = false;
            this.dgMailing.Name = "dgMailing";
            this.dgMailing.ReadOnly = true;
            this.dgMailing.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgMailing.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgMailing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMailing.ShowCellErrors = false;
            this.dgMailing.ShowEditingIcon = false;
            this.dgMailing.ShowRowErrors = false;
            this.dgMailing.Size = new System.Drawing.Size(1285, 281);
            this.dgMailing.TabIndex = 57;
            this.dgMailing.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMailing_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Campanha:";
            // 
            // chkListarAtivos
            // 
            this.chkListarAtivos.AutoSize = true;
            this.chkListarAtivos.Checked = true;
            this.chkListarAtivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkListarAtivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListarAtivos.Location = new System.Drawing.Point(529, 26);
            this.chkListarAtivos.Name = "chkListarAtivos";
            this.chkListarAtivos.Size = new System.Drawing.Size(160, 17);
            this.chkListarAtivos.TabIndex = 63;
            this.chkListarAtivos.Text = "Listar apenas mailings ativos";
            this.chkListarAtivos.UseVisualStyleBackColor = true;
            this.chkListarAtivos.CheckedChanged += new System.EventHandler(this.chkListarAtivos_CheckedChanged);
            // 
            // comboCampanha_filtro
            // 
            this.comboCampanha_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCampanha_filtro.FormattingEnabled = true;
            this.comboCampanha_filtro.Location = new System.Drawing.Point(79, 23);
            this.comboCampanha_filtro.Name = "comboCampanha_filtro";
            this.comboCampanha_filtro.Size = new System.Drawing.Size(434, 21);
            this.comboCampanha_filtro.TabIndex = 79;
            this.comboCampanha_filtro.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_filtro_SelectionChangeCommitted);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(697, 20);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 81;
            // 
            // grpMailing
            // 
            this.grpMailing.Controls.Add(this.dgMailingPlanilha);
            this.grpMailing.Location = new System.Drawing.Point(12, 152);
            this.grpMailing.Name = "grpMailing";
            this.grpMailing.Size = new System.Drawing.Size(1319, 157);
            this.grpMailing.TabIndex = 98;
            this.grpMailing.TabStop = false;
            this.grpMailing.Text = "Registros do Mailing";
            // 
            // dgMailingPlanilha
            // 
            this.dgMailingPlanilha.AllowUserToAddRows = false;
            this.dgMailingPlanilha.AllowUserToDeleteRows = false;
            this.dgMailingPlanilha.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgMailingPlanilha.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgMailingPlanilha.BackgroundColor = System.Drawing.Color.White;
            this.dgMailingPlanilha.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMailingPlanilha.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgMailingPlanilha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMailingPlanilha.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMailingPlanilha.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgMailingPlanilha.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgMailingPlanilha.Location = new System.Drawing.Point(12, 19);
            this.dgMailingPlanilha.MultiSelect = false;
            this.dgMailingPlanilha.Name = "dgMailingPlanilha";
            this.dgMailingPlanilha.ReadOnly = true;
            this.dgMailingPlanilha.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgMailingPlanilha.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgMailingPlanilha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMailingPlanilha.ShowCellErrors = false;
            this.dgMailingPlanilha.ShowEditingIcon = false;
            this.dgMailingPlanilha.ShowRowErrors = false;
            this.dgMailingPlanilha.Size = new System.Drawing.Size(1295, 121);
            this.dgMailingPlanilha.TabIndex = 97;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRegistros);
            this.groupBox2.Controls.Add(this.comboCampanha_filtro);
            this.groupBox2.Controls.Add(this.chkListarAtivos);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dgMailing);
            this.groupBox2.Location = new System.Drawing.Point(12, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1319, 343);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mailings Cadastrados";
            // 
            // fMailing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 672);
            this.Controls.Add(this.grpMailing);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "fMailing";
            this.ShowIcon = false;
            this.Text = "Mailing";
            this.Load += new System.EventHandler(this.fMailing_Load);
            this.grpAtivo.ResumeLayout(false);
            this.grpAtivo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTelefones.ResumeLayout(false);
            this.grpTelefones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMailing)).EndInit();
            this.grpMailing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMailingPlanilha)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDMailing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.GroupBox grpAtivo;
        private System.Windows.Forms.RadioButton radNao;
        private System.Windows.Forms.RadioButton radSim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar prbProgresso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMailing;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.CheckBox chkDuplicado;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdImportar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdNovo;
        private System.Windows.Forms.Button cmdSalvar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.GroupBox grpTelefones;
        private System.Windows.Forms.Button cmdGerarMailingCallfex;
        private System.Windows.Forms.Button cmdPlanilhaExcel;
        private System.Windows.Forms.DataGridView dgMailing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkListarAtivos;
        private System.Windows.Forms.ComboBox comboCampanha_filtro;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grpMailing;
        private System.Windows.Forms.DataGridView dgMailingPlanilha;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}