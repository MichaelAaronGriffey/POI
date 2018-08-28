using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poi.AppServices;
using Poi.Data.Exceptions.CityExceptions;
using Poi.Domain;
using System;

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
        public IActionResult GetPointsOfInterest(Guid cityId)
        {
            try
            {
                var pointsOfInterest = CityService.GetPointsOfInterest(cityId);
                return Ok(pointsOfInterest);
            }
            catch (CityNotFoundException e)
            {
                var message = $"City with the id of {cityId} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(Guid cityId, Guid id)
        {
            try
            {
                var pointOfInterest = CityService.GetPointOfInterest(cityId, id);
                if (pointOfInterest == null)
                    return NotFound();
                return Ok(pointOfInterest);
            }
            catch (CityNotFoundException e)
            {
                var message = $"City with the id of {cityId} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult PostPointOfInterest(Guid cityId, [FromBody] PointOfInterest pointOfInterest)
        {

            if (pointOfInterest == null)
                return BadRequest(ModelState);
            if ((!ModelState.IsValid))
                return BadRequest(ModelState);
            try
            {
                var newPointOfInterest = CityService.AddPointOfInterest(cityId, pointOfInterest);
                return CreatedAtRoute(nameof(GetPointOfInterest),
                    new { cityId = cityId, id = newPointOfInterest.Id },
                    newPointOfInterest);
            }
            catch (CityNotFoundException e)
            {
                var message = $"City with the id of {cityId} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult PutPointOfInterest(Guid cityId, Guid id, [FromBody] PointOfInterest pointOfInterest)
        {

            if (pointOfInterest == null || id != pointOfInterest.Id)
                return BadRequest(ModelState);
            if ((!ModelState.IsValid))
                return BadRequest(ModelState);

            try
            {
                CityService.UpdatePointOfInterest(cityId, pointOfInterest);
                return NoContent();
            }
            catch (CityNotFoundException e)
            {
                var message = $"City with the id of {cityId} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
            catch (PointOfInterestNotFoundException e)
            {
                var message = $"City with the id of {cityId} with a Point of Interests with the id of {id} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(Guid cityId, Guid id)
        {
            try
            {
                CityService.DeletePointOfInterest(cityId, id);
                return NoContent();
            }
            catch (CityNotFoundException e)
            {
                var message = $"City with the id of {cityId} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
            catch (PointOfInterestNotFoundException e)
            {
                var message = $"City with the id of {cityId} with a Point of Interests with the id of {id} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
        }
    }
}
