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
                if (string.IsNullOrEmpty(maNLD) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                    return;
                }

                if (!decimal.TryParse(luongText, out luong))
                {
                    MessageBox.Show("Lương không hợp lệ.");
                    return;
                }

                if (!decimal.TryParse(phuCapText, out phuCap))
                {
                    MessageBox.Show("Phụ cấp không hợp lệ.");
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
