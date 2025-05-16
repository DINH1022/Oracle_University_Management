namespace OUM.View
{
    partial class AddCourseForm
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
            label2 = new Label();
            label1 = new Label();
            panel13 = new Panel();
            panel12 = new Panel();
            CancelBtn = new Button();
            addBtn = new Button();
            panel9 = new Panel();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            txtLuong = new TextBox();
            label8 = new Label();
            panel8 = new Panel();
            textBox3 = new TextBox();
            label7 = new Label();
            panel5 = new Panel();
            comboBox2 = new ComboBox();
            label4 = new Label();
            panel4 = new Panel();
            comboBox1 = new ComboBox();
            label3 = new Label();
            panel2.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGoldenrodYellow;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 109);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(19, 59);
            label2.Name = "label2";
            label2.Size = new Size(602, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập thông tin để tạo mở môn mới dùng mới trong hệ thống";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 31);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 1;
            label1.Text = "Mở môn học";
            label1.Click += label1_Click;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel12);
            panel13.Controls.Add(panel9);
            panel13.Controls.Add(panel8);
            panel13.Controls.Add(panel5);
            panel13.Controls.Add(panel4);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 109);
            panel13.Name = "panel13";
            panel13.Size = new Size(800, 341);
            panel13.TabIndex = 11;
            // 
            // panel12
            // 
            panel12.Controls.Add(CancelBtn);
            panel12.Controls.Add(addBtn);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 282);
            panel12.Name = "panel12";
            panel12.Size = new Size(800, 59);
            panel12.TabIndex = 11;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Gainsboro;
            CancelBtn.Dock = DockStyle.Right;
            CancelBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBtn.Location = new Point(568, 0);
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
            addBtn.Location = new Point(684, 0);
            addBtn.Margin = new Padding(6);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(116, 59);
            addBtn.TabIndex = 6;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(textBox2);
            panel9.Controls.Add(textBox1);
            panel9.Controls.Add(txtLuong);
            panel9.Controls.Add(label8);
            panel9.Location = new Point(19, 233);
            panel9.Name = "panel9";
            panel9.Size = new Size(336, 38);
            panel9.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(76, 0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(260, 38);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(76, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(260, 38);
            textBox1.TabIndex = 2;
            // 
            // txtLuong
            // 
            txtLuong.BorderStyle = BorderStyle.FixedSingle;
            txtLuong.Dock = DockStyle.Fill;
            txtLuong.Location = new Point(76, 0);
            txtLuong.Multiline = true;
            txtLuong.Name = "txtLuong";
            txtLuong.Size = new Size(260, 38);
            txtLuong.TabIndex = 1;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Dock = DockStyle.Left;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(76, 38);
            label8.TabIndex = 0;
            label8.Text = "Năm";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Controls.Add(textBox3);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(19, 171);
            panel8.Name = "panel8";
            panel8.Size = new Size(336, 38);
            panel8.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(76, 0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(260, 38);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(76, 38);
            label7.TabIndex = 0;
            label7.Text = "HK";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(comboBox2);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(19, 109);
            panel5.Name = "panel5";
            panel5.Size = new Size(336, 38);
            panel5.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(76, 7);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(260, 28);
            comboBox2.TabIndex = 1;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(76, 38);
            label4.TabIndex = 0;
            label4.Text = "MAGV";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBox1);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(19, 50);
            panel4.Name = "panel4";
            panel4.Size = new Size(336, 38);
            panel4.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboBox1.Location = new Point(76, 0);
            comboBox1.Margin = new Padding(0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(260, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(76, 38);
            label3.TabIndex = 0;
            label3.Text = "MaHP";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddCourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel13);
            Controls.Add(panel2);
            Name = "AddCourseForm";
            Text = "AddCourseForm";
            Load += AddCourseForm_Load_1;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel13.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label2;
        private Label label1;
        private Panel panel13;
        private Panel panel9;
        private TextBox txtLuong;
        private Label label8;
        private Panel panel8;
        private Label label7;
        private Panel panel5;
        private Label label4;
        private Panel panel4;
        private ComboBox comboBox1;
        private Label label3;
        private ComboBox comboBox2;
        private Panel panel12;
        private Button CancelBtn;
        private Button addBtn;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox3;
    }
}