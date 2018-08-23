using Poi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poi.Data.Repositories
{
    public interface ICityRepository
    {
        List<City> GetCities();
        City GetCity();
    }
}
