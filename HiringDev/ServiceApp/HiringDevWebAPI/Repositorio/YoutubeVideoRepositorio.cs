using Dapper;
using HiringDevWebAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace HiringDevWebAPI.Repositorio
{
    /// <summary>
    /// Classe principal <c>YoutubeVideoRepositorio</c>.
    /// Contem os metodos e atributos que representam necessários para persistir os dados do tipo YoutubeVideo no banco de dados.
    /// Classe implementa os metodos da interface IYoutubeVideoRepositorio.
    /// </summary>
    public class YoutubeVideoRepositorio : IYoutubeVideoRepositorio
    {
        /// <summary>
        /// Representa um conjunto de propriedades de configuração da aplicação.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor para instancias do tipo <see cref="=YoutubeVideoRepositorio"/>.
        /// </summary>
        /// <param name="configuration">Resolução de depencias da interface IConfiguration.</param>
        public YoutubeVideoRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Obtem um objeto salvo no banco de dados do tipo YoutubeVideo, pesquisando por de seu identificador.
        /// </summary>
        /// <param name="videoId">Valor do identificador a ser pesquisado no banco de dados.</param>
        /// <returns>Objecto do tipo YoutubeVideo.</returns>
        public YoutubeVideo ObterYoutubeVideoPorId(string videoId)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                return conexao.QueryFirstOrDefault<YoutubeVideo>
                    (
                        "SELECT VideoId, " +
                        "Descricao, " +
                        "Titulo, " +
                        "UrlImagem " +
                        "FROM segfyhiringdev.YoutubeVideo " +
                        "WHERE VideoId = @VideoId",
                        new { VideoId = videoId }
                    );
            }
        }

        /// <summary>
        /// Obtem uma lista de objetos salvo no banco de dados do tipo YoutubeVideo,
        /// pesquisando por se termo contém dentro de "Descricao" ou "Titulo".
        /// Método criado para ser acionado quando a quota diária de pesquisas da API do Youtube for alcançada.
        /// </summary>
        /// <param name="texto">Valor a ser pesquisado nas colunas "Descricao" ou "Titulo".</param>
        /// <returns>Lista de objecto do tipo YoutubeVideo.</returns>
        public List<YoutubeVideo> ObterListaVideosPorTexto(string texto)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                return conexao.Query<YoutubeVideo>
                    (
                        "SELECT VideoId, " +
                        "Descricao, " +
                        "Titulo, " +
                        "UrlImagem " +
                        "FROM segfyhiringdev.YoutubeVideo " +
                        "WHERE Descricao like @Texto OR Titulo like @Texto",
                        new { Texto = $"%{texto}%" }
                    ).ToList();
            }
        }

        /// <summary>
        /// Insere uma nova entidade do tipo YoutubeVideo no banco de dados.
        /// </summary>
        /// <param name="youtubeVideo">Objeto a ser inserido no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        public int InserirYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                string insertQuery = "INSERT INTO segfyhiringdev.YoutubeVideo (VideoId, Descricao, Titulo, UrlImagem) " +
                    "VALUES (@VideoId, @Descricao, @Titulo, @UrlImagem)";

                return conexao.Execute(insertQuery, youtubeVideo);
            }
        }

        /// <summary>
        /// Atualiza uma entidade do tipo YoutubeVideo no banco de dados.
        /// </summary>
        /// <param name="youtubeVideo">Objeto a ser atualziado no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        public int AtualizarYoutubeVideo(YoutubeVideo youtubeVideo)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                string updateQuery = "UPDATE segfyhiringdev.YoutubeVideo SET Descricao = @Descricao, Titulo = @Titulo, UrlImagem = @UrlImagem " +
                    "WHERE VideoId = @VideoId";

                return conexao.Execute(updateQuery, youtubeVideo);
            }
        }
    }
}