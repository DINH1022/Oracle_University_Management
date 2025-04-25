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
                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text.Trim(), @"^\d{9,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ.");
                    return;
                }

                if (dateTimePickerNgaySinh.Value >= DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.");
                    return;
                }

                if (comboGioiTinh.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn giới tính.");
                    return;
                }

                if (comboKhoa.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn khoa.");
                    return;
                }

                if (comboTinhTrang.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn tình trạng.");
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
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
