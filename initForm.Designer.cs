namespace teamProject_00
{
    partial class initForm
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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 40F);
            this.label1.Location = new System.Drawing.Point(198, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "All A Bank";
            // 
            // button_Init
            // 
            this.button_Init.Location = new System.Drawing.Point(272, 232);
            this.button_Init.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Init.Name = "button_Init";
            this.button_Init.Size = new System.Drawing.Size(125, 51);
            this.button_Init.TabIndex = 3;
            this.button_Init.Text = "들어가기";
            this.button_Init.UseVisualStyleBackColor = true;
            this.button_Init.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(240, 148);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(176, 21);
            this.textBox_name.TabIndex = 2;
            this.textBox_name.Text = "이름을 입력해주세요!";
            // 
            // initForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 360);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_Init);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "initForm";
            this.Text = "initial_Form";
            this.Load += new System.EventHandler(this.initForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Init;
        private System.Windows.Forms.TextBox textBox_name;
    }
}

