namespace WebServices.Infra
{
    using Microsoft.Extensions.DependencyInjection;
    using NetCore.AutoRegisterDi;

    /// <summary>
    /// Module configuration extension.
    /// </summary>
    public static class ModuleConfigExtensions
    {

        /// <summary>
        /// Auto register classes ended with Repository and Service.
        /// </summary>
        /// <typeparam name="T">Any class from the assembly that will be registerd.</typeparam>
        /// <param name="services">Services collection</param>
        public static void AddAutoRegister<T>(this IServiceCollection services)
        {
            services.AddAutoRegister<T>("Repository");
            services.AddAutoRegister<T>("Service");
            services.AddAutoRegister<T>("Provider");            
        }

        /// <summary>
        /// Registro automatico para injeção de dependencia das classes Repository, Service e WebApiControllers.
        /// </summary>
        /// <param name="classesEndedWith">the sufix to be searched.</param>
        /// <param name="container">container autofac.</param>
        /// <param name="assembly">assembly com os dados.</param>
        public static void AddAutoRegister<T>(this IServiceCollection services, string classesEndedWith)
        {
            services.RegisterAssemblyPublicNonGenericClasses(typeof(T).Assembly)
                .Where(c => c.Name.EndsWith(classesEndedWith))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }

    }
}