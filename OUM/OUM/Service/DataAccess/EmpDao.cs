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
                    MessageBox.Show(
                        $"Lỗi khi lấy danh sách nhân viên: {ex.Message}",
                        "Lỗi Truy Vấn Dữ Liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
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

                    if (userExists > 0)
                    {
                        MessageBox.Show(
                            $"Mã nhân viên {emp.manld} đã tồn tại trong hệ thống. Vui lòng sử dụng mã số khác.",
                            "Nhân viên đã tồn tại",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    var createUserCmd = connection.CreateCommand();
                    createUserCmd.CommandText = $@"
                            BEGIN
                                EXECUTE IMMEDIATE 'CREATE USER {emp.manld} IDENTIFIED BY PASS123';
                                EXECUTE IMMEDIATE 'GRANT CONNECT TO {emp.manld}';
                            END;";
                    createUserCmd.ExecuteNonQuery();


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

                    MessageBox.Show(
                        $"Đã thêm nhân viên {emp.name} thành công.",
                        "Thêm Nhân Viên Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("ORA-00001"))
                    {
                        MessageBox.Show(
                            $"Nhân viên với mã số {emp.manld} đã tồn tại trong hệ thống. Vui lòng sử dụng mã số khác.",
                            "Trùng Mã Nhân Viên",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-01400")) 
                    {
                        MessageBox.Show(
                            "Thiếu thông tin bắt buộc. Vui lòng điền đầy đủ các trường:\n" +
                            "- Mã nhân viên\n- Họ tên\n- Giới tính",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02290")) 
                    {
                        MessageBox.Show(
                            "Dữ liệu không hợp lệ. Vui lòng kiểm tra:\n" +
                            "- Giới tính chỉ chấp nhận 'Nam' hoặc 'Nữ'\n" +
                            "- Vai trò phải nằm trong danh sách cho phép",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02291")) 
                    {
                        MessageBox.Show(
                            $"Đơn vị '{emp.madv}' không tồn tại trong hệ thống. Vui lòng chọn đơn vị hợp lệ.",
                            "Lỗi Ràng Buộc Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Lỗi khi thêm nhân viên:\n{ex.Message}",
                            "Lỗi Hệ Thống",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
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
                        MessageBox.Show(
                            $"Không tìm thấy nhân viên có mã số {emp.manld} để cập nhật.",
                            "Không Tìm Thấy Nhân Viên",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Đã cập nhật thông tin nhân viên {emp.name} thành công.",
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
                            "Thiếu thông tin bắt buộc. Vui lòng điền đầy đủ thông tin nhân viên.",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02290")) 
                    {
                        MessageBox.Show(
                            "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại các thông tin như giới tính và vai trò.",
                            "Lỗi Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else if (ex.Message.Contains("ORA-02291")) 
                    {
                        MessageBox.Show(
                            "Đơn vị không tồn tại trong hệ thống. Vui lòng chọn đơn vị hợp lệ.",
                            "Lỗi Ràng Buộc Dữ Liệu",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Lỗi khi cập nhật nhân viên:\n{ex.Message}",
                            "Lỗi Hệ Thống",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
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

                    
                    var checkDonviCmd = connection.CreateCommand();
                    checkDonviCmd.CommandText = @"
                        SELECT COUNT(*) FROM DONVI WHERE TRGDV = :manld";
                    checkDonviCmd.Parameters.Add(new OracleParameter("manld", emp.manld.ToUpper()));
                    int donviCount = Convert.ToInt32(checkDonviCmd.ExecuteScalar());

                    if (donviCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa nhân viên này vì đang là trưởng {donviCount} đơn vị.",
                            "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                    var checkMomonCmd = connection.CreateCommand();
                    checkMomonCmd.CommandText = @"
                        SELECT COUNT(*) FROM MOMON WHERE MAGV = :manld";
                    checkMomonCmd.Parameters.Add(new OracleParameter("manld", emp.manld.ToUpper()));
                    int momonCount = Convert.ToInt32(checkMomonCmd.ExecuteScalar());

                    if (momonCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa nhân viên này vì đang phụ trách {momonCount} môn.",
                            "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
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

                    MessageBox.Show("Nhân viên đã được xóa thành công.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = "Lỗi khi xóa nhân viên";

                    if (ex.Message.Contains("integrity constraint"))
                    {
                        errorMessage = "Không thể xóa nhân viên này vì còn dữ liệu liên quan trong hệ thống.";
                    }
                    else
                    {
                        errorMessage += ":\n" + ex.Message;
                    }

                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
