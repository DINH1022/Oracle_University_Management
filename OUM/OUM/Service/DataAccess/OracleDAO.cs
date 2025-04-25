using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
                return true;
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
            string connect = GetConnectionString();
            using (var connection = new OracleConnection(connect))
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


        public List<UserSystemInformation> GetSystemUsers(string keyword)
        {
            List<UserSystemInformation> users = new List<UserSystemInformation>();
            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = @"SELECT username, account_status,created FROM dba_users
                                    WHERE oracle_maintained ='N'" + (!string.IsNullOrEmpty(keyword) ? " AND UPPER(username) LIKE UPPER(:keyword)" : ""); ;
                    var command = new OracleCommand(query, connection);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        command.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    var reader =command.ExecuteReader();
                    while (reader.Read())
                    {
                        UserSystemInformation user = new UserSystemInformation
                        (
                            username: reader["USERNAME"].ToString(),
                            status: reader["ACCOUNT_STATUS"].ToString(),
                            created: Convert.ToDateTime(reader["CREATED"])
                        );
                        users.Add(user);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error when get system user: " + ex.Message);
            }
            return users;
        }
        public List<RoleSystemInformation> GetSystemRoles(string keyword)
        {
            List<RoleSystemInformation> roles = new List<RoleSystemInformation>();
            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = @"SELECT ROLE, COMMON,INHERITED, AUTHENTICATION_TYPE FROM dba_roles
                                    WHERE oracle_maintained ='N'" + (!string.IsNullOrEmpty(keyword)? " AND UPPER(ROLE) LIKE UPPER(:keyword)" : "");
                   
                    var command = new OracleCommand(query, connection);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        command.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RoleSystemInformation role = new RoleSystemInformation
                        (
                            RoleName: reader["ROLE"].ToString(),
                            Common: reader["COMMON"].ToString(),
                            Inherited: reader["INHERITED"].ToString(),
                            AuthenticationType: reader["AUTHENTICATION_TYPE"].ToString()
                        );
                        roles.Add(role);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get system role: " + ex.Message);
            }
            return roles;
        }
        public List<DatabaseObject> GetDatabaseObject(string objectType)
        {
            List<DatabaseObject> DBobjects = new List<DatabaseObject>();
            string query ;
            if(string.IsNullOrEmpty(objectType)||objectType == "ALL")
            {
                query = @"SELECT OBJECT_NAME, OBJECT_TYPE,STATUS,CREATED FROM ALL_OBJECTS
                          WHERE OWNER =:owner and OBJECT_TYPE in ('TABLE','VIEW','FUNCTION','PROCEDURE')";
            }
            else
            {
                query = @"SELECT OBJECT_NAME, OBJECT_TYPE,STATUS,CREATED FROM ALL_OBJECTS
                          WHERE OWNER =:owner and OBJECT_TYPE = :objectType";
            }
            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    var command = new OracleCommand(query, connection);
                    command.Parameters.Add(new OracleParameter("owner", AdminSession.Username.ToUpper()));
                    if(!string.IsNullOrEmpty(objectType)&&objectType!="ALL")
                    {
                        command.Parameters.Add(new OracleParameter("objectType", objectType));

                    }
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DatabaseObject dbobject = new DatabaseObject
                        (
                            name: reader["OBJECT_NAME"].ToString(),
                            type: reader["OBJECT_TYPE"].ToString(),
                            created: Convert.ToDateTime(reader["CREATED"]),
                            status: reader["STATUS"].ToString()
                        );
                        DBobjects.Add(dbobject);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get system user: " + ex.Message);
            }
            return DBobjects;
        }
        public List<string> GetColumsForObject(string objectName,string objectType)
        {
            List<string> columns = new List<string>();
            string query;
            if (objectType=="TABLE"||objectType=="VIEW")
            {
                query = @"SELECT COLUMN_NAME FROM ALL_TAB_COLUMNS
                          WHERE OWNER =:owner and TABLE_NAME= :objecName";
                try
                {
                    using (var connection = new OracleConnection(GetConnectionString()))
                    {
                        connection.Open();
                        var command = new OracleCommand(query, connection);
                        command.Parameters.Add(new OracleParameter("owner", AdminSession.Username.ToUpper()));
                        command.Parameters.Add(new OracleParameter("objecName", objectName.ToUpper()));
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            columns.Add(reader.GetString(0));
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error when get system user: " + ex.Message);
                }
            }
            return columns;
        }
        public bool GrantPrivilege(string username, string objectName, string privilege, List<string> columns =null, bool withGrantOption = false)
        {
            try
            {
                using (var connection =new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    string sql;
                    string grantOptionClause = withGrantOption ? "WITH GRANT OPTION" : "";
                    if ( privilege=="UPDATE" && columns!=null && columns.Count > 0)
                    {
                        if (columns.Contains("ALL"))
                        {
                            sql = $"GRANT {privilege} ON {objectName} TO {username} {grantOptionClause}";
                        }
                        else
                        {
                            sql = $"GRANT {privilege}({string.Join(", ",columns)}) ON {objectName} TO {username} {grantOptionClause}";
                        }
                    }
                    else
                    { 
                        sql = $"GRANT {privilege} ON {objectName} TO {username} {grantOptionClause}";
                    }
                    using (var command = new OracleCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when grant privilege: " + ex.Message);
                return false;
            }
        }
        public bool GrantRoleToUser(string role, string username, bool withAdminOption = false)
        {
            try
            {
                using (var connection = new OracleConnection(GetConnectionString()))
                {
                    connection.Open();
                    string sql;
                    string grantOptionClause = withAdminOption ? "WITH ADMIN OPTION" : "";
                    sql = $"GRANT {role} TO {username} {grantOptionClause}";
                    using (var command = new OracleCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when grant role: " + ex.Message);
                return false;
            }
        }
    }
}
