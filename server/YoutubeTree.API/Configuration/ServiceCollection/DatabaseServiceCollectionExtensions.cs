using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeTree.Data;

namespace YoutubeTree.API
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var isInMemoryDatabase = configuration.GetValue<bool>("Database:Memory");

            if (isInMemoryDatabase)
            {
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("YoutubeTreeMemory");
                });
            }
            else
            {
                var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
                
                services.AddDbContext<DataContext>(
                    options => {
                        options.UseNpgsql(
                            configuration.GetValue<string>("Database:Connection"),
                            sql => sql.MigrationsAssembly(migrationsAssembly)
                        ).UseLowerCaseNamingConvention();
                    }
                );
            }

            return services;
        }
    }
}