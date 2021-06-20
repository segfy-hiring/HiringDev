using SegFyChallenge.Application.Services;
using SegFyChallenge.Persistence.Repositories;

namespace SegFyChallenge.Tests.Helpers
{
    public class ServicesFactory
    {
        public static VideoService CreateVideoService()
        {
            var repository = new VideoRepository(ContextFactory.CreateApplicationContext());
            var youtubeApiClient = YoutubeApiClientFactory.Create();
            return new VideoService(repository, youtubeApiClient);
        }

        public static ChannelService CreateChannelService()
        {
            var repository = new ChannelRepository(ContextFactory.CreateApplicationContext());
            var youtubeApiClient = YoutubeApiClientFactory.Create();
            return new ChannelService(repository, youtubeApiClient);
        }
    }
}