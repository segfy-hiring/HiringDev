using System.Threading.Tasks;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Business.Interfaces
{
    public interface IYoutubeSeachService
    {
        Task<Pagination> SeachAsync(string term, string nextPageToken = "");
    }
}
