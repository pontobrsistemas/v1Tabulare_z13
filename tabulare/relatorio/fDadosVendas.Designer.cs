namespace tabulare.relatorio
{
    partial class fDadosVenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.chkListarInativos = new System.Windows.Forms.CheckBox();
            this.cmdNenhum = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.cmdTodos = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.comboAuditoria = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkCampanha = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpOpcoes = new System.Windows.Forms.GroupBox();
            this.radReceptivo = new System.Windows.Forms.RadioButton();
            this.radAtivo = new System.Windows.Forms.RadioButton();
            this.radTodos = new System.Windows.Forms.RadioButton();
            this.cmdExportar = new System.Windows.Forms.Button();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboMailing = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datDataFinal = new System.Windows.Forms.DateTimePicker();
            this.datDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.grpDadosVenda = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grpOpcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.grpDadosVenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblQuantidade);
            this.groupBox1.Controls.Add(this.chkListarInativos);
            this.groupBox1.Controls.Add(this.cmdNenhum);
            this.groupBox1.Controls.Add(this.lblRegistros);
            this.groupBox1.Controls.Add(this.cmdTodos);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.comboAuditoria);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chkCampanha);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.grpOpcoes);
            this.groupBox1.Controls.Add(this.cmdExportar);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.comboOperador);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboMailing);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.datDataFinal);
            this.groupBox1.Controls.Add(this.datDataInicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1309, 184);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro do Relatório";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.Black;
            this.lblQuantidade.Location = new System.Drawing.Point(1062, 46);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(0, 13);
            this.lblQuantidade.TabIndex = 160;
            // 
            // chkListarInativos
            // 
            this.chkListarInativos.AutoSize = true;
            this.chkListarInativos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListarInativos.Location = new System.Drawing.Point(1046, 26);
            this.chkListarInativos.Name = "chkListarInativos";
            this.chkListarInativos.Size = new System.Drawing.Size(130, 17);
            this.chkListarInativos.TabIndex = 159;
            this.chkListarInativos.Text = "Listar mailings inativos";
            this.chkListarInativos.UseVisualStyleBackColor = true;
            this.chkListarInativos.CheckedChanged += new System.EventHandler(this.chkListarInativos_CheckedChanged);
            // 
            // cmdNenhum
            // 
            this.cmdNenhum.BackColor = System.Drawing.SystemColors.Control;
            this.cmdNenhum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdNenhum.Image = global::v1Tabulare_z13.Properties.Resources.DTodos;
            this.cmdNenhum.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdNenhum.Location = new System.Drawing.Point(932, 141);
            this.cmdNenhum.Name = "cmdNenhum";
            this.cmdNenhum.Size = new System.Drawing.Size(110, 25);
            this.cmdNenhum.TabIndex = 158;
            this.cmdNenhum.Text = "Nenhum";
            this.cmdNenhum.UseVisualStyleBackColor = true;
            this.cmdNenhum.Click += new System.EventHandler(this.cmdNenhum_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(657, 81);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 140;
            // 
            // cmdTodos
            // 
            this.cmdTodos.BackColor = System.Drawing.SystemColors.Control;
            this.cmdTodos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdTodos.Image = global::v1Tabulare_z13.Properties.Resources.STodos;
            this.cmdTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdTodos.Location = new System.Drawing.Point(812, 141);
            this.cmdTodos.Name = "cmdTodos";
            this.cmdTodos.Size = new System.Drawing.Size(111, 25);
            this.cmdTodos.TabIndex = 157;
            this.cmdTodos.Text = "Todos   ";
            this.cmdTodos.UseVisualStyleBackColor = true;
            this.cmdTodos.Click += new System.EventHandler(this.cmdTodos_Click);
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
            this.cmdFechar.Location = new System.Drawing.Point(253, 131);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(110, 25);
            this.cmdFechar.TabIndex = 139;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // comboAuditoria
            // 
            this.comboAuditoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAuditoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAuditoria.FormattingEnabled = true;
            this.comboAuditoria.Location = new System.Drawing.Point(412, 76);
            this.comboAuditoria.Name = "comboAuditoria";
            this.comboAuditoria.Size = new System.Drawing.Size(232, 21);
            this.comboAuditoria.TabIndex = 129;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(809, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 155;
            this.label10.Text = "Campanha:";
            // 
            // chkCampanha
            // 
            this.chkCampanha.FormattingEnabled = true;
            this.chkCampanha.Location = new System.Drawing.Point(812, 26);
            this.chkCampanha.Name = "chkCampanha";
            this.chkCampanha.Size = new System.Drawing.Size(230, 109);
            this.chkCampanha.TabIndex = 156;
            this.chkCampanha.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkCampanha_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(358, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 130;
            this.label7.Text = "Auditoria:";
            // 
            // grpOpcoes
            // 
            this.grpOpcoes.Controls.Add(this.radReceptivo);
            this.grpOpcoes.Controls.Add(this.radAtivo);
            this.grpOpcoes.Controls.Add(this.radTodos);
            this.grpOpcoes.Location = new System.Drawing.Point(22, 71);
            this.grpOpcoes.Name = "grpOpcoes";
            this.grpOpcoes.Size = new System.Drawing.Size(294, 44);
            this.grpOpcoes.TabIndex = 128;
            this.grpOpcoes.TabStop = false;
            this.grpOpcoes.Text = "Opções";
            // 
            // radReceptivo
            // 
            this.radReceptivo.AutoSize = true;
            this.radReceptivo.Location = new System.Drawing.Point(138, 16);
            this.radReceptivo.Name = "radReceptivo";
            this.radReceptivo.Size = new System.Drawing.Size(132, 17);
            this.radReceptivo.TabIndex = 80;
            this.radReceptivo.Text = "Receptivo / Indicação";
            this.radReceptivo.UseVisualStyleBackColor = true;
            // 
            // radAtivo
            // 
            this.radAtivo.AutoSize = true;
            this.radAtivo.Location = new System.Drawing.Point(77, 16);
            this.radAtivo.Name = "radAtivo";
            this.radAtivo.Size = new System.Drawing.Size(49, 17);
            this.radAtivo.TabIndex = 79;
            this.radAtivo.Text = "Ativo";
            this.radAtivo.UseVisualStyleBackColor = true;
            // 
            // radTodos
            // 
            this.radTodos.AutoSize = true;
            this.radTodos.Checked = true;
            this.radTodos.Location = new System.Drawing.Point(11, 16);
            this.radTodos.Name = "radTodos";
            this.radTodos.Size = new System.Drawing.Size(55, 17);
            this.radTodos.TabIndex = 78;
            this.radTodos.TabStop = true;
            this.radTodos.Text = "Todos";
            this.radTodos.UseVisualStyleBackColor = true;
            // 
            // cmdExportar
            // 
            this.cmdExportar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExportar.FlatAppearance.BorderSize = 0;
            this.cmdExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExportar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdExportar.Image = global::v1Tabulare_z13.Properties.Resources.ExportarD;
            this.cmdExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdExportar.Location = new System.Drawing.Point(137, 131);
            this.cmdExportar.Name = "cmdExportar";
            this.cmdExportar.Size = new System.Drawing.Size(110, 25);
            this.cmdExportar.TabIndex = 127;
            this.cmdExportar.Text = "Exportar dados   ";
            this.cmdExportar.UseVisualStyleBackColor = true;
            this.cmdExportar.Click += new System.EventHandler(this.cmdExportar_Click);
            // 
            // cmdGerar
            // 
            this.cmdGerar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdGerar.FlatAppearance.BorderSize = 0;
            this.cmdGerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdGerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGerar.Image = global::v1Tabulare_z13.Properties.Resources.GDados;
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGerar.Location = new System.Drawing.Point(22, 131);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(109, 25);
            this.cmdGerar.TabIndex = 126;
            this.cmdGerar.Text = "Gerar dados";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // comboOperador
            // 
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Location = new System.Drawing.Point(412, 51);
            this.comboOperador.Name = "comboOperador";
            this.comboOperador.Size = new System.Drawing.Size(382, 21);
            this.comboOperador.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Operador:";
            // 
            // comboMailing
            // 
            this.comboMailing.FormattingEnabled = true;
            this.comboMailing.Location = new System.Drawing.Point(412, 26);
            this.comboMailing.Name = "comboMailing";
            this.comboMailing.Size = new System.Drawing.Size(382, 21);
            this.comboMailing.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Mailing:";
            // 
            // datDataFinal
            // 
            this.datDataFinal.Location = new System.Drawing.Point(88, 44);
            this.datDataFinal.Name = "datDataFinal";
            this.datDataFinal.Size = new System.Drawing.Size(228, 20);
            this.datDataFinal.TabIndex = 71;
            // 
            // datDataInicial
            // 
            this.datDataInicial.Location = new System.Drawing.Point(88, 19);
            this.datDataInicial.Name = "datDataInicial";
            this.datDataInicial.Size = new System.Drawing.Size(228, 20);
            this.datDataInicial.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Data Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Inicial:";
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            this.dgDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDados.BackgroundColor = System.Drawing.Color.White;
            this.dgDados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDados.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgDados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDados.Location = new System.Drawing.Point(11, 19);
            this.dgDados.MultiSelect = false;
            this.dgDados.Name = "dgDados";
            this.dgDados.ReadOnly = true;
            this.dgDados.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgDados.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDados.ShowCellErrors = false;
            this.dgDados.ShowEditingIcon = false;
            this.dgDados.ShowRowErrors = false;
            this.dgDados.Size = new System.Drawing.Size(1286, 416);
            this.dgDados.TabIndex = 69;
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
            // grpDadosVenda
            // 
            this.grpDadosVenda.Controls.Add(this.dgDados);
            this.grpDadosVenda.Location = new System.Drawing.Point(12, 192);
            this.grpDadosVenda.Name = "grpDadosVenda";
            this.grpDadosVenda.Size = new System.Drawing.Size(1309, 453);
            this.grpDadosVenda.TabIndex = 151;
            this.grpDadosVenda.TabStop = false;
            this.grpDadosVenda.Text = "Filtro";
            // 
            // fDadosVenda
            // 
            this.AcceptButton = this.cmdGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 672);
            this.Controls.Add(this.grpDadosVenda);
            this.Controls.Add(this.groupBox1);
            this.Name = "fDadosVenda";
            this.ShowIcon = false;
            this.Text = "Dados da Venda";
            this.Load += new System.EventHandler(this.fContatosTrabalhados_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fDadosVenda_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpOpcoes.ResumeLayout(false);
            this.grpOpcoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.grpDadosVenda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.DateTimePicker datDataInicial;
        private System.Windows.Forms.DateTimePicker datDataFinal;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.ComboBox comboMailing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboOperador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdExportar;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.GroupBox grpOpcoes;
        private System.Windows.Forms.RadioButton radReceptivo;
        private System.Windows.Forms.RadioButton radAtivo;
        private System.Windows.Forms.RadioButton radTodos;
        private System.Windows.Forms.ComboBox comboAuditoria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grpDadosVenda;
        private System.Windows.Forms.CheckedListBox chkCampanha;
        private System.Windows.Forms.Button cmdNenhum;
        private System.Windows.Forms.Button cmdTodos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkListarInativos;
        private System.Windows.Forms.Label lblQuantidade;
    }
}