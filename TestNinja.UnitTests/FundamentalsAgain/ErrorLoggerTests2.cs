using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.FundamentalsAgain
{
    [TestFixture]
    [Category("FundamentalsAgain")]
    public class ErrorLoggerTests2
    {
        private ErrorLogger sut;

        [SetUp]
        public void SetUp()
        {
            sut = new ErrorLogger();
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Log_WhenErrorIsNullOrWhitespace_ShouldThrowArgumentNullException(string error)
        {
            Assert.Throws<ArgumentNullException>(() => sut.Log(error));
        }

        [Test]
        public void Log_ValidErrorMessage_ShouldSetLastErrorProperty()
        {
            sut.Log("error");

            var result = sut.LastError;

            Assert.That(result, Is.EqualTo("error"));
        }

        [Test]
        public void Log_ValidErrorMessage_ShouldRaiseErrorLoggedEvent()
        {
            var result = Guid.Empty;
            sut.ErrorLogged += (sender, args) => { result = args; };

            sut.Log("error");

            Assert.That(result, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
