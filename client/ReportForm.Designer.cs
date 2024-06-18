namespace teamProject_00
{
    partial class ReportForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lvwTransactions = new System.Windows.Forms.ListView();
            this.btn_exit = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btn_MonthlyData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 308);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 76);
            this.button1.TabIndex = 0;
            this.button1.Text = "보고서 읽어오기";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 470);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(227, 82);
            this.button2.TabIndex = 1;
            this.button2.Text = "보고서 Export";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lvwTransactions
            // 
            this.lvwTransactions.HideSelection = false;
            this.lvwTransactions.Location = new System.Drawing.Point(507, 80);
            this.lvwTransactions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvwTransactions.Name = "lvwTransactions";
            this.lvwTransactions.Size = new System.Drawing.Size(748, 494);
            this.lvwTransactions.TabIndex = 2;
            this.lvwTransactions.UseCompatibleStateImageBehavior = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1114, 13);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(128, 42);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "뒤로";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "      yyyy-MM";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(25, 167);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(212, 35);
            this.dateTimePicker.TabIndex = 4;
            // 
            // btn_MonthlyData
            // 
            this.btn_MonthlyData.Location = new System.Drawing.Point(291, 159);
            this.btn_MonthlyData.Name = "btn_MonthlyData";
            this.btn_MonthlyData.Size = new System.Drawing.Size(137, 54);
            this.btn_MonthlyData.TabIndex = 5;
            this.btn_MonthlyData.Text = "조회";
            this.btn_MonthlyData.UseVisualStyleBackColor = true;
            this.btn_MonthlyData.Click += new System.EventHandler(this.btn_MonthlyData_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 626);
            this.Controls.Add(this.btn_MonthlyData);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lvwTransactions);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView lvwTransactions;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btn_MonthlyData;
    }
}