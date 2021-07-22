using Joao.HiringDev.Apresentacao.Models;
using Joao.HiringDev.Apresentacao.Models.Home;
using Joao.HiringDev.Servicos.Core.IServicos;
using Joao.HiringDev.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Joao.HiringDev.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IYoutubeApiServico _youtubeApiServico;

        public HomeController(
                        ILogger<HomeController> logger,
                        IYoutubeApiServico youtubeApiServico)
        {
            _logger = logger;
            _youtubeApiServico = youtubeApiServico;
        }

        public async Task<IActionResult> Index(FiltroHomeViewModel viewModel)
        {
            if(viewModel != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                
                await _youtubeApiServico.Obter(viewModel.PalavraChave);
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
