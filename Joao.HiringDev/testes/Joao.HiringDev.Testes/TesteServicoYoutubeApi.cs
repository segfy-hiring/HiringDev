using Joao.HiringDev.Servicos.Servicos;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Joao.HiringDev.Testes
{
    public class TesteServicoYoutubeApi
    {
        [Fact]
        public async Task TesteConsultarVideoApi()
        {
            var servico = new YoutubeApiServico();

            var resultado = await servico.Obter("João Carias");
            var videosTestes = resultado.Videos.Where(x => "João Carias".Contains(x.Title)).ToList();
            Assert.All(videosTestes, item => Assert.Contains("João Carias", item.Title));
        }

        [Fact]
        public async Task TesteConsultarCanalApi()
        {
            var servico = new YoutubeApiServico();

            var resultado = await servico.Obter("João Carias");
            var canaisTestes = resultado.Canais.Where(x => "João Carias".Contains(x.Title)).ToList();

            Assert.All(canaisTestes, t => Assert.Contains("João Carias", t.Title));
        }
    }
}
