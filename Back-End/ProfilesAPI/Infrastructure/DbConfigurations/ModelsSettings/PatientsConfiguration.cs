using Domain.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfigurations.ModelsSettings
{
    /// <summary>
    /// Patients table configuration class.
    /// </summary>
    public class PatientsConfiguration : EntityConfiguration<Patient>
    {
        /// <summary>
        /// Configures additional properties specific to the Patients entity.
        /// </summary>
        /// <param name="builder">Patient's settings variable</param>
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.IsLinkedToAccount)
                   .IsRequired();
        }
    }
}
