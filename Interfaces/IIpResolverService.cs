using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchIp.SDK.Interfaces
{
    public interface IIpResolverService
    {
        string? GetClientIp(HttpContext context);
    }
}
