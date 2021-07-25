namespace Joao.HiringDev.Apresentacao.Models.Home
{
    public class VideoYoutubeViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public string PublishedAtRaw { get; set; }
        public string LiveBroadcastContent { get; set; }
        public string ETag { get; set; }
        public string ThumbnailUrlVideoImage { get; set; }

        public VideoYoutubeViewModel(string id, string title, string description, string channelId, string channelTitle, string publishedAtRaw, string liveBroadcastContent, string eTag, string thumbnailUrlVideoImage)
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

        public VideoYoutubeViewModel() { }
    }
}
