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
    public partial class RegisterNewCoursePage : UserControl
    {
        private List<NewRegistrationCourse> courses;
        private RegistrationCourses dao;
        public RegisterNewCoursePage()
        {
            InitializeComponent();
            courses = new List<NewRegistrationCourse>();
            dao = new RegistrationCourses();
            courses = dao.GetNewRegistrationCourses("");
            setUpListRegisteredCourseDataGridView();
        }
        private void setUpListRegisteredCourseDataGridView()
        {
            listCourses.AutoGenerateColumns = false;
            listCourses.DataSource = null;
            listCourses.DataSource = courses;
            listCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //DataGridViewButtonColumn cancelBtn = new DataGridViewButtonColumn
            //{
            //    HeaderText = "Thao tác",
            //    Text = "Đăng ký",
            //    UseColumnTextForButtonValue = true,
            //    Name = "registerBtn"
            //};
            //listCourses.Columns.Add(cancelBtn);

        }

        private void searchBtn(object sender, EventArgs e)
        {
            string keyword = searchInput.Text;
            courses = dao.GetNewRegistrationCourses(keyword);
            setUpListRegisteredCourseDataGridView();
        }

        private void searchInputTextChanged(object sender, EventArgs e)
        {
            string keyword = searchInput.Text;
            courses = dao.GetNewRegistrationCourses(keyword);
            setUpListRegisteredCourseDataGridView();
        }
    }
}
