using Application.Interfaces;
using Domain.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ModelDto.Enums;
using System.Reflection;

namespace Infrastructure {
    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public ApplicationDbContext() {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
        public DbSet<CalismaTur> CalismaTurleri { get; set; }
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<AracTipi> AracTipleri { get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Sofor> Soforler { get; set; }
        public DbSet<KategoriTip> KategoriTipleri { get; set; }
        public DbSet<Dosya> Dosyalar { get; set; }
        public DbSet<AracTalep> AracTalepleri { get; set; }
        public DbSet<AracBeklemeDurum> AracBeklemeDurumlari { get; set; }

        public async Task<DatabaseFacade> GetDatabase() {
            return base.Database;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            foreach (var entry in ChangeTracker.Entries<IEntity<int>>()) {
                switch (entry.State) {
                    case EntityState.Added:
                        entry.Entity.KaydedenId = 1;
                        entry.Entity.DegistirenId = 1;
                        entry.Entity.Durum = VeriDurumu.Aktif;
                        entry.Entity.KayitTarih = DateTime.Now;
                        entry.Entity.DegisiklikTarih = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.DegistirenId = 1;
                        entry.Entity.DegisiklikTarih = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            new GlobalQueryFilter().Filter(modelBuilder);
        }
        public override async void Dispose() => await base.DisposeAsync();
    }
}
