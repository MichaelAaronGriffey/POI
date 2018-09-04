using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poi.Middleware
{
    public static class SwaggerMiddleware
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string title)
        {
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Info { Title = title, Version = "v1" });
            });
            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, string title)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", title);
                c.RoutePrefix = "swagger";
            });
            return app;
        }
    }
}
