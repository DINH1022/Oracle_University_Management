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
            catch (Exception ex) {
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
            string cols = (priv.ToUpper()==EXECUTE_INCIDATOR)?"THỰC THI": "TẤT CẢ CÁC CỘT";
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
            OracleConnection conn = getOracleConnection();
            try
            {
                string queryString = $@"SELECT * FROM USER_TAB_PRIVS 
                                        WHERE GRANTEE NOT LIKE '{PREFIX_ROLE}%'";
                OracleCommand cmd = new OracleCommand(queryString, conn);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GrantInformation> grantInformations = new List<GrantInformation>();
                //permision on whole table,view
                while (reader.Read())
                {
                    GrantInformation newGrantInfor = createNewGrantInfor(reader, conn);
                    grantInformations.Add(newGrantInfor);
                }

                //permission on col
                queryString = $@"SELECT * FROM USER_COL_PRIVS CPRIVS  
                                WHERE GRANTEE NOT LIKE '{PREFIX_ROLE}%' 
                                AND NOT EXISTS 
                                    (SELECT 1 FROM USER_TAB_PRIVS TPRIVS 
                                    WHERE CPRIVS.GRANTEE=TPRIVS.GRANTEE 
                                    AND CPRIVS.TABLE_NAME=TPRIVS.TABLE_NAME 
                                    AND CPRIVS.""PRIVILEGE""=TPRIVS.""PRIVILEGE"")
                                ";
                cmd = new OracleCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GrantInformation newGrantInfor = createNewGrantInfor_column(reader);
                    grantInformations.Add(newGrantInfor);
                }
                return grantInformations;
            }
            catch (Exception ex)
            {
                return new List<GrantInformation>();
            }
            finally
            {
                closeOracleConnection(conn);
            }
        }

        public List<GrantInformation> getRolePrivileges()
        {
            OracleConnection conn = getOracleConnection();
            try
            {
                string queryString = $@"SELECT * FROM USER_TAB_PRIVS 
                                        WHERE GRANTEE LIKE '{PREFIX_ROLE}%'";
                OracleCommand cmd = new OracleCommand(queryString, conn);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GrantInformation> grantInformations = new List<GrantInformation>();
                //permision on whole table,view
                while (reader.Read())
                {
                    GrantInformation newGrantInfor = createNewGrantInfor(reader, conn);
                    grantInformations.Add(newGrantInfor);
                }

                //permission on col
                queryString = $@"SELECT * FROM USER_COL_PRIVS CPRIVS  
                                WHERE GRANTEE LIKE '{PREFIX_ROLE}%' 
                                AND NOT EXISTS 
                                    (SELECT 1 FROM USER_TAB_PRIVS TPRIVS 
                                    WHERE CPRIVS.GRANTEE=TPRIVS.GRANTEE 
                                    AND CPRIVS.TABLE_NAME=TPRIVS.TABLE_NAME 
                                    AND CPRIVS.""PRIVILEGE""=TPRIVS.""PRIVILEGE"")
                                ";
                cmd = new OracleCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GrantInformation newGrantInfor = createNewGrantInfor_column(reader);
                    grantInformations.Add(newGrantInfor);
                }
                return grantInformations;
            }
            catch (Exception ex)
            {
                return new List<GrantInformation>();
            }
            finally
            {
                closeOracleConnection(conn);
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
            OracleConnection conn = getOracleConnection();
            try
            {
                string queryString = $@"SELECT * 
                                        FROM dba_role_privs 
                                        WHERE GRANTED_ROLE LIKE '{PREFIX_ROLE}%' 
                                        AND GRANTEE NOT IN ('{PDBADMIN_USERNAME}')
                                        ORDER BY grantee";
                OracleCommand cmd = new OracleCommand(queryString, conn);
                OracleDataReader reader = cmd.ExecuteReader();
                List<UserRoleInformation> grantInformations = new List<UserRoleInformation>();
                while (reader.Read())
                {
                    UserRoleInformation userRoleInfor = createNewUserRoleInfor(reader, conn);
                    grantInformations.Add(userRoleInfor);
                }
                return grantInformations;
            }
            catch (Exception ex)
            {
                return new List<UserRoleInformation>();
            }
            finally
            {
                closeOracleConnection(conn);
            }
        }

        public bool revokeAllColumnsPriv(string username, string object_name, string query_type)
        {
            OracleConnection conn = getOracleConnection();
            try
            {
                string query = $@"REVOKE {query_type.ToUpper()} ON {PDBADMIN_USERNAME}.{object_name.ToUpper()} FROM {username}";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                closeOracleConnection(conn);
            }
        }

        public bool revokeRoleFromUser(string username, string role)
        {
            OracleConnection conn = getOracleConnection();
            try
            {
                string query = $@"REVOKE {role} FROM {username}";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                closeOracleConnection(conn);
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
        public bool revokeGivenColumnPriv(string username,string object_name,string query_type,string column_name)
        {
            OracleConnection conn = getOracleConnection();
            try
            {
                List<string> cols = getAllColsOfGivenPriOfGivenUser(conn, username, object_name, query_type);
                cols=cols
                    .Where(str=>str.ToLower()!=column_name.ToLower())
                    .ToList();
                string leftCols=buildLeftCols(cols);
                string query = $@"REVOKE {query_type} ON {PDBADMIN_USERNAME}.{object_name} FROM {username}";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                if (leftCols.Length == 0)
                {
                    return true;
                }
                query = $@"GRANT {query_type.ToUpper()}({leftCols}) ON {PDBADMIN_USERNAME}.{object_name} TO {username}";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                closeOracleConnection(conn);
            }
        }

        public bool revokeExecutePriv(string username,string object_name)
        {
            OracleConnection conn = getOracleConnection();
            try
            {
                string query = $@"REVOKE EXECUTE ON {PDBADMIN_USERNAME}.{object_name} FROM {username}";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                closeOracleConnection(conn);
            }
        }
    }
}
