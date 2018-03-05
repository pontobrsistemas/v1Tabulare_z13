namespace tabulare.supervisor
{
    partial class fStatus
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
            this.lblRegistros = new System.Windows.Forms.Label();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.cmdSalvar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoraRetorno = new System.Windows.Forms.MaskedTextBox();
            this.comboAcao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpAtivo = new System.Windows.Forms.GroupBox();
            this.radNao = new System.Windows.Forms.RadioButton();
            this.radSim = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQtdeTentativas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDStatus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgStatus = new System.Windows.Forms.DataGridView();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grpAtivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRegistros);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.cmdCancelar);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.cmdSalvar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtHoraRetorno);
            this.groupBox1.Controls.Add(this.comboAcao);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.grpAtivo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtQtdeTentativas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIDStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 127);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status (Resultado do Contato)";
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(511, 26);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(0, 13);
            this.lblRegistros.TabIndex = 129;
            this.lblRegistros.Tag = "l";
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
            this.cmdFechar.Location = new System.Drawing.Point(372, 95);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(109, 25);
            this.cmdFechar.TabIndex = 128;
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
            this.cmdCancelar.Location = new System.Drawing.Point(240, 95);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(109, 25);
            this.cmdCancelar.TabIndex = 77;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // comboCampanha
            // 
            this.comboCampanha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(108, 20);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(373, 21);
            this.comboCampanha.TabIndex = 102;
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
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
            this.cmdSalvar.Location = new System.Drawing.Point(108, 95);
            this.cmdSalvar.Name = "cmdSalvar";
            this.cmdSalvar.Size = new System.Drawing.Size(109, 25);
            this.cmdSalvar.TabIndex = 76;
            this.cmdSalvar.Text = "Salvar";
            this.cmdSalvar.UseVisualStyleBackColor = true;
            this.cmdSalvar.Click += new System.EventHandler(this.cmdSalvar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(45, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "Campanha:";
            // 
            // txtHoraRetorno
            // 
            this.txtHoraRetorno.Enabled = false;
            this.txtHoraRetorno.Location = new System.Drawing.Point(529, 70);
            this.txtHoraRetorno.Mask = "00:00";
            this.txtHoraRetorno.Name = "txtHoraRetorno";
            this.txtHoraRetorno.Size = new System.Drawing.Size(53, 20);
            this.txtHoraRetorno.TabIndex = 101;
            this.txtHoraRetorno.ValidatingType = typeof(System.DateTime);
            // 
            // comboAcao
            // 
            this.comboAcao.Enabled = false;
            this.comboAcao.FormattingEnabled = true;
            this.comboAcao.Location = new System.Drawing.Point(244, 69);
            this.comboAcao.Name = "comboAcao";
            this.comboAcao.Size = new System.Drawing.Size(189, 21);
            this.comboAcao.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Ação:";
            // 
            // grpAtivo
            // 
            this.grpAtivo.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.grpAtivo.Controls.Add(this.radNao);
            this.grpAtivo.Controls.Add(this.radSim);
            this.grpAtivo.Location = new System.Drawing.Point(645, 49);
            this.grpAtivo.Name = "grpAtivo";
            this.grpAtivo.Size = new System.Drawing.Size(124, 41);
            this.grpAtivo.TabIndex = 48;
            this.grpAtivo.TabStop = false;
            this.grpAtivo.Text = "Ativo";
            // 
            // radNao
            // 
            this.radNao.AutoSize = true;
            this.radNao.Enabled = false;
            this.radNao.Location = new System.Drawing.Point(62, 18);
            this.radNao.Name = "radNao";
            this.radNao.Size = new System.Drawing.Size(45, 17);
            this.radNao.TabIndex = 6;
            this.radNao.Text = "Não";
            this.radNao.UseVisualStyleBackColor = true;
            // 
            // radSim
            // 
            this.radSim.AutoSize = true;
            this.radSim.Enabled = false;
            this.radSim.Location = new System.Drawing.Point(14, 17);
            this.radSim.Name = "radSim";
            this.radSim.Size = new System.Drawing.Size(42, 17);
            this.radSim.TabIndex = 5;
            this.radSim.Text = "Sim";
            this.radSim.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tempo Retorno:";
            // 
            // txtQtdeTentativas
            // 
            this.txtQtdeTentativas.Enabled = false;
            this.txtQtdeTentativas.Location = new System.Drawing.Point(108, 69);
            this.txtQtdeTentativas.MaxLength = 2;
            this.txtQtdeTentativas.Name = "txtQtdeTentativas";
            this.txtQtdeTentativas.Size = new System.Drawing.Size(67, 20);
            this.txtQtdeTentativas.TabIndex = 2;
            this.txtQtdeTentativas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtdeTentativas_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quant. Tentativas:";
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(108, 45);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(475, 20);
            this.txtStatus.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // txtIDStatus
            // 
            this.txtIDStatus.Location = new System.Drawing.Point(669, 21);
            this.txtIDStatus.Name = "txtIDStatus";
            this.txtIDStatus.ReadOnly = true;
            this.txtIDStatus.Size = new System.Drawing.Size(100, 20);
            this.txtIDStatus.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód.:";
            // 
            // dgStatus
            // 
            this.dgStatus.AllowUserToAddRows = false;
            this.dgStatus.AllowUserToDeleteRows = false;
            this.dgStatus.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgStatus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStatus.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgStatus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgStatus.Location = new System.Drawing.Point(15, 19);
            this.dgStatus.MultiSelect = false;
            this.dgStatus.Name = "dgStatus";
            this.dgStatus.ReadOnly = true;
            this.dgStatus.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgStatus.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStatus.ShowCellErrors = false;
            this.dgStatus.ShowEditingIcon = false;
            this.dgStatus.ShowRowErrors = false;
            this.dgStatus.Size = new System.Drawing.Size(1288, 490);
            this.dgStatus.TabIndex = 18;
            this.dgStatus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStatus_CellClick);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgStatus);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1319, 527);
            this.groupBox2.TabIndex = 130;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro";
            // 
            // fStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 672);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "fStatus";
            this.ShowIcon = false;
            this.Text = "Status (Resultado do Contato)";
            this.Load += new System.EventHandler(this.fStatus_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fStatus_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpAtivo.ResumeLayout(false);
            this.grpAtivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStatus)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboAcao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpAtivo;
        private System.Windows.Forms.RadioButton radNao;
        private System.Windows.Forms.RadioButton radSim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQtdeTentativas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgStatus;
        private System.Windows.Forms.MaskedTextBox txtHoraRetorno;
        protected System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdSalvar;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}