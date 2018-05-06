using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_ErrorPassed_ShouldChangeLastErrorProperty()
        {
            var sut = new ErrorLogger();

            sut.Log("a");

            Assert.That(sut.LastError, Is.EqualTo("a"));
        }
    }
}
