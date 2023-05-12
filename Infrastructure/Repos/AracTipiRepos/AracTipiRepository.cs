using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repos.AracTipiRepos
{
    public class AracTipiRepository : Repository<AracTipi>, IAracTipiRepository
    {
        public AracTipiRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
