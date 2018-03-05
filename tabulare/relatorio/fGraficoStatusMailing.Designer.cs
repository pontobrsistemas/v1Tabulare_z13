namespace tabulare.relatorio
{
    partial class fGraficoStatusMailing
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkListarAtivos = new System.Windows.Forms.CheckBox();
            this.lblRegistrosCombo = new System.Windows.Forms.Label();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMailing = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.gprStatusMailing = new System.Windows.Forms.GroupBox();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.gprStatusMailing.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkListarAtivos);
            this.groupBox1.Controls.Add(this.lblRegistrosCombo);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboMailing);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 113);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status Mailing";
            // 
            // chkListarAtivos
            // 
            this.chkListarAtivos.AutoSize = true;
            this.chkListarAtivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListarAtivos.Location = new System.Drawing.Point(530, 51);
            this.chkListarAtivos.Name = "chkListarAtivos";
            this.chkListarAtivos.Size = new System.Drawing.Size(133, 17);
            this.chkListarAtivos.TabIndex = 145;
            this.chkListarAtivos.Text = "Listar mailings inativos.";
            this.chkListarAtivos.UseVisualStyleBackColor = true;
            // 
            // lblRegistrosCombo
            // 
            this.lblRegistrosCombo.AutoSize = true;
            this.lblRegistrosCombo.Location = new System.Drawing.Point(530, 27);
            this.lblRegistrosCombo.Name = "lblRegistrosCombo";
            this.lblRegistrosCombo.Size = new System.Drawing.Size(0, 13);
            this.lblRegistrosCombo.TabIndex = 144;
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
            this.cmdGerar.Location = new System.Drawing.Point(78, 74);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(109, 26);
            this.cmdGerar.TabIndex = 131;
            this.cmdGerar.Text = "Gerar dados";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // comboCampanha
            // 
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(78, 19);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(449, 21);
            this.comboCampanha.TabIndex = 72;
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
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
            this.cmdFechar.Location = new System.Drawing.Point(202, 74);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(109, 26);
            this.cmdFechar.TabIndex = 143;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Campanha:";
            // 
            // comboMailing
            // 
            this.comboMailing.FormattingEnabled = true;
            this.comboMailing.Location = new System.Drawing.Point(78, 45);
            this.comboMailing.Name = "comboMailing";
            this.comboMailing.Size = new System.Drawing.Size(449, 21);
            this.comboMailing.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mailing:";
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
            // gprStatusMailing
            // 
            this.gprStatusMailing.Controls.Add(this.crystalReportViewer);
            this.gprStatusMailing.Location = new System.Drawing.Point(12, 120);
            this.gprStatusMailing.Name = "gprStatusMailing";
            this.gprStatusMailing.Size = new System.Drawing.Size(1319, 530);
            this.gprStatusMailing.TabIndex = 151;
            this.gprStatusMailing.TabStop = false;
            this.gprStatusMailing.Text = "Filtro";
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(18, 19);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.SelectionFormula = "";
            this.crystalReportViewer.ShowCloseButton = false;
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.ShowParameterPanelButton = false;
            this.crystalReportViewer.ShowRefreshButton = false;
            this.crystalReportViewer.ShowTextSearchButton = false;
            this.crystalReportViewer.ShowZoomButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1284, 493);
            this.crystalReportViewer.TabIndex = 8;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer.ViewTimeSelectionFormula = "";
            // 
            // fGraficoStatusMailing
            // 
            this.AcceptButton = this.cmdGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 672);
            this.Controls.Add(this.gprStatusMailing);
            this.Controls.Add(this.groupBox1);
            this.Name = "fGraficoStatusMailing";
            this.ShowIcon = false;
            this.Text = "Gráfico Status Mailing";
            this.Load += new System.EventHandler(this.fStatusMailing_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fStatusMailing_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gprStatusMailing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboMailing;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.GroupBox gprStatusMailing;
        private System.Windows.Forms.Label lblRegistrosCombo;
        private System.Windows.Forms.CheckBox chkListarAtivos;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
    }
}