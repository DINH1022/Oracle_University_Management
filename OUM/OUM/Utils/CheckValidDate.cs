using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUM.Utils
{
    public class CheckValidDate
    {
        public bool IsWithinRegistrationPeriod()
        {
            DateTime today = DateTime.Now;
            int currentMonth = today.Month;
            DateTime semesterStarDate;
            if(currentMonth >=9)
            {
                semesterStarDate = new DateTime(today.Year, 9, 1);
            } 
            else if(currentMonth >= 5)
            {
                semesterStarDate = new DateTime(today.Year, 5, 1);
            }
            else
            {
                semesterStarDate = new DateTime(today.Year, 1, 1);
            }
            TimeSpan elapsed = today - semesterStarDate;
            return true;
        }
    }
}
