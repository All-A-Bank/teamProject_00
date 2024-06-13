namespace teamProject_00
{
    partial class BudgetForm
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BudgetSetting_btn = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(101, 9);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "남은 예산: ₩";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 186);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "오늘까지 지출: ₩";
            // 
            // BudgetSetting_btn
            // 
            this.BudgetSetting_btn.Location = new System.Drawing.Point(81, 236);
            this.BudgetSetting_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BudgetSetting_btn.Name = "BudgetSetting_btn";
            this.BudgetSetting_btn.Size = new System.Drawing.Size(73, 27);
            this.BudgetSetting_btn.TabIndex = 3;
            this.BudgetSetting_btn.Text = "예산 설정";
            this.BudgetSetting_btn.UseVisualStyleBackColor = true;
            this.BudgetSetting_btn.Click += new System.EventHandler(this.BudgetSetting_btn_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(400, 11);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(69, 27);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "뒤로";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // BudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 289);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.BudgetSetting_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BudgetForm";
            this.Text = "Budget";
            this.Load += new System.EventHandler(this.BudgetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BudgetSetting_btn;
        private System.Windows.Forms.Button btn_exit;
    }
}