using RTube.Models;
using System.Collections.Generic;
using System.Linq;

namespace RTube.Repositories
{
    public interface IYouTubeRepository
    {
        bool Exists(YouTubeItem item);
        void Save(YouTubeItem item);
        void Update(YouTubeItem item);

        IQueryable<YouTubeItem> List();
    }
}