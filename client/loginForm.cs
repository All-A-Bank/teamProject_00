using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Windows.Forms;
using PacketClass;

namespace teamProject_00
{
    public partial class loginForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;

        public Login m_loginClass;

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

        public loginForm()
        {
            InitializeComponent();

            this.m_client = new TcpClient();
            try
            {
                this.m_client.Connect("127.0.0.1", 7777);
            }
            catch
            {
                MessageBox.Show("접속에러");
                return;
            }
            this.m_bConnect = true;
            this.m_networkStream = this.m_client.GetStream();
        }

        public loginForm(TcpClient client, NetworkStream networkStream)
        {
            InitializeComponent();
            this.m_client = client;
            this.m_networkStream = networkStream;
            this.m_bConnect = client.Connected;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.");
                return;
            }
            Login login = new Login();
            login.type = (int)PacketType.로그인;
            login.userId = this.textBox_ID.Text;
            login.password = this.textBox_PWD.Text;

            Packet.Serialize(login).CopyTo(this.sendBuffer, 0);
            this.Send();

            Task.Run(() => ReceiveResponse());
        }

        private void ReceiveResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.에러)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MessageBox.Show("서버 에러: " + responsePacket.errorMessage);
                    }));
                }
                else if ((PacketType)responsePacket.type == PacketType.로그인)
                {
                    string userId = responsePacket.message;
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        mainForm main = new mainForm(this.m_networkStream, this.m_client, userId);
                        main.Show();
                        this.Hide();
                    }));
                }
            }
        }

        private void initForm_Load(object sender, EventArgs e)
        {
            textBox_ID.Focus();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            signupForm signup = new signupForm(this.m_client, this.m_networkStream);
            signup.Show();
            this.Hide();
        }
    }
}
