namespace teamProject_00
{
    partial class chart_Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo_all = new System.Windows.Forms.RadioButton();
            this.rdo_out = new System.Windows.Forms.RadioButton();
            this.rdo_in = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(39, 22);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(378, 283);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_all);
            this.groupBox1.Controls.Add(this.rdo_out);
            this.groupBox1.Controls.Add(this.rdo_in);
            this.groupBox1.Location = new System.Drawing.Point(463, 155);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(214, 44);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "필터";
            // 
            // rdo_all
            // 
            this.rdo_all.AutoSize = true;
            this.rdo_all.Checked = true;
            this.rdo_all.Location = new System.Drawing.Point(126, 19);
            this.rdo_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdo_all.Name = "rdo_all";
            this.rdo_all.Size = new System.Drawing.Size(47, 16);
            this.rdo_all.TabIndex = 2;
            this.rdo_all.TabStop = true;
            this.rdo_all.Text = "전체";
            this.rdo_all.UseVisualStyleBackColor = true;
            this.rdo_all.CheckedChanged += new System.EventHandler(this.rdo_all_CheckedChanged_1);
            // 
            // rdo_out
            // 
            this.rdo_out.AutoSize = true;
            this.rdo_out.Location = new System.Drawing.Point(59, 19);
            this.rdo_out.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdo_out.Name = "rdo_out";
            this.rdo_out.Size = new System.Drawing.Size(47, 16);
            this.rdo_out.TabIndex = 1;
            this.rdo_out.Text = "지출";
            this.rdo_out.UseVisualStyleBackColor = true;
            this.rdo_out.CheckedChanged += new System.EventHandler(this.rdo_out_CheckedChanged_1);
            // 
            // rdo_in
            // 
            this.rdo_in.AutoSize = true;
            this.rdo_in.Location = new System.Drawing.Point(6, 18);
            this.rdo_in.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdo_in.Name = "rdo_in";
            this.rdo_in.Size = new System.Drawing.Size(47, 16);
            this.rdo_in.TabIndex = 0;
            this.rdo_in.Text = "수입";
            this.rdo_in.UseVisualStyleBackColor = true;
            this.rdo_in.CheckedChanged += new System.EventHandler(this.rdo_in_CheckedChanged_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(463, 108);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(568, 22);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(120, 42);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "뒤로";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // chart_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "chart_Form";
            this.Text = "chartForm";
            this.Load += new System.EventHandler(this.chart_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo_all;
        private System.Windows.Forms.RadioButton rdo_out;
        private System.Windows.Forms.RadioButton rdo_in;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_exit;
    }
}