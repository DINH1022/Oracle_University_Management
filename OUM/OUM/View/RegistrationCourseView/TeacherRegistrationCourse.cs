using OUM.Model;
using OUM.Service.DataAccess;
using OUM.Session;
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
    public partial class TeacherRegistrationCourse : UserControl
    {
        private List<CourseDetail> detailcourses;
        private List<StudenRegisterdCourseGrade> students;
        private RegistrationCourses dao;
        public TeacherRegistrationCourse()
        {
            InitializeComponent();
            dao = new RegistrationCourses();
            detailcourses = dao.getCourseDetaiOfGV("");
            students = dao.getListStudentsOfGV("");
            SetUpListCourseDetailDGW();
            SetUpListGradeStudentsDGW();
        }
        private void SetUpListCourseDetailDGW()
        {
            listCourseDetail.AutoGenerateColumns = false;
            listCourseDetail.DataSource = null;
            listCourseDetail.DataSource = detailcourses;
            listCourseDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void SetUpListGradeStudentsDGW()
        {
            listGradeStudents.AutoGenerateColumns = false;
            listGradeStudents.DataSource = null;
            listGradeStudents.DataSource = students;
            listGradeStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void searchInputCourseDetailTextChanged(object sender, EventArgs e)
        {
            string keyword = searchInputCourseDetail.Text;
            UpdateCourseDetail(keyword);
        }


        private void UpdateCourseDetail(string keyword)
        {
            detailcourses = dao.getCourseDetaiOfGV(keyword);
            SetUpListCourseDetailDGW();
        }
        private void UpdateGradeStudent(string mamm)
        {
            students = dao.getListStudentsOfGV(mamm);
            SetUpListGradeStudentsDGW();
        }

        private void CourseDetailSelectionChange(object sender, EventArgs e)
        {
            if (listCourseDetail.SelectedRows.Count > 0)
            {
                var selectedCourse = listCourseDetail.SelectedRows[0].DataBoundItem as CourseDetail;
                if (selectedCourse != null)
                {
                    UpdateGradeStudent(selectedCourse.MAMM);
                }
            }
        }
    }
}
