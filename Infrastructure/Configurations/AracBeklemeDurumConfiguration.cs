using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class AracBeklemeDurumConfiguration : BaseConfigure<AracBeklemeDurum, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<AracBeklemeDurum> builder)
        {
            builder.Property(e => e.BeklemeDurum).IsRequired();
        }
    }
}
