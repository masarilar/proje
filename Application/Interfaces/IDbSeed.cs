namespace Application.Interfaces {
    public interface IDbSeed {
        Task SeedData(IServiceProvider service);
    }
}
