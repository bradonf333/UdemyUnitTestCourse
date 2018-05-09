using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.FundamentalsAgain
{
    [TestFixture]
    [Category("FundamentalsAgain")]
    public class DemeritPointsCalculatorTests2
    {
        private DemeritPointsCalculator sut;

        [SetUp]
        public void SetUp()
        {
            sut = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_WhenSpeedIsLessThan0OrGreaterThanMaxSpeed_ShouldThrowArgumentOutOfRangeException(int speed)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.CalculateDemeritPoints(speed));
        }

        [Test]
        [TestCase(1)]
        [TestCase(65)]
        public void CalculateDemeritPoints_WhenSpeedIsLessThanOrEqualToSpeedLimit_ShouldReturn0DemeritPoints(int speed)
        {
            var result = sut.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(90, 5)]
        public void CalculateDemeritPoints_WhenSpeedIsGreaterThanSpeedLimit_ShouldCalculateDemeritPoints(int speed, int expectedResult)
        {
            var result = sut.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
