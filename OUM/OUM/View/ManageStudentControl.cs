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
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog();
        }

        private void Data_Load(object sender, EventArgs e)
        {
            
            ViewModel.LoadData();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ViewModel.Students;

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
    }


}
