using Microsoft.VisualBasic.Logging;
using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Service.DataAccess;
using OUM.Session;
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
    public partial class PermissionInfo : UserControl
    {
        private AdminViewModel viewModel;
        private OracleDAO dao;
        private List<PermissionIn> permissions = new List<PermissionIn>();
        public string GetConnectionString()
        {
            return $"User Id={AdminSession.Username};Password={AdminSession.Password};Data Source=localhost:1521/DKHP;";
        }

        public PermissionInfo()
        {
            InitializeComponent();
            viewModel = new AdminViewModel();
            dao = new OracleDAO();
            this.Load += PermissionInfo_Load;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void PermissionInfo_Load(object sender, EventArgs e)
        {
            LoadAllRolesToComboBox();
            LoadAllUsersToComboBox();
            LoadObjectsToComboBox();

            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }


        private void LoadAllUsersToComboBox()
        {
            List<UserInfo> users = dao.GetAllUsers();
            users.Insert(0, new UserInfo("None", "None", "None"));

            if (users.Count > 0)
            {

                USER_Combobox.DataSource = users;
                USER_Combobox.DisplayMember = "UserId";  // Hiển thị tên người dùng trong ComboBox
                USER_Combobox.ValueMember = "UserId";     // Lưu giá trị UserId khi chọn
            }
            else
            {
                MessageBox.Show("Không có người dùng trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void LoadAllRolesToComboBox()
        {
            List<string> roles = dao.GetAllRoles();

            if (roles.Count > 0)
            {
                ROLE_Combobox.DataSource = roles;
            }
            else
            {
                MessageBox.Show("Không có roles trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadObjectsToComboBox()
        {
            List<string> tables = dao.GetAllTables();
            List<string> procedures = dao.GetAllProcedures();
            List<string> functions = dao.GetAllFunctions();

            List<string> allObjects = new List<string>();
            allObjects.AddRange(tables);
            allObjects.AddRange(procedures);
            allObjects.AddRange(functions);

            if (allObjects.Count > 0)
            {
                OBJECT_Combobox.DataSource = allObjects;
            }
            else
            {
                MessageBox.Show("Không có đối tượng nào trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.ToLower();  // Lấy văn bản từ TextBox và chuyển thành chữ thường để so sánh không phân biệt chữ hoa và chữ thường

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = permissions;
            }
            else
            {
                var filteredPermissions = permissions.Where(p =>
                    p.Name.ToLower().Contains(searchText) ||          // Kiểm tra theo Name (User)
                    p.ObjectName.ToLower().Contains(searchText) ||    // Kiểm tra theo ObjectName
                    p.Authority.ToLower().Contains(searchText) ||     // Kiểm tra theo Authority
                    p.Operation.ToLower().Contains(searchText) ||     // Kiểm tra theo Operation
                    p.Columns.ToLower().Contains(searchText) ||       // Kiểm tra theo Columns
                    p.Role.ToLower().Contains(searchText)             // Kiểm tra theo Role (Role)
                ).ToList();

                dataGridView1.DataSource = filteredPermissions;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void USER_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userId = USER_Combobox.SelectedValue.ToString();
            //MessageBox.Show($"UserId Selected: {userId}");
            //var permissions = GetUserPermissions(userId);

            if (userId == "None")
            {
                dataGridView1.DataSource = null;  // Không hiển thị gì trong DataGridView
            }
            else
            {
                var userPermissions = GetUserPermissions(userId);
                permissions = userPermissions;

                if (permissions.Count > 0)
                {
                    dataGridView1.DataSource = userPermissions;
                }
                else
                {
                    MessageBox.Show("Không có quyền cho người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        

        private List<PermissionIn> GetUserPermissions(string userId)
        {
            List<PermissionIn> permissions = new List<PermissionIn>();
            string query = "SELECT GRANTEE, TABLE_NAME, PRIVILEGE, GRANTABLE, OWNER " +
                   "FROM DBA_TAB_PRIVS WHERE GRANTEE LIKE :userId";

            string query2 = "SELECT GRANTEE, OWNER, TABLE_NAME, COLUMN_NAME, PRIVILEGE " +
                    "FROM DBA_COL_PRIVS WHERE GRANTEE LIKE :userId";

            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(new OracleParameter(":userId", userId +"%" ));

                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        permissions.Add(new PermissionIn
                        {
                            Name = reader["GRANTEE"].ToString(),
                            ObjectName = reader["TABLE_NAME"].ToString(),
                            Authority = reader["PRIVILEGE"].ToString(),
                            GrantOption = reader["GRANTABLE"].ToString(),
                            Operation = reader["OWNER"]?.ToString(),
                            Columns = "NONE"
                        });
                    }

                    OracleCommand command2 = new OracleCommand(query2, connection);
                    command2.Parameters.Add(new OracleParameter(":userId", userId + "%"));
                    OracleDataReader reader2 = command2.ExecuteReader();

                    while (reader2.Read())
                    {
                        permissions.Add(new PermissionIn
                        {
                            Name = reader2["GRANTEE"].ToString(),
                            ObjectName = reader2["TABLE_NAME"].ToString(),
                            Authority = reader2["PRIVILEGE"].ToString(),
                            GrantOption = "NONE",  // Quyền cấp lại không có cho quyền cột
                            Operation = reader2["OWNER"]?.ToString(),
                            Columns = reader2["COLUMN_NAME"].ToString() // Thêm cột cho quyền trên cột
                        });
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy quyền người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return permissions;
        }

        private void ROLE_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string roleName = ROLE_Combobox.SelectedItem.ToString();
            var rolepermissions = GetRolePermissions(roleName);
            permissions = rolepermissions;

            if (permissions.Count > 0)
            {
                dataGridView1.DataSource = rolepermissions;
            }
            else
            {
                MessageBox.Show("Không có quyền cho vai trò này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private List<PermissionIn> GetRolePermissions(string roleName)
        {
            List<PermissionIn> permissions = new List<PermissionIn>();
            string query = "SELECT GRANTEE, TABLE_NAME, PRIVILEGE, 'NONE' AS COLUMN_NAME, GRANTABLE , GRANTOR  FROM DBA_TAB_PRIVS WHERE GRANTEE = :roleName";

            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(new OracleParameter(":roleName", roleName));
                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        permissions.Add(new PermissionIn
                        {
                            //Name = reader["GRANTEE"].ToString(),
                            Role = reader["GRANTEE"].ToString(),
                            ObjectName = reader["TABLE_NAME"].ToString(),
                            Authority = reader["PRIVILEGE"].ToString(),
                            Columns = reader["COLUMN_NAME"].ToString(),
                            GrantOption = reader["GRANTABLE"].ToString(),
                            Operation = reader["GRANTOR"]?.ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy quyền vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return permissions;
        }

        private void OBJECT_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string objectName = OBJECT_Combobox.SelectedItem.ToString();
            var objectpermissions = GetObjectPermissions(objectName);
            permissions = objectpermissions;

           

            if (permissions.Count > 0)
            {
                dataGridView1.DataSource = objectpermissions;
            }
            else
            {
                MessageBox.Show("Không có quyền cho đối tượng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private List<PermissionIn> GetObjectPermissions(string objectName)
        {
            List<PermissionIn> permissions = new List<PermissionIn>();
            string query = "SELECT  TABLE_NAME, PRIVILEGE, 'NONE' AS COLUMN_NAME, GRANTABLE, GRANTOR   FROM DBA_TAB_PRIVS WHERE TABLE_NAME = :objectName";

            using (OracleConnection connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(new OracleParameter(":objectName", objectName));
                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        permissions.Add(new PermissionIn
                        {
                            // Name = reader["GRANTEE"].ToString(),
                            ObjectName = reader["TABLE_NAME"].ToString(),
                            Authority = reader["PRIVILEGE"].ToString(),
                            Columns = reader["COLUMN_NAME"].ToString(),
                            GrantOption = reader["GRANTABLE"].ToString(),
                            Operation = reader["GRANTOR"]?.ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy quyền đối tượng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return permissions;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}

