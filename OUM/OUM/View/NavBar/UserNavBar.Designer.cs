namespace OUM.View
{
    partial class UserNavBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserNavBar));
            panel1 = new Panel();
            NoticeBtn = new Button();
            EmpBtn = new Button();
            Regiterbutton = new Button();
            Coursebutton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            LogoutBtn = new Button();
            StudentBtn = new Button();
            InfoBtn = new Button();
            panelMain = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGoldenrodYellow;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(NoticeBtn);
            panel1.Controls.Add(EmpBtn);
            panel1.Controls.Add(Regiterbutton);
            panel1.Controls.Add(Coursebutton);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(StudentBtn);
            panel1.Controls.Add(InfoBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 853);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // NoticeBtn
            // 
            NoticeBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoticeBtn.ForeColor = Color.DarkGreen;
            NoticeBtn.Location = new Point(27, 681);
            NoticeBtn.Name = "NoticeBtn";
            NoticeBtn.Size = new Size(175, 50);
            NoticeBtn.TabIndex = 6;
            NoticeBtn.Text = "Thông Báo";
            NoticeBtn.UseVisualStyleBackColor = false;
            // 
            // EmpBtn
            // 
            EmpBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmpBtn.ForeColor = Color.DarkGreen;
            EmpBtn.Location = new Point(27, 397);
            EmpBtn.Name = "EmpBtn";
            EmpBtn.Size = new Size(175, 49);
            EmpBtn.TabIndex = 5;
            EmpBtn.Text = "Quản Lý Nhân Viên";
            EmpBtn.UseVisualStyleBackColor = false;
            EmpBtn.Click += EmpBtn_Click;
            // 
            // Regiterbutton
            // 
            Regiterbutton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Regiterbutton.ForeColor = Color.DarkGreen;
            Regiterbutton.Location = new Point(27, 584);
            Regiterbutton.Name = "Regiterbutton";
            Regiterbutton.Size = new Size(175, 50);
            Regiterbutton.TabIndex = 4;
            Regiterbutton.Text = "Đăng Ký Học Phần";
            Regiterbutton.UseVisualStyleBackColor = false;
            Regiterbutton.Click += Regiterbutton_Click;
            // 
            // Coursebutton
            // 
            Coursebutton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Coursebutton.ForeColor = Color.DarkGreen;
            Coursebutton.Location = new Point(27, 489);
            Coursebutton.Name = "Coursebutton";
            Coursebutton.Size = new Size(175, 49);
            Coursebutton.TabIndex = 3;
            Coursebutton.Text = "Danh sách lớp mở";
            Coursebutton.UseVisualStyleBackColor = false;
            Coursebutton.Click += Coursebutton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.BackgroundImage = (Image)resources.GetObject("flowLayoutPanel1.BackgroundImage");
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.Zoom;
            flowLayoutPanel1.Location = new Point(49, 39);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(130, 130);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(LogoutBtn);
            panel2.Dock = DockStyle.Bottom;
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(0, 791);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 60);
            panel2.TabIndex = 2;
            // 
            // LogoutBtn
            // 
            LogoutBtn.BackColor = Color.White;
            LogoutBtn.Dock = DockStyle.Fill;
            LogoutBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogoutBtn.ForeColor = Color.DarkGreen;
            LogoutBtn.Location = new Point(0, 0);
            LogoutBtn.Name = "LogoutBtn";
            LogoutBtn.Size = new Size(229, 60);
            LogoutBtn.TabIndex = 3;
            LogoutBtn.Text = "Đăng Xuất";
            LogoutBtn.UseVisualStyleBackColor = false;
            LogoutBtn.TextChanged += LogoutBtn_Click;
            LogoutBtn.Click += LogoutBtn_Click;
            // 
            // StudentBtn
            // 
            StudentBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StudentBtn.ForeColor = Color.DarkGreen;
            StudentBtn.Location = new Point(27, 308);
            StudentBtn.Name = "StudentBtn";
            StudentBtn.Size = new Size(175, 49);
            StudentBtn.TabIndex = 1;
            StudentBtn.Text = "Quản Lý Sinh Viên ";
            StudentBtn.UseVisualStyleBackColor = false;
            StudentBtn.Click += StudentBtn_Click;
            // 
            // InfoBtn
            // 
            InfoBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InfoBtn.ForeColor = Color.DarkGreen;
            InfoBtn.Location = new Point(27, 219);
            InfoBtn.Name = "InfoBtn";
            InfoBtn.Size = new Size(175, 49);
            InfoBtn.TabIndex = 0;
            InfoBtn.Text = "Thông tin cá nhân";
            InfoBtn.UseVisualStyleBackColor = false;
            InfoBtn.TextChanged += InfoBtn_Click;
            InfoBtn.Click += InfoBtn_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(231, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(951, 853);
            panelMain.TabIndex = 7;
            // 
            // UserNavBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            Name = "UserNavBar";
            Text = "AcademicAdminNavPage";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Regiterbutton;
        private Button Coursebutton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button LogoutBtn;
        private Button StudentBtn;
        private Button InfoBtn;
        private Button EmpBtn;
        private Button NoticeBtn;
        private Panel panelMain;
    }
}