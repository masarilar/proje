using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class DuyuruConfiguration : BaseConfigure<Duyuru, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<Duyuru> builder)
        {
            builder.Property(e => e.KategoriId).IsRequired();
            builder.Property(e => e.Basligi).IsRequired().HasMaxLength(200);
            builder.Property(e => e.AnaResim).HasMaxLength(int.MaxValue);
            builder.Property(e => e.Metin).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(e => e.YayinTarih).IsRequired();
            builder.Property(e => e.YayinBitisTarih).IsRequired();
            builder.Property(e => e.KeywordAlani).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(e => e.SliderGoster).IsRequired().HasColumnType("smallint");
            builder.Property(e => e.SliderSirasi).IsRequired();
            builder.Property(e => e.YorumEkle).IsRequired().HasColumnType("smallint");
            builder.Property(e => e.Begenme).IsRequired().HasColumnType("smallint");
        }
    }
}
