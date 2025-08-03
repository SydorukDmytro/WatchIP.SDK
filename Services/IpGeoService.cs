using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Configuration;
using WatchIp.SDK.Interfaces;
using WatchIp.SDK.Models;
using WatchIp.SDK.Models.DTO;

namespace WatchIp.SDK.Services
{
    public class IpGeoService : IIpGeoService
    {
        private readonly HttpClient _httpClient;
        private readonly WatchIpOptions _options;
        private readonly IMemoryCache _cache;

        public IpGeoService(HttpClient httpClient, IOptions<WatchIpOptions> options, IMemoryCache cache)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<IpInfo?> GetIpInfoAsync(string ip)
        {
            if(_cache.TryGetValue(ip, out IpInfo cached))
            {
                return cached;
            }
            try
            {
                var url = $"http://ip-api.com/json/{ip}";
                var response = await _httpClient.GetFromJsonAsync<GeoIpResponse>(url);

                if(response == null || response.Status != "success")
                {
                    return null;
                }
                var ipInfo = new IpInfo
                {
                    Ip = response.Query,
                    Country = response.Country,
                    CountryCode = response.CountryCode,
                    City = response.City,
                    IsBlockedCountry = _options.BlockCountries?.Contains(response.CountryCode) ?? false
                };

                _cache.Set(ip, ipInfo, TimeSpan.FromMinutes(60));

                return ipInfo;
            }catch
            {
                return null;
            }
        }
    }
}
