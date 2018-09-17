using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;

namespace Poi.Middleware.Services
{
    public static class ServicesStrategies
    {
        public enum Strategies
        {
            TimeoutStrategy,
            RetryStrategy
        }

        public static IServiceCollection AddServicePolicyRegistry(this IServiceCollection services)
        {
            var retryStrategy = HttpPolicyExtensions.HandleTransientHttpError().RetryAsync(10);
            var timeoutStrategy = Policy.TimeoutAsync<HttpResponseMessage>(10);

            var registry = services.AddPolicyRegistry();
            registry.Add(Strategies.RetryStrategy.ToString(), retryStrategy);
            registry.Add(Strategies.TimeoutStrategy.ToString(), timeoutStrategy);

            return services;
        }
    }
}
