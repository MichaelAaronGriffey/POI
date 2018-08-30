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
        public ActionResult<IEnumerable<PointOfInterest>> GetPointsOfInterest(Guid cityId)
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
        public ActionResult<PointOfInterest> GetPointOfInterest(Guid cityId, Guid id)
        {
            try
            {
                var pointOfInterest = CityService.GetPointOfInterest(cityId, id);
                return Ok(pointOfInterest);
            }
            catch (PointOfInterestNotFoundException e)
            {
                var message = $"City with the id of {cityId} with a Point of Interests with the id of {id} was not found.";
                return NotFound(message);
            }
            catch (CityNotFoundException e)
            {
                var message = $"City with the id of {cityId} was not found.";
                Logger.LogInformation(message, e);
                return NotFound(message);
            }
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public ActionResult<PointOfInterest> PostPointOfInterest(Guid cityId, [FromBody] PointOfInterest pointOfInterest)
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
            catch(PointOfInterestPersistanceException e)
            {
                Logger.LogCritical(e.Message, e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public ActionResult PutPointOfInterest(Guid cityId, Guid id, [FromBody] PointOfInterest pointOfInterest)
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
        public ActionResult DeletePointOfInterest(Guid cityId, Guid id)
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
