using OUM.Model;
using OUM.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.ViewModel
{
    public class RoleViewModel : INotifyPropertyChanged
    {
        private List<UserPerRole> _userPerRoles;

        public event PropertyChangedEventHandler? PropertyChanged;
        public List<UserPerRole> UserPerRoles
        {
            get => _userPerRoles;
            set
            {
                _userPerRoles = value;
            }
        }

        public void LoadData()
        {
            OracleDAO dao = new OracleDAO();
            UserPerRoles = dao.GetListRole();
        }

        public void DeleteRole(UserPerRole upr)
        {
            OracleDAO dao = new OracleDAO();
            dao.DropRole(upr.roleName);
            LoadData();
        }
        
        public void AddRole(UserPerRole r)
        {
            OracleDAO dao = new OracleDAO();
            dao.AddRole(r.roleName);
            LoadData();
        }

        
    }
}
