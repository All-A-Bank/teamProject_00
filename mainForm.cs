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
        public mainForm()
        {
            InitializeComponent();
        }

        private void btn_InOut_Click(object sender, EventArgs e)
        {
            InOutForm inOutForm = new InOutForm();
            inOutForm.Show();
            this.Hide();

        }
    }
}
