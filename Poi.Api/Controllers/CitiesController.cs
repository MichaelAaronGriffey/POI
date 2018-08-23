using Microsoft.AspNetCore.Mvc;
using Poi.AppServices;
using Poi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poi.Api.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        public CitiesController(ICityService cityService)
        {
            CityService = cityService;
        }

        public ICityService CityService { get; }

        public IActionResult GetCities()
        {
            return Ok(CityService.GetCities());
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
