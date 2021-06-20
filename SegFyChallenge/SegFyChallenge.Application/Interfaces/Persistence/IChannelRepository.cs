using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Application.Interfaces.Persistence
{
    public interface IChannelRepository
    {
        Task<Channel> Get(int id);
        Task<List<Channel>> GetAll();
        Task<int> Save(Channel channel);
        Task Delete(Channel channel);
        Task Delete(int id);
    }
}