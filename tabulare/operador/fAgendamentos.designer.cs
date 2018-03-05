namespace tabulare.operador
{
    partial class fAgendamentos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAgendamentos));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgProspects = new System.Windows.Forms.DataGridView();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timerAtualizacao = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblInfoagendamentos = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmdAtualizar = new System.Windows.Forms.Button();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProspects)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.dgProspects);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(7, 124);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(931, 558);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Prospects";
            // 
            // dgProspects
            // 
            this.dgProspects.AllowUserToAddRows = false;
            this.dgProspects.AllowUserToDeleteRows = false;
            this.dgProspects.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgProspects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProspects.BackgroundColor = System.Drawing.Color.White;
            this.dgProspects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgProspects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProspects.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProspects.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgProspects.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgProspects.GridColor = System.Drawing.Color.Cornsilk;
            this.dgProspects.Location = new System.Drawing.Point(10, 20);
            this.dgProspects.MultiSelect = false;
            this.dgProspects.Name = "dgProspects";
            this.dgProspects.ReadOnly = true;
            this.dgProspects.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgProspects.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgProspects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProspects.ShowCellErrors = false;
            this.dgProspects.ShowEditingIcon = false;
            this.dgProspects.ShowRowErrors = false;
            this.dgProspects.Size = new System.Drawing.Size(912, 522);
            this.dgProspects.TabIndex = 16;
            this.dgProspects.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProspects_CellDoubleClick);
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.BackColor = System.Drawing.Color.Transparent;
            this.lblFormulario.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulario.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFormulario.Location = new System.Drawing.Point(511, 11);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(179, 26);
            this.lblFormulario.TabIndex = 13;
            this.lblFormulario.Text = "lblFormulario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 25);
            this.label5.TabIndex = 41;
            this.label5.Text = "AGENDAMENTOS";
            // 
            // timerAtualizacao
            // 
            this.timerAtualizacao.Enabled = true;
            this.timerAtualizacao.Interval = 30000;
            this.timerAtualizacao.Tick += new System.EventHandler(this.timerAtualizacao_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblRegistros);
            this.groupBox1.Controls.Add(this.lblInfoagendamentos);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cmdAtualizar);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Location = new System.Drawing.Point(8, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(930, 73);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(14, 54);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 81;
            // 
            // lblInfoagendamentos
            // 
            this.lblInfoagendamentos.AutoSize = true;
            this.lblInfoagendamentos.Location = new System.Drawing.Point(14, 37);
            this.lblInfoagendamentos.Name = "lblInfoagendamentos";
            this.lblInfoagendamentos.Size = new System.Drawing.Size(179, 13);
            this.lblInfoagendamentos.TabIndex = 80;
            this.lblInfoagendamentos.Text = "Agendamentos atrasados (vencidos)";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(17, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 13);
            this.textBox1.TabIndex = 79;
            // 
            // cmdAtualizar
            // 
            this.cmdAtualizar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAtualizar.FlatAppearance.BorderSize = 0;
            this.cmdAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAtualizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAtualizar.Image = global::v1Tabulare_z13.Properties.Resources.Sync;
            this.cmdAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdAtualizar.Location = new System.Drawing.Point(812, 11);
            this.cmdAtualizar.Name = "cmdAtualizar";
            this.cmdAtualizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdAtualizar.Size = new System.Drawing.Size(109, 25);
            this.cmdAtualizar.TabIndex = 78;
            this.cmdAtualizar.Text = "Atualizar";
            this.cmdAtualizar.UseVisualStyleBackColor = true;
            this.cmdAtualizar.Click += new System.EventHandler(this.cmdAtualizar_Click);
            // 
            // cmdFechar
            // 
            this.cmdFechar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdFechar.FlatAppearance.BorderSize = 0;
            this.cmdFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdFechar.Image = global::v1Tabulare_z13.Properties.Resources.fFechar;
            this.cmdFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdFechar.Location = new System.Drawing.Point(812, 41);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(109, 25);
            this.cmdFechar.TabIndex = 77;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // fAgendamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(959, 701);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox5);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fAgendamentos";
            this.ShowIcon = false;
            this.Text = "Agendamentos";
            this.Load += new System.EventHandler(this.fAgendamentos_Load);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProspects)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgProspects;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timerAtualizacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfoagendamentos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cmdAtualizar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Label lblRegistros;

    }
}