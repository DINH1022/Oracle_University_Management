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
    public partial class ManageRoleControl : UserControl
    {
        private RoleViewModel ViewModel;
        public ManageRoleControl()
        {
            InitializeComponent();
            ViewModel = new RoleViewModel();
            this.Load += Data_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        
        private void addBtn_Click(object sender, EventArgs e)
        {
            AddRoleForm addRoleForm = new AddRoleForm();
            if (addRoleForm.ShowDialog() == DialogResult.OK)
            {
                ViewModel.LoadData();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ViewModel.UserPerRoles;
                AddButtonColumn();
                CustomizeHeaders();
            }
        }
        private void CustomizeHeaders()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["roleName"].HeaderText = "Tên Role";
                dataGridView1.Columns["userCount"].HeaderText = "Số lượng User";
            }
        }

        private void Data_Load(object sender, EventArgs e)
        {
            ViewModel.LoadData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ViewModel.UserPerRoles;
            AddButtonColumn();
            CustomizeHeaders();
        }


        private void AddButtonColumn()
        {
            if (dataGridView1.Columns.Contains("Delete"))
                dataGridView1.Columns.Remove("Delete");
           
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true
            };
            
            dataGridView1.Columns.Add(deleteButton);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var r = dataGridView1.Rows[e.RowIndex].DataBoundItem as UserPerRole;
                if (r == null) return;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa role {r.roleName} không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            ViewModel.DeleteRole(r);
                            ViewModel.LoadData();
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ViewModel.UserPerRoles;
                            AddButtonColumn();
                            CustomizeHeaders();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa:\n" + ex.Message);
                        }
                    }
                }
               
            }
        }
        
    }
}

