using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Models;
using YoutubeAPI.Data.Context;

namespace YoutubeAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YoutubeAPIContext context;

        public UserRepository(YoutubeAPIContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateOrGet(User user)
        {
            var entity = await this.context.Users.SingleOrDefaultAsync(x => x.Email == user.Email);

            if (entity is null)
            {
                this.context.Users.Add(user);
                await this.context.SaveChangesAsync();
                return user;
            }

            return entity;

        }
    }
}
