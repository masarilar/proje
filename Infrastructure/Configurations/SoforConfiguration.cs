using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SoforConfiguration : BaseConfigure<Sofor, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<Sofor> builder)
        {
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.KullaniciId).IsRequired();
            builder.Property(e => e.Resim).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(e => e.EhliyetYetkinlikleri).IsRequired().HasMaxLength(int.MaxValue);
        }
    }
}
