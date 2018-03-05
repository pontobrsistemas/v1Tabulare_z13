namespace tabulare.relatorio
{
    partial class fRespostasScriptDetalhado
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
            this.lblCcliente = new System.Windows.Forms.Label();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.grpOpcoes = new System.Windows.Forms.GroupBox();
            this.radReceptivo = new System.Windows.Forms.RadioButton();
            this.radAtivo = new System.Windows.Forms.RadioButton();
            this.radTodos = new System.Windows.Forms.RadioButton();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboPergunta = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboMailing = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datDataFinal = new System.Windows.Forms.DateTimePicker();
            this.datDataInicial = new System.Windows.Forms.DateTimePicker();
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpOpcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(12, 231);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.SelectionFormula = "";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowRefreshButton = false;
            this.crystalReportViewer.ShowTextSearchButton = false;
            this.crystalReportViewer.ShowZoomButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(973, 428);
            this.crystalReportViewer.TabIndex = 7;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCcliente);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.grpOpcoes);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboPergunta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboMailing);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.datDataFinal);
            this.groupBox1.Controls.Add(this.datDataInicial);
            this.groupBox1.Controls.Add(this.comboOperador);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 190);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro do Relatório";
            // 
            // lblCcliente
            // 
            this.lblCcliente.AutoSize = true;
            this.lblCcliente.ForeColor = System.Drawing.Color.Blue;
            this.lblCcliente.Location = new System.Drawing.Point(423, 165);
            this.lblCcliente.Name = "lblCcliente";
            this.lblCcliente.Size = new System.Drawing.Size(544, 13);
            this.lblCcliente.TabIndex = 152;
            this.lblCcliente.Text = "Obs.: Este relatório exibe as respostas do script com o status #Contato com Suces" +
                "so# ou #Pesquisa Realizada#. ";
            this.lblCcliente.Visible = false;
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
            this.cmdFechar.Location = new System.Drawing.Point(834, 50);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.cmdFechar.Size = new System.Drawing.Size(110, 23);
            this.cmdFechar.TabIndex = 144;
            this.cmdFechar.UseVisualStyleBackColor = false;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // grpOpcoes
            // 
            this.grpOpcoes.Controls.Add(this.radReceptivo);
            this.grpOpcoes.Controls.Add(this.radAtivo);
            this.grpOpcoes.Controls.Add(this.radTodos);
            this.grpOpcoes.Location = new System.Drawing.Point(24, 124);
            this.grpOpcoes.Name = "grpOpcoes";
            this.grpOpcoes.Size = new System.Drawing.Size(308, 54);
            this.grpOpcoes.TabIndex = 130;
            this.grpOpcoes.TabStop = false;
            this.grpOpcoes.Text = "Opções";
            // 
            // radReceptivo
            // 
            this.radReceptivo.AutoSize = true;
            this.radReceptivo.Location = new System.Drawing.Point(147, 22);
            this.radReceptivo.Name = "radReceptivo";
            this.radReceptivo.Size = new System.Drawing.Size(132, 17);
            this.radReceptivo.TabIndex = 80;
            this.radReceptivo.Text = "Receptivo / Indicação";
            this.radReceptivo.UseVisualStyleBackColor = true;
            // 
            // radAtivo
            // 
            this.radAtivo.AutoSize = true;
            this.radAtivo.Location = new System.Drawing.Point(86, 22);
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
            this.radTodos.Location = new System.Drawing.Point(20, 22);
            this.radTodos.Name = "radTodos";
            this.radTodos.Size = new System.Drawing.Size(55, 17);
            this.radTodos.TabIndex = 78;
            this.radTodos.TabStop = true;
            this.radTodos.Text = "Todos";
            this.radTodos.UseVisualStyleBackColor = true;
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
            this.cmdGerar.ForeColor = System.Drawing.Color.Black;
            this.cmdGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGerar.Location = new System.Drawing.Point(834, 19);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Padding = new System.Windows.Forms.Padding(38, 0, 0, 0);
            this.cmdGerar.Size = new System.Drawing.Size(110, 23);
            this.cmdGerar.TabIndex = 129;
            this.cmdGerar.UseVisualStyleBackColor = false;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // comboCampanha
            // 
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(415, 19);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(400, 21);
            this.comboCampanha.TabIndex = 52;
            this.comboCampanha.SelectedIndexChanged += new System.EventHandler(this.comboCampanha_SelectedIndexChanged);
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Campanha:";
            // 
            // comboPergunta
            // 
            this.comboPergunta.FormattingEnabled = true;
            this.comboPergunta.Location = new System.Drawing.Point(415, 102);
            this.comboPergunta.Name = "comboPergunta";
            this.comboPergunta.Size = new System.Drawing.Size(400, 21);
            this.comboPergunta.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Pergunta:";
            // 
            // comboMailing
            // 
            this.comboMailing.FormattingEnabled = true;
            this.comboMailing.Location = new System.Drawing.Point(415, 46);
            this.comboMailing.Name = "comboMailing";
            this.comboMailing.Size = new System.Drawing.Size(400, 21);
            this.comboMailing.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Mailing:";
            // 
            // datDataFinal
            // 
            this.datDataFinal.Location = new System.Drawing.Point(84, 47);
            this.datDataFinal.Name = "datDataFinal";
            this.datDataFinal.Size = new System.Drawing.Size(220, 20);
            this.datDataFinal.TabIndex = 44;
            // 
            // datDataInicial
            // 
            this.datDataInicial.Location = new System.Drawing.Point(84, 20);
            this.datDataInicial.Name = "datDataInicial";
            this.datDataInicial.Size = new System.Drawing.Size(220, 20);
            this.datDataInicial.TabIndex = 43;
            // 
            // comboOperador
            // 
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Location = new System.Drawing.Point(415, 75);
            this.comboOperador.Name = "comboOperador";
            this.comboOperador.Size = new System.Drawing.Size(400, 21);
            this.comboOperador.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Operador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Data Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 22);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(533, 25);
            this.label6.TabIndex = 64;
            this.label6.Text = "RELATÓRIO RESPOSTAS DO SCRIPT (DETALHADO)";
            // 
            // fRespostasScriptDetalhado
            // 
            this.AcceptButton = this.cmdGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(997, 672);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer);
            this.Name = "fRespostasScriptDetalhado";
            this.ShowIcon = false;
            this.Text = "Respostas Script (Detalhado)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fRespostasScript_FormClosing);
            this.Load += new System.EventHandler(this.fRespostasScript_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fRespostasScriptDetalhado_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpOpcoes.ResumeLayout(false);
            this.grpOpcoes.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboPergunta;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.GroupBox grpOpcoes;
        private System.Windows.Forms.RadioButton radReceptivo;
        private System.Windows.Forms.RadioButton radAtivo;
        private System.Windows.Forms.RadioButton radTodos;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Label lblCcliente;
    }
}