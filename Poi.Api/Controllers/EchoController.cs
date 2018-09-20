using Microsoft.AspNetCore.Mvc;

namespace Poi.Api.Controllers
{
    /// <summary>
    /// A controller to echo requests to validate basic functionality.
    /// </summary>
    [Route("[controller]")]
    public class EchoController: Controller
    {
        /// <summary>
        /// Echos the given input
        /// </summary>
        /// <param name="input">The input to echo</param>
        /// <returns>Echo:{input}</returns>
        [HttpGet("{input}")]
        public string Get(string input)
        {
            return $"Echo:{input}";
        }
    }
}
