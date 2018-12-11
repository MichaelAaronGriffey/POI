using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;

namespace Poi.Middleware.Services
{
    public static class PolicyRegistry
    {
        public class Policies
        {
            public const string TimeoutStrategy = "TimoutStrategy";
            public const string RetryStrategy = "RetryStrategy";
        }

        public static IServiceCollection AddServicePolicyRegistry(this IServiceCollection services)
        {
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError().RetryAsync(10);
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

            var registry = services.AddPolicyRegistry();
            registry.Add(Policies.RetryStrategy, retryPolicy);
            registry.Add(Policies.TimeoutStrategy, timeoutPolicy);

            return services;
        }
    }
}
