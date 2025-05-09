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
    public class EmpDao
    {
        private readonly OracleDAO _oracleDAO;

        public EmpDao()
        {
            _oracleDAO = new OracleDAO();
        }

        private OracleConnection GetOracleConnection()
        {
            string connectString = _oracleDAO.GetConnectionString();
            return new OracleConnection(connectString);
        }

        public List<Employee> GetListEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (OracleConnection connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            NV.MANLD,
                            NV.HOTEN,
                            NV.PHAI,
                            NV.NGSINH,
                            NV.LUONG,
                            NV.PHUCAP,
                            NV.DT,
                            NV.MADV,
                            NV.VAITRO,
                            U.USERNAME,
                            U.CREATED AS THOIGIANTAO
                        FROM NHANVIEN NV
                        LEFT JOIN DBA_USERS U ON NV.MANLD = U.USERNAME
                        ORDER BY NV.MANLD";

                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee(
                                manld: reader["MANLD"].ToString(),
                                name: reader["HOTEN"].ToString(),
                                gender: reader["PHAI"].ToString(),
                                dob: reader["NGSINH"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGSINH"]),
                                salary: reader["LUONG"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LUONG"]),
                                allowance: reader["PHUCAP"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PHUCAP"]),
                                phone: reader["DT"]?.ToString() ?? "",
                                madv: reader["MADV"]?.ToString() ?? "",
                                role: reader["VAITRO"].ToString()
                            );

                            emp.Username = reader["USERNAME"]?.ToString() ?? "";
                            emp.CreatedTime = reader["THOIGIANTAO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["THOIGIANTAO"]);

                            employees.Add(emp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
                }
            }

            return employees;
        }

        public void InsertEmployee(Employee emp)
        {
            using (var connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();

                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM ALL_USERS WHERE USERNAME = :username";
                    checkCmd.Parameters.Add(new OracleParameter("username", emp.manld.ToUpper()));

                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists == 0)
                    {
                        var createUserCmd = connection.CreateCommand();
                        createUserCmd.CommandText = $@"
                            BEGIN
                                EXECUTE IMMEDIATE 'CREATE USER {emp.manld} IDENTIFIED BY PASS123';
                                EXECUTE IMMEDIATE 'GRANT CONNECT TO {emp.manld}';
                            END;";
                        createUserCmd.ExecuteNonQuery();
                    }

                    var insertCmd = connection.CreateCommand();
                    insertCmd.CommandText = @"INSERT INTO NHANVIEN (MANLD, HOTEN, PHAI, NGSINH, LUONG, PHUCAP, DT, MADV, VAITRO) 
                                      VALUES (:manld, :name, :gender, :dob, :salary, :allowance, :phone, :madv, :role)";
                    insertCmd.Parameters.Add(new OracleParameter("manld", emp.manld));
                    insertCmd.Parameters.Add(new OracleParameter("name", emp.name));
                    insertCmd.Parameters.Add(new OracleParameter("gender", emp.gender));
                    insertCmd.Parameters.Add(new OracleParameter("dob", emp.dob));
                    insertCmd.Parameters.Add(new OracleParameter("salary", emp.salary));
                    insertCmd.Parameters.Add(new OracleParameter("allowance", emp.allowance));
                    insertCmd.Parameters.Add(new OracleParameter("phone", emp.phone));
                    insertCmd.Parameters.Add(new OracleParameter("madv", emp.madv));
                    insertCmd.Parameters.Add(new OracleParameter("role", emp.role));

                    insertCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("ORA-00001"))
                    {
                        MessageBox.Show("User đã tồn tại. Vui lòng nhập mã nld khác.");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                    }
                }
            }
        }

        
        public void UpdateEmployee(Employee emp)
        {
            using (var connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();

                    var updateCmd = connection.CreateCommand();
                    updateCmd.CommandText = @"
                        UPDATE NHANVIEN 
                        SET HOTEN = :name, 
                            PHAI = :gender, 
                            NGSINH = :dob, 
                            LUONG = :salary, 
                            PHUCAP = :allowance, 
                            DT = :phone, 
                            MADV = :madv, 
                            VAITRO = :role
                        WHERE MANLD = :manld";

                    updateCmd.Parameters.Add(new OracleParameter("name", emp.name));
                    updateCmd.Parameters.Add(new OracleParameter("gender", emp.gender));
                    updateCmd.Parameters.Add(new OracleParameter("dob", emp.dob));
                    updateCmd.Parameters.Add(new OracleParameter("salary", emp.salary));
                    updateCmd.Parameters.Add(new OracleParameter("allowance", emp.allowance));
                    updateCmd.Parameters.Add(new OracleParameter("phone", emp.phone));
                    updateCmd.Parameters.Add(new OracleParameter("madv", emp.madv));
                    updateCmd.Parameters.Add(new OracleParameter("role", emp.role));
                    updateCmd.Parameters.Add(new OracleParameter("manld", emp.manld));

                    int rows = updateCmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để cập nhật.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật nhân viên:\n" + ex.Message);
                }
            }
        }

        
        public void DeleteEmployee(Employee emp)
        {
            using (var connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();

                   
                    var deleteEmpCmd = connection.CreateCommand();
                    deleteEmpCmd.CommandText = "DELETE FROM NHANVIEN WHERE MANLD = :manld";
                    deleteEmpCmd.Parameters.Add(new OracleParameter("manld", emp.manld.ToUpper()));
                    deleteEmpCmd.ExecuteNonQuery();

                    
                    if (!string.IsNullOrEmpty(emp.Username))
                    {
                        var dropUserCmd = connection.CreateCommand();
                        dropUserCmd.CommandText = $"DROP USER {emp.Username} CASCADE";
                        dropUserCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên:\n" + ex.Message);
                }
            }
        }

        
        public bool IsMaNLDExists(string maNLD)
        {
            using (var connection = GetOracleConnection())
            {
                try
                {
                    connection.Open();
                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM NHANVIEN WHERE MANLD = :manld";
                    checkCmd.Parameters.Add(new OracleParameter("manld", maNLD));
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi kiểm tra mã NLD: " + ex.Message);
                    return false;
                }
            }
        }











    }
}
