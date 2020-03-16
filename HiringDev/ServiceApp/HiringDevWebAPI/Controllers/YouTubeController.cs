using HiringDevWebAPI.Models;
using HiringDevWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HiringDevWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouTubeController : ControllerBase
    {
        private readonly IYoutubeService _youtubeService;

        public YouTubeController(IYoutubeService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PesquisarVideos(
            [FromQuery(Name = "texto")] string texto,
            [FromQuery(Name = "pagina")] int pagina,
            [FromQuery(Name = "quantidade")] int quantidade)
        {
            return await PesquisarPorTipo("video", texto, pagina, quantidade);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> PesquisarCanais(
            [FromQuery(Name = "texto")] string texto,
            [FromQuery(Name = "pagina")] int pagina,
            [FromQuery(Name = "quantidade")] int quantidade)
        {
            return await PesquisarPorTipo("channel", texto, pagina, quantidade);
        }

        private async Task<IActionResult> PesquisarPorTipo(string tipo, string texto, int pagina, int quantidade)
        {
            var skip = (pagina - 1) * quantidade;

            if (quantidade <= 0)
            {
                return BadRequest("O parâmetro 'quantidade' não pode igual ou menor que 0");
            }

            if (pagina < 0)
            {
                return BadRequest("O parâmetro 'pagina' não pode ser negativo");
            }

            var retorno = await _youtubeService.PesquisarPorTextoETipo(texto, tipo);

            switch (tipo.ToLower())
            {
                case "channel":

                    return Ok(
                        new { Total = retorno.Count, Canais = retorno.Select(x => x as YoutubeCanal).Skip(skip).Take(quantidade).ToArray() });

                case "video":
                    return Ok(
                        new { Total = retorno.Count, Videos = retorno.Select(x => x as YoutubeVideo).Skip(skip).Take(quantidade).ToArray() });

                default:
                    return Ok(
                        new { Total = 0 });
            }
        }
    }
}