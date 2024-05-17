using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace teamProject_00
{
    public partial class chart_Form : Form
    {
        Dictionary<string, float> expense = new Dictionary<string, float>
        {
            {"식비",300.0f },
            {"교통비",150.0f },
            {"주거비",500.0f },
            {"여가비",100.0f }
        };
        public chart_Form()
        {
            InitializeComponent();
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.chart_Form_Paint);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            InOutForm inOutForm = new InOutForm();
            inOutForm.Show();
            this.Hide();
        }

        private void chart_Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//그림 가장자리의 부드러움
            g.Clear(this.BackColor);

            float startAngle = 0f;//파이차트 시작 각도

            float totalExpense = 0f;//총 지출 계산
            foreach (KeyValuePair<string, float> kvp in expense)
            {
                totalExpense += kvp.Value;
            }

            Rectangle pieRectangle = new Rectangle(10,10,200,200);//파이 차트 영역


            foreach (KeyValuePair<string,float> kvp in expense)
            {

                float sweepAngle = (kvp.Value / totalExpense) * 360;//현재 카테고리의 비율
                g.FillPie(new SolidBrush(GetColorForCategory(kvp.Key)), pieRectangle, startAngle, sweepAngle);
                
                //카테고리 이름 표시
                double midAngle = (Math.PI/180.0) * (startAngle + sweepAngle / 2);//파이 조각의 중간 각도
                //카테고리 이름을 그릴 위치
                PointF labelPoint = new PointF(
                    pieRectangle.X + (pieRectangle.Width/2)+(float)(Math.Cos(midAngle)*(pieRectangle.Width/4)),
                    pieRectangle.Y + (pieRectangle.Height / 2) + (float)(Math.Sin(midAngle) * (pieRectangle.Height/4))
                    );//중간점 좌표 계산

               StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(kvp.Key,this.Font, Brushes.Black,labelPoint,format);
                //g.DrawString(kvp.Key, this.Font, new SolidBrush(Color.Black),labelPoint );

                startAngle += sweepAngle;//다음 파이값의 시작 각도 업데이트
            }
   
        }
        private Dictionary<string, Color> categoryColors = new Dictionary<string, Color>();
        private Random rnd = new Random();

        // 카테고리에 대한 색상을 가져오는 함수
        public Color GetColorForCategory(string categoryId)
        {
            // 이미 해당 카테고리에 색상이 할당되었는지 확인
            if (!categoryColors.ContainsKey(categoryId))
            {
                // 색상이 할당되지 않았다면, 새로운 색상 생성
                Color newColor;
                do
                {
                    int r = rnd.Next(256); // Red value (0~255)
                    int g = rnd.Next(256); // Green value (0~255)
                    int b = rnd.Next(256); // Blue value (0~255)
                    newColor = Color.FromArgb(r, g, b);
                }
                // 생성된 색상이 이미 사용된 색상인지 확인 (선택적)
                while (categoryColors.Values.Contains(newColor));

                // 새로운 색상을 카테고리에 할당
                categoryColors[categoryId] = newColor;
            }

            // 할당된 색상 반환
            return categoryColors[categoryId];
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            // 사용자 입력 값을 가져옵니다.
            string category = txtCategory.Text;
            string inputValue = txtValue.Text;
            float value;

            // 입력된 값이 float로 변환 가능한지 확인합니다.
            if (float.TryParse(inputValue, out value))
            {
                // 딕셔너리에 카테고리와 값을 추가합니다.
                // 이미 해당 카테고리가 있는 경우 값을 업데이트하거나 사용자에게 알립니다.
                if (expense.ContainsKey(category))
                {
                    MessageBox.Show("이미 존재하는 카테고리입니다. 다른 이름을 사용해주세요.");
                }
                else
                {
                    expense.Add(category, value);

                    this.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("올바른 숫자 값을 입력해주세요.");
            }
        }

    }
}
