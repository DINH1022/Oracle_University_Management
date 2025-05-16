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

        private void registerBtnClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == listCourses.Columns["THAOTAC"].Index && e.RowIndex >= 0)
            {
                NewRegistrationCourse selectedCourse = courses[e.RowIndex];
                bool success = dao.RegisterCourse(selectedCourse.MAMM,AdminSession.Username.Substring(2));
                if (success)
                {
                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string keyword = searchInput.Text;
                    courses = dao.GetNewRegistrationCourses(keyword);
                    setUpListRegisteredCourseDataGridView();

                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
