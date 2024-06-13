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
            this.m_networkStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkStream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public signupForm(TcpClient client, NetworkStream networkStream)
        {
            InitializeComponent();

            this.m_client = client;
            this.m_networkStream = networkStream;
            this.m_bConnect = client.Connected;

            if (!this.m_bConnect)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.");
                return;
            }
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

            Packet.Serialize(signUp).CopyTo(this.sendBuffer, 0);
            this.Send();

            loginForm login = new loginForm();
            login.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            login.Show();
            this.Hide();
        }
    }
}
