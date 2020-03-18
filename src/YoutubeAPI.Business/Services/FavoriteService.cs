using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Models;
using YoutubeAPI.Business.Util;

namespace YoutubeAPI.Business.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IUserService userService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;

        public FavoriteService(IFavoriteRepository favoriteRepository, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.favoriteRepository = favoriteRepository;
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task RemoveFavorite(string id)
        {
            await this.favoriteRepository.Remove(id);
        }

        public async Task SaveFavoriteAsync(Favorite favorite)
        {
            //to-do validate and error notify

            var user = this.session.GetString(Constants.USER);
            var entity = await this.userService.GetUserByEmail(user);
            favorite.User = entity;

            await this.favoriteRepository.Create(favorite);
        }
    }
}
