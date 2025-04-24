using OUM.Model;
using OUM.Service.DataAccess;
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
    public partial class ManageEmployeeControl : UserControl
    {
        private EmployeeViewModel ViewModel;
        public ManageEmployeeControl()
        {
            InitializeComponent();
            ViewModel = new EmployeeViewModel();
            this.Load += Data_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddEmpForm addEmpForm = new AddEmpForm();
            if (addEmpForm.ShowDialog() == DialogResult.OK)
            {
                ViewModel.LoadData();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ViewModel.Employees;
                AddButtonColumn();
                CustomizeHeaders();
            }
        }
        private void CustomizeHeaders()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Username"].HeaderText = "Tên tài khoản";
                dataGridView1.Columns["CreatedTime"].HeaderText = "Ngày tạo";
                dataGridView1.Columns["manld"].HeaderText = "Mã nld";
                dataGridView1.Columns["name"].HeaderText = "Họ tên";
                dataGridView1.Columns["gender"].HeaderText = "Giới tính";
                dataGridView1.Columns["dob"].HeaderText = "Ngày sinh";
                dataGridView1.Columns["salary"].HeaderText = "Lương";
                dataGridView1.Columns["allowance"].HeaderText = "Phụ cấp";
                dataGridView1.Columns["phone"].HeaderText = "Điện thoại";
                dataGridView1.Columns["madv"].HeaderText = "Mã đơn vị";
                dataGridView1.Columns["role"].HeaderText = "Vai trò";
            }
        }

        private void Data_Load(object sender, EventArgs e)
        {
            ViewModel.LoadData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ViewModel.Employees;
            AddButtonColumn();
            CustomizeHeaders();
        }


        private void AddButtonColumn()
        {
            if (dataGridView1.Columns.Contains("Delete"))
                dataGridView1.Columns.Remove("Delete");
            if (dataGridView1.Columns.Contains("Update"))
                dataGridView1.Columns.Remove("Update");

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Xóa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn
            {
                Name = "Update",
                HeaderText = "Chỉnh sửa",
                Text = "Chỉnh sửa",
                UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Add(updateButton);
            dataGridView1.Columns.Add(deleteButton);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var emp = dataGridView1.Rows[e.RowIndex].DataBoundItem as Employee;
                if (emp == null) return;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {emp.name} không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            ViewModel.DeleteEmployee(emp);
                            ViewModel.LoadData();
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ViewModel.Employees;
                            AddButtonColumn();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa:\n" + ex.Message);
                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Update")
                {
                    var editForm = new UpdateEmpForm(emp);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        ViewModel.LoadData();
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = ViewModel.Employees;
                        AddButtonColumn();
                    }
                }
            }
        }


        private void FilterData(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dataGridView1.DataSource = ViewModel.Employees;
            }
            else
            {
                string lowerKeyword = keyword.ToLower();
                var filtered = ViewModel.Employees
                    .Where(emp =>
                        emp.name.ToLower().Contains(lowerKeyword) ||
                        emp.manld.ToLower().Contains(lowerKeyword) ||
                        emp.phone.ToLower().Contains(lowerKeyword) ||
                        emp.madv.ToLower().Contains(lowerKeyword) ||
                        emp.role.ToLower().Contains(lowerKeyword)
                    )
                    .ToList();

                dataGridView1.DataSource = filtered;
            }

            AddButtonColumn();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string keyword = searchTextBox.Text;
            FilterData(keyword);
        }
    }
}
