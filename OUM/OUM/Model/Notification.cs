using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class Notification
    {
        public int id { get; set; }

        public string content { get; set; }

        public DateTime created_date { get; set; }

        public string label { get; set; }

        public Notification(int id, string content, DateTime created_date, string label)
        {
            this.id = id;
            this.content = content ?? string.Empty;
            this.created_date = created_date;
            this.label = label ?? string.Empty;
        }

    }
}
