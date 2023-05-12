namespace Application.Interfaces {
    public interface IUnitOfWork : IDisposable{
        Task<int> CommitDatabase(bool state = true);
    }
}
