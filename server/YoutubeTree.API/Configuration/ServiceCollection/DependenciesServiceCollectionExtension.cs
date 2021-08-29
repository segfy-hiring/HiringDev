using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutubeTree.Data;
using YoutubeTree.Domain;

namespace YoutubeTree.API
{
    public static class DependenciesServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            services.AddSingleton(provider => {
                return new YouTubeService(
                    new Google.Apis.Services.BaseClientService.Initializer
                    {
                        ApiKey = configuration.GetValue<string>("Youtube:ApiKey")
                    }
                );
            });

            return services;
        }
    }
}