namespace OUM.View
{
    partial class StudentPage
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
            PreviousBtn = new Button();
            AddStudentBtn = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            panel4 = new Panel();
            textBox1 = new TextBox();
            FindBtn = new Button();
            label2 = new Label();
            panel3 = new Panel();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 13);
            label1.Name = "label1";
            label1.Size = new Size(208, 31);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Sinh Viên";
            label1.Click += label1_Click;
            // 
            // PreviousBtn
            // 
            PreviousBtn.Dock = DockStyle.Left;
            PreviousBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PreviousBtn.Location = new Point(0, 0);
            PreviousBtn.Name = "PreviousBtn";
            PreviousBtn.Size = new Size(53, 54);
            PreviousBtn.TabIndex = 1;
            PreviousBtn.Text = "<";
            PreviousBtn.UseVisualStyleBackColor = true;
            // 
            // AddStudentBtn
            // 
            AddStudentBtn.BackColor = SystemColors.ControlDark;
            AddStudentBtn.Dock = DockStyle.Right;
            AddStudentBtn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddStudentBtn.ForeColor = SystemColors.ButtonHighlight;
            AddStudentBtn.Location = new Point(763, 0);
            AddStudentBtn.Name = "AddStudentBtn";
            AddStudentBtn.RightToLeft = RightToLeft.Yes;
            AddStudentBtn.Size = new Size(162, 54);
            AddStudentBtn.TabIndex = 2;
            AddStudentBtn.Text = "Thêm";
            AddStudentBtn.UseVisualStyleBackColor = false;
            AddStudentBtn.Click += this.AddStudent_Click;
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
            panel2.Paint += panel2_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(927, 56);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(FindBtn);
            panel4.Location = new Point(456, 9);
            panel4.Name = "panel4";
            panel4.Size = new Size(441, 38);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(88, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 36);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // FindBtn
            // 
            FindBtn.Dock = DockStyle.Left;
            FindBtn.Location = new Point(0, 0);
            FindBtn.Name = "FindBtn";
            FindBtn.Size = new Size(88, 36);
            FindBtn.TabIndex = 0;
            FindBtn.Text = "Tìm kiếm";
            FindBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 13);
            label2.Name = "label2";
            label2.Size = new Size(130, 31);
            label2.TabIndex = 3;
            label2.Text = "Danh sách ";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(AddStudentBtn);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(PreviousBtn);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(927, 56);
            panel3.TabIndex = 0;
            // 
            // StudentPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 541);
            Controls.Add(panel2);
            Name = "StudentPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Label label1;
        private Button PreviousBtn;
        private Button AddStudentBtn;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel4;
        private Label label2;
        private Button FindBtn;
        private TextBox textBox1;
    }
}