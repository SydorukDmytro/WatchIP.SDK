using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Models.DTO;

namespace WatchIp.SDK.Interfaces
{
    public interface IIpGeoService
    {
        Task<IpInfo?> GetIpInfoAsync(string ip);
    }
}
