namespace WebServices.Infra
{
    using WebServices.Infra.OData.ErrorHandler;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extensions.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Auto register classes ended with Repository and Service
        /// </summary>
        /// <typeparam name="T">the object from assembly</typeparam>
        /// <param name="services">Services collection</param>
        public static IMvcBuilder AddODataErrorReturn(this IMvcBuilder mvcBuilder, bool showDetailedError)
        {
            return mvcBuilder.AddMvcOptions(options =>
            {
                options.Filters.Add(new Error404FilterHandler());
                options.OutputFormatters.Insert(0, new ErrorReturnODataOutputFormatter(showDetailedError));
            });
        }
    }
}