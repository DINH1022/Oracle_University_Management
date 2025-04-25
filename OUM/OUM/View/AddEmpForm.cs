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


        private void AddEmpForm_Load(object sender, EventArgs e)
        {


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
                    MessageBox.Show("Vui lòng nhập mã nhân lực.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng nhập họ tên.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{9,11}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(gioiTinh))
                {
                    MessageBox.Show("Vui lòng chọn giới tính.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(maDV))
                {
                    MessageBox.Show("Vui lòng chọn mã đơn vị.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(vaiTro))
                {
                    MessageBox.Show("Vui lòng chọn vai trò.");
                    return;
                }

                if (ngaySinh >= DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.");
                    return;
                }

                if (!decimal.TryParse(luongText, out luong) || luong < 0)
                {
                    MessageBox.Show("Lương không hợp lệ. Vui lòng nhập lương hợp lệ (số dương).");
                    return;
                }

                if (!decimal.TryParse(phuCapText, out phuCap) || phuCap < 0)
                {
                    MessageBox.Show("Phụ cấp không hợp lệ. Vui lòng nhập phụ cấp hợp lệ (số dương).");
                    return;
                }

                Employee emp = new Employee(maNLD, hoTen, gioiTinh, ngaySinh, luong, phuCap, sdt, maDV, vaiTro);

                EmployeeViewModel vm = new EmployeeViewModel();
                vm.AddEmployee(emp);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
    }
}
