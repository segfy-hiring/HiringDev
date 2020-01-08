namespace WebServices.Infra.DataAccess.ORM.Core
{
    using System.Linq;
    using WebServices.Infra.DataAccess.ORM.Domain;
    using WebServices.Infra.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// BaseRepository.
    /// </summary>
    /// <typeparam name="TEntity">TEntity.</typeparam>
    /// <typeparam name="IDTYPE">IDTYPE.</typeparam>
    /// <typeparam name="TDbContext">TDbContext.</typeparam>
    public abstract class BaseRepository<TEntity, IDTYPE, TDbContext> : IRepository<TEntity, IDTYPE>
        where TEntity : class, IBaseEntity
        where TDbContext : DbContext
    {
        /// <summary>
        /// _databaseSet
        /// </summary>
        private DbSet<TEntity> _databaseSet;

        /// <summary>
        /// BaseRepository
        /// </summary>
        /// <param name="context">context</param>
        public BaseRepository(TDbContext context)
        {
            Context = context;
            _databaseSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Context
        /// </summary>
        public DbContext Context { get; private set; }

        /// <summary>
        /// Retorna a query para entidade <see cref="TEntity"/>.
        /// </summary>
        public DbSet<TEntity> DataSet
        {
            get
            {
                return _databaseSet;
            }
        }

        /// <summary>
        /// Get all objects from databse.
        /// </summary>		       
        /// <returns>Lista de entidades <see cref="TEntity"/></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return DataSet;
        }

        /// <summary>
        /// Returns a new query where the change tracker will NOT track any of the entities that are returned.
        /// </summary>
        /// <returns>List of entities <see cref="TEntity"/></returns>
        public virtual IQueryable<TEntity> GetAllNoTracking()
        {
            return DataSet.AsNoTracking();
        }

        /// <summary>
        /// Get object by id <see cref="TEntity"/>.
        /// </summary>
        /// <param name = "id" >The Id</param>
        /// <returns>Find <see cref="TEntity"/></returns>
        public virtual TEntity FindById(object id)
        {
            return DataSet.Find(id);

        }

        /// <summary>
        /// Returns a new query where the change tracker will track any of the entities that are returned.
        /// </summary>
        /// <param name="id">entity key</param>
        /// <returns>List of entities</returns>
        public virtual IQueryable<TEntity> GetById(IDTYPE id)
        {
            return DataSet.Where(r => r.Id.Equals(id));
        }

        /// <summary>
        /// Returns a new query where the change tracker will NOT track any of the entities that are returned.
        /// </summary>
        /// <param name="id">entity key</param>
        /// <returns>List of entities</returns>
        public virtual IQueryable<TEntity> GetByIdNoTracking(IDTYPE id)
        {
            return DataSet.AsNoTracking().Where(r => r.Id.Equals(id));
        }

        /// <summary>
        /// Insert <see cref="TEntity"/> in database.
        /// </summary>
        /// <param name="obj">Entity to be saved.</param>
        public virtual void Insert(TEntity obj)
        {
            DataSet.Add(obj);
        }

        /// <summary>
        /// Remove <see cref="TEntity"/> from database.
        /// </summary>
        /// <param name="obj">Entity of <see cref="TEntity"/></param>	
        public virtual void Remove(TEntity obj)
        {
            DataSet.Remove(obj);
        }

        /// <summary>
        /// Save changes in context.
        /// </summary>
        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
