using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Configuration;
using WatchIp.SDK.Database;
using WatchIp.SDK.Interfaces;
using WatchIp.SDK.Middleware;
using WatchIp.SDK.Services;

namespace WatchIp.SDK.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWatchIpProtection(this IServiceCollection services, Action<WatchIpOptions> configure)
        {
            var options = new WatchIpOptions();
            configure(options);
            
            services.Configure(configure);
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<WatchIpOptions>>().Value);

            services.AddMemoryCache();

            services.AddHttpClient<IIpGeoService, IpGeoService>();

            services.AddSingleton<IIpResolverService, IpResolverService>();
            services.AddTransient<IpMonitoringMiddleware>();

            services.AddDbContext<WatchIpDbContext>(options =>
            {
                options.UseSqlite("Data Source=WatchIpDb.db");
            });

            return services;
        }
    }
}
