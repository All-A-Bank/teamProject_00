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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("날짜");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("이름");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("지출");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("수입");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("잔액");
            this.btn_InOut = new System.Windows.Forms.Button();
            this.btn_budget = new System.Windows.Forms.Button();
            this.btn_report = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btn_InOut
            // 
            this.btn_InOut.Location = new System.Drawing.Point(504, 54);
            this.btn_InOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_InOut.Name = "btn_InOut";
            this.btn_InOut.Size = new System.Drawing.Size(112, 49);
            this.btn_InOut.TabIndex = 0;
            this.btn_InOut.Text = "수입 / 지출";
            this.btn_InOut.UseVisualStyleBackColor = true;
            this.btn_InOut.Click += new System.EventHandler(this.btn_InOut_Click);
            // 
            // btn_budget
            // 
            this.btn_budget.Location = new System.Drawing.Point(504, 130);
            this.btn_budget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_budget.Name = "btn_budget";
            this.btn_budget.Size = new System.Drawing.Size(112, 38);
            this.btn_budget.TabIndex = 1;
            this.btn_budget.Text = "예산";
            this.btn_budget.UseVisualStyleBackColor = true;
            this.btn_budget.Click += new System.EventHandler(this.btn_budget_Click);
            // 
            // btn_report
            // 
            this.btn_report.Location = new System.Drawing.Point(504, 186);
            this.btn_report.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(112, 30);
            this.btn_report.TabIndex = 2;
            this.btn_report.Text = "보고서";
            this.btn_report.UseVisualStyleBackColor = true;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.listView1.Location = new System.Drawing.Point(11, 86);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(339, 265);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(548, 7);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(0, 12);
            this.label_name.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "잔액 : ";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 395);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.btn_budget);
            this.Controls.Add(this.btn_InOut);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainForm";
            this.Text = "main_Form";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_InOut;
        private System.Windows.Forms.Button btn_budget;
        private System.Windows.Forms.Button btn_report;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}