using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Models;
using YoutubeAPI.Business.Util;
using YoutubeAPI.Data.Context;

namespace YoutubeAPI.Data.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly YoutubeAPIContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;

        public FavoriteRepository(YoutubeAPIContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task Create(Favorite favorite)
        {
            var user = await this.context.Favorites.FirstOrDefaultAsync(x => x.Id.Equals(favorite.Id));
            if(user is null)
            {
                this.context.Favorites.Add(favorite);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<List<Favorite>> List(string term)
        {
            string email = this.session.GetString(Constants.USER);
            var favoritos = new List<Favorite>();

            if (string.IsNullOrEmpty(term))
            {
                favoritos = await this.context.Favorites.AsNoTracking().Where(x => x.User.Email.Equals(email)).ToListAsync();
            }
            else
            {
                favoritos = await this.context.Favorites.AsNoTracking().Where(x => x.User.Email.Equals(email) && x.Title.Contains(term) || x.Description.Contains(term)).ToListAsync();
            }

            return favoritos;
        }

        public async Task Remove(string id)
        {
            var favorite = await this.context.Favorites.SingleOrDefaultAsync(x => x.Id == id);

            if (favorite is null)
            {
                //to-do notify
                return;
            }

            this.context.Favorites.Remove(favorite);
            await this.context.SaveChangesAsync();
        }
    }
}
