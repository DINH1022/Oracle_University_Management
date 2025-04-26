using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OUM.View.GrantAuthView;
namespace OUM.View
{
    public partial class GrantPageControl : UserControl
    {
        public GrantPageControl()
        {
            InitializeComponent();
            LoadControl(new GrantUserControl());
        }
        private void LoadControl(UserControl control)
        {
            panelGrant.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelGrant.Controls.Add(control);
        }
        private void privilegeUserBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new GrantUserControl());
        }

        private void GrantRoleControl_Click(object sender, EventArgs e)
        {
            LoadControl(new GrantRoleControl());

        }

        private void GrantRoleToUser_Click(object sender, EventArgs e)
        {
            LoadControl(new GrantRoleToUserControl());
        }
    }
}
