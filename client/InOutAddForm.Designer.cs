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
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Location = new System.Drawing.Point(196, 25);
            this.txtDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(29, 12);
            this.txtDate.TabIndex = 0;
            this.txtDate.Text = "날짜";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.AutoSize = true;
            this.txtCategoryId.Location = new System.Drawing.Point(180, 99);
            this.txtCategoryId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(53, 12);
            this.txtCategoryId.TabIndex = 1;
            this.txtCategoryId.Text = "카테고리";
            // 
            // txtAmount
            // 
            this.txtAmount.AutoSize = true;
            this.txtAmount.Location = new System.Drawing.Point(283, 99);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(29, 12);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.Text = "금액";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(366, 99);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(29, 12);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "설명";
            // 
            // txtIncomeExpense
            // 
            this.txtIncomeExpense.AutoSize = true;
            this.txtIncomeExpense.Location = new System.Drawing.Point(461, 99);
            this.txtIncomeExpense.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtIncomeExpense.Name = "txtIncomeExpense";
            this.txtIncomeExpense.Size = new System.Drawing.Size(59, 12);
            this.txtIncomeExpense.TabIndex = 4;
            this.txtIncomeExpense.Text = "수입/지출";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(313, 203);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(192, 46);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(195, 21);
            this.dateTimePicker.TabIndex = 6;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(285, 113);
            this.txtprice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(71, 21);
            this.txtprice.TabIndex = 8;
            // 
            // txtdecript
            // 
            this.txtdecript.Location = new System.Drawing.Point(368, 113);
            this.txtdecript.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtdecript.Name = "txtdecript";
            this.txtdecript.Size = new System.Drawing.Size(71, 21);
            this.txtdecript.TabIndex = 9;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(463, 113);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(86, 20);
            this.comboBoxType.TabIndex = 10;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(182, 114);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(86, 20);
            this.comboBoxCategory.TabIndex = 12;
            // 
            // InOutAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 298);
            this.Controls.Add(this.comboBoxCategory);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InOutAddForm";
            this.Text = "InOutAddFrom";
            this.Load += new System.EventHandler(this.InOutAddFrom_Load);
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
        private System.Windows.Forms.ComboBox comboBoxCategory;
    }
}