using System.Threading.Tasks;

namespace YoutubeTree.Application
{
    public interface IYoutubeSearchService
    {
        Task<PagedSearchResponse<SubscriptionViewModel>> Search(string term, string nextPageToken);
    }
}