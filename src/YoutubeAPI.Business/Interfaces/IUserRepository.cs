using System.Threading.Tasks;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateOrGet(User user);
    }
}
