namespace OUM.View.RegistrationCourseView
{
    partial class UpdateStudentGrade
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
            panel3 = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            listCodeCourse = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            panel7 = new Panel();
            searchInputCodeCourse = new TextBox();
            FindBtnCodeCourse = new Button();
            panel5 = new Panel();
            listCourseGrade = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            THAOTAC = new DataGridViewButtonColumn();
            panel6 = new Panel();
            panel8 = new Panel();
            searchInputStudent = new TextBox();
            button1 = new Button();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listCodeCourse).BeginInit();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listCourseGrade).BeginInit();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
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
            panel3.TabIndex = 12;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 0);
            label2.Name = "label2";
            label2.Size = new Size(319, 25);
            label2.TabIndex = 1;
            label2.Text = "Xem và cập nhật điếm số của sinh viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(246, 38);
            label1.TabIndex = 0;
            label1.Text = "Cập nhật điểm số";
            // 
            // panel2
            // 
            panel2.Controls.Add(listCodeCourse);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 102);
            panel2.Name = "panel2";
            panel2.Size = new Size(1058, 204);
            panel2.TabIndex = 13;
            // 
            // listCodeCourse
            // 
            listCodeCourse.BackgroundColor = Color.White;
            listCodeCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listCodeCourse.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            listCodeCourse.Dock = DockStyle.Top;
            listCodeCourse.Location = new Point(0, 56);
            listCodeCourse.Name = "listCodeCourse";
            listCodeCourse.RowHeadersWidth = 51;
            listCodeCourse.Size = new Size(1058, 147);
            listCodeCourse.TabIndex = 17;
            listCodeCourse.SelectionChanged += codeCourseSelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "code";
            dataGridViewTextBoxColumn1.HeaderText = "MÃ MỞ MÔN";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
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
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(searchInputCodeCourse);
            panel7.Controls.Add(FindBtnCodeCourse);
            panel7.Location = new Point(3, 6);
            panel7.Name = "panel7";
            panel7.Size = new Size(611, 46);
            panel7.TabIndex = 13;
            // 
            // searchInputCodeCourse
            // 
            searchInputCodeCourse.Dock = DockStyle.Fill;
            searchInputCodeCourse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInputCodeCourse.Location = new Point(99, 0);
            searchInputCodeCourse.Multiline = true;
            searchInputCodeCourse.Name = "searchInputCodeCourse";
            searchInputCodeCourse.PlaceholderText = "Mã mở môn";
            searchInputCodeCourse.Size = new Size(510, 44);
            searchInputCodeCourse.TabIndex = 2;
            searchInputCodeCourse.TextChanged += searcCodeCourseTextChange;
            // 
            // FindBtnCodeCourse
            // 
            FindBtnCodeCourse.BackColor = Color.PaleGoldenrod;
            FindBtnCodeCourse.Dock = DockStyle.Left;
            FindBtnCodeCourse.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FindBtnCodeCourse.Location = new Point(0, 0);
            FindBtnCodeCourse.Name = "FindBtnCodeCourse";
            FindBtnCodeCourse.Size = new Size(99, 44);
            FindBtnCodeCourse.TabIndex = 0;
            FindBtnCodeCourse.Text = "Tìm kiếm";
            FindBtnCodeCourse.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(listCourseGrade);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 306);
            panel5.Name = "panel5";
            panel5.Size = new Size(1058, 444);
            panel5.TabIndex = 14;
            // 
            // listCourseGrade
            // 
            listCourseGrade.BackgroundColor = Color.White;
            listCourseGrade.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listCourseGrade.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, THAOTAC });
            listCourseGrade.Dock = DockStyle.Fill;
            listCourseGrade.Location = new Point(0, 56);
            listCourseGrade.Name = "listCourseGrade";
            listCourseGrade.RowHeadersWidth = 51;
            listCourseGrade.Size = new Size(1058, 388);
            listCourseGrade.TabIndex = 17;
            listCourseGrade.CellContentClick += UpdateCourseGradeClick;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "MAMM";
            dataGridViewTextBoxColumn7.HeaderText = "MAMM";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "MASV";
            dataGridViewTextBoxColumn8.HeaderText = "MASV";
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
            // THAOTAC
            // 
            THAOTAC.HeaderText = "THAO TÁC";
            THAOTAC.MinimumWidth = 6;
            THAOTAC.Name = "THAOTAC";
            THAOTAC.Text = "Lưu";
            THAOTAC.UseColumnTextForButtonValue = true;
            THAOTAC.Width = 125;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1058, 56);
            panel6.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(searchInputStudent);
            panel8.Controls.Add(button1);
            panel8.Location = new Point(3, 6);
            panel8.Name = "panel8";
            panel8.Size = new Size(611, 46);
            panel8.TabIndex = 13;
            // 
            // searchInputStudent
            // 
            searchInputStudent.Dock = DockStyle.Fill;
            searchInputStudent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInputStudent.Location = new Point(99, 0);
            searchInputStudent.Multiline = true;
            searchInputStudent.Name = "searchInputStudent";
            searchInputStudent.PlaceholderText = "MSSV";
            searchInputStudent.Size = new Size(510, 44);
            searchInputStudent.TabIndex = 2;
            searchInputStudent.TextChanged += searchInputStudentTextChange;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGoldenrod;
            button1.Dock = DockStyle.Left;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(99, 44);
            button1.TabIndex = 0;
            button1.Text = "Tìm kiếm";
            button1.UseVisualStyleBackColor = false;
            // 
            // UpdateStudentGrade
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Name = "UpdateStudentGrade";
            Size = new Size(1058, 750);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listCodeCourse).EndInit();
            panel4.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listCourseGrade).EndInit();
            panel6.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel7;
        private TextBox searchInputCodeCourse;
        private Button FindBtnCodeCourse;
        private DataGridView listCodeCourse;
        private Panel panel5;
        private Panel panel6;
        private Panel panel8;
        private TextBox searchInputStudent;
        private Button button1;
        private DataGridView listCourseGrade;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewButtonColumn THAOTAC;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
