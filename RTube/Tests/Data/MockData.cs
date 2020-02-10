using RTube.Models;
using RTube.Models.Result;
using System;
using System.Collections.Generic;

namespace Tests.Data
{
    public static class MockData
    {
        public static IEnumerable<YouTubeItem> GetItems()
        {
            return GetYouTubeResult().Items;
        }

        public static YouTubeResult GetYouTubeResult()
        {
            var apiResult = GetYouTubeApiResult();
            return new YouTubeResult(apiResult);
        }

        public static YouTubeApiResult GetYouTubeApiResult()
        {
            return new YouTubeApiResult
            {
                nextPageToken = "CAUQAA",
                prevPageToken = "bAUQAA",
                items = new List<Item>
                {
                    new Item
                    {
                        id = new Id
                        {
                            kind = "youtube#video",
                            videoId = "h6fcK_fRYaI"
                        },
                        snippet = new Snippet
                        {
                            title = "The Egg - A Short Story",
                            description = "The Egg Story by Andy Weir Animated by Kurzgesagt A Big Thanks to Andy Weir for allowing us to use his story. The original was released here: ...",
                            publishedAt = new DateTime(2019,9,1),
                            channelTitle =  "Kurzgesagt – In a Nutshell",
                            thumbnails = new Thumbnails
                            {
                                medium = new Medium
                                {
                                    url = "https://i.ytimg.com/vi/h6fcK_fRYaI/mqdefault.jpg",
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
