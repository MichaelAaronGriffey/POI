﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Poi.Middleware.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Poi.Middleware
{
    public static class SwaggerMiddleware
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var packageInfo = services.BuildServiceProvider().GetService<PackageInfo>();
            var swaggerInfo = new Info
            {
                Title = packageInfo.Product,
                Version = packageInfo.Version,
                Description = packageInfo.Description
            };
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", swaggerInfo);
                o.IncludeXmlComments(packageInfo.XMLComents);
            });
            return services;
        }

        public static IApplicationBuilder UseMySwagger(this IApplicationBuilder app)
        {
            var packageInfo = app.ApplicationServices.GetService<PackageInfo>();
            var product = $"{packageInfo.Product} v{packageInfo.Version}";
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", product);

            });
            return app;
        }
    }
}
