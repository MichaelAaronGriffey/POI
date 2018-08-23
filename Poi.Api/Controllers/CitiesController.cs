using Microsoft.AspNetCore.Mvc;
using Poi.AppServices;

namespace Poi.Api.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        public CitiesController(ICityService cityService)
        {
            CityService = cityService;
        }

        public ICityService CityService { get; }

        public IActionResult GetCities()
        {
            var cities = CityService.GetCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = CityService.GetCity(id);
            if (city == null)
                return NotFound();
            return Ok(city);
        }
    }
}
