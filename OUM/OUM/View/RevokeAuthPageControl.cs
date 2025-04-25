using OUM.Model;
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
    public partial class RevokeAuthPageControl : UserControl
    {
        private const string TEXT_USER_AUTH_PAGE = "Quyền của người dùng";
        private const string TEXT_ROLE_AUTH_PAGE = "Quyền của vai trò";
        private const string TEXT_ROLE_OF_USER_PAGE = "Vai trò của người dùng";
        private Boolean isDisplayingGrantInfor = true;
        private List<GrantInformation> grantInformations = new List<GrantInformation>();
        private List<UserRoleInformation> userRoleInformations = new List<UserRoleInformation>();
        public RevokeAuthPageControl()
        {
            InitializeComponent();
        }
        private DataGridViewButtonColumn createDeleteBtnColumn()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = "Thao tác",
                Text = "Xóa quyền",
                UseColumnTextForButtonValue = true,
                Name = "DeleteButton"
            };
            return btn;
        }

        private void refresh_datagrid_user()
        {
            label2.Text = TEXT_USER_AUTH_PAGE;
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn UserCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ObjCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn AuthorCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColsCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn GrantOptCol = new DataGridViewTextBoxColumn();

            UserCol.HeaderText = "Người dùng";
            ObjCol.HeaderText = "Đối tượng";
            AuthorCol.HeaderText = "Quyền";
            ColsCol.HeaderText = "Cột";
            GrantOptCol.HeaderText = "WITH GRANT OPTION";
            UserCol.DataPropertyName = "Name";
            ObjCol.DataPropertyName = "ObjectName";
            AuthorCol.DataPropertyName = "Authority";
            ColsCol.DataPropertyName = "Columns";
            GrantOptCol.DataPropertyName = "GrantOption";

            DataGridViewButtonColumn deleteButtonColumn = createDeleteBtnColumn();

            dataGridView1.Columns.Add(UserCol);
            dataGridView1.Columns.Add(ObjCol);
            dataGridView1.Columns.Add(AuthorCol);
            dataGridView1.Columns.Add(ColsCol);
            dataGridView1.Columns.Add(GrantOptCol);
            dataGridView1.Columns.Add(deleteButtonColumn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            configUICells();
        }
        private void refresh_datagrid_role()
        {
            label2.Text = TEXT_ROLE_AUTH_PAGE;
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn UserCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ObjCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn AuthorCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ColsCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn GrantOptCol = new DataGridViewTextBoxColumn();
            DataGridViewButtonColumn deleteButtonColumn = createDeleteBtnColumn();

            UserCol.HeaderText = "Vai trò";
            ObjCol.HeaderText = "Đối tượng";
            AuthorCol.HeaderText = "Quyền";
            ColsCol.HeaderText = "Cột";
            GrantOptCol.HeaderText = "WITH GRANT OPTION";

            UserCol.DataPropertyName = "Name";
            ObjCol.DataPropertyName = "ObjectName";
            AuthorCol.DataPropertyName = "Authority";
            ColsCol.DataPropertyName = "Columns";
            GrantOptCol.DataPropertyName = "GrantOption";

            dataGridView1.Columns.Add(UserCol);
            dataGridView1.Columns.Add(ObjCol);
            dataGridView1.Columns.Add(AuthorCol);
            dataGridView1.Columns.Add(ColsCol);
            dataGridView1.Columns.Add(GrantOptCol);
            dataGridView1.Columns.Add(deleteButtonColumn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            configUICells();
        }

        private void refresh_datagrid_role_of_user()
        {
            label2.Text = TEXT_ROLE_OF_USER_PAGE;
            dataGridView1.Columns.Clear();
            DataGridViewTextBoxColumn UserCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn RoleCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn GrantOptCol = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn DelCol = new DataGridViewTextBoxColumn();
            UserCol.HeaderText = "Người dùng";
            RoleCol.HeaderText = "Vai trò";
            GrantOptCol.HeaderText = "WITH GRANT OPTION";
            DataGridViewButtonColumn deleteButtonColumn = createDeleteBtnColumn();

            UserCol.DataPropertyName = "Name";
            RoleCol.DataPropertyName = "Role";
            GrantOptCol.DataPropertyName = "GrantOption";

            dataGridView1.Columns.Add(UserCol);
            dataGridView1.Columns.Add(RoleCol);
            dataGridView1.Columns.Add(GrantOptCol);
            dataGridView1.Columns.Add(deleteButtonColumn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            configUICells();
        }

        private List<GrantInformation> mockListGrant()
        {
            List<GrantInformation> grantInformation = new List<GrantInformation>();
            GrantInformation a1 = new GrantInformation("nvcb001", "NHANVIEN", "SELECT", "MANV,HOTEN,PHAI", "Không");
            GrantInformation a2 = new GrantInformation("nvcb001", "NHANVIEN", "SELECT, UPDATE", "MANV,HOTEN,PHAI", "Không");
            GrantInformation a3 = new GrantInformation("nvcb001", "NHANVIEN", "SELECT", "MANV,HOTEN,PHAI", "Không");
            GrantInformation a4 = new GrantInformation("nvcb001", "NHANVIEN", "SELECT", "MANV,HOTEN,PHAI", "Không");
            GrantInformation a5 = new GrantInformation("nvcb001", "NHANVIEN", "SELECT", "MANV,HOTEN,PHAI", "Không");
            GrantInformation a6 = new GrantInformation("nvcb001", "NHANVIEN", "SELECT, DELETE", "MANV,HOTEN,PHAI", "Không");
            GrantInformation a7 = new GrantInformation("nvcb001", "NHANVIEN", "SELECT", "MANV,HOTEN,PHAI", "Không");
            grantInformation.Add(a1);
            grantInformation.Add(a2);
            grantInformation.Add(a3);
            grantInformation.Add(a4);
            grantInformation.Add(a5);
            grantInformation.Add(a6);
            grantInformation.Add(a7);
            return grantInformation;
        }

        private void initData()
        {
            grantInformations = mockListGrant();
        }

        private void configUIHeaders()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

        }
        private void configUICells()
        {
            //dataGridView1.DefaultCellStyle.Padding = new Padding(5);
            int lastColumnIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns[lastColumnIndex].DefaultCellStyle.Padding = new Padding(0);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void RevokeAuthPageControl_Load(object sender, EventArgs e)
        {
            refresh_datagrid_user();
            initData();
            configUIHeaders();
            configUICells();
            dataGridView1.DataSource = grantInformations;
            dataGridView1.AutoResizeRows();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the delete button column
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this grant?" + $"{label2.Text}",
                    "Confirm Delete ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh_datagrid_user();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh_datagrid_role();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh_datagrid_role_of_user();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                //restore the old one;
                if (isDisplayingGrantInfor)
                {
                    dataGridView1.DataSource = grantInformations;
                }
                else
                {
                    dataGridView1.DataSource = userRoleInformations;
                }
            }
            if (isDisplayingGrantInfor)
            {
                List<GrantInformation> newDisplayingGrantInformations = grantInformations
                    .Where(grant => grant.Name.ToLower().Contains(textBox1.Text.ToLower())
                    || grant.ObjectName.ToLower().Contains(textBox1.Text.ToLower())
                    || grant.Authority.ToLower().Contains(textBox1.Text.ToLower())
                    || grant.Columns.ToLower().Contains(textBox1.Text.ToLower())
                    ).ToList();
                dataGridView1.DataSource = newDisplayingGrantInformations;
            }
            else
            {
                List<UserRoleInformation> newDisplayingUserRoleInfors = userRoleInformations
                    .Where(obj => obj.Name.Contains(textBox1.Text.ToLower())
                    || obj.Role.Contains(textBox1.Text.ToLower())
                    ).ToList();
                dataGridView1.DataSource = newDisplayingUserRoleInfors;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
