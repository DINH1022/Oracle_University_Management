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
    public partial class StudentNavPage : Form
    {
        public StudentNavPage()
        {
            InitializeComponent();
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new Account());
        }
        private void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }


        private void LogoutBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void Regiterbutton_Click(object sender, EventArgs e)
        {
            LoadControl(new RegistrationCoursePageControl());
        }
    }
}
