using FluentValidation;
using ModelDto.Dtos.Arac;
using ModelDto.Dtos.AracBeklemeDurum;
using ModelDto.Dtos.AracTalep;
using ModelDto.Dtos.AracTipi;
using ModelDto.Dtos.Birim;
using ModelDto.Dtos.Calisma;
using ModelDto.Dtos.Duyuru;
using ModelDto.Dtos.Gorev;
using ModelDto.Dtos.Kategori;
using ModelDto.Dtos.KategoriTip;
using ModelDto.Dtos.Kullanici;
using ModelDto.Dtos.Sofor;

namespace WebUI
{
    public class ApplicationValidators
    {
        public IServiceCollection GetValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<DtoKullaniciKaydet>, DtoKullaniciKaydetValidator>();
            services.AddScoped<IValidator<DtoKullaniciGuncelle>, DtoKullaniciGuncelleValidator>();
            services.AddScoped<IValidator<DtoCalismaTurKaydet>, DtoCalismaTurKaydetValidator>();
            services.AddScoped<IValidator<DtoCalismaTurGuncelle>, DtoCalismaTurGuncelleValidator>();
            services.AddScoped<IValidator<DtoGorevKaydet>, DtoGorevKaydetValidator>();
            services.AddScoped<IValidator<DtoGorevGuncelle>, DtoGorevGuncelleValidator>();
            services.AddScoped<IValidator<DtoKategoriKaydet>, DtoKategoriKaydetValidator>();
            services.AddScoped<IValidator<DtoKategoriGuncelle>, DtoKategoriGuncelleValidator>();
            services.AddScoped<IValidator<DtoKategoriTipKaydet>, DtoKategoriTipKaydetValidator>();
            services.AddScoped<IValidator<DtoKategoriTipGuncelle>, DtoKategoriTipGuncelleValidator>();
            services.AddScoped<IValidator<DtoBirimKaydet>, DtoBirimKaydetValidator>();
            services.AddScoped<IValidator<DtoBirimGuncelle>, DtoBirimGuncelleValidator>();
            services.AddScoped<IValidator<DtoAracTipiKaydet>, DtoAracTipiKaydetValidator>();
            services.AddScoped<IValidator<DtoAracTipiGuncelle>, DtoAracTipiGuncelleValidator>();
            services.AddScoped<IValidator<DtoAracKaydet>, DtoAracKaydetValidator>();
            services.AddScoped<IValidator<DtoAracGuncelle>, DtoAracGuncelleValidator>();
            services.AddScoped<IValidator<DtoSoforKaydet>, DtoSoforKaydetValidator>();
            services.AddScoped<IValidator<DtoSoforGuncelle>, DtoSoforGuncelleValidator>();
            services.AddScoped<IValidator<DtoDuyuruKaydet>, DtoDuyuruKaydetValidator>();
            services.AddScoped<IValidator<DtoDuyuruGuncelle>, DtoDuyuruGuncelleValidator>();
            services.AddScoped<IValidator<DtoAracTalepKaydet>, DtoAracTalepKaydetValidator>();
            services.AddScoped<IValidator<DtoAracTalepGuncelle>, DtoAracTalepGuncelleValidator>();
            services.AddScoped<IValidator<DtoAracBeklemeDurumKaydet>, DtoAracBeklemeDurumKaydetValidator>();
            services.AddScoped<IValidator<DtoAracBeklemeDurumGuncelle>, DtoAracBeklemeDurumGuncelleValidator>();
            return services;
        }
    }
}
