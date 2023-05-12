using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repos.GorevRepos
{
    public class GorevRepository : Repository<Gorev>, IGorevRepository
    {
        public GorevRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
