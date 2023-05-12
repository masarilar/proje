using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CalismaConfiguration : BaseConfigure<CalismaTur, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<CalismaTur> builder)
        {
            builder.Property(e => e.Adi).IsRequired().HasMaxLength(250);
        }
    }
}
