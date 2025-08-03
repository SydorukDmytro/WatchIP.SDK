using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchIp.SDK.Models;

namespace WatchIp.SDK.Database
{
    public class WatchIpDbContext : DbContext
    {
        public DbSet<IpLogEntry> IpLogs { get; set; }
        public WatchIpDbContext(DbContextOptions<WatchIpDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IpLogEntry>()
                .HasKey(ip => ip.Id);
        }

    }
}
