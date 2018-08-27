using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poi.AppServices;
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
        public IActionResult GetCity(int id)
        {
            try
            {
                var city = CityService.GetCity(id);
                if (city == null)
                {
                    Logger.LogInformation($"City with the id {id} was not found");
                    return NotFound();
                }
                return Ok(city);
            }
            catch (Exception e)
            {
                Logger.LogCritical($"GetCity with the id {id} resulted in an unknown error.", e);
                throw;
            }
        }
    }
}
