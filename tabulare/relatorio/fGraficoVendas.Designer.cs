namespace tabulare.relatorio
{
    partial class fGraficoVendas
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
            this.cmdFechar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.comboAuditoria = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpOpcoes = new System.Windows.Forms.GroupBox();
            this.radReceptivo = new System.Windows.Forms.RadioButton();
            this.radAtivo = new System.Windows.Forms.RadioButton();
            this.radTodos = new System.Windows.Forms.RadioButton();
            this.cmdDesmarcar = new System.Windows.Forms.Button();
            this.cmdMarcar = new System.Windows.Forms.Button();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.datDataFinal = new System.Windows.Forms.DateTimePicker();
            this.datDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.chlCampanha = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.grpOpcoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.cmdFechar.Location = new System.Drawing.Point(220, 118);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(109, 26);
            this.cmdFechar.TabIndex = 139;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.crystalReportViewer);
            this.groupBox2.Location = new System.Drawing.Point(12, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1319, 412);
            this.groupBox2.TabIndex = 155;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(16, 19);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.SelectionFormula = "";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.ShowRefreshButton = false;
            this.crystalReportViewer.ShowTextSearchButton = false;
            this.crystalReportViewer.ShowZoomButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1284, 381);
            this.crystalReportViewer.TabIndex = 7;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // comboAuditoria
            // 
            this.comboAuditoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAuditoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAuditoria.FormattingEnabled = true;
            this.comboAuditoria.Location = new System.Drawing.Point(88, 79);
            this.comboAuditoria.Name = "comboAuditoria";
            this.comboAuditoria.Size = new System.Drawing.Size(241, 21);
            this.comboAuditoria.TabIndex = 133;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(35, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 134;
            this.label7.Text = "Auditoria:";
            // 
            // grpOpcoes
            // 
            this.grpOpcoes.Controls.Add(this.radReceptivo);
            this.grpOpcoes.Controls.Add(this.radAtivo);
            this.grpOpcoes.Controls.Add(this.radTodos);
            this.grpOpcoes.Location = new System.Drawing.Point(388, 23);
            this.grpOpcoes.Name = "grpOpcoes";
            this.grpOpcoes.Size = new System.Drawing.Size(303, 47);
            this.grpOpcoes.TabIndex = 132;
            this.grpOpcoes.TabStop = false;
            this.grpOpcoes.Text = "Op��es";
            // 
            // radReceptivo
            // 
            this.radReceptivo.AutoSize = true;
            this.radReceptivo.Location = new System.Drawing.Point(140, 19);
            this.radReceptivo.Name = "radReceptivo";
            this.radReceptivo.Size = new System.Drawing.Size(132, 17);
            this.radReceptivo.TabIndex = 77;
            this.radReceptivo.Text = "Receptivo / Indica��o";
            this.radReceptivo.UseVisualStyleBackColor = true;
            // 
            // radAtivo
            // 
            this.radAtivo.AutoSize = true;
            this.radAtivo.Location = new System.Drawing.Point(79, 19);
            this.radAtivo.Name = "radAtivo";
            this.radAtivo.Size = new System.Drawing.Size(49, 17);
            this.radAtivo.TabIndex = 76;
            this.radAtivo.Text = "Ativo";
            this.radAtivo.UseVisualStyleBackColor = true;
            // 
            // radTodos
            // 
            this.radTodos.AutoSize = true;
            this.radTodos.Checked = true;
            this.radTodos.Location = new System.Drawing.Point(13, 19);
            this.radTodos.Name = "radTodos";
            this.radTodos.Size = new System.Drawing.Size(55, 17);
            this.radTodos.TabIndex = 75;
            this.radTodos.TabStop = true;
            this.radTodos.Text = "Todos";
            this.radTodos.UseVisualStyleBackColor = true;
            // 
            // cmdDesmarcar
            // 
            this.cmdDesmarcar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDesmarcar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDesmarcar.Image = global::v1Tabulare_z13.Properties.Resources.DTodos;
            this.cmdDesmarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDesmarcar.Location = new System.Drawing.Point(1053, 128);
            this.cmdDesmarcar.Name = "cmdDesmarcar";
            this.cmdDesmarcar.Size = new System.Drawing.Size(111, 26);
            this.cmdDesmarcar.TabIndex = 131;
            this.cmdDesmarcar.Text = "Nenhum";
            this.cmdDesmarcar.UseVisualStyleBackColor = true;
            this.cmdDesmarcar.Click += new System.EventHandler(this.cmdDesmarcar_Click);
            // 
            // cmdMarcar
            // 
            this.cmdMarcar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMarcar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdMarcar.Image = global::v1Tabulare_z13.Properties.Resources.STodos;
            this.cmdMarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMarcar.Location = new System.Drawing.Point(737, 128);
            this.cmdMarcar.Name = "cmdMarcar";
            this.cmdMarcar.Size = new System.Drawing.Size(112, 25);
            this.cmdMarcar.TabIndex = 130;
            this.cmdMarcar.Text = "Todos";
            this.cmdMarcar.UseVisualStyleBackColor = true;
            this.cmdMarcar.Click += new System.EventHandler(this.cmdMarcar_Click);
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
            this.cmdGerar.Location = new System.Drawing.Point(88, 118);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(109, 26);
            this.cmdGerar.TabIndex = 129;
            this.cmdGerar.Text = "Gerar dados";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.comboAuditoria);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.grpOpcoes);
            this.groupBox1.Controls.Add(this.cmdDesmarcar);
            this.groupBox1.Controls.Add(this.cmdMarcar);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.datDataFinal);
            this.groupBox1.Controls.Add(this.datDataInicial);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chlCampanha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 168);
            this.groupBox1.TabIndex = 153;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro do Relat�rio";
            // 
            // datDataFinal
            // 
            this.datDataFinal.Location = new System.Drawing.Point(88, 54);
            this.datDataFinal.Name = "datDataFinal";
            this.datDataFinal.Size = new System.Drawing.Size(241, 20);
            this.datDataFinal.TabIndex = 71;
            // 
            // datDataInicial
            // 
            this.datDataInicial.Location = new System.Drawing.Point(88, 29);
            this.datDataInicial.Name = "datDataInicial";
            this.datDataInicial.Size = new System.Drawing.Size(241, 20);
            this.datDataInicial.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(734, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Campanha:";
            // 
            // chlCampanha
            // 
            this.chlCampanha.CheckOnClick = true;
            this.chlCampanha.FormattingEnabled = true;
            this.chlCampanha.Location = new System.Drawing.Point(737, 29);
            this.chlCampanha.Name = "chlCampanha";
            this.chlCampanha.Size = new System.Drawing.Size(427, 94);
            this.chlCampanha.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 58);
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
            this.label2.Location = new System.Drawing.Point(23, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Inicial:";
            // 
            // fGraficoVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 672);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "fGraficoVendas";
            this.ShowIcon = false;
            this.Text = "Gr�fico de Vendas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fGraficoVendas_FormClosing);
            this.Load += new System.EventHandler(this.fGraficoVendas_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fGraficoVendas_MouseMove);
            this.groupBox2.ResumeLayout(false);
            this.grpOpcoes.ResumeLayout(false);
            this.grpOpcoes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.GroupBox groupBox2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.ComboBox comboAuditoria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpOpcoes;
        private System.Windows.Forms.RadioButton radReceptivo;
        private System.Windows.Forms.RadioButton radAtivo;
        private System.Windows.Forms.RadioButton radTodos;
        private System.Windows.Forms.Button cmdDesmarcar;
        private System.Windows.Forms.Button cmdMarcar;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker datDataFinal;
        private System.Windows.Forms.DateTimePicker datDataInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox chlCampanha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}