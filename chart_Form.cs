using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace teamProject_00
{
    public partial class chart_Form : Form
    {
        public chart_Form()
        {
            InitializeComponent();
            DrawPieChart(1, 2, 3, 4, 5, 6);
        }
         
        private void DrawPieChart(int value1, int value2, int value3, int value4, int value5, int value6)
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            chart1.Legends.Add("MyLegend");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "Title";
            chart1.Legends[0].BorderColor = Color.Black;

            string seriesname = "MySeriesName";
            chart1.Series.Add(seriesname);

            chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

            chart1.Series[seriesname].Points.AddXY("Example1", value1);
            chart1.Series[seriesname].Points.AddXY("Example2", value2);
            chart1.Series[seriesname].Points.AddXY("Example3", value3);
            chart1.Series[seriesname].Points.AddXY("Example4", value4);
            chart1.Series[seriesname].Points.AddXY("Example5", value5);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

        }
    }
}
