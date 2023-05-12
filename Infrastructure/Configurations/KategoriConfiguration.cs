using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class KategoriConfiguration : BaseConfigure<Kategori, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(e => e.Ad).IsRequired().HasMaxLength(250);
            builder.Property(e => e.KategoriTipId).IsRequired();
            builder.Property(e => e.Yetkileri).IsRequired().HasMaxLength(int.MaxValue);
        }
    }
}
