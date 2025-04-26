using OUM.Model;
using OUM.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.ViewModel
{
    public class GrantRoleViewModel:INotifyPropertyChanged
    {
        private readonly OracleDAO dao;
        public ObservableCollection<RoleSystemInformation> Roles { get; set; }
        public ObservableCollection<DatabaseObject> DatabaseObjects { get; set; }

        public List<string> ObjectTypes { get; set; } = new List<string> { "ALL", "TABLE", "VIEW", "FUNCTION", "PROCEDURE" };
        public List<string> Privileges { get; set; }

        public string SelectedObjectType { get; set; } = "ALL";
        public string SelectedPrivilege { get; set; } = "SELECT";

        public RoleSystemInformation SelectedRole { get; set; } = null;
        public DatabaseObject SelectedObject { get; set; } = null;

        public string searchKeyword { get; set; }
        public GrantRoleViewModel()
        {
            dao = new OracleDAO();
            Roles = new ObservableCollection<RoleSystemInformation>();
            DatabaseObjects = new ObservableCollection<DatabaseObject>();
            LoadRoles();
            LoadDatabaseObject();
        }
        public void LoadRoles()
        {
            var roleList = dao.GetSystemRoles(searchKeyword);
            Roles.Clear();
            foreach (var role in roleList)
            {
                Roles.Add(role);
            }
        }
        public void LoadDatabaseObject()
        {
            DatabaseObjects.Clear();
            var objects = dao.GetDatabaseObject(SelectedObjectType);
            foreach (var obj in objects)
            {
                DatabaseObjects.Add(obj);
            }
        }
        public List<string> GetColumsForObject(string objectName, string objectType)
        {
            return dao.GetColumsForObject(objectName, objectType);
        }

        public bool GrantPrivilegeToRole(List<string>? selectedColumns)
        {
            return dao.GrantPrivilege(SelectedRole.RoleName, SelectedObject.Name, SelectedPrivilege, selectedColumns, false);
        }
        public void UpdatePrivileges(string objectType)
        {
            if (objectType == "PROCEDURE" || objectType == "FUNCTION")
            {
                Privileges = new List<string> { "EXECUTE" };
            }
            else
            {
                Privileges = new List<string> { "SELECT", "INSERT", "UPDATE", "DELETE" };
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
