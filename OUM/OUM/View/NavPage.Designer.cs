namespace OUM.View
{
    partial class NavPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavPage));
            panel1 = new Panel();
            button1 = new Button();
            RevokeBtnNav = new Button();
            RoleBtn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            LogoutBtn = new Button();
            EmpBtn = new Button();
            StudentBtn = new Button();
            panelMainContent = new Panel();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGoldenrodYellow;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(RevokeBtnNav);
            panel1.Controls.Add(RoleBtn);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(EmpBtn);
            panel1.Controls.Add(StudentBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 853);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(27, 421);
            button1.Name = "button1";
            button1.Size = new Size(175, 49);
            button1.TabIndex = 5;
            button1.Text = "Cấp quyền";
            button1.UseVisualStyleBackColor = false;
            button1.Click += GrantBtnNav_click;
            // 
            // RevokeBtnNav
            // 
            RevokeBtnNav.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RevokeBtnNav.ForeColor = Color.DarkGreen;
            RevokeBtnNav.Location = new Point(27, 561);
            RevokeBtnNav.Name = "RevokeBtnNav";
            RevokeBtnNav.Size = new Size(175, 49);
            RevokeBtnNav.TabIndex = 4;
            RevokeBtnNav.Text = "Thu hồi quyền";
            RevokeBtnNav.UseVisualStyleBackColor = false;
            RevokeBtnNav.Click += RevokeBtnNav_click;
            // 
            // RoleBtn
            // 
            RoleBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoleBtn.ForeColor = Color.DarkGreen;
            RoleBtn.Location = new Point(27, 341);
            RoleBtn.Name = "RoleBtn";
            RoleBtn.Size = new Size(175, 49);
            RoleBtn.TabIndex = 3;
            RoleBtn.Text = "Quản Lý Vai Trò";
            RoleBtn.UseVisualStyleBackColor = false;
            RoleBtn.Click += manageRole_Click;
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
            LogoutBtn.Dock = DockStyle.Fill;
            LogoutBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogoutBtn.ForeColor = Color.DarkGreen;
            LogoutBtn.Location = new Point(0, 0);
            LogoutBtn.Name = "LogoutBtn";
            LogoutBtn.Size = new Size(229, 60);
            LogoutBtn.TabIndex = 3;
            LogoutBtn.Text = "Đăng Xuất";
            LogoutBtn.UseVisualStyleBackColor = false;
            LogoutBtn.Click += LogoutBtn_Click;
            // 
            // EmpBtn
            // 
            EmpBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmpBtn.ForeColor = Color.DarkGreen;
            EmpBtn.Location = new Point(27, 266);
            EmpBtn.Name = "EmpBtn";
            EmpBtn.Size = new Size(175, 49);
            EmpBtn.TabIndex = 1;
            EmpBtn.Text = "Quản Lý Nhân Viên";
            EmpBtn.UseVisualStyleBackColor = false;
            EmpBtn.Click += btnQuanLyNhanVien_Click;
            // 
            // StudentBtn
            // 
            StudentBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StudentBtn.ForeColor = Color.DarkGreen;
            StudentBtn.Location = new Point(27, 191);
            StudentBtn.Name = "StudentBtn";
            StudentBtn.Size = new Size(175, 49);
            StudentBtn.TabIndex = 0;
            StudentBtn.Text = "Quản Lý Sinh Viên";
            StudentBtn.UseVisualStyleBackColor = false;
            StudentBtn.Click += btnQuanLySinhVien_Click;
            // 
            // panelMainContent
            // 
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(231, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(951, 853);
            panelMainContent.TabIndex = 1;
            panelMainContent.Paint += panelMainContent_Paint;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(27, 487);
            button2.Name = "button2";
            button2.Size = new Size(175, 49);
            button2.TabIndex = 6;
            button2.Text = "Xem quyền";
            button2.UseVisualStyleBackColor = false;
            button2.Click += PerViewBtn_Click;
            // 
            // NavPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(panelMainContent);
            Controls.Add(panel1);
            Name = "NavPage";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button EmpBtn;
        private Button LogoutBtn;
        private Button StudentBtn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button RoleBtn;
        private Panel panelMainContent;
        private Button RevokeBtnNav;
        private Button button1;
        private Button button2;
    }
}