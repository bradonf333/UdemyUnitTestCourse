using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoProcessor _videoProcessor { get; set; }

        public VideoService(IFileReader fileReader = null, 
                            IVideoProcessor videoProcessor = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _videoProcessor = videoProcessor ?? new VideoProcessor();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
            {
                return "Error parsing the video.";
            }

            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            List<int> videoIds = new List<int>();
            var videos = _videoProcessor.GetVideos();
            foreach (var v in videos)
            {
                videoIds.Add(v.Id);
            }

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}