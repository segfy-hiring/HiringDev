using System.ComponentModel.DataAnnotations;

namespace YoutubeApiConsumerApp.Models
{
    public class SearchModel
    {
        [Required]
        public string KeyWord { get; set; }
    }
}
