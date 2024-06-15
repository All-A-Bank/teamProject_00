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
using PacketClass;

namespace teamProject_00
{
    public partial class BudgetSettingForm : Form
    {

        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private bool m_bConnect = false;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        public void Send()
        {
            try
            {
                this.m_networkStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                this.m_networkStream.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 전송 중 오류가 발생했습니다: " + ex.Message);
                m_bConnect = false;
            }
            finally
            {
                for (int i = 0; i < 1024 * 4; i++)
                {
                    this.sendBuffer[i] = 0;
                }
            }
        }

        public BudgetSettingForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;
            this.m_bConnect = client.Connected;
        }

        private void BudgetSettingForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.");
                return;
            }

            Budget budget = new Budget();
            budget.type = (int)PacketType.예산추가;
            budget.amount = decimal.Parse(txtBudget.Text);
            budget.userId = this.userId;

            Packet.Serialize(budget).CopyTo(this.sendBuffer, 0);
            this.Send();

            BudgetForm budgetForm = new BudgetForm(this.m_networkStream, this.m_client, userId);
            budgetForm.Show();
            this.Hide();
        }
    }
}
