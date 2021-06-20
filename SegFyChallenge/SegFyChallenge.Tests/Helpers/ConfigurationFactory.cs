using Microsoft.Extensions.Configuration;

namespace SegFyChallenge.Tests.Helpers
{
    public class ConfigurationFactory
    {
        public static IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            
            return config;
        }
    }
}