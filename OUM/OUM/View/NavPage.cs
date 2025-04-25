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
    public partial class NavPage : Form
    {
        public NavPage()
        {
            InitializeComponent();
        }

        private void LoadControl(UserControl control)
        {
            panelMainContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(control);
        }


        private void btnQuanLySinhVien_Click(object sender, EventArgs e)
        {
            LoadControl(new ManageStudentControl());
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            LoadControl(new ManageEmployeeControl());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void RevokeBtnNav_click(object sender, EventArgs e)
        {
            LoadControl(new RevokeAuthPageControl());
        }

        private void PerViewBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new PermissionInfo());
        }
    }
}