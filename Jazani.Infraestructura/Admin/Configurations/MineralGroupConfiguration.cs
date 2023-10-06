using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infraestructura.Admin.Configurations
{
    public class MineralGroupConfiguration : IEntityTypeConfiguration<MineralGroup>
    {
        public void Configure(EntityTypeBuilder<MineralGroup> builder)
        {
            var todatetime = new ValueConverter<DateTime, DateTimeOffset>(
                    datetime => DateTimeOffset.UtcNow,
                    datetimeOffset => datetimeOffset.DateTime
                );

            builder.ToTable("mineralgroup", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Slug).HasColumnName("slug");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate").HasConversion(todatetime);
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
