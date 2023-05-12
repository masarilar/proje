using Microsoft.Extensions.FileProviders;
using WebUI.Genel;

namespace WebUI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRestSharpRequest, RestSharpRequest>();

            var filePathsConfiguration = configuration.GetSection("FilePaths").Get<string[]>();
            if (filePathsConfiguration != null)
            {
                var fileProviders = new List<IFileProvider>();
                var firstFileProviderFullPath = Path.GetFullPath(filePathsConfiguration[0]);
                foreach (var item in filePathsConfiguration)
                {
                    var fullPath = Path.GetFullPath(item);
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                    fileProviders.Add(new PhysicalFileProvider(fullPath));
                }
                var fileProvider = new CompositeFileProvider(fileProviders);
                services.AddSingleton<IFileProvider>(fileProvider);
                services.AddSingleton<IDosyaServis>(new DosyaServis(firstFileProviderFullPath, fileProvider));

                return new ApplicationValidators().GetValidators(services);
            }

            return services;
        }
    }
}
