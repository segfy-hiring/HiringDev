using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoutubeTree.Application;
using YoutubeTree.Domain;

namespace YoutubeTree.API.Controllers
{
    [ApiController]
    [Route("api/v1/search")]
    public class SearchController : ControllerBase
    {
        private readonly IYoutubeSearchService _youtubeSearchService;
        public SearchController(IYoutubeSearchService youtubeSearchService)
        {
            _youtubeSearchService = youtubeSearchService;
        }

        [ProducesResponseType(typeof(PagedSearchResponse<SubscriptionViewModel>), 200)]
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query, [FromQuery] string nextPage)
        {
            var result = await _youtubeSearchService.Search(query, nextPage);

            return Ok(result);
        }
    }
}
