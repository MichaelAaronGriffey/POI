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

        public IEnumerable<City> GetCities()
        {
            return CityService.GetCities();
        }

        [HttpGet("{id}")]
        public City GetCity(int id)
        {
            return CityService.GetCity(id);
        }
    }
}
