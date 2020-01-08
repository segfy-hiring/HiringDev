namespace WebServices.Infra.DataAccess.ORM.Domain
{
    using System.Linq;
    using WebServices.Infra.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    /// <typeparam name="IDTYPE">Entity key.</typeparam>
    public interface IRepository<TEntity, IDTYPE>
        where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// Return context.
        /// </summary>
        DbContext Context { get; }

        /// <summary>
        /// Return dataset of <see cref="TEntity"/>.
        /// </summary>
        DbSet<TEntity> DataSet { get; }

        /// <summary>
        /// GetAll objects from repository.
        /// </summary>		       
        /// <returns>List <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Returns a new query where the change tracker will NOT track any of the entities that are returned.
        /// </summary>
        /// <returns>List of entities <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAllNoTracking();

        /// <summary>
        /// Get object by id <see cref="TEntity"/>.
        /// </summary>
        /// <param name="id">The Id</param>
        /// <returns>Entity <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetById(IDTYPE id);

        /// <summary>
        /// Returns a new query where the change tracker will track any of the entities that are returned.
        /// </summary>
        /// <param name="id">entity key</param>
        /// <returns>List of entities</returns>
        IQueryable<TEntity> GetByIdNoTracking(IDTYPE id);

        /// <summary>
        /// Get object by id <see cref="TEntity"/>.
        /// </summary>
        /// <param name="id">The Id</param>
        /// <returns>Find <see cref="TEntity"/></returns>
        TEntity FindById(object id);

        /// <summary>
        /// Insert <see cref="TEntity"/> in database.
        /// </summary>
        /// <param name="obj">Entity to be saved.</param>
        void Insert(TEntity obj);

        /// <summary>
        /// Remove <see cref="TEntity"/> from database.
        /// </summary>
        /// <param name="obj">Entity of <see cref="TEntity"/></param>			
        void Remove(TEntity obj);

        /// <summary>
        /// Save changes in context.
        /// </summary>
        void SaveChanges();
    }
}