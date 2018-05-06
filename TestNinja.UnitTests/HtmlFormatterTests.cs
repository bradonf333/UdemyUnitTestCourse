using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_EncloseTheStringWithStrongElement_ShouldReturnTrue()
        {
            var htmlFormatter = new HtmlFormatter();

            var result = htmlFormatter.FormatAsBold("This is bold text!");

            Assert.That(result, Is.EqualTo("<strong>This is bold text!</strong>").IgnoreCase);
        }
    }
}
