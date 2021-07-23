using Joao.HiringDev.Apresentacao.Models;
using Joao.HiringDev.Apresentacao.Models.Home;
using Joao.HiringDev.Dominio.Responses;
using Joao.HiringDev.Infraestrutura.Contextos;
using Joao.HiringDev.Infraestrutura.Core.IRepositorios;
using Joao.HiringDev.Servicos.Core.IServicos;
using Joao.HiringDev.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Joao.HiringDev.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IYoutubeApiServico _youtubeApiServico;

        private readonly Context _context;

        private readonly IRepositorioVideoYoutube _repositorioVideoYoutube;
        private readonly IRepositorioCanalYoutube _repositorioCanalYoutube;

        public HomeController(
                        ILogger<HomeController> logger,
                        Context context,
                        IYoutubeApiServico youtubeApiServico,
                        IRepositorioVideoYoutube repositorioVideoYoutube,
                        IRepositorioCanalYoutube repositorioCanalYoutube)
        {
            _logger = logger;
            _context = context;

            _youtubeApiServico = youtubeApiServico;

            _repositorioVideoYoutube = repositorioVideoYoutube;
            _repositorioCanalYoutube = repositorioCanalYoutube;
        }

        public async Task<IActionResult> Index(FiltroHomeViewModel viewModel)
        {
            if (viewModel != null && !string.IsNullOrEmpty(viewModel.PalavraChave))
            {
                viewModel.YoutubeApiServico = await _youtubeApiServico.Obter(viewModel.PalavraChave);
                SalvarNoBanco(viewModel.YoutubeApiServico);
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

        private void SalvarNoBanco(YoutubeApiServicoResponse response)
        {
            if (response.Videos != null && response.Videos.Any())
            {
                foreach (var video in response.Videos)
                {
                    _repositorioVideoYoutube.Inserir(video);
                }
            }

            if (response.Canais != null && response.Canais.Any())
            {
                foreach (var canal in response.Canais)
                {
                    _repositorioCanalYoutube.Inserir(response.Canais);
                }
            }
        }
    }
}
