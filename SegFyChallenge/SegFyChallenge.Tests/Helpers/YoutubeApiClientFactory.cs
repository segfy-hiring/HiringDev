using SegFyChallenge.Infra.External.YoutubeApi;

namespace SegFyChallenge.Tests.Helpers
{
    public class YoutubeApiClientFactory
    {
        public static YoutubeApiClient Create()
        {
            var config = ConfigurationFactory.GetConfiguration();
            string apiKey = config.GetSection("YoutubeApiKey").Value;
            return new YoutubeApiClient(apiKey);
        }

    }
}