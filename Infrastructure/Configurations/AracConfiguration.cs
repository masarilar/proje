using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class AracConfiguration : BaseConfigure<Arac, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<Arac> builder)
        {
            builder.Property(e => e.AracTipiId).IsRequired();
            builder.Property(e => e.Marka).IsRequired().HasMaxLength(250);
            builder.Property(e => e.ModelYili).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Rengi).IsRequired().HasMaxLength(250);
            builder.Property(e => e.DemirbasDurumu).IsRequired().HasColumnType("smallint");
            builder.Property(e => e.KilometredeBakimaGider).IsRequired().HasColumnType("smallint");
            builder.Property(e => e.Plakasi).IsRequired().HasMaxLength(10);
            builder.Property(e => e.RuhsatNo).IsRequired().HasMaxLength(8);
            builder.Property(e => e.BaslangicKilometresi).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Resimleri).HasMaxLength(int.MaxValue);
        }
    }
}
