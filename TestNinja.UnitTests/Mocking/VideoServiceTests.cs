using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        Mock<IFileReader> mockFileReader;
        Mock<IVideoProcessor> mockVideoProcessor;
        VideoService sut;

        [SetUp]
        public void SetUp()
        {
            mockFileReader = new Mock<IFileReader>();
            mockVideoProcessor = new Mock<IVideoProcessor>();
            sut = new VideoService(mockFileReader.Object, mockVideoProcessor.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ShouldReturnError()
        {
            mockFileReader.Setup(mfr => mfr.Read("video.txt")).Returns("");

            var result = sut.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_2Videos_Should2Videos()
        {
            // Need a Mock VideoContext
            var videos = new List<Video>();
            videos.Add(new Video { Id = 1, Title = "Avengers", IsProcessed = true });
            videos.Add(new Video { Id = 20, Title = "Avengers 2", IsProcessed = true });

            mockVideoProcessor.Setup(mvp => mvp.GetVideos()).Returns(videos);

            var result = sut.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,20"));
        }
    }
}
