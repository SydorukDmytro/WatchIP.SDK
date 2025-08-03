using Microsoft.AspNetCore.Http;
using WatchIp.SDK.Database;
using WatchIp.SDK.Interfaces;
using WatchIp.SDK.Models;

namespace WatchIp.SDK.Middleware
{
    public class IpMonitoringMiddleware
    {
        private readonly IIpResolverService _ipResolver;
        private readonly RequestDelegate _next;
        private readonly IIpGeoService _geoService;
        private readonly WatchIpDbContext _context;

        public IpMonitoringMiddleware(RequestDelegate next, IIpResolverService ipResolverService, IIpGeoService geoService, WatchIpDbContext dbContext)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _ipResolver = ipResolverService ?? throw new ArgumentNullException(nameof(ipResolverService));
            _geoService = geoService ?? throw new ArgumentNullException(nameof(geoService));
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = _ipResolver.GetClientIp(context);
            if (string.IsNullOrWhiteSpace(ip))
            {
                await _next(context);
                return;
            }
            var ipInfo = await _geoService.GetIpInfoAsync(ip);
            var entry = new IpLogEntry
            {
                Ip = ip,
                Country = ipInfo?.Country,
                CountryCode = ipInfo?.CountryCode,
                City = ipInfo?.City,
                Timestamp = DateTime.UtcNow
            };
            _context.IpLogs.Add(entry);
            await _context.SaveChangesAsync();


            if (ipInfo.IsBlockedCountry == true)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access denied from your country.");
                return;
            }
            
            await _next(context);
        }
    }
}