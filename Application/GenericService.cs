using Application.Interfaces;

namespace Application {
    public class GenericService<T> : IGenericService<T> where T : class, new() {
        private readonly IRepository<T> _repository;

        public GenericService(IRepository<T> repository) {
            _repository = repository;
        }

        public async Task<int> AddAsync(T entity) => await _repository.AddAsync(entity);
        public async Task<IQueryable<int>> AddRangeAsync(IEnumerable<T> entities) => await _repository.AddRangeAsync(entities);
        public async Task<IQueryable<T>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<T> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task<int> RemoveAsync(T entity) => await _repository.RemoveAsync(entity);
        public async Task<int> RemoveAsync(int id) => await _repository.RemoveAsync(id);
        public async Task<IQueryable<int>> RemoveRangeAsync(IEnumerable<T> entites) => await _repository.RemoveRangeAsync(entites);
        public async Task<IQueryable<int>> RemoveRangeAsync(List<int> idList) => await _repository.RemoveRangeAsync(idList);
        public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
        public async Task<int> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
        public async Task<IQueryable<int>> UpdateRangeAsync(IEnumerable<T> entities) => await _repository.UpdateRangeAsync(entities);
    }
}
