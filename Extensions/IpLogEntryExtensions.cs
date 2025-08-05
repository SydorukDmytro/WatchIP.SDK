using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Models;
using WatchIp.SDK.Models.DTO;

namespace WatchIp.SDK.Extensions
{
    public static class IpLogEntryExtensions
    {
        public static IpApiDTO ToApiDTO(this IpLogEntry ipLog) => new IpApiDTO
        {
            Ip = ipLog.Ip,
            Country = ipLog.Country,
            CountryCode = ipLog.CountryCode,
            City = ipLog.City,
            IsBlocked = ipLog.IsBlocked,
            Timestamp = ipLog.Timestamp
        };
    }
}
