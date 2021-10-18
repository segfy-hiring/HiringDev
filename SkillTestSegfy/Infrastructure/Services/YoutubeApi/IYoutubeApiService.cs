using System.Threading.Tasks;

namespace SkillTestSegfy.Infrastructure.Services.YoutubeApi
{
    public interface IYoutubeApiService
    {
        Task<YoutubeSearchResponse> Search(string term, long maxResults = 15, YoutubeItemType? type = null);
    }
}
