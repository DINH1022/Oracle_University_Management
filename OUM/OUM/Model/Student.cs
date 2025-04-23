using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }
        public string phone { get; set; }
        public string department { get; set; }
        public string status { get; set; }

        public string address { get; set; }

        public Student (string id, string name, string gender, DateTime dob, string phone, string department, string status, string address)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.dob = dob;
            this.phone = phone;
            this.department = department;
            this.status = status;
            this.address = address;
        }
    }
}
