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
            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;
                var formattedDate = DateTime.ParseExact(date, "dd.MM.yyyy", culture).ToString("dd.MM.yyyy");

                return formattedDate;
            }
            catch(Exception)
            {
                return "";
            }

        }

        public static string AddZeroBeforeNumberIfNeeded(DateTime date)
        {
            try
            {
                string day = date.Day.ToString().PadLeft(2, '0');
                string month = date.Month.ToString().PadLeft(2, '0');
                string year = date.Year.ToString().PadLeft(4, '0');

                return day + "." + month + "." + year;
            }
            catch(Exception)
            {
                return "";
            }
        }

        public static string WriteDatesInProperlyFormat(string firstDate, string secondDate, int differenceBetweenDates)
        {
            try
            {
                if (differenceBetweenDates < 0)
                {
                    if (DateValidator.CheckIfFirstYearIsEqualToSecond(firstDate, secondDate))
                    {
                        if (DateValidator.CheckIfFirstMonthIsEqualToSecond(firstDate, secondDate))
                        {
                            return string.Format(firstDate.Substring(0, 2) + " - " + secondDate);
                        }
                        else
                        {
                            return string.Format(firstDate.Substring(0, 5) + " - " + secondDate);
                        }
                    }
                    else
                    {
                        return string.Format(firstDate + " - " + secondDate);
                    }
                }

                else if (differenceBetweenDates == 0)
                {
                    if (DateValidator.CheckIfFirstYearIsEqualToSecond(firstDate, secondDate))
                    {
                        if (DateValidator.CheckIfFirstMonthIsEqualToSecond(firstDate, secondDate))
                        {
                            return string.Format(firstDate.Substring(0, 2) + " - " + secondDate);
                        }
                        else
                        {
                            return string.Format(firstDate.Substring(0, 5) + " - " + secondDate);
                        }
                    }
                    else
                    {
                        return string.Format(firstDate + " - " + secondDate);
                    }
                }
                else
                {
                    if (DateValidator.CheckIfFirstYearIsEqualToSecond(secondDate, firstDate))
                    {
                        if (DateValidator.CheckIfFirstMonthIsEqualToSecond(secondDate, firstDate))
                        {
                            return string.Format(secondDate.Substring(0,2) + " - " + firstDate);
                        }
                        else
                        {
                            return string.Format(secondDate.Substring(0, 5) + " - " + firstDate);
                        }
                    }
                    else
                    {
                        return string.Format(secondDate+ " - " + firstDate);
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
