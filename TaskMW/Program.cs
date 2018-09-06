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

            try
            {
                Console.WriteLine("Write first date");
                 var _firstDateBeforeFormatting = Convert.ToDateTime(Console.ReadLine()).ToString("dd.MM.yyyy");
                _firstDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting)));

                Console.WriteLine("Write second date");
                var _secondDateBeforeFormatting = Convert.ToDateTime(Console.ReadLine()).ToString("dd.MM.yyyy");
                _secondDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_secondDateBeforeFormatting)));


                if (DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_firstDateString)) && !DateValidator.CheckIfDaysInMonthIsCorrect(Convert.ToDateTime(_firstDateString)) 
                   || (!DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_firstDateString)) && !DateValidator.CheckIfDaysInMonthIsCorrect(Convert.ToDateTime(_firstDateString))))
                {
                    throw new Exception();
                }

                if (DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_secondDateString)) && !DateValidator.CheckIfDaysInMonthIsCorrect(Convert.ToDateTime(_secondDateString))
                                       || (!DateValidator.CheckIfYearIsLeap(Convert.ToDateTime(_secondDateString)) && !DateValidator.CheckIfDaysInMonthIsCorrect(Convert.ToDateTime(_secondDateString))))
                {
                    throw new Exception();
                }

                int differenceBetweenDates = DateTime.Compare(Convert.ToDateTime(_firstDateString), Convert.ToDateTime(_secondDateString));

                if (differenceBetweenDates < 0)
                {
                    Console.WriteLine(_firstDateString + " - " + _secondDateString);
                }
                else if (differenceBetweenDates == 0)
                {
                    if (DateValidator.CheckIfFirstMonthIsEqualToSecond(_firstDateString, _secondDateString))
                    {
                        Console.WriteLine(_firstDateString.Substring(0, 2) + " - " + _secondDateString);
                    }
                    else
                    {
                        Console.WriteLine(_firstDateString + " - " + _secondDateString);
                    }
                }
                else
                    Console.WriteLine(_secondDateString + " - " + _firstDateString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Podana data jest nieprawidłowa. Błąd: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
