using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using YoutubeTree.Application;

namespace YoutubeTree.Tests
{
    public class SubscriptionTest : BaseTest
    {
        [Fact]
        public async Task Post_New_Subscription()
        {
            using (var server = CreateServer())
            {
                var client = server.CreateClient();

                var response = await client.PostAsJsonAsync(
                    "api/v1/subscriptions",
                    new SubscriptionRequest
                    {                                                
                        YoutubeId = "1",
                        Title = ".Net Core",
                        Description = "Criando um aplicativo com .NET Core API",
                        Type = "video",
                        PublishedAt = DateTime.Now,
                        DefaultThumbnail = "https://cdn.com/default",
                        MediumThumbnail = "https://cdn.com/medium",
                        HighThumbnail = "https://cdn.com/high"
                    }
                );

                Assert.Equal(200, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task Get_All_Subscription()
        {
            using(var server = CreateServer())
            {
                var client = server.CreateClient();
                var response = await client.GetFromJsonAsync<List<SubscriptionViewModel>>(
                    "api/v1/subscriptions"
                );

                Assert.Equal("1", response[0].YoutubeId);
            }
        }
    }
}