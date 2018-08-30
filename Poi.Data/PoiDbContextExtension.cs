using Poi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poi.Data
{
    public static class PoiDbContextExtension
    {
        public static ICollection<City> SeedCities { get; } = new List<City> {
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
        public static void EnsureSeedDataForContext(this PoiDbContext context)
        {
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(SeedCities);
                context.SaveChanges();
            }
        }
    }
}
