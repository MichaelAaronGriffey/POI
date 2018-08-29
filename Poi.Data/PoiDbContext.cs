using Microsoft.EntityFrameworkCore;
using Poi.Data.Entities;

namespace Poi.Data
{
    public class PoiDbContext : DbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<PointOfInterest> PointsOfInterest { get; set; }

        public PoiDbContext(DbContextOptions<PoiDbContext> options): base(options)
        {
            //Database.Migrate();
        }
    }
}
