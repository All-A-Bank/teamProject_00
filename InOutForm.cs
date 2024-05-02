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
        public InOutForm()
        {
            InitializeComponent();
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
    }
}
