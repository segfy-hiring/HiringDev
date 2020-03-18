using System.Collections.Generic;

namespace YoutubeAPI.Business.Models
{
    public class Pagination
    {
        public Pagination()
        {
            this.Favorites = new List<Favorite>();
        }

        public string Search { get; set; }

        public string NextPage { get; set; }

        public List<Favorite> Favorites { get; set; }
    }
}
