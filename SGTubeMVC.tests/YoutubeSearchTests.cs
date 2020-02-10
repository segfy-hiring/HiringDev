using Google.Apis.YouTube.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SGTubeMVC.Youtube;
using System;
using static SGTubeMVC.tests.DataMocked;

namespace SGTubeMVC.tests
{
    [TestClass]
    public class YoutubeSearchTests
    {
        [TestMethod]
        public void ValidaResultadoApiYoutube()
        {
            var apiResult = ObterResultadoApiYoutube();

            Assert.AreEqual("TokenNext", apiResult.NextPageToken);
            Assert.AreEqual("TokenPrev", apiResult.PrevPageToken);

            var items = apiResult.Items;

            Assert.AreEqual("youtube#video", items[0].Id.Kind);
            Assert.AreEqual("y3PXR2WYW2Y", items[0].Id.VideoId);
            Assert.AreEqual("ASP .NET Core - Conceitos Básicos", items[0].Snippet.Title);
            Assert.AreEqual("Apresentando os conceitos básicos da ASP .NET Core.", items[0].Snippet.Description);
            Assert.AreEqual(new DateTime(2017, 4, 16), items[0].Snippet.PublishedAt);
            Assert.AreEqual("Jose Carlos Macoratti", items[0].Snippet.ChannelTitle);
            Assert.AreEqual("https://i.ytimg.com/vi/y3PXR2WYW2Y/mqdefault.jpg", items[0].Snippet.Thumbnails.Medium.Url);
        }
    }
}
