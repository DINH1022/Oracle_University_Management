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

namespace OUM.View
{

    public partial class Account : UserControl
    {
        private AdminViewModel viewModel;
        private OracleDAO dao;

        public string GetConnectionString()
        {
            return $"User Id={"PDB_ADMIN"};Password={AdminSession.Password};Data Source=localhost:1521/DKHP;";
        }


        public Account()
        {
            InitializeComponent();
            //viewModel = new AdminViewModel();
            //dao = new OracleDAO();
            this.Load += Account_Load;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            string userId = AdminSession.Username;

            if (userId.StartsWith("SV"))
            {
                // Nếu là sinh viên, lấy thông tin sinh viên
                var student = GetStudentById(userId);
                DisplayStudentInfo(student);
            }
            else if (userId.StartsWith("NV"))
            {
                // Nếu là nhân viên, lấy thông tin nhân viên
                var employee = GetEmployeeById(userId);
                DisplayEmployeeInfo(employee);
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
                textBox1.Text = student.id;
                textBox2.Text = student.name;
                // txtGender.Text = student.Gender;
                //txtPhone.Text = student.Phone;
                //txtDepartment.Text = student.Department;
                //txtStatus.Text = student.Status;
                //txtAddress.Text = student.Address;
            }
        }


        private void DisplayEmployeeInfo(Employee employee)
        {
            if (employee != null)
            {
                textBox1.Text = employee.manld;
                textBox2.Text = employee.name;
                //txtGender.Text = employee.Gender;
                //txtPhone.Text = employee.Phone;
                //txtDepartment.Text = employee.Department;
                //txtRole.Text = employee.Role;
                //txtSalary.Text = employee.Salary.ToString();
                //txtAllowance.Text = employee.Allowance.ToString();
            }
        }



        private void textBoxUserType_TextChanged(object sender, EventArgs e)
        {
            textBoxUserType.Text = textBox1.Text = "HIHI";
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
                SELECT 
                    S.MASV,
                    S.HOTEN,
                    S.PHAI,
                    S.NGSINH,
                    S.DT,
                    S.KHOA,
                    S.TINHTRANG,
                    S.DCHI,
                    U.USERNAME,
                    U.CREATED AS THOIGIANTAO
                FROM SINHVIEN S
                LEFT JOIN DBA_USERS U ON S.MASV = SUBSTR(U.USERNAME, 3)
                WHERE U.USERNAME = :username";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":username", username));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Kiểm tra nếu có dữ liệu trả về
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

                                student.Username = reader["USERNAME"]?.ToString() ?? "";
                                student.CreatedTime = reader["THOIGIANTAO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["THOIGIANTAO"]);
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

            return student; // Trả về sinh viên tìm được, nếu không có thì trả về null
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
                    N.PHUCAP,
                    U.USERNAME,
                    U.CREATED AS THOIGIANTAO
                FROM NHANVIEN N
                LEFT JOIN DBA_USERS U ON N.MANLD = SUBSTR(U.USERNAME, 3)
                WHERE U.USERNAME = :username";

                    using (var command = new OracleCommand(query, connection))
                    {
                       // command.Parameters.Add(new OracleParameter(":username", username));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Kiểm tra nếu có dữ liệu trả về
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

            return employee; // Trả về nhân viên tìm được, nếu không có thì trả về null
        }

       
    }
}
