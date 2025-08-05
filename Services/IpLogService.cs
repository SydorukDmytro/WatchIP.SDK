using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Database;
using WatchIp.SDK.Extensions;
using WatchIp.SDK.Interfaces;
using WatchIp.SDK.Models.DTO;

namespace WatchIp.SDK.Services
{
    public class IpLogService : IIpLogService
    {
        private readonly WatchIpDbContext _context;
        public IpLogService(WatchIpDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<IpApiDTO>> GetAllAsync(int take = 100)
        {
            var logs = await _context.IpLogs
                .OrderByDescending(x => x.Timestamp)
                .Take(take)
                .ToListAsync();
            return logs.Select(log => log.ToApiDTO());
        }

        public async Task<IpApiDTO?> GetByIpAsync(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                throw new ArgumentException("IP address cannot be null or empty.", nameof(ip));
            var log = await _context.IpLogs
            .Where(x => x.Ip == ip)
            .OrderByDescending(x => x.Timestamp)
            .FirstOrDefaultAsync();

            return log?.ToApiDTO();
        }
    }
}
