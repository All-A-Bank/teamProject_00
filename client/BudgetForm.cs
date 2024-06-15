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

        }
    }
}
