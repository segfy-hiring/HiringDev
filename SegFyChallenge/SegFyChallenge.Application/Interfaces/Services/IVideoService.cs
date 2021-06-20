using System.Collections.Generic;
using System.Threading.Tasks;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Application.Interfaces.Services
{
    public interface IVideoService
    {
        Task<List<Video>> GetVideos();
        Task<List<Video>> GetVideosFromYoutube(string queryText);
        Task<Video> GetVideo(int id);
    }
}