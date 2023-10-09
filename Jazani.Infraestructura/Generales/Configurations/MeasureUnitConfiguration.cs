using Jazani.Domain.Generales.Moldels;
using Jazani.Infraestructura.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructura.Generales.Configurations
{
    public class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
    {
        public void Configure(EntityTypeBuilder<MeasureUnit> builder)
        {
            builder.ToTable("measureunit", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Symbol).HasColumnName("symbol");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate").HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
