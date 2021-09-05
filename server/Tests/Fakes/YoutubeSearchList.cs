using System;
using System.Collections.Generic;
using YoutubeTree.Infra.YoutubeService;

namespace YoutubeTree.Tests
{
    public static class YoutubeSearchList
    {
        public static List<YoutubeResponse> GetFakeList()
        {
            return new List<YoutubeResponse>
            {
                new YoutubeResponse("dK4Yb6-LxAk", "video", "Clean Architecture with ASP.NET Core 3.0 • Jason Taylor • GOTO 2019",
                    "This presentation was recorded at GOTO Copenhagen 2019. #GOTOcon #GOTOcph http://gotocph.com Jason Taylor - Solution Architect at SSW ABSTRACT ...",
                    DateTime.Parse("2020-04-21T09:00:13-03:00"), "https://i.ytimg.com/vi/dK4Yb6-LxAk/default.jpg", "https://i.ytimg.com/vi/dK4Yb6-LxAk/mqdefault.jpg", "https://i.ytimg.com/vi/dK4Yb6-LxAk/hqdefault.jpg",
                    "CBQQAA"
                )
            };
        }
    }
}