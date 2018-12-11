using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Poi.Middleware.Services;
using Poi.Middleware.Models;

namespace Poi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        public GitHubController(IGitHubClient gitHubClient)
        {
            GitHubClient = gitHubClient;
        }

        public IGitHubClient GitHubClient { get; }

        [HttpGet("{org}")]
        public async Task<ActionResult<IEnumerable<GitHubRepository>>> GetRepos(string org)
        {
            try
            {
                var result = await GitHubClient.GetRepos(org);
                return Ok(result);
            }catch (HttpRequestException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}