using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMW
{
    class DateValidator
    {
        public static bool CheckIfYearIsLeap(DateTime date)
        {
            return DateTime.IsLeapYear(date.Year);
        }

        public static bool CheckIfDaysInMonthsAreCorrect(DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

            if ((DateTime.DaysInMonth(date.Year, date.Month) < date.Day))
            {
                return false;
            }
            else if (CheckIfYearIsLeap(date) && ((date.Month == 2) && (daysInMonth < date.Day)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckIfFirstMonthIsEqualToSecond(string firstDate, string secondDate)
        {
            if(Convert.ToDateTime(firstDate).Month == Convert.ToDateTime(secondDate).Month)
            {
                return true;
            }
            return false;
        }
    }
}
