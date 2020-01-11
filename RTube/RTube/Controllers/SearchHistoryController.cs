using Microsoft.AspNetCore.Mvc;
using RTube.Models;
using RTube.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTube.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SearchHistoryController: ControllerBase
    {
        private readonly IYouTubeService _youTubeService;

        public SearchHistoryController(IYouTubeService youTubeService)
        {
            _youTubeService = youTubeService;
        }

        [HttpGet]
        public IEnumerable<YouTubeItem> Get()
        {
            return _youTubeService.GetSearchHistory();
        }
    }
}
