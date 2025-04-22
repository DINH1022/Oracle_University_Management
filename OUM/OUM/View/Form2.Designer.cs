namespace OUM.View
{
    partial class Form2
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
            saveFileDialog1 = new SaveFileDialog();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            panel4 = new Panel();
            button3 = new Button();
            textBox1 = new TextBox();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 13);
            label1.Name = "label1";
            label1.Size = new Size(239, 31);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Người Dùng";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Left;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(53, 56);
            button1.TabIndex = 1;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.Dock = DockStyle.Right;
            button2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(697, 0);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.Yes;
            button2.Size = new Size(230, 56);
            button2.TabIndex = 2;
            button2.Text = "Thêm người dùng";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.OldLace;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(927, 541);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(927, 56);
            panel3.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(927, 56);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 13);
            label2.Name = "label2";
            label2.Size = new Size(256, 31);
            label2.TabIndex = 3;
            label2.Text = "Danh sách người dùng";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(button3);
            panel4.Location = new Point(456, 13);
            panel4.Name = "panel4";
            panel4.Size = new Size(441, 31);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Left;
            button3.Location = new Point(0, 0);
            button3.Name = "button3";
            button3.Size = new Size(88, 31);
            button3.TabIndex = 0;
            button3.Text = "Tìm kiếm";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(88, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(353, 31);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 541);
            Controls.Add(panel2);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel4;
        private Label label2;
        private Button button3;
        private TextBox textBox1;
    }
}