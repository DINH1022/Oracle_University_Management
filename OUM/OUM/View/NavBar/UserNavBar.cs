using OUM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OUM.View
{
    public partial class UserNavBar : Form
    {
        public UserNavBar()
        {
            InitializeComponent();
        }

        private void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new Account());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void StudentBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new ManageStudentControl());
        }

        private void EmpBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new ManageEmployeeControl());
        }

        private void Coursebutton_Click(object sender, EventArgs e)
        {
            LoadControl(new CourseOpenControl());
        }

        private void Regiterbutton_Click(object sender, EventArgs e)
        {
            LoadControl(new RegistrationCoursePageControl());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoticeBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new NoticeControl());
        }
    }
}
