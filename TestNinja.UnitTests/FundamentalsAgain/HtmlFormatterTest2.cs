using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.FundamentalsAgain
{
    [TestFixture]
    [Category("FundamentalsAgain")]
    public class HtmlFormatterTest2
    {
        [Test]
        public void FormatAsBold_ShouldReturnStringBeginsWithStrongTag()
        {
            var sut = new HtmlFormatter();

            var result = sut.FormatAsBold("hello");

            Assert.That(result, Does.StartWith("<strong>"));
        }

        [Test]
        public void FormatAsBold_ShouldReturnStringEndsWithStrongTag()
        {
            var sut = new HtmlFormatter();

            var result = sut.FormatAsBold("hello");

            Assert.That(result, Does.EndWith("</strong>"));
        }
    }
}
