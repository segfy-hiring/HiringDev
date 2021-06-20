using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Presentation.Models;

namespace SegFyChallenge.Presentation.Services
{
    public interface ISegFyAppClient
    {
        Task<VideoViewModel> GetVideo(int id);
        Task<List<VideoViewModel>> GetVideos();
        Task<List<VideoViewModel>> SearchVideos(string queryText);
        Task<ChannelViewModel> GetChannel(int id);
        Task<List<ChannelViewModel>> GetChannels();
        Task<List<ChannelViewModel>> SearchChannels(string queryText);
    }
}