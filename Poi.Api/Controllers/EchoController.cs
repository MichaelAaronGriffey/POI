using Microsoft.AspNetCore.Mvc;

namespace Poi.Api.Controllers
{
    [Route("[controller]")]
    public class EchoController: Controller
    {
        [HttpGet("{input}")]
        public string Get(string input)
        {
            return $"Echo:{input}";
        }
    }
}
