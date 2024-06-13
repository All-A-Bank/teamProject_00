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
    public partial class InOutForm : Form
    {
        private DataSet1 dataSet;
        public InOutForm()
        {
            InitializeComponent();

            //dataGridView1.DataSource = dataSet.Tables["Expenses"];
            //dataGridView2.DataSource = dataSet.Tables["Income"];
        }

        private void chart_Click(object sender, EventArgs e)
        {
            chart_Form chart_Form = new chart_Form();
            chart_Form.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InOutAddForm inoutaddForm = new InOutAddForm(this.dataSet);
            inoutaddForm.ShowDialog();
        }

        private void ShowSelectedExpenses(DateTime selectedDate)
        {
            // 선택된 날짜와 일치하는 지출 데이터 가져오기
            DataRow[] selectedExpenses = dataSet.Tables["Expenses"].Select("date >= '" + selectedDate.ToString("yyyy-MM-dd") + "' AND date < '" + selectedDate.AddDays(1).ToString("yyyy-MM-dd") + "'", "date ASC");

            // ListView에 데이터 표시
            listView1.Items.Clear(); // 기존 데이터 지우기

            foreach (DataRow expense in selectedExpenses)
            {
                ListViewItem item = new ListViewItem(expense["expense_id"].ToString());
                item.SubItems.Add(expense["category_id"].ToString());
                item.SubItems.Add(expense["amount"].ToString());
                item.SubItems.Add(expense["description"].ToString());
                item.SubItems.Add(((DateTime)expense["date"]).ToShortDateString()); // 날짜를 원하는 형식으로 표시
                listView1.Items.Add(item);
            }
        }

        private void ShowSelectedIncome(DateTime selectedDate)
        {
            // 선택된 날짜와 일치하는 수입 데이터 가져오기
            DataRow[] selectedIncome = dataSet.Tables["Income"].Select("date >= '" + selectedDate.ToString("yyyy-MM-dd") + "' AND date < '" + selectedDate.AddDays(1).ToString("yyyy-MM-dd") + "'", "date ASC");

            // ListView에 데이터 표시
            listView2.Items.Clear(); // 기존 데이터 지우기

            foreach (DataRow income in selectedIncome)
            {
                ListViewItem item = new ListViewItem(income["income_id"].ToString());
                item.SubItems.Add(income["category_id"].ToString());
                item.SubItems.Add(income["amount"].ToString());
                item.SubItems.Add(income["description"].ToString());
                item.SubItems.Add(((DateTime)income["date"]).ToShortDateString()); // 날짜를 원하는 형식으로 표시
                listView2.Items.Add(item);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // 선택된 날짜
            DateTime selectedDate = dateTimePicker1.Value.Date;
            ShowSelectedExpenses(selectedDate);
            ShowSelectedIncome(selectedDate);
        }
    }
}
