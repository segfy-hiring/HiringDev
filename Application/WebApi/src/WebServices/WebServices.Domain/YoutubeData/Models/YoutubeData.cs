namespace WebServices.Domain.Models
{
    using System;
    using Infra.Models;

    /// <summary>
    /// YoutubeData.
    /// </summary>
    public class YoutubeData : BaseEntity<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeData"/> class.
        /// </summary>
        public YoutubeData()
        {
            PublishedAt = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets VideoId.
        /// </summary>
        public virtual string VideoId { get; set; }

        /// <summary>
        /// Gets or sets ChannelId.
        /// </summary>
        public virtual string ChannelId { get; set; }

        /// <summary>
        /// Gets or sets PublishedAt.
        /// </summary>
        public virtual DateTime? PublishedAt { get; set; }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets ChannelTitle.
        /// </summary>
        public virtual string ChannelTitle { get; set; }

        /// <summary>
        /// Gets or sets ThumbnailUrl.
        /// </summary>
        public virtual string ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        public virtual int? Type { get; set; }
    }
}