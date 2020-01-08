namespace WebServices.API.Controllers
{
    using System;
    using Domain.Models;
    using Domain.Services;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NLog;
    using WebServices.Domain.YoutubeData.Enums;

    /// <summary>
    /// Api controller of the <see cref="YoutubeData"/> entity.
    /// </summary>
    [ODataRoutePrefix("YoutubeData")]
    public class YoutubeDataController : BaseODataController<YoutubeData, IYoutubeDataService, long>
    {
        private readonly ILogger objLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeDataController"/> class.
        /// </summary>
        /// <param name="objYoutubeDataService">YoutubeDataService.</param>
        /// <param name="logger">logger</param>
        public YoutubeDataController(IYoutubeDataService objYoutubeDataService)
                : base(objYoutubeDataService)
        {
            objLogger = NLogHelper.GetLogger();
        }

        /// <summary>
        /// Search video ou channels.
        /// </summary>
        /// <param name="keyword">keyword.</param>
        /// <param name="type">1 - Channel,2 - Video.</param>
        /// <param name="pageToken">Page Token for navigation.</param>
        /// <returns>List of youtube data.</returns>
        [HttpGet]
        [ODataRoute("Search(keyword={keyword}, type={type}, pageToken={pageToken})")]
        public IActionResult Search(string keyword, int type, string pageToken)
        {
            objLogger.Info($"Request: /Search(keyword={keyword}, type={type}, pageToken={pageToken})");

            try
            {
                var youtube = ObjService.Search(keyword, (YoutubeSearchType)type, pageToken);

                return Ok(youtube);
            }
            catch (Exception ex)
            {
                objLogger.Error(ex, $"/Search(keyword={keyword}, type={type}, pageToken={pageToken})");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get video details.
        /// </summary>
        /// <param name="videoId">Youtube video Id.</param>
        /// <returns>Detail from video.</returns>
        [HttpGet]
        [ODataRoute("GetVideoDetail(videoId={videoId})")]
        public IActionResult GetVideoDetail(string videoId)
        {
            objLogger.Info($"Request: GetVideoDetail(videoId={videoId})");

            try
            {
                var youtube = ObjService.GetVideoDetail(videoId);

                return Ok(youtube);
            }
            catch (Exception ex)
            {
                objLogger.Error(ex, $"GetVideoDetail(videoId={videoId})");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get channel details.
        /// </summary>
        /// <param name="channelId">Youtube channel Id.</param>
        /// <returns>Detail from channel.</returns>
        [HttpGet]
        [ODataRoute("GetChannelDetail(channelId={channelId})")]
        public IActionResult GetChannelDetail(string channelId)
        {
            objLogger.Info($"Request: GetChannelDetail(channelId={channelId})");

            try
            {
                var youtube = ObjService.GetChannelDetail(channelId);

                return Ok(youtube);
            }
            catch (Exception ex)
            {
                objLogger.Error(ex, $"GetChannelDetail(channelId={channelId})");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}