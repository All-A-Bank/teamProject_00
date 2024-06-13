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

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;

        public AppDomainInitializer m_initializeClass;
        public Login m_loginClass;


        public mainForm()
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


        private void btn_InOut_Click(object sender, EventArgs e)
        {
            InOutForm inOutForm = new InOutForm();
            inOutForm.Show();
            this.Hide();

        }

        private void btn_budget_Click(object sender, EventArgs e)
        {
            BudgetForm budgetForm = new BudgetForm();
            budgetForm.Show();
            this.Hide();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
            this.Hide();

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void ClientReceive()
        {
            while (m_bConnect)
            {
                int nRead = 0;
                try
                {
                    nRead = this.m_networkStream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_bConnect = false;
                }
            }
        }


        private void mainForm_Load(object sender, EventArgs e)
        {

            Thread clientThread = new Thread(ClientReceive);
            clientThread.Start();

            // 오늘의 날짜를 가져와서 문자열로 변환하여 라벨에 표시
            /*            nowDate.Text = DateTime.Today.ToShortDateString();

                        // 오늘의 날짜
                        DateTime today = DateTime.Today;

                        // 선택된 날짜와 일치하는 수입 데이터 가져오기
                        DataRow[] selectedIncome = dataSet.Tables["Income"].Select("date = '" + today.ToString("yyyy-MM-dd") + "'", "date ASC");

                        listView1.Items.Clear(); // 기존 데이터 지우기

                        for (int i = 0; i < Math.Min(5, selectedIncome.Length); i++)
                        {
                            DataRow income = selectedIncome[i];
                            ListViewItem item = new ListViewItem(income["income_id"].ToString());
                            item.SubItems.Add(income["category_id"].ToString());
                            item.SubItems.Add(income["amount"].ToString());
                            item.SubItems.Add(income["description"].ToString());
                            item.SubItems.Add(((DateTime)income["date"]).ToShortDateString()); // 날짜를 원하는 형식으로 표시
                            listView1.Items.Add(item);
                        }

                        // 선택된 날짜와 일치하는 지출 데이터 가져오기
                        DataRow[] selectedExpenses = dataSet.Tables["Expenses"].Select("date = '" + today.ToString("yyyy-MM-dd") + "'", "date ASC");

                        listView2.Items.Clear(); // 기존 데이터 지우기

                        for (int i = 0; i < Math.Min(5, selectedExpenses.Length); i++)
                        {
                            DataRow expense = selectedExpenses[i];
                            ListViewItem item = new ListViewItem(expense["expense_id"].ToString());
                            item.SubItems.Add(expense["category_id"].ToString());
                            item.SubItems.Add(expense["amount"].ToString());
                            item.SubItems.Add(expense["description"].ToString());
                            item.SubItems.Add(((DateTime)expense["date"]).ToShortDateString()); // 날짜를 원하는 형식으로 표시
                            listView2.Items.Add(item);
                        }*/
        }

    }
}