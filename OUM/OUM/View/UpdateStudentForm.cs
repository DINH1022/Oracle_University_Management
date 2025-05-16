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
        private Student _originalStudent;
        private Student _studentToEdit;
        private StudentViewModel _viewModel;
        private bool _isOnlyEditContact = false;
        private bool _isOnlyEditStatus = false;

        public UpdateStudentForm(Student st)
        {
            InitializeComponent();

            _originalStudent = new Student(
                id: st.id,
                name: st.name,
                gender: st.gender,
                dob: st.dob,
                phone: st.phone,
                department: st.department,
                status: st.status,
                address: st.address
            );
            _originalStudent.Username = st.Username;
            _originalStudent.CreatedTime = st.CreatedTime;

            _studentToEdit = st;
            _viewModel = new StudentViewModel();

            _isOnlyEditContact = _viewModel.isOnlyEditContact(st.id);
            _isOnlyEditStatus = _viewModel.isOnlyEditStatus();

            LoadStudentData();
        }



        private void LoadStudentData()
        {
            txtMSSV.Text = _studentToEdit.id;
            txtHoTen.Text = _studentToEdit.name;
            txtSDT.Text = _studentToEdit.phone;
            comboGioiTinh.SelectedItem = _studentToEdit.gender;
            comboKhoa.SelectedItem = _studentToEdit.department;
            comboTinhTrang.SelectedItem = _studentToEdit.status;
            dateTimePickerNgaySinh.Value = _studentToEdit.dob;
            txtDiaChi.Text = _studentToEdit.address;

            txtMSSV.Enabled = false;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isOnlyEditContact)
                {
                    string newPhone = txtSDT.Text.Trim();
                    string newAddress = txtDiaChi.Text.Trim();

                    if (!ValidateContactInfo(newPhone, newAddress))
                        return;

                    bool otherFieldsChanged =
                        txtHoTen.Text.Trim() != _originalStudent.name ||
                        dateTimePickerNgaySinh.Value.Date != _originalStudent.dob.Date ||
                        comboGioiTinh.SelectedItem?.ToString() != _originalStudent.gender ||
                        comboKhoa.SelectedItem?.ToString() != _originalStudent.department ||
                        comboTinhTrang.SelectedItem?.ToString() != _originalStudent.status;

                    if (otherFieldsChanged)
                    {
                        MessageBox.Show(
                            "Bạn chỉ có quyền cập nhật thông tin liên lạc. Các thay đổi khác sẽ không được lưu.",
                            "Thông báo quyền hạn",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Reset other fields to original values
                        txtHoTen.Text = _originalStudent.name;
                        dateTimePickerNgaySinh.Value = _originalStudent.dob;
                        comboGioiTinh.SelectedItem = _originalStudent.gender;
                        comboKhoa.SelectedItem = _originalStudent.department;
                        comboTinhTrang.SelectedItem = _originalStudent.status;
                    }

                    if (newPhone != _originalStudent.phone || newAddress != _originalStudent.address)
                    {
                        Student updatedStudent = new Student(
                            id: _originalStudent.id,
                            name: _originalStudent.name,
                            gender: _originalStudent.gender,
                            dob: _originalStudent.dob,
                            phone: newPhone,
                            department: _originalStudent.department,
                            status: _originalStudent.status,
                            address: newAddress
                        );
                        updatedStudent.Username = _originalStudent.Username;
                        updatedStudent.CreatedTime = _originalStudent.CreatedTime;

                        bool success = _viewModel.UpdateStudent(updatedStudent);

                        if (success)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();                 
                        }
                        else
                        {
                            this.DialogResult = DialogResult.Cancel;
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
                        this.DialogResult = DialogResult.Cancel;

                    }
                }
                else if (_isOnlyEditStatus)
                {
                    string newStatus = comboTinhTrang.SelectedItem?.ToString();

                    if (string.IsNullOrWhiteSpace(newStatus))
                    {
                        MessageBox.Show("Vui lòng chọn tình trạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comboTinhTrang.Focus();
                        return;
                    }

                    bool otherFieldsChanged =
                        txtHoTen.Text.Trim() != _originalStudent.name ||
                        txtSDT.Text.Trim() != _originalStudent.phone ||
                        txtDiaChi.Text.Trim() != _originalStudent.address ||
                        dateTimePickerNgaySinh.Value.Date != _originalStudent.dob.Date ||
                        comboGioiTinh.SelectedItem?.ToString() != _originalStudent.gender ||
                        comboKhoa.SelectedItem?.ToString() != _originalStudent.department;

                    if (otherFieldsChanged)
                    {
                        MessageBox.Show(
                            "Bạn chỉ có quyền cập nhật tình trạng sinh viên. Các thay đổi khác sẽ không được lưu.",
                            "Thông báo quyền hạn",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        txtHoTen.Text = _originalStudent.name;
                        txtSDT.Text = _originalStudent.phone;
                        txtDiaChi.Text = _originalStudent.address;
                        dateTimePickerNgaySinh.Value = _originalStudent.dob;
                        comboGioiTinh.SelectedItem = _originalStudent.gender;
                        comboKhoa.SelectedItem = _originalStudent.department;
                    }

                    if (newStatus != _originalStudent.status)
                    {
                        Student updatedStudent = new Student(
                            id: _originalStudent.id,
                            name: _originalStudent.name,
                            gender: _originalStudent.gender,
                            dob: _originalStudent.dob,
                            phone: _originalStudent.phone,
                            department: _originalStudent.department,
                            status: newStatus,
                            address: _originalStudent.address
                        );
                        updatedStudent.Username = _originalStudent.Username;
                        updatedStudent.CreatedTime = _originalStudent.CreatedTime;

                        bool success = _viewModel.UpdateStudent(updatedStudent);

                        if (success)
                        {
                            
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            
                        }
                        else
                        {
                            this.DialogResult = DialogResult.Cancel;
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
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    if (!ValidateAllFields())
                        return;

                    _studentToEdit.name = txtHoTen.Text.Trim();
                    _studentToEdit.phone = txtSDT.Text.Trim();
                    _studentToEdit.address = txtDiaChi.Text.Trim();
                    _studentToEdit.dob = dateTimePickerNgaySinh.Value;
                    _studentToEdit.gender = comboGioiTinh.SelectedItem?.ToString();
                    _studentToEdit.department = comboKhoa.SelectedItem?.ToString();
                    _studentToEdit.status = comboTinhTrang.SelectedItem?.ToString();

                    bool success = _viewModel.UpdateStudent(_studentToEdit);
                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private bool ValidateContactInfo(string phone, string address)
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

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateAllFields()
        {
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
                return false;
            }

            if (!ValidateContactInfo(phone, address))
                return false;

            if (string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboGioiTinh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(department))
            {
                MessageBox.Show("Vui lòng chọn khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboKhoa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Vui lòng chọn tình trạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboTinhTrang.Focus();
                return false;
            }

            if (dob >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerNgaySinh.Focus();
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
