using Microsoft.AspNetCore.Mvc;
using SkillTestSegfy.Infrastructure.Services.YoutubeApi;
using SkillTestSegfy.Web.Models.Home;
using System.Linq;
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
            return View(new YoutubeSearchModel
            {
                Message = "Nenhuma pesquisa efetuada.",
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(YoutubeSearchModel model)
        {
            var results = await YoutubeApiService.Search(model.Term);
            model.Items = results.Select(o => new YoutubeSearchItemModel(o)).ToList();

            if (!model.Items.Any())
            {
                model.Message = "Nenhum vídeo, canal ou playlist encontrado.";
            }

            return View(model);
        }
    }
}
