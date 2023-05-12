using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IDosyaRepository : IRepository<Dosya>
    {
        IQueryable<Dosya> GetAllListAsync(Func<Dosya, bool> predicate);
        Task<Dosya> GetAsync(Expression<Func<Dosya, bool>> predicate);
    }
}
