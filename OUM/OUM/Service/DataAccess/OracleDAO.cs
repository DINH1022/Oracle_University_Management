using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Session;
using OUM.View;
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

                    string query = "SELECT MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, MADV, VAITRO FROM NHANVIEN";

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
                                salary: reader["LUONG"] == DBNull.Value ? 0 : Convert.ToDouble(reader["LUONG"]),
                                allowance: reader["PHUCAP"] == DBNull.Value ? 0 : Convert.ToDouble(reader["PHUCAP"]),
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

        public List<UserInfo> GetAllUsers()
        {
            List<UserInfo> users = new List<UserInfo>();


            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Lấy dữ liệu từ bảng NHANVIEN (Nhân viên)
                    string query = "SELECT MANLD AS UserId, HOTEN AS UserName, 'Employee' AS UserType FROM NHANVIEN";
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserInfo user = new UserInfo(
                                userId: reader["UserId"].ToString(),
                                userName: reader["UserName"].ToString(),
                                userType: reader["UserType"].ToString()  // 'Employee'
                            );
                            users.Add(user);
                        }
                    }

                    // Lấy dữ liệu từ bảng SINHVIEN (Sinh viên)
                    query = "SELECT  MASV AS UserId, HOTEN AS UserName, 'Student' AS UserType FROM SINHVIEN";
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userId = "SV" + reader["UserId"].ToString();
                            UserInfo user = new UserInfo(
                                userId: userId,
                                userName: reader["UserName"].ToString(),
                                userType: reader["UserType"].ToString()  // 'Student'
                            );
                            users.Add(user);
                        }
                    }

                    connection.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy danh sách người dùng: " + ex.Message);
                }
            }

            return users;
        }

        public List<string> GetAllRoles()
        {
            List<string> roles = new List<string>();

            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = "SELECT granted_role FROM user_role_privs";  // Truy vấn lấy roles
                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader["granted_role"].ToString());  // Lấy role
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách roles: {ex.Message}");
            }

            return roles;
        }


        public List<string> GetAllTables()
        {
            List<string> tables = new List<string>();

            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT table_name FROM all_tables WHERE owner = 'PDB_ADMIN'";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tables.Add(reader["table_name"].ToString());
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tables: {ex.Message}");
            }

            return tables;
        }

        // Lấy tất cả các thủ tục trong cơ sở dữ liệu
        public List<string> GetAllProcedures()
        {
            List<string> procedures = new List<string>();

            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT object_name FROM all_objects WHERE object_type = 'PROCEDURE' AND owner = 'PDB_ADMIN'";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            procedures.Add(reader["object_name"].ToString());
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching procedures: {ex.Message}");
            }

            return procedures;
        }

        // Lấy tất cả các hàm trong cơ sở dữ liệu
        public List<string> GetAllFunctions()
        {
            List<string> functions = new List<string>();

            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT object_name FROM all_objects WHERE object_type = 'FUNCTION' AND owner = 'PDB_ADMIN'";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            functions.Add(reader["object_name"].ToString());
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching functions: {ex.Message}");
            }

            return functions;
        }

        

    }

}
