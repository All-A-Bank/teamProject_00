using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketClass;

namespace teamProject_00
{
    public partial class ReportForm : Form
    {

        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private string userId;

        private byte[] readBuffer = new byte[1024 * 4];

        public ReportForm(NetworkStream networkStream, TcpClient client, string userId)
        {
            InitializeComponent();
            this.m_networkStream = networkStream;
            this.m_client = client;
            this.userId = userId;

            // Initialize ListView
            lvwTransactions.View = View.Details;
            lvwTransactions.Columns.Add("유형", 100);
            lvwTransactions.Columns.Add("카테고리", 100);
            lvwTransactions.Columns.Add("가격", 100);
            lvwTransactions.Columns.Add("설명", 100);
            lvwTransactions.Columns.Add("날짜", 100);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm(this.m_networkStream, this.m_client, userId);
            mainForm.Show();
            this.Hide();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        

        private void RequestMonthlyTransactionList(string yearMonth)
        {
            lvwTransactions.Items.Clear(); // Clear previous items
            RequestMonthlyIncomeList(yearMonth);
            RequestMonthlyExpenseList(yearMonth);
        }

        private void RequestMonthlyIncomeList(string yearMonth)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.수입월목록요청;
            requestPacket.message.Add(this.userId + "," + yearMonth);

            byte[] serializedData = Packet.Serialize(requestPacket);
            this.m_networkStream.Write(serializedData, 0, serializedData.Length);
            this.m_networkStream.Flush();

            Task.Run(() => ReceiveMonthlyIncomeListResponse());
        }

        private void RequestMonthlyExpenseList(string yearMonth)
        {
            Packet requestPacket = new Packet();
            requestPacket.type = (int)PacketType.지출월목록요청;
            requestPacket.message.Add(this.userId + "," + yearMonth);

            byte[] serializedData = Packet.Serialize(requestPacket);
            this.m_networkStream.Write(serializedData, 0, serializedData.Length);
            this.m_networkStream.Flush();

            Task.Run(() => ReceiveMonthlyExpenseListResponse());
        }

        private void ReceiveMonthlyIncomeListResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.수입월목록요청)
                {
                    List<string> msgList = responsePacket.message;

                    // Invoke 메서드를 사용하여 UI 업데이트
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        foreach (string msg in msgList)
                        {
                            string[] data = msg.Split(',');

                            string categoryId = data[0];
                            string categoryName = GetCategoryName(categoryId);
                            string amount = data[1];
                            string description = data[2];
                            string date = data[3];

                            ListViewItem lvwItem = new ListViewItem("수입");
                            lvwItem.SubItems.Add(categoryName);
                            lvwItem.SubItems.Add(amount);
                            lvwItem.SubItems.Add(description);
                            lvwItem.SubItems.Add(date);

                            lvwTransactions.Items.Add(lvwItem);
                        }
                    }));
                }
            }
        }

        private void ReceiveMonthlyExpenseListResponse()
        {
            int bytesRead = this.m_networkStream.Read(this.readBuffer, 0, this.readBuffer.Length);
            if (bytesRead > 0)
            {
                Packet responsePacket = (Packet)Packet.Desserialize(this.readBuffer);

                if ((PacketType)responsePacket.type == PacketType.지출월목록요청)
                {
                    List<string> msgList = responsePacket.message;

                    // Invoke 메서드를 사용하여 UI 업데이트
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        foreach (string msg in msgList)
                        {
                            string[] data = msg.Split(',');

                            string categoryId = data[0];
                            string categoryName = GetCategoryName(categoryId);
                            string amount = data[1];
                            string description = data[2];
                            string date = data[3];

                            ListViewItem lvwItem = new ListViewItem("지출");
                            lvwItem.SubItems.Add(categoryName);
                            lvwItem.SubItems.Add(amount);
                            lvwItem.SubItems.Add(description);
                            lvwItem.SubItems.Add(date);

                            lvwTransactions.Items.Add(lvwItem);
                        }
                    }));
                }
            }
        }

        private string GetCategoryName(string categoryId)
        {
            switch (categoryId)
            {
                case "1":
                    return "식비";
                case "2":
                    return "교통비";
                case "3":
                    return "여가생활";
                case "4":
                    return "급여";
                case "5":
                    return "연금";
                default:
                    return "기타";
            }

        }

      

      

        private void btn_MonthlyData_Click(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = (DateTimePicker)this.Controls["dateTimePicker"];
            string yearMonth = dateTimePicker.Value.ToString("yyyy-MM");
            RequestMonthlyTransactionList(yearMonth);
        }

        private void btn_import_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV 파일 (*.csv)|*.csv",
                Title = "CSV 파일 열기"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lvwTransactions.Items.Clear();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
                {
                    string line;
                    bool isFirstLine = true;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue; // 첫 번째 줄은 헤더이므로 건너뜁니다.
                        }

                        string[] values = line.Split(',');
                        if (values.Length == 5)
                        {
                            ListViewItem lvwItem = new ListViewItem(values[0]);
                            lvwItem.SubItems.Add(values[1]);
                            lvwItem.SubItems.Add(values[2]);
                            lvwItem.SubItems.Add(values[3]);
                            lvwItem.SubItems.Add(values[4]);
                            lvwTransactions.Items.Add(lvwItem);
                        }
                    }
                }
                MessageBox.Show("CSV 파일에서 데이터를 불러왔습니다.");
            }
        }

        private void btn_export_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV 파일 (*.csv)|*.csv",
                Title = "CSV 파일로 저장"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("유형,카테고리,가격,설명,날짜");
                    foreach (ListViewItem item in lvwTransactions.Items)
                    {
                        string[] subItems = new string[item.SubItems.Count];
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            subItems[i] = item.SubItems[i].Text;
                        }
                        string line = string.Join(",", subItems);
                        sw.WriteLine(line);
                    }
                }
                MessageBox.Show("CSV 파일로 저장되었습니다.");
            }

        }
    }
}
