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
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.lvwTransactions = new System.Windows.Forms.ListView();
            this.btn_exit = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btn_MonthlyData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(92, 308);
            this.btn_import.Margin = new System.Windows.Forms.Padding(4);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(227, 76);
            this.btn_import.TabIndex = 0;
            this.btn_import.Text = "보고서 읽어오기";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click_1);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(92, 470);
            this.btn_export.Margin = new System.Windows.Forms.Padding(4);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(227, 82);
            this.btn_export.TabIndex = 1;
            this.btn_export.Text = "보고서 Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click_1);
            // 
            // lvwTransactions
            // 
            this.lvwTransactions.HideSelection = false;
            this.lvwTransactions.Location = new System.Drawing.Point(507, 80);
            this.lvwTransactions.Margin = new System.Windows.Forms.Padding(4);
            this.lvwTransactions.Name = "lvwTransactions";
            this.lvwTransactions.Size = new System.Drawing.Size(748, 494);
            this.lvwTransactions.TabIndex = 2;
            this.lvwTransactions.UseCompatibleStateImageBehavior = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1114, 13);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4);
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
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_import);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.ListView lvwTransactions;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btn_MonthlyData;
    }
}