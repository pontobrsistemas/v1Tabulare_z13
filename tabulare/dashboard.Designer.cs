namespace tabulare
{
    partial class dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.cmdAtualizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartProdutividadeHoje = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartProdutividade10dias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chartContatosRealizados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chartOperadoresAtivos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chartStatusMailing = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboCampanha = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProdutividadeHoje)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProdutividade10dias)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartContatosRealizados)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOperadoresAtivos)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatusMailing)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAtualizar
            // 
            this.cmdAtualizar.Location = new System.Drawing.Point(504, 11);
            this.cmdAtualizar.Name = "cmdAtualizar";
            this.cmdAtualizar.Size = new System.Drawing.Size(75, 23);
            this.cmdAtualizar.TabIndex = 0;
            this.cmdAtualizar.Text = "Atualizar";
            this.cmdAtualizar.UseVisualStyleBackColor = true;
            this.cmdAtualizar.Click += new System.EventHandler(this.cmdAtualizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartProdutividadeHoje);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 312);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produtividade hoje (Resultado do contato)";
            // 
            // chartProdutividadeHoje
            // 
            chartArea1.Name = "ChartArea1";
            this.chartProdutividadeHoje.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProdutividadeHoje.Legends.Add(legend1);
            this.chartProdutividadeHoje.Location = new System.Drawing.Point(7, 18);
            this.chartProdutividadeHoje.Name = "chartProdutividadeHoje";
            this.chartProdutividadeHoje.Size = new System.Drawing.Size(529, 285);
            this.chartProdutividadeHoje.TabIndex = 185;
            this.chartProdutividadeHoje.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chartProdutividade10dias);
            this.groupBox2.Location = new System.Drawing.Point(566, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 312);
            this.groupBox2.TabIndex = 186;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produtividade (todos operadores, últimos 10 dias)";
            // 
            // chartProdutividade10dias
            // 
            chartArea2.Name = "ChartArea1";
            this.chartProdutividade10dias.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartProdutividade10dias.Legends.Add(legend2);
            this.chartProdutividade10dias.Location = new System.Drawing.Point(7, 18);
            this.chartProdutividade10dias.Name = "chartProdutividade10dias";
            this.chartProdutividade10dias.Size = new System.Drawing.Size(529, 285);
            this.chartProdutividade10dias.TabIndex = 185;
            this.chartProdutividade10dias.Text = "chart1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chartContatosRealizados);
            this.groupBox4.Location = new System.Drawing.Point(1118, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(545, 312);
            this.groupBox4.TabIndex = 187;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contatos realizados por operador (mês atual, top 10)";
            // 
            // chartContatosRealizados
            // 
            chartArea3.Name = "ChartArea1";
            this.chartContatosRealizados.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartContatosRealizados.Legends.Add(legend3);
            this.chartContatosRealizados.Location = new System.Drawing.Point(7, 18);
            this.chartContatosRealizados.Name = "chartContatosRealizados";
            this.chartContatosRealizados.Size = new System.Drawing.Size(529, 285);
            this.chartContatosRealizados.TabIndex = 185;
            this.chartContatosRealizados.Text = "chart1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chartOperadoresAtivos);
            this.groupBox5.Location = new System.Drawing.Point(566, 356);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(545, 312);
            this.groupBox5.TabIndex = 190;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Vendas (últimos 12 meses)";
            // 
            // chartOperadoresAtivos
            // 
            chartArea4.Name = "ChartArea1";
            this.chartOperadoresAtivos.ChartAreas.Add(chartArea4);
            this.chartOperadoresAtivos.Location = new System.Drawing.Point(7, 18);
            this.chartOperadoresAtivos.Name = "chartOperadoresAtivos";
            this.chartOperadoresAtivos.Size = new System.Drawing.Size(529, 285);
            this.chartOperadoresAtivos.TabIndex = 185;
            this.chartOperadoresAtivos.Text = "chart4";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chartStatusMailing);
            this.groupBox6.Location = new System.Drawing.Point(12, 356);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(545, 312);
            this.groupBox6.TabIndex = 189;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Status mailing (ativos)";
            // 
            // chartStatusMailing
            // 
            chartArea5.Name = "ChartArea1";
            this.chartStatusMailing.ChartAreas.Add(chartArea5);
            legend4.Name = "Legend1";
            this.chartStatusMailing.Legends.Add(legend4);
            this.chartStatusMailing.Location = new System.Drawing.Point(7, 18);
            this.chartStatusMailing.Name = "chartStatusMailing";
            this.chartStatusMailing.Size = new System.Drawing.Size(529, 285);
            this.chartStatusMailing.TabIndex = 185;
            this.chartStatusMailing.Text = "chart1";
            // 
            // comboCampanha
            // 
            this.comboCampanha.FormattingEnabled = true;
            this.comboCampanha.Location = new System.Drawing.Point(76, 11);
            this.comboCampanha.Name = "comboCampanha";
            this.comboCampanha.Size = new System.Drawing.Size(422, 21);
            this.comboCampanha.TabIndex = 192;
            this.comboCampanha.SelectionChangeCommitted += new System.EventHandler(this.comboCampanha_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 191;
            this.label6.Text = "Campanha:";
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1356, 687);
            this.ControlBox = false;
            this.Controls.Add(this.comboCampanha);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdAtualizar);
            this.Name = "dashboard";
            this.Text = "Tabulare - Dashboard";
            this.Load += new System.EventHandler(this.dashboard_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProdutividadeHoje)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProdutividade10dias)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartContatosRealizados)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartOperadoresAtivos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStatusMailing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAtualizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProdutividadeHoje;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProdutividade10dias;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartContatosRealizados;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOperadoresAtivos;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatusMailing;
        private System.Windows.Forms.ComboBox comboCampanha;
        private System.Windows.Forms.Label label6;
    }
}