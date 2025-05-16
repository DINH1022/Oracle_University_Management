using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Model
{
    public class StudenRegisterdCourseGrade
    {
        public string MAMM { get; set; }
        public string MASV { get; set; }
        public string TENSV { get; set; }
        public decimal DIEMTH { get; set; }
        public decimal DIEMQT { get; set; }
        public decimal DIEMCK { get; set; }
        public decimal DIEMTK { get; set; }

        public StudenRegisterdCourseGrade(string mamm, string masv, decimal diemth, decimal diemqt, decimal diemck, decimal diemtk, string tensv = "")
        {
            MAMM = mamm;
            MASV = masv;
            TENSV = tensv;
            DIEMTH = diemth;
            DIEMQT = diemqt;
            DIEMCK = diemck;
            DIEMTK = diemtk;
        }
    }
}
