using System;
using System.Threading.Tasks;
using Google;
using SegFyChallenge.Application.Dto;
using SegFyChallenge.Application.Interfaces.Infra;
using SegFyChallenge.Infra.External.YoutubeApi;
using SegFyChallenge.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace SegFyChallenge.Tests.Infra
{
    public class YoutubeApiTest
    {
        private readonly string _apikey;

        public YoutubeApiTest()
        {
            var configuration = ConfigurationFactory.GetConfiguration();
            _apikey = configuration.GetSection("YoutubeApiKey").Value;
        }

        [Fact]
        public async Task Search_DefaultMaxResults_TestAsync()
        {
            var youtubeApi = new YoutubeApiClient(_apikey);
            var response = await youtubeApi.Search("C# Course", 5, SearchType.Both);

            Assert.NotNull(response);
            Assert.Equal(response.Count, 5);
        }

        [Fact]
        public async Task Search_MaxResults_15_TestAsync()
        {
            var youtubeApi = new YoutubeApiClient(_apikey);
            var response = await youtubeApi.Search("C# Course", 15, SearchType.Both);

            Assert.NotNull(response);
            Assert.Equal(response.Count, 15);
        }

        [Fact]
        public async Task Search_MissingApiKeyFail_TestAsync()
        {
            var youtubeApi = new YoutubeApiClient("");

            await Assert.ThrowsAsync<GoogleApiException>(async () => {
                var response = await youtubeApi.Search("C# Course", 15, SearchType.Both);
            });
        }

        [Fact]
        public async Task Search_OnlyVideos_TestAsync()
        {
            var youtubeApi = new YoutubeApiClient(_apikey);
            var response = await youtubeApi.Search("C# Course", 50, SearchType.Video);

            Assert.NotNull(response);
            Assert.All(response, item => Assert.Equal(item.Kind, YoutubeItemKind.Video));

        }
        
        [Fact]
        public async Task Search_OnlyChannels_TestAsync()
        {
            var youtubeApi = new YoutubeApiClient(_apikey);
            var response = await youtubeApi.Search("C# Course", 50, SearchType.Channel);

            Assert.NotNull(response);
            Assert.All(response, item => Assert.Equal(item.Kind, YoutubeItemKind.Channel));

        }
    }
}