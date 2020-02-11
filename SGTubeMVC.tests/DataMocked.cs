using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;

namespace SGTubeMVC.tests
{
    public class DataMocked
    {
        public static SearchListResponse ObterResultadoApiYoutube()
        {
            return new SearchListResponse
            {
                NextPageToken = "TokenNext",
                PrevPageToken = "TokenPrev",
                Items = new List<SearchResult>
                {
                    new SearchResult
                    {
                        Id = new ResourceId
                        {
                            Kind = "youtube#video",
                            VideoId = "y3PXR2WYW2Y"
                        },
                        Snippet = new SearchResultSnippet
                        {
                            Title = "ASP .NET Core - Conceitos Básicos",
                            Description = "Apresentando os conceitos básicos da ASP .NET Core.",
                            PublishedAt = new DateTime(2017,4,16),
                            ChannelTitle =  "Jose Carlos Macoratti",
                            Thumbnails = new ThumbnailDetails
                            {
                                Medium = new Thumbnail
                                {
                                    Url = "https://i.ytimg.com/vi/y3PXR2WYW2Y/mqdefault.jpg",
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
