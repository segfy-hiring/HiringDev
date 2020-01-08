namespace WebServices.Core.Repositories
{
    using System;
    using DataContext;
    using Domain.Models;
    using Domain.Repositories;
    using Infra.DataAccess.ORM.Core;

    /// <summary>
    /// Repository of the <see cref="Youtube"/> class.
    /// </summary>
    public class YoutubeDataRepository : BaseRepository<YoutubeData, long, WebServicesDBContext>, IYoutubeDataRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YoutubeDataRepository"/> class.
        /// </summary>
        /// <param name="objContext">Database context.</param>
        public YoutubeDataRepository(WebServicesDBContext objContext)
          : base(objContext)
        {
        }
    }
}