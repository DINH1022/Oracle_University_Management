using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Service.DataAccess
{
    public class StudentDao
    {
        private readonly OracleDAO _oracleDAO;

        public StudentDao()
        {
            _oracleDAO = new OracleDAO();
        }

        private OracleConnection GetOracleConnection()
        {
            string connectString = _oracleDAO.GetConnectionString();
            return new OracleConnection(connectString);
        }

        public List<Student> GetListStudents()
        {
            List<Student> students = new List<Student>();

            using (OracleConnection connection = GetOracleConnection())
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Lỗi khi lấy danh sách sinh viên: {ex.Message}",
                        "Lỗi Truy Vấn Dữ Liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            return students;
        }

        
        public void InsertStudent(Student st)
        {
            using (var connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();
                    string username = "SV" + st.id.ToUpper();
                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM ALL_USERS WHERE USERNAME = :username";
                    checkCmd.Parameters.Add(new OracleParameter("username", username));

                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show(
                            $"Mã sinh viên {st.id} đã tồn tại trong hệ thống. Vui lòng sử dụng mã số khác.",
                            "Sinh viên đã tồn tại",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    
                    var createUserCmd = connection.CreateCommand();
                    createUserCmd.CommandText = $@"
                        BEGIN
                            EXECUTE IMMEDIATE 'CREATE USER {username} IDENTIFIED BY PASS123';
                            EXECUTE IMMEDIATE 'GRANT CREATE SESSION TO {username}';
                        END;";
                    createUserCmd.ExecuteNonQuery();
                    

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
                    insertCmd.Parameters.Add(new OracleParameter("address", st.address));

                    insertCmd.ExecuteNonQuery();

                    
                    MessageBox.Show(
                        $"Đã thêm sinh viên {st.name} thành công.",
                        "Thêm Sinh Viên Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("ORA-00001"))
                    {
                        MessageBox.Show(
                            $"Sinh viên với mã số {st.id} đã tồn tại trong hệ thống. Vui lòng sử dụng mã số khác.",
                            "Trùng Mã Sinh Viên",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-01400")) 
                    {
                        MessageBox.Show(
                            "Thiếu thông tin bắt buộc. Vui lòng điền đầy đủ thông tin sinh viên.",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02290")) 
                    {
                        MessageBox.Show(
                            "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại các thông tin như giới tính và trạng thái.",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02291")) 
                    {
                        MessageBox.Show(
                            "Khoa không tồn tại trong hệ thống. Vui lòng chọn khoa hợp lệ.",
                            "Lỗi Ràng Buộc Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Lỗi khi thêm sinh viên:\n{ex.Message}",
                            "Lỗi Hệ Thống",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        
        public void UpdateStudent(Student st)
        {
            using (var connection = GetOracleConnection())
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
                        MessageBox.Show(
                            $"Không tìm thấy sinh viên có mã số {st.id} để cập nhật.",
                            "Không Tìm Thấy Sinh Viên",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Đã cập nhật thông tin sinh viên {st.name} thành công.",
                            "Cập Nhật Thành Công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("ORA-01400")) 
                    {
                        MessageBox.Show(
                            "Thiếu thông tin bắt buộc. Vui lòng điền đầy đủ thông tin sinh viên.",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02290")) 
                    {
                        MessageBox.Show(
                            "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại các thông tin như giới tính và trạng thái.",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02291")) 
                    {
                        MessageBox.Show(
                            "Khoa không tồn tại trong hệ thống. Vui lòng chọn khoa hợp lệ.",
                            "Lỗi Ràng Buộc Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Lỗi khi cập nhật sinh viên:\n{ex.Message}",
                            "Lỗi Hệ Thống",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }


        public void DeleteStudent(Student st)
        {
            using (var connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();

                    
                    var checkConstraintsCmd = connection.CreateCommand();
                    checkConstraintsCmd.CommandText = @"
                        SELECT COUNT(*) FROM DANGKY WHERE MASV = :masv";
                    checkConstraintsCmd.Parameters.Add(new OracleParameter("masv", st.id.ToUpper()));
                    int dangkyCount = Convert.ToInt32(checkConstraintsCmd.ExecuteScalar());

                    if (dangkyCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa sinh viên này vì sinh viên đang có {dangkyCount} đăng ký học phần.",
                            "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    var deleteStudentCmd = connection.CreateCommand();
                    deleteStudentCmd.CommandText = "DELETE FROM SINHVIEN WHERE MASV = :masv";
                    deleteStudentCmd.Parameters.Add(new OracleParameter("masv", st.id.ToUpper()));
                    deleteStudentCmd.ExecuteNonQuery();

                    
                    
                    var dropUserCmd = connection.CreateCommand();
                    dropUserCmd.CommandText = $"DROP USER {st.Username} CASCADE";
                    dropUserCmd.ExecuteNonQuery();
                    

                    MessageBox.Show("Sinh viên đã được xóa thành công.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = "Lỗi khi xóa sinh viên";

                    if (ex.Message.Contains("integrity constraint"))
                    {
                        errorMessage = "Không thể xóa sinh viên này vì còn dữ liệu liên quan trong hệ thống.";
                    }
                    else
                    {
                        errorMessage += ":\n" + ex.Message;
                    }

                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public bool IsMaSVExists(string maSV)
        {
            using (var connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();
                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM SINHVIEN WHERE MASV = :masv";
                    checkCmd.Parameters.Add(new OracleParameter("masv", maSV));
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi kiểm tra mã SV: " + ex.Message);
                    return false;
                }
            }
        }


    }
}
