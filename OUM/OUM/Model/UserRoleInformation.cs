using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class UserRoleInformation
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string GrantOption { get; set; }

        public UserRoleInformation(string name, string role, string grantOption)
        {
            Name = name;
            Role = role;
            GrantOption = grantOption;
        }
    }
}
