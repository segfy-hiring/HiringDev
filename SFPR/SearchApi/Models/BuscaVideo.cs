using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SearchApi.Models
{
    public class BuscaVideo
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Minimum length")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int BuscaId { get; set; }
        public Busca Busca { get; set; }
    }
}