using PacketClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace teamProject_00
{
    public partial class chart_Form : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;
        private byte[] readBuffer = new byte[1024 * 4];
        private List<FinancialData> financialDataList;

        public chart_Form(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;
            this.financialDataList = new List<FinancialData>();

            LoadDataAsync();

            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_Form_Paint);
        }

        private async void LoadDataAsync()
        {
            await RequestFinancialData(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
        }

        Dictionary<string, float> expense = new Dictionary<string, float>
        {
            {"식비",300.0f },
            {"교통비",150.0f },
            {"주거비",500.0f },
            {"여가비",100.0f }
        };

        public class FinancialData
        {
            public string Type { get; set; }
            public string CategoryName { get; set; }
            public decimal Amount { get; set; }
        }

        private async Task RequestFinancialData(string date)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.재정데이터요청;
            requestPacket.message.Add(this.userId + "," + date);

            byte[] serializedData = Packet.Serialize(requestPacket);
            await this.m_networkStream.WriteAsync(serializedData, 0, serializedData.Length);
            await this.m_networkStream.FlushAsync();

            await ReceiveFinancialDataResponse();
        }
        private async Task ReceiveFinancialDataResponse()
        {
            int bytesRead = await this.m_networkStream.ReadAsync(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);
                if ((PacketType)responsePacket.type == PacketType.재정데이터요청)
                {
                    string financialDataMessage = string.Join(",", responsePacket.message);
                    ParseFinancialData(financialDataMessage);
                    UpdateChart();
                }
            }
        }

        private void ParseFinancialData(string financialDataMessage)
        {
            financialDataList.Clear();
            string[] dataEntries = financialDataMessage.Split(new[] { ',' });

            foreach (string entry in dataEntries)
            {
                string[] parts = entry.Split(':');
                if (parts.Length == 3)
                {
                    string type = parts[0];
                    string categoryName = parts[1];
                    decimal amount;
                    if (decimal.TryParse(parts[2], out amount))
                        financialDataList.Add(new FinancialData { Type = type, CategoryName = categoryName, Amount = amount });
                }
            }
        }

        private void UpdateChart()
        {
            if (rdo_in.Checked)
                DisplayPieChart("income");
            else if (rdo_out.Checked)
                DisplayPieChart("expense");
            else if (rdo_all.Checked)
                DisplayPieChart("all");

        }

        private void DisplayPieChart(string filter)
        {
            var chartData = new Dictionary<string, decimal>();
            foreach (var data in financialDataList)
            {
                if (filter == "all" || data.Type == filter)
                {
                    string categoryName = data.CategoryName;
                    if (!chartData.ContainsKey(categoryName))
                    {
                        chartData[categoryName] = 0;
                    }
                    chartData[categoryName] += data.Amount;
                }
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.chart1.Series.Clear();
                }));
            }
            else
                this.chart1.Series.Clear();




            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    if (chart1.Series.IndexOf("FinancialData") != -1)
                    {
                        chart1.Series.Remove(chart1.Series["FinancialData"]);
                    }

                    var series = new System.Windows.Forms.DataVisualization.Charting.Series
                    {
                        Name = "FinancialData",
                        IsVisibleInLegend = true,
                        ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
                    };

                    chart1.Series.Add(series);

                    foreach (var entry in chartData)
                    {
                        series.Points.AddXY(entry.Key, entry.Value);

                    }
                    chart1.Invalidate();
                }));
            }

            else
            {
                // 동일한 이름의 시리즈가 이미 존재하는지 확인하고 제거
                if (chart1.Series.IndexOf("FinancialData") != -1)
                {
                    chart1.Series.Remove(chart1.Series["FinancialData"]);
                }

                var series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "FinancialData",
                    IsVisibleInLegend = true,
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
                };

                chart1.Series.Add(series);

                foreach (var entry in chartData)
                {
                    series.Points.AddXY(entry.Key, entry.Value);
                }

                chart1.Invalidate();
            }

        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            InOutForm inOutForm = new InOutForm(this.m_networkStream, this.m_client, userId);
            inOutForm.Show();
            this.Hide();
        }

        private void chart_Form_Paint(object sender, PaintEventArgs e)
        {

        }
        private Dictionary<string, Color> categoryColors = new Dictionary<string, Color>();
        private Random rnd = new Random();

        // 카테고리에 대한 색상을 가져오는 함수
        public Color GetColorForCategory(string categoryId)
        {
            // 이미 해당 카테고리에 색상이 할당되었는지 확인
            if (!categoryColors.ContainsKey(categoryId))
            {
                // 색상이 할당되지 않았다면, 새로운 색상 생성
                Color newColor;
                do
                {
                    int r = rnd.Next(256); // Red value (0~255)
                    int g = rnd.Next(256); // Green value (0~255)
                    int b = rnd.Next(256); // Blue value (0~255)
                    newColor = Color.FromArgb(r, g, b);
                }
                // 생성된 색상이 이미 사용된 색상인지 확인 (선택적)
                while (categoryColors.Values.Contains(newColor));

                // 새로운 색상을 카테고리에 할당
                categoryColors[categoryId] = newColor;
            }

            // 할당된 색상 반환
            return categoryColors[categoryId];
        }

        private void chart_Form_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await RequestFinancialData(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
            });
        }
     
        private void rdo_in_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void rdo_out_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void rdo_all_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateChart();
        }
    }
}
