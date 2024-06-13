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
    public partial class ExpenseForm : Form
    {
        private DateTime selectedDate;
        public ExpenseForm(DateTime selectedDate)
        {
            InitializeComponent();
            this.selectedDate = selectedDate;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
