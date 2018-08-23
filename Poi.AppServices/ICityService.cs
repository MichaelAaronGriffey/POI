using Poi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poi.AppServices
{
    public interface ICityService
    {
        List<City> GetCities();
        City GetCity(int id);
    }
}
