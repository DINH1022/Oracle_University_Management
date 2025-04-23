using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OUM.Service.DataAccess
{
    public class OracleDAO
    {
        public bool AuthenticateAdmin(string username, string password)
        {
            try
            {
                using (var connection = new OracleConnection($"User Id={username};Password={password};Data Source=localhost:1521/DKHP;"))
                {
                    connection.Open();
                    connection.Close();
                    return true;

                } ;
            }
            catch
            {
                return false;
            }
        }
        public string GetConnectionString()
        {
            return $"User Id={AdminSession.Username};Password={AdminSession.Password};Data Source=localhost:1521/DKHP;";
        }
        //Template connect to db
        public bool CreateUser(string username,string password)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    string query = $"CREATE USER {username} IDENTIFIED BY {password}";
                    using(var cmd = new OracleCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }


        public List<Employee> GetListEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, MADV, VAITRO FROM NHANVIEN ORDER BY MANLD";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee(
                                manld: reader["MANLD"].ToString(),
                                name: reader["HOTEN"].ToString(),
                                gender: reader["PHAI"].ToString(),
                                dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                salary: reader["LUONG"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LUONG"]),
                                allowance: reader["PHUCAP"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PHUCAP"]),
                                phone: reader["DT"]?.ToString() ?? "",
                                madv: reader["MADV"]?.ToString() ?? "",
                                role: reader["VAITRO"].ToString()
                            );

                            employees.Add(emp);
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
                }
            }

            return employees;
        }

        public List<Student> GetListStudents()
        {
            List<Student> students = new List<Student>();

            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT MASV, HOTEN, PHAI, NGSINH, DT, KHOA, TINHTRANG FROM SINHVIEN";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student s = new Student(

                                id: reader["MASV"].ToString(),
                                name : reader["HOTEN"].ToString(),
                                gender: reader["PHAI"].ToString(),
                                dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                phone: reader["DT"]?.ToString() ?? "",
                                department: reader["KHOA"]?.ToString() ?? "",
                                status : reader["TINHTRANG"]?.ToString() ?? "",
                                address: ""
                            );

                            students.Add(s);
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy danh sách sinh viên: " + ex.Message);
                }
            }

            return students;
        }

        public void InsertEmployee(Employee emp)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    
                    cmd.CommandText = @"INSERT INTO NHANVIEN (MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, MADV, VAITRO) 
                                VALUES (:manld, :name, :gender, :dob, :salary, :allowance, :phone, :madv, :role)";
                    cmd.Parameters.Add(new OracleParameter("manld", emp.manld));
                    cmd.Parameters.Add(new OracleParameter("name", emp.name));
                    cmd.Parameters.Add(new OracleParameter("gender", emp.gender));
                    cmd.Parameters.Add(new OracleParameter("dob", emp.dob));
                    cmd.Parameters.Add(new OracleParameter("salary", emp.salary));
                    cmd.Parameters.Add(new OracleParameter("allowance", emp.allowance));
                    cmd.Parameters.Add(new OracleParameter("phone", emp.phone));
                    cmd.Parameters.Add(new OracleParameter("madv", emp.madv));
                    cmd.Parameters.Add(new OracleParameter("role", emp.role));

                   
                    cmd.ExecuteNonQuery();

                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }
        }





    }
}
