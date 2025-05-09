using OUM.View.RegistrationCourseView;
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
    public partial class RegistrationCoursePageControl : UserControl
    {
        public RegistrationCoursePageControl()
        {
            InitializeComponent();
            LoadControl(new RegisteredCoursePage());
        }

        private void LoadControl(UserControl control)
        {
            panelMainContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(control);
        }

        private void registerNewCourseBtnClick(object sender, EventArgs e)
        {
            LoadControl(new RegisterNewCoursePage());
        }
    }
}
