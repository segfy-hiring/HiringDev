using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.DependencyInjection;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Services;
using YoutubeAPI.Data.Context;
using YoutubeAPI.Data.Repositories;

namespace YoutubeApi.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, string apikey)
        {
            services.AddScoped<YoutubeAPIContext>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IYoutubeSeachService, YoutubeSeachService>();

            services.AddSingleton(s => new YouTubeService(
                new BaseClientService.Initializer()
                {
                    ApiKey = apikey
                }));

            return services;
        }
    }
}
