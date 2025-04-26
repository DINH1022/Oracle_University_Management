using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class UserSystemInformation:INotifyPropertyChanged
    {
        public string Username { get; set; }
        public string AccountStatus { get; set; }
        public DateTime Created { get; set; }

        public UserSystemInformation(string username,string status, DateTime created) { 
            this.Username = username;
            this.AccountStatus = status;
            this.Created = created;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
