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
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtMSSV.Text.Trim();
                string name = txtHoTen.Text.Trim();
                string phone = txtSDT.Text.Trim();
                string gender = comboGioiTinh.SelectedItem?.ToString();
                string department = comboKhoa.SelectedItem?.ToString();
                string status = comboTinhTrang.SelectedItem?.ToString();
                DateTime dob = dateTimePickerNgaySinh.Value.Date;
                string address = txtDiaChi.Text.Trim();

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) ||
                    string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(department) ||
                    string.IsNullOrEmpty(status) || string.IsNullOrEmpty(address))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin sinh viên và chọn các mục từ ComboBox.");
                    return;
                }

                
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{9,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.");
                    return;
                }

                
                if (dob >= DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.");
                    return;
                }

                Student st = new Student(id, name, gender, dob, phone, department, status, address);

                StudentViewModel vm = new StudentViewModel();
                vm.AddStudent(st);

                MessageBox.Show("Thêm sinh viên thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }

    
}
}
