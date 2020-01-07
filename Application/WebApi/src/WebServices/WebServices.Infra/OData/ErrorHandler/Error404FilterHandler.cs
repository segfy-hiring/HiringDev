namespace WebServices.Infra.OData.ErrorHandler
{
    using WebServices.Infra.ErrorHandler;
    using WebServices.Infra.Exceptions;
    using WebServices.Infra.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Error404FilterHandler.
    /// </summary>
    public class Error404FilterHandler : ResultFilterAttribute
    {
        /// <summary>
        /// OnResultExecuting.
        /// </summary>
        /// <param name="context">context.</param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            ///Whether any ODataController throw a 404 result, return an error return
            if (context.Controller is Microsoft.AspNet.OData.ODataController && context.Result as StatusCodeResult != null && (context.Result as StatusCodeResult).StatusCode == 404)
            {
                var error = new ErrorReturn("Entity not found");
                error.Message = new ValidationInfo(EnumValidationInfo.EntityNotFound.ToString(), "Entity not found");
                context.Result = new JsonResult(error, new JsonSerializerSettings() { ContractResolver = new DefaultContractResolver() });
            }
            else
            {
                base.OnResultExecuting(context);
            }
        }
    }
}
