using Poi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using System;
using System.Collections;
using System.Collections.Generic;
using Poi.Data.Repositories;
using Tests.Poi.Data.Data;

namespace Tests.Poi.Data
{
    public class CityRepository_CityExists
    {

        [Theory]
        [MemberData(nameof(CityGuids.ValidCityGuids), MemberType = typeof(CityGuids))]
        public void ReturnsTrueForExisting(Guid id)
        {
            var context = InMemoryPoiDbContext.GetPoiDbContextSeeded();
            var repo = new CityRepository(context);
            Assert.True(repo.CityExists(id));
        }

        [Theory]
        [MemberData(nameof(CityGuids.InValidCityGuids), MemberType = typeof(CityGuids))]
        public void ReturnsFalseForNotExisting(Guid id)
        {
            var context = InMemoryPoiDbContext.GetPoiDbContextSeeded();
            var repo = new CityRepository(context);
            Assert.False(repo.CityExists(id));
        }
    }
    
}
