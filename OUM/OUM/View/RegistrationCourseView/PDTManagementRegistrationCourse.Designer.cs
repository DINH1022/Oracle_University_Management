namespace OUM.View.RegistrationCourseView
{
    partial class PDTManagementRegistrationCourse
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
            listStudent = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            panel7 = new Panel();
            searchInputStudent = new TextBox();
            FindBtnStudent = new Button();
            panel5 = new Panel();
            listRegisteredCourse = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            panel6 = new Panel();
            label3 = new Label();
            panel9 = new Panel();
            panel8 = new Panel();
            searchInputRegisteredCourse = new TextBox();
            findBtnRegisteredCourse = new Button();
            panel10 = new Panel();
            listCourse = new DataGridView();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            panel11 = new Panel();
            label4 = new Label();
            panel12 = new Panel();
            panel13 = new Panel();
            searchInputCourse = new TextBox();
            findBtnCourse = new Button();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listStudent).BeginInit();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listRegisteredCourse).BeginInit();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)listCourse).BeginInit();
            panel11.SuspendLayout();
            panel13.SuspendLayout();
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
            panel3.TabIndex = 11;
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
            label2.Size = new Size(388, 25);
            label2.TabIndex = 1;
            label2.Text = "Xem và quản lý đăng ký học phần của sinh viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 12);
            label1.Name = "label1";
            label1.Size = new Size(361, 38);
            label1.TabIndex = 0;
            label1.Text = "Quản lý đăng ký học phần";
            // 
            // panel2
            // 
            panel2.Controls.Add(listStudent);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 102);
            panel2.Name = "panel2";
            panel2.Size = new Size(1058, 298);
            panel2.TabIndex = 13;
            // 
            // listStudent
            // 
            listStudent.BackgroundColor = Color.White;
            listStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listStudent.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            listStudent.Dock = DockStyle.Fill;
            listStudent.Location = new Point(0, 60);
            listStudent.Name = "listStudent";
            listStudent.RowHeadersWidth = 51;
            listStudent.Size = new Size(1058, 238);
            listStudent.TabIndex = 16;
            listStudent.SelectionChanged += studentSeletionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "id";
            dataGridViewTextBoxColumn1.HeaderText = "MSSV";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "name";
            dataGridViewTextBoxColumn2.HeaderText = "HỌ TÊN";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "gender";
            dataGridViewTextBoxColumn3.HeaderText = "GIỚI TÍNH";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "dob";
            dataGridViewTextBoxColumn4.HeaderText = "NGÀY SINH";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "department";
            dataGridViewTextBoxColumn5.HeaderText = "KHOA";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "status";
            dataGridViewTextBoxColumn6.HeaderText = "TÌNH TRẠNG";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel7);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1058, 60);
            panel4.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(searchInputStudent);
            panel7.Controls.Add(FindBtnStudent);
            panel7.Location = new Point(3, 6);
            panel7.Name = "panel7";
            panel7.Size = new Size(611, 46);
            panel7.TabIndex = 13;
            // 
            // searchInputStudent
            // 
            searchInputStudent.Dock = DockStyle.Fill;
            searchInputStudent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInputStudent.Location = new Point(99, 0);
            searchInputStudent.Multiline = true;
            searchInputStudent.Name = "searchInputStudent";
            searchInputStudent.PlaceholderText = "Họ tên, MSSV";
            searchInputStudent.Size = new Size(510, 44);
            searchInputStudent.TabIndex = 2;
            searchInputStudent.TextChanged += searchInputStudentTextChanged;
            // 
            // FindBtnStudent
            // 
            FindBtnStudent.BackColor = Color.PaleGoldenrod;
            FindBtnStudent.Dock = DockStyle.Left;
            FindBtnStudent.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FindBtnStudent.Location = new Point(0, 0);
            FindBtnStudent.Name = "FindBtnStudent";
            FindBtnStudent.Size = new Size(99, 44);
            FindBtnStudent.TabIndex = 0;
            FindBtnStudent.Text = "Tìm kiếm";
            FindBtnStudent.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(listRegisteredCourse);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 400);
            panel5.Name = "panel5";
            panel5.Size = new Size(1058, 400);
            panel5.TabIndex = 14;
            // 
            // listRegisteredCourse
            // 
            listRegisteredCourse.BackgroundColor = Color.White;
            listRegisteredCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listRegisteredCourse.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewButtonColumn2 });
            listRegisteredCourse.Dock = DockStyle.Fill;
            listRegisteredCourse.Location = new Point(0, 125);
            listRegisteredCourse.Name = "listRegisteredCourse";
            listRegisteredCourse.RowHeadersWidth = 51;
            listRegisteredCourse.Size = new Size(1058, 275);
            listRegisteredCourse.TabIndex = 16;
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
            dataGridViewTextBoxColumn8.DataPropertyName = "MAHP";
            dataGridViewTextBoxColumn8.HeaderText = "MAHP";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "TENHP";
            dataGridViewTextBoxColumn9.HeaderText = "TÊN HỌC PHẦN";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.DataPropertyName = "SOTC";
            dataGridViewTextBoxColumn10.HeaderText = "SỐ TC";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "STTH";
            dataGridViewTextBoxColumn11.HeaderText = "THỰC HÀNH";
            dataGridViewTextBoxColumn11.MinimumWidth = 6;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.Width = 125;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.DataPropertyName = "STLT";
            dataGridViewTextBoxColumn12.HeaderText = "LÝ THUYẾT";
            dataGridViewTextBoxColumn12.MinimumWidth = 6;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.Width = 125;
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewButtonColumn2.HeaderText = "THAO TÁC";
            dataGridViewButtonColumn2.MinimumWidth = 6;
            dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            dataGridViewButtonColumn2.Text = "Hủy đăng ký";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumn2.Width = 125;
            // 
            // panel6
            // 
            panel6.Controls.Add(label3);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(panel8);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1058, 125);
            panel6.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 32);
            label3.Name = "label3";
            label3.Size = new Size(290, 38);
            label3.TabIndex = 15;
            label3.Text = "Học phần đã đăng ký";
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(1058, 29);
            panel9.TabIndex = 14;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(searchInputRegisteredCourse);
            panel8.Controls.Add(findBtnRegisteredCourse);
            panel8.Location = new Point(4, 73);
            panel8.Name = "panel8";
            panel8.Size = new Size(611, 46);
            panel8.TabIndex = 13;
            // 
            // searchInputRegisteredCourse
            // 
            searchInputRegisteredCourse.Dock = DockStyle.Fill;
            searchInputRegisteredCourse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInputRegisteredCourse.Location = new Point(99, 0);
            searchInputRegisteredCourse.Multiline = true;
            searchInputRegisteredCourse.Name = "searchInputRegisteredCourse";
            searchInputRegisteredCourse.PlaceholderText = "Học phần";
            searchInputRegisteredCourse.Size = new Size(510, 44);
            searchInputRegisteredCourse.TabIndex = 2;
            searchInputRegisteredCourse.TextChanged += searchInputRegisterdCourseTextChanged;
            // 
            // findBtnRegisteredCourse
            // 
            findBtnRegisteredCourse.BackColor = Color.PaleGoldenrod;
            findBtnRegisteredCourse.Dock = DockStyle.Left;
            findBtnRegisteredCourse.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            findBtnRegisteredCourse.Location = new Point(0, 0);
            findBtnRegisteredCourse.Name = "findBtnRegisteredCourse";
            findBtnRegisteredCourse.Size = new Size(99, 44);
            findBtnRegisteredCourse.TabIndex = 0;
            findBtnRegisteredCourse.Text = "Tìm kiếm";
            findBtnRegisteredCourse.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            panel10.Controls.Add(listCourse);
            panel10.Controls.Add(panel11);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 800);
            panel10.Name = "panel10";
            panel10.Size = new Size(1058, 429);
            panel10.TabIndex = 15;
            // 
            // listCourse
            // 
            listCourse.BackgroundColor = Color.White;
            listCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            listCourse.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17, dataGridViewTextBoxColumn18, dataGridViewButtonColumn3 });
            listCourse.Dock = DockStyle.Fill;
            listCourse.Location = new Point(0, 125);
            listCourse.Name = "listCourse";
            listCourse.RowHeadersWidth = 51;
            listCourse.Size = new Size(1058, 304);
            listCourse.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.DataPropertyName = "MAMM";
            dataGridViewTextBoxColumn13.HeaderText = "MAMM";
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.Width = 125;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.DataPropertyName = "MAHP";
            dataGridViewTextBoxColumn14.HeaderText = "MAHP";
            dataGridViewTextBoxColumn14.MinimumWidth = 6;
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.Width = 125;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.DataPropertyName = "TENHP";
            dataGridViewTextBoxColumn15.HeaderText = "TÊN HỌC PHẦN";
            dataGridViewTextBoxColumn15.MinimumWidth = 6;
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.Width = 125;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.DataPropertyName = "SOTC";
            dataGridViewTextBoxColumn16.HeaderText = "SỐ TC";
            dataGridViewTextBoxColumn16.MinimumWidth = 6;
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.Width = 125;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.DataPropertyName = "STTH";
            dataGridViewTextBoxColumn17.HeaderText = "THỰC HÀNH";
            dataGridViewTextBoxColumn17.MinimumWidth = 6;
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.Width = 125;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewTextBoxColumn18.DataPropertyName = "STLT";
            dataGridViewTextBoxColumn18.HeaderText = "LÝ THUYẾT";
            dataGridViewTextBoxColumn18.MinimumWidth = 6;
            dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            dataGridViewTextBoxColumn18.Width = 125;
            // 
            // dataGridViewButtonColumn3
            // 
            dataGridViewButtonColumn3.HeaderText = "THAO TÁC";
            dataGridViewButtonColumn3.MinimumWidth = 6;
            dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            dataGridViewButtonColumn3.Text = "Đăng ký";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumn3.Width = 125;
            // 
            // panel11
            // 
            panel11.Controls.Add(label4);
            panel11.Controls.Add(panel12);
            panel11.Controls.Add(panel13);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(1058, 125);
            panel11.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(4, 32);
            label4.Name = "label4";
            label4.Size = new Size(319, 38);
            label4.TabIndex = 15;
            label4.Text = "Học phần chưa đăng ký";
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 0);
            panel12.Name = "panel12";
            panel12.Size = new Size(1058, 29);
            panel12.TabIndex = 14;
            // 
            // panel13
            // 
            panel13.BackColor = Color.White;
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Controls.Add(searchInputCourse);
            panel13.Controls.Add(findBtnCourse);
            panel13.Location = new Point(4, 73);
            panel13.Name = "panel13";
            panel13.Size = new Size(611, 46);
            panel13.TabIndex = 13;
            // 
            // searchInputCourse
            // 
            searchInputCourse.Dock = DockStyle.Fill;
            searchInputCourse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInputCourse.Location = new Point(99, 0);
            searchInputCourse.Multiline = true;
            searchInputCourse.Name = "searchInputCourse";
            searchInputCourse.PlaceholderText = "Học phần";
            searchInputCourse.Size = new Size(510, 44);
            searchInputCourse.TabIndex = 2;
            // 
            // findBtnCourse
            // 
            findBtnCourse.BackColor = Color.PaleGoldenrod;
            findBtnCourse.Dock = DockStyle.Left;
            findBtnCourse.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            findBtnCourse.Location = new Point(0, 0);
            findBtnCourse.Name = "findBtnCourse";
            findBtnCourse.Size = new Size(99, 44);
            findBtnCourse.TabIndex = 0;
            findBtnCourse.Text = "Tìm kiếm";
            findBtnCourse.UseVisualStyleBackColor = false;
            // 
            // PDTManagementRegistrationCourse
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel10);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Name = "PDTManagementRegistrationCourse";
            Size = new Size(1058, 1229);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listStudent).EndInit();
            panel4.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listRegisteredCourse).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)listCourse).EndInit();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private DataGridView listStudent;
        private Panel panel4;
        private Panel panel7;
        private TextBox searchInputStudent;
        private Button FindBtnStudent;
        private Panel panel5;
        private DataGridView listRegisteredCourse;
        private Panel panel6;
        private Label label3;
        private Panel panel9;
        private Panel panel8;
        private TextBox searchInputRegisteredCourse;
        private Button findBtnRegisteredCourse;
        private Panel panel10;
        private DataGridView listCourse;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewButtonColumn dataGridViewButtonColumn3;
        private Panel panel11;
        private Label label4;
        private Panel panel12;
        private Panel panel13;
        private TextBox searchInputCourse;
        private Button findBtnCourse;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
