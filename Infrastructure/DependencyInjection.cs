using Application.AracApps;
using Application.AracTipiApps;
using Application.BirimApps;
using Application.CalismaApps;
using Application.DosyaApps;
using Application.DuyuruApps;
using Application.GorevApps;
using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Application.KategoriApps;
using Application.KategoriTipApps;
using Application.KullaniciApps;
using Application.SoforApps;
using Infrastructure.Repos;
using Infrastructure.Repos.AracRepos;
using Infrastructure.Repos.AracTalepRepos;
using Infrastructure.Repos.AracTipiRepos;
using Infrastructure.Repos.BirimRepos;
using Infrastructure.Repos.CalismaRepos;
using Infrastructure.Repos.DosyaRepos;
using Infrastructure.Repos.DuyuruRepos;
using Infrastructure.Repos.GorevRepos;
using Infrastructure.Repos.KategoriRepos;
using Infrastructure.Repos.KategoriTipRepos;
using Infrastructure.Repos.KullaniciRepos;
using Infrastructure.Repos.SoforRepos;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.AracTalepApps;
using Infrastructure.Repos.AracBeklemeDurumuRepos;
using Application.AracBeklemeDurumApps;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Identity;

namespace Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    _options => _options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddScoped<IMapper, Mapper>();

            //services.AddAuthentication(options => {
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options => {
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.Audience = configuration["JWT:Issuer"];
            //    options.Audience = configuration["JWT:Audience"];
            //    options.TokenValidationParameters = new TokenValidationParameters() {
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidAudience = configuration["JWT:Audience"],
            //        ValidIssuer = configuration["JWT:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            //    };
            //});
            //services.AddAuthorization();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            //services.AddScoped<IJwtToken, JwtToken>();
            #region Repositories And Apps Lifecycle
            services.AddScoped<IDuyuruRepository, DuyuruRepository>();
            services.AddScoped<IDuyuruApp, DuyuruApp>();
            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IKategoriApp, KategoriApp>();
            services.AddScoped<IGorevRepository, GorevRepository>();
            services.AddScoped<IGorevApp, GorevApp>();
            services.AddScoped<ICalismaRepository, CalismaRepository>();
            services.AddScoped<ICalismaApp, CalismaApp>();
            services.AddScoped<IKullaniciRepository, KullaniciRepository>();
            services.AddScoped<IKullaniciApp, KullaniciApp>();
            services.AddScoped<IAracRepository, AracRepository>();
            services.AddScoped<IAracApp, AracApp>();
            services.AddScoped<IAracTipiRepository, AracTipiRepository>();
            services.AddScoped<IAracTipiApp, AracTipiApp>();
            services.AddScoped<IBirimRepository, BirimRepository>();
            services.AddScoped<IBirimApp, BirimApp>();
            services.AddScoped<ISoforRepository, SoforRepository>();
            services.AddScoped<ISoforApp, SoforApp>();
            services.AddScoped<IKategoriTipRepository, KategoriTipRepository>();
            services.AddScoped<IKategoriTipApp, KategoriTipApp>();
            services.AddScoped<IDosyaRepository, DosyaRepository>();
            services.AddScoped<IDosyaApp, DosyaApp>();
            services.AddScoped<IAracTalepRepository, AracTalepRepository>();
            services.AddScoped<IAracTalepApp, AracTalepApp>();
            services.AddScoped<IAracBeklemeDurumRepository, AracBeklemeDurumRepository>();
            services.AddScoped<IAracBeklemeDurumApp, AracBeklemeDurumApp>();
            #endregion
            //services.AddScoped<IValidator<DtoDuyuruKaydet>, DtoDuyuruKaydetValidator>();
            //return services;
            return new ApplicationValidators().GetValidators(services);
        }
    }
}
