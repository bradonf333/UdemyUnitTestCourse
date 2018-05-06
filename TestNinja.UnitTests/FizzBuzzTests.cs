using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void GetOutput_WhenCalled_ReturnsCorrectFizzBuzzWord(int input, string fizzbuzz)
        {
            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo(fizzbuzz));
        }

        [Test]
        public void GetOutput_NumberDivisibleBy3And5_ShouldReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleBy3Only_ShouldReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_NumberDivisibleBy5Only_ShouldReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_NumberNotDivisibleBy3Or5_ShouldReturnNumber()
        {
            var result = FizzBuzz.GetOutput(1);

            Assert.That(result, Is.EqualTo("1"));
        }
    }
}
