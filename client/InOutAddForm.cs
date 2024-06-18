using PacketClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teamProject_00
{
    public partial class InOutAddForm : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        public string userId;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;

        public IncomeAdd m_incomeaddClass;
        public ExpenseAdd m_expenseaddClass;

        public void Send()
        {
            try
            {
                this.m_networkStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                this.m_networkStream.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 전송 중 오류가 발생했습니다: " + ex.Message);
                m_bConnect = false;
            }
            finally
            {
                for (int i = 0; i < 1024 * 4; i++)
                {
                    this.sendBuffer[i] = 0;
                }
            }
        }

        public InOutAddForm(TcpClient client, NetworkStream networkStream, String userId)
        {
            InitializeComponent();
            this.m_client = client;
            this.m_networkStream = networkStream;
            this.m_bConnect = client.Connected;
            this.userId = userId;
        }

        private void InOutAddFrom_Load(object sender, EventArgs e)
        {
            comboBoxType.Items.Add("Income");
            comboBoxType.Items.Add("Expense");

            // 카테고리 항목 추가
            comboBoxCategory.Items.Add(new ComboBoxItem("식비", 1));
            comboBoxCategory.Items.Add(new ComboBoxItem("교통비", 2));
            comboBoxCategory.Items.Add(new ComboBoxItem("여가생활", 3));
            comboBoxCategory.Items.Add(new ComboBoxItem("급여", 4));
            comboBoxCategory.Items.Add(new ComboBoxItem("연금", 5));
        }


        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.");
                return;
            }
            try
            {
                string type = comboBoxType.SelectedItem.ToString();

                ComboBoxItem selectedCategory = comboBoxCategory.SelectedItem as ComboBoxItem;
                if (selectedCategory == null)
                {
                    MessageBox.Show("카테고리를 선택해주세요.");
                    return;
                }

                int categoryId = selectedCategory.Value;

                if (type == "Income")
                {
                    IncomeAdd incomeAdd = new IncomeAdd();
                    incomeAdd.type = (int)PacketType.수입추가;

                    // Parse txtprice.Text to int for amount
                    if (int.TryParse(txtprice.Text, out int amount))
                    {
                        incomeAdd.amount = amount;
                    }
                    else
                    {
                        MessageBox.Show("금액을 정수로 입력해주세요.");
                        return;
                    }

                    incomeAdd.category_id = categoryId;
                    incomeAdd.description = txtdecript.Text;
                    incomeAdd.date = dateTimePicker.Value;
                    incomeAdd.userId = userId;

                    Packet.Serialize(incomeAdd).CopyTo(this.sendBuffer, 0);
                    this.Send();
                }
                else if (type == "Expense")
                {
                    ExpenseAdd expenseAdd = new ExpenseAdd();
                    expenseAdd.type = (int)PacketType.지출추가;

                    // Parse txtprice.Text to int for amount
                    if (int.TryParse(txtprice.Text, out int amount))
                    {
                        expenseAdd.amount = amount;
                    }
                    else
                    {
                        MessageBox.Show("금액을 정수로 입력해주세요.");
                        return;
                    }

                    expenseAdd.category_id = categoryId;
                    expenseAdd.description = txtdecript.Text;
                    expenseAdd.date = dateTimePicker.Value;
                    expenseAdd.userId = userId;

                    Packet.Serialize(expenseAdd).CopyTo(this.sendBuffer, 0);
                    this.Send();
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
