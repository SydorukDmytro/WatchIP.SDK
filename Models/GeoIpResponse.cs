using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WatchIp.SDK.Models
{
    public class GeoIpResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; } = string.Empty;
        [JsonPropertyName("region")]
        public string Region { get; set; } = string.Empty;
        [JsonPropertyName("regionName")]
        public string RegionName { get; set; } = string.Empty;
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;
        [JsonPropertyName("zip")]
        public string Zip { get; set; } = string.Empty;
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = string.Empty;
        [JsonPropertyName("isp")]
        public string Isp { get; set; } = string.Empty;
        [JsonPropertyName("org")]
        public string Org { get; set; } = string.Empty;
        [JsonPropertyName("as")]
        public string As { get; set; } = string.Empty;
        [JsonPropertyName("query")]
        public string Query { get; set; } = string.Empty;
    }
}
