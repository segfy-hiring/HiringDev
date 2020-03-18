using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using YoutubeApi.Api.Extensions;
using YoutubeApi.Api.Models;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Models;
using YoutubeAPI.Business.Util;


namespace YoutubeApi.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IYoutubeSeachService service;
        private readonly IMapper mapper;
        private readonly IFavoriteService favoriteService;

        public HomeController(IYoutubeSeachService youtubeSeachService, IMapper mapper, IFavoriteService favoriteService)
        {
            this.service = youtubeSeachService;
            this.mapper = mapper;
            this.favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = HttpContext.Session.GetString(Constants.SEARCH);
            }
            else
            {
                HttpContext.Session.SetString(Constants.SEARCH, search);
            }

            var model = this.mapper.Map<PaginationViewModel>(await this.service.SeachAsync(search));

            HttpContext.Session.Set(Constants.SEARCHES, model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ShowMore(string search, string nextPageToken)
        {
            var model = HttpContext.Session.Get<PaginationViewModel>(Constants.SEARCHES);
            var nextpage = this.mapper.Map<PaginationViewModel>(await this.service.SeachAsync(search, nextPageToken));

            if (model is null)
            {
                model = nextpage;
            }
            else
            {
                model.NextPage = nextpage.NextPage;
                model.Searches.AddRange(nextpage.Searches);
            }

            HttpContext.Session.Set(Constants.SEARCHES, model);
            return View(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> Favorite([Bind("Id, Title, Details,Type, Description,PublishedAt")]SearchViewModel searchViewModel)
        {
            var favorite = this.mapper.Map<Favorite>(searchViewModel);
            await this.favoriteService.SaveFavoriteAsync(favorite);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFavorite(string id)
        {
            await this.favoriteService.RemoveFavorite(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Back()
        {
            HttpContext.Session.Remove(Constants.SEARCHES);
            HttpContext.Session.Remove(Constants.SEARCH);
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
