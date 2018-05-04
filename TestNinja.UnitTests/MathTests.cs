﻿using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        Math math;

        [SetUp]
        public void SetUp()
        {
            math = new Math();
        }


        [Test]
        [Ignore("Reason why we ignored the test.")]
        public void Add_ShouldAddTwoNumbers_ShouldReturnTrue()
        {
            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ShouldReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}