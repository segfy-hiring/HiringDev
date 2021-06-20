using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SegFyChallenge.Presentation.Services;

namespace SegFyChallenge.Presentation.Controllers
{
    public class ChannelController : Controller
    {
        private readonly ISegFyAppClient _service;

        public ChannelController(ISegFyAppClient service)
        {
            _service = service;
        }

        public async Task<IActionResult> Search(string queryText)
        {
            if (string.IsNullOrEmpty(queryText))
            {
                return View();
            }
            else
            {
                var channels = await _service.SearchChannels(queryText);
                return View(channels);
            }
        }

        public async Task<IActionResult> Channels()
        {
            var videos = await _service.GetChannels();
            return View(videos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetChannel(id);
            return View(item);
        }
    }
}