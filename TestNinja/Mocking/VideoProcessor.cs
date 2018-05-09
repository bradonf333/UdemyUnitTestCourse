using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoProcessor
    {
        List<Video> GetVideos();
    }

    public class VideoProcessor : IVideoProcessor
    {
        public List<Video> GetVideos()
        {
            var videos = new List<Video>();
            using (var context = new VideoContext())
            {
                videos =
                    (from video in context.Videos
                     where !video.IsProcessed
                     select video).ToList();

                return videos;
            }

        }
    }
}
