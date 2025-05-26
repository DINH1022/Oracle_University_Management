using OUM.View;

namespace OUM
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            userNameTextBox = new TextBox();
            passWordTextBox = new TextBox();
            LoginBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(226, 94);
            label1.Name = "label1";
            label1.Size = new Size(493, 81);
            label1.TabIndex = 0;
            label1.Text = "PORTAL HCMUS";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(328, 190);
            label2.Name = "label2";
            label2.Size = new Size(319, 31);
            label2.TabIndex = 1;
            label2.Text = "Chào mừng đến với hệ thống ";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(239, 246);
            label3.Name = "label3";
            label3.Size = new Size(99, 28);
            label3.TabIndex = 2;
            label3.Text = "Username";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(239, 346);
            label4.Name = "label4";
            label4.Size = new Size(93, 28);
            label4.TabIndex = 3;
            label4.Text = "Password";
            label4.Click += label4_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userNameTextBox.Location = new Point(239, 277);
            userNameTextBox.Multiline = true;
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(467, 43);
            userNameTextBox.TabIndex = 4;
            // 
            // passWordTextBox
            // 
            passWordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passWordTextBox.Location = new Point(239, 377);
            passWordTextBox.Multiline = true;
            passWordTextBox.Name = "passWordTextBox";
            passWordTextBox.PasswordChar = '*';
            passWordTextBox.Size = new Size(467, 43);
            passWordTextBox.TabIndex = 5;
            // 
            // LoginBtn
            // 
            LoginBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginBtn.Location = new Point(392, 463);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(158, 55);
            LoginBtn.TabIndex = 6;
            LoginBtn.Text = "Đăng nhập";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += button1_Click;
            LoginBtn.MouseClick += LoginBtn_MouseClick;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(944, 588);
            Controls.Add(label1);
            Controls.Add(LoginBtn);
            Controls.Add(passWordTextBox);
            Controls.Add(userNameTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            MaximizeBox = false;
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginPage";
            Load += button1_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox userNameTextBox;
        private TextBox passWordTextBox;
        private Button LoginBtn;
    }
}
