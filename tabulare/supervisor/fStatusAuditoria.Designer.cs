namespace tabulare.supervisor
{
    partial class fStatusAuditoria
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
            this.grpAtivo = new System.Windows.Forms.GroupBox();
            this.radNao = new System.Windows.Forms.RadioButton();
            this.radSim = new System.Windows.Forms.RadioButton();
            this.lblCcliente = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSalvar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTempoExpiracao = new System.Windows.Forms.TextBox();
            this.txtStatusAuditoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDStatusAuditoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDados = new System.Windows.Forms.DataGridView();
            this.grpCampanha = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grpAtivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).BeginInit();
            this.grpCampanha.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpAtivo);
            this.groupBox1.Controls.Add(this.lblCcliente);
            this.groupBox1.Controls.Add(this.lblRegistros);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.cmdCancelar);
            this.groupBox1.Controls.Add(this.cmdSalvar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTempoExpiracao);
            this.groupBox1.Controls.Add(this.txtStatusAuditoria);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIDStatusAuditoria);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 102);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status da Auditoria";
            // 
            // grpAtivo
            // 
            this.grpAtivo.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.grpAtivo.Controls.Add(this.radNao);
            this.grpAtivo.Controls.Add(this.radSim);
            this.grpAtivo.Location = new System.Drawing.Point(466, 14);
            this.grpAtivo.Name = "grpAtivo";
            this.grpAtivo.Size = new System.Drawing.Size(149, 41);
            this.grpAtivo.TabIndex = 156;
            this.grpAtivo.TabStop = false;
            this.grpAtivo.Text = "Ativo";
            // 
            // radNao
            // 
            this.radNao.AutoSize = true;
            this.radNao.Location = new System.Drawing.Point(62, 18);
            this.radNao.Name = "radNao";
            this.radNao.Size = new System.Drawing.Size(45, 17);
            this.radNao.TabIndex = 3;
            this.radNao.Text = "Não";
            this.radNao.UseVisualStyleBackColor = true;
            // 
            // radSim
            // 
            this.radSim.AutoSize = true;
            this.radSim.Location = new System.Drawing.Point(14, 17);
            this.radSim.Name = "radSim";
            this.radSim.Size = new System.Drawing.Size(42, 17);
            this.radSim.TabIndex = 2;
            this.radSim.Text = "Sim";
            this.radSim.UseVisualStyleBackColor = true;
            // 
            // lblCcliente
            // 
            this.lblCcliente.ForeColor = System.Drawing.Color.Blue;
            this.lblCcliente.Location = new System.Drawing.Point(637, 20);
            this.lblCcliente.Name = "lblCcliente";
            this.lblCcliente.Size = new System.Drawing.Size(290, 35);
            this.lblCcliente.TabIndex = 155;
            this.lblCcliente.Text = "Obs.: Caso não queira gerenciar o tempo de expiração do staus, coloque o valor 0." +
    "";
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(163, 21);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 125;
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
            this.cmdFechar.Location = new System.Drawing.Point(334, 67);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(109, 25);
            this.cmdFechar.TabIndex = 123;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCancelar.FlatAppearance.BorderSize = 0;
            this.cmdCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancelar.Image = global::v1Tabulare_z13.Properties.Resources.Abort;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCancelar.Location = new System.Drawing.Point(208, 67);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(109, 25);
            this.cmdCancelar.TabIndex = 73;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSalvar
            // 
            this.cmdSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSalvar.FlatAppearance.BorderSize = 0;
            this.cmdSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalvar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalvar.Image = global::v1Tabulare_z13.Properties.Resources.Salvar1;
            this.cmdSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSalvar.Location = new System.Drawing.Point(82, 67);
            this.cmdSalvar.Name = "cmdSalvar";
            this.cmdSalvar.Size = new System.Drawing.Size(109, 25);
            this.cmdSalvar.TabIndex = 72;
            this.cmdSalvar.Text = "Salvar";
            this.cmdSalvar.UseVisualStyleBackColor = true;
            this.cmdSalvar.Click += new System.EventHandler(this.cmdSalvar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Tempo de Expiração (horas):";
            // 
            // txtTempoExpiracao
            // 
            this.txtTempoExpiracao.BackColor = System.Drawing.Color.White;
            this.txtTempoExpiracao.Location = new System.Drawing.Point(386, 18);
            this.txtTempoExpiracao.MaxLength = 3;
            this.txtTempoExpiracao.Name = "txtTempoExpiracao";
            this.txtTempoExpiracao.Size = new System.Drawing.Size(57, 20);
            this.txtTempoExpiracao.TabIndex = 50;
            this.txtTempoExpiracao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempoExpiracao_KeyPress);
            // 
            // txtStatusAuditoria
            // 
            this.txtStatusAuditoria.BackColor = System.Drawing.Color.White;
            this.txtStatusAuditoria.Location = new System.Drawing.Point(82, 41);
            this.txtStatusAuditoria.Name = "txtStatusAuditoria";
            this.txtStatusAuditoria.ReadOnly = true;
            this.txtStatusAuditoria.Size = new System.Drawing.Size(361, 20);
            this.txtStatusAuditoria.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // txtIDStatusAuditoria
            // 
            this.txtIDStatusAuditoria.BackColor = System.Drawing.Color.White;
            this.txtIDStatusAuditoria.Location = new System.Drawing.Point(82, 18);
            this.txtIDStatusAuditoria.Name = "txtIDStatusAuditoria";
            this.txtIDStatusAuditoria.ReadOnly = true;
            this.txtIDStatusAuditoria.Size = new System.Drawing.Size(80, 20);
            this.txtIDStatusAuditoria.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód.:";
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
            this.dgDados.Location = new System.Drawing.Point(16, 19);
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
            this.dgDados.Size = new System.Drawing.Size(1288, 483);
            this.dgDados.TabIndex = 60;
            this.dgDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDados_CellClick);
            // 
            // grpCampanha
            // 
            this.grpCampanha.Controls.Add(this.dgDados);
            this.grpCampanha.Location = new System.Drawing.Point(12, 108);
            this.grpCampanha.Name = "grpCampanha";
            this.grpCampanha.Size = new System.Drawing.Size(1319, 515);
            this.grpCampanha.TabIndex = 147;
            this.grpCampanha.TabStop = false;
            this.grpCampanha.Text = "Filtro";
            // 
            // fStatusAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 640);
            this.Controls.Add(this.grpCampanha);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fStatusAuditoria";
            this.Text = "Status Auditoria";
            this.Load += new System.EventHandler(this.fStatusAuditoria_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fStatusAuditoria_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAtivo.ResumeLayout(false);
            this.grpAtivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDados)).EndInit();
            this.grpCampanha.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStatusAuditoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDStatusAuditoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTempoExpiracao;
        private System.Windows.Forms.Button cmdSalvar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grpCampanha;
        private System.Windows.Forms.Label lblCcliente;
        private System.Windows.Forms.GroupBox grpAtivo;
        private System.Windows.Forms.RadioButton radNao;
        private System.Windows.Forms.RadioButton radSim;
    }
}