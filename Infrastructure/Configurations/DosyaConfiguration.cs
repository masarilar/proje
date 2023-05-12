using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations {
    public class DosyaConfiguration : BaseConfigure<Dosya, int> {
        protected override void ConfigureDb(EntityTypeBuilder<Dosya> builder) {
            builder.Property(e => e.Adi).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Yol).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(e => e.Uzanti).IsRequired().HasMaxLength(128);
        }
    }
}
