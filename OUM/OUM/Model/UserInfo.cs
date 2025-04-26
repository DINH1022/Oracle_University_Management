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
    public class UserInfo
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }

        public UserInfo(string userId, string userName, string userType)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.UserType = userType;
        }

        public override string ToString()
        {
            return UserId;
        }
    }
}
