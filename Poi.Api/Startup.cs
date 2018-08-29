using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Poi.AppServices;
using Poi.Data.Repositories;
using AutoMapper;
using Poi.AppServices.AutoMapper;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Poi.Data.Repositories.InMemory;
using Microsoft.Extensions.Configuration;
using Poi.Data;
using Microsoft.EntityFrameworkCore;

namespace Poi.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICityService, CityService>();
/*
#if DEBUG
            services.AddSingleton<ICityRepository, InMemoryCityRepository>();
#else
            services.AddTransient<ICityRepository, CityRepository>();
#endif
*/
            services.AddTransient<ICityRepository, InMemoryCityRepository>();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<PoiDbContext>(
            //    o => o.UseSqlServer(connectionString)
            //);

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
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddNLog();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<POIProfile>();
            });

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvc();
        }
    }
}
