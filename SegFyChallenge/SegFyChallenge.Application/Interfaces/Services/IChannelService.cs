using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Application.Interfaces.Services
{
    public interface IChannelService
    {
        Task<List<Channel>> GetChannels();
        Task<List<Channel>> GetChannelsFromYoutube(string queryText);
        Task<Channel> GetChannel(int id);
    }
}