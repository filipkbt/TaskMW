using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMW
{
    public static class DateHandler
    {
        public static string ConvertToProperlyCultureFormat(string date)
        {           
            CultureInfo culture = CultureInfo.CurrentCulture;
            var formattedDate = DateTime.ParseExact(date, "dd.MM.yyyy", culture).ToString("dd.MM.yyyy");
            
            return formattedDate;
        }

        public static string AddZeroBeforeNumberIfNeeded(DateTime date)
        {
            string day = date.Day.ToString().PadLeft(2, '0');
            string month = date.Month.ToString().PadLeft(2, '0');
            string year = date.Year.ToString().PadLeft(4, '0');

            return day + "." + month + "." + year;
        }
    }
}
