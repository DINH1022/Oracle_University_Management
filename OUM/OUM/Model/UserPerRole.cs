using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class UserPerRole
    {
        public string roleName { get; set; }
        public int userCount { get; set; }

        public UserPerRole() { }

        public UserPerRole(string roleName, int userCount) {
            this.roleName = roleName;
            this.userCount = userCount;
        }
    }
}
