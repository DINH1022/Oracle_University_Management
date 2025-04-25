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
    public partial class GrantUserControl : UserControl
    {
        private GrantUserViewModel viewModel;
        public GrantUserControl()
        {
            InitializeComponent();
            viewModel = new GrantUserViewModel();
            setUpListUserDataGridView();
            setUpComboxandDataGridViewDBObect();
            searchInput.DataBindings.Add("Text", viewModel, "searchKeyword", false, DataSourceUpdateMode.OnPropertyChanged);


        }
        private void GrantUserControl_Load(object sender, EventArgs e)
        {
            viewModel.LoadUsers();
            viewModel.LoadDatabaseObject();
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
        private void setUpComboxandDataGridViewDBObect()
        {
            objectsCombox.DataSource = viewModel.ObjectTypes;
            privilegeCombox.DataSource = viewModel.Privileges;
            objectsCombox.SelectedIndexChanged += (s, e) =>
            {
                viewModel.SelectedObjectType = objectsCombox.SelectedItem?.ToString() ?? "ALL";
                viewModel.LoadDatabaseObject();
                listObjectDGV.DataSource = null;
                listObjectDGV.DataSource = viewModel.DatabaseObjects;
            };
            privilegeCombox.SelectedIndexChanged += (s, e) =>
            {
                viewModel.SelectedPrivilege = privilegeCombox.SelectedItem?.ToString() ?? "SELECT";
                if (listObjectDGV.SelectedRows.Count > 0)
                {
                    var selectedObject = listObjectDGV.SelectedRows[0].DataBoundItem as DatabaseObject;
                    if (selectedObject != null)
                    {
                        UpadateColumnCheckboxes(selectedObject);
                    }
                }
            };
            listObjectDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listObjectDGV.AutoGenerateColumns = true;
            listObjectDGV.DataSource = viewModel.DatabaseObjects;
            listObjectDGV.SelectionChanged += ListObjectDGV_SelectionChanged;
        }

        private void ListObjectDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (listObjectDGV.SelectedRows.Count > 0)
            {
                var selectedObject = listObjectDGV.SelectedRows[0].DataBoundItem as DatabaseObject;
                if (selectedObject != null)
                {
                    viewModel.SelectedObject = selectedObject;
                    viewModel.UpdatePrivileges(selectedObject.ObjectType);
                    privilegeCombox.DataSource = null;
                    privilegeCombox.DataSource = viewModel.Privileges;
                    UpadateColumnCheckboxes(selectedObject);
                }
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
            }
        }
        private void UpadateColumnCheckboxes(DatabaseObject selectedObject)
        {
            bool isTableorView = selectedObject.ObjectType == "TABLE" || selectedObject.ObjectType == "VIEW";
            bool isSelectOrUpdate = viewModel.SelectedPrivilege == "UPDATE";
            if (isTableorView && isSelectOrUpdate)
            {
                GenerateColumnCheckbox(selectedObject.Name, selectedObject.ObjectType);
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
            }

        }
        private void GenerateColumnCheckbox(string objectName, string objectType)
        {
            flowLayoutPanel1.Controls.Clear();
            var columns = viewModel.GetColumsForObject(objectName, objectType);

            CheckBox checkBoxAll = new CheckBox
            {
                Text = "Tất cả",
                AutoSize = true,
                Margin = new Padding(5),
                Tag = "ALL"
            };
            checkBoxAll.CheckedChanged += (s, e) =>
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is CheckBox cb && control != checkBoxAll)
                    {
                        cb.Checked = checkBoxAll.Checked;
                    }
                }
            };
            flowLayoutPanel1.Controls.Add(checkBoxAll);
            Panel separator = new Panel
            {
                Height = 1,
                Width = flowLayoutPanel1.Width - 10,
                BackColor = Color.LightGray,
                Margin = new Padding(5),
            };
            flowLayoutPanel1.Controls.Add(separator);
            foreach (var column in columns)
            {
                CheckBox checkBox = new CheckBox
                {
                    Text = column,
                    AutoSize = true,
                    Margin = new Padding(5),
                    Tag = column,
                };
                flowLayoutPanel1.Controls.Add(checkBox);
            }
        }

        private void grantPrivilegeBtn_Click(object sender, EventArgs e)
        {
            if (listUserDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cấp quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listObjectDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng cần cấp quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            viewModel.SelectedUser = (listUserDataGridView.SelectedRows[0].DataBoundItem as UserSystemInformation)!;
            viewModel.SelectedObject = (listObjectDGV.SelectedRows[0].DataBoundItem as DatabaseObject)!;
            List<string> selectedcolumns = null;
            if ((viewModel.SelectedObject.ObjectType == "TABLE" || viewModel.SelectedObject.ObjectType == "VIEW") &&
                (viewModel.SelectedPrivilege == "UPDATE"))
            {
                selectedcolumns = SelectedColumns();
                if (selectedcolumns.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một cột để cấp quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            bool withGrantOption = withGrantOptionCB.Checked;
            bool succes = viewModel.GrantPrivilegeToUser(selectedcolumns, withGrantOption);
            if (succes)
            {
                MessageBox.Show("Cấp quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cấp quyền không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<string> SelectedColumns()
        {
            List<string> columns = new List<string>();
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CheckBox cb && cb.Checked)
                {
                    if (cb.Tag?.ToString() == "ALL")
                    {
                        return new List<string> { "ALL" };
                    }
                    else
                    {
                        columns.Add(cb.Tag?.ToString());
                    }
                }
            }
            return columns;
        }

        private void searchBtn(object sender, EventArgs e)
        {
            viewModel.LoadUsers();
            listUserDataGridView.DataSource = null;
            listUserDataGridView.DataSource = viewModel.Users;
        }
    }
}
