using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class KategoriTipConfiguration : BaseConfigure<KategoriTip, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<KategoriTip> builder)
        {
            builder.Property(e => e.TipAdi).IsRequired().HasMaxLength(250);
        }
    }
}
