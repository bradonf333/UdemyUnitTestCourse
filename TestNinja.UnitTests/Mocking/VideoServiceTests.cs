using System;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        Mock<IFileReader> mockFileReader;
        VideoService sut;

        [SetUp]
        public void SetUp()
        {
            mockFileReader = new Mock<IFileReader>();
            sut = new VideoService(mockFileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ShouldReturnError()
        {
            mockFileReader.Setup(mfr => mfr.Read("video.txt")).Returns("");

            var result = sut.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
