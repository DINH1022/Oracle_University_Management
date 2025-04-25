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

        private void GrantPageControl_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void privilegeUserBtn_Click(object sender, EventArgs e)
        {
            LoadControl(new GrantUserControl());
        }
    }
}
