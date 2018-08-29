using System;
using System.Collections.Generic;
using System.Linq;
using Poi.Data.Entities;
using Poi.Data.Exceptions.CityExceptions;

namespace Poi.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        public CityRepository(PoiDbContext context)
        {
            Context = context;
        }
        public PoiDbContext Context { get; }

        public ICollection<City> Cities { get; } = new List<City> {
               new City {
                    Id = new Guid("51D8DE60-5CCE-46DB-BECC-D6B5E1EF75F6"),
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest {
                            Id = new Guid("6F4DE0F7-5C01-4FD1-B55A-B292C9F2C369"),
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States." },
                        new PointOfInterest {
                            Id = new Guid("9678E698-F96C-475A-B7DB-482B918C3747"),
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattan." },
                    }
               },
               new City {
                    Id = Guid.NewGuid(),
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Id = Guid.NewGuid(),
                             Name = "Cathedral of Our Lady",
                             Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans." },
                          new PointOfInterest() {
                             Id = Guid.NewGuid(),
                             Name = "Antwerp Central Station",
                             Description = "The the finest example of railway architecture in Belgium." },
                     }
               },
               new City {
                    Id= Guid.NewGuid(),
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterest>()
                     {
                         new PointOfInterest() {
                             Id = Guid.NewGuid(),
                             Name = "Eiffel Tower",
                             Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel." },
                          new PointOfInterest() {
                             Id = Guid.NewGuid(),
                             Name = "The Louvre",
                             Description = "The world's largest museum." },
                     }
               },
        };

        public List<City> GetCities()
        {
            return Cities.ToList();
        }

        public City GetCity(Guid id)
        {
            var city = GetCities().FirstOrDefault(m => m.Id == id);
            if (city == null)
                throw new CityNotFoundException();
            return city;
        }

        public PointOfInterest GetPointOfInterest(Guid cityId, Guid id)
        {
            var city = GetCity(cityId);
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
                throw new PointOfInterestNotFoundException();
            return pointOfInterest;
        }

        public List<PointOfInterest> GetPointsOfInterest(Guid cityId)
        {
            var city = GetCity(cityId);
            var pointsOfInterest = city.PointsOfInterest.ToList();
            return pointsOfInterest;
        }

        public PointOfInterest AddPointOfInterest(Guid cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId);
            city.PointsOfInterest.Add(pointOfInterest);
            return pointOfInterest;
        }

        public void UpdatePointOfInterest(Guid cityId, PointOfInterest pointOfInterest)
        {
            var originalPointOfInterest = GetPointOfInterest(cityId, pointOfInterest.Id);
            originalPointOfInterest = pointOfInterest;
        }

        public void DeletePointOfInterest(Guid cityId, Guid id)
        {
            var pointOfInterest = GetPointOfInterest(cityId, id);
            var city = GetCity(cityId);
            city.PointsOfInterest.Remove(pointOfInterest);
        }
    }
}
