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

namespace teamProject_00
{
    public partial class InOutForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private byte[] readBuffer = new byte[1024 * 4];

        public int incomeCnt = 1;
        public int expenseCnt = 1;

        public InOutForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lvwIncome.Items.Clear();
            lvwExpense.Items.Clear();

            incomeCnt = 1;
            expenseCnt = 1;

            string selectedDate = dateTimePicker1.Value.Date.ToString();

            RequestIncomeList(selectedDate);
            RequestExpenseList(selectedDate);

        }




        private void InOutForm_Load(object sender, EventArgs e)
        {
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

                    List<string> msgList = new List<string>();
                    for (int i = 0; i < responsePacket.message.Count; i++)
                    {
                        ListViewItem lvwItem = new ListViewItem(Convert.ToString(incomeCnt));
                        incomeCnt++;

                        msgList.Add(responsePacket.message[i]);
                        string[] msg = msgList[i].Split(',');

                        string categoryId = msg[0];
                        string categoryName;
                        if (int.Parse(categoryId) == 1)
                        {
                            categoryName = "식비";
                        }
                        else if (int.Parse(categoryId) == 2)
                        {

                            categoryName = "교통비";
                        }
                        else if (int.Parse(categoryId) == 3)
                        {

                            categoryName = "여가생활";
                        }
                        else if (int.Parse(categoryId) == 4)
                        {

                            categoryName = "급여";
                        }
                        else
                        {

                            categoryName = "연금";
                        }


                        string amount = msg[1];
                        string description = msg[2];
                        string date = msg[3];

                        lvwItem.SubItems.Add(categoryName);
                        lvwItem.SubItems.Add(amount);
                        lvwItem.SubItems.Add(description);
                        lvwItem.SubItems.Add(date);

                        lvwIncome.Items.Add(lvwItem);
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
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

        private void ReceiveExpenseListResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.수입지출목록요청)
                {

                    List<string> msgList = new List<string>();
                    for (int i = 0; i < responsePacket.message.Count; i++)
                    {
                        ListViewItem lvwItem = new ListViewItem(Convert.ToString(expenseCnt));
                        expenseCnt++;

                        msgList.Add(responsePacket.message[i]);
                        string[] msg = msgList[i].Split(',');

                        string categoryId = msg[0];
                        string categoryName;
                        if (int.Parse(categoryId) == 1)
                        {
                            categoryName = "식비";
                        }
                        else if (int.Parse(categoryId) == 2)
                        {

                            categoryName = "교통비";
                        }
                        else if (int.Parse(categoryId) == 3)
                        {

                            categoryName = "여가생활";
                        }
                        else if (int.Parse(categoryId) == 4)
                        {

                            categoryName = "급여";
                        }
                        else
                        {

                            categoryName = "연금";
                        }


                        string amount = msg[1];
                        string description = msg[2];
                        string date = msg[3];

                        lvwItem.SubItems.Add(categoryName);
                        lvwItem.SubItems.Add(amount);
                        lvwItem.SubItems.Add(description);
                        lvwItem.SubItems.Add(date);

                        lvwExpense.Items.Add(lvwItem);
                    }

                    this.Invoke(new MethodInvoker(delegate ()
                    {
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

        private void addbutton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(userId);
            InOutAddForm inOutAddForm = new InOutAddForm(this.m_client, this.m_networkStream, this.userId);
            inOutAddForm.Show();
        }
    }
}