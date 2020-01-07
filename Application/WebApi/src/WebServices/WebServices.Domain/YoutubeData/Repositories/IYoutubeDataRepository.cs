namespace WebServices.Domain.Repositories
{
    using Infra.DataAccess.ORM.Domain;
    using Models;

    /// <summary>
    /// Repository interface of the <see cref="YoutubeData"/> entity.
    /// </summary>
    public interface IYoutubeDataRepository : IRepository<YoutubeData, long>
    {
    }
}