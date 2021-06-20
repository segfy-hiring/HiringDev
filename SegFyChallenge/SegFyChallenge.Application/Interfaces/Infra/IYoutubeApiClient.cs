using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Application.Dto;

namespace SegFyChallenge.Application.Interfaces.Infra
{
    public enum SearchType
    {
        Video,
        Channel,
        Both
    }

    public interface IYoutubeApiClient
    {
        Task<List<YoutubeItem>> Search(string content, int maxResults, SearchType searchType);
    }
}