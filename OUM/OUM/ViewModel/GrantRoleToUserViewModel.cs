using OUM.Model;
using OUM.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.ViewModel
{
    public class GrantRoleToUserViewModel
    {
        private readonly OracleDAO dao;
        public ObservableCollection<UserSystemInformation> Users { get; set; }
        public ObservableCollection<RoleSystemInformation> Roles { get; set; }
        public UserSystemInformation SelectedUser { get; set; } = null;
        public RoleSystemInformation SelectedRole { get; set; } = null;
        public string userSearchKeyword { get; set; }
        public string roleSearchKeyword { get; set; }

        public GrantRoleToUserViewModel()
        {
            dao = new OracleDAO();
            Users = new ObservableCollection<UserSystemInformation>();
            Roles = new ObservableCollection<RoleSystemInformation>();
            LoadRoles();
            LoadUsers();
        }
        public void LoadRoles()
        {
            var roleList = dao.GetSystemRoles(roleSearchKeyword);
            Roles.Clear();
            foreach (var role in roleList)
            {
                Roles.Add(role);
            }
        }
        public void LoadUsers()
        {
            var userList = dao.GetSystemUsers(userSearchKeyword);
            Users.Clear();
            foreach (var user in userList)
            {
                Users.Add(user);
            }
        }
        public bool GrantRoleToUser(bool withAdminOption)
        {
            return dao.GrantRoleToUser(SelectedRole.RoleName, SelectedUser.Username, withAdminOption);
        }
    }
}
