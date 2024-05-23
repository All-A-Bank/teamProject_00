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
    public partial class initForm : Form
    {
        public initForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;

            mainForm main = new mainForm();
            main.AddPerson(name);
            main.Show();
            this.Hide();
        }

        private void initForm_Load(object sender, EventArgs e)
        {
            textBox_name.Focus();
        }
    }
}
