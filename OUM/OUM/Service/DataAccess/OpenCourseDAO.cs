using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Service.DataAccess
{
    public class OpenCourseDAO
    {

        public OpenCourseDAO()
        {
            user_role = GetUserRole();
        }
        private const string PDBADMIN_USERNAME = "PDB_ADMIN";

        private const string MOMON_TABLE_NAME = "MOMON";
        private const string COL_NAME_MAMM = "MAMM";
        private const string COL_NAME_MAHP = "MAHP";
        private const string COL_NAME_MAGV = "MAGV";
        private const string COL_NAME_HK = "HK";
        private const string COL_NAME_NAM = "NAM";
        private const string COL_NAME_NGAY_MO = "NGAY_MO";

        private const string TEACHER_LIST_MANLD_TABLE_NAME = "VIEW_PDT_MANLDS";
        private const string COL_NAME_MANLD = "MANLD";
        private const string COL_NAME_VAITRO = "VAITRO";
        //private const string COL_NAME_HOTEN = "HOTEN";
        //private const string COL_NAME_PHAI = "PHAI";
        //private const string COL_NAME_NGSINH = "NGSINH";
        //private const string COL_NAME_LUONG = "LUONG";
        //private const string COL_NAME_PHUCAP = "PHUCAP";
        //private const string COL_NAME_DT = "DT
        //private const string COL_NAME_MADV = "MADV";

        private const string COURSE_TABLE_NAME = "HOCPHAN";
        private const string COL_NAME_MAHP_TABLE_COURSE = "MAHP";

        private const string MOMON_VIEW_NVPDT = "NV_PDT_MOMON_VIEW";
        private const string MOMON_VIEW_TRGDV = "TRGDV_MOMON_VIEW";
        private const string MOMON_VIEW_GV = "GV_SELF_MOMON_VIEW";
        private const string MOMON_VIEW_SV = "SV_MOMON_VIEW";

        private const string COMPUTE_NEXTMM_FUNCTION_NAME = "GET_NEXT_MM";

        private const string ORACLE_ERROR_CODE_VIOLATE_FOREIGN_KEY = "ORA-02292"; 

        private const string ORACLE_ERROR_CODE_VIEW_NOT_EXIST = "ORA-00942";

        private Dictionary<string, string> ROLE_VIEW_MAPPING= new Dictionary<string, string>()
        {
            {RoleEnum.ROLE_TRGDV,MOMON_VIEW_TRGDV },
            {RoleEnum.ROLE_NV_PDT,MOMON_VIEW_NVPDT },
            {RoleEnum.ROLE_GV,MOMON_VIEW_GV },
            {RoleEnum.ROLE_SV,MOMON_VIEW_SV }
        };

        private string user_role;

        private Dictionary<int,int> TERM_TO_MONTH= new Dictionary<int, int>()
        {
            {1,9},
            {2,1},
            {3,5 }
        };


        private const string TEACHER_ROLE = "GV";

        private OracleDAO oracleDAO = new OracleDAO();

        public string GetUserRole()
        {
            List<string> roles = new List<string>();
            try
            {
                using (OracleConnection conn = new OracleConnection(oracleDAO.GetConnectionString()))
                {
                    conn.Open();
                    string query = "SELECT GRANTED_ROLE FROM USER_ROLE_PRIVS";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log nếu cần
                MessageBox.Show("Lỗi khi truy vấn vai trò người dùng: " + ex.Message,
                                "Lỗi hệ thống",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            return roles[0];
        }
        private Course buildCourseFromReader(OracleDataReader reader)
        {
            if (reader == null)
            {
                return null;
            }
            string mamm = reader[COL_NAME_MAMM].ToString();
            string mahp= reader[COL_NAME_MAHP].ToString();
            string magv=reader[COL_NAME_MAGV].ToString();
            string hk = reader[COL_NAME_HK].ToString();
            string nam = reader[COL_NAME_NAM].ToString();
            return new Course()
            {
                MAMM=mamm,
                MAGV=magv,
                MAHP=mahp,
                HK=hk,
                NAM=nam,
                
            };
        }
        private string buildQuerySearchAllCourse()
        {
            string view = ROLE_VIEW_MAPPING[user_role];
            return @$"SELECT * FROM {PDBADMIN_USERNAME}.{view}";
        }
        public List<Course> getAllCourses()
        {
            string connectString = oracleDAO.GetConnectionString();
            List < Course> courses= new List<Course>();
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = buildQuerySearchAllCourse();
                    OracleCommand oracleCommand = new OracleCommand(query,con);
                    OracleDataReader reader=oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Course newCourse=buildCourseFromReader(reader);
                        courses.Add(newCourse);
                    }
                }
                return courses;
            }
            catch (Exception ex)
            {
                return courses;
            }
        }

        public List<string> getAllTeacherIDs()
        {
            string connectString = oracleDAO.GetConnectionString();
            List<string> ids = new List<string>();
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT * FROM {PDBADMIN_USERNAME}.{TEACHER_LIST_MANLD_TABLE_NAME}";
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader[COL_NAME_MANLD].ToString();
                        ids.Add(id);
                    }
                }
                return ids;
            }
            catch (Exception ex)
            {
                return ids;
            }
        }

        public List<string> getAllCourseIDs()
        {
            string connectString = oracleDAO.GetConnectionString();
            List<string> ids = new List<string>();
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT * FROM {PDBADMIN_USERNAME}.{COURSE_TABLE_NAME}";
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    OracleDataReader reader = oracleCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader[COL_NAME_MAHP_TABLE_COURSE].ToString();
                        ids.Add(id);
                    }
                }
                return ids;
            }
            catch (Exception ex)
            {
                return ids;
            }
        }

        public Course create(Course newCourse)
        {
            string connectString = oracleDAO.GetConnectionString();
            string NEXT_MM_TEXT = "NEXT_MM";
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = $@"SELECT {PDBADMIN_USERNAME}.{COMPUTE_NEXTMM_FUNCTION_NAME} AS {NEXT_MM_TEXT} FROM DUAL";
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    OracleDataReader reader=oracleCommand.ExecuteReader();
                    reader.Read();
                    int nextMAMM = int.Parse(reader[NEXT_MM_TEXT].ToString());
                    string open_day = $@"01/0{TERM_TO_MONTH[int.Parse(newCourse.HK)]}/{newCourse.NAM}";
                    newCourse.MAMM = nextMAMM.ToString();
                    string view = ROLE_VIEW_MAPPING[user_role];
                    query = @$"INSERT INTO {PDBADMIN_USERNAME}.{view} 
                                    ({COL_NAME_MAMM},{COL_NAME_MAHP},{COL_NAME_MAGV},{COL_NAME_HK},{COL_NAME_NAM},{COL_NAME_NGAY_MO}) 
                                    VALUES({newCourse.MAMM},'{newCourse.MAHP}','{newCourse.MAGV}',{newCourse.HK},{newCourse.NAM},TO_DATE('{open_day}','DD/MM/YYYY'))";
                    oracleCommand = new OracleCommand(query, con);
                    oracleCommand.ExecuteNonQuery();
                }
                Course savedCourse = new Course()
                {
                    MAMM = newCourse.MAMM,
                    MAHP = newCourse.MAHP,
                    MAGV = newCourse.MAGV,
                    HK = newCourse.HK,
                    NAM = newCourse.NAM,
                };
                return savedCourse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Course updateCourse(String courseId,Course newCourse)
        {
            string connectString = oracleDAO.GetConnectionString();
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    con.Open();
                    string view = ROLE_VIEW_MAPPING[user_role];
                    string query = @$"UPDATE {PDBADMIN_USERNAME}.{view}  
                                    SET {COL_NAME_MAHP}='{newCourse.MAHP}',
                                    {COL_NAME_MAGV}='{newCourse.MAGV}',{COL_NAME_HK}='{newCourse.HK}',{COL_NAME_NAM}='{newCourse.NAM}'
                                    WHERE {COL_NAME_MAMM}={courseId}";
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    oracleCommand.ExecuteNonQuery();

                }
                Course updatedCourse = new Course()
                {
                    MAMM=newCourse.MAMM,
                    MAHP=newCourse.MAHP,
                    MAGV=newCourse.MAGV,
                    HK=newCourse.HK,
                    NAM=newCourse.NAM,
                };
                return updatedCourse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string deleteCourse(string mamm)
        {
            string connectString = oracleDAO.GetConnectionString();
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    con.Open();
                    string view = ROLE_VIEW_MAPPING[user_role];
                    string query = @$"DELETE FROM {PDBADMIN_USERNAME}.{view}  
                                    WHERE {COL_NAME_MAMM}={mamm}";
                    OracleCommand oracleCommand = new OracleCommand(query, con);
                    oracleCommand.ExecuteNonQuery();

                }
                return "Xóa thành công";
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains(ORACLE_ERROR_CODE_VIOLATE_FOREIGN_KEY.ToLower()))
                {
                    return "Mở môn này đang được sử dụng trong bảng đăng ký, vui lòng xóa hết dữ liệu trong bảng đăng ký trước";
                }
                if (ex.Message.ToLower().Contains(ORACLE_ERROR_CODE_VIEW_NOT_EXIST.ToLower()))
                {
                    return "Bạn không có quyền";
                }
                return "Có lỗi hệ thống";

            }
        }

       

    }
}
