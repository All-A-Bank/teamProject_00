using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Xml.Linq;
using PacketClass;

namespace PacketServer
{
    public partial class Form1 : Form
    {

        private NetworkStream m_networkstream;
        private TcpListener m_listener;

        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bClientOn = false;

        private Thread m_thread;

        public Login m_loginClass;
        public SignUp m_signUpClass;

        DataSet dataSet;

        public Form1()
        {
            InitializeComponent();

            dataSet = new DataSet();

            // 유저
            DataTable personTable = new DataTable("Person");
            personTable.Columns.Add("person_id", typeof(int)).AutoIncrement = true;
            personTable.Columns.Add("userId", typeof(string));
            personTable.Columns.Add("password", typeof(string));
            personTable.PrimaryKey = new DataColumn[] { personTable.Columns["person_id"] };

            // 카테고리
            DataTable categoriesTable = new DataTable("Categories");
            categoriesTable.Columns.Add("category_id", typeof(int)).AutoIncrement = true;
            categoriesTable.Columns.Add("name", typeof(string));
            categoriesTable.PrimaryKey = new DataColumn[] { categoriesTable.Columns["category_id"] };

            // 예산
            DataTable budgetsTable = new DataTable("Budgets");
            budgetsTable.Columns.Add("budget_id", typeof(int)).AutoIncrement = true;
            budgetsTable.Columns.Add("category_id", typeof(int));
            budgetsTable.Columns.Add("amount", typeof(decimal));
            budgetsTable.Columns.Add("description", typeof(string));
            budgetsTable.Columns.Add("date", typeof(DateTime));
            budgetsTable.PrimaryKey = new DataColumn[] { budgetsTable.Columns["budget_id"] };

            // 지출
            DataTable expensesTable = new DataTable("Expenses");
            expensesTable.Columns.Add("expense_id", typeof(int)).AutoIncrement = true;
            expensesTable.Columns.Add("category_id", typeof(int));
            expensesTable.Columns.Add("amount", typeof(decimal));
            expensesTable.Columns.Add("description", typeof(string));
            expensesTable.Columns.Add("date", typeof(DateTime));
            expensesTable.PrimaryKey = new DataColumn[] { expensesTable.Columns["expense_id"] };

            // 수입
            DataTable incomeTable = new DataTable("Income");
            incomeTable.Columns.Add("income_id", typeof(int)).AutoIncrement = true;
            incomeTable.Columns.Add("category_id", typeof(int));
            incomeTable.Columns.Add("amount", typeof(decimal));
            incomeTable.Columns.Add("description", typeof(string));
            incomeTable.Columns.Add("date", typeof(DateTime));
            incomeTable.PrimaryKey = new DataColumn[] { incomeTable.Columns["income_id"] };

            dataSet.Tables.Add(personTable);
            dataSet.Tables.Add(categoriesTable);
            dataSet.Tables.Add(budgetsTable);
            dataSet.Tables.Add(expensesTable);
            dataSet.Tables.Add(incomeTable);

            // 외래 키 설정
            DataRelation categoryBudgetRelation = new DataRelation("CategoryBudget", categoriesTable.Columns["category_id"], budgetsTable.Columns["category_id"]);
            DataRelation categoryExpenseRelation = new DataRelation("CategoryExpense", categoriesTable.Columns["category_id"], expensesTable.Columns["category_id"]);
            DataRelation categoryIncomeRelation = new DataRelation("CategoryIncome", categoriesTable.Columns["category_id"], incomeTable.Columns["category_id"]);

            dataSet.Relations.Add(categoryBudgetRelation);
            dataSet.Relations.Add(categoryExpenseRelation);
            dataSet.Relations.Add(categoryIncomeRelation);

            dataSet.Tables["Categories"].Rows.Add(null, "식비");
            dataSet.Tables["Categories"].Rows.Add(null, "교통비");
            dataSet.Tables["Categories"].Rows.Add(null, "여가생활");
            dataSet.Tables["Categories"].Rows.Add(null, "급여");
            dataSet.Tables["Categories"].Rows.Add(null, "연금");



            dataGridView1.DataSource = dataSet.Tables["Person"];
        }

        public void ServerStart()
        {
            this.m_listener = new TcpListener(7777);
            this.m_listener.Start();

            if (!this.m_bClientOn)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.txt_server_state.AppendText("클라이언트 접속 대기중 \r\n");
                }));
            }

            TcpClient client = this.m_listener.AcceptTcpClient();

            if (client.Connected)
            {
                this.m_bClientOn = true;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.txt_server_state.AppendText("클라이언트 접속 \r\n");
                }));

                m_networkstream = client.GetStream();
            }

            int nRead = 0;

            while (this.m_bClientOn)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_bClientOn = false;
                    this.m_networkstream = null;
                }

                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                switch ((int)packet.type)
                {
                    case (int)PacketType.회원가입:
                        {
                            this.m_signUpClass = (SignUp)Packet.Desserialize(this.readBuffer);
                            this.txt_server_state.AppendText("회원가입 패킷 데이터: " + this.m_signUpClass.userId + ", " + this.m_signUpClass.password + "\r\n");
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("패킷 전송 성공. " + "SignUp Class Data is " + this.m_signUpClass.userId + " " + this.m_signUpClass.password  + "\r\n");
                                dataSet.Tables["Person"].Rows.Add(null, this.m_signUpClass.userId, this.m_signUpClass.password);
                            }));
                            break;
                        }
                    case (int)PacketType.로그인:
                        {
                            this.m_loginClass = (Login)Packet.Desserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("패킷 전송 성공. " + "Login Class Data is " + this.m_loginClass.userId + "\r\n");
                                dataSet.Tables["Person"].Rows.Add(null, this.m_loginClass.userId);
                            }));
                            break;
                        }


                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_thread = new Thread(new ThreadStart(ServerStart));
            this.m_thread.Start();
        }
    }
}
