using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelDto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations {
    public abstract class BaseConfigure<T, TId> : IEntityTypeConfiguration<T> where T : class {
        public void Configure(EntityTypeBuilder<T> builder) {
            if(typeof(T).IsAssignableTo(typeof(IEntity<TId>))) {
                builder.Property(nameof(IEntity<TId>.KaydedenId)).IsRequired();
                builder.Property(nameof(IEntity<TId>.DegistirenId)).IsRequired();

                builder.Property(nameof(IEntity<TId>.KayitTarih)).IsRequired();
                builder.Property(nameof(IEntity<TId>.DegisiklikTarih)).IsRequired();
                builder.Property(nameof(IEntity<TId>.Durum)).IsRequired().HasDefaultValue(VeriDurumu.Aktif).HasColumnType("smallint");
            }
            ConfigureDb(builder);
        }
        protected abstract void ConfigureDb(EntityTypeBuilder<T> builder);
    }
}
