namespace OUM.View
{
    partial class Account
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
            txtDC = new TextBox();
            txtPC = new TextBox();
            txtSalary = new TextBox();
            txtPhone = new TextBox();
            dateTimePickerdob = new DateTimePicker();
            lbPC = new Label();
            lbSalary = new Label();
            lbStatus = new Label();
            lbKhoa = new Label();
            lbDC = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtMa = new TextBox();
            label2 = new Label();
            textBoxUserType = new TextBox();
            label1 = new Label();
            button2 = new Button();
            txt_gen = new TextBox();
            txtKhoa = new TextBox();
            txtStatus = new TextBox();
            lbNewPhone = new Label();
            txtNewP = new TextBox();
            btnUpdate = new Button();
            lbNAddress = new Label();
            txtNewAd = new TextBox();
            SuspendLayout();
            // 
            // txtDC
            // 
            txtDC.Location = new Point(588, 95);
            txtDC.Name = "txtDC";
            txtDC.Size = new Size(287, 27);
            txtDC.TabIndex = 44;
            txtDC.TextChanged += Account_Load;
            // 
            // txtPC
            // 
            txtPC.Location = new Point(588, 317);
            txtPC.Name = "txtPC";
            txtPC.ReadOnly = true;
            txtPC.Size = new Size(250, 27);
            txtPC.TabIndex = 43;
            txtPC.Visible = false;
            txtPC.TextChanged += Account_Load;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(588, 257);
            txtSalary.Name = "txtSalary";
            txtSalary.ReadOnly = true;
            txtSalary.Size = new Size(250, 27);
            txtSalary.TabIndex = 42;
            txtSalary.Visible = false;
            txtSalary.TextChanged += Account_Load;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(147, 318);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 27);
            txtPhone.TabIndex = 41;
            txtPhone.TextChanged += Account_Load;
            // 
            // dateTimePickerdob
            // 
            dateTimePickerdob.CustomFormat = "";
            dateTimePickerdob.Format = DateTimePickerFormat.Short;
            dateTimePickerdob.Location = new Point(147, 255);
            dateTimePickerdob.Name = "dateTimePickerdob";
            dateTimePickerdob.Size = new Size(250, 27);
            dateTimePickerdob.TabIndex = 37;
            dateTimePickerdob.ValueChanged += Account_Load;
            // 
            // lbPC
            // 
            lbPC.AutoSize = true;
            lbPC.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbPC.Location = new Point(465, 317);
            lbPC.Name = "lbPC";
            lbPC.Size = new Size(80, 25);
            lbPC.TabIndex = 36;
            lbPC.Text = "Phụ cấp";
            lbPC.Visible = false;
            // 
            // lbSalary
            // 
            lbSalary.AutoSize = true;
            lbSalary.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbSalary.Location = new Point(465, 257);
            lbSalary.Name = "lbSalary";
            lbSalary.Size = new Size(65, 25);
            lbSalary.TabIndex = 35;
            lbSalary.Text = "Lương";
            lbSalary.Visible = false;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbStatus.Location = new Point(465, 202);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(103, 25);
            lbStatus.TabIndex = 34;
            lbStatus.Text = "Tình trạng";
            // 
            // lbKhoa
            // 
            lbKhoa.AutoSize = true;
            lbKhoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbKhoa.Location = new Point(465, 147);
            lbKhoa.Name = "lbKhoa";
            lbKhoa.Size = new Size(56, 25);
            lbKhoa.TabIndex = 33;
            lbKhoa.Text = "Khoa";
            // 
            // lbDC
            // 
            lbDC.AutoSize = true;
            lbDC.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbDC.Location = new Point(465, 99);
            lbDC.Name = "lbDC";
            lbDC.Size = new Size(73, 25);
            lbDC.TabIndex = 32;
            lbDC.Text = "Địa chỉ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(15, 317);
            label6.Name = "label6";
            label6.Size = new Size(102, 25);
            label6.TabIndex = 31;
            label6.Text = "Điện thoại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 257);
            label5.Name = "label5";
            label5.Size = new Size(104, 25);
            label5.TabIndex = 30;
            label5.Text = "Ngày sinh ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 202);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 29;
            label4.Text = "Phái";
            // 
            // txtName
            // 
            txtName.Location = new Point(94, 145);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(281, 27);
            txtName.TabIndex = 28;
            txtName.TextChanged += Account_Load;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 147);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 27;
            label3.Text = "Họ tên ";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(93, 95);
            txtMa.Name = "txtMa";
            txtMa.ReadOnly = true;
            txtMa.Size = new Size(281, 27);
            txtMa.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 97);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 25;
            label2.Text = "Mã ";
            // 
            // textBoxUserType
            // 
            textBoxUserType.Location = new Point(15, 57);
            textBoxUserType.Name = "textBoxUserType";
            textBoxUserType.ReadOnly = true;
            textBoxUserType.Size = new Size(448, 27);
            textBoxUserType.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(208, 31);
            label1.TabIndex = 23;
            label1.Text = "Thông tin cá nhân";
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(530, 436);
            button2.Name = "button2";
            button2.Size = new Size(195, 40);
            button2.TabIndex = 46;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = true;
            button2.TextChanged += button2_Click;
            button2.Click += button2_Click;
            // 
            // txt_gen
            // 
            txt_gen.Location = new Point(94, 200);
            txt_gen.Name = "txt_gen";
            txt_gen.ReadOnly = true;
            txt_gen.Size = new Size(281, 27);
            txt_gen.TabIndex = 47;
            txt_gen.TextChanged += Account_Load;
            // 
            // txtKhoa
            // 
            txtKhoa.Location = new Point(588, 148);
            txtKhoa.Name = "txtKhoa";
            txtKhoa.ReadOnly = true;
            txtKhoa.Size = new Size(250, 27);
            txtKhoa.TabIndex = 48;
            txtKhoa.TextChanged += Account_Load;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(588, 203);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(250, 27);
            txtStatus.TabIndex = 49;
            txtStatus.TextChanged += Account_Load;
            // 
            // lbNewPhone
            // 
            lbNewPhone.AutoSize = true;
            lbNewPhone.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNewPhone.Location = new Point(12, 366);
            lbNewPhone.Name = "lbNewPhone";
            lbNewPhone.Size = new Size(140, 25);
            lbNewPhone.TabIndex = 50;
            lbNewPhone.Text = "Điện thoại mới";
            lbNewPhone.Visible = false;
            lbNewPhone.TextChanged += btnUpdate_Click;
            // 
            // txtNewP
            // 
            txtNewP.Location = new Point(147, 367);
            txtNewP.Name = "txtNewP";
            txtNewP.Size = new Size(250, 27);
            txtNewP.TabIndex = 51;
            txtNewP.Visible = false;
            // 
            // btnUpdate
            // 
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(288, 436);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(195, 40);
            btnUpdate.TabIndex = 52;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lbNAddress
            // 
            lbNAddress.AutoSize = true;
            lbNAddress.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNAddress.Location = new Point(465, 369);
            lbNAddress.Name = "lbNAddress";
            lbNAddress.Size = new Size(111, 25);
            lbNAddress.TabIndex = 53;
            lbNAddress.Text = "Địa chỉ mới";
            lbNAddress.Visible = false;
            // 
            // txtNewAd
            // 
            txtNewAd.Location = new Point(588, 367);
            txtNewAd.Name = "txtNewAd";
            txtNewAd.Size = new Size(287, 27);
            txtNewAd.TabIndex = 54;
            txtNewAd.Visible = false;
            // 
            // Account
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtNewAd);
            Controls.Add(lbNAddress);
            Controls.Add(btnUpdate);
            Controls.Add(txtNewP);
            Controls.Add(lbNewPhone);
            Controls.Add(txtStatus);
            Controls.Add(txtKhoa);
            Controls.Add(txt_gen);
            Controls.Add(button2);
            Controls.Add(txtDC);
            Controls.Add(txtPC);
            Controls.Add(txtSalary);
            Controls.Add(txtPhone);
            Controls.Add(dateTimePickerdob);
            Controls.Add(lbPC);
            Controls.Add(lbSalary);
            Controls.Add(lbStatus);
            Controls.Add(lbKhoa);
            Controls.Add(lbDC);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(txtMa);
            Controls.Add(label2);
            Controls.Add(textBoxUserType);
            Controls.Add(label1);
            Name = "Account";
            Size = new Size(1164, 806);
            TextChanged += Account_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDC;
        private TextBox txtPC;
        private TextBox txtSalary;
        private TextBox txtPhone;
        private DateTimePicker dateTimePickerdob;
        private Label lbPC;
        private Label lbSalary;
        private Label lbStatus;
        private Label lbKhoa;
        private Label lbDC;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtName;
        private Label label3;
        private TextBox txtMa;
        private Label label2;
        private TextBox textBoxUserType;
        private Label label1;
        private Button button2;
        private TextBox txt_gen;
        private TextBox txtKhoa;
        private TextBox txtStatus;
        private Label lbNewPhone;
        private TextBox txtNewP;
        private Button btnUpdate;
        private Label lbNAddress;
        private TextBox txtNewAd;
    }
}