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
    public partial class PDTManagementRegistrationCourse : UserControl
    {
        private List<Student> students;
        private List<NewRegistrationCourse> registeredCourses;
        private List<NewRegistrationCourse> courses;

        private RegistrationCourses dao;
        public PDTManagementRegistrationCourse()
        {
            InitializeComponent();
            students = new List<Student>();
            registeredCourses = new List<NewRegistrationCourse>();
            dao = new RegistrationCourses();
            students = dao.GetAllStudent("");
            registeredCourses = dao.getRegisteredCoursesByMASV("", "");
            courses = dao.getNewRegistrationCoursesByMASV("", "");
            setUpStudentDGW();
            setUpRegisteredCourseDGW();
            setUpNewRegisterCourseDGW();
        }

        private void setUpStudentDGW()
        {
            listStudent.AutoGenerateColumns = false;
            listStudent.DataSource = null;
            listStudent.DataSource = students;
            listStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void setUpRegisteredCourseDGW()
        {
            listRegisteredCourse.AutoGenerateColumns = false;
            listRegisteredCourse.DataSource = null;
            listRegisteredCourse.DataSource = registeredCourses;
            listRegisteredCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (listRegisteredCourse.Columns.Contains("THAOTAC"))
            {
                listRegisteredCourse.Columns["THAOTAC"].Visible = new CheckValidDate().IsWithinRegistrationPeriod();
            }
        }
        private void setUpNewRegisterCourseDGW()
        {
            listCourse.AutoGenerateColumns = false;
            listCourse.DataSource = null;
            listCourse.DataSource = courses;
            listCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (listCourse.Columns.Contains("THTAC"))
            {
                listCourse.Columns["THTAC"].Visible = new CheckValidDate().IsWithinRegistrationPeriod();
            }
        }
        private void searchInputStudentTextChanged(object sender, EventArgs e)
        {
            string keyword = searchInputStudent.Text;
            UpDateStudentDGV(keyword);
        }

        private void studentSeletionChanged(object sender, EventArgs e)
        {
            if (listStudent.SelectedRows.Count > 0)
            {
                var selectedStudent = listStudent.SelectedRows[0].DataBoundItem as Student;
                if (selectedStudent != null)
                {
                    string keyword = searchInputRegisteredCourse.Text;
                    UpDateRegisteredDGV(keyword, selectedStudent.id);
                    UpDateNewRegistraDGV(keyword, selectedStudent.id);
                }
            }
        }

        private void searchInputRegisterdCourseTextChanged(object sender, EventArgs e)
        {
            if (listStudent.SelectedRows.Count > 0)
            {
                var selectedStudent = listStudent.SelectedRows[0].DataBoundItem as Student;
                if (selectedStudent != null)
                {
                    string keyword = searchInputRegisteredCourse.Text;
                    UpDateRegisteredDGV(keyword, selectedStudent.id);
                }
            }
        }

        private void searchInputCourseTextChange(object sender, EventArgs e)
        {
            if (listStudent.SelectedRows.Count > 0)
            {
                var selectedStudent = listStudent.SelectedRows[0].DataBoundItem as Student;
                if (selectedStudent != null)
                {
                    string keyword = searchInputCourse.Text;
                    UpDateNewRegistraDGV(keyword, selectedStudent.id);
                }
            }
        }
        private void registerCourseClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == listCourse.Columns["THTAC"].Index && e.RowIndex >= 0)
            {
                var selectedStudent = listStudent.SelectedRows[0].DataBoundItem as Student;
                var selectedCourse = courses[e.RowIndex];
                if (selectedStudent != null && selectedCourse != null)
                {
                    NewRegistrationCourse selecteCourse = courses[e.RowIndex];
                    bool succes = dao.RegisterCourse(selecteCourse.MAMM, selectedStudent.id);
                    if (succes)
                    {
                        MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string keyword = searchInputCourse.Text;
                        UpDateRegisteredDGV(keyword, selectedStudent.id);
                        UpDateNewRegistraDGV(keyword, selectedStudent.id);
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void registeredCourseClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == listRegisteredCourse.Columns["THAOTAC"].Index && e.RowIndex >= 0)
            {
                var selectedStudent = listStudent.SelectedRows[0].DataBoundItem as Student;
                var selectedRegisteredCourse = registeredCourses[e.RowIndex];
                if (selectedStudent != null && selectedRegisteredCourse != null)
                {
                    NewRegistrationCourse selectedCourse = registeredCourses[e.RowIndex];
                    bool succes = dao.CancelRegistrationCourse(selectedStudent.id, selectedRegisteredCourse.MAMM);
                    if (succes)
                    {
                        MessageBox.Show("Hủy đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string keyword = searchInputRegisteredCourse.Text;
                        UpDateRegisteredDGV(keyword, selectedStudent.id);
                        UpDateNewRegistraDGV(keyword, selectedStudent.id);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi hủy đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void UpDateStudentDGV(string keyword)
        {
            students = dao.GetAllStudent(keyword);
            setUpStudentDGW();
        }
        private void UpDateRegisteredDGV(string keyword, string masv)
        {
            registeredCourses = dao.getRegisteredCoursesByMASV(keyword, masv);
            setUpRegisteredCourseDGW();
        }
        private void UpDateNewRegistraDGV(string keyword, string masv)
        {
            courses = dao.getNewRegistrationCoursesByMASV(keyword, masv);
            setUpNewRegisterCourseDGW();
        }

       
    }
}
