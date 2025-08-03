using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchIp.SDK.Models.DTO
{
    public class IpInfo
    {
        public string Ip { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool IsBlockedCountry { get; set; }
    }
}
