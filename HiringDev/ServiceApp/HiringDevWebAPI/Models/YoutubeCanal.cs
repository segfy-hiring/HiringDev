using Google.Apis.YouTube.v3.Data;

namespace HiringDevWebAPI.Models
{
    /// <summary>
    /// Classe principal <c>YoutubeCanal</c>.
    /// Contem os metodos e atributos que representam YoutubeCanal.
    /// Classe herda metodos e atributos da classe YoutubeEntidade.
    /// </summary>
    public class YoutubeCanal : YoutubeEntidade
    {
        /// <summary>
        /// Obtem e define o valor para CanalId.
        /// </summary>
        /// <value>Identificador unico de YoutubeCanal.</value>
        public string CanalId { get; set; }

        /// <summary>
        /// Construtor padrão, necessário para criar novas instancias do tipo <see cref="=YoutubeCanal"/>.
        /// </summary>
        public YoutubeCanal()
        {
        }

        /// <summary>
        /// Construtor para criar nova instancia do tipo <see cref="=YoutubeCanal"/>
        /// a partir de um objeto do tipo SearchResult (Google.Apis.YouTube.v3.Data).
        /// </summary>
        /// <param name="item">Objeto de retorno da API do Youtube.</param>
        public YoutubeCanal(SearchResult item) : base(item)
        {
            this.CanalId = item.Snippet.ChannelId;
        }
    }
}