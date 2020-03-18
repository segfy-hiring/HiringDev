using System.Threading.Tasks;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string user);
    }
}
