using AutoFixture;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
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
    public class ChannelTests
    {
        [Fact]
        public async Task ValidGetChannelByIdHandler()
        {
            // Arrange
            var search = new Fixture().Create<GetChannelByIdRequest>();

            var channelRepository = new Mock<IChannelRepository>();

            var getSearchHandler = new GetChannelByIdHandler(channelRepository.Object);

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
                ex.Message.ShouldBe("Channel not found.");
            }

        }
    }
}
