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
        Mock<IVideoRepository> mockVideoRepo;
        List<Video> videos;
        VideoService sut;

        [SetUp]
        public void SetUp()
        {
            mockFileReader = new Mock<IFileReader>();
            mockVideoRepo = new Mock<IVideoRepository>();
            videos = new List<Video>();
            sut = new VideoService(mockFileReader.Object, mockVideoRepo.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ShouldReturnError()
        {
            mockFileReader.Setup(mfr => mfr.Read("video.txt")).Returns("");

            var result = sut.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_NoVideos_ShouldReturnNoVideoIds()
        {
            mockVideoRepo.Setup(mvp => mvp.GetUnprocessedVideos()).Returns(videos);

            var result = sut.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_2UnprocessedVideos_ShouldReturn2VideoIds()
        {
            videos.Add(new Video { Id = 1, Title = "Avengers", IsProcessed = false });
            videos.Add(new Video { Id = 20, Title = "Avengers 2", IsProcessed = false });
            mockVideoRepo.Setup(mvp => mvp.GetUnprocessedVideos()).Returns(videos);

            var result = sut.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,20"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_1Processed1UnprocessedVideos_ShouldReturn1VideoId()
        {
            videos.Add(new Video { Id = 1, Title = "Avengers", IsProcessed = false });
            videos.Add(new Video { Id = 20, Title = "Avengers 2", IsProcessed = true });
            mockVideoRepo.Setup(mvp => mvp.GetUnprocessedVideos()).Returns(videos);

            var result = sut.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1"));
        }
    }
}
