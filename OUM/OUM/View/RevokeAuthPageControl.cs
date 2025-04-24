using OUM.Model;
using OUM.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OUM.View
{
    public partial class RevokeAuthPageControl : UserControl
    {
        private RevokeDAO revokeDAO=new RevokeDAO();


        private const string TEXT_USER_AUTH_PAGE = "Quyền của người dùng";
        private const string TEXT_ROLE_AUTH_PAGE = "Quyền của vai trò";
        private const string TEXT_ROLE_OF_USER_PAGE = "Vai trò của người dùng";
        private const string FULL_COLS_INDICATOR = "TẤT CẢ CÁC CỘT";

        private const string HEADERTEXT_USER_PRIVS_NAME = "Người dùng";
        private const string HEADERTEXT_USER_PRIVS_OBJECT = "Đối tượng";
        private const string HEADERTEXT_USER_PRIVS_PRIV = "Quyền";
        private const string HEADERTEXT_USER_PRIVS_COLS = "Cột";
        private const string HEADERTEXT_USER_PRIVS_GRANTOPT = "WITH GRANT OPTION";

        private const string HEADERTEXT_ROLE_PRIVS_NAME = "Vai trò";
        private const string HEADERTEXT_ROLE_PRIVS_OBJECT = "Đối tượng";
        private const string HEADERTEXT_ROLE_PRIVS_PRIV = "Quyền";
        private const string HEADERTEXT_ROLE_PRIVS_COLS = "Cột";
        private const string HEADERTEXT_ROLE_PRIVS_GRANTOPT = "WITH GRANT OPTION";

        private const string HEADERTEXT_USER_ROLE_NAME = "Đối tượng";
        private const string HEADERTEXT_USER_ROLE_ROLE = "Vai trò";
        private const string HEADERTEXT_USER_ROLE_GRANTOPT = "WITH GRANT OPTION";

        private Dictionary<String, String> HEADER_TEXT_TO_NAME_USER_PRIVS = new Dictionary<String, String>()
        {
            {HEADERTEXT_USER_PRIVS_NAME,"name"},
            {HEADERTEXT_USER_PRIVS_OBJECT,"object_name"},
            {HEADERTEXT_USER_PRIVS_PRIV,"privilege"},
            {HEADERTEXT_USER_PRIVS_COLS,"columns" },
            {HEADERTEXT_USER_PRIVS_GRANTOPT,"grantopt"}
        };
        private Dictionary<String, String> HEADER_TEXT_TO_DATAPROP_USER_PRIVS = new Dictionary<String, String>()
        {
            {HEADERTEXT_USER_PRIVS_NAME,"Name"},
            {HEADERTEXT_USER_PRIVS_OBJECT,"ObjectName"},
            {HEADERTEXT_USER_PRIVS_PRIV,"Authority"},
            {HEADERTEXT_USER_PRIVS_COLS,"Columns" },
            {HEADERTEXT_USER_PRIVS_GRANTOPT,"GrantOption"}
        };
        private Dictionary<String, String> HEADER_TEXT_TO_NAME_ROLE_PRIVS = new Dictionary<String, String>()
        {
            {HEADERTEXT_ROLE_PRIVS_NAME,"name"},
            {HEADERTEXT_ROLE_PRIVS_OBJECT,"object_name"},
            {HEADERTEXT_ROLE_PRIVS_PRIV,"privilege"},
            {HEADERTEXT_ROLE_PRIVS_COLS,"columns" },
            {HEADERTEXT_ROLE_PRIVS_GRANTOPT,"grantopt"}
        };
        private Dictionary<String, String> HEADER_TEXT_TO_DATAPROP_ROLE_PRIVS = new Dictionary<String, String>()
        {
            {HEADERTEXT_ROLE_PRIVS_NAME,"Name"},
            {HEADERTEXT_ROLE_PRIVS_OBJECT,"ObjectName"},
            {HEADERTEXT_ROLE_PRIVS_PRIV,"Authority"},
            {HEADERTEXT_ROLE_PRIVS_COLS,"Columns" },
            {HEADERTEXT_ROLE_PRIVS_GRANTOPT,"GrantOption"}
        };
        private Dictionary<String, String> HEADER_TEXT_TO_NAME_USER_ROLE = new Dictionary<String, String>()
        {
            {HEADERTEXT_USER_ROLE_NAME, "name"},
            {HEADERTEXT_USER_ROLE_ROLE,"role"},
            {HEADERTEXT_USER_ROLE_GRANTOPT ,"grantopt"}
        };

        private Dictionary<String, String> HEADER_TEXT_TO_DATAPROP_USER_ROLE = new Dictionary<String, String>()
        {
            {HEADERTEXT_USER_ROLE_NAME, "Name"},
            {HEADERTEXT_USER_ROLE_ROLE,"Role"},
            {HEADERTEXT_USER_ROLE_GRANTOPT ,"GrantOption"}
        };

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

            UserCol.HeaderText = HEADERTEXT_USER_PRIVS_NAME;
            ObjCol.HeaderText = HEADERTEXT_USER_PRIVS_OBJECT;
            AuthorCol.HeaderText = HEADERTEXT_USER_PRIVS_PRIV;
            ColsCol.HeaderText = HEADERTEXT_USER_PRIVS_COLS;
            GrantOptCol.HeaderText = HEADERTEXT_USER_PRIVS_GRANTOPT;

            UserCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_PRIVS[UserCol.HeaderText];
            ObjCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_PRIVS[ObjCol.HeaderText];
            AuthorCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_PRIVS[AuthorCol.HeaderText];
            ColsCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_PRIVS[ColsCol.HeaderText];
            GrantOptCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_PRIVS[GrantOptCol.HeaderText];

            UserCol.Name = HEADER_TEXT_TO_NAME_USER_PRIVS[UserCol.HeaderText];
            ObjCol.Name= HEADER_TEXT_TO_NAME_USER_PRIVS[ObjCol.HeaderText];
            AuthorCol.Name= HEADER_TEXT_TO_NAME_USER_PRIVS[AuthorCol.HeaderText];
            ColsCol.Name= HEADER_TEXT_TO_NAME_USER_PRIVS[ColsCol.HeaderText];
            GrantOptCol.Name= HEADER_TEXT_TO_NAME_USER_PRIVS[GrantOptCol.HeaderText];

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

            UserCol.HeaderText = HEADERTEXT_ROLE_PRIVS_NAME;
            ObjCol.HeaderText = HEADERTEXT_ROLE_PRIVS_OBJECT;
            AuthorCol.HeaderText = HEADERTEXT_ROLE_PRIVS_PRIV;
            ColsCol.HeaderText = HEADERTEXT_ROLE_PRIVS_COLS;
            GrantOptCol.HeaderText = HEADERTEXT_ROLE_PRIVS_GRANTOPT;

            UserCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_ROLE_PRIVS[UserCol.HeaderText];
            ObjCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_ROLE_PRIVS[ObjCol.HeaderText];
            AuthorCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_ROLE_PRIVS[AuthorCol.HeaderText];
            ColsCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_ROLE_PRIVS[ColsCol.HeaderText];
            GrantOptCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_ROLE_PRIVS[GrantOptCol.HeaderText];

            UserCol.Name = HEADER_TEXT_TO_NAME_ROLE_PRIVS[UserCol.HeaderText];
            ObjCol.Name = HEADER_TEXT_TO_NAME_ROLE_PRIVS[ObjCol.HeaderText];
            AuthorCol.Name= HEADER_TEXT_TO_NAME_ROLE_PRIVS[AuthorCol.HeaderText];
            ColsCol.Name= HEADER_TEXT_TO_NAME_ROLE_PRIVS[ColsCol.HeaderText];
            GrantOptCol.Name= HEADER_TEXT_TO_NAME_ROLE_PRIVS[GrantOptCol.HeaderText];

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
            UserCol.HeaderText = HEADERTEXT_USER_ROLE_NAME;
            RoleCol.HeaderText = HEADERTEXT_USER_ROLE_ROLE;
            GrantOptCol.HeaderText = HEADERTEXT_USER_ROLE_GRANTOPT;
            DataGridViewButtonColumn deleteButtonColumn = createDeleteBtnColumn();

            UserCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_ROLE[UserCol.HeaderText];
            RoleCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_ROLE[RoleCol.HeaderText];
            GrantOptCol.DataPropertyName = HEADER_TEXT_TO_DATAPROP_USER_ROLE[GrantOptCol.HeaderText];

            UserCol.Name = HEADER_TEXT_TO_NAME_USER_ROLE[UserCol.HeaderText];
            RoleCol.Name= HEADER_TEXT_TO_NAME_USER_ROLE[RoleCol.HeaderText];
            GrantOptCol.Name= HEADER_TEXT_TO_NAME_USER_ROLE[GrantOptCol.HeaderText];

            dataGridView1.Columns.Add(UserCol);
            dataGridView1.Columns.Add(RoleCol);
            dataGridView1.Columns.Add(GrantOptCol);
            dataGridView1.Columns.Add(deleteButtonColumn);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            configUICells();
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
            configUIHeaders();
            configUICells();
            grantInformations=revokeDAO.getUserPrivileges();
            dataGridView1.DataSource = grantInformations;
            dataGridView1.AutoResizeRows();
        }

        private Boolean isRevokingRoleFromUser()
        {
            if (label2.Text == TEXT_ROLE_OF_USER_PAGE)
            {
                return true;
            }
            return false;
        }

        private Boolean isRevokingAllColumns(DataGridViewCellEventArgs e)
        {
            //there is no need to split case for role_privs and user_privs, because they store in same table and same way,
            //we can also do like this:
            //string cols=dataGridView1.Rows[e.RowIndex].Cells[HEADER_TEXT_TO_NAME_ROLE_PRIVS[HEADERTEXT_ROLE_PRIVS_COLS]].ToString();
            string cols =dataGridView1
                .Rows[e.RowIndex]
                .Cells[HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_COLS]]
                .Value.ToString();
            if (cols == FULL_COLS_INDICATOR)
            {
                return true;
            }
            return false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index)
            {
                //there is no need to split case for role_privs and user_privs, because they store in same table and same way
                //therefore, we can use the name interchangeably
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this grant?",
                    "Confirm Delete ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                {
                    if (isRevokingRoleFromUser()) {
                        string nameOfCol_username = HEADER_TEXT_TO_NAME_USER_ROLE[HEADERTEXT_USER_ROLE_NAME];
                        string nameOfCol_role = HEADER_TEXT_TO_NAME_USER_ROLE[HEADERTEXT_USER_ROLE_ROLE];

                        string username = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_username].Value.ToString();
                        string role = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_role].Value.ToString();
                        var objectToRemove = userRoleInformations
                            .FirstOrDefault(obj => obj.Name.ToUpper() == username
                                                && obj.Role.ToUpper() == role);
                        dataGridView1.DataSource = null;
                        if (objectToRemove != null)
                        {
                            userRoleInformations.Remove(objectToRemove);
                        }
                        dataGridView1.DataSource= userRoleInformations;
                        revokeDAO.revokeRoleFromUser(username, role);
                        return;
                    }
                    if (isRevokingAllColumns(e))
                    {
                        string nameOfCol_username = HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_NAME];
                        string nameOfCol_objectName = HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_OBJECT];
                        string nameOfCol_queryType = HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_PRIV];

                        string username = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_username].Value.ToString();
                        string object_name = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_objectName].Value.ToString();
                        string query_type = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_queryType].Value.ToString();
                        GrantInformation objectToRemove = grantInformations
                            .FirstOrDefault(obj => obj.Name.ToUpper() == username.ToUpper()
                                             && obj.ObjectName.ToUpper() == object_name.ToUpper()
                                             && obj.Authority.ToUpper() == query_type.ToUpper());
                        dataGridView1.DataSource = null;
                        if (objectToRemove != null) {
                            grantInformations.Remove(objectToRemove);    
                        }
                        dataGridView1.DataSource = userRoleInformations;
                        revokeDAO.revokeAllColumnsPriv(username, object_name, query_type);
                        return;
                    }
                    string nameOfCol_name = HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_NAME];
                    string nameOfCol_objectname = HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_OBJECT];
                    string nameOfCol_querytype = HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_PRIV];
                    string nameOfCol_col = HEADER_TEXT_TO_NAME_USER_PRIVS[HEADERTEXT_USER_PRIVS_COLS];

                    string name = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_name].Value.ToString();
                    string objectName = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_objectname].Value.ToString();
                    string queryType = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_querytype].Value.ToString();
                    string col = dataGridView1.Rows[e.RowIndex].Cells[nameOfCol_col].Value.ToString();
                    GrantInformation objectToRemove1 = grantInformations
                        .FirstOrDefault(obj => obj.Name.ToUpper() == name &&
                                   obj.ObjectName.ToUpper() == objectName &&
                                   obj.Authority.ToUpper() == queryType &&
                                   obj.Columns.ToUpper() == col);
                    dataGridView1.DataSource = null;
                    if (objectToRemove1 != null)
                    {
                        grantInformations.Remove(objectToRemove1);
                    }
                    dataGridView1.DataSource = userRoleInformations;
                    revokeDAO.revokeGivenColumnPriv(name, objectName, queryType, col);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh_datagrid_user();
            grantInformations = revokeDAO.getUserPrivileges();
            dataGridView1.DataSource = grantInformations;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh_datagrid_role();
            grantInformations=revokeDAO.getRolePrivileges();
            dataGridView1.DataSource = grantInformations;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh_datagrid_role_of_user();
            userRoleInformations=revokeDAO.getUserRolePrivs();
            dataGridView1.DataSource=userRoleInformations;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
