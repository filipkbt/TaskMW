using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMW;

namespace TaskMW.Tests
{
    [TestFixture]
    public class TaskMWTests
    {
        [TestCase("11-12-1994")]
        [TestCase("1.12.1994")]
        [TestCase("1/2/1994")]
        [Test]
        public void ConvertToProperlyCultureFormatTest(string date)
        {
           var _firstDateBeforeFormatting = Convert.ToDateTime(date).ToString("dd.MM.yyyy");
           var _firstDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting)));
           Assert.AreEqual(_firstDateString, DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting))));
        }

        [TestCase("11-12-1994")]
        [TestCase("1.12.1994")]
        [TestCase("1/2/1994")]
        [TestCase("1/2/124")]
        [TestCase("11/2/124")]
        [Test]
        public void AddZeroBeforeNumberIfNeededTest(DateTime date)
        {
            string formattedDate = DateHandler.AddZeroBeforeNumberIfNeeded(date);
            Assert.AreEqual(formattedDate, DateHandler.AddZeroBeforeNumberIfNeeded(date));
        }

        [TestCase("11/2/2016")]
        [TestCase("11/2/2020")]
        [TestCase("11.2.2020")]
        [TestCase("11-2-2020")]
        [Test]
        public void CheckIfYearIsLeapShouldReturnTrue(DateTime date)
        {
            Assert.IsTrue(DateValidator.CheckIfYearIsLeap(date));
        }

        [TestCase("11/2/2015")]
        [TestCase("11/2/2013")]
        [TestCase("11.2.2013")]
        [TestCase("11-2-2013")]
        [Test]
        public void CheckIfYearIsLeapShouldReturnFalse(DateTime date)
        {
            Assert.AreEqual(DateValidator.CheckIfYearIsLeap(date), false);
        }

        [TestCase("11/2/2015")]
        [TestCase("11/2/2013")]
        [TestCase("11.2.2013")]
        [TestCase("11-2-2013")]
        [Test]
        public void CheckIfDaysInMonthsAreCorrectShouldReturnTrue(string date)
        {
            Assert.IsTrue(DateValidator.CheckIfDaysInMonthsAreCorrect(date));
        }

        [TestCase("42/3/1995")]
        [TestCase("29/2/2015")]
        [TestCase("29.2.2017")]
        [TestCase("42.2.2018")]
        [Test]
        public void CheckIfDaysInMonthsAreCorrectShouldReturnFalse(string date)
        {
          
            Assert.AreEqual(false, DateValidator.CheckIfDaysInMonthsAreCorrect(date));
        }

        [TestCase("11/2/2015", "11/2/2012")] 
        [TestCase("11/2/2013", "12/2/2013")]
        [TestCase("11.2.2013", "2-2-2013")]
        [Test]
        public void CheckIfFirstMonthIsEqualToSecondReturnTrue(string firstDate, string secondDate)
        {
            var _firstDateBeforeFormatting = Convert.ToDateTime(firstDate).ToString("dd.MM.yyyy");
            var _firstDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting)));

            var _secondDateBeforeFormatting = Convert.ToDateTime(secondDate).ToString("dd.MM.yyyy");
            var _secondDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_secondDateBeforeFormatting)));

            Assert.IsTrue(DateValidator.CheckIfFirstMonthIsEqualToSecond(_firstDateString, _secondDateString));
        }

        [TestCase("11/2/2015", "11/6/2012")]
        [TestCase("11/2/2013", "2-1-2013")]
        [TestCase("11-2-2013", "11-7-2013")]
        [Test]
        public void CheckIfFirstMonthIsEqualToSecondShouldReturnFalse(string firstDate, string secondDate)
        {
           var _firstDateBeforeFormatting = Convert.ToDateTime(firstDate).ToString("dd.MM.yyyy");
           var _firstDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting)));

           var _secondDateBeforeFormatting = Convert.ToDateTime(secondDate).ToString("dd.MM.yyyy");
           var _secondDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_secondDateBeforeFormatting)));

            Assert.AreEqual(false, DateValidator.CheckIfFirstMonthIsEqualToSecond(_firstDateString, _secondDateString));
        }

        [TestCase("11/2/2015", "11/6/2015")]
        [TestCase("11/2/2013", "2-1-2013")]
        [TestCase("11-2-2014", "11-7-2014")]
        [Test]
        public void CheckIfFirstYearIsEqualToSecondShouldReturnTrue(string firstDate, string secondDate)
        {
            var _firstDateBeforeFormatting = Convert.ToDateTime(firstDate).ToString("dd.MM.yyyy");
            var _firstDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting)));

            var _secondDateBeforeFormatting = Convert.ToDateTime(secondDate).ToString("dd.MM.yyyy");
            var _secondDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_secondDateBeforeFormatting)));

            Assert.IsTrue(DateValidator.CheckIfFirstYearIsEqualToSecond(_firstDateString, _secondDateString));
        }

        [TestCase("11/2/2015", "11/6/2012")]
        [TestCase("11/2/2013", "2-1-2011")]
        [TestCase("11-2-2013", "11-7-2018")]
        [Test]
        public void CheckIfFirstYearIsEqualToSecondShouldReturnFalse(string firstDate, string secondDate)
        {
            var _firstDateBeforeFormatting = Convert.ToDateTime(firstDate).ToString("dd.MM.yyyy");
            var _firstDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_firstDateBeforeFormatting)));

            var _secondDateBeforeFormatting = Convert.ToDateTime(secondDate).ToString("dd.MM.yyyy");
            var _secondDateString = DateHandler.ConvertToProperlyCultureFormat(DateHandler.AddZeroBeforeNumberIfNeeded(Convert.ToDateTime(_secondDateBeforeFormatting)));

            Assert.AreEqual(false, DateValidator.CheckIfFirstYearIsEqualToSecond(_firstDateString, _secondDateString));
        }

    }
}
