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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BudgetSetting_btn = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lblSetBudget = new System.Windows.Forms.Label();
            this.lblExpenseAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIncomeAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "설정한 예산: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "오늘까지 지출:";
            // 
            // BudgetSetting_btn
            // 
            this.BudgetSetting_btn.Location = new System.Drawing.Point(133, 159);
            this.BudgetSetting_btn.Margin = new System.Windows.Forms.Padding(2);
            this.BudgetSetting_btn.Name = "BudgetSetting_btn";
            this.BudgetSetting_btn.Size = new System.Drawing.Size(100, 34);
            this.BudgetSetting_btn.TabIndex = 3;
            this.BudgetSetting_btn.Text = "예산 설정";
            this.BudgetSetting_btn.UseVisualStyleBackColor = true;
            this.BudgetSetting_btn.Click += new System.EventHandler(this.BudgetSetting_btn_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(345, 39);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(96, 34);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "뒤로";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lblSetBudget
            // 
            this.lblSetBudget.AutoSize = true;
            this.lblSetBudget.Location = new System.Drawing.Point(205, 39);
            this.lblSetBudget.Name = "lblSetBudget";
            this.lblSetBudget.Size = new System.Drawing.Size(11, 12);
            this.lblSetBudget.TabIndex = 5;
            this.lblSetBudget.Text = "0";
            // 
            // lblExpenseAmount
            // 
            this.lblExpenseAmount.AutoSize = true;
            this.lblExpenseAmount.Location = new System.Drawing.Point(221, 76);
            this.lblExpenseAmount.Name = "lblExpenseAmount";
            this.lblExpenseAmount.Size = new System.Drawing.Size(11, 12);
            this.lblExpenseAmount.TabIndex = 6;
            this.lblExpenseAmount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "오늘까지 수입";
            // 
            // lblIncomeAmount
            // 
            this.lblIncomeAmount.AutoSize = true;
            this.lblIncomeAmount.Location = new System.Drawing.Point(221, 115);
            this.lblIncomeAmount.Name = "lblIncomeAmount";
            this.lblIncomeAmount.Size = new System.Drawing.Size(11, 12);
            this.lblIncomeAmount.TabIndex = 8;
            this.lblIncomeAmount.Text = "0";
            // 
            // BudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 275);
            this.Controls.Add(this.lblIncomeAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblExpenseAmount);
            this.Controls.Add(this.lblSetBudget);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.BudgetSetting_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BudgetForm";
            this.Text = "Budget";
            this.Load += new System.EventHandler(this.BudgetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BudgetSetting_btn;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lblSetBudget;
        private System.Windows.Forms.Label lblExpenseAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIncomeAmount;
    }
}