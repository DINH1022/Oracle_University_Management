namespace OUM.View
{
    partial class AddEmpForm
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
            CancelBtn = new Button();
            button1 = new Button();
            panel12 = new Panel();
            resetBtn = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            panel4 = new Panel();
            textBox2 = new TextBox();
            label4 = new Label();
            panel5 = new Panel();
            comboBox1 = new ComboBox();
            label5 = new Label();
            panel6 = new Panel();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            panel7 = new Panel();
            textBox3 = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            panel13 = new Panel();
            panel14 = new Panel();
            textBox5 = new TextBox();
            label11 = new Label();
            panel11 = new Panel();
            comboBox3 = new ComboBox();
            label10 = new Label();
            panel10 = new Panel();
            comboBox2 = new ComboBox();
            label9 = new Label();
            panel9 = new Panel();
            textBox4 = new TextBox();
            label8 = new Label();
            panel8 = new Panel();
            label7 = new Label();
            panel12.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Gainsboro;
            CancelBtn.Dock = DockStyle.Right;
            CancelBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBtn.Location = new Point(596, 0);
            CancelBtn.Margin = new Padding(6);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(116, 59);
            CancelBtn.TabIndex = 8;
            CancelBtn.Text = "Hủy";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += Cancel_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Gainsboro;
            button1.Dock = DockStyle.Right;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(828, 0);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(116, 59);
            button1.TabIndex = 6;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            panel12.Controls.Add(CancelBtn);
            panel12.Controls.Add(resetBtn);
            panel12.Controls.Add(button1);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 420);
            panel12.Name = "panel12";
            panel12.Size = new Size(944, 59);
            panel12.TabIndex = 9;
            // 
            // resetBtn
            // 
            resetBtn.BackColor = Color.Gainsboro;
            resetBtn.Dock = DockStyle.Right;
            resetBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resetBtn.Location = new Point(712, 0);
            resetBtn.Margin = new Padding(6);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(116, 59);
            resetBtn.TabIndex = 7;
            resetBtn.Text = "Làm mới";
            resetBtn.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(76, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(260, 38);
            textBox1.TabIndex = 1;
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
            label3.Text = "Mã NLD";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(19, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(336, 38);
            panel4.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(76, 0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(260, 38);
            textBox2.TabIndex = 1;
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
            label4.Text = "Họ Tên";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(textBox2);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(19, 91);
            panel5.Name = "panel5";
            panel5.Size = new Size(336, 38);
            panel5.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Nam ", "Nữ" });
            comboBox1.Location = new Point(103, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(127, 28);
            comboBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(103, 28);
            label5.TabIndex = 0;
            label5.Text = "Giới Tính";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.Controls.Add(comboBox1);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(389, 91);
            panel6.Name = "panel6";
            panel6.Size = new Size(230, 28);
            panel6.TabIndex = 3;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Dock = DockStyle.Left;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(103, 28);
            label6.TabIndex = 0;
            label6.Text = "Ngày Sinh";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Dock = DockStyle.Right;
            dateTimePicker1.Location = new Point(103, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(359, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.Controls.Add(label6);
            panel7.Controls.Add(dateTimePicker1);
            panel7.Location = new Point(389, 32);
            panel7.Name = "panel7";
            panel7.Size = new Size(462, 28);
            panel7.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(76, 0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(260, 38);
            textBox3.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(944, 109);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGoldenrodYellow;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(944, 109);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.Location = new Point(19, 59);
            label2.Name = "label2";
            label2.Size = new Size(602, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập thông tin để tạo người dùng mới trong hệ thống";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 31);
            label1.Name = "label1";
            label1.Size = new Size(170, 28);
            label1.TabIndex = 1;
            label1.Text = "Thêm Nhân Viên";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel13);
            panel3.Controls.Add(panel12);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 109);
            panel3.Name = "panel3";
            panel3.Size = new Size(944, 479);
            panel3.TabIndex = 3;
            // 
            // panel13
            // 
            panel13.Controls.Add(panel14);
            panel13.Controls.Add(panel11);
            panel13.Controls.Add(panel10);
            panel13.Controls.Add(panel9);
            panel13.Controls.Add(panel8);
            panel13.Controls.Add(panel7);
            panel13.Controls.Add(panel6);
            panel13.Controls.Add(panel5);
            panel13.Controls.Add(panel4);
            panel13.Dock = DockStyle.Fill;
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(944, 420);
            panel13.TabIndex = 10;
            // 
            // panel14
            // 
            panel14.Controls.Add(textBox5);
            panel14.Controls.Add(label11);
            panel14.Location = new Point(19, 275);
            panel14.Name = "panel14";
            panel14.Size = new Size(336, 38);
            panel14.TabIndex = 6;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Dock = DockStyle.Fill;
            textBox5.Location = new Point(76, 0);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(260, 38);
            textBox5.TabIndex = 1;
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
            label11.Text = "Phụ Cấp";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            panel11.Controls.Add(comboBox3);
            panel11.Controls.Add(label10);
            panel11.Location = new Point(389, 215);
            panel11.Name = "panel11";
            panel11.Size = new Size(230, 28);
            panel11.TabIndex = 5;
            // 
            // comboBox3
            // 
            comboBox3.Dock = DockStyle.Fill;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "NVCB", "GV", "NV PĐT", "..." });
            comboBox3.Location = new Point(103, 0);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(127, 28);
            comboBox3.TabIndex = 1;
            // 
            // label10
            // 
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.Dock = DockStyle.Left;
            label10.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(103, 28);
            label10.TabIndex = 0;
            label10.Text = "Vai Trò";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            panel10.Controls.Add(comboBox2);
            panel10.Controls.Add(label9);
            panel10.Location = new Point(389, 153);
            panel10.Name = "panel10";
            panel10.Size = new Size(230, 28);
            panel10.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "CNTT", "Toán", "Sinh Học", "Hóa Học" });
            comboBox2.Location = new Point(103, 0);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(127, 28);
            comboBox2.TabIndex = 1;
            // 
            // label9
            // 
            label9.BorderStyle = BorderStyle.FixedSingle;
            label9.Dock = DockStyle.Left;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(103, 28);
            label9.TabIndex = 0;
            label9.Text = "Mã ĐV";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            panel9.Controls.Add(textBox4);
            panel9.Controls.Add(label8);
            panel9.Location = new Point(19, 215);
            panel9.Name = "panel9";
            panel9.Size = new Size(336, 38);
            panel9.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Dock = DockStyle.Fill;
            textBox4.Location = new Point(76, 0);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(260, 38);
            textBox4.TabIndex = 1;
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
            label8.Text = "Lương";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Controls.Add(textBox3);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(19, 153);
            panel8.Name = "panel8";
            panel8.Size = new Size(336, 38);
            panel8.TabIndex = 2;
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
            label7.Text = "SĐT";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddEmpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 588);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "AddEmpForm";
            Text = "AddEmpForm";
            panel12.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel11.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button CancelBtn;
        private Button button1;
        private Panel panel12;
        private Button resetBtn;
        private TextBox textBox1;
        private Label label3;
        private Panel panel4;
        private TextBox textBox2;
        private Label label4;
        private Panel panel5;
        private ComboBox comboBox1;
        private Label label5;
        private Panel panel6;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private Panel panel7;
        private TextBox textBox3;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Panel panel3;
        private Panel panel13;
        private Panel panel14;
        private TextBox textBox5;
        private Label label11;
        private Panel panel11;
        private ComboBox comboBox3;
        private Label label10;
        private Panel panel9;
        private TextBox textBox4;
        private Label label8;
        private Panel panel8;
        private Label label7;
        private Panel panel10;
        private ComboBox comboBox2;
        private Label label9;
    }
}