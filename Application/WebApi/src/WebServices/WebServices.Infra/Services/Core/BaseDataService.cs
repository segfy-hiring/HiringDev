namespace WebServices.Infra.Services.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.ORM.Domain;
    using Domain;
    using Exceptions;
    using Microsoft.AspNet.OData;
    using Models;

    /// <summary>
    ///  Implementação de serviço de entidades
    /// </summary>
    /// <typeparam name="TEntity">Entidade utilizada no serviço</typeparam>
    /// <typeparam name="IDTYPE">Id type</typeparam>
    /// <typeparam name="TRepository">Repositorio utilizado no servico</typeparam>
    public abstract class BaseDataService<TEntity, IDTYPE, TRepository> : IDataService<TEntity, IDTYPE>
        where TEntity : class, IBaseEntity
        where TRepository : IRepository<TEntity, IDTYPE>
    {
        /// <summary>
        /// Repositorio principal asso ciado 
        /// </summary>
        protected readonly TRepository ObjServiceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseServiceOData"/> class.
        /// </summary>
        /// <param name="objRepository">Repositorio principal</param>
        public BaseDataService(TRepository objRepository)
        {
            ObjServiceRepository = objRepository;
        }

        /// <summary>
        /// Get TEntitys by filter.
        /// </summary>
        /// <returns>List of TEntity.</returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return ObjServiceRepository.GetAll();
        }

        /// <summary>
        /// Get TEntitys by filter. They won't be cached by System.Data.Entity.DbContext.
        /// </summary>
        /// <returns>List of TEntity.</returns>
        public virtual IQueryable<TEntity> GetAllNoTracking()
        {
            return ObjServiceRepository.GetAllNoTracking();
        }

        /// <summary>
        /// Get TEntity by ID.
        /// </summary>
        /// <param name="id">TEntity Id.</param>
        /// <returns>An <see cref="IQueryable"/>TEntity.</returns>
        public virtual IQueryable<TEntity> GetById(IDTYPE id)
        {
            return ObjServiceRepository.GetById(id);
        }

        /// <summary>
        /// Get TEntity by ID. The entity won't be cached by System.Data.Entity.DbContext.
        /// </summary>
        /// <param name="id">Id do TEntity.</param>
        /// <returns>An <see cref="IQueryable"/>TEntity.</returns>
        public virtual IQueryable<TEntity> GetByIdNoTracking(IDTYPE id)
        {
            return ObjServiceRepository.GetByIdNoTracking(id);
        }

        /// <summary>
        /// Insert new object.
        /// </summary>
        /// <param name="obj">object to be inserted.</param>
        /// <returns>An <see cref="TEntity"/> of inserted object.</returns>
        public virtual TEntity Save(TEntity obj)
        {
            var dataBaseEntity = ObjServiceRepository.FindById(obj.Id);
            var isDefaultKey = Equals(obj.Id, default(IDTYPE));

            if (!isDefaultKey && dataBaseEntity == null)
            {
                var exception = new IntegraException(new ValidationInfo(EnumValidationInfo.EntityNotFound.ToString(), "Entidade não encontrada, não foi possivel salvar."));
                exception.Fields.Add(nameof(IBaseEntity.Id), new List<string>
                {
                    string.Format("Entity not found for Id: {0}", obj.Id)
                });

                throw exception;
            }

            if (dataBaseEntity != null)
            {
                ObjServiceRepository.Context.Entry(dataBaseEntity).CurrentValues.SetValues(obj);
            }
            else
            {
                ObjServiceRepository.Insert(obj);
                dataBaseEntity = obj;
            }

            ObjServiceRepository.SaveChanges();

            return dataBaseEntity;
        }

        /// <summary>
        /// Update objects.
        /// </summary>
        /// <param name="obj">Object to update.</param>
        /// <returns>An <see cref="TEntity"/> of updated object.</returns>
        public virtual TEntity Patch(Delta<TEntity> obj)
        {
            var dataBaseEntity = ObjServiceRepository.FindById(obj.GetInstance().Id);

            if (dataBaseEntity == null)
            {
                var exception = new IntegraException(new ValidationInfo(EnumValidationInfo.EntityNotFound.ToString(), "Entidade não encontrada, não foi possivel salvar."));
                exception.Fields.Add(nameof(IBaseEntity.Id), new List<string>
                {
                    string.Format("Entity not found for Id: {0}", obj.GetInstance().Id)
                });

                throw exception;
            }

            obj.Patch(dataBaseEntity);

            ObjServiceRepository.SaveChanges();

            return dataBaseEntity;
        }

        /// <summary>
        /// Remove <see cref="TEntity"/> object from database.
        /// </summary>
        /// <param name="id">Id of <see cref="TEntity"/></param>
        /// <returns>Deleted entity</returns>			
        public virtual TEntity Remove(IDTYPE id)
        {
            var dataBaseEntity = ObjServiceRepository.FindById(id);

            ObjServiceRepository.Remove(dataBaseEntity);

            ObjServiceRepository.SaveChanges();

            return dataBaseEntity;
        }
    }
}