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
            panel3 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            LogoutBtn = new Button();
            panelMain = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGoldenrodYellow;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 853);
            panel1.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(229, 192);
            panel3.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.BackgroundImage = (Image)resources.GetObject("flowLayoutPanel1.BackgroundImage");
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.Zoom;
            flowLayoutPanel1.Location = new Point(51, 59);
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
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(231, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(951, 853);
            panelMain.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 192);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(229, 601);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // UserNavBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(panelMain);
            Controls.Add(panel1);
            Name = "UserNavBar";
            Text = "UserPage";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button LogoutBtn;
        private Panel panelMain;
        private Panel panel3;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}