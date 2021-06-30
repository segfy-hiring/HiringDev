using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeApiConsumerApp.Models;

namespace YoutubeApiConsumerApp.Data.Repository.Interfaces
{
    public interface IYoutubeRepository : IDisposable
    {
        SearchResponseModel GetAllVideosAndChannels();
        Task<int> SaveSearchedVideos(YoutubeVideoModel youtubeVideoViewModel);
        Task<int> SaveSearchedChannels(YoutubeChannelModel youtubeChannelViewModel);
        Boolean IsVideoAlreadySaved(string Id);
        Boolean IsChannelAlreadySaved(string Id);
    }
}
