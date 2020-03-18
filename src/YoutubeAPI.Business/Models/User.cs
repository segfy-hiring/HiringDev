using System;
using System.Collections.Generic;

namespace YoutubeAPI.Business.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public List<Favorite> Favorites { get; set; }
    }
}
