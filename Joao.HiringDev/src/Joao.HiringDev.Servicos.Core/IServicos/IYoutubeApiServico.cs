using Joao.HiringDev.Dominio.Responses;
using System.Threading.Tasks;

namespace Joao.HiringDev.Servicos.Core.IServicos
{
    public interface IYoutubeApiServico
    {
        Task<YoutubeApiServicoResponse> Obter(string busca);
    }
}
