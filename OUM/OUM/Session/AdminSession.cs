using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Session
{
    public static class AdminSession
    {
        public static string Username { get; set; } = "";
        public static string Password { get; set; } = "";
        public static void Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public static void Logout()
        {
            Username = "";
            Password = "";
        }
    }
   
}
