using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poi.AppServices;
using Poi.Domain;
using System.Linq;

namespace Poi.Api.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        public PointsOfInterestController(ICityService cityService, ILogger<PointsOfInterestController> logger)
        {
            CityService = cityService;
            Logger = logger;
        }

        public ICityService CityService { get; }
        public ILogger<PointsOfInterestController> Logger { get; }

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

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
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

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult PostPointOfInterest(int cityId, [FromBody] PointOfInterest pointOfInterest)
        {

            if (pointOfInterest == null)
                return BadRequest(ModelState);
            if (pointOfInterest?.Name == pointOfInterest?.Description)
                ModelState.AddModelError("Description", "The name may not match the description");
            if ((!ModelState.IsValid))
                return BadRequest(ModelState);

            var city = CityService.GetCity(cityId);
            if (city == null)
                return NotFound();
            var maxId = city.PointsOfInterest.Max(p => p.Id);
            pointOfInterest.Id = ++maxId;
            city.PointsOfInterest.Add(pointOfInterest);

            return CreatedAtRoute(nameof(GetPointOfInterest),
                new { cityId = cityId, id = pointOfInterest.Id },
                pointOfInterest);
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult PutPointOfInterest(int cityId, int id, [FromBody] PointOfInterest pointOfInterest)
        {

            if (pointOfInterest == null)
                return BadRequest(ModelState);
            if (pointOfInterest?.Name == pointOfInterest?.Description)
                ModelState.AddModelError("Description", "The name may not match the description");
            if ((!ModelState.IsValid))
                return BadRequest(ModelState);

            var city = CityService.GetCity(cityId);
            if (city == null)
                return NotFound();
            var pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestToUpdate == null)
                return NotFound();
            pointOfInterestToUpdate = pointOfInterest;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PatchPointOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterest> pointOfInterestPatchDocument)
        {
            if (pointOfInterestPatchDocument == null)
                return BadRequest(ModelState);

            var city = CityService.GetCity(cityId);
            if (city == null)
                return NotFound();
            var pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestToUpdate == null)
                return NotFound();

            pointOfInterestPatchDocument.ApplyTo(pointOfInterestToUpdate, ModelState);
            if (pointOfInterestToUpdate.Id != id)
                ModelState.AddModelError("Id", "Id can not be updated");
            if (pointOfInterestToUpdate.Name == pointOfInterestToUpdate.Description)
                ModelState.AddModelError("Description", "The name may not match the description");
            TryValidateModel(pointOfInterestToUpdate);
            if ((!ModelState.IsValid))
                return BadRequest(ModelState);

            return NoContent();
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CityService.GetCity(cityId);
            if (city == null)
                return NotFound();
            var pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestToUpdate == null)
                return NotFound();
            city.PointsOfInterest.Remove(pointOfInterestToUpdate);
            return NoContent();
        }
    }
}
