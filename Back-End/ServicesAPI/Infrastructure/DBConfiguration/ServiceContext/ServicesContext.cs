using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBConfiguration.ServiceContext
{
    public class ServicesContext : DbContext
    {
        public ServicesContext(DbContextOptions<ServicesContext> options) 
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServicesContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
