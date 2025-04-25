using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OUM.Model
{
    public class RoleInfo
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public RoleInfo(string roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }
    }
}
