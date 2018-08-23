using System;
using System.Collections.Generic;
using Poi.Data.Repositories;
using Poi.Domain;

namespace Poi.AppServices
{
    public class CityService : ICityService
    {
        public CityService(ICityRepository cityRepository)
        {
            CityRepository = cityRepository;
        }

        public ICityRepository CityRepository { get; }

        public List<City> GetCities()
        {
            return new List<City> {
               new City {  Id= 1, Name = "Oklahoma City", Description = "The capital of Oklahoma", NumberOfPointsOfInterest = 2 }
           };
        }

        public City GetCity(int id)
        {
            return new City { Id = 1, Name = "Oklahoma City", Description = "The capital of Oklahoma", NumberOfPointsOfInterest = 2 };
        }
    }
}
