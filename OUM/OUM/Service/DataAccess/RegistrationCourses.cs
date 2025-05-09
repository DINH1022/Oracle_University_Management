using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using OUM.Model;
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
    }
}
