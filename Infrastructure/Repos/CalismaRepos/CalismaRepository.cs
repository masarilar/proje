using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repos.CalismaRepos
{
    public class CalismaRepository : Repository<CalismaTur>, ICalismaRepository
    {
        public CalismaRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
