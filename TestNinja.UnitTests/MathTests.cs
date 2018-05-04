using NUnit.Framework;
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
        public void Add_ShouldAddTwoNumbers_ShouldReturnTrue()
        {
            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstNumberIsGreater_ShouldReturnTrue()
        {
            var result = math.Max(3, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_SecondNumberIsGreater_ShouldReturnTrue()
        {
            var result = math.Max(2, 3);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_BothNumbersAreEqual_ShouldReturnTrue()
        {
            var result = math.Max(2, 2);

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
