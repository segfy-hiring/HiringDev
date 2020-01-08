namespace WebServices.Domain.Services
{
    using Infra.Services.Domain;
    using Models;
    using WebServices.Domain.YoutubeData.Enums;

    /// <summary>
    /// Service interface of the <see cref="YoutubeData"/> entity.
    /// </summary>
    public interface IYoutubeDataService : IDataService<YoutubeData, long>
    {
        /// <summary>
        /// Search and Get Youtube Results.
        /// </summary>
        /// <param name="keyword">word to be searached.</param>
        /// <param name="searchType">type of search.</param>
        /// <param name="pageToken">Page token.</param>
        /// <returns>Youtube object with pages and items list.</returns>
        Youtube Search(string keyword, YoutubeSearchType searchType, string pageToken);

        /// <summary>
        /// Get video details.
        /// </summary>
        /// <param name="videoId">youtube id video.</param>
        /// <returns>YoutubeDataDetail video detail.</returns>
        YoutubeDataDetail GetVideoDetail(string videoId);

        /// <summary>
        /// Get channel details.
        /// </summary>
        /// <param name="channelId">youtube id channel.</param>
        /// <returns>YoutubeDataDetail video detail.</returns>
        YoutubeDataDetail GetChannelDetail(string channelId);
    }
}