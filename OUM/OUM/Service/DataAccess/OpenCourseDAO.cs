using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Service.DataAccess
{
    public class OpenCourseDAO
    {
        private const string PDBADMIN_USERNAME = "PDB_ADMIN";
        private const string MOMON_TABLE_NAME = "MOMON";
        private const string COL_NAME_MAMM = "MAMM";
        private const string COL_NAME_MAHP = "MAHP";
        private const string COL_NAME_MAGV = "MAGV";
        private const string COL_NAME_HK = "HK";
        private const string COL_NAME_NAM = "NAM";

        private OracleDAO oracleDAO = new OracleDAO();

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
        public List<Course> getAllCourses()
        {
            string connectString = oracleDAO.GetConnectionString();
            List < Course> courses= new List<Course>();
            try
            {
                using (OracleConnection con = new OracleConnection(connectString))
                {
                    con.Open();
                    string query = @$"SELECT * FROM {PDBADMIN_USERNAME}.{MOMON_TABLE_NAME}";
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
    }
}
