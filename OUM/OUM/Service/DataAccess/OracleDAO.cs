using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    if (ex.Message.Contains("ORA-01921"))
                    {
                        MessageBox.Show("Role đã tồn tại. Vui lòng nhập role khác.");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm role: " + ex.Message);
                    }
                }
            }
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
                    string query = "SELECT MANLD AS UserId, HOTEN AS UserName, 'Employee' AS UserType FROM NHANVIEN ORDER BY MANLD";
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
                    query = "SELECT  MASV AS UserId, HOTEN AS UserName, 'Student' AS UserType FROM SINHVIEN ORDER BY MASV";
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
