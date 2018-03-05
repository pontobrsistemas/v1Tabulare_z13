namespace tabulare
{
    partial class fOperador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOperador));
            this.tlpPadrao = new System.Windows.Forms.ToolTip(this.components);
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerTratamentoVenda = new System.Windows.Forms.Timer(this.components);
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblModulo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInformacoes = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.pnlTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPadrao
            // 
            this.tlpPadrao.IsBalloon = true;
            // 
            // picLogin
            // 
            this.picLogin.BackColor = System.Drawing.Color.Transparent;
            this.picLogin.Image = global::v1Tabulare_z13.Properties.Resources.key;
            this.picLogin.Location = new System.Drawing.Point(11, 56);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(19, 17);
            this.picLogin.TabIndex = 16;
            this.picLogin.TabStop = false;
            this.tlpPadrao.SetToolTip(this.picLogin, "Clique aqui pra trocar sua senha");
            this.picLogin.Click += new System.EventHandler(this.picLogin_Click);
            // 
            // cmdFechar
            // 
            this.cmdFechar.BackColor = System.Drawing.Color.Transparent;
            this.cmdFechar.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdFechar.FlatAppearance.BorderSize = 0;
            this.cmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFechar.ForeColor = System.Drawing.Color.Transparent;
            this.cmdFechar.Image = ((System.Drawing.Image)(resources.GetObject("cmdFechar.Image")));
            this.cmdFechar.Location = new System.Drawing.Point(1002, 0);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(49, 81);
            this.cmdFechar.TabIndex = 3;
            this.tlpPadrao.SetToolTip(this.cmdFechar, "Fechar");
            this.cmdFechar.UseVisualStyleBackColor = false;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerTratamentoVenda
            // 
            this.timerTratamentoVenda.Interval = 10000;
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.White;
            this.pnlTopo.BackgroundImage = global::v1Tabulare_z13.Properties.Resources.form42;
            this.pnlTopo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTopo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopo.Controls.Add(this.pictureBox3);
            this.pnlTopo.Controls.Add(this.lblModulo);
            this.pnlTopo.Controls.Add(this.label4);
            this.pnlTopo.Controls.Add(this.picLogin);
            this.pnlTopo.Controls.Add(this.lblLogin);
            this.pnlTopo.Controls.Add(this.label2);
            this.pnlTopo.Controls.Add(this.label1);
            this.pnlTopo.Controls.Add(this.pictureBox2);
            this.pnlTopo.Controls.Add(this.pictureBox1);
            this.pnlTopo.Controls.Add(this.cmdFechar);
            this.pnlTopo.Controls.Add(this.lblInformacoes);
            this.pnlTopo.Controls.Add(this.lblUsuario);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(3, 3);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(1053, 83);
            this.pnlTopo.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Image = global::v1Tabulare_z13.Properties.Resources.Logo_PontoBR;
            this.pictureBox3.Location = new System.Drawing.Point(819, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Padding = new System.Windows.Forms.Padding(3);
            this.pictureBox3.Size = new System.Drawing.Size(183, 81);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.BackColor = System.Drawing.Color.Transparent;
            this.lblModulo.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulo.ForeColor = System.Drawing.Color.Black;
            this.lblModulo.Location = new System.Drawing.Point(3, 0);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(232, 35);
            this.lblModulo.TabIndex = 8;
            this.lblModulo.Text = "Módulo Operador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(38, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "LOGIN:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(82, 59);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(50, 13);
            this.lblLogin.TabIndex = 15;
            this.lblLogin.Text = "lblLogin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(278, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "RAMAL:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "USUÁRIO:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::v1Tabulare_z13.Properties.Resources.telephone;
            this.pictureBox2.Location = new System.Drawing.Point(259, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 17);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::v1Tabulare_z13.Properties.Resources.users;
            this.pictureBox1.Location = new System.Drawing.Point(11, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 17);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblInformacoes
            // 
            this.lblInformacoes.AutoSize = true;
            this.lblInformacoes.BackColor = System.Drawing.Color.Transparent;
            this.lblInformacoes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformacoes.ForeColor = System.Drawing.Color.Black;
            this.lblInformacoes.Location = new System.Drawing.Point(328, 57);
            this.lblInformacoes.Name = "lblInformacoes";
            this.lblInformacoes.Size = new System.Drawing.Size(92, 13);
            this.lblInformacoes.TabIndex = 4;
            this.lblInformacoes.Text = "lblInformacoes";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblUsuario.Location = new System.Drawing.Point(101, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(63, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // fOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 684);
            this.Controls.Add(this.pnlTopo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(850, 0);
            this.Name = "fOperador";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Módulo Operador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fOperador_FormClosing);
            this.Load += new System.EventHandler(this.fOperador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.pnlTopo.ResumeLayout(false);
            this.pnlTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolTip tlpPadrao;
        protected System.Windows.Forms.Label lblUsuario;
        protected System.Windows.Forms.Label lblInformacoes;
        private System.Windows.Forms.Button cmdFechar;
        protected System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.PictureBox picLogin;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timerTratamentoVenda;
        private System.Windows.Forms.ImageList imageList1;
    }
}