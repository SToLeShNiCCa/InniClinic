using Domain.DBServices.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfigurations.ModelsSettings
{
    /// <summary>
    /// Receptionists table configuration class.
    /// </summary>
    public class ReceptionistConfiguration : EntityConfiguration<Receptionist>
    {
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<Receptionist> builder)
        {
            builder.Property(p => p.OfficeId)
                   .IsRequired();
        }
    }
}
