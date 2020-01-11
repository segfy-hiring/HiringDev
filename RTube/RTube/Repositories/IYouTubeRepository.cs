using RTube.Models;
using System.Collections.Generic;

namespace RTube.Repositories
{
    public interface IYouTubeRepository
    {
        bool Exists(YouTubeItem item);
        void Save(YouTubeItem item);
        void Update(YouTubeItem item);

        IEnumerable<YouTubeItem> List();
    }
}