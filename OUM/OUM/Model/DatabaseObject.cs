using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class DatabaseObject :INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string ObjectType { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public DatabaseObject(string name,string type,DateTime created, string status) { 
            this.Name = name;
            this.ObjectType = type;
            this.Created = created;
            this.Status = status;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
