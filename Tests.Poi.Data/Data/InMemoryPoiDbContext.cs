using Microsoft.EntityFrameworkCore;
using Poi.Data;

namespace Tests.Poi.Data.Data
{
    public class InMemoryPoiDbContext
    {

        public static PoiDbContext GetPoiDbContext()
        {
            var context = new PoiDbContext(
                new DbContextOptionsBuilder<PoiDbContext>()
                    .UseInMemoryDatabase("POI").Options
            );
            return context;
        }

        public static PoiDbContext GetPoiDbContextSeeded()
        {
            var context = GetPoiDbContext();
            context.Cities.AddRange(PoiDbContextExtension.SeedCities);
            return context;
        }
    }
}
