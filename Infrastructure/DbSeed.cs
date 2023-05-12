using Application.Interfaces;
using System.Reflection;

namespace Infrastructure {
    public static class DbSeed {
        public static async Task SeedData(IServiceProvider services) {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(e => {
                    var interfacess = e.GetInterfaces();
                    return !e.IsAbstract && interfacess.Any(f => f == typeof(IDbSeed));
                });

            var dbSeeds = types.Select(e => Activator.CreateInstance(e) as IDbSeed);

            foreach (var dbSeed in dbSeeds) {
                if (dbSeed == null) {
                    throw new Exception("Something Wrong");
                }
                await dbSeed.SeedData(services);
            }
        }
    }
}
