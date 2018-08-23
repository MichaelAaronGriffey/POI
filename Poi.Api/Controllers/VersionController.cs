using Microsoft.AspNetCore.Mvc;


namespace Poi.Api.Controllers
{
    [Route("[controller]")]
    public class VersionController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "1.0.0.0";
        }
    }
}
