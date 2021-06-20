using System;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Tests.Helpers
{
    public class EntitiesFactory
    {
        public static Video CreateVideo()
        {
            return new Video()
            {
                ChannelId = "ChannelId_Test",
                Description = "Description_Test",
                PublishedAt = DateTime.Now,
                Title = "Title_Test",
                VideoId = "VideoId_Test"
            };
        }

        public static Channel CreateChannel()
        {
            return new Channel()
            {
                ChannelId = "ChannelId_Test",
                Description = "Description_Test",
                PublishedAt = DateTime.Now,
                Title = "Title_Test"
            };
        }
    }
}