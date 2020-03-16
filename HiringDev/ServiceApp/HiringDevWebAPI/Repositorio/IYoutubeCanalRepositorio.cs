using HiringDevWebAPI.Models;
using System.Collections.Generic;

namespace HiringDevWebAPI.Repositorio
{
    /// <summary>
    /// Interface <c>IYoutubeCanalRepositorio</c>.
    /// Contem a assinatura dos métodos necessárias para implementação.
    /// </summary>
    public interface IYoutubeCanalRepositorio
    {
        /// <summary>
        /// Obtem um objeto salvo no banco de dados do tipo YoutubeCanal, pesquisando por de seu identificador.
        /// </summary>
        /// <param name="canalId">Valor do identificador a ser pesquisado no banco de dados.</param>
        /// <returns>Objecto do tipo YoutubeCanal.</returns>
        YoutubeCanal ObterYoutubeCanalPorId(string canalId);

        /// <summary>
        /// Obtem uma lista de objetos salvo no banco de dados do tipo YoutubeCanal,
        /// pesquisando por se termo contém dentro de "Descricao" ou "Titulo".
        /// Método criado para ser acionado quando a quota diária de pesquisas da API do Youtube for alcançada.
        /// </summary>
        /// <param name="texto">Valor a ser pesquisado nas colunas "Descricao" ou "Titulo".</param>
        /// <returns>Lista de objecto do tipo YoutubeCanal.</returns>
        List<YoutubeCanal> ObterListaCanaisPorTexto(string texto);

        /// <summary>
        /// Insere uma nova entidade do tipo YoutubeCanal no banco de dados.
        /// </summary>
        /// <param name="youtubeCanal">Objeto a ser inserido no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        int InserirYoutubeCanal(YoutubeCanal youtubeCanal);

        /// <summary>
        /// Atualiza uma entidade do tipo YoutubeCanal no banco de dados.
        /// </summary>
        /// <param name="youtubeCanal">Objeto a ser atualziado no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        int AtualizarYoutubeCanal(YoutubeCanal youtubeCanal);


    }
}