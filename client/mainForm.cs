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
    public partial class mainForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private byte[] readBuffer = new byte[1024 * 4];

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
            RequestUserName();
        }

        private void RequestUserName()
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.유저이름요청;
            requestPacket.message = this.userId;

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

                if ((PacketType)responsePacket.type == PacketType.유저이름요청)
                {
                    string userName = responsePacket.message;
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        label_name.Text = userName;
                    }));
                }
            }
        }
    }
}