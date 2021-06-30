using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YoutubeApiConsumerApp.Models;
using System.Threading.Tasks;
using YoutubeApiConsumerApp.Data.Repository.Interfaces;
using YoutubeApiConsumerApp.Services.Youtube.Interfaces;

namespace YoutubeApiConsumerApp.Controllers
{
    public class YoutubeController : Controller
    {
        private readonly IYoutubeRepository _youtubeRepository;
        private readonly IYoutubeAppService _youtubeAppService;

        public YoutubeController(IYoutubeRepository youtubeRepository, IYoutubeAppService youtubeAppService)
        {
            _youtubeRepository = youtubeRepository;
            _youtubeAppService = youtubeAppService;
        }
       
        public IActionResult Index()
        {
            return View("YouTubeApiHome");
        }

        public ActionResult Search(SearchModel searchViewModel)
        {      
            var response = _youtubeAppService.GetVideosAndChannelsBySearchTerm(searchViewModel);
            return View("List", _youtubeAppService.FromYoutubeResponseToSearchResponseModel(response));
        }

        public ActionResult VideoDetails(YoutubeVideoModel youtubeVideoViewModel)
        {
            return View(youtubeVideoViewModel);
        }

        public ActionResult ChannelDetails(YoutubeChannelModel youtubeChannelViewModel)
        {
            return View(youtubeChannelViewModel);
        }
        public async Task<ActionResult<IEnumerable<YoutubeVideoModel>>> GetVideosAndChannelsFromDatabase()
        {
            var response = _youtubeRepository.GetAllVideosAndChannels();
            return View("List", response);
        }

        public async Task<IActionResult> SaveVideoOnDatabase(YoutubeVideoModel youtubeVideoViewModel)
        {
            if (ModelState.IsValid)
            {
                var video = _youtubeRepository.IsVideoAlreadySaved(youtubeVideoViewModel.Id);

                if (!video)
                {                    
                    await _youtubeRepository.SaveSearchedVideos(youtubeVideoViewModel);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Ok("Video Info has been already saved on Database! So We didn't save it again to save server space and resources :)");
                }                
            }
            return BadRequest("Error Saving Video Info to Database!");
        }

        public async Task<IActionResult> SaveChannelOnDatabase(YoutubeChannelModel youtubeChannelViewModel)
        {

            if (ModelState.IsValid)
            {
                var channel = _youtubeRepository.IsChannelAlreadySaved(youtubeChannelViewModel.Id);

                if (!channel)
                {
                    await _youtubeRepository.SaveSearchedChannels(youtubeChannelViewModel);                    
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Ok("Channel Info has been already saved on Database! So We didn't save it again to save server space and resources :)");
                }
                
            }

            return BadRequest("Error Saving Channel Info to Database!");
        }
    }
}
