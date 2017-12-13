using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Empty
{
    public static class HttpResponseHeadersExtensions
    {
        public static void SetServerTiming(this HttpResponse response, params ServerTimingMetric[] metrics)
        {
            var serverTiming = new ServerTimingHeaderValue();
            foreach (var metric in metrics)
            {
                serverTiming.ServerTimingMetrics.Add(metric);
            }
            response.Headers.Append("Server-Timing", serverTiming.ToString());
        }
        public static IServiceCollection AddServerTiming(this IServiceCollection services)
        {
            services.AddScoped<IServerTiming, ServerTiming>();
            return services;
        }
    }
}
