using Jazani.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infraestructura.Admin.Configurations
{
    public class PendingTypeConfiguration: IEntityTypeConfiguration<PendingType>
    {
        public void Configure(EntityTypeBuilder<PendingType> builder)
        {
            builder.ToTable("pendingtype", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
