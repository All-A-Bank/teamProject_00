namespace teamProject_00
{
    partial class InOutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.addbutton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwExpense = new System.Windows.Forms.ListView();
            this.lvwIncome = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(427, 76);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.CustomProperties = "pieStartAngel=270";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(246, 192);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(438, 301);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(235, 33);
            this.addbutton.TabIndex = 2;
            this.addbutton.Text = "수입/지출 추가";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(427, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 21);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(624, 5);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(66, 19);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "뒤로";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "지출";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "수입";
            // 
            // lvwExpense
            // 
            this.lvwExpense.HideSelection = false;
            this.lvwExpense.Location = new System.Drawing.Point(12, 24);
            this.lvwExpense.Name = "lvwExpense";
            this.lvwExpense.Size = new System.Drawing.Size(396, 134);
            this.lvwExpense.TabIndex = 19;
            this.lvwExpense.UseCompatibleStateImageBehavior = false;
            // 
            // lvwIncome
            // 
            this.lvwIncome.HideSelection = false;
            this.lvwIncome.Location = new System.Drawing.Point(12, 190);
            this.lvwIncome.Name = "lvwIncome";
            this.lvwIncome.Size = new System.Drawing.Size(396, 123);
            this.lvwIncome.TabIndex = 20;
            this.lvwIncome.UseCompatibleStateImageBehavior = false;
            // 
            // InOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.lvwIncome);
            this.Controls.Add(this.lvwExpense);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.chart1);
            this.Name = "InOutForm";
            this.Text = "InOut_Form";
            this.Load += new System.EventHandler(this.InOutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwExpense;
        private System.Windows.Forms.ListView lvwIncome;
    }
}