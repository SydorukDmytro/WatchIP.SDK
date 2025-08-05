using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchIp.SDK.Models.DTO
{
    public class IpApiDTO
    {
        public string Ip { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? City { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
