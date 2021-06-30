using System.ComponentModel.DataAnnotations.Schema;

namespace YoutubeApiConsumerApp.Models
{
    [Table("Video")]
    public class YoutubeVideoModel
    {
        [Column("Id")]
        public string Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("ChannelId")]
        public string ChannelId { get; set; }

        [Column("ChannelTitle")]
        public string ChannelTitle { get; set; }

        [Column("PublishedAtRaw")]
        public string PublishedAtRaw { get; set; }

        [Column("LiveBroadcastContent")]
        public string LiveBroadcastContent { get; set; }

        [Column("ETag")]
        public string ETag { get; set; }

        [Column("ThumbnailUrlVideoImage")]
        public string ThumbnailUrlVideoImage { get; set; }

    }
}
