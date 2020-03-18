using System.Threading.Tasks;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            //to-do validate and error notify
            var user = new User()
            {
                Email = email
            };

            return await this.userRepository.CreateOrGet(user);
        }
    }
}
