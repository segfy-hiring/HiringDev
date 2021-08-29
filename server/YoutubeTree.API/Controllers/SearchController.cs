using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoutubeTree.Domain;

namespace YoutubeTree.API.Controllers
{
    [ApiController]
    [Route("api/v1/search")]
    public class SearchController : ControllerBase
    {
        readonly ISubscriptionRepository _subscriptionRepository;
        public SearchController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var result = await _subscriptionRepository.Search(query);

            if (!result.Any())
            {
                return BadRequest();
            }

            return Ok(new SubscriptionViewModel().ToMapMany(result));
        }
    }
}
