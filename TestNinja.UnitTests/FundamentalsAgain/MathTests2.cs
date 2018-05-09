using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.UnitTests.FundamentalsAgain
{
    [TestFixture]
    [Category("FundamentalsAgain")]
    public class MathTests2
    {
        private Fundamentals.Math sut;

        [SetUp]
        public void SetUp()
        {
            sut = new Fundamentals.Math();
        }

        [Test]
        public void Add_WhenCalled_ShouldReturnSumOfBothNumbers()
        {
            var result = sut.Add(1, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_WhenOneNumberIsHigher_ShouldReturnHighestOfBothNumbers()
        {
            var result = sut.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_WhenNumbersAreEqual_ShouldReturnNumber()
        {
            var result = sut.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetOddNumbers_LimitEquals0_ShouldReturnBlankList()
        {
            var result = sut.GetOddNumbers(0);
            List<int> expectedResult = new List<int>();

            Assert.That(result, Is.EquivalentTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitEquals1_ShouldReturnListOf1()
        {
            var result = sut.GetOddNumbers(1);
            List<int> expectedResult = new List<int>();
            expectedResult.Add(1);

            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
        [Test]
        public void GetOddNumbers_LimitEquals100_ShouldReturnListWithCountOf50()
        {
            var result = sut.GetOddNumbers(100);

            Assert.That(result.Count(), Is.EqualTo(50));
        }

    }
}
