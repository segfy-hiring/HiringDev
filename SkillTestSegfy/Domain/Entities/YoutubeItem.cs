using System;

namespace SkillTestSegfy.Domain.Entities
{
    public class YoutubeItem
    {
        protected YoutubeItem() { }
        public YoutubeItem(DateTime searchDateTime, YoutubeItemType type, string id, string title, string description, string thumbnailUrl)
        {
            SearchDateTime = searchDateTime;
            Type = type;
            YoutubeId = id;
            Title = title;
            Description = description;
            ThumbnailUrl = thumbnailUrl;
        }

        public virtual int Id { get; private set; }
        public virtual DateTime SearchDateTime { get; private set; }

        public virtual YoutubeItemType Type { get; private set; }
        public virtual string YoutubeId { get; private set; }
        public virtual string Title { get; private set; }
        public virtual string Description { get; private set; }
        public virtual string ThumbnailUrl { get; private set; }

        public void UpdateFrom(YoutubeItem item)
        {
            SearchDateTime = item.SearchDateTime;
            Title = item.Title;
            Description = item.Description;
            ThumbnailUrl = item.ThumbnailUrl;
        }

        public string GetUrl()
        {
            return Type switch
            {
                YoutubeItemType.Video => $"https://www.youtube.com/watch?v={YoutubeId}",
                YoutubeItemType.Channel => $"https://www.youtube.com/channel/{YoutubeId}",
                YoutubeItemType.Playlist => $"https://www.youtube.com/playlist?list={YoutubeId}",

                _ => throw new InvalidOperationException($"Type '{Type}' does not have a case."),
            };
        }
    }
}
