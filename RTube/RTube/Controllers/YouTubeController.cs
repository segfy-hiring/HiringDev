using Microsoft.AspNetCore.Mvc;
using RTube.Models.Result;
using RTube.Services;
using System.Threading.Tasks;

namespace RTube.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YouTubeController : ControllerBase
    {
        private readonly IYouTubeService _youTubeService;

        public YouTubeController(IYouTubeService youTubeService)
        {
            _youTubeService = youTubeService;
        }

        [HttpGet]
        public async Task<YouTubeResult> Get(string query, string pageToken = null)
        {
            return await _youTubeService.Search(query, pageToken);
        }
    }
}
