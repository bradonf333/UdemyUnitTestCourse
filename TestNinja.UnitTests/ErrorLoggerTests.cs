using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        ErrorLogger sut;

        [SetUp]
        public void SetUp()
        {
            sut = new ErrorLogger();
        }

        [Test]
        public void Log_ErrorPassed_ShouldChangeLastErrorProperty()
        {
            sut.Log("a");

            Assert.That(sut.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_NullOrWhiteSpaceErrorPassed_ShouldThrowArgumentNullException(string error)
        {
            Assert.That(() => sut.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_ShouldRaiseErrorLoggedEvent()
        {
            var result = Guid.Empty;
            sut.ErrorLogged += (sender, args) => { result = args; };

            sut.Log("a");

            Assert.That(result, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
