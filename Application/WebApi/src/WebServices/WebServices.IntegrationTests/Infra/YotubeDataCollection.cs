namespace WebServices.IntegrationTests
{
    using WebServices.Domain.Models;

    /// <summary>
    /// YotubeDataCollection, save data to use in other tests.
    /// </summary>
    public static class YotubeDataCollection
    {
        /// <summary>
        /// YoutubeVideos.
        /// </summary>
        public static Youtube YoutubeVideos { get; set; }

        /// <summary>
        /// YoutubeChannels.
        /// </summary>
        public static Youtube YoutubeChannels { get; set; }
    }
}
