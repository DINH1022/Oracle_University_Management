using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class RoleSystemInformation : INotifyPropertyChanged
    {
        public string RoleName { get; set; }
        public string Common {  get; set; }
        public string Inherited { get; set; }
        public string AuthenticationType { get; set; }
        public RoleSystemInformation(string RoleName,string Common, string Inherited, string AuthenticationType )
        {
            this.RoleName = RoleName;
            this.Common = Common;
            this.Inherited = Inherited;
            this.AuthenticationType = AuthenticationType;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
