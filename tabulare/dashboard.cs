using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using controller;
using model.objetos;
using System.Windows.Forms.DataVisualization.Charting;

namespace tabulare
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void CarregarCampanhasAtivas(int iIDUsuario)
        {
            campanhaCTL CCampanha = new campanhaCTL();
            CCampanha.PreencherComboBox_Campanhas(comboCampanha, true, true, false, iIDUsuario, fLogin.Usuario.Perfil);
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            CarregarCampanhasAtivas(fLogin.Usuario.IDUsuario);
            CarregarDashboard(Convert.ToInt32(comboCampanha.SelectedValue));            
        }

        private void CarregarDashboard(int iIDCampanha)
        {
            relatorioCTL CRelatorio = new relatorioCTL();
            DataSet dataSet = CRelatorio.RetornarDashboard(iIDCampanha);

            //Produtividade hoje
            DataTable dataTable = dataSet.Tables[0];

            chartProdutividadeHoje.Series.Clear();
            chartProdutividadeHoje.Series.Add("Status".ToString());
            chartProdutividadeHoje.Series[0].ChartType = SeriesChartType.Pie;
            chartProdutividadeHoje.Series[0].IsValueShownAsLabel = true;
            chartProdutividadeHoje.Legends["Legend1"].Enabled = true;
            chartProdutividadeHoje.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chartProdutividadeHoje.Series[0].Label = "#PERCENT{P0}";
            chartProdutividadeHoje.Series[0].LegendText = "#VALX (#VALY)";

            foreach (DataRow dataRow in dataTable.Rows)
            {
                chartProdutividadeHoje.Series[0].Points.AddXY(dataRow["Status"], Convert.ToInt32(dataRow["Quantidade"]));
            }

            //Produtividade (todos operadores, últimos 10 dias)
            dataTable = dataSet.Tables[1];

            chartProdutividade10dias.Series.Clear();

            chartProdutividade10dias.Series.Add("Vendas".ToString());
            chartProdutividade10dias.Series[0].ChartType = SeriesChartType.StackedColumn;
            chartProdutividade10dias.Series[0].IsValueShownAsLabel = true;

            chartProdutividade10dias.Series.Add("Não Venda".ToString());
            chartProdutividade10dias.Series[1].ChartType = SeriesChartType.StackedColumn;
            chartProdutividade10dias.Series[1].IsValueShownAsLabel = true;

            chartProdutividade10dias.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chartProdutividade10dias.Legends["Legend1"].Enabled = true;
            chartProdutividade10dias.Legends["Legend1"].Docking = Docking.Bottom;
            
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string sData = dataRow["Dia"].ToString() + "/" + dataRow["Mes"].ToString() + "/" + dataRow["Ano"].ToString();
                chartProdutividade10dias.Series[0].Points.AddXY(sData, Convert.ToInt32(dataRow["Vendas"]));
                chartProdutividade10dias.Series[1].Points.AddXY(sData, Convert.ToInt32(dataRow["NaoVenda"]));
            }

            //Contatos realizados por operador (mês atual)
            dataTable = dataSet.Tables[2];

            chartContatosRealizados.Series.Clear();

            chartContatosRealizados.Series.Add("Vendas".ToString());
            chartContatosRealizados.Series[0].ChartType = SeriesChartType.StackedColumn;
            chartContatosRealizados.Series[0].IsValueShownAsLabel = true;

            chartContatosRealizados.Series.Add("Não Venda".ToString());
            chartContatosRealizados.Series[1].ChartType = SeriesChartType.StackedColumn;
            chartContatosRealizados.Series[1].IsValueShownAsLabel = true;

            chartContatosRealizados.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chartContatosRealizados.Legends["Legend1"].Enabled = true;
            chartContatosRealizados.Legends["Legend1"].Docking = Docking.Bottom;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                chartContatosRealizados.Series[0].Points.AddXY(dataRow["Operador"], Convert.ToInt32(dataRow["Vendas"]));
                chartContatosRealizados.Series[1].Points.AddXY(dataRow["Operador"], Convert.ToInt32(dataRow["NaoVenda"]));
            }

            //Status mailing (ativos)
            dataTable = dataSet.Tables[3];

            chartStatusMailing.Series.Clear();
            chartStatusMailing.Series.Add("Status".ToString());
            chartStatusMailing.Series[0].ChartType = SeriesChartType.Pie;
            chartStatusMailing.Series[0].IsValueShownAsLabel = true;
            chartStatusMailing.Legends["Legend1"].Enabled = true;
            chartStatusMailing.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chartStatusMailing.Series[0].Label = "#PERCENT{P0}";
            chartStatusMailing.Series[0].LegendText = "#VALX (#VALY)";

            foreach (DataRow dataRow in dataTable.Rows)
            {
                chartStatusMailing.Series[0].Points.AddXY(dataRow["Status"], Convert.ToInt32(dataRow["Quantidade"]));
            }

            //Vendas (últimos 12 meses)
            dataTable = dataSet.Tables[4];

            chartOperadoresAtivos.Series.Clear();
            chartOperadoresAtivos.Series.Add("Vendas".ToString());
            chartOperadoresAtivos.Series[0].ChartType = SeriesChartType.StackedColumn;
            chartOperadoresAtivos.Series[0].IsValueShownAsLabel = true;
            chartOperadoresAtivos.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                string sMes = dataRow["Mes"].ToString() + "/" + dataRow["Ano"].ToString();
                chartOperadoresAtivos.Series[0].Points.AddXY(sMes, Convert.ToInt32(dataRow["Quantidade"]));
            }
        }

        private void comboCampanha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CarregarDashboard(Convert.ToInt32(comboCampanha.SelectedValue));
        }

        private void cmdAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDashboard(Convert.ToInt32(comboCampanha.SelectedValue));
        }
    }
}
