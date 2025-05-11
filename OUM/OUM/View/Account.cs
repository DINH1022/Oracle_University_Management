using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Service.DataAccess;
using OUM.Session;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OUM.View
{

    public partial class Account : UserControl
    {
        private AdminViewModel viewModel;
        private OracleDAO dao;

        public string
            GetConnectionString()
        {
            return $"User Id={AdminSession.Username};Password={AdminSession.Password};Data Source=localhost:1521/DKHP;";
        }


        public Account()
        {
            InitializeComponent();
            viewModel = new AdminViewModel();
            dao = new OracleDAO();
            this.Load += Account_Load;

        }

        private void Account_Load(object sender, EventArgs e)
        {
            string userId = AdminSession.Username;

            if (userId.StartsWith("SV"))
            {
                var student = GetStudentById(userId);
                DisplayStudentInfo(student);
                lbSalary.Visible = false;
                lbPC.Visible = false;

            }
            else if (userId.StartsWith("NV"))
            {
                var employee = GetEmployeeById(userId);
                DisplayEmployeeInfo(employee);
                txtSalary.Visible = true;
                txtPC.Visible = true;
                txtDC.Visible = false;
                lbDC.Visible = false;
                txtDC.Visible = false;
                lbSalary.Visible = true;
                lbPC.Visible = true;
                txtStatus.Visible = false;
                lbStatus.Visible = false;
                lbSalary.Visible = true;
                lbPC.Visible = true;

                lbKhoa.Location = new Point(465, 202);
                txtKhoa.Location = new Point(588, 203);
            }
            else
            {
                MessageBox.Show("Không tìm thấy người dùng.");
            }

        }

        private void DisplayStudentInfo(Student student)
        {
            if (student != null)
            {
                textBoxUserType.Text = student.id + " - " + student.name;
                txtMa.Text = student.id;
                txtName.Text = student.name;
                txt_gen.Text = student.gender;
                txtPhone.Text = student.phone;
                txtKhoa.Text = student.department;
                txtStatus.Text = student.status;
                txtDC.Text = student.address;
                dateTimePickerdob.Text = student.dob.ToString("yyyy-MM-dd");
            }
        }


        private void DisplayEmployeeInfo(Employee employee)
        {
            if (employee != null)
            {
                textBoxUserType.Text = employee.manld + " - " + employee.name;
                txtMa.Text = employee.manld;
                txtName.Text = employee.name;
                txt_gen.Text = employee.gender;
                txtPhone.Text = employee.phone;
                txtKhoa.Text = employee.madv;
                txtSalary.Text = employee.salary.ToString();
                txtPC.Text = employee.allowance.ToString();
            }
        }





        public Student GetStudentById(string username)
        {
            Student student = null;

            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT MASV, HOTEN, PHAI, NGSINH, DT, KHOA, TINHTRANG, DCHI
                FROM PDB_ADMIN.SINHVIEN
                WHERE MASV = :masv";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":masv", username.Substring(2)));

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new Student(
                                    id: reader["MASV"].ToString(),
                                    name: reader["HOTEN"].ToString(),
                                    gender: reader["PHAI"].ToString(),
                                    dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                    phone: reader["DT"]?.ToString() ?? "",
                                    department: reader["KHOA"]?.ToString() ?? "",
                                    status: reader["TINHTRANG"]?.ToString() ?? "",
                                    address: reader["DCHI"]?.ToString() ?? ""
                                );
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin sinh viên: " + ex.Message);
                }
            }

            return student;
        }



        public Employee GetEmployeeById(string username)
        {
            Employee employee = null;

            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT 
                        N.MANLD,
                        N.HOTEN,
                        N.PHAI,
                        N.NGSINH,
                        N.DT,
                        N.MADV,
                        N.VAITRO,
                        N.LUONG,
                        N.PHUCAP
                    FROM PDB_ADMIN.NHANVIEN N
                    WHERE N.MANLD =:username";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":username", username));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee(
                                    manld: reader["MANLD"].ToString(),
                                    name: reader["HOTEN"].ToString(),
                                    gender: reader["PHAI"].ToString(),
                                    dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                    phone: reader["DT"]?.ToString() ?? "",
                                    madv: reader["MADV"]?.ToString() ?? "",
                                    role: reader["VAITRO"]?.ToString() ?? "",
                                    salary: reader["LUONG"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LUONG"]),
                                    allowance: reader["PHUCAP"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PHUCAP"])
                                );
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin nhân viên: " + ex.Message);
                }
            }

            return employee;
        }



        public bool UpdateStudentPhone(string username, string newPhone)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "UPDATE PDB_ADMIN.SINHVIEN SET DT = :newPhone WHERE MASV = :masv";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":newPhone", newPhone));
                    command.Parameters.Add(new OracleParameter(":masv", username.Substring(2)));

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật số điện thoại: " + ex.Message);
                        return false;
                    }
                }

            }
        }


        public bool UpdateEmployeePhone(string manld, string newPhone)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "UPDATE PDB_ADMIN.NHANVIEN SET DT = :newPhone WHERE MANLD = :manld";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":newPhone", newPhone));
                    command.Parameters.Add(new OracleParameter(":manld", manld));

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật số điện thoại: " + ex.Message);
                        return false;
                    }
                }

            }
        }


        public bool UpdateStudentAddress(string username, string newAddress)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "UPDATE PDB_ADMIN.SINHVIEN SET DCHI = :newAddress WHERE MASV = :masv";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":newAddress", newAddress));
                    command.Parameters.Add(new OracleParameter(":masv", username.Substring(2)));  // Lấy mã sinh viên từ username (VD: SVxxxx)

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;  // Trả về true nếu có ít nhất một dòng bị ảnh hưởng
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật địa chỉ: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            string newPhone = txtNewP.Text; 
            string newAddress = txtNewAd.Text;
            string username = AdminSession.Username;

            bool updateSuccessPhone = false;
            bool updateSuccessAddress = false;

            if (username.StartsWith("NV"))
            {
                bool updateSuccess = UpdateEmployeePhone(username, newPhone);
                if (updateSuccess)
                {
                    txtPhone.Text = newPhone;
                    lbNewPhone.Visible = false;
                    txtNewP.Visible = false;
                    MessageBox.Show("Cập nhật số điện thoại thành công!");
                }
            }
            else if (username.StartsWith("SV"))
            {
                if (!string.IsNullOrEmpty(newPhone))
                {
                    updateSuccessPhone = UpdateStudentPhone(username, newPhone);
                    if (updateSuccessPhone)
                    {
                        txtPhone.Text = newPhone;  
                        lbNewPhone.Visible = false; 
                        txtNewP.Visible = false;
                    }
                }

                if (!string.IsNullOrEmpty(newAddress))
                {
                    updateSuccessAddress = UpdateStudentAddress(username, newAddress);
                    if (updateSuccessAddress)
                    {
                        txtDC.Text = newAddress;  
                        lbNAddress.Visible = false;
                        txtNewAd.Visible = false;
                    }
                }
            }

            if (updateSuccessPhone || updateSuccessAddress)
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được cập nhật.");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = AdminSession.Username;

            if (username.StartsWith("NV"))
            {
                lbNewPhone.Visible = true;
                txtNewP.Visible = true;
            }
            else
            {
                lbNewPhone.Visible = true;
                txtNewP.Visible = true;
                lbNAddress.Visible = true;
                txtNewAd.Visible = true;
            }
            //txtNewP.Clear();

        }
    }
}
