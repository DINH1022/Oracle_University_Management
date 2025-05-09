using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using OUM.Model;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Service.DataAccess
{
    public class RegistrationCourses
    {
        private OracleDAO dao = new OracleDAO();
        private const string PDBADMIN_USERNAME = "PDB_ADMIN";
        private const string DANGKY_TABLE_NAME = "DANGKY";
        private const string MOMON_VIEW_NAME = "SV_MOMON_VIEW";
        private const string HOCPHAN_TABLE_NAME = "HOCPHAN";

        public List<RegisteredCourse> getAllRegisteredCourses()
        {
            string connectString = dao.GetConnectionString();
            List<RegisteredCourse> courses = new List<RegisteredCourse>();
            try
            {
                using (var con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT DK.MAMM,HP.MAHP,HP.TENHP,HP.SOTC, DK.DIEMTH,DK.DIEMQT, DK.DIEMCK, DK.DIEMTK
                                      FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} DK JOIN 
                                           {PDBADMIN_USERNAME}.{MOMON_VIEW_NAME} MM ON (DK.MAMM = MM.MAMM) JOIN
                                           {PDBADMIN_USERNAME}.{HOCPHAN_TABLE_NAME} HP ON (MM.MAHP = HP.MAHP)";
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        RegisteredCourse course = new RegisteredCourse(
                            mamm: reader["MAMM"].ToString(),
                            mahp: reader["MAHP"].ToString(),
                            tenhp: reader["TENHP"].ToString(),
                            sotc:Convert.ToInt32(reader["SOTC"]),
                            diemth: reader["DIEMTH"]==DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMTH"]),
                            diemqt: reader["DIEMQT"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMQT"]),
                            diemck: reader["DIEMCK"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMCK"]),
                            diemtk: reader["DIEMTK"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMTK"])
                        );
                        courses.Add(course);
                    }
                    con.Close();
                }
                return courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get registered course",ex.Message);
                return courses;
            }
        }
        public List<NewRegistrationCourse> GetNewRegistrationCourses(string keyword)
        {
            List<NewRegistrationCourse> courses = new List<NewRegistrationCourse>();
            try
            {
                string connectionString = dao.GetConnectionString();
                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT MM.MAMM, MM.MAHP, HP.TENHP,HP.SOTC, HP.STLT, HP.STTH
                                      FROM {PDBADMIN_USERNAME}.{MOMON_VIEW_NAME} MM JOIN
                                           {PDBADMIN_USERNAME}.{HOCPHAN_TABLE_NAME} HP ON (MM.MAHP=HP.MAHP)
                                            WHERE MM.MAMM NOT IN (SELECT MAMM FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} WHERE MASV=:masv)"
                                            +(!string.IsNullOrEmpty(keyword) ? " AND UPPER(HP.TENHP) LIKE UPPER(:keyword)" :"");
                    OracleCommand command = new OracleCommand(query,connection);
                    //Cần bỏ bớt 2 kí tự SV trong tài khoản user SV 
                    string mssv = AdminSession.Username.Substring(2);
                    command.Parameters.Add(new OracleParameter("mssv",mssv));
                    if(!string.IsNullOrEmpty(keyword))
                    {
                        command.Parameters.Add(new OracleParameter("keyword","%"+keyword+"%"));
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        NewRegistrationCourse course = new NewRegistrationCourse(
                            mamm: reader["MAMM"].ToString(),
                            mahp: reader["MAHP"].ToString(),
                            tenhp: reader["TENHP"].ToString(),
                            sotc: Convert.ToInt32(reader["SOTC"]),
                            stth: Convert.ToInt32(reader["STTH"]),
                            stlt: Convert.ToInt32(reader["STLT"])
                        );
                        courses.Add(course);
                    }
                    connection.Close();
                    return courses;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return courses;
            }
        }
        public bool CancelRegistrationCourse(string masv,string mamm)
        {
            try
            {
                string connectionString = dao.GetConnectionString();
                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"DELETE FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} WHERE MASV =:masv AND MAMM =:mamm";
                    var command = new OracleCommand(query,connection);
                    command.Parameters.Add(new OracleParameter("masv", masv));
                    command.Parameters.Add(new OracleParameter("mamm", mamm));
                    int count= command.ExecuteNonQuery();
                    return count >0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool RegisterCourse(string mamm)
        {
            string connectionString = dao.GetConnectionString();
            try
            {
                using(var connection  = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} (MASV,MAMM) VALUES(:mssv,:mamm)";
                    OracleCommand command = new OracleCommand(query,connection);
                    //Cần bỏ bớt 2 kí tự SV trong tài khoản user SV để tránh lỗi khóa ngoại
                    string mssv = AdminSession.Username.Substring(2);
                    command.Parameters.Add(new OracleParameter("mssv",mssv));
                    command.Parameters.Add(new OracleParameter("mamm", mamm));
                    int count =command.ExecuteNonQuery();
                    return count > 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
