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
using System.IO;
using System.Runtime.InteropServices.ComTypes;

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
        public IncomeAdd m_incomeAdd;
        public ExpenseAdd m_expenseAdd;
        public Budget m_budgetClass;

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
            personTable.Columns.Add("name", typeof(string));
            personTable.PrimaryKey = new DataColumn[] { personTable.Columns["person_id"] };

            // 카테고리
            DataTable categoriesTable = new DataTable("Categories");
            categoriesTable.Columns.Add("category_id", typeof(int)).AutoIncrement = true;
            categoriesTable.Columns.Add("name", typeof(string));
            categoriesTable.PrimaryKey = new DataColumn[] { categoriesTable.Columns["category_id"] };

            // 예산
            DataTable budgetsTable = new DataTable("Budgets");
            budgetsTable.Columns.Add("budget_id", typeof(int)).AutoIncrement = true;
            budgetsTable.Columns.Add("amount", typeof(decimal));
            budgetsTable.Columns.Add("userId", typeof(string));
            budgetsTable.PrimaryKey = new DataColumn[] { budgetsTable.Columns["budget_id"] };

            // 지출
            DataTable expensesTable = new DataTable("Expense");
            expensesTable.Columns.Add("expense_id", typeof(int)).AutoIncrement = true;
            expensesTable.Columns.Add("category_id", typeof(int));
            expensesTable.Columns.Add("userId", typeof(string));
            expensesTable.Columns.Add("amount", typeof(decimal));
            expensesTable.Columns.Add("description", typeof(string));
            expensesTable.Columns.Add("date", typeof(DateTime));
            expensesTable.PrimaryKey = new DataColumn[] { expensesTable.Columns["expense_id"] };

            // 수입
            DataTable incomeTable = new DataTable("Income");
            incomeTable.Columns.Add("income_id", typeof(int)).AutoIncrement = true;
            incomeTable.Columns.Add("category_id", typeof(int));
            incomeTable.Columns.Add("userId", typeof(string));
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
            DataRelation categoryExpenseRelation = new DataRelation("CategoryExpense", categoriesTable.Columns["category_id"], expensesTable.Columns["category_id"]);
            DataRelation categoryIncomeRelation = new DataRelation("CategoryIncome", categoriesTable.Columns["category_id"], incomeTable.Columns["category_id"]);
            DataRelation personIncomeRelation = new DataRelation("PersonIncome", personTable.Columns["userId"], incomeTable.Columns["userId"]);
            DataRelation personExpenseRelation = new DataRelation("PersonExpense", personTable.Columns["userId"], expensesTable.Columns["userId"]);
            DataRelation personBudgetRelation = new DataRelation("PersonBudget", personTable.Columns["userId"], budgetsTable.Columns["userId"]);

            dataSet.Relations.Add(categoryExpenseRelation);
            dataSet.Relations.Add(categoryIncomeRelation);
            dataSet.Relations.Add(personIncomeRelation);
            dataSet.Relations.Add(personExpenseRelation);
            dataSet.Relations.Add(personBudgetRelation);

            dataSet.Tables["Categories"].Rows.Add(null, "식비");
            dataSet.Tables["Categories"].Rows.Add(null, "교통비");
            dataSet.Tables["Categories"].Rows.Add(null, "여가생활");
            dataSet.Tables["Categories"].Rows.Add(null, "급여");
            dataSet.Tables["Categories"].Rows.Add(null, "연금");



            dataGridView1.DataSource = dataSet.Tables["Budgets"];
            dataGridView2.DataSource = dataSet.Tables["Income"];
            dataGridView3.DataSource = dataSet.Tables["Expense"];
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

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("회원가입 Request 성공. " + "SignUp Class Data is " + this.m_signUpClass.userId + " / " + this.m_signUpClass.password + " / " + this.m_signUpClass.name + "\r\n");
                                dataSet.Tables["Person"].Rows.Add(null, this.m_signUpClass.userId, this.m_signUpClass.password, this.m_signUpClass.name);
                            }));
                            break;
                        }

                    case (int)PacketType.로그인:
                        {
                            this.m_loginClass = (Login)Packet.Desserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                bool loginSuccess = checkValidLogin(this.m_loginClass.userId, this.m_loginClass.password);

                                if (loginSuccess)
                                {
                                    this.txt_server_state.AppendText("로그인 Request 성공. " + "Login Class Data is " + this.m_loginClass.userId + "\r\n");
                                    SendLoginSuccessPacket(m_loginClass.userId);
                                }
                                else
                                {
                                    this.txt_server_state.AppendText("로그인 Request 실패. 잘못된 사용자 ID 또는 비밀번호.\r\n");
                                    SendErrorPacket("로그인 실패. 아이디 또는 비밀번호가 일치하지 않습니다.");
                                }
                            }));
                            break;
                        }

                    case (int)PacketType.유저이름과예산요청:
                        {
                            this.txt_server_state.AppendText("유저 이름과 예산 요청 \r\n");
                            string userId = packet.message[0];
                            SendUserNameAndBudgetResponse(userId);
                            break;
                        }

                    case (int)PacketType.수입추가:
                        {
                            this.m_incomeAdd = (IncomeAdd)Packet.Desserialize(this.readBuffer);

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("수입추가 Request 성공. " + "IncomeAdd Class Data is " + this.m_incomeAdd.category_id + " / " + this.m_incomeAdd.userId + " / " + this.m_incomeAdd.amount + " / " + this.m_incomeAdd.description + " / " + this.m_incomeAdd.date + "\r\n");
                                dataSet.Tables["Income"].Rows.Add(null, this.m_incomeAdd.category_id, this.m_incomeAdd.userId ,this.m_incomeAdd.amount, this.m_incomeAdd.description, this.m_incomeAdd.date);
                            }));
                            break;
                        }

                    case (int)PacketType.지출추가:
                        {
                            this.m_expenseAdd = (ExpenseAdd)Packet.Desserialize(this.readBuffer);

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("지출추가 Request 성공. " + "ExpenseAdd Class Data is " + this.m_expenseAdd.category_id + " / " + this.m_expenseAdd.userId + " / " + this.m_expenseAdd.amount + " / " + this.m_expenseAdd.description + " / " + this.m_expenseAdd.date + "\r\n");
                                dataSet.Tables["Expense"].Rows.Add(null, this.m_expenseAdd.category_id, this.m_expenseAdd.userId, this.m_expenseAdd.amount, this.m_expenseAdd.description, this.m_expenseAdd.date);
                            }));
                            break;
                        }

                    case (int)PacketType.수입지출목록요청:
                        {
                            // packet.message를 DateTime으로 변환
                            string[] msg = packet.message[0].Split(',');
                            string userId = msg[0];
                            string date = msg[1];
                            
                            this.txt_server_state.AppendText("수입목록 Response 성공. " + userId + " " + date +  "\r\n");

                            SendIncomeResponse(userId, date);
                            SendExpenseResponse(userId, date);

                            break;
                        }

                    case (int)PacketType.예산추가:
                        {
                            this.m_budgetClass = (Budget)Packet.Desserialize(this.readBuffer);

                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("예산추가 Request 성공. " + "Budget Class Data is " + this.m_budgetClass.amount + " / " + this.m_budgetClass.userId + "\r\n");
                                dataSet.Tables["Budgets"].Rows.Add(null, this.m_budgetClass.amount, this.m_budgetClass.userId);
                            }));
                            break;
                        }

                }
            }
        }

        private void SendUserNameAndBudgetResponse(string userId)
        {
            try
            {
                DataTable personTable = dataSet.Tables["Person"];
                DataRow[] person = personTable.Select($"userId = '{userId}'");

                DataTable budgetTable = dataSet.Tables["Budgets"];
                DataRow[] budget = budgetTable.Select($"userId = '{userId}'", "budget_id DESC");

                Packet responsePacket = new Packet();
                responsePacket.type = (int)PacketType.유저이름과예산요청;

                responsePacket.message.Add(person[0]["name"].ToString());

                if (budget.Length > 0)
                {
                    responsePacket.message.Add(budget[0]["amount"].ToString());

                }
                else
                {
                    responsePacket.message.Add("0");
                }


                byte[] serializedData = Packet.Serialize(responsePacket);
                this.m_networkstream.Write(serializedData, 0, serializedData.Length);
                this.m_networkstream.Flush();
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SendIncomeResponse(string userId, string date)
        {
            DataTable incomeTable = dataSet.Tables["Income"];
            DataRow[] incomeList = incomeTable.Select($"userId = '{userId}' AND CONVERT(date, 'System.String') LIKE '{date}%'");
            Packet responsePacket = new Packet();
            responsePacket.type = (int)PacketType.수입지출목록요청;

            foreach (DataRow income in incomeList)
            {
                string incomeInfo = $"{income["category_id"]}, {income["amount"]}, {income["description"]}, {income["date"]}";
                responsePacket.message.Add(incomeInfo);
            }


            byte[] serializedData = Packet.Serialize(responsePacket);
            this.m_networkstream.Write(serializedData, 0, serializedData.Length);
            this.m_networkstream.Flush();
        }

        private void SendExpenseResponse(string userId, string date)
        {
            DataTable expensesTable = dataSet.Tables["Expense"];
            DataRow[] expenseList = expensesTable.Select($"userId = '{userId}' AND CONVERT(date, 'System.String') LIKE '{date}%'");
            Packet responsePacket = new Packet();
            responsePacket.type = (int)PacketType.수입지출목록요청;

            foreach (DataRow expense in expenseList)
            {
                string expenseInfo = $"{expense["category_id"]}, {expense["amount"]}, {expense["description"]}, {expense["date"]}";
                responsePacket.message.Add(expenseInfo);
            }


            byte[] serializedData = Packet.Serialize(responsePacket);
            this.m_networkstream.Write(serializedData, 0, serializedData.Length);
            this.m_networkstream.Flush();
        }

        private bool checkValidLogin(string userId, string password)
        {
            DataTable personTable = dataSet.Tables["Person"];

            DataRow[] person = personTable.Select($"userId = '{userId}' AND password = '{password}'");

            return person.Length > 0;
        }

        private void SendLoginSuccessPacket(string userId)
        {
            Packet loginSuccessPacket = new Packet();
            loginSuccessPacket.type = (int)PacketType.로그인;
            loginSuccessPacket.message.Add(userId);

            byte[] serializedData = Packet.Serialize(loginSuccessPacket);
            this.m_networkstream.Write(serializedData, 0, serializedData.Length);
            this.m_networkstream.Flush();
        }

        private void SendErrorPacket(string errorMessage)
        {
            Packet errorPacket = new Packet();

            errorPacket.type = (int)PacketType.에러;
            errorPacket.errorMessage = errorMessage;

            byte[] serializedData = Packet.Serialize(errorPacket);
            this.m_networkstream.Write(serializedData, 0, serializedData.Length);
            this.m_networkstream.Flush();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_thread = new Thread(new ThreadStart(ServerStart));
            this.m_thread.Start();
        }
    }
}
