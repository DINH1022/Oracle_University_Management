using OUM.Service.DataAccess;
using OUM.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.ViewModel
{
    public class AdminViewModel:INotifyPropertyChanged
    {
        private OracleDAO dao = new OracleDAO();

        public event PropertyChangedEventHandler? PropertyChanged;
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public bool AdminLogin()
        {
            bool success = dao.AuthenticateAdmin(username, password);
            if(success)
            {
                AdminSession.Login(username, password);
                return true;
            }
            else
            {
                return false;
            }
        }
        //Viết hàm tạo user ở đây. gọi tới OracleDAO service để truy vấn xuống database.
        // View(form/page) sẽ gọi hàm được từ ViewModel
        // Các lớp sẽ được định nghĩa tại Model. ví dụ như lớp student 
    }
}
