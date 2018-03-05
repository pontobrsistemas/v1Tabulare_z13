namespace tabulare.relatorio
{
    partial class fRespostasScriptSintetico
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
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.radReceptivo = new System.Windows.Forms.RadioButton();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.radAtivo = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.radTodos = new System.Windows.Forms.RadioButton();
            this.comboMailing = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datDataFinal = new System.Windows.Forms.DateTimePicker();
            this.datDataInicial = new System.Windows.Forms.DateTimePicker();
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCcliente = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(12, 151);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.SelectionFormula = "";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowRefreshButton = false;
            this.crystalReportViewer.ShowTextSearchButton = false;
            this.crystalReportViewer.ShowZoomButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(973, 484);
            this.crystalReportViewer.TabIndex = 7;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.radReceptivo);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.radAtivo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.radTodos);
            this.groupBox1.Controls.Add(this.comboMailing);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.datDataFinal);
            this.groupBox1.Controls.Add(this.datDataInicial);
            this.groupBox1.Controls.Add(this.comboOperador);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 98);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro do Relatório";
            // 
            // cmdFechar
            // 
            this.cmdFechar.BackColor = System.Drawing.Color.Aqua;
            this.cmdFechar.BackgroundImage = global::v1Tabulare_z13.Properties.Resources.Fechar;
            this.cmdFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdFechar.FlatAppearance.BorderSize = 0;
            this.cmdFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdFechar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.ForeColor = System.Drawing.Color.Black;
            this.cmdFechar.Location = new System.Drawing.Point(841, 48);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.cmdFechar.Size = new System.Drawing.Size(110, 23);
            this.cmdFechar.TabIndex = 145;
            this.cmdFechar.UseVisualStyleBackColor = false;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // cmdGerar
            // 
            this.cmdGerar.BackColor = System.Drawing.Color.Aqua;
            this.cmdGerar.BackgroundImage = global::v1Tabulare_z13.Properties.Resources.Gerar_dados;
            this.cmdGerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdGerar.FlatAppearance.BorderSize = 0;
            this.cmdGerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdGerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGerar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGerar.ForeColor = System.Drawing.Color.Aqua;
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGerar.Location = new System.Drawing.Point(842, 17);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Padding = new System.Windows.Forms.Padding(38, 0, 0, 0);
            this.cmdGerar.Size = new System.Drawing.Size(109, 24);
            this.cmdGerar.TabIndex = 130;
            this.cmdGerar.UseVisualStyleBackColor = false;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // radReceptivo
            // 
            this.radReceptivo.AutoSize = true;
            this.radReceptivo.Location = new System.Drawing.Point(151, 73);
            this.radReceptivo.Name = "radReceptivo";
            this.radReceptivo.Size = new System.Drawing.Size(132, 17);
            this.radReceptivo.TabIndex = 77;
            this.radReceptivo.Text = "Receptivo / Indicação";
            this.radReceptivo.UseVisualStyleBackColor = true;
            // 
            // comboCampanha
            // 
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(402, 17);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(400, 21);
            this.comboCampanha.TabIndex = 55;
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
            // 
            // radAtivo
            // 
            this.radAtivo.AutoSize = true;
            this.radAtivo.Location = new System.Drawing.Point(90, 73);
            this.radAtivo.Name = "radAtivo";
            this.radAtivo.Size = new System.Drawing.Size(49, 17);
            this.radAtivo.TabIndex = 76;
            this.radAtivo.Text = "Ativo";
            this.radAtivo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Campanha:";
            // 
            // radTodos
            // 
            this.radTodos.AutoSize = true;
            this.radTodos.Checked = true;
            this.radTodos.Location = new System.Drawing.Point(24, 73);
            this.radTodos.Name = "radTodos";
            this.radTodos.Size = new System.Drawing.Size(55, 17);
            this.radTodos.TabIndex = 75;
            this.radTodos.TabStop = true;
            this.radTodos.Text = "Todos";
            this.radTodos.UseVisualStyleBackColor = true;
            // 
            // comboMailing
            // 
            this.comboMailing.FormattingEnabled = true;
            this.comboMailing.Location = new System.Drawing.Point(402, 42);
            this.comboMailing.Name = "comboMailing";
            this.comboMailing.Size = new System.Drawing.Size(400, 21);
            this.comboMailing.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Mailing:";
            // 
            // datDataFinal
            // 
            this.datDataFinal.Location = new System.Drawing.Point(84, 45);
            this.datDataFinal.Name = "datDataFinal";
            this.datDataFinal.Size = new System.Drawing.Size(220, 20);
            this.datDataFinal.TabIndex = 44;
            // 
            // datDataInicial
            // 
            this.datDataInicial.Location = new System.Drawing.Point(84, 17);
            this.datDataInicial.Name = "datDataInicial";
            this.datDataInicial.Size = new System.Drawing.Size(220, 20);
            this.datDataInicial.TabIndex = 43;
            // 
            // comboOperador
            // 
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Location = new System.Drawing.Point(402, 70);
            this.comboOperador.Name = "comboOperador";
            this.comboOperador.Size = new System.Drawing.Size(400, 21);
            this.comboOperador.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Operador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Data Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Inicial:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(515, 25);
            this.label5.TabIndex = 64;
            this.label5.Text = "RELATÓRIO RESPOSTAS DO SCRIPT (SINTÉTICO)";
            // 
            // lblCcliente
            // 
            this.lblCcliente.AutoSize = true;
            this.lblCcliente.ForeColor = System.Drawing.Color.Blue;
            this.lblCcliente.Location = new System.Drawing.Point(324, 31);
            this.lblCcliente.Name = "lblCcliente";
            this.lblCcliente.Size = new System.Drawing.Size(544, 13);
            this.lblCcliente.TabIndex = 153;
            this.lblCcliente.Text = "Obs.: Este relatório exibe as respostas do script com o status #Contato com Suces" +
                "so# ou #Pesquisa Realizada#. ";
            // 
            // fRespostasScriptSintetico
            // 
            this.AcceptButton = this.cmdGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(997, 672);
            this.Controls.Add(this.lblCcliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer);
            this.Name = "fRespostasScriptSintetico";
            this.ShowIcon = false;
            this.Text = "Respostas Script (Sintético)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fRespostasScript_FormClosing);
            this.Load += new System.EventHandler(this.fRespostasScript_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fRespostasScriptSintetico_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboMailing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker datDataFinal;
        private System.Windows.Forms.DateTimePicker datDataInicial;
        private System.Windows.Forms.ComboBox comboOperador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radReceptivo;
        private System.Windows.Forms.RadioButton radAtivo;
        private System.Windows.Forms.RadioButton radTodos;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Label lblCcliente;
    }
}