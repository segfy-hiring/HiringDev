using SegFyChallenge.Application.Services;
using SegFyChallenge.Persistence.Repositories;
using SegFyChallenge.Tests.Helpers;
using Xunit;

namespace SegFyChallenge.Tests.Services
{
    public class ChannelServiceTest
    {
        [Fact]
        public async void GetChannelsFromYoutube_Test()
        {
            var repository = new ChannelRepository(ContextFactory.CreateApplicationContext());
            var service = new ChannelService(repository, YoutubeApiClientFactory.Create());
            var channels = await service.GetChannelsFromYoutube("teste");
            var channelsInDatabase = await repository.GetAll();

            Assert.NotNull(channels);
            Assert.NotNull(channelsInDatabase);
            Assert.Equal(channels.Count, channelsInDatabase.Count);
        }

    }
}