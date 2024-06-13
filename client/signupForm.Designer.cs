namespace teamProject_00
{
    partial class signupForm
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
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_PWD = new System.Windows.Forms.TextBox();
            this.btn_signup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(109, 37);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(279, 21);
            this.txt_ID.TabIndex = 0;
            // 
            // txt_PWD
            // 
            this.txt_PWD.Location = new System.Drawing.Point(109, 100);
            this.txt_PWD.Name = "txt_PWD";
            this.txt_PWD.Size = new System.Drawing.Size(279, 21);
            this.txt_PWD.TabIndex = 1;
            // 
            // btn_signup
            // 
            this.btn_signup.Location = new System.Drawing.Point(54, 237);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Size = new System.Drawing.Size(156, 53);
            this.btn_signup.TabIndex = 2;
            this.btn_signup.Text = "회원가입";
            this.btn_signup.UseVisualStyleBackColor = true;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "아이디 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "비밀번호 :";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(266, 237);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(156, 53);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "돌아가기";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "닉네임 :";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(109, 157);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(279, 21);
            this.txt_name.TabIndex = 6;
            // 
            // signupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_signup);
            this.Controls.Add(this.txt_PWD);
            this.Controls.Add(this.txt_ID);
            this.Name = "signupForm";
            this.Text = "signupForm";
            this.Load += new System.EventHandler(this.signupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_PWD;
        private System.Windows.Forms.Button btn_signup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_name;
    }
}