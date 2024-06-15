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

        private bool m_bConnect = false;

        private byte[] readBuffer = new byte[1024 * 4];

        public decimal incomeAmount = 0;
        public decimal expenseAmount = 0;

        public BudgetForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;
            this.m_bConnect = client.Connected;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // 선택한 날짜 확인
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;

            // 새 폼 생성 및 열기
            using (ExpenseForm expense_form = new ExpenseForm(selectedDate))
            {
                expense_form.ShowDialog();
            }
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
            RequestBudget();
            SetCurrentDate();
        }

        private void RequestBudget()
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
                    string amount = responsePacket.message[1];
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lblSetBudget.Text = amount;
                    }));
                }
            }
        }

        private void SetCurrentDate()
        {
            string selectedDate = DateTime.Now.ToString("yyyy-MM-dd");
            RequestIncomeList(selectedDate);
            RequestExpenseList(selectedDate);
        }

        private void RequestIncomeList(string date)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.수입목록요청;
            requestPacket.message.Add(this.userId + "," + date);

            byte[] serializedData = Packet.Serialize(requestPacket);
            this.m_networkStream.Write(serializedData, 0, serializedData.Length);
            this.m_networkStream.Flush();

            Task.Run(() => ReceiveIncomeListResponse());
        }

        private void RequestExpenseList(string date)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.지출목록요청;
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

        private void ReceiveExpenseListResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
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
