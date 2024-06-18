using PacketClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teamProject_00
{
    public partial class BudgetForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private byte[] readBuffer = new byte[1024 * 4];

        public decimal incomeAmount = 0;
        public decimal expenseAmount = 0;

        public BudgetForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm(this.m_networkStream, this.m_client, userId);
            mainForm.Show();
            this.Hide();
        }

        private void BudgetSetting_btn_Click(object sender, EventArgs e)
        {
            BudgetSettingForm budgetSettingForm = new BudgetSettingForm(this.m_networkStream, this.m_client, userId);
            budgetSettingForm.Show();
            this.Hide();
        }

        private void BudgetForm_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await RefreshData();
            });
        }

        private async Task RefreshData()
        {
            await RequestBudget();
            await SetCurrentDate();
        }

        private async Task RequestBudget()
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
                    string amount = responsePacket.message[1];
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lblSetBudget.Text = amount;
                    }));
                }
            }
        }

        private async Task SetCurrentDate()
        {
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
                    List<string> msgList = responsePacket.message;

                    foreach (string msg in msgList)
                    {
                        string[] data = msg.Split(',');
                        string amount = data[1];
                        incomeAmount += decimal.Parse(amount);
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lblIncomeAmount.Text = incomeAmount.ToString();
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

                    foreach (string msg in msgList)
                    {
                        string[] data = msg.Split(',');
                        string amount = data[1];
                        expenseAmount += decimal.Parse(amount);
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lblExpenseAmount.Text = expenseAmount.ToString();
                    }));
                }
            }
        }
    }
}
