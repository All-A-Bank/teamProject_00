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
    public partial class InOutAddForm : Form
    {
        private DataSet1 dataSet;
        public InOutAddForm(DataSet1 dataSet)
        {
            InitializeComponent();
            this.dataSet = dataSet;
        }

        private void InOutAddFrom_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Add("Income");
            comboBoxType.Items.Add("Expense");

            dataGridView1.DataSource = dataSet.Tables["Income"];
        }

       


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               
                string type = comboBoxType.SelectedItem.ToString();

               
                if (type == "Income")
                {
                    // Add a new row to the Income table
                    DataRow newRow = dataSet.Tables["Income"].NewRow();
                    newRow["category_id"] = txtcategory.Text;
                    newRow["amount"] = txtprice.Text;
                    newRow["description"] = txtdecript.Text;
                    newRow["date"] = dateTimePicker.Text;
                    dataSet.Tables["Income"].Rows.Add(newRow);
                }
                else if (type == "Expense")
                {
                    // Add a new row to the Expenses table
                    DataRow newRow = dataSet.Tables["Expenses"].NewRow();
                    newRow["category_id"] = txtcategory.Text;
                    newRow["amount"] = txtprice.Text;
                    newRow["description"] = txtdecript.Text;
                    newRow["date"] = dateTimePicker.Value;
                    //newRow["date"] = DateTime.Now;
                    dataSet.Tables["Expenses"].Rows.Add(newRow);
                }

               

                MessageBox.Show("레코드가 성공적으로 추가되었습니다.");
                this.Close(); // Close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류: " + ex.Message);
            }
        }
    }
        
}
