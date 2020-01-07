namespace WebServices.IntegrationTests
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using WebServices.API;
    using WebServices.Domain.Models;
    using WebServices.IntegrationTests.Infra;
    using Xunit;

    /// <summary>
    /// Test Class to test the main operation services
    /// </summary>
    [TestCaseOrderer("WebServices.IntegrationTests.PriorityOrderer", "WebServices.IntegrationTests")]
    public class YoutubeDataTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> objFactory;

        /// <summary>
        /// Setup bootstrap server
        /// </summary>
        /// <param name="factory">factory for bootstraping</param>
        public YoutubeDataTest(WebApplicationFactory<Startup> factory)
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            objFactory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, conf) =>
                {
                    conf.AddJsonFile(configPath);
                });

            });
        }

        /// <summary>
        /// Test get list of videos on youtube using YoutubeAPIV3 and saves in database.
        /// </summary>
        [Fact, TestPriority(1)]
        public void SearchYoutubeVideoTest()
        {
            var client = objFactory.CreateClient();

            var requestMessage = new HttpRequestMessage(new HttpMethod("GET"),
               string.Format("/odata/YoutubeData/Search(keyword='{0}',type={1}, pageToken='{2}')", "Dragon Ball Z", 2, string.Empty));

            var response = client.SendAsync(requestMessage).Result;

            response.EnsureSuccessStatusCode();

            var stringResponse = response.Content.ReadAsStringAsync().Result;

            var youtube = JsonConvert.DeserializeObject<Youtube>(stringResponse);
            
            YotubeDataCollection.YoutubeVideos = youtube;
            
            Assert.Equal(50, youtube.YoutubeData.Count());
        }

        /// <summary>
        /// Test get list of videos on youtube using pagination.
        /// </summary>
        [Fact, TestPriority(2)]
        public void SearchYoutubeVideoByPageTest()
        {
            // Arrange
            var client = objFactory.CreateClient();

            var requestMessage = new HttpRequestMessage(new HttpMethod("GET"),
                string.Format("/odata/YoutubeData/Search(keyword='{0}',type={1}, pageToken='{2}')", "Dragon Ball Z", 2, YotubeDataCollection.YoutubeVideos.NextPage));

            var response = client.SendAsync(requestMessage).Result;

            response.EnsureSuccessStatusCode();

            var stringResponse = response.Content.ReadAsStringAsync().Result;

            var youtube = JsonConvert.DeserializeObject<Youtube>(stringResponse);

            Assert.Equal(50, youtube.YoutubeData.Count());
        }

        /// <summary>
        /// Test get list of channels on youtube using YoutubeAPIV3 and saves in database.
        /// </summary>
        [Fact, TestPriority(3)]
        public void SearchYoutubeChannelTest()
        {
            // Arrange
            var client = objFactory.CreateClient();

            var requestMessage = new HttpRequestMessage(new HttpMethod("GET"),
                string.Format("/odata/YoutubeData/Search(keyword='{0}',type={1}, pageToken='{2}')", "Dragon Ball Z", 1, string.Empty));

            var response = client.SendAsync(requestMessage).Result;

            response.EnsureSuccessStatusCode();

            var stringResponse = response.Content.ReadAsStringAsync().Result;

            var youtubeChannels = JsonConvert.DeserializeObject<Youtube>(stringResponse);

            YotubeDataCollection.YoutubeChannels = youtubeChannels;

            Assert.Equal(50, youtubeChannels.YoutubeData.Count());
        }

        /// <summary>
        /// Test get video details by Id.
        /// </summary>
        [Fact, TestPriority(4)]
        public void GetYoutubeVideoByIdTest()
        {
            // Arrange
            var client = objFactory.CreateClient();

            var requestMessage = new HttpRequestMessage(new HttpMethod("GET"),
                string.Format("/odata/YoutubeData/GetVideoDetail(videoId='{0}')", YotubeDataCollection.YoutubeVideos.YoutubeData.FirstOrDefault().VideoId));

            var response = client.SendAsync(requestMessage).Result;

            response.EnsureSuccessStatusCode();

            var stringResponse = response.Content.ReadAsStringAsync().Result;

            var youtubeDetail = JsonConvert.DeserializeObject<YoutubeDataDetail>(stringResponse);

            Assert.NotNull(youtubeDetail);
        }

        /// <summary>
        /// Test get channel details by id
        /// </summary>
        [Fact, TestPriority(5)]
        public void GetYoutubeChannelByIdTest()
        {
            // Arrange
            var client = objFactory.CreateClient();

            var requestMessage = new HttpRequestMessage(new HttpMethod("GET"),
                string.Format("/odata/YoutubeData/GetChannelDetail(channelId='{0}')", YotubeDataCollection.YoutubeChannels.YoutubeData.FirstOrDefault().ChannelId));

            var response = client.SendAsync(requestMessage).Result;

            response.EnsureSuccessStatusCode();

            var stringResponse = response.Content.ReadAsStringAsync().Result;

            var youtubeDetail = JsonConvert.DeserializeObject<YoutubeDataDetail>(stringResponse);

            Assert.NotNull(youtubeDetail);
        }

        /// <summary>
        /// Test get youtube data from database.
        /// </summary>
        [Fact, TestPriority(6)]
        public void GetAllYoutubeDataTest()
        {
            // Arrange
            var client = objFactory.CreateClient();

            var requestMessage = new HttpRequestMessage(new HttpMethod("GET"), "/odata/YoutubeData");

            var response = client.SendAsync(requestMessage).Result;

            response.EnsureSuccessStatusCode();

            var stringResponse = response.Content.ReadAsStringAsync().Result;

            var odataResult = JsonConvert.DeserializeObject<OdataResult>(stringResponse);        

            Assert.True(odataResult.Value.Count() > 0);
        }
    }
}
