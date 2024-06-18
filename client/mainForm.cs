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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace teamProject_00
{
    public partial class mainForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private byte[] readBuffer = new byte[1024 * 4];

        public int incomeCnt = 1;
        public int expenseCnt = 1;

        public decimal budgetAmount = 0;
        public decimal incomdeAmount = 0;
        public decimal expenseAmount = 0;

        public mainForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;

            lvwExpense.View = View.Details;
            lvwExpense.Columns.Clear();
            lvwExpense.Columns.Add("카테고리");
            lvwExpense.Columns.Add("가격");
            lvwExpense.Columns.Add("설명");
            lvwExpense.Columns.Add("날짜");
            lvwExpense.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvwIncome.View = View.Details;
            lvwIncome.Columns.Clear();
            lvwIncome.Columns.Add("카테고리");
            lvwIncome.Columns.Add("가격");
            lvwIncome.Columns.Add("설명");
            lvwIncome.Columns.Add("날짜");
            lvwIncome.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void btn_InOut_Click(object sender, EventArgs e)
        {
            InOutForm inOutForm = new InOutForm(this.m_networkStream, this.m_client, userId);
            inOutForm.Show();
            this.Hide();

        }

        private void btn_budget_Click(object sender, EventArgs e)
        {
            BudgetForm budgetForm = new BudgetForm(this.m_networkStream, this.m_client, userId);
            budgetForm.Show();
            this.Hide();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(this.m_networkStream, this.m_client, userId);
            reportForm.Show();
            this.Hide();

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await RefreshData();
            });
        }


        private async Task RequestUserNameAndBudget()
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.유저이름과예산요청;
            requestPacket.message.Add(this.userId);

            byte[] serializedData = Packet.Serialize(requestPacket);
            await this.m_networkStream.WriteAsync(serializedData, 0, serializedData.Length);
            await this.m_networkStream.FlushAsync();

            await ReceiveResponse();
        }

        private async Task ReceiveResponse()
        {
            int bytesRead = await this.m_networkStream.ReadAsync(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);
                if ((PacketType)responsePacket.type == PacketType.유저이름과예산요청)
                {
                    string userName = responsePacket.message[0];
                    string amount = responsePacket.message[1];

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MessageBox.Show("메인 폼으로 이동했습니다!");
                        label_name.Text = userName;
                        lblSetBudget.Text = amount;
                    }));

                    budgetAmount = decimal.Parse(lblSetBudget.Text);
                }
            }
        }

        private async Task SetCurrentDate()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                nowDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }));

            string selectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            await RequestIncomeList(selectedDate);
            await RequestExpenseList(selectedDate);
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

        private async Task ReceiveIncomeListResponse()
        {
            int bytesRead = await this.m_networkStream.ReadAsync(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.수입목록요청)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lvwIncome.Items.Clear();
                    }));

                    List<string> msgList = responsePacket.message;
                    int incomeCount = 0; // 추가된 항목 수를 카운트

                    foreach (string msg in msgList)
                    {
                        if (incomeCount >= 5)
                            break;

                        string[] data = msg.Split(',');

                        string categoryId = data[0];
                        string categoryName = GetCategoryName(categoryId); // ID로부터 카테고리 이름을 가져오는 메서드 구현 필요
                        string amount = data[1];
                        string description = data[2];
                        string date = data[3];

                        ListViewItem lvwItem = new ListViewItem(categoryName);
                        lvwItem.SubItems.Add(amount);
                        lvwItem.SubItems.Add(description);
                        lvwItem.SubItems.Add(date);

                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvwIncome.Items.Add(lvwItem);
                        }));

                        incomeCount++; // 항목 수 증가

                        // 디버깅용 로그 출력
                        Console.WriteLine($"Income: {categoryName}, {amount}, {description}, {date}");
                    }
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
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lvwExpense.Items.Clear();
                        expenseAmount = 0;
                    }));

                    List<string> msgList = responsePacket.message;
                    int expenseCount = 0; // 추가된 항목 수를 카운트

                    foreach (string msg in msgList)
                    {
                        if (expenseCount >= 5)
                            break;

                        string[] data = msg.Split(',');

                        string categoryId = data[0];
                        string categoryName = GetCategoryName(categoryId); // ID로부터 카테고리 이름을 가져오는 메서드 구현 필요
                        string amount = data[1];
                        string description = data[2];
                        string date = data[3];

                        expenseAmount += decimal.Parse(amount);

                        ListViewItem lvwItem = new ListViewItem(categoryName);
                        lvwItem.SubItems.Add(amount);
                        lvwItem.SubItems.Add(description);
                        lvwItem.SubItems.Add(date);

                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvwExpense.Items.Add(lvwItem);
                        }));

                        expenseCount++; // 항목 수 증가

                        // 디버깅용 로그 출력
                        Console.WriteLine($"Expense: {categoryName}, {amount}, {description}, {date}");
                    }

                    this.Invoke(new MethodInvoker(delegate
                    {
                        lblRemainBudget.Text = (budgetAmount - expenseAmount).ToString();
                    }));
                }
            }
        }

        private string GetCategoryName(string categoryId)
        {
            switch (categoryId)
            {
                case "1":
                    return "식비";
                case "2":
                    return "교통비";
                case "3":
                    return "여가생활";
                case "4":
                    return "급여";
                case "5":
                    return "연금";
                default:
                    return "기타";
            }
        }

        private async Task RefreshData()
        {
            await RequestUserNameAndBudget();
            await SetCurrentDate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                m_networkStream.Close();
                m_client.Close();

                Application.Exit();
            }
        }
    }
}