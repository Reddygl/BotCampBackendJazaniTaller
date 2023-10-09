using Jazani.Domain.Generales.Moldels;
using Jazani.Infraestructura.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructura.Generales.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("investment", "mc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amountinvestd).HasColumnName("amountinvestd");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.MiningconcessionId).HasColumnName("miningconcessionid");
            builder.Property(x => x.InvestmentTypeId).HasColumnName("investmenttypeid");
            builder.Property(x => x.InvestmentConceptId).HasColumnName("investmentconceptid");
            builder.Property(x => x.MeasureUnitId).HasColumnName("measureunitid");
            builder.Property(x => x.CurrencyTypeId).HasColumnName("currencytypeid");
            builder.Property(x => x.HolderId).HasColumnName("holderid");
            builder.Property(x => x.PeriodTypeId).HasColumnName("periodtypeid");
            builder.Property(x => x.DeclaredTypeId).HasColumnName("declaredtypeid");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate").HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
            builder.HasOne(one => one.Holder).WithMany(many => many.Investments).HasForeignKey(o => o.HolderId);
            builder.HasOne(one => one.MiningConcession).WithMany(many => many.Investments).HasForeignKey(o => o.MiningconcessionId);
            builder.HasOne(one => one.InvestmentType).WithMany(many => many.Investments).HasForeignKey(o => o.InvestmentTypeId);
            builder.HasOne(one => one.InvestmentConcept).WithMany(many => many.Investments).HasForeignKey(o => o.InvestmentConceptId);
            builder.HasOne(one => one.MeasureUnit).WithMany(many => many.Investments).HasForeignKey(o => o.MeasureUnitId);
            builder.HasOne(one => one.Periodtype).WithMany(many => many.Investments).HasForeignKey(o => o.PeriodTypeId);

        }
    }
}
