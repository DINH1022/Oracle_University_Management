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
    public partial class ManageStudentControl : UserControl
    {
        public ManageStudentControl()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog();
        }
    }


}
