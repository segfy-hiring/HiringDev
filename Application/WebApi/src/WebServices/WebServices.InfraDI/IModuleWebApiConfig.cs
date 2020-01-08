namespace WebServices.Infra
{
    #region Namespace imports

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    #endregion

    /// <summary>
    ///     Interface to register Autofac autofac modules.
    /// </summary>
    public interface IModuleWebApiConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// Method used in each project to register their components.
        /// </summary>
        /// <param name="container">
        /// autofac (DI)
        /// </param>
        void RegisterWebApi(IConfiguration configuration, IServiceCollection services);

        #endregion
    }
}