using Domain.DBServices.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfigurations.ModelsSettings
{
    /// <summary>
    /// Doctors table configuration class.
    /// </summary>
    public class DoctorsConfiguration : EntityConfiguration<Doctor>
    {
        /// <summary>
        /// Doctor's table configuration method.
        /// </summary>
        /// <param name="builder">Doctor's settings variable</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Doctor> builder)
        {
            //Status property
            builder.Property(p => p.Status)
                .IsRequired();
        }
    }
}
