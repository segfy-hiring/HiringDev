using FakeTube.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeTube.Infrastructure.Services.Youtube
{
    public interface IYoutubeApiService
    {
        Task<YoutubeSearchResponse> Search(string term, int maxResults = 15, YoutubeItemType? type = null);
        Task<IEnumerable<YoutubeItem>> GetHistory(string term = null, int maxResults = 15, YoutubeItemType? type = null);
    }
}
