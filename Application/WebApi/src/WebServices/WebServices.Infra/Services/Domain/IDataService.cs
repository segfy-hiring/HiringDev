namespace WebServices.Infra.Services.Domain
{
    using System.Linq;
    using Microsoft.AspNet.OData;

    /// <summary>
    /// Entity services contract
    /// </summary>
    /// <typeparam name="TEntity">Entidade Utilizada no serviço</typeparam>
    /// <typeparam name="IDTYPE">Id type</typeparam>
    public interface IDataService<TEntity, IDTYPE>
        where TEntity : class
    {
        /// <summary>
        /// Get TEntitys by filter.
        /// </summary>
        /// <returns>List of TEntity.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get TEntitys by filter. They won't be cached by System.Data.Entity.DbContext.
        /// </summary>
        /// <returns>List of TEntity.</returns>
        IQueryable<TEntity> GetAllNoTracking();

        /// <summary>
        /// Get TEntity by ID.
        /// </summary>
        /// <param name="id">TEntity Id.</param>
        /// <returns>An <see cref="SingleResult"/>SingleResult Entity.</returns>
        IQueryable<TEntity> GetById(IDTYPE id);

        /// <summary>
        /// Get TEntity by ID. The entity won't be cached by System.Data.Entity.DbContext.
        /// </summary>
        /// <param name="id">Id do TEntity.</param>
        /// <returns>An <see cref="SingleResult"/>SingleResult Entity.</returns>
        IQueryable<TEntity> GetByIdNoTracking(IDTYPE id);

        /// <summary>
        /// Insert new object.
        /// </summary>
        /// <param name="obj">object to be inserted.</param>
        /// <returns>An <see cref="IHttpActionResult"/> of inserted object.</returns>
        TEntity Save(TEntity obj);

        /// <summary>
        /// Update objects.
        /// </summary>
        /// <param name="obj">Object to update.</param>
        /// <returns>An <see cref="IHttpActionResult"/> of updated object.</returns>
        TEntity Patch(Delta<TEntity> obj);

        /// <summary>
        /// Remove <see cref="TEntity"/> object from database.
        /// </summary>
        /// <param name="id">Id of <see cref="TEntity"/></param>
        /// <returns>Deleted entity</returns>		
        TEntity Remove(IDTYPE id);
    }
}
