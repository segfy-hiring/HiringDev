using Dapper;
using HiringDevWebAPI.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace HiringDevWebAPI.Repositorio
{
    /// <summary>
    /// Classe principal <c>YoutubeCanalRepositorio</c>.
    /// Contem os metodos e atributos que representam necessários para persistir os dados do tipo YoutubeCanal no banco de dados.
    /// Classe implementa os metodos da interface IYoutubeCanalRepositorio.
    /// </summary>
    public class YoutubeCanalRepositorio : IYoutubeCanalRepositorio
    {
        /// <summary>
        /// Representa um conjunto de propriedades de configuração da aplicação.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor para instancias do tipo <see cref="=YoutubeCanalRepositorio"/>.
        /// </summary>
        /// <param name="configuration">Resolução de depencias da interface IConfiguration.</param>
        public YoutubeCanalRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Obtem um objeto salvo no banco de dados do tipo YoutubeCanal, pesquisando por de seu identificador.
        /// </summary>
        /// <param name="canalId">Valor do identificador a ser pesquisado no banco de dados.</param>
        /// <returns>Objecto do tipo YoutubeCanal.</returns>
        public YoutubeCanal ObterYoutubeCanalPorId(string canalId)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                return conexao.QueryFirstOrDefault<YoutubeCanal>
                    (
                        "SELECT CanalId, " +
                        "Descricao, " +
                        "Titulo, " +
                        "UrlImagem " +
                        "FROM segfyhiringdev.YoutubeCanal " +
                        "WHERE CanalId = @CanalId",
                        new { CanalId = canalId }
                    );
            }
        }

        /// <summary>
        /// Obtem uma lista de objetos salvo no banco de dados do tipo YoutubeCanal,
        /// pesquisando por se termo contém dentro de "Descricao" ou "Titulo".
        /// Método criado para ser acionado quando a quota diária de pesquisas da API do Youtube for alcançada.
        /// </summary>
        /// <param name="texto">Valor a ser pesquisado nas colunas "Descricao" ou "Titulo".</param>
        /// <returns>Lista de objecto do tipo YoutubeCanal.</returns>
        public List<YoutubeCanal> ObterListaCanaisPorTexto(string texto)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                return conexao.Query<YoutubeCanal>
                    (
                        "SELECT CanalId, " +
                        "Descricao, " +
                        "Titulo, " +
                        "UrlImagem " +
                        "FROM segfyhiringdev.YoutubeCanal " +
                        "WHERE Descricao like @Texto OR Titulo like @Texto",
                        new { Texto = $"%{texto}%" }
                    ).ToList();
            }
        }

        /// <summary>
        /// Insere uma nova entidade do tipo YoutubeCanal no banco de dados.
        /// </summary>
        /// <param name="youtubeCanal">Objeto a ser inserido no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        public int InserirYoutubeCanal(YoutubeCanal youtubeCanal)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                string insertQuery = "INSERT INTO segfyhiringdev.YoutubeCanal (CanalId, Descricao, Titulo, UrlImagem) " +
                    "VALUES (@CanalId, @Descricao, @Titulo, @UrlImagem)";

                return conexao.Execute(insertQuery, youtubeCanal);
            }
        }

        /// <summary>
        /// Atualiza uma entidade do tipo YoutubeCanal no banco de dados.
        /// </summary>
        /// <param name="youtubeCanal">Objeto a ser atualziado no banco.</param>
        /// <returns>Linhas afetadas.</returns>
        public int AtualizarYoutubeCanal(YoutubeCanal youtubeCanal)
        {
            using (MySqlConnection conexao = new MySqlConnection(
                _configuration.GetConnectionString("BaseYouTube")))
            {
                string updateQuery = "UPDATE segfyhiringdev.YoutubeCanal SET Descricao = @Descricao, Titulo = @Titulo, UrlImagem = @UrlImagem " +
                    "WHERE CanalId = @CanalId";

                return conexao.Execute(updateQuery, youtubeCanal);
            }
        }
    }
}