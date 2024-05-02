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
            this.SuspendLayout();
            // 
            // btn_InOut
            // 
            this.btn_InOut.Location = new System.Drawing.Point(576, 68);
            this.btn_InOut.Name = "btn_InOut";
            this.btn_InOut.Size = new System.Drawing.Size(128, 61);
            this.btn_InOut.TabIndex = 0;
            this.btn_InOut.Text = "수입 / 지출";
            this.btn_InOut.UseVisualStyleBackColor = true;
            this.btn_InOut.Click += new System.EventHandler(this.btn_InOut_Click);
            // 
            // btn_budget
            // 
            this.btn_budget.Location = new System.Drawing.Point(576, 163);
            this.btn_budget.Name = "btn_budget";
            this.btn_budget.Size = new System.Drawing.Size(128, 48);
            this.btn_budget.TabIndex = 1;
            this.btn_budget.Text = "예산";
            this.btn_budget.UseVisualStyleBackColor = true;
            // 
            // btn_report
            // 
            this.btn_report.Location = new System.Drawing.Point(576, 233);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(128, 37);
            this.btn_report.TabIndex = 2;
            this.btn_report.Text = "보고서";
            this.btn_report.UseVisualStyleBackColor = true;
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
            this.listView1.Location = new System.Drawing.Point(12, 108);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(387, 330);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(626, 9);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(0, 15);
            this.label_name.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "잔액 : ";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_report);
            this.Controls.Add(this.btn_budget);
            this.Controls.Add(this.btn_InOut);
            this.Name = "mainForm";
            this.Text = "main_Form";
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
    }
}