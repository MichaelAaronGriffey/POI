using Poi.Data.Entities;
using System;
using System.Collections.Generic;

namespace Poi.Data.Repositories
{
    public interface ICityRepository
    {
        /// <summary>
        /// Gets a list of the cities
        /// </summary>
        /// <returns>The cities</returns>
        List<City> GetCities();

        /// <summary>
        /// Gets the City by id
        /// </summary>
        /// <param name="id">the unique id of the City</param>
        /// <returns>The City</returns>
        City GetCity(Guid id);

        /// <summary>
        /// Gets the Points of Interest related to the City
        /// </summary>
        /// <param name="cityId">The unique id of the City</param>
        /// <returns>The Points Of Interest related to the City.</returns>
        /// <exception cref="CityNotFoundException">Thrown when the City is not found.</exception>
        List<PointOfInterest> GetPointsOfInterest(Guid cityId);

        /// <summary>
        /// Gets the Points of Interest related to the City
        /// </summary>
        /// <param name="cityId">The unique id of the City</param>
        /// <param name="id">The unique id of the Point of interest</param>
        /// <returns>A Point Of Interest related to the City.</returns>
        /// <exception cref="CityNotFoundException">Thrown when the City is not found.</exception>
        PointOfInterest GetPointOfInterest(Guid cityId, Guid id);

        /// <summary>
        /// Adds a new Point of Interest
        /// </summary>
        /// <param name="cityId">The unique id of the City</param>
        /// <param name="pointOfInterest">The Point of Interest to add</param>
        /// <returns>The new Point of Interest</returns>
        /// <exception cref="CityNotFoundException">Thrown when the City is not found.</exception>
        PointOfInterest AddPointOfInterest(Guid cityId, PointOfInterest pointOfInterest);

        /// <summary>
        /// Updates a Point of Interest
        /// </summary>
        /// <param name="cityId">The unique id of the City</param>
        /// <param name="pointOfInterest">The Point of Interest to Update</param>
        /// <exception cref="CityNotFoundException">Thrown when the City is not found.</exception>
        /// <exception cref="PointOfInterestNotFoundException">Thrown when the Point of interest is not found.</exception>
        void UpdatePointOfInterest(Guid cityId, PointOfInterest pointOfInterest);

        /// <summary>
        /// Deletes the Points of Interest related to the City
        /// </summary>
        /// <param name="cityId">The unique id of the City</param>
        /// <param name="id">The unique id of the Point of interest</param>
        /// <exception cref="CityNotFoundException">Thrown when the City is not found.</exception>
        /// <exception cref="PointOfInterestNotFoundException">Thrown when the Point of interest is not found.</exception>
        void DeletePointOfInterest(Guid cityId, Guid id);
    }
}
