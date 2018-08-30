using Poi.Data.Repositories.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poi.Data
{
    public static class PoiDbContextExtension
    {
        public static void EnsureSeedDataForContext(this PoiDbContext context)
        {
            if (!context.Cities.Any())
            {
                var list = InMemoryCityRepository.Cities;
                context.Cities.AddRange(list);
                context.SaveChanges();
            }
        }
    }
}
