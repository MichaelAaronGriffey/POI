using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poi.Data;

namespace Poi.Middleware
{
    public static class PoiDbContextMiddleware
    {
        public static IServiceCollection AddPoiDbContext(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddDbContext<PoiDbContext>(
                    o => o.UseInMemoryDatabase("POI")
                );
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<PoiDbContext>(
                    o => o.UseSqlServer(connectionString)
                );
            }

            return services;
        }
    }
}
