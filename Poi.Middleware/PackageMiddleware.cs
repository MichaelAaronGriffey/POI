using Microsoft.Extensions.DependencyInjection;
using Poi.Middleware.Models;
using System;
using System.IO;
using System.Reflection;

namespace Poi.Middleware
{
    public static class PackageMiddleware
    {
        public static IServiceCollection AddPackageInfo(this IServiceCollection services)
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            var id = entryAssembly?.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
            var version = entryAssembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            var company = entryAssembly?.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
            var product = entryAssembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
            var description = entryAssembly?.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
            var copyright = entryAssembly?.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
            var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{id}.xml");

            var packageInfo = new PackageInfo
            {
                Assembly = entryAssembly,
                Id = id,
                Version = version,
                Company = company,
                Product = product,
                Description = description,
                Copyright = copyright,
                XMLComents = xmlPath,
            };
            services.AddSingleton<PackageInfo>(packageInfo);
            return services;
        }
    }
}
