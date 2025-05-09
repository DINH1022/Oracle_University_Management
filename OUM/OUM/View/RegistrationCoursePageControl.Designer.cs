namespace OUM.View
{
    partial class RegistrationCoursePageControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel3 = new Panel();
            button1 = new Button();
            label2 = new Label();
            panelMainContent = new Panel();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(255, 38);
            label1.TabIndex = 0;
            label1.Text = "Đăng ký học phần";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(button1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1058, 111);
            panel3.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGoldenrod;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(764, 34);
            button1.Name = "button1";
            button1.Size = new Size(235, 41);
            button1.TabIndex = 2;
            button1.Text = "Đăng ký học phần mới";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 50);
            label2.Name = "label2";
            label2.Size = new Size(349, 25);
            label2.TabIndex = 1;
            label2.Text = "Xem và quản lý đăng ký học phần của bạn";
            // 
            // panelMainContent
            // 
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(0, 111);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1058, 639);
            panelMainContent.TabIndex = 11;
            // 
            // RegistrationCoursePageControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMainContent);
            Controls.Add(panel3);
            Name = "RegistrationCoursePageControl";
            Size = new Size(1058, 750);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel3;
        private Label label2;
        private Button button1;
        private Panel panelMainContent;
    }
}
