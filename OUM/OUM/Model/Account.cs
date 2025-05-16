using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class Account
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }
        public decimal Salary { get; set; }
        public decimal Allowance { get; set; }
        public string Role { get; set; }

        // Constructor cần phải khớp với những tham số được truyền vào
        public Account(string userId, string name, string gender, string phone, string department, string status, string address, DateTime dob, decimal salary = 0, decimal allowance = 0, string role = "")
        {
            UserId = userId;
            Name = name;
            Gender = gender;
            Phone = phone;
            Department = department;
            Status = status;
            Address = address;
            Dob = dob;
            Salary = salary;
            Allowance = allowance;
            Role = role;
        }
    }

}
