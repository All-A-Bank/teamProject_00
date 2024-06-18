namespace teamProject_00
{
    partial class InOutAddForm
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
            this.txtDate = new System.Windows.Forms.Label();
            this.txtCategoryId = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtIncomeExpense = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.txtdecript = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Location = new System.Drawing.Point(75, 51);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(44, 18);
            this.txtDate.TabIndex = 0;
            this.txtDate.Text = "날짜";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.AutoSize = true;
            this.txtCategoryId.Location = new System.Drawing.Point(51, 162);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(80, 18);
            this.txtCategoryId.TabIndex = 1;
            this.txtCategoryId.Text = "카테고리";
            // 
            // txtAmount
            // 
            this.txtAmount.AutoSize = true;
            this.txtAmount.Location = new System.Drawing.Point(198, 162);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(44, 18);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "금액";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(317, 162);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(44, 18);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "설명";
            // 
            // txtIncomeExpense
            // 
            this.txtIncomeExpense.AutoSize = true;
            this.txtIncomeExpense.Location = new System.Drawing.Point(453, 162);
            this.txtIncomeExpense.Name = "txtIncomeExpense";
            this.txtIncomeExpense.Size = new System.Drawing.Size(88, 18);
            this.txtIncomeExpense.TabIndex = 4;
            this.txtIncomeExpense.Text = "수입/지출";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(242, 318);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 43);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(68, 82);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(277, 28);
            this.dateTimePicker.TabIndex = 6;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(201, 183);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(100, 28);
            this.txtprice.TabIndex = 8;
            // 
            // txtdecript
            // 
            this.txtdecript.Location = new System.Drawing.Point(320, 183);
            this.txtdecript.Name = "txtdecript";
            this.txtdecript.Size = new System.Drawing.Size(100, 28);
            this.txtdecript.TabIndex = 9;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(456, 183);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxType.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(689, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(365, 326);
            this.dataGridView1.TabIndex = 11;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(54, 185);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 26);
            this.comboBoxCategory.TabIndex = 12;
            // 
            // InOutAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 447);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.txtdecript);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtIncomeExpense);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtCategoryId);
            this.Controls.Add(this.txtDate);
            this.Name = "InOutAddForm";
            this.Text = "InOutAddFrom";
            this.Load += new System.EventHandler(this.InOutAddFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtCategoryId;
        private System.Windows.Forms.Label txtAmount;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Label txtIncomeExpense;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.TextBox txtdecript;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxCategory;
    }
}