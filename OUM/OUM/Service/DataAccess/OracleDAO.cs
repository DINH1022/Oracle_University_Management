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

                    string query = @"
                SELECT 
                    NV.MANLD,
                    NV.HOTEN,
                    NV.PHAI,
                    NV.NGSINH,
                    NV.LUONG,
                    NV.PHUCAP,
                    NV.DT,
                    NV.MADV,
                    NV.VAITRO,
                    U.USERNAME,
                    U.CREATED AS THOIGIANTAO
                FROM NHANVIEN NV
                LEFT JOIN DBA_USERS U ON NV.MANLD = U.USERNAME
                ORDER BY NV.MANLD";

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

                            emp.Username = reader["USERNAME"]?.ToString() ?? "";
                            emp.CreatedTime = reader["THOIGIANTAO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["THOIGIANTAO"]);

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

                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM ALL_USERS WHERE USERNAME = :username";
                    checkCmd.Parameters.Add(new OracleParameter("username", emp.manld.ToUpper()));

                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists == 0)
                    {
                        var createUserCmd = connection.CreateCommand();
                        createUserCmd.CommandText = $@"
                            BEGIN
                                EXECUTE IMMEDIATE 'CREATE USER {emp.manld} IDENTIFIED BY PASS123';
                                EXECUTE IMMEDIATE 'GRANT CONNECT TO {emp.manld}';
                                
                            END;";
                        createUserCmd.ExecuteNonQuery();
                    }

                    var insertCmd = connection.CreateCommand();
                    insertCmd.CommandText = @"INSERT INTO NHANVIEN (MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, MADV, VAITRO) 
                                      VALUES (:manld, :name, :gender, :dob, :salary, :allowance, :phone, :madv, :role)";
                    insertCmd.Parameters.Add(new OracleParameter("manld", emp.manld));
                    insertCmd.Parameters.Add(new OracleParameter("name", emp.name));
                    insertCmd.Parameters.Add(new OracleParameter("gender", emp.gender));
                    insertCmd.Parameters.Add(new OracleParameter("dob", emp.dob));
                    insertCmd.Parameters.Add(new OracleParameter("salary", emp.salary));
                    insertCmd.Parameters.Add(new OracleParameter("allowance", emp.allowance));
                    insertCmd.Parameters.Add(new OracleParameter("phone", emp.phone));
                    insertCmd.Parameters.Add(new OracleParameter("madv", emp.madv));
                    insertCmd.Parameters.Add(new OracleParameter("role", emp.role));

                    insertCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên hoặc tạo user:\n" + ex.Message);
                }
            }
        }

        public void DropUser(string username)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var dropCmd = connection.CreateCommand();
                    dropCmd.CommandText = $"DROP USER {username} CASCADE";
                    dropCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi drop user:\n" + ex.Message);
                }
            }
        }

        public void DeleteEmployee(Employee emp)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var Cmd = connection.CreateCommand();
                    Cmd.CommandText = "DELETE FROM NHANVIEN WHERE MANLD = :manld";
                    Cmd.Parameters.Add(new OracleParameter("manld", emp.manld.ToUpper()));
                    Cmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên:\n" + ex.Message);
                }
            }
        }




    }
}
