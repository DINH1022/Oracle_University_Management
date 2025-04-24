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
