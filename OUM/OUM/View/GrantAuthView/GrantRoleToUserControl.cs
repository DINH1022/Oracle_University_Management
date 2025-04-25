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

namespace OUM.View.GrantAuthView
{
    public partial class GrantRoleToUserControl : UserControl
    {
        private GrantRoleToUserViewModel viewModel;
        public GrantRoleToUserControl()
        {
            InitializeComponent();
            viewModel = new GrantRoleToUserViewModel();
            setUpListUserDataGridView();
            setUpListRoleDataGridView();
            roleSearchInput.DataBindings.Add("Text", viewModel, "roleSearchKeyword", false, DataSourceUpdateMode.OnPropertyChanged);
            userSearchInput.DataBindings.Add("Text", viewModel, "userSearchKeyword", false, DataSourceUpdateMode.OnPropertyChanged);

        }
        private void setUpListUserDataGridView()
        {
            listUserDataGridView.AutoGenerateColumns = true;
            listUserDataGridView.DataSource = viewModel.Users;
            if (listUserDataGridView.Columns.Count > 0)
            {
                listUserDataGridView.Columns["Username"].HeaderText = "Username";
                listUserDataGridView.Columns["AccountStatus"].HeaderText = "Trạng thái";
                listUserDataGridView.Columns["Created"].HeaderText = "Ngày tạo";
                listUserDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }
        private void setUpListRoleDataGridView()
        {
            listRoleDataGridView.AutoGenerateColumns = true;
            listRoleDataGridView.DataSource = viewModel.Roles;
            if (listRoleDataGridView.Columns.Count > 0)
            {
                listRoleDataGridView.Columns["RoleName"].HeaderText = "Tên Role";
                listRoleDataGridView.Columns["Common"].HeaderText = "Chung";
                listRoleDataGridView.Columns["Inherited"].HeaderText = "Kế thừa";
                listRoleDataGridView.Columns["AuthenticationType"].HeaderText = "Loại xác thực";

                listRoleDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }
        private void grantPrivilegeBtn_Click(object sender, EventArgs e)
        {
            if (listUserDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cấp quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listRoleDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vai trò cần cấp quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            viewModel.SelectedUser = (listUserDataGridView.SelectedRows[0].DataBoundItem as UserSystemInformation)!;
            viewModel.SelectedRole = (listRoleDataGridView.SelectedRows[0].DataBoundItem as RoleSystemInformation)!;
            bool withAdminOption = withAdminOptionCB.Checked;
            bool succes = viewModel.GrantRoleToUser(withAdminOption);
            if (succes)
            {
                MessageBox.Show("Cấp quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cấp quyền không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void withAdminOptionCB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void userSearchBtn(object sender, EventArgs e)
        {
            viewModel.LoadUsers();
            listUserDataGridView.DataSource = null;
            listUserDataGridView.DataSource = viewModel.Users;
        }

        private void roleSearchBtn(object sender, EventArgs e)
        {
            viewModel.LoadRoles();
            listRoleDataGridView.DataSource = null;
            listRoleDataGridView.DataSource = viewModel.Roles;
        }
    }
}
