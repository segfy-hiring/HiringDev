using Google.Apis.YouTube.v3.Data;
using System.Threading.Tasks;

namespace SGTubeMVC.Youtube
{
    public interface ISearch
    {
        Task<SearchListResponse> YoutubeApi_Search(string termo);
    }
}
