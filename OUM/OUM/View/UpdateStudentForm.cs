using OUM.Model;
using OUM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace OUM.View
{
    public partial class UpdateStudentForm : Form
    {
        private Student StudentToEdit;

        public UpdateStudentForm(Student st)
        {
            InitializeComponent();
            StudentToEdit = st;
            LoadStudentData();
        }
        private void LoadStudentData()
        {
            
            txtMSSV.Text = StudentToEdit.id;
            txtHoTen.Text = StudentToEdit.name;
            txtSDT.Text = StudentToEdit.phone;
            comboGioiTinh.SelectedItem = StudentToEdit.gender;
            comboKhoa.SelectedItem = StudentToEdit.department;
            comboTinhTrang.SelectedItem = StudentToEdit.status;
            dateTimePickerNgaySinh.Value = StudentToEdit.dob;
            txtDiaChi.Text = StudentToEdit.address;

            txtMSSV.Enabled = false;
        }


        private void updateBtn_Click(object sender, EventArgs e)
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

                StudentToEdit.name = txtHoTen.Text.Trim();
                StudentToEdit.phone = txtSDT.Text.Trim();
                StudentToEdit.address = txtDiaChi.Text.Trim();
                StudentToEdit.dob = dateTimePickerNgaySinh.Value;
                StudentToEdit.gender = comboGioiTinh.SelectedItem?.ToString();
                StudentToEdit.department = comboKhoa.SelectedItem?.ToString();
                StudentToEdit.status = comboTinhTrang.SelectedItem?.ToString();

                StudentViewModel vm = new StudentViewModel();
                vm.UpdateStudent(StudentToEdit);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
