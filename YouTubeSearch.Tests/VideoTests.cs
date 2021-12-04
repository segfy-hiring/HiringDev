using AutoFixture;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YouTubeSearch.Application.Commands;
using YouTubeSearch.Application.Handlers;
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Tests
{
    public class VideoTests
    {
        [Fact]
        public async Task ValidGetVideoByIdHandler()
        {
            // Arrange
            var search = new Fixture().Create<GetVideoByIdRequest>();

            var videoRepository = new Mock<IVideoRepository>();

            var getSearchHandler = new GetVideoByIdHandler(videoRepository.Object);

            // Act
            try
            {
                var result = await getSearchHandler.Handle(search, new CancellationToken());

                // Asset
                result.ShouldNotBeNull();
                result.Id.ShouldBeEquivalentTo(search.Id);
            }
            catch (KeyNotFoundException ex)
            {
                ex.Message.ShouldBe("Video not found.");
            }
        }
    }
}
