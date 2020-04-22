using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchApi.Models
{
    public class Busca
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Minimum length")]
        public List<BuscaVideo> Videos { get; set; }
        public List<BuscaChannel> Channels { get; set; }

        public Busca()
        {
            Videos = new List<BuscaVideo>();
            Channels = new List<BuscaChannel>();
        }

        public bool IsEmpty()
        {
            return this.Videos.Count == 0 && this.Channels.Count == 0;
        }
    }
}