using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMW
{
    class Program
    {
        static void Main(string[] args)
        {
            string _firstDateString;
            string _secondDateString;
            string _firstDateBeforeFormatting;
            string _secondDateBeforeFormatting;
            try
            {
                _firstDateBeforeFormatting = Convert.ToDateTime(args[0]).ToString("dd.MM.yyyy");
                _firstDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting)));

                _secondDateBeforeFormatting = Convert.ToDateTime(args[1]).ToString("dd.MM.yyyy");
                _secondDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_secondDateBeforeFormatting)));

                if (DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_firstDateString)) && !DateValidator.CheckIfDaysInMonthsAreCorrect(_firstDateString)
                   || (!DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_firstDateString)) && !DateValidator.CheckIfDaysInMonthsAreCorrect(_firstDateString)))
                {
                    throw new Exception();
                }

                if (DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_secondDateString)) && !DateValidator.CheckIfDaysInMonthsAreCorrect(_secondDateString)
                                       || (!DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_secondDateString)) && !DateValidator.CheckIfDaysInMonthsAreCorrect(_secondDateString)))
                {
                    throw new Exception();
                }

                int differenceBetweenDates = DateTime.Compare(Convert.ToDateTime(_firstDateString), Convert.ToDateTime(_secondDateString));

                Console.WriteLine(DateHandler.WriteDatesInProperlyFormat(_firstDateString, _secondDateString, differenceBetweenDates));
            }

            catch (Exception ex)
            {
                Console.WriteLine("Podana data jest nieprawidłowa. Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
