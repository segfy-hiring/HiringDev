using System;

namespace SkillTestSegfy.Infrastructure.Services.Youtube
{
    public enum YoutubeItemType
    {
        Unknown, Video, Channel, Playlist
    }

    public class YoutubeItem
    {
        public YoutubeItemType Type { get; internal set; }
        public string Id { get; internal set; }
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public string ThumbnailUrl { get; internal set; }

        public string GetUrl()
        {
            return Type switch
            {
                YoutubeItemType.Video => $"https://www.youtube.com/watch?v={Id}",
                YoutubeItemType.Channel => $"https://www.youtube.com/channel/{Id}",
                YoutubeItemType.Playlist => $"https://www.youtube.com/playlist?list={Id}",

                _ => throw new InvalidOperationException($"Type '{Type}' does not have a case."),
            };
        }
    }
}
