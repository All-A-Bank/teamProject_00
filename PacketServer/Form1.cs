﻿using System;
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
        }

        private void LogMessage(string message)
        {
            if (txt_server_state.InvokeRequired)
            {
                txt_server_state.Invoke(new MethodInvoker(delegate
                {
                    txt_server_state.AppendText(message + "\r\n");
                }));
            }
            else
                txt_server_state.AppendText(message + "\r\n");
        }

        public void ServerStart()
        {
            this.m_listener = new TcpListener(7777);
            this.m_listener.Start();

            while (true)
            {
                if (!this.m_bClientOn)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.txt_server_state.AppendText("클라이언트 접속 대기중 \r\n");
                    }));
                }

                try
                {
                    TcpClient client = this.m_listener.AcceptTcpClient();
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.txt_server_state.AppendText("클라이언트 접속 \r\n");
                    }));

                    m_networkstream = client.GetStream();
                    this.m_bClientOn = true;

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.txt_server_state.AppendText("서버 오류: " + ex.Message + "\r\n");
                    }));
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            int nRead = 0;
            NetworkStream clientStream = client.GetStream();

            while (true)
            {
                try
                {
                    nRead = 0;
                    nRead = clientStream.Read(readBuffer, 0, 1024 * 4);
                    if (nRead == 0)
                    {
                        break;
                    }

                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                    ProcessPacket(packet);
                }
                catch
                {
                    break;
                }
            }

            this.Invoke(new MethodInvoker(delegate ()
            {
                this.txt_server_state.AppendText("클라이언트 연결 끊김 \r\n");
            }));

            clientStream.Close();
            client.Close();
            this.m_bClientOn = false;
        }

        private void ProcessPacket(Packet packet)
        {
            switch ((int)packet.type)
            {
                case (int)PacketType.회원가입:
                    {
                        this.m_signUpClass = (SignUp)Packet.Desserialize(this.readBuffer);
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            SendSignUpResponse(this.m_signUpClass);
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
                        LogMessage("유저 이름과 예산 요청");
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
                            dataSet.Tables["Income"].Rows.Add(null, this.m_incomeAdd.category_id, this.m_incomeAdd.userId, this.m_incomeAdd.amount, this.m_incomeAdd.description, this.m_incomeAdd.date);
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

                case (int)PacketType.수입목록요청:
                    {
                        // packet.message를 DateTime으로 변환
                        string[] msg = packet.message[0].Split(',');
                        string userId = msg[0];
                        string date = msg[1];

                        LogMessage($"수입목록 Response 성공. {userId} {date}");

                        SendIncomeResponse(userId, date);
                        //SendExpenseResponse(userId, date);

                        break;
                    }

                case (int)PacketType.지출목록요청:
                    {
                        // packet.message를 DateTime으로 변환
                        string[] msg = packet.message[0].Split(',');
                        string userId = msg[0];
                        string date = msg[1];

                        LogMessage($"지출목록 Response 성공. {userId} {date}");

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
                case (int)PacketType.재정데이터요청:
                    {
                        //string userId = packet.message[0];
                        string[] msg = packet.message[0].Split(',');
                        string userId = msg[0];
                        string date = msg[1];
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            SendFinancialDataPacket(userId, date);
                        }));

                        break;
                    }
                case (int)PacketType.카테고리이름요청:
                    {
                        string categoryId = packet.message[0];
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            SendCategoryName(categoryId);
                        }));

                        break;
                    }

                case (int)PacketType.수입월목록요청:
                    {
                        string[] msg = packet.message[0].Split(',');
                        string userId = msg[0];
                        string yearMonth = msg[1];

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            this.txt_server_state.AppendText("수입 월 목록 요청: " + userId + " " + yearMonth + "\r\n");
                            SendMonthlyIncomeResponse(userId, yearMonth);
                        }));
                        break;
                    }

                case (int)PacketType.지출월목록요청:
                    {
                        string[] msg = packet.message[0].Split(',');
                        string userId = msg[0];
                        string yearMonth = msg[1];

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            this.txt_server_state.AppendText("지출 월 목록 요청: " + userId + " " + yearMonth + "\r\n");
                            SendMonthlyExpenseResponse(userId, yearMonth);
                        }));
                        break;
                    }
            }
        }

        private void SendSignUpResponse(SignUp signUp)
        {
            try
            {
                DataTable personTable = dataSet.Tables["Person"];
                DataRow[] existingUsers = personTable.Select($"userId = '{signUp.userId}'");

                Packet responsePacket = new Packet();
                if (existingUsers.Length > 0)
                {
                    responsePacket.type = (int)PacketType.에러;
                    responsePacket.errorMessage = "이미 존재하는 아이디입니다.";
                }
                else
                {
                    personTable.Rows.Add(null, signUp.userId, signUp.password, signUp.name);
                    responsePacket.type = (int)PacketType.회원가입;
                }

                byte[] serializedData = Packet.Serialize(responsePacket);
                this.m_networkstream.Write(serializedData, 0, serializedData.Length);
                this.m_networkstream.Flush();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
            responsePacket.type = (int)PacketType.수입목록요청;

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
            responsePacket.type = (int)PacketType.지출목록요청;

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
        private void SendCategoryName(string categoryId)
        {
            DataTable categoryTable = dataSet.Tables["Categories"];
            DataRow[] category = categoryTable.Select($"category_id = {categoryId}");

            if (category.Length > 0)
            {
                Packet categoryNamePacket = new Packet();
                categoryNamePacket.type = (int)PacketType.카테고리이름요청;
                categoryNamePacket.message.Add(category[0]["name"].ToString());

                byte[] serializedData = Packet.Serialize(categoryNamePacket);
                this.m_networkstream.Write(serializedData, 0, serializedData.Length);
                this.m_networkstream.Flush();
            }
            else
            {
                // Handle case where the category is not found
                Packet errorPacket = new Packet
                {
                    type = (int)PacketType.에러,
                    errorMessage = "Category not found."
                };

                byte[] serializedData = Packet.Serialize(errorPacket);
                this.m_networkstream.Write(serializedData, 0, serializedData.Length);
                this.m_networkstream.Flush();
            }
        }


        private void SendFinancialDataPacket(string userId, string date)
        {
            DataTable personTable = dataSet.Tables["Person"];
            DataTable incomeTable = dataSet.Tables["Income"];
            DataTable expenseTable = dataSet.Tables["Expense"];
            DataTable categoriesTable = dataSet.Tables["Categories"];

            DataRow[] person = personTable.Select($"userID = '{userId}'");
            if (person.Length == 0)
            {
                SendErrorPacket("사용자 정보를 찾을 수 없습니다.");
                return;
            }

            int personId = (int)person[0]["person_id"];
            DataRow[] expenses = expenseTable.Select($"userId = '{userId}' AND CONVERT(date, 'System.String') LIKE '{date}%'");
            DataRow[] incomes = incomeTable.Select($"userId = '{userId}' AND CONVERT(date, 'System.String') LIKE '{date}%'");

            List<string> financialDataList = new List<string>();

            foreach (DataRow row in expenses)
            {
                int categoryId = (int)row["category_id"];
                string categoryName = GetCategoryName(categoryId);

                string expenseData = $"expense:{categoryName}:{row["amount"]}";
                financialDataList.Add(expenseData);
            }

            foreach (DataRow row in incomes)
            {
                int categoryId = (int)row["category_id"];
                string categoryName = GetCategoryName(categoryId);

                string incomeData = $"income:{categoryName}:{row["amount"]}";
                financialDataList.Add(incomeData);
            }

            Packet financialDataPacket = new Packet();
            financialDataPacket.type = (int)PacketType.재정데이터요청;
            financialDataPacket.message.AddRange(financialDataList); // Add all elements of financialDataList to message

            byte[] serializedData = Packet.Serialize(financialDataPacket);
            this.m_networkstream.Write(serializedData, 0, serializedData.Length);
            this.m_networkstream.Flush();
        }

        private string GetCategoryName(int categoryId)
        {
            DataTable categoriesTable = dataSet.Tables["Categories"];
            DataRow[] category = categoriesTable.Select($"category_id = {categoryId}");

            if (category.Length > 0)
            {
                return category[0]["name"].ToString();
            }
            else
            {
                return "Unknown";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_thread = new Thread(new ThreadStart(ServerStart));
            this.m_thread.Start();
        }

        private void SendMonthlyIncomeResponse(string userId, string yearMonth)
        {
            DataTable incomeTable = dataSet.Tables["Income"];
            DataRow[] incomeList = incomeTable.Select($"userId = '{userId}' AND CONVERT(date, 'System.String') LIKE '{yearMonth}%'");
            Packet responsePacket = new Packet();
            responsePacket.type = (int)PacketType.수입월목록요청;

            foreach (DataRow income in incomeList)
            {
                string incomeInfo = $"{income["category_id"]}, {income["amount"]}, {income["description"]}, {income["date"]}";
                responsePacket.message.Add(incomeInfo);
            }

            byte[] serializedData = Packet.Serialize(responsePacket);
            this.m_networkstream.Write(serializedData, 0, serializedData.Length);
            this.m_networkstream.Flush();
        }

        private void SendMonthlyExpenseResponse(string userId, string yearMonth)
        {
            DataTable expensesTable = dataSet.Tables["Expense"];
            DataRow[] expenseList = expensesTable.Select($"userId = '{userId}' AND CONVERT(date, 'System.String') LIKE '{yearMonth}%'");
            Packet responsePacket = new Packet();
            responsePacket.type = (int)PacketType.지출월목록요청;

            foreach (DataRow expense in expenseList)
            {
                string expenseInfo = $"{expense["category_id"]}, {expense["amount"]}, {expense["description"]}, {expense["date"]}";
                responsePacket.message.Add(expenseInfo);
            }

            byte[] serializedData = Packet.Serialize(responsePacket);
            this.m_networkstream.Write(serializedData, 0, serializedData.Length);
            this.m_networkstream.Flush();
        }
    }
}
