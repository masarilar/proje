using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ModelDto.Enums;

namespace Infrastructure {
    public class GlobalQueryFilter {
        public void Filter(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Duyuru>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<Kategori>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<Gorev>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<CalismaTur>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<Arac>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<Kullanici>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<AracTipi>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<Birim>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<Sofor>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<KategoriTip>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<Dosya>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<AracTalep>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
            modelBuilder.Entity<AracBeklemeDurum>().HasQueryFilter(model => model.Durum == VeriDurumu.Aktif);
        }
    }
}
