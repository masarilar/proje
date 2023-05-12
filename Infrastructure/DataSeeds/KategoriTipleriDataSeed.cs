using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DataSeeds {
    public class KategoriTipleriDataSeed : IDbSeed {
        public async Task SeedData(IServiceProvider service) {
            var applicationDbContext = service.GetRequiredService<IApplicationDbContext>();
            var kategoriTipleriListesi = await applicationDbContext.KategoriTipleri.ToListAsync();

            var sabitKategoriTipleri = new List<KategoriTip>() {
                new() {TipAdi = "Duyuru"},
                new() {TipAdi = "Haber"}
            };

            foreach (var sabitKategoriTip in sabitKategoriTipleri) {
                var kategoriTip = kategoriTipleriListesi.FirstOrDefault(e => e.TipAdi == sabitKategoriTip.TipAdi);
                var varOlanKategoriTip = kategoriTip != null;
                if (!varOlanKategoriTip)
                    await applicationDbContext.KategoriTipleri.AddAsync(sabitKategoriTip);
            }

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
