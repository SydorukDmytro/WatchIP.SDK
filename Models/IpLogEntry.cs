using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchIp.SDK.Models
{
    public class IpLogEntry
    {
        public int Id { get; set; }
        public string Ip { get; set; } = null!;
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? City { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool IsBlocked { get; set; }
    }
}
