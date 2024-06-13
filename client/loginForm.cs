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
            this.m_networkStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkStream.Flush();

            for(int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.m_bConnect)
            {
                return;
            }
            Login login = new Login();
            login.type = (int)PacketType.로그인;
            login.userId = this.textBox_ID.Text;

            Packet.Serialize(login).CopyTo(this.sendBuffer, 0);
            this.Send();

            mainForm main = new mainForm();
            main.Show();
            this.Hide();
        }

        private void initForm_Load(object sender, EventArgs e)
        {
            textBox_ID.Focus();
        }


        private void initForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_client.Close();
            this.m_networkStream.Close();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            signupForm signup = new signupForm(this.m_client, this.m_networkStream);
            signup.Show();
            this.Hide();
        }
    }
}
