using System.Collections.Generic;

namespace YoutubeApiConsumerApp.Models
{
    public class SearchResponseModel
    {   
        public List<YoutubeVideoModel> _youtubeVideos { get; set; }

        public List<YoutubeChannelModel> _youtubeChannels { get; set; }

        public SearchResponseModel(List<YoutubeVideoModel> youtubeVideos, List<YoutubeChannelModel> youtubeChannels)
        {
            _youtubeVideos   = youtubeVideos;
            _youtubeChannels = youtubeChannels;
        }        

    }
}
