namespace teamProject_00
{
    partial class mainForm
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
            this.btn_InOut = new System.Windows.Forms.Button();
            this.btn_budget = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.label_name = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nowDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSetBudget = new System.Windows.Forms.Label();
            this.lblRemainBudget = new System.Windows.Forms.Label();
            this.lvwExpense = new System.Windows.Forms.ListView();
            this.lvwIncome = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_InOut
            // 
            this.btn_InOut.Location = new System.Drawing.Point(699, 165);
            this.btn_InOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_InOut.Name = "btn_InOut";
            this.btn_InOut.Size = new System.Drawing.Size(128, 61);
            this.btn_InOut.TabIndex = 0;
            this.btn_InOut.Text = "수입 / 지출";
            this.btn_InOut.UseVisualStyleBackColor = true;
            this.btn_InOut.Click += new System.EventHandler(this.btn_InOut_Click);
            // 
            // btn_budget
            // 
            this.btn_budget.Location = new System.Drawing.Point(699, 260);
            this.btn_budget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_budget.Name = "btn_budget";
            this.btn_budget.Size = new System.Drawing.Size(128, 48);
            this.btn_budget.TabIndex = 1;
            this.btn_budget.Text = "예산";
            this.btn_budget.UseVisualStyleBackColor = true;
            this.btn_budget.Click += new System.EventHandler(this.btn_budget_Click);
            // 
            // btn_report
            // 
            this.btn_report.Location = new System.Drawing.Point(699, 330);
            this.btn_report.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(128, 38);
            this.btn_report.TabIndex = 2;
            this.btn_report.Text = "보고서";
            this.btn_report.UseVisualStyleBackColor = true;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(627, 11);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(0, 15);
            this.label_name.TabIndex = 4;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(574, 11);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(57, 15);
            this.lbl_name.TabIndex = 5;
            this.lbl_name.Text = "name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "남은 예산 :";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "지출";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 291);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "수입";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "날짜 : ";
            // 
            // nowDate
            // 
            this.nowDate.AutoSize = true;
            this.nowDate.Location = new System.Drawing.Point(75, 14);
            this.nowDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nowDate.Name = "nowDate";
            this.nowDate.Size = new System.Drawing.Size(0, 15);
            this.nowDate.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "설정한 예산 :";
            // 
            // lblSetBudget
            // 
            this.lblSetBudget.AutoSize = true;
            this.lblSetBudget.Location = new System.Drawing.Point(115, 36);
            this.lblSetBudget.Name = "lblSetBudget";
            this.lblSetBudget.Size = new System.Drawing.Size(15, 15);
            this.lblSetBudget.TabIndex = 16;
            this.lblSetBudget.Text = "0";
            // 
            // lblRemainBudget
            // 
            this.lblRemainBudget.AutoSize = true;
            this.lblRemainBudget.Location = new System.Drawing.Point(102, 68);
            this.lblRemainBudget.Name = "lblRemainBudget";
            this.lblRemainBudget.Size = new System.Drawing.Size(15, 15);
            this.lblRemainBudget.TabIndex = 17;
            this.lblRemainBudget.Text = "0";
            // 
            // lvwExpense
            // 
            this.lvwExpense.HideSelection = false;
            this.lvwExpense.Location = new System.Drawing.Point(23, 126);
            this.lvwExpense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwExpense.Name = "lvwExpense";
            this.lvwExpense.Size = new System.Drawing.Size(497, 143);
            this.lvwExpense.TabIndex = 18;
            this.lvwExpense.UseCompatibleStateImageBehavior = false;
            // 
            // lvwIncome
            // 
            this.lvwIncome.HideSelection = false;
            this.lvwIncome.Location = new System.Drawing.Point(23, 326);
            this.lvwIncome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwIncome.Name = "lvwIncome";
            this.lvwIncome.Size = new System.Drawing.Size(497, 143);
            this.lvwIncome.TabIndex = 19;
            this.lvwIncome.UseCompatibleStateImageBehavior = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 524);
            this.Controls.Add(this.lvwIncome);
            this.Controls.Add(this.lvwExpense);
            this.Controls.Add(this.lblRemainBudget);
            this.Controls.Add(this.lblSetBudget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nowDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.btn_budget);
            this.Controls.Add(this.btn_InOut);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainForm";
            this.Text = "main_Form";
            this.Activated += new System.EventHandler(this.mainForm_Activated);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_InOut;
        private System.Windows.Forms.Button btn_budget;
        private System.Windows.Forms.Button btn_report;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label nowDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSetBudget;
        private System.Windows.Forms.Label lblRemainBudget;
        private System.Windows.Forms.ListView lvwExpense;
        private System.Windows.Forms.ListView lvwIncome;
    }
}