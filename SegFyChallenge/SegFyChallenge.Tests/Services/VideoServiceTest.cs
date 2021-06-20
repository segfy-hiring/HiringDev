using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Application.Services;
using SegFyChallenge.Persistence.Repositories;
using SegFyChallenge.Tests.Helpers;
using Xunit;

namespace SegFyChallenge.Tests.Services
{
    public class VideoServiceTest
    {
        [Fact]
        public async void GetVideosFromYoutube_Test()
        {
            var repository = new VideoRepository(ContextFactory.CreateApplicationContext());
            var service = new VideoService(repository, YoutubeApiClientFactory.Create());
            var videos = await service.GetVideosFromYoutube("teste");
            var videosInDatabase = await repository.GetAll();

            Assert.NotNull(videos);
            Assert.NotNull(videosInDatabase);
            Assert.Equal(videos.Count, videosInDatabase.Count);
        }

    }
}