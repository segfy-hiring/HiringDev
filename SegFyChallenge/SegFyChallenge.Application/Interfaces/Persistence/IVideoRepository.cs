using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Application.Interfaces.Persistence
{
    public interface IVideoRepository
    {
        Task<Video> Get(int id);
        Task<List<Video>> GetAll();
        Task<int> Save(Video video);
        Task Delete(Video video);
        Task Delete(int id);
    }
}