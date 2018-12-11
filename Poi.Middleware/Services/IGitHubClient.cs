using Poi.Middleware.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poi.Middleware.Services
{
    public interface IGitHubClient
    {
        Task<IEnumerable<GitHubRepository>> GetRepos(string org);

    }
}
