using RTube.Models;

namespace RTube.Repositories
{
    public interface IYouTubeRepository
    {
        bool Exists(YouTubeItem item);
        void Save(YouTubeItem item);
        void Update(YouTubeItem item);
    }
}