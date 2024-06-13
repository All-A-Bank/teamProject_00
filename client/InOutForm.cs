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
    public partial class InOutForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private byte[] readBuffer = new byte[1024 * 4];

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ShowSelectedExpenses(DateTime selectedDate)
        {

        }

        private void ShowSelectedIncome(DateTime selectedDate)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void InOutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
