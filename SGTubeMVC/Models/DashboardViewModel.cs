using Google.Apis.YouTube.v3.Data;
using SGTubeMVC.Mongo.Models;
using System.Collections.Generic;

namespace SGTubeMVC.Models
{
    public class DashboardViewModel
    {
        public string search { get; set; }
        public IEnumerable<Post> history { get; set; }
        public string historyClick { get; set; }
        public IEnumerable<SearchResult> videos { get; set; }
        public IEnumerable<SearchResult> channels { get; set; }
        public IEnumerable<SearchResult> playlists { get; set; }
    }
}
