using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using YoutubeTree.API;

namespace YoutubeTree.Tests
{
    public class BaseTest
    {
        public TestServer CreateServer()
        {
            var webhost =  new WebHostBuilder()
                .ConfigureAppConfiguration(config => 
                {
                    config.AddInMemoryCollection(CreateInMemoryConfig());
                })
                .UseStartup<Startup>();
            
            var testServer = new TestServer(webhost);

            return testServer;
        }

        private IDictionary<string, string> CreateInMemoryConfig()
        {
            return new Dictionary<string, string>
            {
                { "Database:Memory", "true" }
            };
        }
    }
}