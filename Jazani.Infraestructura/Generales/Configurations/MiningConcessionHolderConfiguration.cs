using Jazani.Domain.Generales.Moldels;
using Jazani.Infraestructura.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructura.Generales.Configurations
{
    public class MiningConcessionHolderConfiguration : IEntityTypeConfiguration<MiningConcessionHolder>
    {
        public void Configure(EntityTypeBuilder<MiningConcessionHolder> builder)
        {

            builder.ToTable("miningconcessionholder", "mc");
            builder.HasKey(x => new { x.MiningConcessionId, x.HolderId });
            builder.Property(x => x.Percent).HasColumnName("percent");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate").HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
            builder.HasOne(one => one.MiningConcession).WithMany(many => many.MiningConcessionHolders).HasPrincipalKey(o => o.Id);
            builder.HasOne(one => one.Holder).WithMany(many => many.MiningConcessionHolders).HasPrincipalKey(o => o.Id);
        }
    }
}
