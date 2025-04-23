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
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddEmpForm addEmpForm = new AddEmpForm();
            addEmpForm.ShowDialog();
        }

        private void Data_Load(object sender, EventArgs e)
        {
            ViewModel.LoadData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ViewModel.Employees;

            if (dataGridView1.Columns.Count > 0)
            {
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
    }
}
