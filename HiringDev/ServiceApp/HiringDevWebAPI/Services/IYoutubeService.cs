using HiringDevWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringDevWebAPI.Services
{
    /// <summary>
    /// Interface <c>IYoutubeService</c>.
    /// Contem a assinatura dos métodos necessárias para implementação.
    /// </summary>
    public interface IYoutubeService
    {
        /// <summary>
        /// Obtem uma lista objeto do tipo YoutubeEntidade, pesquisado por texto e tipo (video ou canal)
        /// na API do YouTube. Se Quota diária de requisições da API do YouTube for atingida, pesquisa será feita no banco de dados.
        /// </summary>
        /// <param name="texto">Texto a ser pesquisado.</param>
        /// <param name="tipo">Tipo a ser pesado tipo (video ou canal).</param>
        /// <returns>Lista de objetos do tipo YoutubeEntidade.</returns>
        Task<List<YoutubeEntidade>> PesquisarPorTextoETipo(string texto, string tipo);
    }
}