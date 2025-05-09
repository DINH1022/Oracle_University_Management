﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class Employee
    {
        public string Username { get; set; }
        public DateTime CreatedTime { get; set; }
        public string manld {  get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }
        public decimal salary {  get; set; }
        public decimal allowance { get; set; }
        public string phone { get; set; }
        public string madv {  get; set; }
        public string role { get; set; }
        

        public Employee(string manld, string name, string gender, DateTime dob, decimal salary, decimal allowance, string phone, string madv, string role)
        {
            this.manld = manld;
            this.name = name;
            this.gender = gender;
            this.dob = dob;
            this.salary = salary;
            this.allowance = allowance;
            this.phone = phone;
            this.madv = madv;
            this.role = role;
        }
    }
}
