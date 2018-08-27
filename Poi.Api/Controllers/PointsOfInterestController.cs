using Microsoft.AspNetCore.Mvc;
using Poi.AppServices;
using System.Linq;

namespace Poi.Api.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        public PointsOfInterestController(ICityService cityService)
        {
            CityService = cityService;
        }

        public ICityService CityService { get; }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CityService.GetCity(cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsofinterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CityService.GetCity(cityId);
            if (city == null)
                return NotFound();
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
                return NotFound();
            return Ok(pointOfInterest);
        }
    }
}
