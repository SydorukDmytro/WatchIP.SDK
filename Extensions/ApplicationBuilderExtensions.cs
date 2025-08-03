using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Middleware;

namespace WatchIp.SDK.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWatchIpProtection(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IpMonitoringMiddleware>();
        }
    }
}
