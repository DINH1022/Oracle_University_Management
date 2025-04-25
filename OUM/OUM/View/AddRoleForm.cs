using OUM.Model;
using OUM.ViewModel;
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
    public partial class AddRoleForm : Form
    {
        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtRoleName.Text.Trim();


                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Vui lòng điền tên vai trò.");
                    return;
                }
                UserPerRole r = new UserPerRole(name, 0);

                RoleViewModel vm = new RoleViewModel();
                vm.AddRole(r);

                MessageBox.Show("Thêm role thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm role: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtRoleName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

