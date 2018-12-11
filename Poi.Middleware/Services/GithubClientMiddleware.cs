using Microsoft.Extensions.DependencyInjection;
using System;
using static Poi.Middleware.Services.PolicyRegistry;

namespace Poi.Middleware.Services
{
    public static class GithubClientMiddleware
    {
        public static IServiceCollection AddGitHubClient(this IServiceCollection services, string gitHubUri)
        {
            services.AddHttpClient<IGitHubClient, GitHubClient>(c =>
            {
                c.BaseAddress = new Uri(gitHubUri);
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            })
            .AddPolicyHandlerFromRegistry(Policies.RetryStrategy)
            .AddPolicyHandlerFromRegistry(Policies.TimeoutStrategy);

            return services;
        }
    }
}
