using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMW
{
    public class DateValidator
    {
        public static bool CheckIfYearIsLeap(DateTime date)
        {
            return DateTime.IsLeapYear(date.Year);
        }

        public static bool CheckIfDaysInMonthsAreCorrect(string date)
        {

            try
            {
                var _dateBeforeFormatting = Convert.ToDateTime(date).ToString("dd.MM.yyyy");
                var _dateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_dateBeforeFormatting)));
                DateTime _dateConvertedToDateTime = Convert.ToDateTime(_dateString);
                int daysInMonth = DateTime.DaysInMonth(Convert.ToDateTime(_dateString).Year, Convert.ToDateTime(_dateString).Month);

                if (daysInMonth < _dateConvertedToDateTime.Day)
                {
                    return false;
                }
                else if (CheckIfYearIsLeap(_dateConvertedToDateTime) && ((_dateConvertedToDateTime.Month == 2) && (daysInMonth < _dateConvertedToDateTime.Day)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CheckIfFirstMonthIsEqualToSecond(string firstDate, string secondDate)
        {
            try
            {
                var firstDateFormatted = Convert.ToDateTime(firstDate).ToString("dd.MM.yyyy");
                var secondDateFormatted = Convert.ToDateTime(secondDate).ToString("dd.MM.yyyy");

                if (Convert.ToDateTime(firstDateFormatted).Month == Convert.ToDateTime(secondDateFormatted).Month)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CheckIfFirstYearIsEqualToSecond(string firstDate, string secondDate)
        {
            try
            {
                var firstDateFormatted = Convert.ToDateTime(firstDate).ToString("dd.MM.yyyy");
                var secondDateFormatted = Convert.ToDateTime(secondDate).ToString("dd.MM.yyyy");

                if (Convert.ToDateTime(firstDateFormatted).Year == Convert.ToDateTime(secondDateFormatted).Year)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
