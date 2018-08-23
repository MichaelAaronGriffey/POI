using System;
using System.Collections.Generic;
using System.Linq;
using Poi.Data.Entities;

namespace Poi.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        public List<City> GetCities()
        {
           return new List<City> {
               new City {  Id= 1, Name = "Oklahoma City", Description = "The capital of Oklahoma" }
           };
        }

        public City GetCity(int id)
        {
            return GetCities().FirstOrDefault(m => m.Id == id);
        }
    }
}
