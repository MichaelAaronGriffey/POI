using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Poi.AppServices;
using Poi.Data.Repositories;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Poi.AppServices.AutoMapper;
using Poi.Middleware;
using Poi.Middleware.Services;

namespace Poi.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICityRepository, CityRepository>();

            services.AddPoiDbContext(Configuration, Environment);

            services.AddServicePolicyRegistry();
            var gitHubUri = Configuration.GetValue<string>("GitHub:uri");
            services.AddGitHubService(gitHubUri);

            services.AddPackageInfo();
            services.AddSwagger();

            services.AddMvc()
                .AddMvcOptions(o =>
                {
                    o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                })
                .AddJsonOptions(o =>
                {
                    if (o.SerializerSettings.ContractResolver != null)
                    {
                        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                        castedResolver.NamingStrategy = null;
                    }
                })
                ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////loggerFactory.AddNLog();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<POIProfile>();
            });

            app.UseMySwagger();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
