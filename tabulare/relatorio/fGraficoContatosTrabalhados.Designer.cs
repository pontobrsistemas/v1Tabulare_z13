namespace tabulare.relatorio
{
    partial class fGraficoContatosTrabalhados
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
            this.chkUltimoResubmit = new System.Windows.Forms.CheckBox();
            this.chkListarAtivos = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboHoraFinal = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboHoraInicial = new System.Windows.Forms.ComboBox();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.grpOpcoes = new System.Windows.Forms.GroupBox();
            this.radReceptivo = new System.Windows.Forms.RadioButton();
            this.radAtivo = new System.Windows.Forms.RadioButton();
            this.radTodos = new System.Windows.Forms.RadioButton();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdDesmarcar = new System.Windows.Forms.Button();
            this.cmdMarcar = new System.Windows.Forms.Button();
            this.chlStatus = new System.Windows.Forms.CheckedListBox();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMailing = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datDataFinal = new System.Windows.Forms.DateTimePicker();
            this.datDataInicial = new System.Windows.Forms.DateTimePicker();
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.grpContatosTrabalhados = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grpOpcoes.SuspendLayout();
            this.grpContatosTrabalhados.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(17, 19);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.SelectionFormula = "";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.ShowRefreshButton = false;
            this.crystalReportViewer.ShowTextSearchButton = false;
            this.crystalReportViewer.ShowZoomButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1278, 389);
            this.crystalReportViewer.TabIndex = 7;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUltimoResubmit);
            this.groupBox1.Controls.Add(this.chkListarAtivos);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboHoraFinal);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.comboHoraInicial);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.grpOpcoes);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmdDesmarcar);
            this.groupBox1.Controls.Add(this.cmdMarcar);
            this.groupBox1.Controls.Add(this.chlStatus);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboMailing);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.datDataFinal);
            this.groupBox1.Controls.Add(this.datDataInicial);
            this.groupBox1.Controls.Add(this.comboOperador);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1307, 207);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro do Relatório";
            // 
            // chkUltimoResubmit
            // 
            this.chkUltimoResubmit.AutoSize = true;
            this.chkUltimoResubmit.Location = new System.Drawing.Point(906, 184);
            this.chkUltimoResubmit.Name = "chkUltimoResubmit";
            this.chkUltimoResubmit.Size = new System.Drawing.Size(289, 17);
            this.chkUltimoResubmit.TabIndex = 156;
            this.chkUltimoResubmit.Text = "Retornar apenas os contatos depois do último Resubmit";
            this.chkUltimoResubmit.UseVisualStyleBackColor = true;
            // 
            // chkListarAtivos
            // 
            this.chkListarAtivos.AutoSize = true;
            this.chkListarAtivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListarAtivos.Location = new System.Drawing.Point(543, 97);
            this.chkListarAtivos.Name = "chkListarAtivos";
            this.chkListarAtivos.Size = new System.Drawing.Size(173, 17);
            this.chkListarAtivos.TabIndex = 155;
            this.chkListarAtivos.Text = "Listar mailings ativos e inativos.";
            this.chkListarAtivos.UseVisualStyleBackColor = true;
            this.chkListarAtivos.CheckedChanged += new System.EventHandler(this.chkListarAtivos_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(359, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 154;
            this.label9.Text = "Hora final:";
            // 
            // comboHoraFinal
            // 
            this.comboHoraFinal.FormattingEnabled = true;
            this.comboHoraFinal.Items.AddRange(new object[] {
            "",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00"});
            this.comboHoraFinal.Location = new System.Drawing.Point(416, 42);
            this.comboHoraFinal.Name = "comboHoraFinal";
            this.comboHoraFinal.Size = new System.Drawing.Size(121, 21);
            this.comboHoraFinal.TabIndex = 153;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 152;
            this.label10.Text = "Hora inicial:";
            // 
            // comboHoraInicial
            // 
            this.comboHoraInicial.FormattingEnabled = true;
            this.comboHoraInicial.Items.AddRange(new object[] {
            "",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00"});
            this.comboHoraInicial.Location = new System.Drawing.Point(416, 16);
            this.comboHoraInicial.Name = "comboHoraInicial";
            this.comboHoraInicial.Size = new System.Drawing.Size(121, 21);
            this.comboHoraInicial.TabIndex = 151;
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
            this.cmdFechar.Location = new System.Drawing.Point(216, 154);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(110, 26);
            this.cmdFechar.TabIndex = 127;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // grpOpcoes
            // 
            this.grpOpcoes.Controls.Add(this.radReceptivo);
            this.grpOpcoes.Controls.Add(this.radAtivo);
            this.grpOpcoes.Controls.Add(this.radTodos);
            this.grpOpcoes.Location = new System.Drawing.Point(576, 23);
            this.grpOpcoes.Name = "grpOpcoes";
            this.grpOpcoes.Size = new System.Drawing.Size(298, 51);
            this.grpOpcoes.TabIndex = 126;
            this.grpOpcoes.TabStop = false;
            this.grpOpcoes.Text = "Opções";
            // 
            // radReceptivo
            // 
            this.radReceptivo.AutoSize = true;
            this.radReceptivo.Location = new System.Drawing.Point(150, 17);
            this.radReceptivo.Name = "radReceptivo";
            this.radReceptivo.Size = new System.Drawing.Size(132, 17);
            this.radReceptivo.TabIndex = 80;
            this.radReceptivo.Text = "Receptivo / Indicação";
            this.radReceptivo.UseVisualStyleBackColor = true;
            // 
            // radAtivo
            // 
            this.radAtivo.AutoSize = true;
            this.radAtivo.Location = new System.Drawing.Point(89, 17);
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
            this.radTodos.Location = new System.Drawing.Point(23, 17);
            this.radTodos.Name = "radTodos";
            this.radTodos.Size = new System.Drawing.Size(55, 17);
            this.radTodos.TabIndex = 78;
            this.radTodos.TabStop = true;
            this.radTodos.Text = "Todos";
            this.radTodos.UseVisualStyleBackColor = true;
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
            this.cmdGerar.Location = new System.Drawing.Point(84, 154);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(110, 25);
            this.cmdGerar.TabIndex = 125;
            this.cmdGerar.Text = "Gerar dados";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(903, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Status da Ligação (Resultado do Contato):";
            // 
            // cmdDesmarcar
            // 
            this.cmdDesmarcar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDesmarcar.Image = global::v1Tabulare_z13.Properties.Resources.DTodos;
            this.cmdDesmarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDesmarcar.Location = new System.Drawing.Point(1113, 154);
            this.cmdDesmarcar.Name = "cmdDesmarcar";
            this.cmdDesmarcar.Size = new System.Drawing.Size(111, 26);
            this.cmdDesmarcar.TabIndex = 79;
            this.cmdDesmarcar.Text = "Nenhum";
            this.cmdDesmarcar.UseVisualStyleBackColor = true;
            this.cmdDesmarcar.Click += new System.EventHandler(this.cmdDesmarcar_Click);
            // 
            // cmdMarcar
            // 
            this.cmdMarcar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMarcar.Image = global::v1Tabulare_z13.Properties.Resources.STodos;
            this.cmdMarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMarcar.Location = new System.Drawing.Point(904, 154);
            this.cmdMarcar.Name = "cmdMarcar";
            this.cmdMarcar.Size = new System.Drawing.Size(112, 26);
            this.cmdMarcar.TabIndex = 78;
            this.cmdMarcar.Text = "Todos";
            this.cmdMarcar.UseVisualStyleBackColor = true;
            this.cmdMarcar.Click += new System.EventHandler(this.cmdMarcar_Click);
            // 
            // chlStatus
            // 
            this.chlStatus.CheckOnClick = true;
            this.chlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chlStatus.FormattingEnabled = true;
            this.chlStatus.Location = new System.Drawing.Point(904, 29);
            this.chlStatus.Name = "chlStatus";
            this.chlStatus.Size = new System.Drawing.Size(320, 121);
            this.chlStatus.TabIndex = 70;
            // 
            // comboCampanha
            // 
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(84, 70);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(453, 21);
            this.comboCampanha.TabIndex = 48;
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Campanha:";
            // 
            // comboMailing
            // 
            this.comboMailing.FormattingEnabled = true;
            this.comboMailing.Location = new System.Drawing.Point(84, 95);
            this.comboMailing.Name = "comboMailing";
            this.comboMailing.Size = new System.Drawing.Size(453, 21);
            this.comboMailing.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Mailing:";
            // 
            // datDataFinal
            // 
            this.datDataFinal.Location = new System.Drawing.Point(84, 43);
            this.datDataFinal.Name = "datDataFinal";
            this.datDataFinal.Size = new System.Drawing.Size(226, 20);
            this.datDataFinal.TabIndex = 44;
            // 
            // datDataInicial
            // 
            this.datDataInicial.Location = new System.Drawing.Point(84, 17);
            this.datDataInicial.Name = "datDataInicial";
            this.datDataInicial.Size = new System.Drawing.Size(226, 20);
            this.datDataInicial.TabIndex = 43;
            // 
            // comboOperador
            // 
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Location = new System.Drawing.Point(84, 120);
            this.comboOperador.Name = "comboOperador";
            this.comboOperador.Size = new System.Drawing.Size(453, 21);
            this.comboOperador.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Operador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Data Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 20);
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
            // grpContatosTrabalhados
            // 
            this.grpContatosTrabalhados.Controls.Add(this.crystalReportViewer);
            this.grpContatosTrabalhados.Location = new System.Drawing.Point(12, 213);
            this.grpContatosTrabalhados.Name = "grpContatosTrabalhados";
            this.grpContatosTrabalhados.Size = new System.Drawing.Size(1307, 424);
            this.grpContatosTrabalhados.TabIndex = 150;
            this.grpContatosTrabalhados.TabStop = false;
            this.grpContatosTrabalhados.Text = "Filtro";
            // 
            // fGraficoContatosTrabalhados
            // 
            this.AcceptButton = this.cmdGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1276, 672);
            this.Controls.Add(this.grpContatosTrabalhados);
            this.Controls.Add(this.groupBox1);
            this.Name = "fGraficoContatosTrabalhados";
            this.ShowIcon = false;
            this.Text = "Gráfico Contatos Trabalhados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fContatosTrabalhados_FormClosing);
            this.Load += new System.EventHandler(this.fContatosTrabalhados_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fContatosTrabalhadosSintetico_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpOpcoes.ResumeLayout(false);
            this.grpOpcoes.PerformLayout();
            this.grpContatosTrabalhados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboOperador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datDataInicial;
        private System.Windows.Forms.DateTimePicker datDataFinal;
        private System.Windows.Forms.ComboBox comboMailing;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox chlStatus;
        private System.Windows.Forms.Button cmdDesmarcar;
        private System.Windows.Forms.Button cmdMarcar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.GroupBox grpOpcoes;
        private System.Windows.Forms.RadioButton radReceptivo;
        private System.Windows.Forms.RadioButton radAtivo;
        private System.Windows.Forms.RadioButton radTodos;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.GroupBox grpContatosTrabalhados;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboHoraFinal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboHoraInicial;
        private System.Windows.Forms.CheckBox chkListarAtivos;
        private System.Windows.Forms.CheckBox chkUltimoResubmit;
    }
}