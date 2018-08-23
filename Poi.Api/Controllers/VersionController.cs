using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;


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
