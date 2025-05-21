namespace OUM.View
{
    partial class TeacherNavPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherNavPage));
            panel1 = new Panel();
            Regiterbutton = new Button();
            Coursebutton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            LogoutBtn = new Button();
            StudentBtn = new Button();
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
            panel1.TabIndex = 4;
            // 
            // Regiterbutton
            // 
            Regiterbutton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Regiterbutton.ForeColor = Color.DarkGreen;
            Regiterbutton.Location = new Point(27, 484);
            Regiterbutton.Name = "Regiterbutton";
            Regiterbutton.Size = new Size(175, 69);
            Regiterbutton.TabIndex = 4;
            Regiterbutton.Text = "Kết Quả Đăng Ký Học Phần";
            Regiterbutton.UseVisualStyleBackColor = false;
            // 
            // Coursebutton
            // 
            Coursebutton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Coursebutton.ForeColor = Color.DarkGreen;
            Coursebutton.Location = new Point(27, 382);
            Coursebutton.Name = "Coursebutton";
            Coursebutton.Size = new Size(175, 49);
            Coursebutton.TabIndex = 3;
            Coursebutton.Text = "Mở môn";
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
            StudentBtn.Location = new Point(27, 290);
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
            panelMain.Location = new Point(227, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(955, 849);
            panelMain.TabIndex = 0;
            // 
            // TeacherNavPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(panel1);
            Controls.Add(panelMainContent);
            Name = "TeacherNavPage";
            Text = "TeacherNavPage";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelMainContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Coursebutton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button LogoutBtn;
        private Button StudentBtn;
        private Button InfoBtn;
        private Panel panelMainContent;
        private Button Regiterbutton;
        private Panel panelMain;
    }
}