using Jazani.Domain.Generales.Moldels;
using Jazani.Infraestructura.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructura.Generales.Configurations
{
    public class HolderConfiguration : IEntityTypeConfiguration<Holder>
    {
        public void Configure(EntityTypeBuilder<Holder> builder)
        {

            builder.ToTable("holder", "soc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.LastName).HasColumnName("lastname");
            builder.Property(x => x.MaidenName).HasColumnName("maidenname");
            builder.Property(x => x.DocumentNumber).HasColumnName("documentnumber");
            builder.Property(x => x.HolderGroupId).HasColumnName("holdergroupid");
            builder.Property(x => x.HolderRegimeId).HasColumnName("holderregimeid");
            builder.Property(x => x.HolderTypeId).HasColumnName("holdertypeid");
            builder.Property(x => x.RegistryOfficeId).HasColumnName("registryofficeid");
            builder.Property(x => x.IdentificationDocumentId).HasColumnName("identificationdocumentid");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate").HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
