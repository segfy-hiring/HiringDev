using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoutubeTree.Domain;

namespace YoutubeTree.API
{
    [ApiController]
    [Route("api/v1/subscriptions")]
    public class SubscriptionController : ControllerBase
    {
        readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;    
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscriptions = await _subscriptionRepository.GetAll();

            return Ok(new SubscriptionViewModel().ToMapMany(subscriptions));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subscription = await _subscriptionRepository.GetById(id);

            return Ok(new SubscriptionViewModel().ToMap(subscription));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubscriptionRequest request)
        {
            await _subscriptionRepository.Create(
                new Subscription(
                    request.YoutubeId,
                    request.Type,
                    request.Title,
                    request.Description,
                    request.PublishedAt,
                    request.DefaultThumbnail,
                    request.MediumThumbnail,
                    request.HighThumbnail            
                )
            );

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _subscriptionRepository.Delete(id);

            return NoContent();
        }
    }
}