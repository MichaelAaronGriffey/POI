using System.Collections.Generic;
using Poi.Data.Repositories;
using Poi.Domain;
using AutoMapper;
using System;

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

        public City GetCity(Guid id)
        {
            var city = CityRepository.GetCity(id);
            var domainCity = Mapper.Map<City>(city);
            return domainCity;
        }

        public List<PointOfInterest> GetPointsOfInterest(Guid cityId)
        {
            var pointsOfInterest = CityRepository.GetPointsOfInterest(cityId);
            var domainPointsOfInterest = Mapper.Map<List<PointOfInterest>>(pointsOfInterest);
            return domainPointsOfInterest;
        }

        public PointOfInterest GetPointOfInterest(Guid cityId, Guid id)
        {
            var pointOfInterest = CityRepository.GetPointOfInterest(cityId, id);
            var domainPointOfInterest = Mapper.Map<PointOfInterest>(pointOfInterest);
            return domainPointOfInterest;
        }

        public PointOfInterest AddPointOfInterest(Guid cityId, PointOfInterest pointOfInterest)
        {
            var pointOfInterestToAdd = Mapper.Map<Data.Entities.PointOfInterest>(pointOfInterest);
            var newPointOfInterest = CityRepository.AddPointOfInterest(cityId, pointOfInterestToAdd);
            var domainPointOfInterest = Mapper.Map<PointOfInterest>(newPointOfInterest);
            return domainPointOfInterest;
        }

        public void UpdatePointOfInterest(Guid cityId, PointOfInterest pointOfInterest)
        {
            var pointOfInterestToUpdate = Mapper.Map<Data.Entities.PointOfInterest>(pointOfInterest);
            CityRepository.UpdatePointOfInterest(cityId, pointOfInterestToUpdate);
        }

        public void DeletePointOfInterest(Guid cityId, Guid id)
        {
            CityRepository.DeletePointOfInterest(cityId, id);
        }
    }
}
