using System.Collections.Generic;
using Poi.Data.Repositories;
using Poi.Domain;
using AutoMapper;

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
            var cities = CityRepository.GetCities();
            var domainCities = Mapper.Map<List<City>>(cities);
            return domainCities;
        }

        public City GetCity(int id)
        {
            var city = CityRepository.GetCity(id);
            var domainCity = Mapper.Map<City>(city);
            return domainCity;
        }
    }
}
