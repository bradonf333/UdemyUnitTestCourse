using NUnit.Framework;
using TestNinja.Fundamentals;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        DemeritPointsCalculator sut;

        [SetUp]
        public void SetUp()
        {
            sut = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_SpeedLessThan0_ShouldThrowOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.CalculateDemeritPoints(-2));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedGreaterThanMaxSpeed_ShouldThrowOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.CalculateDemeritPoints(600));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(60, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedLessOrEqualToSpeedLimit_ShouldReturn0(int speed, int expectedResult)
        {
            var result = sut.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedEquals70_ShouldReturn1()
        {
            var result = sut.CalculateDemeritPoints(70);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedEquals90_ShouldReturn5()
        {
            var result = sut.CalculateDemeritPoints(90);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
