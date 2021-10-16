using Microsoft.AspNetCore.Mvc;
using SkillTestSegfy.Infrastructure.Services.YoutubeApi;
using SkillTestSegfy.Web.Models.Home;
using System.Threading.Tasks;

namespace SkillTestSegfy.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IYoutubeApiService youtubeApiService)
        {
            YoutubeApiService = youtubeApiService;
        }

        private IYoutubeApiService YoutubeApiService { get; }

        public IActionResult Index()
        {
            return View(new YoutubeSearchModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(YoutubeSearchModel model)
        {
            var results = await YoutubeApiService.Search(model.Term);
            model.Titles = results;

            return View(model);
        }
    }
}
