namespace OUM.View
{
    partial class UpdateStudentForm
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
            updateBtn = new Button();
            panel12 = new Panel();
            CancelBtn = new Button();
            txtMSSV = new TextBox();
            label3 = new Label();
            panel4 = new Panel();
            txtHoTen = new TextBox();
            label4 = new Label();
            panel5 = new Panel();
            comboGioiTinh = new ComboBox();
            label5 = new Label();
            panel6 = new Panel();
            label6 = new Label();
            dateTimePickerNgaySinh = new DateTimePicker();
            panel7 = new Panel();
            txtSDT = new TextBox();
            panel13 = new Panel();
            panel11 = new Panel();
            comboTinhTrang = new ComboBox();
            label10 = new Label();
            panel10 = new Panel();
            comboKhoa = new ComboBox();
            label9 = new Label();
            panel9 = new Panel();
            txtDiaChi = new TextBox();
            label8 = new Label();
            panel8 = new Panel();
            label7 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            panel12.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel13.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.Gainsboro;
            updateBtn.Dock = DockStyle.Right;
            updateBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateBtn.Location = new Point(828, 0);
            updateBtn.Margin = new Padding(6);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(116, 59);
            updateBtn.TabIndex = 6;
            updateBtn.Text = "Cập nhật";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // panel12
            // 
            panel12.Controls.Add(CancelBtn);
            panel12.Controls.Add(updateBtn);
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 420);
            panel12.Name = "panel12";
            panel12.Size = new Size(944, 59);
            panel12.TabIndex = 9;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Gainsboro;
            CancelBtn.Dock = DockStyle.Right;
            CancelBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBtn.Location = new Point(712, 0);
            CancelBtn.Margin = new Padding(6);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(116, 59);
            CancelBtn.TabIndex = 8;
            CancelBtn.Text = "Hủy";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += cancelBtn_Click;
            // 
            // txtMSSV
            // 
            txtMSSV.BorderStyle = BorderStyle.FixedSingle;
            txtMSSV.Dock = DockStyle.Fill;
            txtMSSV.Location = new Point(62, 0);
            txtMSSV.Multiline = true;
            txtMSSV.Name = "txtMSSV";
            txtMSSV.Size = new Size(192, 38);
            txtMSSV.TabIndex = 1;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(62, 38);
            label3.TabIndex = 0;
            label3.Text = "MSSV";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtMSSV);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(19, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(254, 38);
            panel4.TabIndex = 0;
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Dock = DockStyle.Fill;
            txtHoTen.Location = new Point(62, 0);
            txtHoTen.Multiline = true;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(192, 38);
            txtHoTen.TabIndex = 1;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Left;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(62, 38);
            label4.TabIndex = 0;
            label4.Text = "Họ Tên";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtHoTen);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(19, 91);
            panel5.Name = "panel5";
            panel5.Size = new Size(254, 38);
            panel5.TabIndex = 2;
            // 
            // comboGioiTinh
            // 
            comboGioiTinh.Dock = DockStyle.Fill;
            comboGioiTinh.FormattingEnabled = true;
            comboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboGioiTinh.Location = new Point(103, 0);
            comboGioiTinh.Name = "comboGioiTinh";
            comboGioiTinh.Size = new Size(127, 28);
            comboGioiTinh.TabIndex = 1;
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
            panel6.Controls.Add(comboGioiTinh);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(305, 91);
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
            // dateTimePickerNgaySinh
            // 
            dateTimePickerNgaySinh.Dock = DockStyle.Right;
            dateTimePickerNgaySinh.Location = new Point(103, 0);
            dateTimePickerNgaySinh.Name = "dateTimePickerNgaySinh";
            dateTimePickerNgaySinh.Size = new Size(359, 27);
            dateTimePickerNgaySinh.TabIndex = 4;
            // 
            // panel7
            // 
            panel7.Controls.Add(label6);
            panel7.Controls.Add(dateTimePickerNgaySinh);
            panel7.Location = new Point(305, 32);
            panel7.Name = "panel7";
            panel7.Size = new Size(462, 28);
            panel7.TabIndex = 4;
            // 
            // txtSDT
            // 
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Dock = DockStyle.Fill;
            txtSDT.Location = new Point(62, 0);
            txtSDT.Multiline = true;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(192, 38);
            txtSDT.TabIndex = 1;
            // 
            // panel13
            // 
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
            // panel11
            // 
            panel11.Controls.Add(comboTinhTrang);
            panel11.Controls.Add(label10);
            panel11.Location = new Point(19, 276);
            panel11.Name = "panel11";
            panel11.Size = new Size(230, 28);
            panel11.TabIndex = 5;
            // 
            // comboTinhTrang
            // 
            comboTinhTrang.Dock = DockStyle.Fill;
            comboTinhTrang.FormattingEnabled = true;
            comboTinhTrang.Items.AddRange(new object[] { "đang học", "nghỉ học", "bảo lưu", "đang cập nhật" });
            comboTinhTrang.Location = new Point(103, 0);
            comboTinhTrang.Name = "comboTinhTrang";
            comboTinhTrang.Size = new Size(127, 28);
            comboTinhTrang.TabIndex = 1;
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
            label10.Text = "Tình Trạng";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            panel10.Controls.Add(comboKhoa);
            panel10.Controls.Add(label9);
            panel10.Location = new Point(305, 153);
            panel10.Name = "panel10";
            panel10.Size = new Size(230, 28);
            panel10.TabIndex = 4;
            // 
            // comboKhoa
            // 
            comboKhoa.Dock = DockStyle.Fill;
            comboKhoa.FormattingEnabled = true;
            comboKhoa.Items.AddRange(new object[] { "CNTT", "TOAN", "VL", "HOA", "SINH", "MT", "DC", "VLKT", "DTVT", "KHLN", "KDL" });
            comboKhoa.Location = new Point(103, 0);
            comboKhoa.Name = "comboKhoa";
            comboKhoa.Size = new Size(127, 28);
            comboKhoa.TabIndex = 1;
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
            label9.Text = "Khoa";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            panel9.Controls.Add(txtDiaChi);
            panel9.Controls.Add(label8);
            panel9.Location = new Point(19, 215);
            panel9.Name = "panel9";
            panel9.Size = new Size(748, 38);
            panel9.TabIndex = 5;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Dock = DockStyle.Fill;
            txtDiaChi.Location = new Point(62, 0);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(686, 38);
            txtDiaChi.TabIndex = 1;
            // 
            // label8
            // 
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Dock = DockStyle.Left;
            label8.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(62, 38);
            label8.TabIndex = 0;
            label8.Text = "Địa Chỉ";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.Controls.Add(txtSDT);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(19, 153);
            panel8.Name = "panel8";
            panel8.Size = new Size(254, 38);
            panel8.TabIndex = 2;
            // 
            // label7
            // 
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Dock = DockStyle.Left;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(62, 38);
            label7.TabIndex = 0;
            label7.Text = "SĐT";
            label7.TextAlign = ContentAlignment.MiddleLeft;
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
            label2.Text = "Chỉnh sửa thông tin người dùng trong hệ thống";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 31);
            label1.Name = "label1";
            label1.Size = new Size(202, 28);
            label1.TabIndex = 1;
            label1.Text = "Chỉnh Sửa Sinh Viên";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(panel13);
            panel3.Controls.Add(panel12);
            panel3.Location = new Point(0, 109);
            panel3.Name = "panel3";
            panel3.Size = new Size(944, 479);
            panel3.TabIndex = 3;
            // 
            // UpdateStudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 588);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "UpdateStudentForm";
            Text = "UpdateStudentForm";
            panel12.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button updateBtn;
        private Panel panel12;
        private Button CancelBtn;
        private TextBox txtMSSV;
        private Label label3;
        private Panel panel4;
        private TextBox txtHoTen;
        private Label label4;
        private Panel panel5;
        private ComboBox comboGioiTinh;
        private Label label5;
        private Panel panel6;
        private Label label6;
        private DateTimePicker dateTimePickerNgaySinh;
        private Panel panel7;
        private TextBox txtSDT;
        private Panel panel13;
        private Panel panel11;
        private ComboBox comboTinhTrang;
        private Label label10;
        private Panel panel10;
        private ComboBox comboKhoa;
        private Label label9;
        private Panel panel9;
        private TextBox txtDiaChi;
        private Label label8;
        private Panel panel8;
        private Label label7;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Panel panel3;
    }
}