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
        private Employee _originalEmp;
        private Employee _empToEdit;
        //private Employee EmpToEdit;
        private EmployeeViewModel _viewModel;
        private bool _isPhoneOnlyMode = false;

        public UpdateEmpForm(Employee emp)
        {

            InitializeComponent();           
            _originalEmp = new Employee(
                manld: emp.manld,
                name: emp.name,
                gender: emp.gender,
                dob: emp.dob,
                salary: emp.salary,
                allowance: emp.allowance,
                phone: emp.phone,
                madv: emp.madv,
                role: emp.role
            );
            _originalEmp.Username = emp.Username;
            _originalEmp.CreatedTime = emp.CreatedTime;

            _empToEdit = emp;
            _viewModel = new EmployeeViewModel();

            _isPhoneOnlyMode = _viewModel.IsPhoneOnlyUpdateMode(emp.manld);
            //ConfigureFormBasedOnPermissions();
            LoadEmployeeData();
        }

        //private void ConfigureFormBasedOnPermissions()
        //{
        //    if (_isPhoneOnlyMode)
        //    {
                
        //        txtHoTen.Enabled = false;
        //        txtLuong.Enabled = false;
        //        txtPhuCap.Enabled = false;
        //        dateTimePickerNgaySinh.Enabled = false;
        //        comboGioiTinh.Enabled = false;
        //        comboMaDV.Enabled = false;
        //        comboVaiTro.Enabled = false;

               
        //        Label restrictionLabel = new Label
        //        {
        //            Text = "Bạn chỉ có quyền cập nhật số điện thoại.",
        //            ForeColor = Color.Red,
        //            AutoSize = true,
        //            Location = new Point(txtSDT.Left, txtSDT.Bottom + 5)
        //        };
        //        this.Controls.Add(restrictionLabel);

                
        //        this.Text = "Cập Nhật Số Điện Thoại";
        //    }
        //}

        private void LoadEmployeeData()
        {
            txtMaNLD.Text = _empToEdit.manld;
            txtHoTen.Text = _empToEdit.name;
            txtSDT.Text = _empToEdit.phone;
            txtLuong.Text = _empToEdit.salary.ToString();
            txtPhuCap.Text = _empToEdit.allowance.ToString();
            dateTimePickerNgaySinh.Value = _empToEdit.dob;
            comboGioiTinh.SelectedItem = _empToEdit.gender;
            comboMaDV.SelectedItem = _empToEdit.madv;
            comboVaiTro.SelectedItem = _empToEdit.role;

            txtMaNLD.Enabled = false;
        }


        //private void LoadEmployeeData()
        //{
        //    txtMaNLD.Text = EmpToEdit.manld;
        //    txtHoTen.Text = EmpToEdit.name;
        //    txtSDT.Text = EmpToEdit.phone;
        //    txtLuong.Text = EmpToEdit.salary.ToString();
        //    txtPhuCap.Text = EmpToEdit.allowance.ToString();
        //    dateTimePickerNgaySinh.Value = EmpToEdit.dob;
        //    comboGioiTinh.SelectedItem = EmpToEdit.gender;
        //    comboMaDV.SelectedItem = EmpToEdit.madv;
        //    comboVaiTro.SelectedItem = EmpToEdit.role;

        //    txtMaNLD.Enabled = false;
        //}


        //private void updateBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string hoTen = txtHoTen.Text.Trim();
        //        string sdt = txtSDT.Text.Trim();
        //        string luongText = txtLuong.Text.Trim();
        //        string phuCapText = txtPhuCap.Text.Trim();
        //        DateTime ngaySinh = dateTimePickerNgaySinh.Value.Date;
        //        string gioiTinh = comboGioiTinh.SelectedItem?.ToString();
        //        string maDV = comboMaDV.SelectedItem?.ToString();
        //        string vaiTro = comboVaiTro.SelectedItem?.ToString();

        //        // Validate employee name
        //        if (string.IsNullOrWhiteSpace(hoTen))
        //        {
        //            MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtHoTen.Focus();
        //            return;
        //        }

        //        // Validate phone number
        //        if (string.IsNullOrWhiteSpace(sdt))
        //        {
        //            MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtSDT.Focus();
        //            return;
        //        }

        //        // Validate phone number format
        //        if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{9,11}$"))
        //        {
        //            MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtSDT.Focus();
        //            return;
        //        }

        //        // Validate salary
        //        if (!decimal.TryParse(luongText, out decimal luong) || luong < 0)
        //        {
        //            MessageBox.Show("Lương không hợp lệ. Vui lòng nhập lương hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtLuong.Focus();
        //            return;
        //        }

        //        // Validate allowance
        //        if (!decimal.TryParse(phuCapText, out decimal phuCap) || phuCap < 0)
        //        {
        //            MessageBox.Show("Phụ cấp không hợp lệ. Vui lòng nhập phụ cấp hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtPhuCap.Focus();
        //            return;
        //        }

        //        // Validate date of birth
        //        if (ngaySinh >= DateTime.Now)
        //        {
        //            MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            dateTimePickerNgaySinh.Focus();
        //            return;
        //        }

        //        // Validate gender selection
        //        if (string.IsNullOrWhiteSpace(gioiTinh))
        //        {
        //            MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            comboGioiTinh.Focus();
        //            return;
        //        }

        //        // Validate department selection
        //        if (string.IsNullOrWhiteSpace(maDV))
        //        {
        //            MessageBox.Show("Vui lòng chọn mã đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            comboMaDV.Focus();
        //            return;
        //        }

        //        // Validate role selection
        //        if (string.IsNullOrWhiteSpace(vaiTro))
        //        {
        //            MessageBox.Show("Vui lòng chọn vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            comboVaiTro.Focus();
        //            return;
        //        }

        //        EmpToEdit.name = txtHoTen.Text.Trim();
        //        EmpToEdit.phone = txtSDT.Text.Trim();
        //        EmpToEdit.salary = decimal.Parse(txtLuong.Text);
        //        EmpToEdit.allowance = decimal.Parse(txtPhuCap.Text);
        //        EmpToEdit.dob = dateTimePickerNgaySinh.Value;
        //        EmpToEdit.gender = comboGioiTinh.SelectedItem?.ToString();
        //        EmpToEdit.madv = comboMaDV.SelectedItem?.ToString();
        //        EmpToEdit.role = comboVaiTro.SelectedItem?.ToString();



        //        EmployeeViewModel vm = new EmployeeViewModel();
        //        vm.UpdateEmployee(EmpToEdit);

        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                string newPhone = txtSDT.Text.Trim();
                if (!ValidatePhoneOnly(newPhone))
                    return;

                
                if (_isPhoneOnlyMode)
                {
                    
                    bool otherFieldsChanged =
                        txtHoTen.Text.Trim() != _originalEmp.name ||
                        decimal.Parse(txtLuong.Text) != _originalEmp.salary ||
                        decimal.Parse(txtPhuCap.Text) != _originalEmp.allowance ||
                        dateTimePickerNgaySinh.Value.Date != _originalEmp.dob.Date ||
                        comboGioiTinh.SelectedItem?.ToString() != _originalEmp.gender ||
                        comboMaDV.SelectedItem?.ToString() != _originalEmp.madv ||
                        comboVaiTro.SelectedItem?.ToString() != _originalEmp.role;

                    if (otherFieldsChanged)
                    {
                       
                        MessageBox.Show(
                            "Bạn chỉ có quyền cập nhật số điện thoại. Các thay đổi khác sẽ không được lưu.",
                            "Thông báo quyền hạn",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Reset other fields to original values
                        txtHoTen.Text = _originalEmp.name;
                        txtLuong.Text = _originalEmp.salary.ToString();
                        txtPhuCap.Text = _originalEmp.allowance.ToString();
                        dateTimePickerNgaySinh.Value = _originalEmp.dob;
                        comboGioiTinh.SelectedItem = _originalEmp.gender;
                        comboMaDV.SelectedItem = _originalEmp.madv;
                        comboVaiTro.SelectedItem = _originalEmp.role;
                    }

                    // Update only the phone number
                    if (newPhone != _originalEmp.phone)
                    {
                       
                        Employee updatedEmp = new Employee(
                            manld: _originalEmp.manld,
                            name: _originalEmp.name,
                            gender: _originalEmp.gender,
                            dob: _originalEmp.dob,
                            salary: _originalEmp.salary,
                            allowance: _originalEmp.allowance,
                            phone: newPhone,
                            madv: _originalEmp.madv,
                            role: _originalEmp.role
                        );
                        updatedEmp.Username = _originalEmp.Username;
                        updatedEmp.CreatedTime = _originalEmp.CreatedTime;

                        
                        _viewModel.UpdateEmployee(updatedEmp);

                      
                        DialogResult result = MessageBox.Show(
                            "Số điện thoại đã được cập nhật thành công. Bạn có muốn đóng form này không?",
                            "Cập nhật thành công",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }    
                            
                    }
                    else
                    {
                        MessageBox.Show(
                            "Không có thay đổi nào được thực hiện.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                else
                {
                   
                    if (!ValidateAllFields())
                        return;

                    
                    Employee updatedEmp = new Employee(
                        manld: _empToEdit.manld,
                        name: txtHoTen.Text.Trim(),
                        gender: comboGioiTinh.SelectedItem?.ToString(),
                        dob: dateTimePickerNgaySinh.Value.Date,
                        salary: decimal.Parse(txtLuong.Text),
                        allowance: decimal.Parse(txtPhuCap.Text),
                        phone: newPhone,
                        madv: comboMaDV.SelectedItem?.ToString(),
                        role: comboVaiTro.SelectedItem?.ToString()
                    );
                    updatedEmp.Username = _empToEdit.Username;
                    updatedEmp.CreatedTime = _empToEdit.CreatedTime;

                    
                    _viewModel.UpdateEmployee(updatedEmp);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidatePhoneOnly(string phone)
        {
            
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{9,11}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }

            return true;
        }

        
        private bool ValidateAllFields()
        {
            string hoTen = txtHoTen.Text.Trim();
            string luongText = txtLuong.Text.Trim();
            string phuCapText = txtPhuCap.Text.Trim();
            DateTime ngaySinh = dateTimePickerNgaySinh.Value.Date;
            string gioiTinh = comboGioiTinh.SelectedItem?.ToString();
            string maDV = comboMaDV.SelectedItem?.ToString();
            string vaiTro = comboVaiTro.SelectedItem?.ToString();

           
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

           
            if (!decimal.TryParse(luongText, out decimal luong) || luong < 0)
            {
                MessageBox.Show("Lương không hợp lệ. Vui lòng nhập lương hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLuong.Focus();
                return false;
            }

            
            if (!decimal.TryParse(phuCapText, out decimal phuCap) || phuCap < 0)
            {
                MessageBox.Show("Phụ cấp không hợp lệ. Vui lòng nhập phụ cấp hợp lệ (số dương).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhuCap.Focus();
                return false;
            }

           
            if (ngaySinh >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerNgaySinh.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(gioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboGioiTinh.Focus();
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(maDV))
            {
                MessageBox.Show("Vui lòng chọn mã đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaDV.Focus();
                return false;
            }

           
            if (string.IsNullOrWhiteSpace(vaiTro))
            {
                MessageBox.Show("Vui lòng chọn vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboVaiTro.Focus();
                return false;
            }

            return true;
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
