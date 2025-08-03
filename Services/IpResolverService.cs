using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Interfaces;

namespace WatchIp.SDK.Services
{
    public class IpResolverService : IIpResolverService
    {
        public string? GetClientIp(HttpContext context)
        {
            var headers = context.Request.Headers;
            if (headers.ContainsKey("X-Forwarded-For"))
            {
                var forwardedFor = headers["X-Forwarded-For"].ToString();
                if (!string.IsNullOrEmpty(forwardedFor))
                {
                    return forwardedFor.Split(',')[0].Trim();
                }
            }
            return context.Connection.RemoteIpAddress?.ToString();
        }
    }
}
