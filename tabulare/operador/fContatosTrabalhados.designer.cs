namespace tabulare.operador
{
    partial class fContatosTrabalhados
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
            this.label5 = new System.Windows.Forms.Label();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.datDataInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdExportar = new System.Windows.Forms.Button();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.datDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 25);
            this.label5.TabIndex = 68;
            this.label5.Text = "CONTATOS TRABALHADOS";
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(13, 148);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.SelectionFormula = "";
            this.crystalReportViewer.ShowExportButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.ShowPrintButton = false;
            this.crystalReportViewer.ShowRefreshButton = false;
            this.crystalReportViewer.ShowTextSearchButton = false;
            this.crystalReportViewer.ShowZoomButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(977, 489);
            this.crystalReportViewer.TabIndex = 67;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // datDataInicial
            // 
            this.datDataInicial.Location = new System.Drawing.Point(105, 20);
            this.datDataInicial.Name = "datDataInicial";
            this.datDataInicial.Size = new System.Drawing.Size(227, 20);
            this.datDataInicial.TabIndex = 74;
            this.datDataInicial.ValueChanged += new System.EventHandler(this.datDataInicial_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Data Inicial:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.cmdExportar);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.datDataFinal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.datDataInicial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(977, 104);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro do Relatório";
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
            this.cmdExportar.Location = new System.Drawing.Point(223, 72);
            this.cmdExportar.Name = "cmdExportar";
            this.cmdExportar.Size = new System.Drawing.Size(109, 25);
            this.cmdExportar.TabIndex = 126;
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
            this.cmdGerar.Location = new System.Drawing.Point(105, 72);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(108, 26);
            this.cmdGerar.TabIndex = 125;
            this.cmdGerar.Text = "Gerar dados";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // datDataFinal
            // 
            this.datDataFinal.Location = new System.Drawing.Point(105, 46);
            this.datDataFinal.Name = "datDataFinal";
            this.datDataFinal.Size = new System.Drawing.Size(227, 20);
            this.datDataFinal.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Data Final:";
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
            this.cmdFechar.Location = new System.Drawing.Point(338, 72);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(108, 25);
            this.cmdFechar.TabIndex = 75;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // fContatosTrabalhados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 656);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.Name = "fContatosTrabalhados";
            this.Text = "Contatos Trabalhados";
            this.Load += new System.EventHandler(this.fContatosTrabalhados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.DateTimePicker datDataInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.DateTimePicker datDataFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.Button cmdExportar;
    }
}