using HiringDevWebAPI.Models;
using System.Collections.Generic;

namespace HiringDevWebAPI.Repositorio
{
    /// <summary>
    /// Interface <c>IYoutubeVideoRepositorio</c>.
    /// Contem a assinatura dos métodos necessárias para implementação.
    /// </summary>
    public interface IYoutubeVideoRepositorio
    {
        /// <summary>
        /// Obtem um objeto salvo no banco de dados do tipo YoutubeVideo, pesquisando por de seu identificador.
        /// </summary>
        /// <param name="videoId">Valor do identificador a ser pesquisado no banco de dados.</param>
        /// <returns>Objecto do tipo YoutubeVideo.</returns>
        YoutubeVideo ObterYoutubeVideoPorId(string videoId);

        /// <summary>
        /// Obtem uma lista de objetos salvo no banco de dados do tipo YoutubeVideo,
        /// pesquisando por se termo contém dentro de "Descricao" ou "Titulo".
        /// Método criado para ser acionado quando a quota diária de pesquisas da API do Youtube for alcançada.
        /// </summary>
        /// <param name="texto">Valor a ser pesquisado nas colunas "Descricao" ou "Titulo".</param>
        /// <returns>Lista de objecto do tipo YoutubeVideo.</returns>
        List<YoutubeVideo> ObterListaVideosPorTexto(string texto);

        /// <summary>
        /// Insere uma nova entidade do tipo YoutubeVideo no banco de dados.
        /// </summary>
        /// <param name="youtubeVideo">Objeto a ser inserido no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        int InserirYoutubeVideo(YoutubeVideo youtubeVideo);

        /// <summary>
        /// Atualiza uma entidade do tipo YoutubeVideo no banco de dados.
        /// </summary>
        /// <param name="youtubeVideo">Objeto a ser atualziado no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        int AtualizarYoutubeVideo(YoutubeVideo youtubeVideo);
    }
}