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
    public partial class UpdateEmpForm : Form
    {
        private Employee EmpToEdit;

        public UpdateEmpForm(Employee emp)
        {
            InitializeComponent();
            EmpToEdit = emp;
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            txtMaNLD.Text = EmpToEdit.manld;
            txtHoTen.Text = EmpToEdit.name;
            txtSDT.Text = EmpToEdit.phone;
            txtLuong.Text = EmpToEdit.salary.ToString();
            txtPhuCap.Text = EmpToEdit.allowance.ToString();
            dateTimePickerNgaySinh.Value = EmpToEdit.dob;
            comboGioiTinh.SelectedItem = EmpToEdit.gender;
            comboMaDV.SelectedItem = EmpToEdit.madv;
            comboVaiTro.SelectedItem = EmpToEdit.role;

            txtMaNLD.Enabled = false;
        }
     

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = txtHoTen.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string luongText = txtLuong.Text.Trim();
                string phuCapText = txtPhuCap.Text.Trim();
                DateTime ngaySinh = dateTimePickerNgaySinh.Value.Date;
                string gioiTinh = comboGioiTinh.SelectedItem?.ToString();
                string maDV = comboMaDV.SelectedItem?.ToString();
                string vaiTro = comboVaiTro.SelectedItem?.ToString();

                // Validate employee name
                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                // Validate phone number
                if (string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                // Validate phone number format
                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{9,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                    return;
                }

                // Validate salary
                if (!decimal.TryParse(luongText, out decimal luong) || luong < 0)
                {
                    MessageBox.Show("Lương không hợp lệ. Vui lòng nhập lương hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLuong.Focus();
                    return;
                }

                // Validate allowance
                if (!decimal.TryParse(phuCapText, out decimal phuCap) || phuCap < 0)
                {
                    MessageBox.Show("Phụ cấp không hợp lệ. Vui lòng nhập phụ cấp hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhuCap.Focus();
                    return;
                }

                // Validate date of birth
                if (ngaySinh >= DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerNgaySinh.Focus();
                    return;
                }

                // Validate gender selection
                if (string.IsNullOrWhiteSpace(gioiTinh))
                {
                    MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboGioiTinh.Focus();
                    return;
                }

                // Validate department selection
                if (string.IsNullOrWhiteSpace(maDV))
                {
                    MessageBox.Show("Vui lòng chọn mã đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaDV.Focus();
                    return;
                }

                // Validate role selection
                if (string.IsNullOrWhiteSpace(vaiTro))
                {
                    MessageBox.Show("Vui lòng chọn vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboVaiTro.Focus();
                    return;
                }

                EmpToEdit.name = txtHoTen.Text.Trim();
                EmpToEdit.phone = txtSDT.Text.Trim();
                EmpToEdit.salary = decimal.Parse(txtLuong.Text);
                EmpToEdit.allowance = decimal.Parse(txtPhuCap.Text);
                EmpToEdit.dob = dateTimePickerNgaySinh.Value;
                EmpToEdit.gender = comboGioiTinh.SelectedItem?.ToString();
                EmpToEdit.madv = comboMaDV.SelectedItem?.ToString();
                EmpToEdit.role = comboVaiTro.SelectedItem?.ToString();

                

                EmployeeViewModel vm = new EmployeeViewModel();
                vm.UpdateEmployee(EmpToEdit);

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
