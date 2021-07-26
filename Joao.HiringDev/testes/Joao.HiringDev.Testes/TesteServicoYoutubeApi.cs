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

            var resultado = await servico.Obter("Jo�o Carias");
            var videosTestes = resultado.Videos.Where(x => "Jo�o Carias".Contains(x.Title)).ToList();
            Assert.All(videosTestes, item => Assert.Contains("Jo�o Carias", item.Title));
        }

        [Fact]
        public async Task TesteConsultarCanalApi()
        {
            var servico = new YoutubeApiServico();

            var resultado = await servico.Obter("Jo�o Carias");
            var canaisTestes = resultado.Canais.Where(x => "Jo�o Carias".Contains(x.Title)).ToList();

            Assert.All(canaisTestes, t => Assert.Contains("Jo�o Carias", t.Title));
        }
    }
}
