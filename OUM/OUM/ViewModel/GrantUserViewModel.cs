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
    public class GrantUserViewModel:INotifyPropertyChanged
    {
        private readonly OracleDAO dao;
        public ObservableCollection<UserSystemInformation> Users { get; set; }
        public ObservableCollection<DatabaseObject> DatabaseObjects { get; set; }

        public List<string> ObjectTypes { get; set; } = new List<string> { "ALL", "TABLE", "VIEW", "FUNCTION", "PROCEDURE" };
        public List<string> Privileges { get; set; } 

        public string SelectedObjectType { get; set; } = "ALL";
        public string SelectedPrivilege { get; set; } = "SELECT";

        public UserSystemInformation SelectedUser { get; set; } = null;
        public DatabaseObject SelectedObject { get; set; } = null;

        public GrantUserViewModel()
        {
            dao = new OracleDAO();
            Users = new ObservableCollection<UserSystemInformation>();
            DatabaseObjects = new ObservableCollection<DatabaseObject>();
            LoadUsers();
            LoadDatabaseObject();
        }
        public void LoadUsers()
        {
            var userList = dao.GetSystemUsers("");
            Users.Clear();
            foreach (var user in userList)
            {
                Users.Add(user);
            }
        }
        public void LoadDatabaseObject()
        {
            DatabaseObjects.Clear();
            var objects = dao.GetDatabaseObject(SelectedObjectType);
            foreach(var obj  in objects)
            {
                DatabaseObjects.Add(obj);
            }
        }
        public List<string> GetColumsForObject(string objectName,string objectType)
        {
            return dao.GetColumsForObject(objectName, objectType);
        }
        public bool GrantPrivilegeToUser(List<string>? selectedColumns,bool withGrantOption)
        {
            return dao.GrantPrivilege(SelectedUser.Username, SelectedObject.Name, SelectedPrivilege, selectedColumns, withGrantOption);
        }
        public void UpdatePrivileges(string objectType)
        {
            if(objectType == "PROCEDURE" || objectType == "FUNCTION")
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
