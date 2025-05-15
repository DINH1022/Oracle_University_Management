using OUM.Model;
using OUM.Service.DataAccess;
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
        private RegistrationCourses dao;
        public PDTManagementRegistrationCourse()
        {
            InitializeComponent();
            students = new List<Student>();
            registeredCourses = new List<NewRegistrationCourse>();
            dao = new RegistrationCourses();
            students = dao.GetAllStudent("");
            registeredCourses = dao.getRegisteredCoursesByMASV("", "");
            setUpStudentDGW();
            setRegisteredCourseDGW();
        }

        private void setUpStudentDGW()
        {
            listStudent.AutoGenerateColumns = false;
            listStudent.DataSource = null;
            listStudent.DataSource = students;
            listStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void setRegisteredCourseDGW()
        {
            listRegisteredCourse.AutoGenerateColumns = false;
            listRegisteredCourse.DataSource = null;
            listRegisteredCourse.DataSource = registeredCourses;
            listRegisteredCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void searchInputStudentTextChanged(object sender, EventArgs e)
        {
            string keyword = searchInputStudent.Text;
            students = dao.GetAllStudent(keyword);
            setUpStudentDGW();
        }

        private void studentSeletionChanged(object sender, EventArgs e)
        {
            if (listStudent.SelectedRows.Count > 0)
            {
                var selectedStudent = listStudent.SelectedRows[0].DataBoundItem as Student;
                if (selectedStudent != null)
                {
                    string keyword = searchInputRegisteredCourse.Text;
                    registeredCourses = dao.getRegisteredCoursesByMASV(keyword, selectedStudent.id);
                    setRegisteredCourseDGW();
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
                    registeredCourses = dao.getRegisteredCoursesByMASV(keyword, selectedStudent.id);
                    setRegisteredCourseDGW();
                }
            }
        }



        //private void ListObjectDGV_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (listObjectDGV.SelectedRows.Count > 0)
        //    {
        //        var selectedObject = listObjectDGV.SelectedRows[0].DataBoundItem as DatabaseObject;
        //        if (selectedObject != null)
        //        {
        //            viewModel.SelectedObject = selectedObject;
        //            viewModel.UpdatePrivileges(selectedObject.ObjectType);
        //            privilegeCombox.DataSource = null;
        //            privilegeCombox.DataSource = viewModel.Privileges;
        //            UpadateColumnCheckboxes(selectedObject);
        //        }
        //    }
        //    else
        //    {
        //        flowLayoutPanel1.Controls.Clear();
        //    }
        //}

    }
}
