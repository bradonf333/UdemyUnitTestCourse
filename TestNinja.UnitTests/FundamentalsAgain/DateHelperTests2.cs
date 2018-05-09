using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.FundamentalsAgain
{
    [TestFixture]
    [Category("FundamentalsAgain")]
    public class DateHelperTests2
    {
        [Test]
        public void FirstOfNextMonth_WhenMonthIsNot12_ShouldReturnFirstOfTheNextMonthOfTheSameYear()
        {
            var result = DateHelper.FirstOfNextMonth(new DateTime(2018, 5, 8));

            var expectedResult = new DateTime(2018, 6, 1);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FirstOfNextMonth_WhenMonthIs12_ShouldReturnFirstOfTheNextMonthOfTheNextYear()
        {
            var result = DateHelper.FirstOfNextMonth(new DateTime(2018, 12, 8));

            var expectedResult = new DateTime(2019, 1, 1);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
