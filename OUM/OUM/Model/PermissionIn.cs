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


       public class PermissionIn
        {
            public string Name { get; set; }       
            public string ObjectName { get; set; }  // Tên đối tượng (bảng, view, hoặc procedure)
            public string Authority { get; set; }   // Quyền (SELECT, INSERT, UPDATE, DELETE, ...)
            public string Columns { get; set; }     // Cột có quyền
            public string GrantOption { get; set; } // Quyền cấp lại (WITH GRANT OPTION)
            public string Operation { get; set; }
            public string Role { get; set; }

        public PermissionIn(string name = "", string objectName = "", string authority = "", string columns = "", string grantOption = "", string operation ="", string role ="")
        {
            Name = name;
            ObjectName = objectName;
            Authority = authority;
            Columns = columns;
            GrantOption = grantOption;
            Operation = operation;
            Role = role;
        }


    }
}
