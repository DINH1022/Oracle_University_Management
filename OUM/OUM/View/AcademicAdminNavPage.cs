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
using OUM.View.RegistrationCourseView;
namespace OUM.View
{
    public partial class AcademicAdminNavPage : Form
    {
        public AcademicAdminNavPage()
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

        private void Regiterbutton_Click(object sender, EventArgs e)
        {
            LoadControl(new PDTManagementRegistrationCourse());
        }

        private void CloseApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Coursebutton_Click(object sender, EventArgs e)
        {
        }
    }
}
