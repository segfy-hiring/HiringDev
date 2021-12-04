using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouTubeSearch.Application.Handlers;
using YouTubeSearch.Core.Repositories;
using YouTubeSearch.Infrastructure;
using YouTubeSearch.Infrastructure.Repositories;
using YouTubeSearch.Infrastructure.Repositories.Base;
using YouTubeSearch.Core.Repositories.Base;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YoutTubeSearch.API.Helpers;

namespace YoutTubeSearch
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
            //services.AddControllers();
            services.AddSpaStaticFiles(options => options.RootPath = "client-app/dist");

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            var connection = Configuration["ConexaoMySql:MySqlConnectionString"];

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(connection, serverVersion)
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "YouTubeSearcher.API",
                    Version = "v1"
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateVideoHandler).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<IChannelRepository, ChannelRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YoutTubeSearch v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("AllowMyOrigin");
            app.UseMvc();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                    spa.UseVueDevelopmentServer();
            });
        }
    }
}
