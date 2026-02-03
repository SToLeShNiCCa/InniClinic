using Domain.DBServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DbConfigurations.ModelsSettings
{
    /// <summary>
    /// Base entity configuration class.
    /// </summary>
    /// <typeparam name="T">Template which contain model's class</typeparam>
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        /// <summary>
        /// Base entity configuration method.
        /// </summary>
        /// <param name="builder">Entity's settings variable</param>
        public void Configure(EntityTypeBuilder<T> builder)
        {
            //Primary key property
            builder.HasKey(e => e.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            //FirstName property
            builder.Property(p => p.FirstName)
                   .HasMaxLength(15)
                   .IsRequired();

            //MiddleName property
            builder.Property(p => p.MiddleName)
                   .HasMaxLength(15)
                   .IsRequired();

            //LastName property
            builder.Property(p => p.LastName)
                   .HasMaxLength(15)
                   .IsRequired();

            // Call to configure additional properties in derived classes
            ConfigureAdditionalProperties(builder);
        }

        protected abstract void ConfigureAdditionalProperties(EntityTypeBuilder<T> builder);
    }
}