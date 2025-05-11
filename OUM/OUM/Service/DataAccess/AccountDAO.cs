using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OUM.Service.DataAccess
{
    public class AccountDAO
    {
        private OracleDAO oracleDAO = new OracleDAO();


        public string GetConnectionString()
        {
            return $"User Id={AdminSession.Username};Password={AdminSession.Password};Data Source=localhost:1521/DKHP;";
        }


        public Student GetStudentById(string username)
        {
            Student student = null;

            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT MASV, HOTEN, PHAI, NGSINH, DT, KHOA, TINHTRANG, DCHI
                FROM PDB_ADMIN.SINHVIEN
                WHERE MASV = :masv";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":masv", username.Substring(2)));

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new Student(
                                    id: reader["MASV"].ToString(),
                                    name: reader["HOTEN"].ToString(),
                                    gender: reader["PHAI"].ToString(),
                                    dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                    phone: reader["DT"]?.ToString() ?? "",
                                    department: reader["KHOA"]?.ToString() ?? "",
                                    status: reader["TINHTRANG"]?.ToString() ?? "",
                                    address: reader["DCHI"]?.ToString() ?? ""
                                );
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin sinh viên: " + ex.Message);
                }
            }

            return student;
        }



        public Employee GetEmployeeById(string username)
        {
            Employee employee = null;

            using (var connection = new OracleConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT 
                        N.MANLD,
                        N.HOTEN,
                        N.PHAI,
                        N.NGSINH,
                        N.DT,
                        N.MADV,
                        N.VAITRO,
                        N.LUONG,
                        N.PHUCAP
                    FROM PDB_ADMIN.NHANVIEN N
                    WHERE N.MANLD =:username";

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":username", username));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee(
                                    manld: reader["MANLD"].ToString(),
                                    name: reader["HOTEN"].ToString(),
                                    gender: reader["PHAI"].ToString(),
                                    dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                    phone: reader["DT"]?.ToString() ?? "",
                                    madv: reader["MADV"]?.ToString() ?? "",
                                    role: reader["VAITRO"]?.ToString() ?? "",
                                    salary: reader["LUONG"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LUONG"]),
                                    allowance: reader["PHUCAP"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PHUCAP"])
                                );
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin nhân viên: " + ex.Message);
                }
            }

            return employee;
        }



        public bool UpdateStudentPhone(string username, string newPhone)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "UPDATE PDB_ADMIN.SINHVIEN SET DT = :newPhone WHERE MASV = :masv";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":newPhone", newPhone));
                    command.Parameters.Add(new OracleParameter(":masv", username.Substring(2)));

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật số điện thoại: " + ex.Message);
                        return false;
                    }
                }

            }
        }


        public bool UpdateEmployeePhone(string manld, string newPhone)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "UPDATE PDB_ADMIN.NHANVIEN SET DT = :newPhone WHERE MANLD = :manld";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":newPhone", newPhone));
                    command.Parameters.Add(new OracleParameter(":manld", manld));

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật số điện thoại: " + ex.Message);
                        return false;
                    }
                }

            }
        }


        public bool UpdateStudentAddress(string username, string newAddress)
        {
            using (var connection = new OracleConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "UPDATE PDB_ADMIN.SINHVIEN SET DCHI = :newAddress WHERE MASV = :masv";
                using (var command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":newAddress", newAddress));
                    command.Parameters.Add(new OracleParameter(":masv", username.Substring(2)));  // Lấy mã sinh viên từ username (VD: SVxxxx)

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;  // Trả về true nếu có ít nhất một dòng bị ảnh hưởng
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật địa chỉ: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
