using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teamProject_00
{
    public partial class mainForm : Form
    {

        DataSet1 dataset;

        public mainForm()
        {
            InitializeComponent();

            dataset = new DataSet1();

            // 유저
            DataTable personTable = new DataTable("Person");
            personTable.Columns.Add("person_id", typeof(int)).AutoIncrement = true;
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

            dataset.Tables.Add(personTable);
            dataset.Tables.Add(categoriesTable);
            dataset.Tables.Add(budgetsTable);
            dataset.Tables.Add(expensesTable);
            dataset.Tables.Add(incomeTable);

            // 외래 키 설정
            DataRelation categoryBudgetRelation = new DataRelation("CategoryBudget",categoriesTable.Columns["category_id"], budgetsTable.Columns["category_id"]);
            DataRelation categoryExpenseRelation = new DataRelation("CategoryExpense",categoriesTable.Columns["category_id"], expensesTable.Columns["category_id"]);
            DataRelation categoryIncomeRelation = new DataRelation("CategoryIncome",categoriesTable.Columns["category_id"], incomeTable.Columns["category_id"]);

            dataset.Relations.Add(categoryBudgetRelation);
            dataset.Relations.Add(categoryExpenseRelation);
            dataset.Relations.Add(categoryIncomeRelation);

        }

        public void AddPerson(string name)
        {
            dataset.Tables["Person"].Rows.Add(null, name);
            label_name.Text = dataset.Tables["Person"].Rows[0]["name"].ToString();
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

        private void mainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
