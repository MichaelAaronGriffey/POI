using Poi.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Poi.Data.Data
{
    public static class CityGuids
    {
        public static IEnumerable<object[]> ValidCityGuids => PoiDbContextExtension.SeedCities.Select(c => new object[] { c.Id });

        public static IEnumerable<object[]> InValidCityGuids => new List<object[]> {
            new object[] { Guid.Empty },
            new object[] { new Guid("11111111-1111-1111-1111-111111111111") }
        };
    }


}
