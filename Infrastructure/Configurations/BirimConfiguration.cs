using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BirimConfiguration : BaseConfigure<Birim, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<Birim> builder)
        {
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Adi).IsRequired().HasMaxLength(250);
        }
    }
}
