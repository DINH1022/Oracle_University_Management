namespace OUM.View
{
    partial class AdminOfficeNavPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminOfficeNavPage));
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            LogoutBtn = new Button();
            EmpBtn = new Button();
            InfoBtn = new Button();
            panelMainContent = new Panel();
            panelMain = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelMainContent.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGoldenrodYellow;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(EmpBtn);
            panel1.Controls.Add(InfoBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 853);
            panel1.TabIndex = 4;
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
            // EmpBtn
            // 
            EmpBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmpBtn.ForeColor = Color.DarkGreen;
            EmpBtn.Location = new Point(27, 290);
            EmpBtn.Name = "EmpBtn";
            EmpBtn.Size = new Size(175, 49);
            EmpBtn.TabIndex = 1;
            EmpBtn.Text = "Quản Lý Nhân Viên";
            EmpBtn.UseVisualStyleBackColor = false;
            // 
            // InfoBtn
            // 
            InfoBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InfoBtn.ForeColor = Color.DarkGreen;
            InfoBtn.Location = new Point(27, 191);
            InfoBtn.Name = "InfoBtn";
            InfoBtn.Size = new Size(175, 49);
            InfoBtn.TabIndex = 0;
            InfoBtn.Text = "Thông tin cá nhân";
            InfoBtn.UseVisualStyleBackColor = false;
            InfoBtn.TextChanged += InfoBtn_Click;
            InfoBtn.Click += InfoBtn_Click;
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(panelMain);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1182, 853);
            panelMainContent.TabIndex = 5;
            // 
            // panelMain
            // 
            panelMain.Location = new Point(228, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(954, 853);
            panelMain.TabIndex = 0;
            // 
            // AdminOfficeNavPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(panel1);
            Controls.Add(panelMainContent);
            Name = "AdminOfficeNavPage";
            Text = "AdminOfficeNavPage";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelMainContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button LogoutBtn;
        private Button EmpBtn;
        private Button InfoBtn;
        private Panel panelMainContent;
        private Panel panelMain;
    }
}