using System.Collections.Generic;
using System.Threading.Tasks;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Business.Interfaces
{
    public interface IFavoriteRepository
    {
        Task Create(Favorite favorite);

        Task<List<Favorite>> List(string term);

        Task Remove(string id);
    }
}
