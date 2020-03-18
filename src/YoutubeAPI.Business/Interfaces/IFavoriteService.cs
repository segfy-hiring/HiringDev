using System.Threading.Tasks;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Business.Interfaces
{
    public interface IFavoriteService
    {
        Task SaveFavoriteAsync(Favorite favorite);

        Task RemoveFavorite(string id);
    }
}
