using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SegFyChallenge.Application.Interfaces.Services;
using SegFyChallenge.Domain.Models;
using SegFyChallenge.WebApi.Models;

namespace SegFyChallenge.WebApi.Controllers
{
    [ApiController]
    [Route("Videos")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _service;

        public VideoController(IVideoService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery(Name = "queryText")] string queryText)
        {
            if (string.IsNullOrEmpty(queryText))
            {
                return NotFound(); 
            }
            else
            {
                var videos = await _service.GetVideosFromYoutube(queryText);
                var videosViewModel = VideoViewModel.FromVideos(videos);
                return Ok(videosViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var videos = await _service.GetVideos();
            var videosViewModel = VideoViewModel.FromVideos(videos);
            return Ok(videosViewModel);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetVideo(id);
            if (item != null)
            {
                var viewModel = new VideoViewModel() 
                {
                    ChannelId = item.ChannelId,
                    Description = item.Description,
                    Id = item.Id,
                    PublishedAt = item.PublishedAt,
                    Title = item.Title,
                    VideoId = item.VideoId
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