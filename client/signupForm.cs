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
    public partial class signupForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;

        public SignUp m_signupClass;

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

        public signupForm(TcpClient client, NetworkStream networkStream)
        {
            InitializeComponent();
            this.m_client = client;
            this.m_networkStream = networkStream;
            this.m_bConnect = client.Connected;
        }


        private void signupForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.");
                return;
            }

            SignUp signUp = new SignUp();
            signUp.type = (int)PacketType.회원가입;
            signUp.userId = txt_ID.Text;
            signUp.password = txt_PWD.Text;
            signUp.name = txt_name.Text;

            Packet.Serialize(signUp).CopyTo(this.sendBuffer, 0);
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
                        MessageBox.Show(responsePacket.errorMessage);
                    }));
                }
                else if ((PacketType)responsePacket.type == PacketType.회원가입)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        MessageBox.Show("회원가입에 성공하셨습니다!");
                        loginForm login = new loginForm(this.m_client, this.m_networkStream);
                        login.Show();
                        this.Hide();
                    }));
                }
            }
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm(this.m_client, this.m_networkStream);
            login.Show();
            this.Hide();
        }

    }
}
