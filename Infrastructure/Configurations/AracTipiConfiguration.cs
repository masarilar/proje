using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class AracTipiConfiguration : BaseConfigure<AracTipi, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<AracTipi> builder)
        {
            builder.Property(e=>e.Adi).IsRequired().HasMaxLength(250);
        }
    }
}
