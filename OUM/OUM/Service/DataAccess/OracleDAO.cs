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
                        ORDER BY S.MASV";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student s = new Student(
                                id: reader["MASV"].ToString(),
                                name: reader["HOTEN"].ToString(),
                                gender: reader["PHAI"].ToString(),
                                dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                phone: reader["DT"]?.ToString() ?? "",
                                department: reader["KHOA"]?.ToString() ?? "",
                                status: reader["TINHTRANG"]?.ToString() ?? "",
                                address: reader["DCHI"]?.ToString() ?? ""
                            );

                            s.Username = reader["USERNAME"]?.ToString() ?? "";
                            s.CreatedTime = reader["THOIGIANTAO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["THOIGIANTAO"]);

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


        public void InsertStudent(Student st)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    string username = "SV" + st.id.ToUpper();
                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM ALL_USERS WHERE USERNAME = :username";
                    checkCmd.Parameters.Add(new OracleParameter("username", username));

                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists == 0)
                    {
                        var createUserCmd = connection.CreateCommand();
                        createUserCmd.CommandText = $@"
                            BEGIN
                                EXECUTE IMMEDIATE 'CREATE USER {username} IDENTIFIED BY PASS123';
                                EXECUTE IMMEDIATE 'GRANT CONNECT TO {username}';
                                
                            END;";
                        createUserCmd.ExecuteNonQuery();
                    }

                    var insertCmd = connection.CreateCommand();
                    insertCmd.CommandText = @"INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DT, KHOA, TINHTRANG, DCHI) 
                                      VALUES (:id, :name, :gender, :dob, :phone, :department, :status, :address)";
                    insertCmd.Parameters.Add(new OracleParameter("id", st.id));
                    insertCmd.Parameters.Add(new OracleParameter("name", st.name));
                    insertCmd.Parameters.Add(new OracleParameter("gender", st.gender));
                    insertCmd.Parameters.Add(new OracleParameter("dob", st.dob));
                    insertCmd.Parameters.Add(new OracleParameter("phone", st.phone));
                    insertCmd.Parameters.Add(new OracleParameter("department", st.department));          
                    insertCmd.Parameters.Add(new OracleParameter("status", st.status));
                    insertCmd.Parameters.Add(new OracleParameter("address", st.address));   // phải đúng thứ tự !!!

                 

                    insertCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sinh viên hoặc tạo user:\n" + ex.Message);
                }
            }
        }

        public void UpdateStudent(Student st)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var updateCmd = connection.CreateCommand();
                    updateCmd.CommandText = @"
                        UPDATE SINHVIEN 
                        SET HOTEN = :name, 
                            PHAI = :gender, 
                            NGSINH = :dob, 
                            DT = :phone, 
                            KHOA = :department,
                            TINHTRANG = :status,
                            DCHI = :address
                        WHERE MASV = :id";

                    updateCmd.Parameters.Add(new OracleParameter("name", st.name));
                    updateCmd.Parameters.Add(new OracleParameter("gender", st.gender));
                    updateCmd.Parameters.Add(new OracleParameter("dob", st.dob));
                    updateCmd.Parameters.Add(new OracleParameter("phone", st.phone));
                    updateCmd.Parameters.Add(new OracleParameter("department", st.department));
                    updateCmd.Parameters.Add(new OracleParameter("status", st.status));
                    updateCmd.Parameters.Add(new OracleParameter("address", st.address));
                    updateCmd.Parameters.Add(new OracleParameter("id", st.id)); 

                    int rows = updateCmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên để cập nhật.");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật sinh viên:\n" + ex.Message);
                }
            }
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

        public void UpdateEmployee(Employee emp)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var updateCmd = connection.CreateCommand();
                    updateCmd.CommandText = @"
                        UPDATE NHANVIEN 
                        SET HOTEN = :name, 
                            PHAI = :gender, 
                            NGSINH = :dob, 
                            LUONG = :salary, 
                            PHUCAP = :allowance, 
                            DT = :phone, 
                            MADV = :madv, 
                            VAITRO = :role
                        WHERE MANLD = :manld";

                    updateCmd.Parameters.Add(new OracleParameter("name", emp.name));
                    updateCmd.Parameters.Add(new OracleParameter("gender", emp.gender));
                    updateCmd.Parameters.Add(new OracleParameter("dob", emp.dob));
                    updateCmd.Parameters.Add(new OracleParameter("salary", emp.salary));
                    updateCmd.Parameters.Add(new OracleParameter("allowance", emp.allowance));
                    updateCmd.Parameters.Add(new OracleParameter("phone", emp.phone));
                    updateCmd.Parameters.Add(new OracleParameter("madv", emp.madv));
                    updateCmd.Parameters.Add(new OracleParameter("role", emp.role));
                    updateCmd.Parameters.Add(new OracleParameter("manld", emp.manld)); 

                    int rows = updateCmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật.");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên:\n" + ex.Message);
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

        public void DeleteStudent(Student st)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var Cmd = connection.CreateCommand();
                    Cmd.CommandText = "DELETE FROM SINHVIEN WHERE MASV = :masv";
                    Cmd.Parameters.Add(new OracleParameter("masv", st.id.ToUpper()));
                    Cmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sinh viên:\n" + ex.Message);
                }
            }
        }

        public List<UserPerRole> GetListRole()
        {
            List<UserPerRole> uprs = new List<UserPerRole>();

            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT granted_role as ROLENAME,count(*) as USERCOUNT FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE LIKE 'ROLE_%' group by granted_role";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserPerRole upr = new UserPerRole(
                                roleName: reader["ROLENAME"].ToString(),
                                userCount: reader["USERCOUNT"] == DBNull.Value ? 0 : Convert.ToInt32(reader["USERCOUNT"]) - 1   // -1 của pdb_admin
                            );
                            uprs.Add(upr);
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy danh sách role: " + ex.Message);
                }
            }

            return uprs;
        }

        public void DropRole(string roleName)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var dropCmd = connection.CreateCommand();
                    dropCmd.CommandText = $"DROP ROLE {roleName}";  //xóa role tự động thu hồi role phía user, không cần thu hồi thủ công
                    dropCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi drop role:\n" + ex.Message);
                }
            }
        }

        public void AddRole(string roleName)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var dropCmd = connection.CreateCommand();
                    dropCmd.CommandText = $"CREATE ROLE ROLE_{roleName}";  
                    dropCmd.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm role:\n" + ex.Message);
                }
            }
        }

    }
}
