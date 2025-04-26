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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
                

                RoleViewModel vm = new RoleViewModel();
                if (vm.IsRolexists(name))
                {
                    MessageBox.Show("Role đã tồn tại. Vui lòng nhập role khác.");
                    return;
                }
                UserPerRole r = new UserPerRole(name, 0);
                vm.AddRole(r);

                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-00001"))
                {
                    MessageBox.Show("Role đã tồn tại. Vui lòng nhập role khác.");
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm role: " + ex.Message);
                }
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

