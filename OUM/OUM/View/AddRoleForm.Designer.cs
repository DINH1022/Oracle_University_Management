namespace OUM.View
{
    partial class AddRoleForm
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
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            panel13 = new Panel();
            txtRoleName = new TextBox();
            panel12 = new Panel();
            CancelBtn = new Button();
            addBtn = new Button();
            panel1 = new Panel();
            label3 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGoldenrodYellow;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(367, 80);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 26);
            label1.Name = "label1";
            label1.Size = new Size(135, 28);
            label1.TabIndex = 1;
            label1.Text = "Thêm Vai Trò";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 18);
            label2.Name = "label2";
            label2.Size = new Size(254, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập tên cho role mới ";
            label2.Click += label2_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel13);
            panel3.Controls.Add(panel12);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 81);
            panel3.Name = "panel3";
            panel3.Size = new Size(367, 278);
            panel3.TabIndex = 5;
            // 
            // panel13
            // 
            panel13.Controls.Add(label3);
            panel13.Controls.Add(label2);
            panel13.Controls.Add(txtRoleName);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(367, 219);
            panel13.TabIndex = 10;
            // 
            // txtRoleName
            // 
            txtRoleName.AllowDrop = true;
            txtRoleName.Location = new Point(60, 87);
            txtRoleName.Multiline = true;
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(246, 37);
            txtRoleName.TabIndex = 0;
            txtRoleName.TextChanged += txtRoleName_TextChanged;
            // 
            // panel12
            // 
            panel12.Controls.Add(CancelBtn);
            panel12.Controls.Add(addBtn);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 219);
            panel12.Name = "panel12";
            panel12.Size = new Size(367, 59);
            panel12.TabIndex = 9;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Gainsboro;
            CancelBtn.Dock = DockStyle.Right;
            CancelBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBtn.Location = new Point(135, 0);
            CancelBtn.Margin = new Padding(6);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(116, 59);
            CancelBtn.TabIndex = 8;
            CancelBtn.Text = "Quay lại";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.Gainsboro;
            addBtn.Dock = DockStyle.Right;
            addBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addBtn.Location = new Point(251, 0);
            addBtn.Margin = new Padding(6);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(116, 59);
            addBtn.TabIndex = 6;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(367, 81);
            panel1.TabIndex = 4;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 51);
            label3.Name = "label3";
            label3.Size = new Size(325, 20);
            label3.TabIndex = 2;
            label3.Text = "Lưu ý : Tên role sẽ tự động thêm tiền tố 'ROLE_'";
            // 
            // AddRoleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 359);
            Controls.Add(panel3);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "AddRoleForm";
            Text = "AddRoleForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel12.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label2;
        private Label label1;
        private Panel panel3;
        private Panel panel13;
        private TextBox txtRoleName;
        private Panel panel12;
        private Button CancelBtn;
        private Button addBtn;
        private Panel panel1;
        private Label label3;
    }
}