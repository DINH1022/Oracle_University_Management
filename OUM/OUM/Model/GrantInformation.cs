using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class GrantInformation
    {
        public string Name { get; set; }
        public string ObjectName { get; set; }
        public string Authority { get; set; }
        public string Columns { get; set; }
        public string GrantOption { get; set; }
        public GrantInformation(string name, string objectName, string authority, string columns, string grantOption)
        {
            Name = name;
            ObjectName = objectName;
            Authority = authority;
            Columns = columns;
            GrantOption = grantOption;
        }
    }
}
