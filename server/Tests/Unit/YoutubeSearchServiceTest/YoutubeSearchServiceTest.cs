using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using YoutubeTree.Application;
using YoutubeTree.Domain;
using YoutubeTree.Infra.YoutubeService;

namespace YoutubeTree.Tests
{
    public class YoutubeSearchServiceTest
    {
        private readonly Subscription _fakeSubscription;
        public YoutubeSearchServiceTest()
        {
            _fakeSubscription = new Subscription(
                "db_85924u52j45u5",
                "video",
                "ASP.NET Core Test",
                "ASP.NET Core Web App description",
                new DateTime(2020, 3, 30),
                "https://fake.cdn.com/default",
                "https://fake.cdn.com/medium",
                "https://fake.cdn.com/high"
            );
        }

        [Fact]
        public async Task Should_Merge_Youtube_And_Database_Data()
        {
            var respository = new SubscriptionFakeRepository();
            await respository.Create(_fakeSubscription);
            
            var youtubeList = YoutubeSearchList.GetFakeList();
            var searchService = new YoutubeSearchService(
                new YoutubeFakeService(youtubeList),
                respository
            );

            var result = await searchService.Search(".net core");
            var databaseItem = result.Data.Where(s => s.YoutubeId == "db_85924u52j45u5").FirstOrDefault();
            var youtubeItem = result.Data.Where(s => s.YoutubeId == youtubeList[0].Id).FirstOrDefault();

            Assert.Equal(2, result.Data.Count());
            Assert.Equal("db_85924u52j45u5", databaseItem.YoutubeId);
            Assert.NotNull(youtubeItem);
        }

        [Fact]
        public async Task Should_Merge_Youtube_With_No_Database_Item()
        {
            var respository = new SubscriptionFakeRepository();
            var youtubeList = YoutubeSearchList.GetFakeList();
            var searchService = new YoutubeSearchService(
                new YoutubeFakeService(youtubeList),
                respository
            );

            var result = await searchService.Search(".net core");
            var youtubeItem = result.Data.Where(s => s.YoutubeId == youtubeList[0].Id).FirstOrDefault();

            Assert.True(result.Data.Count() == 1);
            Assert.NotNull(youtubeItem);
        }

        [Fact]
        public async Task Should_Merge_Database_With_No_Youtube_Item()
        {
            var respository = new SubscriptionFakeRepository();
            await respository.Create(_fakeSubscription);
            
            var searchService = new YoutubeSearchService(
                new YoutubeFakeService(new List<YoutubeResponse>()),
                respository
            );

            var result = await searchService.Search(".net core");
            var databaseItem = result.Data.Where(s => s.YoutubeId == "db_85924u52j45u5").FirstOrDefault();

            Assert.True(result.Data.Count() == 1);
            Assert.Equal("db_85924u52j45u5", databaseItem.YoutubeId);
        }

        [Fact]
        public async Task Should_Remove_Duplicate_Items()
        {
            var youtubeList = YoutubeSearchList.GetFakeList();
            var respository = new SubscriptionFakeRepository();
            await respository.Create(_fakeSubscription);
            
            // Duplica o Registro do youtube no Banco
            await respository.Create(new Subscription(
                youtubeList[0].Id,
                youtubeList[0].Type,
                youtubeList[0].Title,
                youtubeList[0].Description,
                youtubeList[0].PublishedAt,
                youtubeList[0].DefaultThumbnail,
                youtubeList[0].MediumThumbnail,
                youtubeList[0].HighThumbnail
            ));
                        
            var searchService = new YoutubeSearchService(
                new YoutubeFakeService(youtubeList),
                respository
            );

            var result = await searchService.Search(".net core");
            var databaseItem = result.Data.Where(s => s.YoutubeId == "db_85924u52j45u5").FirstOrDefault();
            var youtubeItem = result.Data.Where(s => s.YoutubeId == youtubeList[0].Id).FirstOrDefault();

            Assert.Equal(2, result.Data.Count());
        }
    }
}