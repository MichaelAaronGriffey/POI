using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poi.AppServices;
using Poi.Data.Exceptions.CityExceptions;
using System;

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

        public IActionResult GetCities()
        {
            var cities = CityService.GetCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(Guid id)
        {
            try
            {
                var city = CityService.GetCity(id);
                return Ok(city);
            }
            catch (CityNotFoundException e)
            {
                Logger.LogInformation($"City with the id {id} was not found", e);
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Logger.LogCritical($"GetCity with the id {id} resulted in an unknown error.", e);
                throw;
            }
        }

        [HttpGet("ThrowError")]
        public IActionResult ThrowError()
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
