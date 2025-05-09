namespace OUM.View.RegistrationCourseView
{
    partial class RegisterNewCoursePage
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
            panel1 = new Panel();
            panel4 = new Panel();
            searchInput = new TextBox();
            FindBtn = new Button();
            listCourses = new DataGridView();
            MAMM = new DataGridViewTextBoxColumn();
            MAHP = new DataGridViewTextBoxColumn();
            TENHP = new DataGridViewTextBoxColumn();
            SOTC = new DataGridViewTextBoxColumn();
            STTH = new DataGridViewTextBoxColumn();
            STLT = new DataGridViewTextBoxColumn();
            THAOTAC = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listCourses).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1058, 81);
            panel1.TabIndex = 12;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(searchInput);
            panel4.Controls.Add(FindBtn);
            panel4.Location = new Point(18, 22);
            panel4.Name = "panel4";
            panel4.Size = new Size(491, 38);
            panel4.TabIndex = 4;
            // 
            // searchInput
            // 
            searchInput.Dock = DockStyle.Fill;
            searchInput.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInput.Location = new Point(88, 0);
            searchInput.Multiline = true;
            searchInput.Name = "searchInput";
            searchInput.PlaceholderText = "Học phần";
            searchInput.Size = new Size(401, 36);
            searchInput.TabIndex = 2;
            searchInput.TextChanged += searchInputTextChanged;
            // 
            // FindBtn
            // 
            FindBtn.BackColor = Color.PaleGoldenrod;
            FindBtn.Dock = DockStyle.Left;
            FindBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FindBtn.Location = new Point(0, 0);
            FindBtn.Name = "FindBtn";
            FindBtn.Size = new Size(88, 36);
            FindBtn.TabIndex = 0;
            FindBtn.Text = "Tìm kiếm";
            FindBtn.UseVisualStyleBackColor = false;
            FindBtn.Click += searchBtn;
            // 
            // listCourses
            // 
            listCourses.BackgroundColor = Color.White;
            listCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listCourses.Columns.AddRange(new DataGridViewColumn[] { MAMM, MAHP, TENHP, SOTC, STTH, STLT, THAOTAC });
            listCourses.Dock = DockStyle.Fill;
            listCourses.Location = new Point(0, 81);
            listCourses.Name = "listCourses";
            listCourses.RowHeadersWidth = 51;
            listCourses.Size = new Size(1058, 669);
            listCourses.TabIndex = 13;
            listCourses.CellClick += registerBtnClick;
            // 
            // MAMM
            // 
            MAMM.DataPropertyName = "MAMM";
            MAMM.HeaderText = "MAMM";
            MAMM.MinimumWidth = 6;
            MAMM.Name = "MAMM";
            MAMM.Width = 125;
            // 
            // MAHP
            // 
            MAHP.DataPropertyName = "MAHP";
            MAHP.HeaderText = "MAHP";
            MAHP.MinimumWidth = 6;
            MAHP.Name = "MAHP";
            MAHP.Width = 125;
            // 
            // TENHP
            // 
            TENHP.DataPropertyName = "TENHP";
            TENHP.HeaderText = "TÊN HỌC PHẦN";
            TENHP.MinimumWidth = 6;
            TENHP.Name = "TENHP";
            TENHP.Width = 125;
            // 
            // SOTC
            // 
            SOTC.DataPropertyName = "SOTC";
            SOTC.HeaderText = "SỐ TC";
            SOTC.MinimumWidth = 6;
            SOTC.Name = "SOTC";
            SOTC.Width = 125;
            // 
            // STTH
            // 
            STTH.DataPropertyName = "STTH";
            STTH.HeaderText = "THỰC HÀNH";
            STTH.MinimumWidth = 6;
            STTH.Name = "STTH";
            STTH.Width = 125;
            // 
            // STLT
            // 
            STLT.DataPropertyName = "STLT";
            STLT.HeaderText = "LÝ THUYẾT";
            STLT.MinimumWidth = 6;
            STLT.Name = "STLT";
            STLT.Width = 125;
            // 
            // THAOTAC
            // 
            THAOTAC.HeaderText = "THAO TÁC";
            THAOTAC.MinimumWidth = 6;
            THAOTAC.Name = "THAOTAC";
            THAOTAC.Text = "Đăng ký";
            THAOTAC.UseColumnTextForButtonValue = true;
            THAOTAC.Width = 125;
            // 
            // RegisterNewCoursePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listCourses);
            Controls.Add(panel1);
            Name = "RegisterNewCoursePage";
            Size = new Size(1058, 750);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)listCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private TextBox searchInput;
        private Button FindBtn;
        private DataGridView listCourses;
        private DataGridViewTextBoxColumn MAMM;
        private DataGridViewTextBoxColumn MAHP;
        private DataGridViewTextBoxColumn TENHP;
        private DataGridViewTextBoxColumn SOTC;
        private DataGridViewTextBoxColumn STTH;
        private DataGridViewTextBoxColumn STLT;
        private DataGridViewButtonColumn THAOTAC;
    }
}
