using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repos.KategoriTipRepos
{
    public class KategoriTipRepository : Repository<KategoriTip>, IKategoriTipRepository
    {
        public KategoriTipRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
