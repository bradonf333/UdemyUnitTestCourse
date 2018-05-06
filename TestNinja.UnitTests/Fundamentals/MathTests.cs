using NUnit.Framework;
using System.Linq;
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
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ShouldReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitEquals1_ShouldNotBeEmpty()
        {
            var result = math.GetOddNumbers(1);

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetOddNumbers_LimitEquals10_ShouldReturn5Numbers()
        {
            var result = math.GetOddNumbers(10);

            Assert.That(result.Count(), Is.EqualTo(5));
        }

        [Test]
        public void GetOddNumbers_LimitEquals10_ShouldContain1_3_5_7_9()
        {
            var result = math.GetOddNumbers(10);

            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Does.Contain(9));
        }

        [Test]
        public void GetOddNumbers_LimitEquals10_ShouldReturnTrue()
        {
            var result = math.GetOddNumbers(10);

            var expectedNumbers = new[]
            {
                1,3,5,7,9
            };

            Assert.That(result, Is.EquivalentTo(expectedNumbers));

            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
