using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SegFyChallenge.Presentation.Services;

namespace SegFyChallenge.Presentation.Controllers
{
    public class VideoController : Controller
    {
        private readonly ISegFyAppClient _service;

        public VideoController(ISegFyAppClient service)
        {
            _service = service;
        }

        public async Task<IActionResult> Search([FromQuery(Name = "queryText")] string queryText)
        {
            if (string.IsNullOrEmpty(queryText))
            {
                return View(); 
            }
            else
            {
                var videos = await _service.SearchVideos(queryText);
                return View(videos);
            }
        }

        public async Task<IActionResult> Videos()
        {
            var videos = await _service.GetVideos();
            return View(videos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetVideo(id);
            return View(item);
        }
    }
}