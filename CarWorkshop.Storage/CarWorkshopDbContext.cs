using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Storage
{
    public class CarWorkshopDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<CarWorkshop.Storage.Entities.Car> Cars { get; set; }

        public DbSet<CarWorkshop.Storage.Entities.Client> Clients { get; set; }
        public DbSet<CarWorkshop.Storage.Entities.Order> Orders { get; set; }
        public DbSet<CarWorkshop.Storage.Entities.Repair> Repairs { get; set; }

        public CarWorkshopDbContext(IConfiguration configuration)
            : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"server=LEGION;database=CarWorkshop;Trusted_Connection=True;TrustServerCertificate=True",
               x => x.MigrationsHistoryTable("__EFMigrationsHistory", "CarWorkshop"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
