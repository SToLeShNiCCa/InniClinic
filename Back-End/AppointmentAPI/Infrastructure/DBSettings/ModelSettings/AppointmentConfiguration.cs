using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DBSettings.ModelSettings
{
    public class AppointmentConfiguration : EntityConfiguration<Appointment>
    {
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(p => p.PatientId)
                .IsRequired();

            builder.Property(p => p.DoctorId)
                .IsRequired();

            builder.Property(p => p.ServiceId)
                .IsRequired();

            builder.Property(p => p.Date)
                .IsRequired();

            builder.Property(p => p.Time)
                .IsRequired();

            builder.Property(p => p.IsApproved)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
