using System.Collections.Generic;
using Poi.Data.Repositories;
using Poi.Domain;
using AutoMapper;
using System;
using Poi.Data.Exceptions.CityExceptions;

namespace Poi.AppServices
{
    public class CityService : ICityService
    {
        public CityService(ICityRepository cityRepository)
        {
            CityRepository = cityRepository;
        }

        public ICityRepository CityRepository { get; }

        public bool CityExists(Guid id)
        {
            return CityRepository.CityExists(id);
        }

        public List<City> GetCities()
        {
            var cities = CityRepository.GetCities();
            var domainCities = Mapper.Map<List<City>>(cities);
            return domainCities;
        }

        public City GetCity(Guid id, bool includePointsOfInterest)
        {
            var city = CityRepository.GetCity(id, includePointsOfInterest);
            var domainCity = Mapper.Map<City>(city);
            return domainCity;
        }

        public List<PointOfInterest> GetPointsOfInterest(Guid cityId)
        {
            if (!CityExists(cityId))
                throw new CityNotFoundException();
            var pointsOfInterest = CityRepository.GetPointsOfInterest(cityId);
            var domainPointsOfInterest = Mapper.Map<List<PointOfInterest>>(pointsOfInterest);
            return domainPointsOfInterest;
        }

        public PointOfInterest GetPointOfInterest(Guid cityId, Guid id)
        {
            if (!CityExists(cityId))
                throw new CityNotFoundException();
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
            if (!CityExists(cityId))
                throw new CityNotFoundException();
            var pointOfInterestToUpdate = Mapper.Map<Data.Entities.PointOfInterest>(pointOfInterest);
            CityRepository.UpdatePointOfInterest(cityId, pointOfInterestToUpdate);
        }

        public void DeletePointOfInterest(Guid cityId, Guid id)
        {
            if (!CityExists(cityId))
                throw new CityNotFoundException();
            CityRepository.DeletePointOfInterest(cityId, id);
        }
    }
}
