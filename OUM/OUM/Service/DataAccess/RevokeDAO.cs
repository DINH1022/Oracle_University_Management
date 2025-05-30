using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OUM.Service.DataAccess
{
    public class RevokeDAO
    {
        private OracleDAO oracleDAO = new OracleDAO();
        const string NAME_COL = "GRANTEE";
        const string OBJECT_COL = "TABLE_NAME";
        const string PRIVILEGE_COL = "PRIVILEGE";
        const string GRANTOPT_COL = "GRANTABLE";

        //use for user-role privs
        const string USER_COL = "GRANTEE";
        const string GRANTED_ROLE_COL = "GRANTED_ROLE";
        const string ADMINOPT_COL = "ADMIN_OPTION";


        const string PREFIX_ROLE = "ROLE_";
        string PDBADMIN_USERNAME = "PDB_ADMIN";
        private OracleConnection getOracleConnection()
        {
            string connectString = oracleDAO.GetConnectionString();
            OracleConnection conn = new OracleConnection(connectString);
            conn.Open();
            return conn;
        }

        private Boolean closeOracleConnection(OracleConnection oracleConnection)
        {
            try
            {
                oracleConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //private string buildColumnsStringOfGivenTable(OracleConnection conn, string tablename)
        //{
        //    string res="";
        //    string query = $@"SELECT * FROM  
        //                    DBA_TAB_COLUMNS 
        //                    WHERE TABLE_NAME='{tablename}'";
        //    OracleCommand cmd = new OracleCommand(query, conn);
        //    OracleDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        res += (reader["COLUMN_NAME"]+", ");
        //    }
        //    return res.Substring(0,res.Length-2);
        //}
        private GrantInformation createNewGrantInfor(OracleDataReader reader, OracleConnection conn)
        {

            const string EXECUTE_INCIDATOR = "EXECUTE";
            string name = reader[NAME_COL].ToString();
            string object_name = reader[OBJECT_COL].ToString();
            string priv = reader[PRIVILEGE_COL].ToString();
            string cols = (priv.ToUpper() == EXECUTE_INCIDATOR) ? "THỰC THI" : "TẤT CẢ CÁC CỘT";
            string grantOpt = reader[GRANTOPT_COL].ToString();
            GrantInformation grantInformation = new GrantInformation(name, object_name, priv, cols, grantOpt);
            return grantInformation;
        }
        private GrantInformation createNewGrantInfor_column(OracleDataReader reader)
        {
            string name = reader[NAME_COL].ToString();
            string object_name = reader[OBJECT_COL].ToString();
            string priv = reader[PRIVILEGE_COL].ToString();
            string cols = reader["COLUMN_NAME"].ToString();
            string grantOpt = reader[GRANTOPT_COL].ToString();
            GrantInformation grantInformation = new GrantInformation(name, object_name, priv, cols, grantOpt);
            return grantInformation;
        }
        public List<GrantInformation> getUserPrivileges()
        {
            List<GrantInformation> grantInformations = new List<GrantInformation>();
            try
            {
                using (OracleConnection conn = getOracleConnection())
                {
                    //permision on whole table,view
                    string queryString1 = $@"SELECT * FROM DBA_TAB_PRIVS
                             WHERE OWNER='{PDBADMIN_USERNAME}' AND GRANTEE NOT LIKE '{PREFIX_ROLE}%'";
                    using (OracleCommand cmd1 = new OracleCommand(queryString1, conn))
                    using (OracleDataReader reader1 = cmd1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            GrantInformation newGrantInfor = createNewGrantInfor(reader1, conn);
                            grantInformations.Add(newGrantInfor);
                        }
                    }

                    //permission on col
                    string queryString2 = $@"SELECT * FROM DBA_COL_PRIVS CPRIVS
                             WHERE OWNER='{PDBADMIN_USERNAME}' AND GRANTEE NOT LIKE '{PREFIX_ROLE}%'
                             AND NOT EXISTS
                                 (SELECT 1 FROM USER_TAB_PRIVS TPRIVS
                                  WHERE CPRIVS.GRANTEE=TPRIVS.GRANTEE
                                  AND CPRIVS.TABLE_NAME=TPRIVS.TABLE_NAME
                                  AND CPRIVS.""PRIVILEGE""=TPRIVS.""PRIVILEGE"")";
                    using (OracleCommand cmd2 = new OracleCommand(queryString2, conn))
                    using (OracleDataReader reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            GrantInformation newGrantInfor = createNewGrantInfor_column(reader2);
                            grantInformations.Add(newGrantInfor);
                        }
                    }
                }
                return grantInformations;
            }
            catch (Exception ex)
            {
                return new List<GrantInformation>();
            }
        }

        public List<GrantInformation> getRolePrivileges()
        {
            List<GrantInformation> grantInformations = new List<GrantInformation>();
            try
            {
                using (OracleConnection conn = getOracleConnection())
                {
                    // Permission on whole table/view for roles matching the prefix
                    string queryString1 = $@"SELECT * FROM DBA_TAB_PRIVS
                             WHERE OWNER='{PDBADMIN_USERNAME}' AND GRANTEE LIKE '{PREFIX_ROLE}%'";
                    using (OracleCommand cmd1 = new OracleCommand(queryString1, conn))
                    using (OracleDataReader reader1 = cmd1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            GrantInformation newGrantInfor = createNewGrantInfor(reader1, conn);
                            grantInformations.Add(newGrantInfor);
                        }
                    }
                    string queryString2 = $@"SELECT * FROM DBA_COL_PRIVS CPRIVS
                             WHERE OWNER='{PDBADMIN_USERNAME}' AND GRANTEE LIKE '{PREFIX_ROLE}%'
                             AND NOT EXISTS
                                 (SELECT 1 FROM USER_TAB_PRIVS TPRIVS
                                  WHERE CPRIVS.GRANTEE=TPRIVS.GRANTEE
                                  AND CPRIVS.TABLE_NAME=TPRIVS.TABLE_NAME
                                  AND CPRIVS.""PRIVILEGE""=TPRIVS.""PRIVILEGE"")";
                    using (OracleCommand cmd2 = new OracleCommand(queryString2, conn))
                    using (OracleDataReader reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            GrantInformation newGrantInfor = createNewGrantInfor_column(reader2);
                            grantInformations.Add(newGrantInfor);
                        }
                    }
                }
                return grantInformations;
            }
            catch (Exception ex)
            {
                return new List<GrantInformation>();
            }
        }

        private UserRoleInformation createNewUserRoleInfor(OracleDataReader reader, OracleConnection conn)
        {
            string name = reader[USER_COL].ToString();
            string role = reader[GRANTED_ROLE_COL].ToString();
            string adminopt = reader[ADMINOPT_COL].ToString();
            UserRoleInformation userRoleInformation = new UserRoleInformation(name, role, adminopt);
            return userRoleInformation;
        }
        public List<UserRoleInformation> getUserRolePrivs()
        {
            List<UserRoleInformation> grantInformations = new List<UserRoleInformation>();
            try
            {
                using (OracleConnection conn = getOracleConnection())
                {
                    string queryString = $@"SELECT *
                             FROM dba_role_privs
                             WHERE GRANTED_ROLE LIKE '{PREFIX_ROLE}%'
                             AND GRANTEE NOT IN ('{PDBADMIN_USERNAME}')
                             ORDER BY grantee";
                    using (OracleCommand cmd = new OracleCommand(queryString, conn))
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserRoleInformation userRoleInfor = createNewUserRoleInfor(reader, conn);
                            grantInformations.Add(userRoleInfor);
                        }
                    }
                }
                return grantInformations;
            }
            catch (Exception ex)
            {
                return new List<UserRoleInformation>();
            }
        }

        public bool revokeAllColumnsPriv(string username, string object_name, string query_type)
        {
            try
            {
                using (OracleConnection conn = getOracleConnection())
                {
                    string query = $@"REVOKE {query_type.ToUpper()} ON {PDBADMIN_USERNAME.ToUpper()}.{object_name.ToUpper()} FROM {username}";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool revokeRoleFromUser(string username, string role)
        {
            try
            {
                using (OracleConnection conn = getOracleConnection())
                {
                    string query = $@"REVOKE {role} FROM {username}";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private List<string> getAllColsOfGivenPriOfGivenUser(OracleConnection conn, string username, string object_name, string query_type)
        {
            List<string> cols = new List<string>();
            string queryString = $@"SELECT COLUMN_NAME FROM USER_COL_PRIVS 
                            WHERE GRANTEE='{username}'
                            AND TABLE_NAME='{object_name}'
                            AND ""PRIVILEGE""='{query_type}'
                            ";
            OracleCommand cmd = new OracleCommand(queryString, conn);
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string col = reader[0].ToString();
                cols.Add(col);
            }
            return cols;
        }
        private string buildLeftCols(List<string> cols)
        {
            if (cols == null || cols.Count == 0)
            {
                return "";
            }
            return string.Join(",", cols);
        }
        public bool revokeGivenColumnPriv(string username, string object_name, string query_type, string column_name)
        {
            try
            {
                using (OracleConnection conn = getOracleConnection())
                {
                    List<string> cols = getAllColsOfGivenPriOfGivenUser(conn, username, object_name, query_type);
                    cols = cols
                        .Where(str => !string.Equals(str, column_name, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    string leftCols = buildLeftCols(cols);
                    string revokeQuery = $@"REVOKE {query_type.ToUpper()} ON {PDBADMIN_USERNAME.ToUpper()}.{object_name.ToUpper()} FROM {username}";
                    using (OracleCommand revokeCmd = new OracleCommand(revokeQuery, conn))
                    {
                        revokeCmd.ExecuteNonQuery();
                    }

                    if (!string.IsNullOrEmpty(leftCols))
                    {
                        string grantQuery = $@"GRANT {query_type.ToUpper()}({leftCols}) ON {PDBADMIN_USERNAME.ToUpper()}.{object_name.ToUpper()} TO {username}";
                        using (OracleCommand grantCmd = new OracleCommand(grantQuery, conn))
                        {
                            grantCmd.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool revokeExecutePriv(string username, string object_name)
        {
            try
            {
                using (OracleConnection conn = getOracleConnection())
                {
                    string query = $@"REVOKE EXECUTE ON {PDBADMIN_USERNAME.ToUpper()}.{object_name.ToUpper()} FROM {username}";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
