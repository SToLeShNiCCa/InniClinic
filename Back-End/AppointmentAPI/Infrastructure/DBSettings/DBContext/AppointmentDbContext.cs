using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBSettings.DBContext
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
