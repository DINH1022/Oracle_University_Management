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
using OUM.ViewModel;

namespace OUM.View
{
    public partial class ManageStudentControl : UserControl
    {
        private StudentViewModel ViewModel;
        public ManageStudentControl()
        {
            InitializeComponent();
            ViewModel = new StudentViewModel();
            this.Load += Data_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void CustomizeHeaders()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id"].HeaderText = "Mã SV";
                dataGridView1.Columns["name"].HeaderText = "Họ tên";
                dataGridView1.Columns["gender"].HeaderText = "Giới tính";
                dataGridView1.Columns["dob"].HeaderText = "Ngày sinh";
                dataGridView1.Columns["phone"].HeaderText = "Điện thoại";
                dataGridView1.Columns["department"].HeaderText = "Khoa";
                dataGridView1.Columns["status"].HeaderText = "Tình trạng";
                dataGridView1.Columns["address"].HeaderText = "Địa chỉ";
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                ViewModel.LoadData();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ViewModel.Students;
                AddButtonColumn();
                CustomizeHeaders();
            }
        }

        private void Data_Load(object sender, EventArgs e)
        {

            ViewModel.LoadData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ViewModel.Students;
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
                var st = dataGridView1.Rows[e.RowIndex].DataBoundItem as Student;
                if (st == null) return;

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {st.name} không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            ViewModel.DeleteStudent(st);
                            ViewModel.LoadData();
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = ViewModel.Students;
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
                    var editForm = new UpdateStudentForm(st);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        ViewModel.LoadData();
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = ViewModel.Students;
                        AddButtonColumn();
                    }
                }
            }
        }

        private void FilterData(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dataGridView1.DataSource = ViewModel.Students;
            }
            else
            {
                string lowerKeyword = keyword.ToLower();
                var filtered = ViewModel.Students
                    .Where(st =>
                        st.name.ToLower().Contains(lowerKeyword) ||
                        st.id.ToLower().Contains(lowerKeyword) ||
                        st.phone.ToLower().Contains(lowerKeyword) ||
                        st.department.ToLower().Contains(lowerKeyword) ||
                        st.address.ToLower().Contains(lowerKeyword) ||
                        st.Username.ToLower().Contains(lowerKeyword)
                    )
                    .ToList();

                dataGridView1.DataSource = filtered;
            }

            AddButtonColumn();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            string keyword = searchTextBox.Text;
            FilterData(keyword);
        }
    }


}
