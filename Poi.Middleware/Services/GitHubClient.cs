using Poi.Middleware.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Poi.Middleware.Services
{
    

    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _httpClient;

        public GitHubClient(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Gets all the repos from the base repo
        /// </summary>
        /// <param name="org">The name of the organization</param>
        /// <returns>A list of repos</returns>
        /// <exception cref="HttpRequestException">Throws an exception if the System.Net.Http.HttpResponseMessage.IsSuccessStatusCode property for the HTTP response is false.</exception>
        public async Task<IEnumerable<GitHubRepository>> GetRepos(string org)
        {
            var response = await _httpClient.GetAsync($"/orgs/{org}/repos");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<GitHubRepository>>();

            return result;
        }
    }
}
