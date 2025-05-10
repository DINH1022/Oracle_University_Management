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
    public partial class AddEmpForm : Form
    {
        public AddEmpForm()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string maNLD = txtMaNLD.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string luongText = txtLuong.Text.Trim();
                string phuCapText = txtPhuCap.Text.Trim();
                DateTime ngaySinh = dateTimePickerNgaySinh.Value.Date;
                string gioiTinh = comboGioiTinh.SelectedItem?.ToString();
                string maDV = comboMaDV.SelectedItem?.ToString();
                string vaiTro = comboVaiTro.SelectedItem?.ToString();

                decimal luong, phuCap;
                if (string.IsNullOrWhiteSpace(maNLD))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân lực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNLD.Focus();
                    return;
                }

                if (!maNLD.StartsWith("NV", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã nhân lực phải bắt đầu bằng 'NV'.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNLD.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{9,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(gioiTinh))
                {
                    MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboGioiTinh.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(maDV))
                {
                    MessageBox.Show("Vui lòng chọn mã đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaDV.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(vaiTro))
                {
                    MessageBox.Show("Vui lòng chọn vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboVaiTro.Focus();
                    return;
                }

                if (ngaySinh >= DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerNgaySinh.Focus();
                    return;
                }

                if (!decimal.TryParse(luongText, out luong) || luong < 0)
                {
                    MessageBox.Show("Lương không hợp lệ. Vui lòng nhập lương hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLuong.Focus();
                    return;
                }

                if (!decimal.TryParse(phuCapText, out phuCap) || phuCap < 0)
                {
                    MessageBox.Show("Phụ cấp không hợp lệ. Vui lòng nhập phụ cấp hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhuCap.Focus();
                    return;
                }


                EmployeeViewModel vm = new EmployeeViewModel();
                if (vm.IsMaNLDExists(maNLD))
                {
                    MessageBox.Show("Mã nld đã tồn tại. Vui lòng nhập mã khác.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNLD.Focus();
                    return;
                }
                Employee emp = new Employee(maNLD, hoTen, gioiTinh, ngaySinh, luong, phuCap, sdt, maDV, vaiTro);

                vm.AddEmployee(emp);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-00001"))
                {
                    MessageBox.Show("Nhân viên đã tồn tại. Vui lòng nhập mã nhân lực khác.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNLD.Focus();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
