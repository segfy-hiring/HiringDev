namespace WebServices.Domain.Models
{
    /// <summary>
    /// YoutubeDataDetail.
    /// </summary>
    public class YoutubeDataDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeDataDetail"/> class.
        /// </summary>
        public YoutubeDataDetail()
        {
        }

        /// <summary>
        /// Gets or sets EmbedHtml.
        /// </summary>
        public string EmbedHtml { get; set; }

        /// <summary>
        /// Gets or sets ViewCount.
        /// </summary>
        public long ViewCount { get; set; }

        /// <summary>
        /// Gets or sets LikeCount.
        /// </summary>
        public long LikeCount { get; set; }

        /// <summary>
        /// Gets or sets DislikeCount.
        /// </summary>
        public long DislikeCount { get; set; }

        /// <summary>
        /// Gets or sets SubscriberCount.
        /// </summary>
        public long SubscriberCount { get; set; }

        /// <summary>
        /// Gets or sets VideoCount.
        /// </summary>
        public long VideoCount { get; set; }

        /// <summary>
        /// Gets or sets detail Type (1 - Channel, 2 - Video).
        /// </summary>
        public int Type { get; set; }
    }
}