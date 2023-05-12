using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class KullaniciConfiguration : BaseConfigure<Kullanici, int>
    {
        protected override void ConfigureDb(EntityTypeBuilder<Kullanici> builder)
        {
            builder.Property(e => e.TC).IsRequired().HasMaxLength(11);
            builder.Property(e => e.Ad).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Soyad).IsRequired().HasMaxLength(250);
            builder.Property(e => e.AdSoyad).IsRequired().HasMaxLength(250);
            builder.Property(e => e.DogumTarihi).IsRequired();
            builder.Property(e => e.Eposta).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Parola).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Resim).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(e => e.BirimId).IsRequired();
            builder.Property(e => e.GorevId).IsRequired();
            builder.Property(e => e.Adres).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(e => e.CepTelefon).IsRequired().HasMaxLength(11);
            builder.Property(e => e.EvTelefon).HasMaxLength(11);
            builder.Property(e => e.DahiliNo).HasMaxLength(11);
            builder.Property(e => e.YakiniAdSoyad).IsRequired().HasMaxLength(250);
            builder.Property(e => e.YakiniTelefon).IsRequired().HasMaxLength(11);
            builder.Property(e => e.KanGrubu).IsRequired().HasMaxLength(25);
            builder.Property(e => e.Cinsiyet).IsRequired().HasColumnType("smallint");
            builder.Property(e => e.MedeniDurum).IsRequired().HasColumnType("smallint");
            builder.Property(e => e.AskerlikDurum).IsRequired().HasColumnType("smallint");
            builder.Property(e => e.FirmaSicilNo).HasMaxLength(250);
            builder.Property(e => e.CalismaTurId).IsRequired();
        }
    }
}
