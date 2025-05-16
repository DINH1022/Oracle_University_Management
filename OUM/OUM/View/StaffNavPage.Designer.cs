namespace OUM.View
{
    partial class StaffNavPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffNavPage));
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            LogoutBtn = new Button();
            InfoBtn = new Button();
            panelMainContent = new Panel();
            panel3 = new Panel();
            panelMain = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelMainContent.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGoldenrodYellow;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(InfoBtn);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 853);
            panel1.TabIndex = 2;
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
            panelMainContent.Controls.Add(panel3);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1182, 853);
            panelMainContent.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(panelMain);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1182, 853);
            panel3.TabIndex = 2;
            // 
            // panelMain
            // 
            panelMain.Location = new Point(228, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(954, 853);
            panelMain.TabIndex = 0;
            // 
            // StaffNavPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(panel1);
            Controls.Add(panelMainContent);
            Name = "StaffNavPage";
            Text = "Staff";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panelMainContent.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button LogoutBtn;
        private Button InfoBtn;
        private Panel panelMainContent;
        private Panel panel3;
        private Panel panelMain;
    }
}