using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poi.AppServices;
using Poi.Data.Exceptions.CityExceptions;
using Poi.Domain;
using System;
using System.Collections.Generic;

namespace Poi.Api.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        public CitiesController(ICityService cityService, ILogger<CitiesController> logger)
        {
            CityService = cityService;
            Logger = logger;
        }

        public ICityService CityService { get; }
        public ILogger<CitiesController> Logger { get; }

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            var cities = CityService.GetCities();
            return Ok(cities);
        }

        /// <summary>
        /// Gets the City by id
        /// </summary>
        /// <param name="id">the unique id of the City</param>
        /// <param name="includePointsOfInterest">if the points of interest should be included</param>
        /// <returns>The City</returns>
        /// <example>Get /api/cities/51D8DE60-5CCE-46DB-BECC-D6B5E1EF75F6</example>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<City> GetCity(Guid id, bool includePointsOfInterest = false)
        {
            try
            {
                var city = CityService.GetCity(id, includePointsOfInterest);
                return Ok(city);
            }
            catch (CityNotFoundException e)
            {
                Logger.LogInformation($"City with the id {id} was not found", e);
                return NotFound(e.Message);
            }
        }

        [HttpGet("ThrowError")]
        public ActionResult ThrowError()
        {
            try
            {
                throw new Exception("There has been an error intentionally thrown");
            }
            catch (Exception e)
            {
                Logger.LogCritical($"ThowError resulted in an unknown error.", e);
                return StatusCode(500, e.Message);
            }
        }

    }
}
