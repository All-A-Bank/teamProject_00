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

        public mainForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;
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
            RequestUserNameAndBudget();
            SetCurrentDate();
        }

        private void RequestUserNameAndBudget()
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.유저이름과예산요청;
            requestPacket.message.Add(this.userId);

            byte[] serializedData = Packet.Serialize(requestPacket);
            this.m_networkStream.Write(serializedData, 0, serializedData.Length);
            this.m_networkStream.Flush();

            Task.Run(() => ReceiveResponse());
        }

        private void ReceiveResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);
                if ((PacketType)responsePacket.type == PacketType.유저이름과예산요청)
                {
                    string userName = responsePacket.message[0];
                    string amount = responsePacket.message[1];
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        label_name.Text = userName;
                        lblSetBudget.Text = amount;
                    }));
                }
            }
        }

        private void SetCurrentDate()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                nowDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }));

            string selectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            RequestIncomeList(selectedDate);
            RequestExpenseList(selectedDate);
        }

        private void RequestIncomeList(string date)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.수입지출목록요청;
            requestPacket.message.Add(this.userId + "," + date);

            byte[] serializedData = Packet.Serialize(requestPacket);
            this.m_networkStream.Write(serializedData, 0, serializedData.Length);
            this.m_networkStream.Flush();

            Task.Run(() => ReceiveIncomeListResponse());
        }

        private void RequestExpenseList(string date)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.수입지출목록요청;
            requestPacket.message.Add(this.userId + "," + date);

            byte[] serializedData = Packet.Serialize(requestPacket);
            this.m_networkStream.Write(serializedData, 0, serializedData.Length);
            this.m_networkStream.Flush();

            Task.Run(() => ReceiveExpenseListResponse());
        }

        private void ReceiveIncomeListResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.수입지출목록요청)
                {
                    List<string> msgList = responsePacket.message;

                    foreach (string msg in msgList)
                    {
                        string[] data = msg.Split(',');

                        string categoryId = data[0];
                        string categoryName = GetCategoryName(categoryId); // Implement this method to get category name from ID
                        string amount = data[1];
                        string description = data[2];
                        string date = data[3];

                        ListViewItem lvwItem = new ListViewItem(categoryName);
                        lvwItem.SubItems.Add(amount);
                        lvwItem.SubItems.Add(description);
                        lvwItem.SubItems.Add(date);

                        lvwIncome.Items.Add(lvwItem);
                    }
                }
            }
        }

        private void ReceiveExpenseListResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.수입지출목록요청)
                {
                    List<string> msgList = responsePacket.message;

                    foreach (string msg in msgList)
                    {
                        string[] data = msg.Split(',');

                        string categoryId = data[0];
                        string categoryName = GetCategoryName(categoryId); // Implement this method to get category name from ID
                        string amount = data[1];
                        string description = data[2];
                        string date = data[3];

                        ListViewItem lvwItem = new ListViewItem(categoryName);
                        lvwItem.SubItems.Add(amount);
                        lvwItem.SubItems.Add(description);
                        lvwItem.SubItems.Add(date);

                        lvwExpense.Items.Add(lvwItem);
                    }
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
    }
}