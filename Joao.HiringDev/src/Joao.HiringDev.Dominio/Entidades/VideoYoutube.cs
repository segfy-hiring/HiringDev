using Joao.HiringDev.Dominio.Core.Interfaces;

namespace Joao.HiringDev.Dominio.Entidades
{
    public class VideoYoutube : IEntidade
    {
        private VideoYoutube()
        {
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ChannelId { get; private set; }
        public string ChannelTitle { get; private set; }
        public string PublishedAtRaw { get; private set; }
        public string LiveBroadcastContent { get; private set; }
        public string ETag { get; private set; }
        public string ThumbnailUrlVideoImage { get; private set; }

        public VideoYoutube(string id, string title, string description, string channelId, string channelTitle, string publishedAtRaw, string liveBroadcastContent, string eTag, string thumbnailUrlVideoImage)
        {
            Id = id;
            Title = title;
            Description = description;
            ChannelId = channelId;
            ChannelTitle = channelTitle;
            PublishedAtRaw = publishedAtRaw;
            LiveBroadcastContent = liveBroadcastContent;
            ETag = eTag;
            ThumbnailUrlVideoImage = thumbnailUrlVideoImage;
        }
    }
}
