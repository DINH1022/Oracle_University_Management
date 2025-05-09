using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class RegisteredCourse
    {
        public string MAMM { get; set; }
        public string MAHP { get; set; }
        public string TENHP { get; set; }
        public int SOTC { get; set; }
        public decimal DIEMTH { get; set; }
        public decimal DIEMQT { get; set; }
        public decimal DIEMCK { get; set; }
        public decimal DIEMTK { get; set; }

        public RegisteredCourse(string mamm, string mahp, string tenhp, int sotc, decimal diemth, decimal diemqt, decimal diemck, decimal diemtk)
        {
            MAMM = mamm;
            MAHP = mahp;
            TENHP = tenhp;
            SOTC = sotc;
            DIEMTH = diemth;
            DIEMQT = diemqt;
            DIEMCK = diemck;
            DIEMTK = diemtk;
        }
    }
}
