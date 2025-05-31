using Oracle.ManagedDataAccess.Client;
using OUM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Service.DataAccess
{
    public class NotificationDao
    {
        private readonly OracleDAO _oracleDAO;

        public NotificationDao()
        {
            _oracleDAO = new OracleDAO();
        }

        private OracleConnection GetOracleConnection()
        {
            string connectString = _oracleDAO.GetConnectionString();
            return new OracleConnection(connectString);
        }

        public List<Model.Notification> GetNotifications()
        {
            List<Model.Notification> notifications = new List<Model.Notification>();
            using (OracleConnection connection = GetOracleConnection())
            {

                try
                {
                    connection.Open();
                    string query = "SELECT ID, CONTENT, CREATED_AT, LABEL FROM pdb_admin.THONGBAO";


                    using (var command = new OracleCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Notification n = new Notification(
                                id: reader["ID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID"]),
                                content: reader["CONTENT"]?.ToString() ?? "",
                                created_date: reader["CREATED_AT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CREATED_AT"]),
                                label: reader["LABEL"]?.ToString() ?? ""
                            );
                                

                            notifications.Add(n);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Thông báo rỗng",
                        "Thông báo",
                        MessageBoxButtons.OK
                    );
                }

            }
            return notifications;
        }



    }
}
