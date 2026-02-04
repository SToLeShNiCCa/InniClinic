using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DBSettings.ModelSettings
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            ConfigureAdditionalProperties(builder);
        }
        protected abstract void ConfigureAdditionalProperties(EntityTypeBuilder<T> builder);
    }
}
