using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SegFyChallenge.Application.Interfaces.Infra;
using SegFyChallenge.Application.Interfaces.Persistence;
using SegFyChallenge.Application.Interfaces.Services;
using SegFyChallenge.Application.Services;
using SegFyChallenge.Infra.External.YoutubeApi;
using SegFyChallenge.Persistence.Contexts;
using SegFyChallenge.Persistence.Repositories;

namespace SegFyChallenge.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SegFyChallenge.WebApi", Version = "v1" });
            });

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SegFyChallengeDb"));
            });

            services.AddScoped<ApplicationContext>();
            services.AddScoped<IYoutubeApiClient>(d => new YoutubeApiClient(Configuration.GetSection("YoutubeApiKey").Value));
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IChannelRepository, ChannelRepository>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<IChannelService, ChannelService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SegFyChallenge.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
