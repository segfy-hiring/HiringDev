namespace WebServices.Domain.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Youtube Class to retrieve data.
    /// </summary>
    public class Youtube
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Youtube"/> class.
        /// </summary>
        public Youtube()
        {
            YoutubeData = new List<YoutubeData>();
        }

        /// <summary>
        /// Gets or sets next Page.
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// Gets or sets previous page.
        /// </summary>
        public string PreviousPage { get; set; }

        /// <summary>
        /// Gets or sets youtubeData List o Videos or Channel.
        /// </summary>
        public IList<YoutubeData> YoutubeData { get; set; }
    }
}