using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DBConfiguration.ModelsSettings
{
    public class ServiceCategoryConfiguration : EntityConfiguration<ServiceCategory>
    {
        protected override void ConfigureAdditionalProperties(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.Property(sc => sc.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(sc => sc.TimeSlotSize)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
    
}
