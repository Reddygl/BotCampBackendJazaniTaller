using Jazani.Domain.Generales.Moldels;
using Jazani.Infraestructura.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructura.Generales.Configurations
{
    public class MiningConcessionConfiguration : IEntityTypeConfiguration<MiningConcession>
    {
        public void Configure(EntityTypeBuilder<MiningConcession> builder)
        {

            builder.ToTable("miningconcession", "mc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MineralTypeId).HasColumnName("mineraltypeid");
            builder.Property(x => x.OriginId).HasColumnName("originid");
            builder.Property(x => x.TypeId).HasColumnName("typeid");
            builder.Property(x => x.SituationId).HasColumnName("situationid");
            builder.Property(x => x.MiningunitId).HasColumnName("miningunitid");
            builder.Property(x => x.ConditionId).HasColumnName("conditionid");
            builder.Property(x => x.StatemanagementId).HasColumnName("statemanagementid");
            builder.Property(x => x.Code).HasColumnName("code");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Observation).HasColumnName("observation");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate").HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
