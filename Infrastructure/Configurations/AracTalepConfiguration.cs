using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class AracTalepConfiguration : BaseConfigure<AracTalep, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<AracTalep> builder)
        {
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.BaslangicNoktasi).IsRequired().HasMaxLength(250);
            builder.Property(e => e.BitisNoktasi).IsRequired().HasMaxLength(250);
            builder.Property(e => e.ToplamKilometre).IsRequired().HasMaxLength(250);
            builder.Property(e => e.GidisTarihSaat).IsRequired();
            builder.Property(e => e.AracBeklemeDurumId).IsRequired();
            builder.Property(e => e.AracTalepDurum).IsRequired().HasColumnType("smallint");
        }
    }
}
