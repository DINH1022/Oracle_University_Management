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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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

                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Vui lòng nhập mã số sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMSSV.Focus();
                    return;
                }

               
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Vui lòng nhập họ tên sinh viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{9,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(gender))
                {
                    MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboGioiTinh.Focus();
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(department))
                {
                    MessageBox.Show("Vui lòng chọn khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboKhoa.Focus();
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("Vui lòng chọn tình trạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboTinhTrang.Focus();
                    return;
                }

                
                if (dob >= DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerNgaySinh.Focus();
                    return;
                }


               
                if (string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;
                }

                
                StudentViewModel vm = new StudentViewModel();
                if (vm.IsMaSVExists(id))
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại. Vui lòng nhập mã khác.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMSSV.Focus();
                    return;
                }

               
                Student st = new Student(id, name, gender, dob, phone, department, status, address);
                vm.AddStudent(st);

                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-00001"))
                {
                    MessageBox.Show("Sinh viên đã tồn tại. Vui lòng nhập mã số sinh viên khác.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMSSV.Focus();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    
}
}
