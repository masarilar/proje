using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class GorevConfiguration : BaseConfigure<Gorev, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<Gorev> builder)
        {
            builder.Property(e => e.Adi).IsRequired().HasMaxLength(250);
        }
    }
}
