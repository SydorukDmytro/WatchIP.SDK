using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Models.DTO;

namespace WatchIp.SDK.Interfaces
{
    public interface IIpLogService
    {
        Task<IEnumerable<IpApiDTO>> GetAllAsync(int take = 100);
        Task<IpApiDTO?> GetByIpAsync(string ip);
    }
}
