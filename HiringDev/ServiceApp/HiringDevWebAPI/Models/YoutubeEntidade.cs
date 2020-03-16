using Google.Apis.YouTube.v3.Data;

namespace HiringDevWebAPI.Models
{
    /// <summary>
    /// Classe principal <c>YoutubeEntidade</c>.
    /// Contem os metodos e atributos comuns entre as classes YoutubeCanal e YoutubeVideo.
    /// </summary>
    public class YoutubeEntidade
    {
        /// <summary>
        /// Obtem e define o valor para Descricao.
        /// </summary>
        /// <value>Representa a descrição de um vídeo/canal.</value>
        public string Descricao { get; set; }
        /// <summary>
        /// Obtem e define o valor para Titulo.
        /// </summary>
        /// <value>Representa o título de um vídeo/canal.</value>
        public string Titulo { get; set; }
        /// <summary>
        /// Obtem e define o valor para UrlImagem.
        /// </summary>
        /// <value>Contem a URL da imagem de um vídeo/canal.</value>
        public string UrlImagem { get; set; }

        /// <summary>
        /// Construtor padrão, necessário para criar novas instancias.
        /// </summary>
        public YoutubeEntidade()
        {
        }

        /// <summary>
        /// Construtor para criar nova instancia a partir de um objeto do tipo SearchResult (Google.Apis.YouTube.v3.Data).
        /// </summary>
        /// <param name="item">Objeto de retorno da API do Youtube.</param>
        public YoutubeEntidade(SearchResult item)
        {
            this.Descricao = item.Snippet.Description;
            this.Titulo = item.Snippet.Title;
            this.UrlImagem = item.Snippet.Thumbnails.Default__.Url;
        }
    }
}