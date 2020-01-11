using RTube.Models.Result;
using System.Threading.Tasks;

namespace RTube.Services
{
    public interface IYouTubeService
    {
        Task<YouTubeResult> Search(string query, string pageToken = null);
    }
}