namespace OUM.View
{
    partial class UpdateCourseForm
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
            label3 = new Label();
            panel4 = new Panel();
            comboBox1 = new ComboBox();
            CancelBtn = new Button();
            addBtn = new Button();
            panel12 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel13 = new Panel();
            panel14 = new Panel();
            txtNam = new TextBox();
            label11 = new Label();
            panel9 = new Panel();
            textBox1 = new TextBox();
            label8 = new Label();
            panel8 = new Panel();
            comboBox3 = new ComboBox();
            label7 = new Label();
            panel5 = new Panel();
            comboBox2 = new ComboBox();
            label4 = new Label();
            panel1 = new Panel();
            txtMaMM = new TextBox();
            label5 = new Label();
            panel4.SuspendLayout();
            panel12.SuspendLayout();
            panel2.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
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
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Gainsboro;
            CancelBtn.Dock = DockStyle.Right;
            CancelBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBtn.Location = new Point(882, 0);
            CancelBtn.Margin = new Padding(6);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(116, 80);
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
            addBtn.Location = new Point(998, 0);
            addBtn.Margin = new Padding(6);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(116, 80);
            addBtn.TabIndex = 6;
            addBtn.Text = "Cập nhật";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // panel12
            // 
            panel12.Controls.Add(CancelBtn);
            panel12.Controls.Add(addBtn);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 485);
            panel12.Name = "panel12";
            panel12.Size = new Size(1114, 80);
            panel12.TabIndex = 11;
            // 
            // label2
            // 
            label2.Location = new Point(19, 59);
            label2.Name = "label2";
            label2.Size = new Size(602, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập thông tin để tạo mở môn mới dùng mới trong hệ thống";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 31);
            label1.Name = "label1";
            label1.Size = new Size(275, 28);
            label1.TabIndex = 1;
            label1.Text = "Cập nhật thông tin mở môn";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGoldenrodYellow;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1114, 109);
            panel2.TabIndex = 12;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel14);
            panel13.Controls.Add(panel9);
            panel13.Controls.Add(panel8);
            panel13.Controls.Add(panel5);
            panel13.Controls.Add(panel1);
            panel13.Controls.Add(panel12);
            panel13.Controls.Add(panel4);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(1114, 565);
            panel13.TabIndex = 13;
            // 
            // panel14
            // 
            panel14.Controls.Add(txtNam);
            panel14.Controls.Add(label11);
            panel14.Location = new Point(56, 392);
            panel14.Name = "panel14";
            panel14.Size = new Size(336, 38);
            panel14.TabIndex = 16;
            // 
            // txtNam
            // 
            txtNam.BorderStyle = BorderStyle.FixedSingle;
            txtNam.Dock = DockStyle.Fill;
            txtNam.Location = new Point(76, 0);
            txtNam.Multiline = true;
            txtNam.Name = "txtNam";
            txtNam.ReadOnly = true;
            txtNam.Size = new Size(260, 38);
            txtNam.TabIndex = 1;
            txtNam.TextChanged += txtNam_TextChanged;
            // 
            // label11
            // 
            label11.BorderStyle = BorderStyle.FixedSingle;
            label11.Dock = DockStyle.Left;
            label11.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(0, 0);
            label11.Name = "label11";
            label11.Size = new Size(76, 38);
            label11.TabIndex = 0;
            label11.Text = "Nam";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            panel9.Controls.Add(textBox1);
            panel9.Controls.Add(label8);
            panel9.Location = new Point(56, 328);
            panel9.Name = "panel9";
            panel9.Size = new Size(336, 38);
            panel9.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(76, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(260, 38);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
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
            label8.Text = "HK";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Controls.Add(comboBox3);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(56, 269);
            panel8.Name = "panel8";
            panel8.Size = new Size(336, 38);
            panel8.TabIndex = 13;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(76, 10);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(260, 28);
            comboBox3.TabIndex = 2;
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
            label7.Text = "MaGV";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(comboBox2);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(56, 203);
            panel5.Name = "panel5";
            panel5.Size = new Size(336, 38);
            panel5.TabIndex = 14;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(76, 10);
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
            label4.Text = "MaHP";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtMaMM);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(56, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 38);
            panel1.TabIndex = 12;
            // 
            // txtMaMM
            // 
            txtMaMM.BorderStyle = BorderStyle.FixedSingle;
            txtMaMM.Dock = DockStyle.Fill;
            txtMaMM.Location = new Point(76, 0);
            txtMaMM.Multiline = true;
            txtMaMM.Name = "txtMaMM";
            txtMaMM.ReadOnly = true;
            txtMaMM.Size = new Size(260, 38);
            txtMaMM.TabIndex = 1;
            txtMaMM.TextChanged += txtMaMM_TextChanged;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 38);
            label5.TabIndex = 0;
            label5.Text = "MaMM";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UpdateCourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 565);
            Controls.Add(panel2);
            Controls.Add(panel13);
            Name = "UpdateCourseForm";
            Text = "UpdateCourseForm";
            Load += UpdateCourseForm_Load;
            panel4.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel13.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Panel panel4;
        private ComboBox comboBox1;
        private Button CancelBtn;
        private Button addBtn;
        private Panel panel12;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Panel panel13;
        private Panel panel14;
        private TextBox txtNam;
        private Label label11;
        private Panel panel9;
        private Label label8;
        private Panel panel8;
        private Label label7;
        private Panel panel5;
        private Label label4;
        private Panel panel1;
        private TextBox txtMaMM;
        private Label label5;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private TextBox textBox1;
    }
}