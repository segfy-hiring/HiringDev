using AutoFixture;
using Moq;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YouTubeSearch.Application.Handlers;
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Tests
{
    public class SearchTests
    {
        [Fact]
        public async Task ValidGetSearchResultFIlteredHandler()
        {
            // Arrange
            var search = new Fixture().Create<GetSearchResultFilteredRequest>();

            var videoRepository = new Mock<IVideoRepository>();
            var channelRepository = new Mock<IChannelRepository>();

            var getSearchHandler = new GetSearchResultFIlteredHandler(videoRepository.Object, channelRepository.Object);

            // Act
            var result = await getSearchHandler.Handle(search, new CancellationToken());

            // Assert
            result.Page.ShouldBe(search.Page);
            result.PageSize.ShouldBe(search.PageSize);
            result.Total.ShouldBeGreaterThanOrEqualTo(result.Results.Count());
            result.Results.ShouldNotBeNull();
        }
    }
}
