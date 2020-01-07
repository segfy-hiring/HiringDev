namespace WebServices.API
{
    using System.Linq;
    using HealthChecks.UI.Client;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WebServices.Core.DataContext;
    using WebServices.Domain.Models;
    using WebServices.Domain.Util;
    using WebServices.Infra;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="environment">the environment.</param>
        /// <param name="configuration">the configuration.</param>
        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;

            AppSettingsUtil.SetAppSettingsUtil(configuration);
        }

        /// <summary>
        /// Gets the environment.
        /// </summary>
        public IHostingEnvironment Environment { get; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure the services.
        /// </summary>
        /// <param name="services">the services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            ModuleConfigExtensions.AddAutoRegister<WebServicesDBContext>(services);
            services.AddAutoRegister<NLog.Logger>();

            services.AddDbContext<WebServicesDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("SqlWebServices")));

            services
                .AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("SqlWebServices"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddOData();

            services.AddMvc()
                .AddODataErrorReturn(showDetailedError: Environment.IsDevelopment())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="app">the app builder.</param>
        /// <param name="env">the environment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseErrorReturnExceptionHandler(showDetailedError: Environment.IsDevelopment());

            ODataConventionModelBuilder odataBuilder = new ODataConventionModelBuilder();

            ConfigureEntitySets(odataBuilder);
            ConfigureEntityTypes(odataBuilder);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMvc(b =>
            {
                b.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                b.MapODataServiceRoute("odata", "odata", odataBuilder.GetEdmModel());
            });

            app.UseHealthChecks("/healthz", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }

        /// <summary>
        /// Configure odata entity set.
        /// </summary>
        /// <param name="builder">the odata builder.</param>
        private void ConfigureEntitySets(ODataModelBuilder builder)
        {
            builder.EntitySet<YoutubeData>("YoutubeData").EntityType.HasKey(t => t.Id);
        }

        /// <summary>
        /// Configure odata functions and actions.
        /// </summary>
        /// <param name="builder">the odata builder.</param>
        private void ConfigureEntityTypes(ODataModelBuilder builder)
        {
            var functionSearch = builder.EntityType<YoutubeData>().Collection.Function("Search");
            functionSearch.Parameter<string>("keyword");
            functionSearch.Parameter<int>("type");
            functionSearch.Parameter<string>("pageToken");
            functionSearch.Returns<IActionResult>();

            var functionGetVideoDetail = builder.EntityType<YoutubeData>().Collection.Function("GetVideoDetail");
            functionGetVideoDetail.Parameter<string>("videoId");
            functionGetVideoDetail.Returns<IActionResult>();

            var functionGetChannelDetail = builder.EntityType<YoutubeData>().Collection.Function("GetChannelDetail");
            functionGetChannelDetail.Parameter<string>("channelId");
            functionGetChannelDetail.Returns<IActionResult>();
        }
    }
}