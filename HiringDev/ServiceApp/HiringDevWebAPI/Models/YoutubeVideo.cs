using Google.Apis.YouTube.v3.Data;

namespace HiringDevWebAPI.Models
{
    /// <summary>
    /// Classe principal <c>YoutubeVideo</c>.
    /// Contem os metodos e atributos que representam YoutubeVideo.
    /// Classe herda metodos e atributos da classe YoutubeEntidade.
    /// </summary>
    public class YoutubeVideo : YoutubeEntidade
    {
        /// <summary>
        /// Obtem e define o valor para VideoId, que representa o identificador unico de YoutubeVideo.
        /// </summary>
        /// <value>Identificador unico de YoutubeVideo.</value>
        public string VideoId { get; set; }

        /// <summary>
        /// Construtor padrão, necessário para criar novas instancias do tipo <see cref="=YoutubeVideo"/>.
        /// </summary>
        public YoutubeVideo()
        {
        }

        /// <summary>
        /// Construtor para criar nova instancia do tipo <see cref="=YoutubeVideo"/>
        /// a partir de um objeto do tipo SearchResult (Google.Apis.YouTube.v3.Data).
        /// </summary>
        /// <param name="item">Objeto de retorno da API do Youtube.</param>
        public YoutubeVideo(SearchResult item) : base(item)
        {
            this.VideoId = item.Id.VideoId;
        }
    }
}