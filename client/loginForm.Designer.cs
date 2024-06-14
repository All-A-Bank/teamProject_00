namespace teamProject_00
{
    partial class loginForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_Init = new System.Windows.Forms.Button();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_PWD = new System.Windows.Forms.TextBox();
            this.btn_signup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 40F);
            this.label1.Location = new System.Drawing.Point(283, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "All A Bank";
              // 
            // button_Init
            // 
            this.button_Init.Location = new System.Drawing.Point(504, 348);
            this.button_Init.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Init.Name = "button_Init";
            this.button_Init.Size = new System.Drawing.Size(179, 76);
            this.button_Init.TabIndex = 3;
            this.button_Init.Text = "로그인";
            this.button_Init.UseVisualStyleBackColor = true;
            this.button_Init.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(353, 174);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(250, 28);
            this.textBox_ID.TabIndex = 2;
            this.textBox_ID.Text = "ID 입력하세요.";
            // 
            // textBox_PWD
            // 
            this.textBox_PWD.Location = new System.Drawing.Point(353, 243);
            this.textBox_PWD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_PWD.Name = "textBox_PWD";
            this.textBox_PWD.Size = new System.Drawing.Size(250, 28);
            this.textBox_PWD.TabIndex = 4;
            this.textBox_PWD.Text = "비밀번호 입력하세요.";
            // 
            // btn_signup
            // 
            this.btn_signup.Location = new System.Drawing.Point(246, 348);
            this.btn_signup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Size = new System.Drawing.Size(179, 76);
            this.btn_signup.TabIndex = 5;
            this.btn_signup.Text = "회원가입";
            this.btn_signup.UseVisualStyleBackColor = true;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 540);
            this.Controls.Add(this.btn_signup);
            this.Controls.Add(this.textBox_PWD);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.button_Init);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "loginForm";
            this.Text = "initial_Form";
            this.Load += new System.EventHandler(this.initForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Init;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_PWD;
        private System.Windows.Forms.Button btn_signup;
    }
}

