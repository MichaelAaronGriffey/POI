using Microsoft.Extensions.DependencyInjection;
using Poi.Middleware.Services;
using System;

namespace Poi.Middleware
{
    public static class GithubServiceMiddleware
    {
        public static IServiceCollection AddGitHubService(this IServiceCollection services, string gitHubUri)
        {
            services.AddHttpClient<GitHubService>(c =>
            {
                c.BaseAddress = new Uri(gitHubUri);
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });
            return services;
        }
    }
}
