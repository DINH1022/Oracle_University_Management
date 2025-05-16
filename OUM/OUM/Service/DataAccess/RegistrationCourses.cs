using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using OUM.Model;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

namespace OUM.Service.DataAccess
{
    public class RegistrationCourses
    {
        private OracleDAO dao = new OracleDAO();
        private const string PDBADMIN_USERNAME = "pdb_admin";
        private const string DANGKY_TABLE_NAME = "DANGKY";
        private const string DANGKY_HOCPHAN_TABLE_NAME = "DANGKY_HOCPHAN";

        private const string MOMON_VIEW_NAME = "SV_MOMON_VIEW";
        private const string PDT_MOMON_VIEW_NAME = "NV_PDT_MOMON_VIEW";
        private const string GV_MOMON_VIEW_NAME = "GV_SELF_MOMON_VIEW";

        private const string HOCPHAN_TABLE_NAME = "HOCPHAN";
        private const string SINHVIEN_TABLE_NAME = "SINHVIEN";


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




        public List<NewRegistrationCourse> getRegisteredCoursesByMASV(string keyword,string masv)
        {
            string connectString = dao.GetConnectionString();
            List<NewRegistrationCourse> courses = new List<NewRegistrationCourse>();
            try
            {
                using (var con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT DK.MAMM,HP.MAHP,HP.TENHP,HP.SOTC, HP.STTH,HP.STLT
                                      FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} DK JOIN 
                                           {PDBADMIN_USERNAME}.{PDT_MOMON_VIEW_NAME} MM ON (DK.MAMM = MM.MAMM) JOIN
                                           {PDBADMIN_USERNAME}.{HOCPHAN_TABLE_NAME} HP ON (MM.MAHP = HP.MAHP) 
                                           WHERE DK.MASV =:masv"
                                           +(!string.IsNullOrEmpty(keyword) ? " AND UPPER(HP.TENHP) LIKE UPPER(:keyword)" : "");
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    oracleCommand.Parameters.Add(new OracleParameter("masv", masv));
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        oracleCommand.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    OracleDataReader reader = oracleCommand.ExecuteReader();
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
                    con.Close();
                }
                return courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get registered course", ex.Message);
                return courses;
            }
        }


        public List<StudenRegisterdCourseGrade> getRegistrationGradeCourse(string keyword, string mamm)
        {
            string connectString = dao.GetConnectionString();
            List<StudenRegisterdCourseGrade> courses = new List<StudenRegisterdCourseGrade>();
            try
            {
                using (var con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT DK.MAMM,DK.MASV, DK.DIEMTH, DK.DIEMQT, DK.DIEMCK, DK.DIEMTK
                                      FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} DK                                     
                                           WHERE DK.MAMM =:mamm"
                                           + (!string.IsNullOrEmpty(keyword) ? " AND UPPER(DK.MASV) LIKE UPPER(:keyword)" : "");
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    oracleCommand.Parameters.Add(new OracleParameter("mamm", mamm));
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        oracleCommand.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        StudenRegisterdCourseGrade course = new StudenRegisterdCourseGrade(
                            mamm: reader["MAMM"].ToString(),
                            masv: reader["MASV"].ToString(),
                            diemth: reader["DIEMTH"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMTH"]),
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
                Console.WriteLine("Error when get course", ex.Message);
                return courses;
            }
        }


        public List<CodeCourse> getCodeCourse(string keyword)
        {
            string connectString = dao.GetConnectionString();
            List<CodeCourse> codes = new List<CodeCourse>();
            try
            {
                using (var con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT DISTINCT DK.MAMM
                                      FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} DK"
                                           + (!string.IsNullOrEmpty(keyword) ? " WHERE UPPER(DK.MAMM) LIKE UPPER(:keyword)" : "");
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        oracleCommand.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        CodeCourse code = new CodeCourse(
                        code: reader["MAMM"].ToString());
                        codes.Add(code);
                    }
                    con.Close();
                }
                return codes;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get course", ex.Message);
                return codes;
            }
        }

        public List<NewRegistrationCourse> getNewRegistrationCoursesByMASV(string keyword, string masv)
        {
            string connectString = dao.GetConnectionString();
            List<NewRegistrationCourse> courses = new List<NewRegistrationCourse>();
            try
            {
                using (var con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT MM.MAMM, MM.MAHP, HP.TENHP,HP.SOTC, HP.STLT, HP.STTH
                                      FROM {PDBADMIN_USERNAME}.{PDT_MOMON_VIEW_NAME} MM JOIN
                                           {PDBADMIN_USERNAME}.{HOCPHAN_TABLE_NAME} HP ON (MM.MAHP = HP.MAHP) JOIN
                                           {PDBADMIN_USERNAME}.{SINHVIEN_TABLE_NAME} SV ON (SV.KHOA = HP.MADV)
                                            WHERE SV.MASV =:masv1 AND MM.MAMM NOT IN (SELECT MAMM FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} WHERE MASV =:masv2)"
                                           + (!string.IsNullOrEmpty(keyword) ? " AND UPPER(HP.TENHP) LIKE UPPER(:keyword)" : "");
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    oracleCommand.Parameters.Add(new OracleParameter("masv1", masv));
                    oracleCommand.Parameters.Add(new OracleParameter("masv2", masv));

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        oracleCommand.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    OracleDataReader reader = oracleCommand.ExecuteReader();
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
                    con.Close();
                }
                return courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get registered course", ex.Message);
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





        public bool UpdateStudentCourseGrade(StudenRegisterdCourseGrade studentGrade)
        {
            try
            {
                string connectionString = dao.GetConnectionString();
                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"UPDATE {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} SET 
                    DIEMTH=:diemth, DIEMQT=:diemqt, DIEMCK=:diemck,DIEMTK=:diemtk
                    WHERE MAMM=:mamm AND MASV=:masv";
                                         
                    OracleCommand command = new OracleCommand(query, connection);
                    command.Parameters.Add(new OracleParameter("diemth", studentGrade.DIEMTH));
                    command.Parameters.Add(new OracleParameter("diemqt", studentGrade.DIEMQT));
                    command.Parameters.Add(new OracleParameter("diemck", studentGrade.DIEMCK));
                    command.Parameters.Add(new OracleParameter("diemtk", studentGrade.DIEMTK));
                    command.Parameters.Add(new OracleParameter("mamm", studentGrade.MAMM));
                    command.Parameters.Add(new OracleParameter("masv", studentGrade.MASV));
                    int count = command.ExecuteNonQuery();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Student> GetAllStudent(string keyword)
        {
            List<Student> students = new List<Student>();
            try
            {
                string connectionString = dao.GetConnectionString();
                using (var connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"SELECT MASV, HOTEN, PHAI, NGSINH, KHOA, DT, TINHTRANG, DCHI
                                      FROM {PDBADMIN_USERNAME}.{SINHVIEN_TABLE_NAME}"                                 
                                            + (!string.IsNullOrEmpty(keyword) ? " WHERE (UPPER(MASV) LIKE UPPER(:keyword))  OR (UPPER(HOTEN) LIKE UPPER(:keyword))"  : "");
                    OracleCommand command = new OracleCommand(query, connection);                 
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        command.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student(
                            id: reader["MASV"].ToString(),
                                name: reader["HOTEN"].ToString(),
                                gender: reader["PHAI"].ToString(),
                                dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                phone: reader["DT"]?.ToString() ?? "",
                                department: reader["KHOA"]?.ToString() ?? "",
                                status: reader["TINHTRANG"]?.ToString() ?? "",
                                address: reader["DCHI"]?.ToString() ?? ""
                        );
                        students.Add(student);
                    }
                    connection.Close();
                    return students;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return students;
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
        public bool RegisterCourse(string mamm,string masv)
        {
            string connectionString = dao.GetConnectionString();
            try
            {
                using(var connection  = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = $@"INSERT INTO {PDBADMIN_USERNAME}.{DANGKY_HOCPHAN_TABLE_NAME} (MASV,MAMM) VALUES(:masv,:mamm)";
                    OracleCommand command = new OracleCommand(query,connection);
                    command.Parameters.Add(new OracleParameter("masv",masv));
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

        public List<CourseDetail> getCourseDetaiOfGV(string keyword)
        {
            string connectString = dao.GetConnectionString();
            List<CourseDetail> courses = new List<CourseDetail>();
            try
            {
                using (var con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT MM.MAMM,MM.MAHP,HP.TENHP,HP.SOTC, HP.STTH,HP.STLT, MM.HK,MM.NAM
                                      FROM {PDBADMIN_USERNAME}.{GV_MOMON_VIEW_NAME} MM JOIN
                                           {PDBADMIN_USERNAME}.{HOCPHAN_TABLE_NAME} HP ON (MM.MAHP = HP.MAHP)"
                                           + (!string.IsNullOrEmpty(keyword) ? " WHERE UPPER(HP.TENHP) LIKE UPPER(:keyword)" : "");
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        oracleCommand.Parameters.Add(new OracleParameter("keyword", "%" + keyword + "%"));
                    }
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        CourseDetail course = new CourseDetail(
                            mamm: reader["MAMM"].ToString(),
                            mahp: reader["MAHP"].ToString(),
                            tenhp: reader["TENHP"].ToString(),
                            sotc: Convert.ToInt32(reader["SOTC"]),
                            stth: Convert.ToInt32(reader["STTH"]),
                            stlt: Convert.ToInt32(reader["STLT"]),
                            hk: Convert.ToInt32(reader["HK"]),
                            nam: Convert.ToInt32(reader["NAM"])
                        );
                        courses.Add(course);
                    }
                    con.Close();
                }
                return courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get registered course", ex.Message);
                return courses;
            }
        }

        public List<StudenRegisterdCourseGrade> getListStudentsOfGV(string mamm)
        {
            string connectString = dao.GetConnectionString();
            List<StudenRegisterdCourseGrade> students = new List<StudenRegisterdCourseGrade>();
            try
            {
                using (var con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT DK.MASV, SV.HOTEN, DK.DIEMTH, DK.DIEMQT, DK.DIEMCK, DK.DIEMTK
                                      FROM {PDBADMIN_USERNAME}.{DANGKY_TABLE_NAME} DK JOIN
                                           {PDBADMIN_USERNAME}.{SINHVIEN_TABLE_NAME} SV ON (DK.MASV = SV.MASV)
                                           WHERE DK.MAMM =:mamm";
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    oracleCommand.Parameters.Add(new OracleParameter("mamm", mamm));
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        StudenRegisterdCourseGrade student = new StudenRegisterdCourseGrade
                        (
                            mamm: mamm,
                            masv: reader["MASV"].ToString(),
                            diemth: reader["DIEMTH"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMTH"]),
                            diemqt: reader["DIEMQT"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMQT"]),
                            diemck: reader["DIEMCK"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMCK"]),
                            diemtk: reader["DIEMTK"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DIEMTK"]),
                            tensv: reader["HOTEN"].ToString()
                        );
                        students.Add(student);
                    }
                    con.Close();
                }
                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when get registered course", ex.Message);
                return students;
            }
        }


    }
}
