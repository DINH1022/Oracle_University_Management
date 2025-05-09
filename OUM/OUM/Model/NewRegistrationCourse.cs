using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class NewRegistrationCourse
    {
        public string MAMM {  get; set; } 
        public string MAHP { get; set; }
        public string TENHP { get; set; }
        public int SOTC { get; set; }
        public int STTH { get; set; }
        public int STLT { get; set; }
        public NewRegistrationCourse(string mamm, string mahp, string tenhp, int sotc, int stlt, int stth)
        {
            MAMM = mamm;
            MAHP = mahp;
            TENHP = tenhp;
            SOTC = sotc;
            STTH = stth;
            STLT = stlt;
        }
    }
}
