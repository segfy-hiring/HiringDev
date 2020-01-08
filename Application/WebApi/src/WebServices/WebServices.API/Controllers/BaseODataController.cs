namespace WebServices.API.Controllers
{
    using System.Linq;
    using Infra.Models;
    using Infra.Services.Domain;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNet.OData.Routing;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The base odata controller.
    /// </summary>
    /// <typeparam name="TEntity">Entity used on service.</typeparam>
    /// <typeparam name="TService">Service used on controller.</typeparam>
    /// <typeparam name="TIDTYPE">Id type.</typeparam>
    public abstract class BaseODataController<TEntity, TService, TIDTYPE> : ODataController
            where TService : IDataService<TEntity, TIDTYPE>
            where TEntity : class, IBaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseODataController{TEntity, TService, IDTYPE}"/> class.
        /// </summary>
        /// <param name="objTService">the service.</param>
        protected BaseODataController(TService objTService)
        {
            ObjService = objTService;
        }

        /// <summary>
        /// Gets or sets Service of controller.
        /// </summary>
        protected TService ObjService { get; set; }

        /// <summary>
        /// Get TEntitys by filter.
        /// </summary>
        /// <returns>List of TEntity.</returns>
        [HttpGet]
        [EnableQuery(MaxNodeCount = 36556, HandleNullPropagation = HandleNullPropagationOption.False)]
        public virtual IQueryable<TEntity> Get()
        {
            return ObjService.GetAllNoTracking();
        }

        /// <summary>
        /// Obter TEntity Por ID.
        /// </summary>
        /// <param name="id">Id do TEntity.</param>
        /// <returns>An <see cref="SingleResult"/>SingleResult Entity.</returns>
        [HttpGet]
        [ODataRoute("({id})")]
        [EnableQuery(MaxNodeCount = 36556, HandleNullPropagation = HandleNullPropagationOption.False, MaxExpansionDepth = 15)]
        public virtual SingleResult<TEntity> Get([FromODataUri] TIDTYPE id)
        {
            return SingleResult.Create(ObjService.GetByIdNoTracking(id));
        }

        /// <summary>
        /// Insert new object.
        /// </summary>
        /// <param name="obj">object to be inserted.</param>
        /// <returns>An <see cref="IHttpActionResult"/> of inserted object.</returns>
        [HttpPost]
        [ODataRoute("")]
        public virtual IActionResult Post([FromBody] TEntity obj)
        {
            return Ok(ObjService.Save(obj));
        }

        /// <summary>
        /// Update objects.
        /// </summary>
        /// <param name="obj">Object to update.</param>
        /// <returns>An <see cref="IHttpActionResult"/> of updated object.</returns>
        [HttpPut]
        [ODataRoute("")]
        public virtual IActionResult Put([FromBody] TEntity obj)
        {
            return Ok(ObjService.Save(obj));
        }

        /// <summary>
        /// Update object attriutes.
        /// </summary>
        /// <param name="obj">Object to be updated.</param>
        /// <returns>An <see cref="IHttpActionResult"/> of updated object.</returns>
        [HttpPatch]
        [ODataRoute("")]
        public virtual IActionResult Patch([FromBody] Delta<TEntity> obj)
        {
            return Ok(ObjService.Patch(obj));
        }

        /// <summary>
        /// Delete object.
        /// </summary>
        /// <param name="id">Object Id to be deleted.</param>
        /// <returns>An <see cref="IHttpActionResult"/> with result.</returns>
        [HttpDelete]
        [ODataRoute("({id})")]
        public virtual IActionResult Delete([FromODataUri] TIDTYPE id)
        {
            return Ok(ObjService.Remove(id));
        }
    }
}