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

    }
}
