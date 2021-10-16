using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTestSegfy.Web.Models.Home
{
    public class YoutubeSearchModel
    {
        public YoutubeSearchModel()
        {
            Titles = Enumerable.Empty<string>();
        }

        public string Term { get; set; }
        public IEnumerable<string> Titles { get; set; }
    }
}
