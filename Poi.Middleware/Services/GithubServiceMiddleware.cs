using Microsoft.Extensions.DependencyInjection;
using System;
using static Poi.Middleware.Services.ServicesStrategies;

namespace Poi.Middleware.Services
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
            })
            .AddPolicyHandlerFromRegistry(Strategies.RetryStrategy.ToString())
            .AddPolicyHandlerFromRegistry(Strategies.TimeoutStrategy.ToString());

            return services;
        }
    }
}
