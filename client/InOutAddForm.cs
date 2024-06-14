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


                if (type == "Income")
                {
                    IncomeAdd incomeAdd = new IncomeAdd();
                    incomeAdd.type = (int)PacketType.수입추가;

                    // Parse txtcategory.Text to int for category_id
                    if (int.TryParse(txtcategory.Text, out int categoryId))
                    {
                        incomeAdd.category_id = categoryId;
                    }
                    else
                    {
                        MessageBox.Show("카테고리 ID를 정수로 입력해주세요.");
                        return;
                    }

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

                    incomeAdd.description = txtdecript.Text;
                    incomeAdd.date = dateTimePicker.Value.Date;
                    incomeAdd.userId = userId;

                   // MessageBox.Show(userId);

                    Packet.Serialize(incomeAdd).CopyTo(this.sendBuffer, 0);
                    this.Send();
                }
                else if (type == "Expense")
                {
                    ExpenseAdd expenseAdd = new ExpenseAdd();
                    expenseAdd.type = (int)PacketType.지출추가;

                    // Parse txtcategory.Text to int for category_id
                    if (int.TryParse(txtcategory.Text, out int categoryId))
                    {
                        expenseAdd.category_id = categoryId;
                    }
                    else
                    {
                        MessageBox.Show("카테고리 ID를 정수로 입력해주세요.");
                        return;
                    }

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

                    expenseAdd.description = txtdecript.Text;
                    expenseAdd.date = dateTimePicker.Value.Date;
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
