using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SegFyChallenge.Application.Interfaces.Services;
using SegFyChallenge.Domain.Models;
using SegFyChallenge.WebApi.Models;

namespace SegFyChallenge.WebApi.Controllers
{

    [ApiController]
    [Route("Channels")]
    public class ChannelController : ControllerBase
    {
        
        private readonly IChannelService _service;

        public ChannelController(IChannelService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search(string queryText)
        {
            if (string.IsNullOrEmpty(queryText))
            {
                return NotFound();
            }
            else
            {
                var channels = await _service.GetChannelsFromYoutube(queryText);
                var channelsViewModel = ChannelViewModel.FromChannels(channels);
                return Ok(channelsViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var channels = await _service.GetChannels();
            var channelViewModels = ChannelViewModel.FromChannels(channels);
            return Ok(channelViewModels);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetChannel(id);
            if (item != null)
            {
                var viewModel = new ChannelViewModel() 
                {
                    ChannelId = item.ChannelId,
                    Description = item.Description,
                    Id = item.Id,
                    PublishedAt = item.PublishedAt,
                    Title = item.Title
                };

                return Ok(viewModel);
            }
            else
            {
                return NotFound();
            }
        }
    }
}