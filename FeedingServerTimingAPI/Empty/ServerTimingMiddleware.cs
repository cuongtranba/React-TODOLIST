using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Empty
{
    public class ServerTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private static Task _completedTask = Task.FromResult<object>(null);
        public ServerTimingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        public Task Invoke(HttpContext context)
        {
            HandleServerTiming(context);
            return _next(context);
        }
        private void HandleServerTiming(HttpContext context)
        {
            context.Response.OnStarting(() => {
                IServerTiming serverTiming = context.RequestServices.GetRequiredService<IServerTiming>();
                serverTiming.Metrics.Add(new ServerTimingMetric("cache", 300, "Cache"));
                serverTiming.Metrics.Add(new ServerTimingMetric("sql", 900, "Sql Server"));
                serverTiming.Metrics.Add(new ServerTimingMetric("fs", 600, "FileSystem"));
                serverTiming.Metrics.Add(new ServerTimingMetric("cpu", 1230, "Total CPU"));
                if (serverTiming.Metrics.Count > 0)
                {
                    context.Response.SetServerTiming(serverTiming.Metrics.ToArray());
                }
                return _completedTask;
            });
        }
    }
    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseServerTiming(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ServerTimingMiddleware>();
        }
    }
}
