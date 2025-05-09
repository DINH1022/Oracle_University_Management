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
    public partial class RegisteredCoursePage : UserControl
    {
        private RegistrationCourses dao;
        private List<RegisteredCourse> registeredCourses;
        public RegisteredCoursePage()
        {
            InitializeComponent();
            dao = new RegistrationCourses();
            registeredCourses = dao.getAllRegisteredCourses();
            setUpListRegisteredCourseDataGridView();
        }
        private void setUpListRegisteredCourseDataGridView()
        {
            listRegisteredCourses.AutoGenerateColumns = true;
            listRegisteredCourses.DataSource = registeredCourses;
            listRegisteredCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
