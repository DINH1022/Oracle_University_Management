namespace OUM.View.RegistrationCourseView
{
    partial class TeacherRegistrationCourse
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
            listGradeStudents = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            panel5 = new Panel();
            panel6 = new Panel();
            label3 = new Label();
            searchInputCourseDetail = new TextBox();
            FindBtnCourseDetail = new Button();
            panel7 = new Panel();
            panel4 = new Panel();
            listCourseDetail = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            MAHP = new DataGridViewTextBoxColumn();
            TENHP = new DataGridViewTextBoxColumn();
            SOTC = new DataGridViewTextBoxColumn();
            STLT = new DataGridViewTextBoxColumn();
            STTH = new DataGridViewTextBoxColumn();
            HK = new DataGridViewTextBoxColumn();
            NAM = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)listGradeStudents).BeginInit();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listCourseDetail).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // listGradeStudents
            // 
            listGradeStudents.BackgroundColor = Color.White;
            listGradeStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listGradeStudents.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12 });
            listGradeStudents.Dock = DockStyle.Fill;
            listGradeStudents.Location = new Point(0, 56);
            listGradeStudents.Name = "listGradeStudents";
            listGradeStudents.RowHeadersWidth = 51;
            listGradeStudents.Size = new Size(1058, 388);
            listGradeStudents.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "MASV";
            dataGridViewTextBoxColumn7.HeaderText = "MASV";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "TENSV";
            dataGridViewTextBoxColumn8.HeaderText = "TÊN SV";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "DIEMTH";
            dataGridViewTextBoxColumn9.HeaderText = "ĐIỂM TH";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "DIEMQT";
            dataGridViewTextBoxColumn10.HeaderText = "ĐIỂM QUÁ TRÌNH";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "DIEMCK";
            dataGridViewTextBoxColumn11.HeaderText = "ĐIỂM CUỐI KỲ";
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.Width = 125;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.DataPropertyName = "DIEMTK";
            dataGridViewTextBoxColumn12.HeaderText = "TỔNG KẾT";
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Width = 125;
            // 
            // panel5
            // 
            panel5.Controls.Add(listGradeStudents);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 306);
            panel5.Name = "panel5";
            panel5.Size = new Size(1058, 444);
            panel5.TabIndex = 17;
            // 
            // panel6
            // 
            panel6.Controls.Add(label3);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1058, 56);
            panel6.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(264, 38);
            label3.TabIndex = 0;
            label3.Text = "Danh sách sinh viên";
            // 
            // searchInputCourseDetail
            // 
            searchInputCourseDetail.Dock = DockStyle.Fill;
            searchInputCourseDetail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInputCourseDetail.Location = new Point(99, 0);
            searchInputCourseDetail.Multiline = true;
            searchInputCourseDetail.Name = "searchInputCourseDetail";
            searchInputCourseDetail.PlaceholderText = "Mã mở môn";
            searchInputCourseDetail.Size = new Size(510, 44);
            searchInputCourseDetail.TabIndex = 2;
            searchInputCourseDetail.TextChanged += searchInputCourseDetailTextChanged;
            // 
            // FindBtnCourseDetail
            // 
            FindBtnCourseDetail.BackColor = Color.PaleGoldenrod;
            FindBtnCourseDetail.Dock = DockStyle.Left;
            FindBtnCourseDetail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FindBtnCourseDetail.Location = new Point(0, 0);
            FindBtnCourseDetail.Name = "FindBtnCourseDetail";
            FindBtnCourseDetail.Size = new Size(99, 44);
            FindBtnCourseDetail.TabIndex = 0;
            FindBtnCourseDetail.Text = "Tìm kiếm";
            FindBtnCourseDetail.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(searchInputCourseDetail);
            panel7.Controls.Add(FindBtnCourseDetail);
            panel7.Location = new Point(3, 6);
            panel7.Name = "panel7";
            panel7.Size = new Size(611, 46);
            panel7.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel7);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1058, 56);
            panel4.TabIndex = 1;
            // 
            // listCourseDetail
            // 
            listCourseDetail.BackgroundColor = Color.White;
            listCourseDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listCourseDetail.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, MAHP, TENHP, SOTC, STLT, STTH, HK, NAM });
            listCourseDetail.Dock = DockStyle.Top;
            listCourseDetail.Location = new Point(0, 56);
            listCourseDetail.Name = "listCourseDetail";
            listCourseDetail.RowHeadersWidth = 51;
            listCourseDetail.Size = new Size(1058, 147);
            listCourseDetail.TabIndex = 17;
            listCourseDetail.SelectionChanged += CourseDetailSelectionChange;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "MAMM";
            dataGridViewTextBoxColumn1.HeaderText = "MÃ MỞ MÔN";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // MAHP
            // 
            MAHP.DataPropertyName = "MAHP";
            MAHP.HeaderText = "MÃ HP";
            MAHP.MinimumWidth = 6;
            MAHP.Name = "MAHP";
            MAHP.Width = 125;
            // 
            // TENHP
            // 
            TENHP.DataPropertyName = "TENHP";
            TENHP.HeaderText = "TÊN HP";
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
            // STLT
            // 
            STLT.DataPropertyName = "STLT";
            STLT.HeaderText = "STLT";
            STLT.MinimumWidth = 6;
            STLT.Name = "STLT";
            STLT.Width = 125;
            // 
            // STTH
            // 
            STTH.DataPropertyName = "STTH";
            STTH.HeaderText = "STTH";
            STTH.MinimumWidth = 6;
            STTH.Name = "STTH";
            STTH.Width = 125;
            // 
            // HK
            // 
            HK.DataPropertyName = "HK";
            HK.HeaderText = "HỌC KỲ";
            HK.MinimumWidth = 6;
            HK.Name = "HK";
            HK.Width = 125;
            // 
            // NAM
            // 
            NAM.DataPropertyName = "NAM";
            NAM.HeaderText = "NĂM";
            NAM.MinimumWidth = 6;
            NAM.Name = "NAM";
            NAM.Width = 125;
            // 
            // panel2
            // 
            panel2.Controls.Add(listCourseDetail);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 102);
            panel2.Name = "panel2";
            panel2.Size = new Size(1058, 204);
            panel2.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(390, 38);
            label1.TabIndex = 0;
            label1.Text = "Danh sách lớp và bảng điểm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 0);
            label2.Name = "label2";
            label2.Size = new Size(419, 25);
            label2.TabIndex = 1;
            label2.Text = "Xem danh sách lớp và bảng điểm các lớp phụ trách";
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(1056, 50);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1058, 102);
            panel3.TabIndex = 15;
            // 
            // TeacherRegistrationCourse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Name = "TeacherRegistrationCourse";
            Size = new Size(1058, 750);
            ((System.ComponentModel.ISupportInitialize)listGradeStudents).EndInit();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listCourseDetail).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridViewButtonColumn THAOTAC;
        private DataGridView listGradeStudents;
        private Panel panel5;
        private TextBox searchInputCourseDetail;
        private Button FindBtnCourseDetail;
        private Panel panel7;
        private Panel panel4;
        private DataGridView listCourseDetail;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Panel panel3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn MAHP;
        private DataGridViewTextBoxColumn TENHP;
        private DataGridViewTextBoxColumn SOTC;
        private DataGridViewTextBoxColumn STLT;
        private DataGridViewTextBoxColumn STTH;
        private DataGridViewTextBoxColumn HK;
        private DataGridViewTextBoxColumn NAM;
        private Panel panel6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Panel panel8;
        private TextBox searchInputStudent;
        private Button button1;
        private Label label3;
    }
}
