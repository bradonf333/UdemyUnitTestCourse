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
        private IVideoRepository _videoRepo { get; set; }

        public VideoService(IFileReader fileReader = null, 
                            IVideoRepository videoRepo = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _videoRepo = videoRepo ?? new VideoRepository();
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

            var videos = _videoRepo.GetUnprocessedVideos();

            foreach (var v in videos)
            {
                if (!v.IsProcessed)
                {
                    videoIds.Add(v.Id);
                }
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