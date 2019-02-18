using DeviceManager.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.DBContext
{
    public class DeviceManagerDbContext : DbContext
    {
        public DeviceManagerDbContext(DbContextOptions<DeviceManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }

        public DbSet<DevicePropertyValue> DevicePropertyValues { get; set; }

        public DbSet<DeviceType> DeviceTypes { get; set; }

        public DbSet<DeviceTypeProperty> DeviceTypeProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to under 40 
            base.OnModelCreating(modelBuilder);

        }
    }
}
