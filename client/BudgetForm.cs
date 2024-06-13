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
    public partial class BudgetForm : Form
    {
        public BudgetForm()
        {
            InitializeComponent();
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
            mainForm mainForm = new mainForm();
            mainForm.Show();
            this.Hide();
        }

        private void BudgetSetting_btn_Click(object sender, EventArgs e)
        {
            BudgetSettingForm budgetSettingForm = new BudgetSettingForm();
            budgetSettingForm.ShowDialog();

        }
    }
}
