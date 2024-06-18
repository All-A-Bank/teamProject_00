using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PacketClass;
using static teamProject_00.chart_Form;

namespace teamProject_00
{
    public partial class InOutForm : Form
    {


        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private byte[] readBuffer = new byte[1024 * 4];
        private List<FinancialData> financialDataList;
        public int incomeCnt = 1;
        public int expenseCnt = 1;

        public InOutForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;
            this.financialDataList = new List<FinancialData>();

            lvwExpense.View = View.Details;
            lvwExpense.Columns.Add("id");
            lvwExpense.Columns.Add("카테고리");
            lvwExpense.Columns.Add("가격");
            lvwExpense.Columns.Add("설명");
            lvwExpense.Columns.Add("날짜");
            lvwExpense.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvwIncome.View = View.Details;
            lvwIncome.Columns.Add("id");
            lvwIncome.Columns.Add("카테고리");
            lvwIncome.Columns.Add("가격");
            lvwIncome.Columns.Add("설명");
            lvwIncome.Columns.Add("날짜");
            lvwIncome.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            await RequestFinancialData(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
            await SetCurrentDate(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
        }

        private void chart_Click(object sender, EventArgs e)
        {
            chart_Form chart_Form = new chart_Form(this.m_networkStream, this.m_client, userId);
            chart_Form.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm(this.m_networkStream, this.m_client, userId);
            mainForm.Show();
            this.Hide();
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lvwIncome.Items.Clear();
            lvwExpense.Items.Clear();
            chart1.Series.Clear();

            incomeCnt = 1;
            expenseCnt = 1;

            string selectedDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");

            await SetCurrentDate(selectedDate);

            await UpdatePieChart(selectedDate);
        }

        private async Task SetCurrentDate(string selectedDate)
        {
            await RequestIncomeList(selectedDate);
            await RequestExpenseList(selectedDate);
        }

        private async Task UpdatePieChart(string selectedDate)
        {
            await RequestFinancialData(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
            await DisplayPieChart();
        }

        private void InOutForm_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await SetCurrentDate(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                await RequestFinancialData(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
            });

        }

        private async Task RequestIncomeList(string date)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.수입목록요청;
            requestPacket.message.Add(this.userId + "," + date);

            byte[] serializedData = Packet.Serialize(requestPacket);
            await this.m_networkStream.WriteAsync(serializedData, 0, serializedData.Length);
            await this.m_networkStream.FlushAsync();

            await ReceiveIncomeListResponse();
        }

        private async Task RequestExpenseList(string date)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.지출목록요청;
            requestPacket.message.Add(this.userId + "," + date);

            byte[] serializedData = Packet.Serialize(requestPacket);
            await this.m_networkStream.WriteAsync(serializedData, 0, serializedData.Length);
            await this.m_networkStream.FlushAsync();

            await ReceiveExpenseListResponse();
        }

        private string GetCategoryName(string categoryId)
        {
            switch (categoryId)
            {
                case "0":
                    return "식비";
                case "1":
                    return "교통비";
                case "2":
                    return "여가생활";
                case "3":
                    return "급여";
                case "4":
                    return "연금";
                default:
                    return "기타";
            }
        }

        private async Task ReceiveIncomeListResponse()
        {
            int bytesRead = await this.m_networkStream.ReadAsync(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.수입목록요청)
                {
                    List<string> msgList = responsePacket.message;

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        foreach (string msg in msgList)
                        {
                            ListViewItem lvwItem = new ListViewItem(Convert.ToString(incomeCnt));
                            incomeCnt++;

                            string[] data = msg.Split(',');

                            string categoryId = data[0];
                            string categoryName = GetCategoryName(categoryId);

                            string amount = data[1];
                            string description = data[2];
                            string date = data[3];

                            lvwItem.SubItems.Add(categoryName);
                            lvwItem.SubItems.Add(amount);
                            lvwItem.SubItems.Add(description);
                            lvwItem.SubItems.Add(date);

                            lvwIncome.Items.Add(lvwItem);
                        }
                    }));
                }
                else if ((PacketType)responsePacket.type == PacketType.에러)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MessageBox.Show("서버 에러: " + responsePacket.errorMessage);
                    }));
                }
            }
        }

        private async Task ReceiveExpenseListResponse()
        {
            int bytesRead = await this.m_networkStream.ReadAsync(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.지출목록요청)
                {
                    List<string> msgList = responsePacket.message;

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        foreach (string msg in msgList)
                        {
                            ListViewItem lvwItem = new ListViewItem(Convert.ToString(expenseCnt));
                            expenseCnt++;

                            string[] data = msg.Split(',');

                            string categoryId = data[0];
                            string categoryName = GetCategoryName(categoryId);

                            string amount = data[1];
                            string description = data[2];
                            string date = data[3];

                            lvwItem.SubItems.Add(categoryName);
                            lvwItem.SubItems.Add(amount);
                            lvwItem.SubItems.Add(description);
                            lvwItem.SubItems.Add(date);

                            lvwExpense.Items.Add(lvwItem);
                        }
                    }));
                }
                else if ((PacketType)responsePacket.type == PacketType.에러)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MessageBox.Show("서버 에러: " + responsePacket.errorMessage);
                    }));
                }
            }
        }


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
                    await DisplayPieChart();
                }
            }
        }
        private async Task DisplayPieChart()
        {
            var chartData = new Dictionary<string, decimal>();
            await Task.Run(() =>
            {
                foreach (var data in financialDataList)
                {

                    string categoryName = data.CategoryName;
                    if (!chartData.ContainsKey(categoryName))
                    {
                        chartData[categoryName] = 0;
                    }
                    chartData[categoryName] += data.Amount;
                }
            });
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
        private void addbutton_Click(object sender, EventArgs e)
        {
            InOutAddForm inOutAddForm = new InOutAddForm(this.m_client, this.m_networkStream, this.userId);
            inOutAddForm.Show();
            this.Hide();
        }

    }
}