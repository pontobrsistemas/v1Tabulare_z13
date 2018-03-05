namespace tabulare.supervisor
{
    partial class fMailingIndicacao
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
            this.lblCcliente = new System.Windows.Forms.Label();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSalvar = new System.Windows.Forms.Button();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMailing = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCcliente);
            this.groupBox1.Controls.Add(this.cmdFechar);
            this.groupBox1.Controls.Add(this.cmdCancelar);
            this.groupBox1.Controls.Add(this.cmdSalvar);
            this.groupBox1.Controls.Add(this.comboCampanha);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboMailing);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 128);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mailing Indicação";
            // 
            // lblCcliente
            // 
            this.lblCcliente.ForeColor = System.Drawing.Color.Blue;
            this.lblCcliente.Location = new System.Drawing.Point(580, 30);
            this.lblCcliente.Name = "lblCcliente";
            this.lblCcliente.Size = new System.Drawing.Size(544, 34);
            this.lblCcliente.TabIndex = 153;
            this.lblCcliente.Text = "Obs.: Caso não seja selecionado NENHUM para ser o \"Mailing Indicação\" da Campanha" +
    ", a indicação cadastrada pelo operador será salva no último mailing importado.";
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
            this.cmdFechar.Location = new System.Drawing.Point(317, 90);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(109, 25);
            this.cmdFechar.TabIndex = 126;
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
            this.cmdCancelar.Location = new System.Drawing.Point(202, 90);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(109, 25);
            this.cmdCancelar.TabIndex = 125;
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
            this.cmdSalvar.Location = new System.Drawing.Point(87, 90);
            this.cmdSalvar.Name = "cmdSalvar";
            this.cmdSalvar.Size = new System.Drawing.Size(109, 25);
            this.cmdSalvar.TabIndex = 124;
            this.cmdSalvar.Text = "Salvar";
            this.cmdSalvar.UseVisualStyleBackColor = true;
            this.cmdSalvar.Click += new System.EventHandler(this.cmdSalvar_Click);
            // 
            // comboCampanha
            // 
            this.comboCampanha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(87, 30);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(422, 21);
            this.comboCampanha.TabIndex = 48;
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Campanha:";
            // 
            // comboMailing
            // 
            this.comboMailing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMailing.FormattingEnabled = true;
            this.comboMailing.Location = new System.Drawing.Point(87, 61);
            this.comboMailing.Name = "comboMailing";
            this.comboMailing.Size = new System.Drawing.Size(422, 21);
            this.comboMailing.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Mailing:";
            // 
            // fMailingIndicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 604);
            this.Controls.Add(this.groupBox1);
            this.Name = "fMailingIndicacao";
            this.Text = "fMailingIndicacao";
            this.Load += new System.EventHandler(this.fMailingIndicacao_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fMailingIndicacao_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboMailing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdSalvar;
        private System.Windows.Forms.Label lblCcliente;
    }
}