using OUM.Model;
using OUM.Service.DataAccess;
using OUM.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OUM.View.RegistrationCourseView
{
    public partial class UpdateStudentGrade : UserControl
    {
        private RegistrationCourses dao;
        private List<CodeCourse> codes;
        private List<StudenRegisterdCourseGrade> courseGrade;
        public UpdateStudentGrade()
        {
            InitializeComponent();
            dao = new RegistrationCourses();
            codes = dao.getCodeCourse("");
            courseGrade = dao.getRegistrationGradeCourse("", "");
            setUpCodesDGW();
            setUpCourseGrade();
        }


        private void setUpCodesDGW()
        {
            listCodeCourse.AutoGenerateColumns = false;
            listCodeCourse.DataSource = null;
            listCodeCourse.DataSource = codes;
            listCodeCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void setUpCourseGrade()
        {
            listCourseGrade.AutoGenerateColumns = false;
            listCourseGrade.DataSource = null;
            listCourseGrade.DataSource = courseGrade;
            listCourseGrade.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void searcCodeCourseTextChange(object sender, EventArgs e)
        {
            string keyword = searchInputCodeCourse.Text;
            UpDateCodesDGV(keyword);
        }
        private void searchInputStudentTextChange(object sender, EventArgs e)
        {
            UpdateCodeAndStudentGrade();
        }
        private void UpDateCodesDGV(string keyword)
        {
            codes = dao.getCodeCourse(keyword);
            setUpCodesDGW();
        }
        private void UpDateStudentGrade(string keyword, string mamm)
        {
            courseGrade = dao.getRegistrationGradeCourse(keyword, mamm);
            setUpCourseGrade();
        }
        private void codeCourseSelectionChanged(object sender, EventArgs e)
        {
            UpdateCodeAndStudentGrade();
        }

        private void UpdateCourseGradeClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == listCourseGrade.Columns["THAOTAC"].Index && e.RowIndex >= 0)
            {
                var selectedCourseGrade = listCourseGrade.Rows[e.RowIndex].DataBoundItem as StudenRegisterdCourseGrade;
                if (selectedCourseGrade != null)
                {
                    bool success = dao.UpdateStudentCourseGrade(selectedCourseGrade);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật điểm thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateCodeAndStudentGrade();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi cập nhật điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        private void UpdateCodeAndStudentGrade()
        {
            if (listCodeCourse.SelectedRows.Count > 0)
            {
                var selectedCode = listCodeCourse.SelectedRows[0].DataBoundItem as CodeCourse;
                if (selectedCode != null)
                {
                    string keyword = searchInputStudent.Text;
                    UpDateStudentGrade(keyword, selectedCode.code);
                }
            }
        }
    }
}
