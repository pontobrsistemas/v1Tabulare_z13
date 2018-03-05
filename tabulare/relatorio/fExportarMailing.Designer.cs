namespace tabulare.relatorio
{
    partial class fExportarMailing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdDesmarcar = new System.Windows.Forms.Button();
            this.cmdMarcar = new System.Windows.Forms.Button();
            this.chlStatus = new System.Windows.Forms.CheckedListBox();
            this.lblRegistrosCombo = new System.Windows.Forms.Label();
            this.chkListarAtivos = new System.Windows.Forms.CheckBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmdExportar = new System.Windows.Forms.Button();
            this.cmdGerar = new System.Windows.Forms.Button();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMailing = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.grpExportarMailing = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.grpExportarMailing.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmdDesmarcar);
            this.groupBox1.Controls.Add(this.cmdMarcar);
            this.groupBox1.Controls.Add(this.chlStatus);
            this.groupBox1.Controls.Add(this.lblRegistrosCombo);
            this.groupBox1.Controls.Add(this.chkListarAtivos);
            this.groupBox1.Controls.Add(this.lblRegistros);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.cmdExportar);
            this.groupBox1.Controls.Add(this.cmdGerar);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboMailing);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 177);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro do Relatório";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(693, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 151;
            this.label7.Text = "Status da Ligação:";
            // 
            // cmdDesmarcar
            // 
            this.cmdDesmarcar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDesmarcar.Image = global::v1Tabulare_z13.Properties.Resources.DTodos;
            this.cmdDesmarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdDesmarcar.Location = new System.Drawing.Point(905, 145);
            this.cmdDesmarcar.Name = "cmdDesmarcar";
            this.cmdDesmarcar.Size = new System.Drawing.Size(111, 26);
            this.cmdDesmarcar.TabIndex = 150;
            this.cmdDesmarcar.Text = "Nenhum";
            this.cmdDesmarcar.UseVisualStyleBackColor = true;
            this.cmdDesmarcar.Click += new System.EventHandler(this.cmdDesmarcar_Click);
            // 
            // cmdMarcar
            // 
            this.cmdMarcar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMarcar.Image = global::v1Tabulare_z13.Properties.Resources.STodos;
            this.cmdMarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdMarcar.Location = new System.Drawing.Point(696, 145);
            this.cmdMarcar.Name = "cmdMarcar";
            this.cmdMarcar.Size = new System.Drawing.Size(112, 26);
            this.cmdMarcar.TabIndex = 149;
            this.cmdMarcar.Text = "Todos";
            this.cmdMarcar.UseVisualStyleBackColor = true;
            this.cmdMarcar.Click += new System.EventHandler(this.cmdMarcar_Click);
            // 
            // chlStatus
            // 
            this.chlStatus.CheckOnClick = true;
            this.chlStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chlStatus.FormattingEnabled = true;
            this.chlStatus.Location = new System.Drawing.Point(696, 31);
            this.chlStatus.Name = "chlStatus";
            this.chlStatus.Size = new System.Drawing.Size(320, 108);
            this.chlStatus.TabIndex = 148;
            // 
            // lblRegistrosCombo
            // 
            this.lblRegistrosCombo.AutoSize = true;
            this.lblRegistrosCombo.Location = new System.Drawing.Point(514, 26);
            this.lblRegistrosCombo.Name = "lblRegistrosCombo";
            this.lblRegistrosCombo.Size = new System.Drawing.Size(0, 13);
            this.lblRegistrosCombo.TabIndex = 147;
            // 
            // chkListarAtivos
            // 
            this.chkListarAtivos.AutoSize = true;
            this.chkListarAtivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListarAtivos.Location = new System.Drawing.Point(513, 53);
            this.chkListarAtivos.Name = "chkListarAtivos";
            this.chkListarAtivos.Size = new System.Drawing.Size(133, 17);
            this.chkListarAtivos.TabIndex = 146;
            this.chkListarAtivos.Text = "Listar mailings inativos.";
            this.chkListarAtivos.UseVisualStyleBackColor = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(84, 71);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 140;
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
            this.cmdFechar.Location = new System.Drawing.Point(318, 98);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(110, 28);
            this.cmdFechar.TabIndex = 139;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
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
            this.cmdExportar.Location = new System.Drawing.Point(203, 98);
            this.cmdExportar.Name = "cmdExportar";
            this.cmdExportar.Size = new System.Drawing.Size(109, 28);
            this.cmdExportar.TabIndex = 129;
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
            this.cmdGerar.Location = new System.Drawing.Point(87, 98);
            this.cmdGerar.Name = "cmdGerar";
            this.cmdGerar.Size = new System.Drawing.Size(110, 28);
            this.cmdGerar.TabIndex = 128;
            this.cmdGerar.Text = "Gerar dados";
            this.cmdGerar.UseVisualStyleBackColor = true;
            this.cmdGerar.Click += new System.EventHandler(this.cmdGerar_Click);
            // 
            // comboCampanha
            // 
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(85, 19);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(422, 21);
            this.comboCampanha.TabIndex = 48;
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Campanha:";
            // 
            // comboMailing
            // 
            this.comboMailing.FormattingEnabled = true;
            this.comboMailing.Location = new System.Drawing.Point(85, 47);
            this.comboMailing.Name = "comboMailing";
            this.comboMailing.Size = new System.Drawing.Size(422, 21);
            this.comboMailing.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Mailing:";
            // 
            // dgDados
            // 
            this.dgDados.AllowUserToAddRows = false;
            this.dgDados.AllowUserToDeleteRows = false;
            this.dgDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgDados.BackgroundColor = System.Drawing.Color.White;
            this.dgDados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDados.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDados.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgDados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDados.Location = new System.Drawing.Point(15, 19);
            this.dgDados.MultiSelect = false;
            this.dgDados.Name = "dgDados";
            this.dgDados.ReadOnly = true;
            this.dgDados.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgDados.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDados.ShowCellErrors = false;
            this.dgDados.ShowEditingIcon = false;
            this.dgDados.ShowRowErrors = false;
            this.dgDados.Size = new System.Drawing.Size(1290, 419);
            this.dgDados.TabIndex = 70;
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
            // grpExportarMailing
            // 
            this.grpExportarMailing.Controls.Add(this.dgDados);
            this.grpExportarMailing.Location = new System.Drawing.Point(12, 185);
            this.grpExportarMailing.Name = "grpExportarMailing";
            this.grpExportarMailing.Size = new System.Drawing.Size(1319, 444);
            this.grpExportarMailing.TabIndex = 149;
            this.grpExportarMailing.TabStop = false;
            this.grpExportarMailing.Text = "Filtro";
            // 
            // fExportarMailing
            // 
            this.AcceptButton = this.cmdGerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 672);
            this.Controls.Add(this.grpExportarMailing);
            this.Controls.Add(this.groupBox1);
            this.Name = "fExportarMailing";
            this.ShowIcon = false;
            this.Text = "Exportar Mailing";
            this.Load += new System.EventHandler(this.fContatosTrabalhados_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fExportarMailing_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.grpExportarMailing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboMailing;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Button cmdExportar;
        private System.Windows.Forms.Button cmdGerar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.GroupBox grpExportarMailing;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox chkListarAtivos;
        private System.Windows.Forms.Label lblRegistrosCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdDesmarcar;
        private System.Windows.Forms.Button cmdMarcar;
        private System.Windows.Forms.CheckedListBox chlStatus;
    }
}