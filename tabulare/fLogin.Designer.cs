namespace tabulare
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLicenca = new System.Windows.Forms.Label();
            this.lblVersaoFramework = new System.Windows.Forms.Label();
            this.lblAgent = new System.Windows.Forms.Label();
            this.txtAgent = new System.Windows.Forms.TextBox();
            this.cmdEntrar = new System.Windows.Forms.Button();
            this.cmdSair = new System.Windows.Forms.Button();
            this.lblRamal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRamal = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.lblLicenca);
            this.groupBox1.Controls.Add(this.lblVersaoFramework);
            this.groupBox1.Controls.Add(this.lblAgent);
            this.groupBox1.Controls.Add(this.txtAgent);
            this.groupBox1.Controls.Add(this.cmdEntrar);
            this.groupBox1.Controls.Add(this.cmdSair);
            this.groupBox1.Controls.Add(this.lblRamal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRamal);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 242);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrar";
            // 
            // lblLicenca
            // 
            this.lblLicenca.AutoSize = true;
            this.lblLicenca.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenca.ForeColor = System.Drawing.Color.Black;
            this.lblLicenca.Location = new System.Drawing.Point(66, 221);
            this.lblLicenca.Name = "lblLicenca";
            this.lblLicenca.Size = new System.Drawing.Size(148, 13);
            this.lblLicenca.TabIndex = 99;
            this.lblLicenca.Text = "Licenciado para 0 operadores";
            // 
            // lblVersaoFramework
            // 
            this.lblVersaoFramework.AutoSize = true;
            this.lblVersaoFramework.BackColor = System.Drawing.Color.Transparent;
            this.lblVersaoFramework.ForeColor = System.Drawing.Color.Black;
            this.lblVersaoFramework.Location = new System.Drawing.Point(145, 208);
            this.lblVersaoFramework.Name = "lblVersaoFramework";
            this.lblVersaoFramework.Size = new System.Drawing.Size(92, 13);
            this.lblVersaoFramework.TabIndex = 90;
            this.lblVersaoFramework.Text = "VersaoFramework";
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.BackColor = System.Drawing.Color.Transparent;
            this.lblAgent.ForeColor = System.Drawing.Color.Black;
            this.lblAgent.Location = new System.Drawing.Point(59, 136);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(101, 13);
            this.lblAgent.TabIndex = 98;
            this.lblAgent.Text = "Agent (PlanetFone):";
            this.lblAgent.Visible = false;
            // 
            // txtAgent
            // 
            this.txtAgent.Location = new System.Drawing.Point(61, 152);
            this.txtAgent.MaxLength = 50;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(160, 20);
            this.txtAgent.TabIndex = 92;
            this.txtAgent.Visible = false;
            // 
            // cmdEntrar
            // 
            this.cmdEntrar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdEntrar.FlatAppearance.BorderSize = 0;
            this.cmdEntrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEntrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEntrar.Image = global::v1Tabulare_z13.Properties.Resources.EntrarSistema;
            this.cmdEntrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdEntrar.Location = new System.Drawing.Point(62, 146);
            this.cmdEntrar.Name = "cmdEntrar";
            this.cmdEntrar.Size = new System.Drawing.Size(73, 25);
            this.cmdEntrar.TabIndex = 94;
            this.cmdEntrar.Text = "Entrar";
            this.cmdEntrar.UseVisualStyleBackColor = true;
            this.cmdEntrar.Click += new System.EventHandler(this.cmdEntrar_Click);
            // 
            // cmdSair
            // 
            this.cmdSair.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSair.FlatAppearance.BorderSize = 0;
            this.cmdSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.cmdSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSair.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSair.Image = global::v1Tabulare_z13.Properties.Resources.Exit;
            this.cmdSair.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSair.Location = new System.Drawing.Point(148, 146);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(73, 26);
            this.cmdSair.TabIndex = 95;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // lblRamal
            // 
            this.lblRamal.AutoSize = true;
            this.lblRamal.BackColor = System.Drawing.Color.Transparent;
            this.lblRamal.ForeColor = System.Drawing.Color.Black;
            this.lblRamal.Location = new System.Drawing.Point(59, 97);
            this.lblRamal.Name = "lblRamal";
            this.lblRamal.Size = new System.Drawing.Size(40, 13);
            this.lblRamal.TabIndex = 96;
            this.lblRamal.Text = "Ramal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(58, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "Senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(58, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Login:";
            // 
            // txtRamal
            // 
            this.txtRamal.Location = new System.Drawing.Point(61, 113);
            this.txtRamal.MaxLength = 5;
            this.txtRamal.Name = "txtRamal";
            this.txtRamal.Size = new System.Drawing.Size(160, 20);
            this.txtRamal.TabIndex = 91;
            this.txtRamal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRamal_KeyPress);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(61, 74);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(160, 20);
            this.txtSenha.TabIndex = 90;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(60, 32);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(160, 20);
            this.txtLogin.TabIndex = 89;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(90, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PontoBR Sistemas - Tabulare Software";
            // 
            // fLogin
            // 
            this.AcceptButton = this.cmdEntrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 362);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.fLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.TextBox txtAgent;
        private System.Windows.Forms.Button cmdEntrar;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.Label lblRamal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRamal;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblVersaoFramework;
        private System.Windows.Forms.Label lblLicenca;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}

