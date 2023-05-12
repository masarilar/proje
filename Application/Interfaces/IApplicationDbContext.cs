using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Duyuru> Duyurular { get; set; }
        DbSet<Domain.Entities.Kategori> Kategoriler { get; set; }
        DbSet<Domain.Entities.Gorev> Gorevler { get; set; }
        DbSet<Domain.Entities.CalismaTur> CalismaTurleri { get; set; }
        DbSet<Domain.Entities.Kullanici> Kullanicilar { get; set; }
        DbSet<Domain.Entities.Arac> Araclar { get; set; }
        DbSet<Domain.Entities.AracTipi> AracTipleri { get; set; }
        DbSet<Domain.Entities.Birim> Birimler { get; set; }
        DbSet<Domain.Entities.Sofor> Soforler { get; set; }
        DbSet<Domain.Entities.KategoriTip> KategoriTipleri { get; set; }
        DbSet<Domain.Entities.Dosya> Dosyalar { get; set; }
        DbSet<Domain.Entities.AracTalep> AracTalepleri { get; set; }
        DbSet<Domain.Entities.AracBeklemeDurum> AracBeklemeDurumlari { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void Dispose();
        DbSet<T> Set<T>() where T : class;
        Task<DatabaseFacade> GetDatabase();
    }
}
