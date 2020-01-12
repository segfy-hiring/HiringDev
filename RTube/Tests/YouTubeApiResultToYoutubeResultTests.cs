using Microsoft.VisualStudio.TestTools.UnitTesting;
using RTube.Models.Result;
using System;
using System.Linq;
using static Tests.Data.MockData;

namespace Tests
{
    [TestClass]
    public class YouTubeApiResultToYoutubeResultTests
    {
        [TestMethod]
        public void ConvertToToYoutubeResult()
        {
            var apiResult = GetYouTubeApiResult();
            var result = new YouTubeResult(apiResult);

            Assert.AreEqual("CAUQAA", result.NextPageToken);
            Assert.AreEqual("bAUQAA", result.PrevPageToken);

            var itemsArray = result.Items.ToArray();

            Assert.AreEqual("Kurzgesagt – In a Nutshell", itemsArray[0].ChannelTitle);
            Assert.AreEqual("The Egg Story by Andy Weir Animated by Kurzgesagt A Big Thanks to Andy Weir for allowing us to use his story. The original was released here: ...", itemsArray[0].Description);
            Assert.AreEqual("h6fcK_fRYaI", itemsArray[0].Id);
            Assert.AreEqual("youtube#video", itemsArray[0].Kind);
            Assert.AreEqual(new DateTime(2019, 9, 1), itemsArray[0].PublishedAt);
            Assert.AreEqual("https://i.ytimg.com/vi/h6fcK_fRYaI/mqdefault.jpg", itemsArray[0].Thumbnail);
            Assert.AreEqual("The Egg - A Short Story", itemsArray[0].Title);
        }

        
    }
}
